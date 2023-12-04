//using System.Reflection.Metadata;
using iTextSharp.text;
using iTextSharp.text.pdf;
public class PDF
{
    public PDF() { }
    /// <summary>
    /// Crea un archivo PDF con el texto proporcionado.
    /// </summary>
    /// <param name="texto">Texto que se incluirá en el PDF.</param>
    public void CrearPDF(string texto)
    {
        Document document = new Document();
        PdfWriter.GetInstance(document, new FileStream(@"..\..\..\..\Informes\Informe.pdf", FileMode.Create));
        document.Open();
        document.Add(new Paragraph(texto));
        document.Close();
    }
}