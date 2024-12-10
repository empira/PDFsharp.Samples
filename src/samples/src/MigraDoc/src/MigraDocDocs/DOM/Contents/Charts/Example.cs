// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
// ReSharper disable InvalidXmlDocComment

namespace MigraDocDocs.DOM.Contents.Charts
{
    /// <summary>
    /// "Introduction" chapter.
    /// </summary>
    static class Example
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Contents/Charts";
        
        const string Filename = $"{Path}/Example.pdf";
        const string SampleName = "Example";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content
            
            // Add a chart.
            var chart = section.AddChart(ChartType.Pie2D);

            // Format the border and size.
            chart.LineFormat.Color = Colors.DarkGray;
            chart.LineFormat.Width = Unit.FromPoint(1);
            chart.Width = Unit.FromCentimeter(16);
            chart.Height = Unit.FromCentimeter(12);

            // Add a padding around the pie.
            chart.PlotArea.TopPadding = Unit.FromCentimeter(1);
            chart.PlotArea.RightPadding = Unit.FromCentimeter(1);
            chart.PlotArea.BottomPadding = Unit.FromCentimeter(1);
            chart.PlotArea.LeftPadding = Unit.FromCentimeter(1);

            // Add a series and format it.
            var series = chart.SeriesCollection.AddSeries();
            series.HasDataLabel = true;
            series.DataLabel.Position = DataLabelPosition.Center;
            series.DataLabel.Font.Size = Unit.FromPoint(12);
            series.DataLabel.Font.Bold = true;
            series.LineFormat.Color = Color.FromRgb(96, 96, 96);

            // Add some data and format it.
            var point = series.Add(32);
            point.FillFormat.Color = Colors.MediumOrchid;

            point = series.Add(20);
            point.FillFormat.Color = Colors.DodgerBlue;

            point = series.Add(11);
            point.FillFormat.Color = Colors.Chocolate;

            point = series.Add(7);
            point.FillFormat.Color = Colors.LimeGreen;

            // Add the names for the data.
            var xSeries = chart.XValues.AddXSeries();
            xSeries.Add("Value 1", "Value 2", "Value 3", "Value 4");

            // Add and format the legend.
            var legend = chart.RightArea.AddLegend();
            legend.LineFormat.Color = Colors.DarkGray;
            legend.LineFormat.Width = Unit.FromPoint(1);

            // --- Rendering

            // Create a renderer for the MigraDoc document.
            var pdfRenderer = new PdfDocumentRenderer
            {
                // Associate the MigraDoc document with a renderer.
                Document = document,
                // Let the PDF viewer show this PDF with full pages.
                PdfDocument =
                {
                    PageLayout = PdfPageLayout.SinglePage,
                    ViewerPreferences =
                    {
                        FitWindow = true
                    }
                }
            };

            // Layout and render document to PDF.
            pdfRenderer.RenderDocument();

            // Add sample-specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, SampleName);

            // Save the document.
            pdfRenderer.Save(Filename);

            return Filename;
        }
    }
}
