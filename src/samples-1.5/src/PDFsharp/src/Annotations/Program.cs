// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Quality;

namespace Annotations
{
    /// <summary>
    /// This sample shows how to create annotations.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Create a new PDF document.
            var document = new PdfDocument();
            document.PageLayout = PdfPageLayout.SinglePage;
            document.ViewerPreferences.FitWindow = true;

            // Create a font
            var font = new XFont("Verdana", 14);
            //var font = new XFont("Segoe WP", 20, XFontStyleEx.BoldItalic);

            // Create a page.
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Create a PDF text annotation.
            var textAnnot = new PdfTextAnnotation
            {
                Title = "This is the title",
                Subject = "This is the subject",
                Contents = "This is the contents of the annotation.\rThis is the 2nd line.",
                Icon = PdfTextAnnotationIcon.Note
            };

            gfx.DrawString("The first text annotation", font, XBrushes.Black, 30, 50, XStringFormats.Default);

            // Convert rectangle form world space to page space. This is necessary because the annotation is
            // placed relative to the bottom left corner of the page with units measured in point.
            var rect = gfx.Transformer.WorldToDefaultPage(new XRect(new XPoint(30, 60), new XSize(30, 30)));
            textAnnot.Rectangle = new PdfRectangle(rect);

            // Add the annotation to the page.
            page.Annotations.Add(textAnnot);

            // Create another PDF text annotation which is open and transparent.
            textAnnot = new PdfTextAnnotation
            {
                Title = "Annotation 2 (title)",
                Subject = "Annotation 2 (subject)",
                Contents = "This is the contents of the 2nd annotation.",
                Icon = PdfTextAnnotationIcon.Help,
                Color = XColors.LimeGreen,
                Opacity = 0.5,
                Open = true
            };

            gfx.DrawString("The second text annotation (opened)", font, XBrushes.Black, 30, 140, XStringFormats.Default);

            rect = gfx.Transformer.WorldToDefaultPage(new XRect(new XPoint(30, 150), new XSize(30, 30)));
            textAnnot.Rectangle = new PdfRectangle(rect);

            // Add the 2nd annotation to the page.
            page.Annotations.Add(textAnnot);


            // Create a so-called rubber stamp annotation. I'm not sure if it is useful, but at least
            // it looks impressive...
            var rsAnnot = new PdfRubberStampAnnotation
            {
                Icon = PdfRubberStampAnnotationIcon.TopSecret,
                Flags = PdfAnnotationFlags.ReadOnly
            };

            rect = gfx.Transformer.WorldToDefaultPage(new XRect(new XPoint(100, 400), new XSize(350, 150)));
            rsAnnot.Rectangle = new PdfRectangle(rect);

            // Add the rubber stamp annotation to the page.
            page.Annotations.Add(rsAnnot);

            // PDF supports some more pretty types of annotations like PdfLineAnnotation, PdfSquareAnnotation,
            // PdfCircleAnnotation, PdfMarkupAnnotation (with the subtypes PdfHighlightAnnotation, PdfUnderlineAnnotation,
            // PdfStrikeOutAnnotation, and PdfSquigglyAnnotation), PdfSoundAnnotation, or PdfMovieAnnotation.
            // If you need one of them, feel encouraged to implement it. It is quite easy.

            // Save the document...
            var filename = PdfFileUtility.GetTempPdfFullFileName("samples-1.5/Annotations");
            document.Save(filename);
            // ...and start a viewer.
            PdfFileUtility.ShowDocument(filename);
        }
    }
}
