// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using System.Diagnostics;
using System.Reflection;
using MigraDoc.Rendering;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Quality;

namespace MigraDocDocs
{
    static class Helper
    {
        public const string DocsRoot = "PDFs";

        /// <summary>
        /// Creates all directories from fields decorated with AutoCreatePathAttribute to be required for PDf creation.
        /// </summary>
        public static void CreateTargetPaths()
        {
            var assembly = typeof(Helper).Assembly;
            foreach (var type in assembly.GetTypes())
            {
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                var attributeFields = fields.Where(prop => Attribute.IsDefined(prop, typeof(AutoCreatePathAttribute)));
                foreach (var field in attributeFields)
                {
                    if (field.FieldType != typeof(string))
                        throw new NotSupportedException($"Field \"{type.Namespace}.{field.Name}\" is decorated with AutoCreatePathAttribute, but not a string.");

                    var path = (string?)field.GetRawConstantValue();

                    if (String.IsNullOrEmpty(path))
                        throw new NotSupportedException($"Field \"{type.Namespace}.{field.Name}\" is decorated with AutoCreatePathAttribute, but the given path is empty.");

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                }
            }
        }
        
        public static string GetDisplayPath(string[] pathParts)
        {
            IEnumerable<string> resultPathParts = pathParts;

            if (resultPathParts.FirstOrDefault() == DocsRoot)
                resultPathParts = resultPathParts.Skip(1);

            resultPathParts = resultPathParts.Prepend("MigraDoc");

            var displayPath = String.Join(" / ", resultPathParts);

            return displayPath;
        }

        public static string GetDisplayPath(string chapterPath, string? sampleName = null)
        {
            chapterPath = chapterPath.Trim(PathSeparators);
            IEnumerable<string> pathParts = chapterPath.Split(PathSeparators);

            if (!String.IsNullOrEmpty(sampleName))
                pathParts = pathParts.Append(sampleName + " sample");

            var displayPath = GetDisplayPath(pathParts.ToArray());

            return displayPath;
        }

        public static void AddSampleNameHeading(PdfDocumentRenderer pdfRenderer, string chapterPath, string sampleName)
        {
            var displayPath = GetDisplayPath(chapterPath, sampleName);

            var pdfDocument = pdfRenderer.PdfDocument;

            foreach (var pdfPage in pdfDocument.Pages)
            {
                var gfx = XGraphics.FromPdfPage(pdfPage);

                var font = new XFont("Arial", 10);

                gfx.DrawString(displayPath, font, XBrushes.Black, new XRect(10, 10, pdfPage.Width.Point - 20, 10), XStringFormats.TopLeft);
            }
        }

        public static void CreateSample(AutomaticGeneration? automaticGeneration, Func<string> createSample)
        {
            string filename;
            try
            {
                filename = createSample();
            }
            catch (Exception e)
            {
                var name = GetSampleNameFromFunction(createSample);

                Console.WriteLine($"Sample \"{name}\" could not be created due to an exception:\n" +
                                  $"{e.Message}");
                Console.WriteLine("Press any key to continue.");
                Console.WriteLine();
                Console.ReadKey();
                return;
            }

            // For automatic generation collect result files.
            if (automaticGeneration != null)
                automaticGeneration.AddResultFile(filename);
            // For manual generation handle result.
            else
                Menu.HandleResult(filename);
        }

        static string GetSampleNameFromFunction(Func<string> createSample)
        {
            try
            {
                var type = createSample.Method.DeclaringType;
                if (type != null)
                {
                    // Get value of SampleName constant.
                    var sampleNameInfo = type.GetField("SampleName", BindingFlags.Static | BindingFlags.NonPublic);
                    if (sampleNameInfo != null)
                    {
                        var sampleNameObj = sampleNameInfo.GetValue(null);
                        if (sampleNameObj is string sampleName)
                        {
                            // Get value of Path constant.
                            var pathInfo = type.GetField("Path", BindingFlags.Static | BindingFlags.NonPublic);
                            if (pathInfo != null)
                            {
                                var pathObj = pathInfo.GetValue(null);
                                if (pathObj is string path)
                                {
                                    if (path.StartsWith("PDFs"))
                                        path = "MigraDoc" + path[4..];
                                    path = path.Replace("/", " / ");

                                    // Return sample name with path.
                                    sampleName = $"{path} / {sampleName}";
                                    return sampleName;
                                }
                            }

                            // Return sample name without path.
                            return sampleName;
                        }
                    }
                }
            }
            catch
            {
                // Nothing 
            }

            // Return method name.
            var name = createSample.Method.Name;
            return name;
        }

        public static void ShowDocumentIfDebugging(string filename)
        {
            if (!Debugger.IsAttached)
                return;

            // Process.Start seems not to handle windows AltDirectorySeparatorChar correctly.
            if (Capabilities.OperatingSystem.IsWindows)
            {
                filename = filename.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            }

            PdfFileUtility.ShowDocumentIfDebugging(filename);
        }
        
        static readonly char[] PathSeparators = ['\\', '/'];
    }
}