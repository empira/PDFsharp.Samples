// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;

namespace HelloMigraDoc
{
    public class Charts
    {
        /// <summary>
        /// Defines the charts page.
        /// </summary>
        public static void DefineCharts(Document document)
        {
            var paragraph = document.LastSection.AddParagraph("Chart Overview", StyleNames.Heading1);
            paragraph.AddBookmark(BookmarkName);

            document.LastSection.AddParagraph("Sample Chart", StyleNames.Heading2);

            var chart = new Chart();
            chart.Left = 0;
            chart.Width = Unit.FromCentimeter(16);
            chart.Height = Unit.FromCentimeter(12);

            var series = chart.SeriesCollection.AddSeries();
            series.ChartType = ChartType.Column2D;
            series.Add(1, 17, 45, 5, 3, 20, 11, 23, 8, 19);
            series.HasDataLabel = true;

            series = chart.SeriesCollection.AddSeries();
            series.ChartType = ChartType.Line;
            series.Add(41, 7, 5, 45, 13, 10, 21, 13, 18, 9);

            var xSeries = chart.XValues.AddXSeries();
            xSeries.Add("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N");

            chart.XAxis.Title.Caption = "X-Axis";

            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;

            chart.PlotArea.LineFormat.Color = Colors.DarkGray;
            chart.PlotArea.LineFormat.Width = 1;

            document.LastSection.Add(chart);
        }

        public const string BookmarkName = "Charts";
    }
}
