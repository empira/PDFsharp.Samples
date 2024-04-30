// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Quality;
using PdfSharp.UniversalAccessibility;

namespace UAFeatures.Features
{
    class SampleDocument : FeatureBase
    {
        public static void Run()
        {
            new SampleDocument().CreatePdf();
        }

        PdfDocument _document = default!;

        // Create a font (nothing special here).
        readonly XFont _fontBig = new XFont("Arial", 12, XFontStyleEx.Italic);
        readonly XFont _font = new XFont("Arial ", 10);
        readonly XFont _fontHeader = new XFont("Arial", 10, XFontStyleEx.Italic);
        readonly XFont _fontH1 = new XFont("Arial", 30, XFontStyleEx.Italic);
        readonly XFont _fontH2 = new XFont("Arial", 20, XFontStyleEx.Underline);
        readonly XFont _fontH3 = new XFont("Arial", 16, XFontStyleEx.Italic);
        readonly XFont _fontTH = new XFont("Arial", 10, XFontStyleEx.Bold);

        void CreatePdf()
        {
            InitializeDocument();

            CreateCover();
            CreateTOC();

            CreatePartTextSamples();
            CreatePartListSamples();
            CreatePartTableSamples();

            SaveAndShowDocument(_document, "SampleDocument");
        }

        void InitializeDocument()
        {
            // Create PDF document.
            _document = new PdfDocument();
            _document.ViewerPreferences.FitWindow = true;
            _document.PageLayout = PdfPageLayout.SinglePage;
        }

        void CreateContentPage()
        {
            // Break to new page.
            var page = _document.AddPage();
            // The next line is required to get this XGraphics object later via uaManager.CurrentGraphics.
            XGraphics.FromPdfPage(page);

            Debug.Assert(page.Reference is not null, "Page cannot be a direct object.");
            var pageNumber = _document.Pages.PagesArray.Elements.IndexOf(page.Reference!) + 1;

            // The order of artifacts is not relevant, so we can create header and footer immediately after creating the page.
            CreateHeader();
            CreateFooter(pageNumber);
        }

        void CreateHeader()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Insert a header as an artifact.
            sb.BeginArtifact();
            {
                // This text is, as it is included in the artifact, not handled as actual content of the document. A screen reader will skip this text.
                gfx.DrawString("A sample PDF/UA document - created with PDFsharp", _fontHeader, XBrushes.Gray, 50, 50);
            }
            sb.End();
        }

