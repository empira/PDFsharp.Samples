// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

global using System.Diagnostics;
using MigraDoc;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using PdfSharp.Snippets.Font;

namespace HelloMigraDoc
{
    class Program
    {
        static void Main(string[] args)
        {
            // NET6FIX
            if (PdfSharp.Capabilities.Build.IsCoreBuild)
                GlobalFontSettings.FontResolver = new FailsafeFontResolver();
            
            // Create a MigraDoc document.
            var document = Documents.CreateDocument();

            // Write MigraDoc DDL into a string.
            var ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);

            // Write MigraDoc DDL to a file.
            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

            var renderer = new PdfDocumentRenderer()
            {
                Document = document
            };

            renderer.RenderDocument();

            // Save the document...
            var filename = "HelloMigraDoc.pdf";
            renderer.PdfDocument.Save(filename);

            // ...and start a viewer.
            Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });
        }
    }
}
