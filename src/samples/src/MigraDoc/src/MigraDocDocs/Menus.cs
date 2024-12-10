// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

namespace MigraDocDocs
{
    static class Menus
    {
        const string OptionsTypeChapter = "chapter";
        const string OptionsTypeSample = "sample";

        public static void Menu(AutomaticGeneration? automaticGeneration)
        {
            new Menu(Helper.GetDisplayPath("Document object model"),
            [
                ('1', "Document", Document.Menu),
                ('2', "Contents", Contents.Menu),
                ('3', "Formats", Formats.Menu)
            ], OptionsTypeChapter, automaticGeneration, false).Enter();
        }

        static class Document
        {
            // ReSharper disable once MemberHidesStaticFromOuterClass
            internal static void Menu(AutomaticGeneration? automaticGeneration)
            {
                new Menu(Helper.GetDisplayPath("Document object model/Document"),
                [
                    ('1', "Document structure", DocumentStructure.Menu),
                    ('2', "Formatting", Formatting.Menu),
                    ('3', "Page control", PageControl.Menu),
                    ('4', "Document settings", DocumentSettings.Menu),
                    ('5', "MigraDoc settings", MigraDocSettings.Menu),
                    ('6', "Rendering", Rendering.Menu)
                ], OptionsTypeChapter, automaticGeneration).Enter();
            }

