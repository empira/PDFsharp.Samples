// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace HelloMigraDoc
{
    public class Cover
    {
        /// <summary>
        /// Defines the cover page.
        /// </summary>
        public static void DefineCover(Document document)
        {
            var section = document.AddSection();

            var paragraph = section.AddParagraph();
            paragraph.Format.SpaceAfter = "3cm";

            var image = section.AddImage("../../../../../../../../../assets/migradoc/images/MigraDoc-landscape.png");
            image.Width = "10cm";

            paragraph = section.AddParagraph("A sample document that demonstrates the\ncapabilities of ");
            paragraph.AddFormattedText("MigraDoc", TextFormat.Bold);
            paragraph.Format.Font.Size = 16;
            paragraph.Format.Font.Color = Colors.DarkRed;
            paragraph.Format.SpaceBefore = "8cm";
            paragraph.Format.SpaceAfter = "3cm";

            paragraph = section.AddParagraph("Rendering date: ");
            paragraph.AddDateField();

            paragraph = section.AddParagraph($"Version: {MigraDocRenderingBuildInformation.GitSemVer}");
            paragraph = section.AddParagraph($"Branch: {MigraDocRenderingBuildInformation.BranchName}");
            paragraph = section.AddParagraph($"Assembly: {MigraDocRenderingBuildInformation.AssemblyTitle}");
            paragraph = section.AddParagraph($"Platform: ");
            var platform = MigraDocRenderingBuildInformation.TargetPlatform;
            if (String.IsNullOrEmpty(platform))
                paragraph.AddFormattedText("(none)", TextFormat.Italic);
            else
                paragraph.AddText(platform);
        }
    }
}
