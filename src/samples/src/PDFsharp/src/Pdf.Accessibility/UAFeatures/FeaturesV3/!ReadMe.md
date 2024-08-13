# Features Variant 3

Variant 3 shows the use of the using statement.

**This is experimental - maybe not very useful**

Instead of using **BeginElement** and **End** of a structure builder...

```C#
// Paragraph sample.
sb.BeginElement(PdfGroupingElementTag.Article);
{
    var page = document.AddPage();
    var gfx = XGraphics.FromPdfPage(page);

    sb.BeginElement(PdfBlockLevelElementTag.Heading1);
    gfx.DrawString("Header Text", fontH1, XBrushes.DarkBlue, 50, 100);
    sb.End();

    sb.BeginElement(PdfBlockLevelElementTag.P);
    gfx.DrawString("Line 1", font, XBrushes.DarkBlue, 50, 200);
    gfx.DrawString("Line 2", font, XBrushes.DarkBlue, 50, 250);
    sb.End();
}
sb.End();
```

...a construct with using statements is used.

```C#
// Paragraph sample.
using (abc.UseElement(PdfGroupingElementTag.Article))
{
    var page = document.AddPage();
    var gfx = XGraphics.FromPdfPage(page);

    using (abc.UseElement(PdfBlockLevelElementTag.Heading1))
    {
        gfx.DrawString("Header Text", fontH1, XBrushes.DarkBlue, 50, 100);
    }

    using (abc.UseElement(PdfBlockLevelElementTag.Heading1))
    {
        gfx.DrawString("Line 1", font, XBrushes.DarkBlue, 50, 200);
        gfx.DrawString("Line 2", font, XBrushes.DarkBlue, 50, 250);
    }
}
```

This just makes the code more readable.

## TODO List

* Really useful?
