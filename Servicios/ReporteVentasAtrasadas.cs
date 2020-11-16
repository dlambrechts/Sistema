using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using iTextSharp.text.html;
using System.Windows.Forms;
using BE;


namespace Servicios
{
    public class ReporteVentasAtrasadas
    {
        public void GenerarPresupuestoPdf(List<PresupuestoBE> Atrasados)
        {
            try
            {

                Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream("VentasAtrasadas.pdf", FileMode.Create));
              
                pdfDoc.Open();

                var bodyFont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL);
                var titleFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);
                var titleFontBlue = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
                var boldTableFont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD);               
                var EmailFont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);

                // Cabecera del reporte

                PdfPTable cabecera = new PdfPTable(3);
                cabecera.HorizontalAlignment = 0;
                cabecera.WidthPercentage = 100;
                cabecera.SetWidths(new float[] { 120f, 280f, 120f });
                cabecera.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;


                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("C:\\OneDrive - EQA SAIC\\Escritorio\\logo.png");
                logo.ScaleToFit(100, 30);

                {
                    PdfPCell pdfCelllogo = new PdfPCell(logo);
                    pdfCelllogo.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    pdfCelllogo.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
                    pdfCelllogo.BorderWidthBottom = 1f;
                    cabecera.AddCell(pdfCelllogo);
                }

                {
                    PdfPCell middlecell = new PdfPCell();
                    middlecell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    middlecell.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
                    middlecell.BorderWidthBottom = 1f;
                    cabecera.AddCell(middlecell);
                }

                {
                    PdfPTable nested = new PdfPTable(1);
                    nested.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    PdfPCell nextPostCell1 = new PdfPCell(new Phrase("Gestión de Ventas", titleFont));
                    nextPostCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell1);
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase("Ventas Pedidas", bodyFont));
                    nextPostCell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell2);
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase(DateTime.Now.ToShortDateString(), bodyFont));
                    nextPostCell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell3);
                    nested.AddCell("");
                    PdfPCell nesthousing = new PdfPCell(nested);
                    nesthousing.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nesthousing.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
                    nesthousing.BorderWidthBottom = 1f;
                    nesthousing.Rowspan = 5;
                    nesthousing.PaddingBottom = 10f;
                    cabecera.AddCell(nesthousing);
                }

                // Tabla del reporte

                
                pdfDoc.Add(cabecera);

                PdfPTable table = new PdfPTable(7);
                table.SpacingBefore = 10f;

                PdfPCell Tit1 = new PdfPCell(new Phrase("Presupuesto", bodyFont));
                table.AddCell(Tit1);
                PdfPCell Tit2 = new PdfPCell(new Phrase("Emisión", bodyFont));
                table.AddCell(Tit2);
                PdfPCell TitMonto = new PdfPCell(new Phrase("Monto", bodyFont));
                table.AddCell(TitMonto);
                PdfPCell Tit3 = new PdfPCell(new Phrase("Validez de la Oferta", bodyFont));
                table.AddCell(Tit3);
                PdfPCell Tit4 = new PdfPCell(new Phrase("Cliente", bodyFont));
                table.AddCell(Tit4);
                PdfPCell Tit5 = new PdfPCell(new Phrase("Vendedor", bodyFont));
                table.AddCell(Tit5);
                PdfPCell Tit6 = new PdfPCell(new Phrase("Estado", bodyFont));
                table.AddCell(Tit6);

                

                foreach (PresupuestoBE item in Atrasados)
                {

                 PdfPCell Celda1 = new PdfPCell(new Phrase(Convert.ToString(item.Id), bodyFont));
                 table.AddCell(Celda1);

                 PdfPCell Celda2 = new PdfPCell(new Phrase(Convert.ToString(item.FechaEmision.ToShortDateString()), bodyFont));
                 table.AddCell(Celda2);

                 PdfPCell CeldaMonto = new PdfPCell(new Phrase("$ "+Convert.ToString(item.Total), bodyFont));
                 table.AddCell(CeldaMonto);
    
                PdfPCell Celda3 = new PdfPCell(new Phrase(Convert.ToString(item.FechaValidez.ToShortDateString()), bodyFont));
                table.AddCell(Celda3);

                PdfPCell Celda4 = new PdfPCell(new Phrase(item.Cliente.ToString(), bodyFont));
                table.AddCell(Celda4);

                PdfPCell Celda5 = new PdfPCell(new Phrase(item.Vendedor.ToString(), bodyFont));
                table.AddCell(Celda5);

                PdfPCell Celda6 = new PdfPCell(new Phrase(item.Estado.Descripción, bodyFont));
                table.AddCell(Celda6);



                }

                pdfDoc.Add(table);

                // Totales


                PdfPTable TablaTotales = new PdfPTable(1);
                TablaTotales.SpacingBefore = 10f;



                decimal TotalPerdidas = 0;

                foreach (PresupuestoBE item in Atrasados) {TotalPerdidas = TotalPerdidas + item.Total; }

                PdfPCell Titulo = new PdfPCell(new Phrase("Total Ventas Perdidas: $"+ Convert.ToString(TotalPerdidas), bodyFont));
                TablaTotales.AddCell(Titulo);

                pdfDoc.Add(TablaTotales);


                // Fin tablas

                pdfDoc.Close();
                System.Diagnostics.Process.Start("C:\\OneDrive - EQA SAIC\\00_Trabajo de Campo\\Proyecto\\Sistema\\UI\\bin\\Debug\\VentasAtrasadas.pdf");

            } // Fin TRY

            catch (Exception ex)
            {
                MessageBox.Show("Errror al crear Layout. " + ex.Message);

            }

        }

    }
}
