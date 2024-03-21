# Features Variant 1

Variant 1 shows the base API for creating PDF/UA documents with PDFsharp.
Everything can be done with the base API.

```C#
var sb = uaManager.StructureBuilder;  // Get structure builder.

// Paragraph sample.
sb.BeginElement(PdfGroupingElementTag.Article);
{
    var page = document.AddPage();
    var gfx = XGraphics.FromPdfPage(page);

    sb.BeginElement(PdfBlockLevelElementTag.Heading1);
    gfx.DrawString("Header Text", fontH1, XBrushes.DarkBlue, 50, 100);
    sb.End();

    sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
    gfx.DrawString("Line 1", font, XBrushes.DarkBlue, 50, 200);
    gfx.DrawString("Line 2", font, XBrushes.DarkBlue, 50, 250);
    sb.End();
}
sb.End();
```

## Samples

PDFsharp/UA is documented by samples.

### Hello World

This sample creates a minimal PDF/UA document.

To make a PDF document a PDF/UA document, the following code must be used.

```C#
var uaManager = UAManager.ForDocument(document);
```

The first call creates a **UAManager** and initializes the document.
It must be done before any other operation on the document (e.g. creating a page) is done.  
Any further calls always return the same **UAManager** object.

To define the document structure, retrieve the **StructureBuilder** from the **UAManager**.

```C#
// Get structure builder.
var sb = uaManager.StructureBuilder;
```

The structure tree is built by calling **Begin\*** functions to start a structure element and **End** to close it.

```C#
sb.BeginElement(PdfGroupingElementTag.Article);
{
    // Create a page and a graphics object as usual.
    var page = document.AddPage();
    var gfx = XGraphics.FromPdfPage(page);

    // Create Heading 1 element.
    sb.BeginElement(PdfBlockLevelElementTag.Heading1);
    gfx.DrawString("Header Text", fontH1, XBrushes.DarkBlue, 50, 100);
    sb.End();

    // Create paragraph element.
    sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
    // A trailing blank is needed here to make word break identification possible for screen readers.
    // If there are several DrawStrings in one BlockLevelElement, insert trailing blanks as if you would write the content as pure text.
    gfx.DrawString("Line 1 ", font, XBrushes.DarkBlue, 50, 200);
    gfx.DrawString("Line 2", font, XBrushes.DarkBlue, 50, 250);
    sb.End();
}
sb.End();
```

Note that all former code can be kept unchanged. Structure is simply mixed in.
You only should ensure that written text, that lies in different DrawString calls in one BlockLevelElement, contains all blanks that define word breaks.
This means that also the blank between the last word of a DrawString call and the first word of the next DrawString call should be written. For this reason the trailing **blank in "Line 1 "** is inserted.
Otherwise a screen reader would read "Line 1Line 2".

### Paragraphs Article

This sample creates a PDF/UA document containing only a heading and one article.
As it is similar to the Hello World sample, the Hello World documentation should be sufficient.

### Paragraphs Pagebreak

This sample creates a PDF/UA document containing one paragraph that spreads over three pages.
To achieve this, the pagebreaks are simply positioned at the desired
positions inside the paragraph element.

```C#
sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
{
    // Draw text on first page.
    gfx.DrawString("A paragraph that contains text content on its first page, ", font, XBrushes.DarkBlue, 50, 100);

    // Break to second page.
    page = document.AddPage();
    gfx = XGraphics.FromPdfPage(page);

    // Draw text on second page, but still same paragraph.
    gfx.DrawString("text content, ", font, XBrushes.DarkBlue, 50, 100);

    ...
}
sb.End();
```

### Images

This sample creates a PDF/UA document containing two images.

In PDF/UA you must define a bounding box and an alternate text for each graphic. This can be done simply with the **BeginElement** function.

The first image is inserted without changing its size. Nevertheless you need the image's size to define its bounding box. For this reason you should create the
image first and use its PointWidth and PointHeight to create the bounding box of the StructureElement.

```C#
// Insert an image with unchanged size.
// Create the figure and pass its alternate text and its bounding box as a parameter.
var image = XImage.FromFile("../../assets/Z3.jpg");
sb.BeginElement(PdfIllustrationElementTag.Figure, "A BMW Z3 driving through a sandstone desert.", new XRect(50, 300, image.PointWidth, image.PointHeight));
{
    // Add the image as usual.
    gfx.DrawImage(image, 50, 300);
}
sb.End();
```

The second sample is inserted with its size defined.

```C#
// Insert an image with a defined size.
// Create the figure and pass its alternate text and its bounding box as a parameter.
sb.BeginElement(PdfIllustrationElementTag.Figure, "A scaled BMW Z3 driving through a sandstone desert.", new XRect(50, 500, 400, 300));
{
    // Add the image as usual.
    gfx.DrawImage(XImage.FromFile("../../assets/Z3.jpg"), 50, 500, 400, 300);
}
sb.End();
```

You could also add multiple images.

### Lists Simple

This sample creates a PDF/UA document containing a small numbered list.

The **List** StructureElement may contain several **ListItem** StructureElements. Each ListItem contains a **Label** and a **ListBody** StructureElement.
The label contains the bullet, number or another kind of label and the ListBody the text of the list item.

According to this rules a list is created like this:

```C#
// Create a new list.
sb.BeginElement(PdfBlockLevelElementTag.List);
{
    // Create the first list item.
    sb.BeginElement(PdfBlockLevelElementTag.ListItem);
    {
        // Create the label of the first list item.
        sb.BeginElement(PdfBlockLevelElementTag.Label);
        {
            gfx.DrawString("1)", font, XBrushes.DarkBlue, 50, 80);
        }
        sb.End();

        // Add the list item's content into a ListBody structure element.
        sb.BeginElement(PdfBlockLevelElementTag.ListBody);
        {
            gfx.DrawString("Item 1", font, XBrushes.DarkBlue, 70, 80);
        }
        sb.End();
    }
    sb.End();

    // Create the second list item.
    ...
}
sb.End();
```

