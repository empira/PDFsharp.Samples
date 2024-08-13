using PdfSharp.Fonts;
using PdfSharp.Snippets.Font;
using PdfSharp;
using UAFeatures.Features;

namespace UAFeatures
{
    class Program
    {
        static void Main(string[] _)
        {
            Console.WriteLine("PDFsharp UA Feature Tester\n");

            if (Capabilities.Build.IsCoreBuild)
                GlobalFontSettings.FontResolver = new FailsafeFontResolver();
#if true
            Menu();
#else
            CreateAll();
#endif
        }

        static void Menu()
        {
            Console.WriteLine("    1. Hello World²");
            Console.WriteLine("    2. Paragraphs Article²");
            Console.WriteLine("    3. Paragraphs Pagebreak");
            Console.WriteLine("    4. Images²");
            Console.WriteLine("    5. Lists Simple²");
            Console.WriteLine("    6. Lists Path");
            Console.WriteLine("    7. Tables");
            Console.WriteLine("    8. Abbreviations²");
            Console.WriteLine("    9. Artifacts");
            Console.WriteLine("    0. Links²");
            Console.WriteLine("    A. Language");
            Console.WriteLine("    B. SampleDocument");

            Console.WriteLine();
            Console.WriteLine("    ² V2 Feature available. Hold Shift for V2 Feature.");

            Select:
            Console.Write("\n    Select: ");
#if true
            var key = Console.ReadKey();
#else
            var key = new ConsoleKeyInfo(' ', ConsoleKey.A, false, false, false);
#endif
            var shift = key.Modifiers == ConsoleModifiers.Shift;
            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    if (shift)
                        FeaturesV2.HelloWorld.Run();
                    else
                        HelloWorld.Run();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    if (shift)
                        FeaturesV2.ParagraphsArticle.Run();
                    else
                        ParagraphsArticle.Run();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ParagraphsPagebreak.Run();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    if (shift)
                        FeaturesV2.Images.Run();
                    else
                        Images.Run();
                    break;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    if (shift)
                        FeaturesV2.ListsSimple.Run();
                    else
                        ListsSimple.Run();
                    break;

                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    ListsPath.Run();
                    break;

                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    Tables.Run();
                    break;

                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    if (shift)
                        FeaturesV2.Abbreviations.Run();
                    else
                        Abbreviations.Run();
                    break;

                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    Artifacts.Run();
                    break;

                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    if (shift)
                        FeaturesV2.Links.Run();
                    else
                        Links.Run();
                    break;

                case ConsoleKey.A:
                    Language.Run();
                    break;

                case ConsoleKey.B:
                    SampleDocument.Run();
                    break;

                default:
                    Console.WriteLine();
                    goto Select;
            }
        }

        static void CreateAll()
        {
            FeaturesV2.HelloWorld.Run();
            HelloWorld.Run();

            FeaturesV2.ParagraphsArticle.Run();
            ParagraphsArticle.Run();

            ParagraphsPagebreak.Run();

            FeaturesV2.Images.Run();
            Images.Run();

            FeaturesV2.ListsSimple.Run();
            ListsSimple.Run();

            ListsPath.Run();

            Tables.Run();

            FeaturesV2.Abbreviations.Run();
            Abbreviations.Run();

            Artifacts.Run();

            FeaturesV2.Links.Run();
            Links.Run();

            Language.Run();

            SampleDocument.Run();
        }
    }
}
