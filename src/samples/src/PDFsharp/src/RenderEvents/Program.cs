// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Quality;

const string programName = "samples-PDFsharp/RenderEvents";

// http://localhost:8094/PDFsharp/Topics/Drawing/RenderEvents.html  #CHECK_BEFORE_RELEASE

#if CORE
// Core build does not use Windows fonts, so set a FontResolver that handles the fonts our samples need.
GlobalFontSettings.FontResolver = new SamplesFontResolver();
#endif

var document = PdfDocUtility.CreateNewPdfDocument(); // ("Render events")
var page = document.AddPage();  // PdfDocTools.AddPageAndGetGraphics(Render...
var gfx = XGraphics.FromPdfPage(page);

// Register a render event handler.
document.RenderEvents.RenderTextEvent += (sender, args) =>
    {
        for (int idx = 0; idx < args.CodePointGlyphIndexPairs.Length; idx++)
        {
            // Use a reference to item because CodePointWithGlyphIndex is a value type.
            ref var item = ref args.CodePointGlyphIndexPairs[idx];

            // Replace X with U.
            if (item.CodePoint == 'X')
            {
                item.CodePoint = 'U';
                args.ReevaluateGlyphIndices = true;
            }

            const char nonBreakHyphen = '\u2011';

            // Replace non-break hyphen with '-' if font does not contain a glyph for it.
            if (item.CodePoint == nonBreakHyphen)
            {
                if (item.GlyphIndex == 0)
                {
                    item.CodePoint = '-';
                    item.GlyphIndex = GlyphHelper.GlyphIndexFromCodePoint('-', args.Font);
                    item.GlyphIndex = GlyphHelper.GlyphIndexFromCodePoint('-', args.Font);
                    //item.GlyphID = args.Font.GlyphTypeface.GlyphIndexFromCodePoint('-');
                }
            }
        }
    };

const string someText = "ABC\u2011XYZ";
var font = new XFont("Arial", 20, XFontStyleEx.Regular);

// Measure the length of "ABC-UYZ".
var length = gfx.MeasureString(someText, font);

// Draw the text "ABC-UYZ".
gfx.DrawString(someText, font, XBrushes.Black, 100, 100);

PdfFileUtility.SaveAndShowDocument(document, programName);