The second ListItem in this sample also contains a nested list.
This is done by creating another List StructureElement inside the ListItem's ListBody StructureElement.

```C#
// Create a LBody structure element for the second list item.
sb.BeginElement(PdfBlockLevelElementTag.ListBody);
{
    // Draw some text.
    gfx.DrawString("Item 2", font, XBrushes.DarkBlue, 70, 100);

    // Create a nested list.
    sb.BeginElement(PdfBlockLevelElementTag.List);
    {
        ...
    }
    sb.End();
}
sb.End();
```

### Lists Path

This sample creates a PDF/UA document with drawn bullets as its ListItem's labels.

To draw the bullet we can call any Draw-method like **DrawEllipse**.
To preserve the accessibility of the document we must provide an alternate text for the label by using the **SetAltText** method.

```C#
// Create the label of the first list item.
sb.BeginElement(PdfBlockLevelElementTag.Label);
{
    // Draw an ellipse as the list item's label.
    gfx.DrawEllipse(XBrushes.DarkBlue, 50, 75, 3, 3);

    // Set the alternative text for the label's structure element.
    sb.SetAltText("Bullet");
}
sb.End();
```

### Abbreviations

This sample shows the use of abbreviations in a PDF/UA document.

As the meaning of abbreviations may vary, it is recommended to define the expanded text for each abbreviation. This can be done with the **SetExpandedText** method.

In this sample the first part of the sentence is written as usual, followed by the abbreviation that is encapsulated in its own StructureElement.
The rest of the sentence is again written as usual.

```C#
sb.BeginElement(PdfBlockLevelElementTag.P);
{
    // Insert simple text.
    gfx.DrawString("A text with an ", font, XBrushes.DarkBlue, 50, 100);

    // Insert a Span for an abbreviation.
    sb.BeginElement(PdfInlineLevelElementTag.Span);
    {
        // Draw the abbreviation.
        gfx.DrawString("abbr.", font, XBrushes.DarkBlue, 50, 120);
        // Set the expanded text for the abbreviation. Note that we also need the trailing blank here, if there was one in pure text representation.
        sb.SetExpandedText("abbreviation ");
    }
    sb.End();

    // Insert further text.
    gfx.DrawString("in a structure element in the middle.", font, XBrushes.DarkBlue, 50, 140);
}
sb.End();
```

As explained before, each blank that would be written in a pure text representation must also be present in a PDF/UA document. For this reason there is a trailing blank
in the first DrawString call (**"A text with an "**) and in the SetExpandedText call (**"abbreviation "**). Otherwise a screen reader would read
"A text with anabbreviationin a structure element in the middle.".

### Artifacts

This sample shows the use of artifacts in a PDF/UA document.

Artifacts are text chars, drawn paths, or images that are not part of the contents of the document, meaning that they only exist for layout or design and not for understanding purposes.
Everything that is drawn or written inside an artifact will not be part of the StructureTree and will be ignored by screen readers.

```C#
// Insert an artifact.
sb.BeginArtifact();
{
    // This text is, as it is included in the artifact, not handled as actual content of the document. A screen reader will skip this text.
    gfx.DrawString("An artifact", font, XBrushes.Gray, 50, 150);
}
sb.End();
```

In this sample a screen reader will read "A paragraph that contains text and some artifacts." and it will ignore the text and graphics in between marked as artifacts.

### Links

This sample creates a PDF/UA document containing two links.

A link in PDF/UA must include the PdfLinkAnnotation and an alternate text.
You can create the Link StructureElement by using the BeginElement overload with exactly these parameters.

```C#
// Create a paragraph.
sb.BeginElement(PdfBlockLevelElementTag.Paragraph);
{
    // Create the links bounding rect.
    var rect = new PdfRectangle(gfx.Transformer.WorldToDefaultPage(new XRect(new XPoint(50, 90), new XPoint(205, 105))));

    // Create a LinkAnnotation referring to page 2.
    var link = PdfLinkAnnotation.CreateDocumentLink(rect, 2);

    // Create a new Link structure element with the LinkAnnotation and the alternative text passed as parameters.
    sb.BeginElement(link, "Link to page 2");
    {
        // Insert the text shown as link.
        gfx.DrawString("This is a link to the next page.", font, XBrushes.DarkBlue, 50, 100);
    }
    sb.End();
}
sb.End();
```

Analogous to this code the sample contains a second Link StructureElement using a web link.

### Language

This sample shows how to set the language of the document and how it can be changed for a span.

The document language is set with the **UAManager**.

```C#
uaManager.SetDocumentLanguage("en-US");
```

The language of the current structure element can be changed with the **SetLanguage** function.

```C#
sb.BeginElement(PdfInlineLevelElementTag.Span);
{
    // Change the language for the current structure element.
    sb.SetLanguage("de-DE");

    // Insert the text in the new language.
    gfx.DrawString("\"Herzlichen Glückwunsch!\" ", font, XBrushes.DarkBlue, 50, 200);
}
sb.End();
```

Narrator applications uses this information to correctly pronounce the text.

### Sample Document

This sample shows how to structure a whole document.

The document has the following structure:

* Title page
* Table of contents
* Chapter One: Text Samples
* Chapter Two: List Samples
* Chapter Three: Table Samples

It also shows the use of headers and footers.
