// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

/*
  The PDF 2.0 documentation comes with a nasty license info on every page.
  The following text was added with iText® and shows this information:

    Licensed to empira Software GmbH / Stefan Lange (Stefan.Lange@xxxxxx.xxx)
             ISO Store Order: OP-xxxxxx / Downloaded: 2022-xx-xx
         Single user licence only, copying and networking prohibited.

  This pythonized C# program removes this information not because it is a license,
  but because it looks so ugly in the printed documentation.

  ===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===
  THIS CODE IS SAMPLE CODE ONLY TO DEMONSTRATE HOW TO CHANGE EXISTING PDF FILES.
  DO NOT USE IT TO INFRINGE COPYRIGHT.
  ===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===​===
*/

using PdfSharp.Pdf.IO;

// You need a copy of the ISO 32000 PDF to run this program.
const string folder = @"C:\Users\StLa\Desktop\PDFsharp\";
const string file = "ISO_32000-2_2020(en).pdf";
const string fileNew = "ISO_32000-2_2020(en)-no-license-info.pdf";

// Open file for editing.
var document = PdfReader.Open(Path.Combine(folder, file), PdfDocumentOpenMode.Modify);

// Remove additional content streams on every page.
foreach (var page in document.Pages)
{
    var contents = page.Contents;
    switch (contents.Elements.Count)
    {
        case 1:
            // Empty page has only license info.
            contents.Elements.Clear();
            break;

        case 3:
            // Normal page has two additional content streams to be deleted.
            // One before and one after the actual content.
            contents.Elements.RemoveAt(0);
            contents.Elements.RemoveAt(1);
            break;
    }
}

// Save PDF with new name.
document.Save(Path.Combine(folder, fileNew));
