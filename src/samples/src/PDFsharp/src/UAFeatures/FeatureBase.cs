using System.Diagnostics;
using PdfSharp.Pdf;
using PdfSharp.Quality;

namespace UAFeatures
{
    class FeatureBase
    {
        public void SaveAndShowDocument(PdfDocument document, string prefix)
        {
            PdfFileUtility.SaveAndShowDocument(document, "UAFeatures/" + prefix);
        }
    }
}
