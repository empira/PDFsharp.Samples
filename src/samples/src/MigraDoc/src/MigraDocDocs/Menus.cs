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
                //('1', "Samples"),
                ('2', "Document", Document.Menu),
                ('3', "Contents", Contents.Menu),
                ('4', "Formats", Formats.Menu)
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
                    //('4', "Document settings"),
                    //('5', "Rendering")
                ], OptionsTypeChapter, automaticGeneration).Enter();
            }

            static class DocumentStructure
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Document/DocumentStructure"),
                    [
                        ('1', "Simple document", auto => Helper.CreateSample(auto, DOM.Document_.DocumentStructure.SimpleDocument)),
                        ('2', "Headings and document outline", auto => Helper.CreateSample(auto, DOM.Document_.DocumentStructure.HeadingsAndDocumentOutline))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class PageControl
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Document/PageControl"),
                    [
                        ('1', "Sections", auto => Helper.CreateSample(auto, DOM.Document_.PageControl.Sections)),
                        ('2', "Page breaks", auto => Helper.CreateSample(auto, DOM.Document_.PageControl.PageBreaks)),
                        ('3', "Page flow properties", auto => Helper.CreateSample(auto, DOM.Document_.PageControl.PageFlowProperties))
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
                        ('1', "Direct formatting", auto => Helper.CreateSample(auto, DOM.Document_.Formatting.DirectFormatting)),
                        ('2', "Default style", auto => Helper.CreateSample(auto, DOM.Document_.Formatting.DefaultStyle)),
                        ('3', "Own style", auto => Helper.CreateSample(auto, DOM.Document_.Formatting.OwnStyle)),
                        ('4', "Modify base style", auto => Helper.CreateSample(auto, DOM.Document_.Formatting.ModifyBaseStyle)),
                        ('5', "Inheritance", auto => Helper.CreateSample(auto, DOM.Document_.Formatting.Inheritance))
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
                    //('2', "Hyperlinks),
                    //('3', "Footnotes),
                    //('4', "Fields),
                    //('5', "Headers & footers),
                    //('6', "Text frames),
                    //('7', "Lists),
                    ('8', "Tables", Tables.Menu),
                    //('9', "Images),
                    //('a', "Charts),
                    //('b', "PDFsharp content)
                ], OptionsTypeChapter, automaticGeneration).Enter();
            }

            static class Text
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Contents/Text"),
                    [
                        ('1', "Example", auto => Helper.CreateSample(auto, DOM.Contents.Text.Example)),
                        ('2', "Hyphenation", auto => Helper.CreateSample(auto, DOM.Contents.Text.Hyphenation)),
                        ('3', "Special characters", auto => Helper.CreateSample(auto, DOM.Contents.Text.SpecialCharacters))
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
                        ('1', "Inheritance", auto => Helper.CreateSample(auto, DOM.Contents.Tables.Inheritance))
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
                    //('1', "Page setup"),
                    ('2', "Font", Font.Menu),
                    ('3', "Paragraph", Paragraph.Menu),
                    ('4', "Tab stops", TabStops.Menu),
                    //('5', "Unit"),
                    //('6', "Colors"),
                    //('7', "Shading & FillFormat"),
                    //('8', "Borders & line formats"),
                    //('9', "Size & positioning"),
                ], OptionsTypeChapter, automaticGeneration).Enter();
            }

            static class Font
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Formats/Font"),
                    [
                        ('1', "Access font", auto => Helper.CreateSample(auto, DOM.Formats.Font.AccessFont)),
                        ('2', "Font name, size & color", auto => Helper.CreateSample(auto, DOM.Formats.Font.FontNameSizeAndColor)),
                        ('3', "Bold & italic", auto => Helper.CreateSample(auto, DOM.Formats.Font.BoldAndItalic)),
                        ('4', "Underline types", auto => Helper.CreateSample(auto, DOM.Formats.Font.UnderlineTypes)),
                        ('5', "Superscript & subscript", auto => Helper.CreateSample(auto, DOM.Formats.Font.SuperscriptAndSubscript))
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
                        ('1', "Access ParagraphFormat", auto => Helper.CreateSample(auto, DOM.Formats.Paragraph.AccessParagraphFormat)),
                        ('2', "Alignment", auto => Helper.CreateSample(auto, DOM.Formats.Paragraph.Alignment)),
                        ('3', "Space before & space after", auto => Helper.CreateSample(auto, DOM.Formats.Paragraph.SpaceBeforeAndAfter)),
                        ('4', "Indents", auto => Helper.CreateSample(auto, DOM.Formats.Paragraph.Indents)),
                        ('5', "Line spacing", auto => Helper.CreateSample(auto, DOM.Formats.Paragraph.LineSpacing))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }

            static class TabStops
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                internal static void Menu(AutomaticGeneration? automaticGeneration)
                {
                    new Menu(Helper.GetDisplayPath("Document object model/Formats/TabStops"),
                    [
                        ('1', "Position & alignment", auto => Helper.CreateSample(auto, DOM.Formats.TabStops.PositionAndAlignment)),
                        ('2', "Leader", auto => Helper.CreateSample(auto, DOM.Formats.TabStops.Leader)),
                        ('3', "Inheritance", auto => Helper.CreateSample(auto, DOM.Formats.TabStops.Inheritance))
                    ], OptionsTypeSample, automaticGeneration).Enter();
                }
            }
        }
    }
}