            static class DocumentStructure
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Document/Document structure"),
                    [
                        ('1', "Simple document", auto => Helper.CreateSample(auto, DOM.Document_.DocumentStructure.SimpleDocument.Sample)),
                        ('2', "Cloning objects", auto => Helper.CreateSample(auto, DOM.Document_.DocumentStructure.CloningObjects.Sample)),
                        ('3', "Headings and document outline", auto => Helper.CreateSample(auto, DOM.Document_.DocumentStructure.HeadingsAndDocumentOutline.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class Formatting
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Document/Formatting"),
                    [
                        ('1', "Direct formatting", auto => Helper.CreateSample(auto, DOM.Document_.Formatting.DirectFormatting.Sample)),
                        ('2', "Default style", auto => Helper.CreateSample(auto, DOM.Document_.Formatting.DefaultStyle.Sample)),
                        ('3', "Own style", auto => Helper.CreateSample(auto, DOM.Document_.Formatting.OwnStyle.Sample)),
                        ('4', "Modify base style", auto => Helper.CreateSample(auto, DOM.Document_.Formatting.ModifyBaseStyle.Sample)),
                        ('5', "Inheritance", auto => Helper.CreateSample(auto, DOM.Document_.Formatting.Inheritance.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class PageControl
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Document/Page control"),
                    [
                        ('1', "Sections", auto => Helper.CreateSample(auto, DOM.Document_.PageControl.Sections.Sample)),
                        ('2', "Page breaks", auto => Helper.CreateSample(auto, DOM.Document_.PageControl.PageBreaks.Sample)),
                        ('3', "Page flow properties", auto => Helper.CreateSample(auto, DOM.Document_.PageControl.PageFlowProperties.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class DocumentSettings
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Document/Document settings"),
                    [
                        ('1', "DocumentInfo", auto => Helper.CreateSample(auto, DOM.Document_.DocumentSettings.DocumentInfo.Sample)),
                        ('2', "Culture", auto => Helper.CreateSample(auto, DOM.Document_.DocumentSettings.Culture.Sample)),
                        ('3', "Color mode", auto => Helper.CreateSample(auto, DOM.Document_.DocumentSettings.ColorMode.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class MigraDocSettings
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Document/MigraDoc settings"),
                    [
                        ('1', "Predefined fonts", auto => Helper.CreateSample(auto, DOM.Document_.MigraDocSettings.PredefinedFonts.Sample)),
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class Rendering
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Document/Rendering"),
                    [
                        ('1', "Rendering a PDF file", auto => Helper.CreateSample(auto, DOM.Document_.Rendering.RenderingPdfFile.Sample)),
                        ('2', "Changing PDF settings", auto => Helper.CreateSample(auto, DOM.Document_.Rendering.ChangingPdfSettings.Sample)),
                        ('3', "Rendering an RTF file", auto => Helper.CreateSample(auto, DOM.Document_.Rendering.RenderingRtfFile.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }
        }

        static class Contents
        {
            // ReSharper disable once MemberHidesStaticFromOuterClass
            internal static void Menu(AutomaticGeneration? automaticGeneration)
            {
                new Menu(Helper.GetDisplayPath("Document object model/Contents"),
                [
                    ('1', "Text", Text.Menu),
                    ('2', "Hyperlinks", Hyperlinks.Menu),
                    ('3', "Footnotes", Footnotes.Menu),
                    ('4', "Fields", Fields.Menu),
                    ('5', "Headers & footers", HeadersAndFooters.Menu),
                    ('6', "Text frames", TextFrames.Menu),
                    ('7', "Lists", Lists.Menu),
                    ('8', "Tables", Tables.Menu),
                    ('9', "Images", Images.Menu),
                    ('a', "Charts", Charts.Menu)
                    //('b', "PDFsharp content", PdfSharpContent.Menu) - Currently no sample available.
                ], OptionsTypeChapter, automaticGeneration).Enter();
            }

            static class Text
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Contents/Text"),
                    [
                        ('1', "Example", auto => Helper.CreateSample(auto, DOM.Contents.Text.Example.Sample)),
                        ('2', "Hyphenation", auto => Helper.CreateSample(auto, DOM.Contents.Text.Hyphenation.Sample)),
                        ('3', "Special characters", auto => Helper.CreateSample(auto, DOM.Contents.Text.SpecialCharacters.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class Hyperlinks
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Contents/Hyperlinks"),
                    [
                        ('1', "To bookmarks", auto => Helper.CreateSample(auto, DOM.Contents.Hyperlinks.ToBookmarks.Sample)),
                        ('2', "To files", auto => Helper.CreateSample(auto, DOM.Contents.Hyperlinks.ToFiles.Sample)),
                        ('3', "To web URLs", auto => Helper.CreateSample(auto, DOM.Contents.Hyperlinks.ToWebUrls.Sample)),
                        ('4', "To mail URLs", auto => Helper.CreateSample(auto, DOM.Contents.Hyperlinks.ToMailUrls.Sample)),
                        ('5', "New window", auto => Helper.CreateSample(auto, DOM.Contents.Hyperlinks.NewWindow.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class Footnotes
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Contents/Footnotes"),
                    [
                        ('1', "Example", auto => Helper.CreateSample(auto, DOM.Contents.Footnotes.Example.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class Fields
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Contents/Fields"),
                    [
                        ('1', "Example", auto => Helper.CreateSample(auto, DOM.Contents.Fields.Example.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class HeadersAndFooters
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Contents/Headers & footers"),
                    [
                        ('1', "Setting up", auto => Helper.CreateSample(auto, DOM.Contents.HeadersAndFooters.SettingUp.Sample)),
                        ('2', "First & even pages", auto => Helper.CreateSample(auto, DOM.Contents.HeadersAndFooters.FirstAndEvenPages.Sample)),
                        ('3', "Size & position", auto => Helper.CreateSample(auto, DOM.Contents.HeadersAndFooters.SizeAndPosition.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class TextFrames
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Contents/Text frames"),
                    [
                        ('1', "Wrapping content", auto => Helper.CreateSample(auto, DOM.Contents.TextFrames.WrappingContent.Sample)),
                        ('2', "Margins", auto => Helper.CreateSample(auto, DOM.Contents.TextFrames.Margins.Sample)),
                        ('3', "Orientation", auto => Helper.CreateSample(auto, DOM.Contents.TextFrames.Orientation.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class Lists
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Contents/Lists"),
                    [
                        ('1', "Bulleted lists", auto => Helper.CreateSample(auto, DOM.Contents.Lists.BulletedLists.Sample)),
                        ('2', "Numbered lists", auto => Helper.CreateSample(auto, DOM.Contents.Lists.NumberedLists.Sample)),
                        ('3', "Mixed lists", auto => Helper.CreateSample(auto, DOM.Contents.Lists.MixedLists.Sample)),
                        ('4', "Indents", auto => Helper.CreateSample(auto, DOM.Contents.Lists.Indents.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class Tables
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Contents/Tables"),
                    [
                        ('1', "A simple table", auto => Helper.CreateSample(auto, DOM.Contents.Tables.SimpleTable.Sample)),
                        ('2', "Row height", auto => Helper.CreateSample(auto, DOM.Contents.Tables.RowHeight.Sample)),
                        ('3', "Table header", auto => Helper.CreateSample(auto, DOM.Contents.Tables.TableHeader.Sample)),
                        ('4', "Table positioning", auto => Helper.CreateSample(auto, DOM.Contents.Tables.TablePositioning.Sample)),
                        ('5', "Text positioning", auto => Helper.CreateSample(auto, DOM.Contents.Tables.TextPositioning.Sample)),
                        ('6', "Merging cells", auto => Helper.CreateSample(auto, DOM.Contents.Tables.MergingCells.Sample)),
                        ('7', "Avoiding page breaks", auto => Helper.CreateSample(auto, DOM.Contents.Tables.AvoidingPageBreaks.Sample)),
                        ('8', "Rounded corners", auto => Helper.CreateSample(auto, DOM.Contents.Tables.RoundedCorners.Sample)),
                        ('9', "Inheritance", auto => Helper.CreateSample(auto, DOM.Contents.Tables.Inheritance.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class Images
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Contents/Images"),
                    [
                        ('1', "From file", auto => Helper.CreateSample(auto, DOM.Contents.Images.FromFile.Sample)),
                        ('2', "Working directory & image path", auto => Helper.CreateSample(auto, DOM.Contents.Images.WorkingDirectoryAndImagePath.Sample)),
                        ('3', "From byte array", auto => Helper.CreateSample(auto, DOM.Contents.Images.FromByteArray.Sample)),
                        ('4', "Resizing", auto => Helper.CreateSample(auto, DOM.Contents.Images.Resizing.Sample)),
                        ('5', "Inline images", auto => Helper.CreateSample(auto, DOM.Contents.Images.InlineImages.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class Charts
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Contents/Charts"),
                    [
                        ('1', "Example", auto => Helper.CreateSample(auto, DOM.Contents.Charts.Example.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }
        }

        static class Formats
        {
            // ReSharper disable once MemberHidesStaticFromOuterClass
            internal static void Menu(AutomaticGeneration? automaticGeneration)
            {
                new Menu(Helper.GetDisplayPath("Document object model/Formats"),
                [
                    ('1', "Page setup", PageSetup.Menu),
                    ('2', "Font", Font.Menu),
                    ('3', "Paragraph", Paragraph.Menu),
                    ('4', "Tab stops", TabStops.Menu),
                    ('5', "Unit", Unit.Menu),
                    ('6', "Colors", Colors.Menu),
                    ('7', "Shading & fill format", ShadingAndFillFormat.Menu),
                    ('8', "Borders & line format", BordersAndLineFormat.Menu),
                    ('9', "Sizing & positioning", SizingAndPositioning.Menu)
                ], OptionsTypeChapter, automaticGeneration).Enter();
            }

            static class PageSetup
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Formats/Page setup"),
                    [
                        ('1', "Example", auto => Helper.CreateSample(auto, DOM.Formats.PageSetup.Example.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class Font
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Formats/Font"),
                    [
                        ('1', "Access font", auto => Helper.CreateSample(auto, DOM.Formats.Font.AccessFont.Sample)),
                        ('2', "Font name, size & color", auto => Helper.CreateSample(auto, DOM.Formats.Font.FontNameSizeAndColor.Sample)),
                        ('3', "Bold & italic", auto => Helper.CreateSample(auto, DOM.Formats.Font.BoldAndItalic.Sample)),
                        ('4', "Underline types", auto => Helper.CreateSample(auto, DOM.Formats.Font.UnderlineTypes.Sample)),
                        ('5', "Superscript & subscript", auto => Helper.CreateSample(auto, DOM.Formats.Font.SuperscriptAndSubscript.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class Paragraph
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Formats/Paragraph"),
                    [
                        ('1', "Access ParagraphFormat", auto => Helper.CreateSample(auto, DOM.Formats.Paragraph.AccessParagraphFormat.Sample)),
                        ('2', "Alignment", auto => Helper.CreateSample(auto, DOM.Formats.Paragraph.Alignment.Sample)),
                        ('3', "Space before & space after", auto => Helper.CreateSample(auto, DOM.Formats.Paragraph.SpaceBeforeAndAfter.Sample)),
                        ('4', "Indents", auto => Helper.CreateSample(auto, DOM.Formats.Paragraph.Indents.Sample)),
                        ('5', "Line spacing", auto => Helper.CreateSample(auto, DOM.Formats.Paragraph.LineSpacing.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class TabStops
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Formats/Tab stops"),
                    [
                        ('1', "Position & alignment", auto => Helper.CreateSample(auto, DOM.Formats.TabStops.PositionAndAlignment.Sample)),
                        ('2', "Leader", auto => Helper.CreateSample(auto, DOM.Formats.TabStops.Leader.Sample)),
                        ('3', "Inheritance", auto => Helper.CreateSample(auto, DOM.Formats.TabStops.Inheritance.Sample)),
                        ('4', "Using DefaultTabStop", auto => Helper.CreateSample(auto, DOM.Formats.TabStops.UsingDefaultTabStop.Sample)),
                        ('5', "Setting DefaultTabStop", auto => Helper.CreateSample(auto, DOM.Formats.TabStops.SettingDefaultTabStop.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class Unit
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Formats/Unit"),
                    [
                        ('1', "Creating a Unit value", auto => Helper.CreateSample(auto, DOM.Formats.Unit_.CreatingUnitValue.Sample)),
                        ('2', "Getting other measure values", auto => Helper.CreateSample(auto, DOM.Formats.Unit_.GettingOtherMeasureValues.Sample)),
                        ('3', "Changing UnitType", auto => Helper.CreateSample(auto, DOM.Formats.Unit_.ChangingUnitType.Sample)),
                        ('4', "Comparing", auto => Helper.CreateSample(auto, DOM.Formats.Unit_.Comparing.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class Colors
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Formats/Colors"),
                    [
                        ('1', "Use predefined color", auto => Helper.CreateSample(auto, DOM.Formats.Colors_.UsingPredefinedColors.Sample)),
                        ('2', "From RGB or CMYK value", auto => Helper.CreateSample(auto, DOM.Formats.Colors_.FromRgbOrCmyk.Sample)),
                        ('3', "Working with opacity", auto => Helper.CreateSample(auto, DOM.Formats.Colors_.WorkingWithOpacity.Sample)),
                        ('4', "From hexadecimal value", auto => Helper.CreateSample(auto, DOM.Formats.Colors_.FromHexValue.Sample)),
                        ('5', "Color channels", auto => Helper.CreateSample(auto, DOM.Formats.Colors_.ColorChannels.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class ShadingAndFillFormat
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Formats/Shading & fill format"),
                    [
                        ('1', "Simple example", auto => Helper.CreateSample(auto, DOM.Formats.ShadingAndFillFormat.SimpleExample.Sample)),
                        ('2', "Visibility", auto => Helper.CreateSample(auto, DOM.Formats.ShadingAndFillFormat.Visibility.Sample)),
                        ('3', "Nesting", auto => Helper.CreateSample(auto, DOM.Formats.ShadingAndFillFormat.Nesting.Sample)),
                        ('4', "SetShading method", auto => Helper.CreateSample(auto, DOM.Formats.ShadingAndFillFormat.SetShadingMethod.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class BordersAndLineFormat
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Formats/Borders & line format"),
                    [
                        ('1', "Width & color", auto => Helper.CreateSample(auto, DOM.Formats.BordersAndLineFormat.WidthAndColor.Sample)),
                        ('2', "Styles", auto => Helper.CreateSample(auto, DOM.Formats.BordersAndLineFormat.Styles.Sample)),
                        ('3', "Visibility", auto => Helper.CreateSample(auto, DOM.Formats.BordersAndLineFormat.Visibility.Sample)),
                        ('4', "Nesting", auto => Helper.CreateSample(auto, DOM.Formats.BordersAndLineFormat.Nesting.Sample)),
                        ('5', "Border distance", auto => Helper.CreateSample(auto, DOM.Formats.BordersAndLineFormat.BorderDistance.Sample)),
                        ('6', "Single borders", auto => Helper.CreateSample(auto, DOM.Formats.BordersAndLineFormat.SingleBorders.Sample)),
                        ('7', "SetEdge method", auto => Helper.CreateSample(auto, DOM.Formats.BordersAndLineFormat.SetEdgeMethod.Sample)),
                        ('8', "Colliding borders", auto => Helper.CreateSample(auto, DOM.Formats.BordersAndLineFormat.CollidingBorders.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class SizingAndPositioning
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Formats/Sizing & positioning"),
                    [
                        ('1', "Sizing", auto => Helper.CreateSample(auto, DOM.Formats.SizingAndPositioning.Sizing.Sample)),
                        ('2', "Horizontal positioning", auto => Helper.CreateSample(auto, DOM.Formats.SizingAndPositioning.HorizontalPositioning.Sample)),
                        ('3', "Vertical positioning", auto => Helper.CreateSample(auto, DOM.Formats.SizingAndPositioning.VerticalPositioning.Sample)),
                        ('4', "WrapFormat", auto => Helper.CreateSample(auto, DOM.Formats.SizingAndPositioning.WrapFormat.Sample))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }
        }
    }
}