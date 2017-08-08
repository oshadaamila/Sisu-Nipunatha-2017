using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisu_Nipunatha
{
    public static class print_competition
    {
        public static void print(DataTable dt){
            Document document = new Document();
            Style style = document.Styles["Normal"];
            style.Font.Name = "BhashitaComplex";
            style.Font.Size = 12;
            Section section = document.AddSection();
            foreach (DataRow a in dt.Rows)
            {
                section.AddParagraph(a[0].ToString() + "\t" + a[1].ToString() + "\t" + Convert.ToDateTime(a[2].ToString()).ToString("yyyy-MM-dd") + "\t" + a[3].ToString()+"\t"+"");
            }
            

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always);
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            // Associate theMigraDoc document with a renderer
            pdfRenderer.Document = document;
            // Layout and render document to PDF
            
            pdfRenderer.RenderDocument();
            // Save the document...
            const string filename = "HelloWorld.pdf";
            pdfRenderer.PdfDocument.Save(filename);
              // ...and start a viewer.
            Process.Start(filename);
            


        }

    }
}