        void CreateFooter(int page)
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Insert a footer as an artifact.
            sb.BeginArtifact();
            {
                // This text is, as it is included in the artifact, not handled as actual content of the document. A screen reader will skip this text.
                gfx.DrawString("Page " + page, _fontHeader, XBrushes.Gray, 280, 810);
            }
            sb.End();
        }

        void CreateSeparator(int y)
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            sb.BeginArtifact();
            gfx.DrawString("//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////", _font, XBrushes.Black, 50, y);
            sb.End();
        }

        void CreateCover()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Create a page and a graphics object as usual.
            var page = _document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Create Heading 1 element.
            sb.BeginElement(PdfBlockLevelElementTag.Heading1);
            gfx.DrawString("A sample PDF/UA document", _fontH1, XBrushes.DarkBlue, 150, 200);
            sb.End();

            sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
            gfx.DrawString("created with PDFsharp", _fontBig, XBrushes.DarkBlue, 150, 230);
            sb.End();
        }

        void CreateTOC()
        {
            // Break to second page.
            CreateContentPage();

            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create the TOC part element.
            sb.BeginElement(PdfGroupingElementTag.Part);
            {
                // Insert the TOC heading.
                sb.BeginElement(PdfBlockLevelElementTag.Heading2);
                gfx.DrawString("Table of contents", _fontH2, XBrushes.DarkBlue, 50, 150);
                sb.End();

                // Insert the first TOC entry as a link.
                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                {
                    // Create the links bounding rect.
                    var rect = new PdfRectangle(gfx.Transformer.WorldToDefaultPage(new XRect(50, 190, 480, 25)));

                    // Create a LinkAnnotation referencing to page 3.
                    var link = PdfLinkAnnotation.CreateDocumentLink(rect, 3);

                    // Create a new Link structure element with the LinkAnnotation and the alternative text passed as parameters.
                    sb.BeginElement(link, "Link to Text Samples chapter");
                    {
                        // Insert the text shown as link.
                        gfx.DrawString("Text Samples ", _fontBig, XBrushes.DarkBlue, 50, 200);
                        // Insert the points as an artifact so that they won't be read.
                        sb.BeginArtifact();
                        gfx.DrawString(".............................................................................................................................................................", _fontBig, XBrushes.DarkBlue, 120, 200);
                        sb.End();
                        gfx.DrawString("3", _fontBig, XBrushes.DarkBlue, 530, 200);
                    }
                    sb.End();
                }
                sb.End();

                // Insert the second TOC entry as a link.
                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                {
                    // Create the links bounding rect.
                    var rect = new PdfRectangle(gfx.Transformer.WorldToDefaultPage(new XRect(50, 220, 480, 25)));

                    // Create a LinkAnnotation referencing to page 5.
                    var link = PdfLinkAnnotation.CreateDocumentLink(rect, 5);

                    // Create a new Link structure element with the LinkAnnotation and the alternative text passed as parameters.
                    sb.BeginElement(link, "Link to List Samples chapter");
                    {
                        // Insert the text shown as link.
                        gfx.DrawString("List Samples ", _fontBig, XBrushes.DarkBlue, 50, 230);
                        // Insert the points as an artifact so that they won't be read.
                        sb.BeginArtifact();
                        gfx.DrawString("..............................................................................................................................................................", _fontBig, XBrushes.DarkBlue, 116, 230);
                        sb.End();
                        gfx.DrawString("5", _fontBig, XBrushes.DarkBlue, 530, 230);
                    }
                    sb.End();
                }
                sb.End();

                // Insert the third TOC entry as a link.
                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                {
                    // Create the links bounding rect.
                    var rect = new PdfRectangle(gfx.Transformer.WorldToDefaultPage(new XRect(50, 250, 480, 25)));

                    // Create a LinkAnnotation referencing to page 6.
                    var link = PdfLinkAnnotation.CreateDocumentLink(rect, 6);

                    // Create a new Link structure element with the LinkAnnotation and the alternative text passed as parameters.
                    sb.BeginElement(link, "Link to Table Samples chapter");
                    {
                        // Insert the text shown as link.
                        gfx.DrawString("Table Samples ", _fontBig, XBrushes.DarkBlue, 50, 260);
                        // Insert the points as an artifact so that they won't be read.
                        sb.BeginArtifact();
                        gfx.DrawString("..........................................................................................................................................................", _fontBig, XBrushes.DarkBlue, 127, 260);
                        sb.End();
                        gfx.DrawString("6", _fontBig, XBrushes.DarkBlue, 530, 260);
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();
        }

        void CreatePartTextSamples()
        {
            // Break to third page.
            CreateContentPage();

            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create the Text Samples part element.
            sb.BeginElement(PdfGroupingElementTag.Part);
            {
                // Insert the Text Samples heading.
                sb.BeginElement(PdfBlockLevelElementTag.Heading2);
                gfx.DrawString("Text Samples", _fontH2, XBrushes.DarkBlue, 50, 100);
                sb.End();

                CreateTextArt1();

                CreateSeparator(410);

                CreateTextArt2();

                CreateSeparator(145);

                CreateTextArt3();

                CreateSeparator(415);

                CreateTextArt4();
            }
            sb.End();
        }

        void CreateTextArt1()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create the first article's element.
            sb.BeginElement(PdfGroupingElementTag.Article);
            {
                // Insert the first article's heading.
                sb.BeginElement(PdfBlockLevelElementTag.Heading3);
                gfx.DrawString("Structure Tree, screen readers and recognizing word breaks", _fontH3, XBrushes.Black, 50, 150);
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                gfx.DrawString("This is the first paragraph of the first article. It is written in one column and it is drawn with several DrawString() ", _font, XBrushes.Black, 50, 170);
                gfx.DrawString("calls, but the Structure Tree gives the screen reader the information, that all this text belongs to the same ", _font, XBrushes.Black, 50, 185);
                gfx.DrawString("paragraph. Note, that in the document's source code all the DrawString() calls get a string ending with a blank. ", _font, XBrushes.Black, 50, 200);
                gfx.DrawString("This blank is necessary for the screen reader, which has to determinate the word breaks. Just write the text like ", _font, XBrushes.Black, 50, 215);
                gfx.DrawString("you were writing it as pure text without the surrounding source code.", _font, XBrushes.Black, 50, 230);
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                gfx.DrawString("Note that the text in the last DrawString() of the previous paragraph doesn't have a trailing blank. Because this ", _font, XBrushes.Black, 50, 250);
                gfx.DrawString("text here is standing in a new block level element - a new paragraph in this case - there is no blank needed for ", _font, XBrushes.Black, 50, 265);
                gfx.DrawString("word break identification between the last word of the previous paragraph and the first word of the current one.", _font, XBrushes.Black, 50, 280);
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                gfx.DrawString("One of the purposes of the Structure Tree is to define ", _font, XBrushes.Black, 50, 320);
                gfx.DrawString("logical order and hierarchy of the text contents. This ", _font, XBrushes.Black, 50, 335);
                gfx.DrawString("order must not always be the usual left to right and ", _font, XBrushes.Black, 50, 350);
                gfx.DrawString("top to bottom order. Imagine a paragraph like this, ", _font, XBrushes.Black, 50, 365);
                gfx.DrawString("which is written in two columns. Because the Structure ", _font, XBrushes.Black, 50, 380);

                gfx.DrawString("Tree is providing the right content order, a screen ", _font, XBrushes.Black, 320, 320);
                gfx.DrawString("reader can read - like you would expect - the first ", _font, XBrushes.Black, 320, 335);
                gfx.DrawString("column before it continues reading the second ", _font, XBrushes.Black, 320, 350);
                gfx.DrawString("one. In PDFsharp the contents must be created in ", _font, XBrushes.Black, 320, 365);
                gfx.DrawString("the order it should appear in the structure tree. ", _font, XBrushes.Black, 320, 380);
                sb.End();
            }
            sb.End();
        }

        void CreateTextArt2()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create the second article's element.
            sb.BeginElement(PdfGroupingElementTag.Article);
            {
                // Insert the second article's heading.
                sb.BeginElement(PdfBlockLevelElementTag.Heading3);
                gfx.DrawString("Artifacts, images and word division", _fontH3, XBrushes.Black, 50, 440);
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                gfx.DrawString("Probably you have noticed that there are some contents of the page that are not read by the screen reader, like ", _font, XBrushes.Black, 50, 460);
                gfx.DrawString("the separator consisting of slashes above or the header and footer. These contents are marked as artifacts. An ", _font, XBrushes.Black, 50, 475);
                gfx.DrawString("artifact's content is not read, because it is per definition no relevant content of the page. ", _font, XBrushes.Black, 50, 490);
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                {
                    gfx.DrawString("An image on the other hand is, if it's not just a background image for design purposes, relevant content. ", _font, XBrushes.Black, 50, 510);
                    gfx.DrawString("To make a document accessible, an image must define a bounding box and an alternative text, which is ", _font, XBrushes.Black, 50, 525);
                    gfx.DrawString("describing what you would see on the picture. If you place an image on a page maybe the text should flow ", _font, XBrushes.Black, 50, 540);

                    gfx.DrawString("around it and maybe the image is ", _font, XBrushes.Black, 370, 555);
                    gfx.DrawString("not placed at the position it is ", _font, XBrushes.Black, 370, 570);
                    gfx.DrawString("handled in the text. Its position in the ", _font, XBrushes.Black, 370, 585);
                    gfx.DrawString("structure tree, however, is defined ", _font, XBrushes.Black, 370, 600);
                    gfx.DrawString("by the position of the image in the ", _font, XBrushes.Black, 370, 615);
                    gfx.DrawString("document's source code.", _font, XBrushes.Black, 370, 630);

                    // Insert an image with a defined size.
                    // Create the figure and pass its alternate text and its bounding box as a parameter.
                    sb.BeginElement(PdfIllustrationElementTag.Figure, "A BMW Z3 driving through a sandstone desert.", new XRect(50, 555, 300, 225));
                    {
                        // Add the image as usual.
                        gfx.DrawImage(XImage.FromFile(IOUtility.GetAssetsPath(@"archives\samples-1.5\images\Z3.jpg")!), 50, 555, 300, 225);
                    }
                    sb.End();
                }
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                {
                    gfx.DrawString("Especially in small columns long ", _font, XBrushes.Black, 370, 650);
                    gfx.DrawString("words often must be divided to pro\u00AD", _font, XBrushes.Black, 370, 665);
                    gfx.DrawString("vide a reasonable text layout. Note ", _font, XBrushes.Black, 370, 680);
                    gfx.DrawString("that all these hyphens must be repre\u00AD", _font, XBrushes.Black, 370, 695);
                    gfx.DrawString("sented by soft hyphens (Unicode ", _font, XBrushes.Black, 370, 710);
                    gfx.DrawString("U+00AD). This way the screen reader ", _font, XBrushes.Black, 370, 725);
                    gfx.DrawString("can clearly identify the hyphen as a ", _font, XBrushes.Black, 370, 740);
                    gfx.DrawString("word division and read the text ", _font, XBrushes.Black, 370, 755);
                    gfx.DrawString("correctly. Of course, there should be ", _font, XBrushes.Black, 370, 770);
                    gfx.DrawString("no trailing blank indicating a word ", _font, XBrushes.Black, 370, 785);

                    // Break to fourth page.
                    CreateContentPage();

                    // Get current graphics for fourth page.
                    gfx = uaManager.CurrentGraphics;

                    gfx.DrawString("break after a soft hyphen. Oh, by the way, we now had a pagebreak in the middle of a sentence. But because we ", _font, XBrushes.Black, 50, 100);
                    gfx.DrawString("did not close the last paragraph, this text still belongs to the last paragraph on the previous page.", _font, XBrushes.Black, 50, 115);
                }
                sb.End();
            }
            sb.End();
        }

        void CreateTextArt3()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create the third article's element.
            sb.BeginElement(PdfGroupingElementTag.Article);
            {
                // Insert the third article's heading.
                sb.BeginElement(PdfBlockLevelElementTag.Heading3);
                gfx.DrawString("Abbreviation and language", _fontH3, XBrushes.Black, 50, 175);
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                gfx.DrawString("If a screen reader reads some text, there are some pitfalls we should beware of. One is abbreviations. A famous ", _font, XBrushes.Black, 50, 195);
                gfx.DrawString("well known example is the abbreviation \"Dr.\". In dependence of the context it could mean \"doctor\" or \"drive\". ", _font, XBrushes.Black, 50, 210);
                gfx.DrawString("With a span containing the expanded text we can provide the correct expanded word: ", _font, XBrushes.Black, 50, 225);
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                {
                    // Insert a Span for an abbreviation.
                    sb.BeginElement(PdfInlineLevelElementTag.Span);
                    {
                        // Draw the abbreviation.
                        gfx.DrawString("Dr.", _font, XBrushes.Black, 70, 245);
                        // Set the expanded text for the abbreviation. Note that we also need the trailing blank here, if there was one in pure text representation.
                        sb.SetExpandedText("Doctor ");
                    }
                    sb.End();

                    gfx.DrawString("Healwell works at 123 Industrial ", _font, XBrushes.Black, 85, 245);

                    // Insert a Span for an abbreviation.
                    sb.BeginElement(PdfInlineLevelElementTag.Span);
                    {
                        // Draw the abbreviation.
                        gfx.DrawString("Dr.", _font, XBrushes.Black, 227, 245);
                        // Set the expanded text for the abbreviation. Note that we also need the trailing blank here, if there was one in pure text representation.
                        sb.SetExpandedText("Drive.");
                    }
                    sb.End();
                }
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                gfx.DrawString("The second pitfall is the language. If we write text in another language we won't care about the pronunciation. ", _font, XBrushes.Black, 50, 265);
                gfx.DrawString("But if a screen reader shall be able to read the text correctly, we should define the used language. PDFsharp ", _font, XBrushes.Black, 50, 280);
                gfx.DrawString("sets the document's language to English by default. ", _font, XBrushes.Black, 50, 295);
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                gfx.DrawString("If we simply write text in a different language, like \"Herzlichen Glückwunsch\", the screen reader will read that ", _font, XBrushes.Black, 50, 320);
                gfx.DrawString("text with the pronunciation of the document's language, which is obviously wrong in this case. To get the ", _font, XBrushes.Black, 50, 335);
                gfx.DrawString("correct pronunciation we can set the language at any Structure Element. This way we change the language for ", _font, XBrushes.Black, 50, 350);
                gfx.DrawString("the Structure Element and even its children, if it has some: ", _font, XBrushes.Black, 50, 365);
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                {
                    // Change the language for the current structure element.
                    sb.SetLanguage("de-DE");

                    // Insert the text in the new language.
                    gfx.DrawString("\"Herzlichen Glückwunsch!\" ", _font, XBrushes.Black, 70, 385);
                }
                sb.End();
            }
            sb.End();
        }

        void CreateTextArt4()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create the fourth article's element.
            sb.BeginElement(PdfGroupingElementTag.Article);
            {
                // Insert the fourth article's heading.
                sb.BeginElement(PdfBlockLevelElementTag.Heading3);
                gfx.DrawString("Links", _fontH3, XBrushes.Black, 50, 445);
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                gfx.DrawString("For the use of links you can take a look at the table of contents. But beside internal links you can also define a ", _font, XBrushes.Black, 50, 465);
                gfx.DrawString("link to an external web page:", _font, XBrushes.Black, 50, 480);
                sb.End();

                sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
                {
                    // Create the links bounding rect.
                    var rect = new PdfRectangle(gfx.Transformer.WorldToDefaultPage(new XRect(new XPoint(70, 490), new XPoint(225, 505))));

                    // Create a LinkAnnotation referencing to the empira website.
                    var link = PdfLinkAnnotation.CreateWebLink(rect, "http://www.empira.de");

                    // Create a new Link structure element with the LinkAnnotation and the alternative text passed as parameters.
                    sb.BeginElement(link, "Link to empira website");
                    {
                        // Insert the text shown as link.
                        gfx.DrawString("This is a link to the empira website.", _font, XBrushes.Blue, 70, 500);
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();
        }

        void CreatePartListSamples()
        {
            // Break to fifth page.
            CreateContentPage();

            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create the List Samples part element.
            sb.BeginElement(PdfGroupingElementTag.Part);
            {
                // Insert the List Samples heading.
                sb.BeginElement(PdfBlockLevelElementTag.Heading2);
                gfx.DrawString("List Samples", _fontH2, XBrushes.DarkBlue, 50, 100);
                sb.End();

                CreateListArt1();

                CreateListArt2();

                CreateListArt3();

                CreateListArt4();
            }
            sb.End();
        }

        void CreateListArt1()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create the first article's element.
            sb.BeginElement(PdfGroupingElementTag.Article);
            {
                // Insert the first article's heading.
                sb.BeginElement(PdfBlockLevelElementTag.Heading3);
                gfx.DrawString("A simple list", _fontH3, XBrushes.Black, 50, 150);
                sb.End();

                // Create a new list.
                sb.BeginElement(PdfBlockLevelElementTag.List);
                {
                    // Create the first list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the first list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("-", _font, XBrushes.Black, 50, 170);
                        }
                        sb.End();

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("First Item", _font, XBrushes.Black, 70, 170);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the second list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the second list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("-", _font, XBrushes.Black, 50, 190);
                        }
                        sb.End();

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("Second Item", _font, XBrushes.Black, 70, 190);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the third list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the third list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("-", _font, XBrushes.Black, 50, 210);
                        }
                        sb.End();

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("Third Item", _font, XBrushes.Black, 70, 210);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the fourth list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the fourth list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("-", _font, XBrushes.Black, 50, 230);
                        }
                        sb.End();

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("Fourth Item", _font, XBrushes.Black, 70, 230);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the fifth list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the fifth list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("-", _font, XBrushes.Black, 50, 250);
                        }
                        sb.End();

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("Fifth Item", _font, XBrushes.Black, 70, 250);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the sixth list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the sixth list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("-", _font, XBrushes.Black, 50, 270);
                        }
                        sb.End();

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            // Insert a Span for an abbreviation.
                            sb.BeginElement(PdfInlineLevelElementTag.Span);
                            {
                                // Draw the abbreviation.
                                gfx.DrawString("etc.", _font, XBrushes.Black, 70, 270);
                                // Set the expanded text for the abbreviation.
                                sb.SetExpandedText("et cetera");
                            }
                            sb.End();
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();
        }

        void CreateListArt2()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create the second article's element.
            sb.BeginElement(PdfGroupingElementTag.Article);
            {
                // Insert the second article's heading.
                sb.BeginElement(PdfBlockLevelElementTag.Heading3);
                gfx.DrawString("A numbered list", _fontH3, XBrushes.Black, 225, 150);
                sb.End();

                // Create a new list.
                sb.BeginElement(PdfBlockLevelElementTag.List);
                {
                    // Create the first list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the first list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("1.", _font, XBrushes.Black, 225, 170);
                        }
                        sb.End();

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("First Item", _font, XBrushes.Black, 245, 170);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the second list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the second list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("2.", _font, XBrushes.Black, 225, 190);
                        }
                        sb.End();

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("Second Item", _font, XBrushes.Black, 245, 190);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the third list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the third list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("3.", _font, XBrushes.Black, 225, 210);
                        }
                        sb.End();

                        // Add the list item's content into a LBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("Third Item", _font, XBrushes.Black, 245, 210);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the fourth list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the fourth list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("4.", _font, XBrushes.Black, 225, 230);
                        }
                        sb.End();

                        // Add the list item's content into a LBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("Fourth Item", _font, XBrushes.Black, 245, 230);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the fifth list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the fifth list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("5.", _font, XBrushes.Black, 225, 250);
                        }
                        sb.End();

                        // Add the list item's content into a LBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("Fifth Item", _font, XBrushes.Black, 245, 250);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the sixth list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the sixth list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("6.", _font, XBrushes.Black, 225, 270);
                        }
                        sb.End();

                        // Add the list item's content into a LBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            // Insert a Span for an abbreviation.
                            sb.BeginElement(PdfInlineLevelElementTag.Span);
                            {
                                // Draw the abbreviation.
                                gfx.DrawString("etc.", _font, XBrushes.Black, 245, 270);
                                // Set the expanded text for the abbreviation.
                                sb.SetExpandedText("et cetera");
                            }
                            sb.End();
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();
        }

        void CreateListArt3()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create the third article's element.
            sb.BeginElement(PdfGroupingElementTag.Article);
            {
                // Insert the third article's heading.
                sb.BeginElement(PdfBlockLevelElementTag.Heading3);
                gfx.DrawString("A hierarchical list", _fontH3, XBrushes.Black, 380, 150);
                sb.End();

                // Create a new list.
                sb.BeginElement(PdfBlockLevelElementTag.List);
                {
                    // Create the first list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the first list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("1.", _font, XBrushes.Black, 380, 170);
                        }
                        sb.End();

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("First Item", _font, XBrushes.Black, 400, 170);

                            // Create a nested list.
                            sb.BeginElement(PdfBlockLevelElementTag.List);
                            {
                                // Create the first list item of the nested list.
                                sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                                {
                                    // Create the label of the nested list's first item.
                                    sb.BeginElement(PdfBlockLevelElementTag.Label);
                                    {
                                        gfx.DrawString("a)", _font, XBrushes.Black, 400, 190);
                                    }
                                    sb.End();

                                    // Add the list item's content into a ListBody structure element.
                                    sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                                    {
                                        gfx.DrawString("First subitem", _font, XBrushes.Black, 420, 190);
                                    }
                                    sb.End();
                                }
                                sb.End();

                                // Create the second list item of the nested list.
                                sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                                {
                                    // Create the label of the nested list's second item.
                                    sb.BeginElement(PdfBlockLevelElementTag.Label);
                                    {
                                        gfx.DrawString("b)", _font, XBrushes.Black, 400, 210);
                                    }
                                    sb.End();

                                    // Add the list item's content into a ListBody structure element.
                                    sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                                    {
                                        gfx.DrawString("Second subitem", _font, XBrushes.Black, 420, 210);
                                    }
                                    sb.End();
                                }
                                sb.End();
                            }
                            sb.End();
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the second list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        // Create the label of the second list item.
                        sb.BeginElement(PdfBlockLevelElementTag.Label);
                        {
                            gfx.DrawString("2.", _font, XBrushes.Black, 380, 230);
                        }
                        sb.End();

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("Second Item", _font, XBrushes.Black, 400, 230);

                            // Create a nested list.
                            sb.BeginElement(PdfBlockLevelElementTag.List);
                            {
                                // Create the first list item of the nested list.
                                sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                                {
                                    // Create the label of the nested list's first item.
                                    sb.BeginElement(PdfBlockLevelElementTag.Label);
                                    {
                                        gfx.DrawString("a)", _font, XBrushes.Black, 400, 250);
                                    }
                                    sb.End();

                                    // Add the list item's content into a ListBody structure element.
                                    sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                                    {
                                        gfx.DrawString("Item 2a)", _font, XBrushes.Black, 420, 250);

                                        // Create another nested list.
                                        sb.BeginElement(PdfBlockLevelElementTag.List);
                                        {
                                            // Create the first list item of the nested list.
                                            sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                                            {
                                                // Create the label of the nested list's first item.
                                                sb.BeginElement(PdfBlockLevelElementTag.Label);
                                                {
                                                    // Insert a Span for an abbreviation.
                                                    sb.BeginElement(PdfInlineLevelElementTag.Span);
                                                    {
                                                        // Draw the abbreviation.
                                                        gfx.DrawString("i", _font, XBrushes.Black, 420, 270);
                                                        // Set the expanded text for the abbreviation.
                                                        sb.SetExpandedText("roman one");
                                                    }
                                                    sb.End();
                                                }
                                                sb.End();

                                                // Add the list item's content into a ListBody structure element.
                                                sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                                                {
                                                    gfx.DrawString("Item 2a) ", _font, XBrushes.Black, 440, 270);
                                                    // Insert a Span for an abbreviation.
                                                    sb.BeginElement(PdfInlineLevelElementTag.Span);
                                                    {
                                                        // Draw the abbreviation.
                                                        gfx.DrawString("i", _font, XBrushes.Black, 479, 270);
                                                        // Set the expanded text for the abbreviation.
                                                        sb.SetExpandedText("roman one");
                                                    }
                                                    sb.End();
                                                }
                                                sb.End();
                                            }
                                            sb.End();

                                            // Create the second list item of the nested list.
                                            sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                                            {
                                                // Create the label of the nested list's second item.
                                                sb.BeginElement(PdfBlockLevelElementTag.Label);
                                                {
                                                    // Insert a Span for an abbreviation.
                                                    sb.BeginElement(PdfInlineLevelElementTag.Span);
                                                    {
                                                        // Draw the abbreviation.
                                                        gfx.DrawString("ii", _font, XBrushes.Black, 420, 290);
                                                        // Set the expanded text for the abbreviation.
                                                        sb.SetExpandedText("roman two");
                                                    }
                                                    sb.End();
                                                }
                                                sb.End();

                                                // Add the list item's content into a ListBody structure element.
                                                sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                                                {
                                                    gfx.DrawString("Item 2a) ", _font, XBrushes.Black, 440, 290);
                                                    // Insert a Span for an abbreviation.
                                                    sb.BeginElement(PdfInlineLevelElementTag.Span);
                                                    {
                                                        // Draw the abbreviation.
                                                        gfx.DrawString("ii", _font, XBrushes.Black, 479, 290);
                                                        // Set the expanded text for the abbreviation.
                                                        sb.SetExpandedText("roman two");
                                                    }
                                                    sb.End();
                                                }
                                                sb.End();
                                            }
                                            sb.End();

                                            // Create the third list item of the nested list.
                                            sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                                            {
                                                // Create the label of the nested list's third item.
                                                sb.BeginElement(PdfBlockLevelElementTag.Label);
                                                {
                                                    // Insert a Span for an abbreviation.
                                                    sb.BeginElement(PdfInlineLevelElementTag.Span);
                                                    {
                                                        // Draw the abbreviation.
                                                        gfx.DrawString("iii", _font, XBrushes.Black, 420, 310);
                                                        // Set the expanded text for the abbreviation.
                                                        sb.SetExpandedText("roman three");
                                                    }
                                                    sb.End();
                                                }
                                                sb.End();

                                                // Add the list item's content into a ListBody structure element.
                                                sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                                                {
                                                    // Insert a Span for an abbreviation.
                                                    sb.BeginElement(PdfInlineLevelElementTag.Span);
                                                    {
                                                        // Draw the abbreviation.
                                                        gfx.DrawString("etc.", _font, XBrushes.Black, 440, 310);
                                                        // Set the expanded text for the abbreviation.
                                                        sb.SetExpandedText("et cetera");
                                                    }
                                                    sb.End();
                                                }
                                                sb.End();
                                            }
                                            sb.End();
                                        }
                                        sb.End();
                                    }
                                    sb.End();
                                }
                                sb.End();
                            }
                            sb.End();
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();
        }

        void CreateListArt4()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create the fourth article's element.
            sb.BeginElement(PdfGroupingElementTag.Article);
            {
                // Insert the fourth article's heading.
                sb.BeginElement(PdfBlockLevelElementTag.Heading3);
                gfx.DrawString("A list with drawn labels", _fontH3, XBrushes.Black, 50, 330);
                sb.End();

                // Create a new list.
                sb.BeginElement(PdfBlockLevelElementTag.List);
                {
                    // Create the first list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        DrawBulletLabel(50, 350);

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("First Item", _font, XBrushes.Black, 70, 350);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the second list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        DrawBulletLabel(50, 370);

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("Second Item", _font, XBrushes.Black, 70, 370);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the third list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        DrawBulletLabel(50, 390);

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("Third Item", _font, XBrushes.Black, 70, 390);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the fourth list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        DrawBulletLabel(50, 410);

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("Fourth Item", _font, XBrushes.Black, 70, 410);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the fifth list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        DrawBulletLabel(50, 430);

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            gfx.DrawString("Fifth Item", _font, XBrushes.Black, 70, 430);
                        }
                        sb.End();
                    }
                    sb.End();

                    // Create the sixth list item.
                    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
                    {
                        DrawBulletLabel(50, 450);

                        // Add the list item's content into a ListBody structure element.
                        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
                        {
                            // Insert a Span for an abbreviation.
                            sb.BeginElement(PdfInlineLevelElementTag.Span);
                            {
                                // Draw the abbreviation.
                                gfx.DrawString("etc.", _font, XBrushes.Black, 70, 450);
                                // Set the expanded text for the abbreviation.
                                sb.SetExpandedText("et cetera");
                            }
                            sb.End();
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();
        }

        void DrawBulletLabel(int x, int y)
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create the label of the list item.
            sb.BeginElement(PdfBlockLevelElementTag.Label);
            {
                // Draw an ellipse as the list item's label.
                gfx.DrawEllipse(XBrushes.Black, x + 4, y - 5, 4, 4);

                // Set the alternative text for the label's structure element.
                sb.SetAltText("Bullet");
            }
            sb.End();
        }

        void CreatePartTableSamples()
        {
            // Break to fifth page.
            CreateContentPage();

            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create the Text Samples part element.
            sb.BeginElement(PdfGroupingElementTag.Part);
            {
                // Insert the Text Samples heading.
                sb.BeginElement(PdfBlockLevelElementTag.Heading2);
                gfx.DrawString("Table Samples", _fontH2, XBrushes.DarkBlue, 50, 100);
                sb.End();

                CreateTable1();

                CreateTable2();
            }
            sb.End();
        }

        void CreateTable1()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create a Heading 1 element.
            sb.BeginElement(PdfBlockLevelElementTag.Heading3);
            {
                gfx.DrawString("Simple table", _fontH3, XBrushes.Black, 50, 150);
            }
            sb.End();

            // Create a new table.
            sb.BeginElement(PdfBlockLevelElementTag.Table);
            {
                // Create a new row.
                sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                {
                    // Create a new header cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                    {
                        gfx.DrawString("Header 1", _fontTH, XBrushes.Black, 50, 200);
                    }
                    sb.End();

                    // Create a new header cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                    {
                        gfx.DrawString("Header 2", _fontTH, XBrushes.Black, 100, 200);
                    }
                    sb.End();
                }
                sb.End();

                // Create a new row.
                sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                {
                    // Create a new data cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                    {
                        gfx.DrawString("Data 1", _font, XBrushes.Black, 50, 220);
                    }
                    sb.End();

                    // Create a new data cell.
                    sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                    {
                        gfx.DrawString("Data 2", _font, XBrushes.Black, 100, 220);
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();
        }

        void CreateTable2()
        {
            // Get the manager for universal accessibility.
            var uaManager = UAManager.ForDocument(_document);

            // Get structure builder.
            var sb = uaManager.StructureBuilder;

            // Get current graphics.
            var gfx = uaManager.CurrentGraphics;

            // Create a Heading 1 element.
            sb.BeginElement(PdfBlockLevelElementTag.Heading3);
            {
                gfx.DrawString("Table with drawn borders", _fontH3, XBrushes.Black, 320, 150);
            }
            sb.End();

            // Create a new table.
            sb.BeginElement(PdfBlockLevelElementTag.Table);
            {
                // Create a TableHeadRowGroup element containing all the header rows.
                sb.BeginElement(PdfBlockLevelElementTag.TableHeadRowGroup);
                {
                    // Create a new row.
                    sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                    {
                        // Create a new header cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                        {
                            gfx.DrawString("Header A", _fontTH, XBrushes.Black, 320, 200);
                            // Draw the left and top border.
                            gfx.DrawLine(XPens.Black, new XPoint(315, 185), new XPoint(315, 205));
                            gfx.DrawLine(XPens.Black, new XPoint(315, 185), new XPoint(385, 185));
                        }
                        sb.End();

                        // Create a new header cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableHeaderCell);
                        {
                            gfx.DrawString("Header B", _fontTH, XBrushes.Black, 390, 200);
                            // Draw the left and top border.
                            gfx.DrawLine(XPens.Black, new XPoint(385, 185), new XPoint(385, 205));
                            gfx.DrawLine(XPens.Black, new XPoint(385, 185), new XPoint(455, 185));
                            // Draw the right border.
                            gfx.DrawLine(XPens.Black, new XPoint(455, 185), new XPoint(455, 205));
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();

                // Create a TableBodyRowGroup element containing all the data rows.
                sb.BeginElement(PdfBlockLevelElementTag.TableBodyRowGroup);
                {
                    // Create a new row.
                    sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                    {
                        // Create a new data cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                        {
                            gfx.DrawString("Data A", _font, XBrushes.Black, 320, 220);
                            // Draw the left and top border.
                            gfx.DrawLine(XPens.Black, new XPoint(315, 205), new XPoint(315, 225));
                            gfx.DrawLine(XPens.Black, new XPoint(315, 205), new XPoint(385, 205));
                        }
                        sb.End();

                        // Create a new data cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                        {
                            gfx.DrawString("Data B", _font, XBrushes.Black, 390, 220);
                            // Draw the left and top border.
                            gfx.DrawLine(XPens.Black, new XPoint(385, 205), new XPoint(385, 225));
                            gfx.DrawLine(XPens.Black, new XPoint(385, 205), new XPoint(455, 205));
                            // Draw the right border.
                            gfx.DrawLine(XPens.Black, new XPoint(455, 205), new XPoint(455, 225));
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();

                // Create a TableFooterRowGroup element containing all the footer rows.
                sb.BeginElement(PdfBlockLevelElementTag.TableFooterRowGroup);
                {
                    // Create a new row.
                    sb.BeginElement(PdfBlockLevelElementTag.TableRow);
                    {
                        // Create a new data cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                        {
                            gfx.DrawString("Footer A", _font, XBrushes.Black, 320, 240);
                            // Draw the left and top border.
                            gfx.DrawLine(XPens.Black, new XPoint(315, 225), new XPoint(315, 245));
                            gfx.DrawLine(XPens.Black, new XPoint(315, 225), new XPoint(385, 225));
                            // Draw the bottom border.
                            gfx.DrawLine(XPens.Black, new XPoint(315, 245), new XPoint(385, 245));
                        }
                        sb.End();

                        // Create a new data cell.
                        sb.BeginElement(PdfBlockLevelElementTag.TableDataCell);
                        {
                            gfx.DrawString("Footer B", _font, XBrushes.Black, 390, 240);
                            // Draw the left and top border.
                            gfx.DrawLine(XPens.Black, new XPoint(385, 225), new XPoint(385, 245));
                            gfx.DrawLine(XPens.Black, new XPoint(385, 225), new XPoint(455, 225));
                            // Draw the right and bottom border.
                            gfx.DrawLine(XPens.Black, new XPoint(455, 225), new XPoint(455, 245));
                            gfx.DrawLine(XPens.Black, new XPoint(385, 245), new XPoint(455, 245));
                        }
                        sb.End();
                    }
                    sb.End();
                }
                sb.End();
            }
            sb.End();
        }
    }
}
