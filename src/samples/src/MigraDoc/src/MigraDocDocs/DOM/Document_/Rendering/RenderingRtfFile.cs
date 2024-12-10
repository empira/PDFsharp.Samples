// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using MigraDoc.DocumentObjectModel;
using MigraDoc.RtfRendering;
// ReSharper disable InvalidXmlDocComment

namespace MigraDocDocs.DOM.Document_.Rendering
{
    /// <summary>
    /// "Rendering an RTF file" chapter.
    /// </summary>
    static class RenderingRtfFile
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Document/Rendering";
        
        const string Filename = $"{Path}/RenderingRtfFile.rtf";
        const string SampleName = "Rendering an RTF file";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            section.AddParagraph(SampleName);

            section.AddParagraph("Test document");
            
            // --- Sample content / Rendering
            
            // Create an RTF renderer for the MigraDoc document.
            var rtfRenderer = new RtfDocumentRenderer();
            
            // Layout and render document to RTF.
            rtfRenderer.Render(document, Filename, Environment.CurrentDirectory);

            return Filename;
        }
    }
}
