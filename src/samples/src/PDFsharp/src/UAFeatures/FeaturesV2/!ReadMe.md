# Features Variant 2

Variant 2 shows the use of additionally available extension methods.
The extension methods allow to write less code, but have no additional features than the base API from the Variant 1 samples.

Instead of using **BeginElement** and **End** for a single draw string function call...

```C#
sb.BeginElement(PdfBlockLevelElementTag.Heading1);
gfx.DrawString("Header Text", fontH1, XBrushes.DarkBlue, 50, 100);
sb.End();
```

...an extension method can be used instead.

```C#
gfx.DrawString("Header Text", fontH1, XBrushes.DarkBlue, 50, 100, PdfBlockLevelElementTag.Heading1);
```

This just makes the code more readable.

## List of feature extension methods

In addition to the listed methods, there are overloads taking XStringFormat as an additional parameter or XPoint or XRect parameters instead of the double x, y, width and height values.

### DrawString

* gfx.DrawString(string text, XFont font, XBrush brush, double x, double y, PdfBlockLevelElementTag tag)
* gfx.DrawString(string text, XFont font, XBrush brush, double x, double y, PdfInlineLevelElementTag tag)

### DrawAbbreviation

Used to create a span with an abbreviation and its expanded text in one line of code.

* gfx.DrawAbbreviation(string abbreviation, string expandedText, XFont font, XBrush brush, double x, double y)

### DrawImage

Used to create the Image StructureElement and the image itself in one line of code.

* gfx.DrawImage(XImage image, double x, double y, string altText, XRect boundingBox)
* gfx.DrawImage(XImage image, double x, double y, double width, double height, string altText, XRect boundingBox)
* gfx.DrawImage(XImage image, double x, double y, string altText)
* gfx.DrawImage(XImage image, double x, double y, double width, double height, string altText)

If there is no bounding box given, it will be determined from the not transformed image position and size.

### DrawLink

Used to create the Link StructureElement and the drawn text in one line of code.

* gfx.DrawLink(string s, XFont font, XBrush brush, double x, double y, PdfLinkAnnotation linkAnnotation, string altText)

### DrawListItem

Used to create a ListItem StructureElement and its children (the Label StructureElement and its textual content and the ListBody StructureElement and its textual content) in one line of code.

* gfx.DrawListItem(string label, string text, XFont font, XBrush brush, double x, double y, double labelWidth)
