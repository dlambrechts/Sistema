using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using iTextSharp.text.html;
using System.Windows.Forms;


namespace Servicios
{
    public class GenerarLayoutPresupuesto
    {
          
        public void GenerarPresupuestoPdf(PresupuestoBE Presup)
        {
            try
            {

                Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream("Presupuesto.pdf", FileMode.Create));
              

                var titleFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);
                var titleFontBlue = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
                var boldTableFont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD);
                var bodyFont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL);
                var EmailFont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLUE);
               
                BaseColor TabelHeaderBackGroundColor = WebColors.GetRGBColor("#EEEEEE");

                iTextSharp.text.Rectangle pageSize = writer.PageSize;
              
                pdfDoc.Open();
                

                #region Top table
                // Cabecera
                PdfPTable headertable = new PdfPTable(3);
                headertable.HorizontalAlignment = 0;
                headertable.WidthPercentage = 100;
                headertable.SetWidths(new float[] { 120f, 280f, 120f });   
                headertable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("C:\\OneDrive - EQA SAIC\\Escritorio\\logo.png");
                logo.ScaleToFit(100, 30);

                {
                    PdfPCell pdfCelllogo = new PdfPCell(logo);
                    pdfCelllogo.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    pdfCelllogo.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
                    pdfCelllogo.BorderWidthBottom = 1f;
                    headertable.AddCell(pdfCelllogo);
                }

                {
                    PdfPCell middlecell = new PdfPCell();
                    middlecell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    middlecell.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
                    middlecell.BorderWidthBottom = 1f;
                    headertable.AddCell(middlecell);
                }

                {
                    PdfPTable nested = new PdfPTable(1);
                    nested.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    PdfPCell nextPostCell1 = new PdfPCell(new Phrase("Gestión de Ventas", titleFont));
                    nextPostCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell1);
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase("VENDEDOR:", bodyFont));
                    nextPostCell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell2);
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase(Presup.Vendedor.ToString(), bodyFont)) ;
                    nextPostCell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell3);
                    PdfPCell nextPostCell4 = new PdfPCell(new Phrase(Presup.Vendedor.Mail, EmailFont));
                    nextPostCell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell4);
                    nested.AddCell("");
                    PdfPCell nesthousing = new PdfPCell(nested);
                    nesthousing.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nesthousing.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
                    nesthousing.BorderWidthBottom = 1f;
                    nesthousing.Rowspan = 5;
                    nesthousing.PaddingBottom = 10f;
                    headertable.AddCell(nesthousing);
                }


                PdfPTable Invoicetable = new PdfPTable(3);
                Invoicetable.HorizontalAlignment = 0;
                Invoicetable.WidthPercentage = 100;
                Invoicetable.SetWidths(new float[] { 120f, 280f, 120f });  
                Invoicetable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                {
                    PdfPTable nested = new PdfPTable(1);
                    nested.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    PdfPCell nextPostCell1 = new PdfPCell(new Phrase("PARA:", bodyFont));
                    nextPostCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell1);
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase(Presup.Cliente.RazonSocial, titleFont));
                    nextPostCell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell2);
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase(Presup.Cliente.Direccion, bodyFont));
                    nextPostCell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell3);
                    PdfPCell nextPostCell4 = new PdfPCell(new Phrase(Presup.Cliente.Mail, EmailFont));
                    nextPostCell4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell4);
                    nested.AddCell("");
                    PdfPCell nesthousing = new PdfPCell(nested);
                    nesthousing.Border = iTextSharp.text.Rectangle.NO_BORDER;
           
                    nesthousing.Rowspan = 5;
                    nesthousing.PaddingBottom = 10f;
                    Invoicetable.AddCell(nesthousing);
                }

                {
                    PdfPCell middlecell = new PdfPCell();
                    middlecell.Border = iTextSharp.text.Rectangle.NO_BORDER;
             
                    Invoicetable.AddCell(middlecell);
                }


                {
                    TimeSpan PlazoEntrega = Presup.FechaEntrega - Presup.FechaEmision;// 
                    PdfPTable nested = new PdfPTable(1);
                    nested.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    PdfPCell nextPostCell1 = new PdfPCell(new Phrase("Presupuesto N° " + Presup.Id, titleFontBlue));
                    nextPostCell1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell1);
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase("Fecha Emisión: " + Presup.FechaEmision.ToShortDateString(), bodyFont));
                    nextPostCell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell2);
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase("Plazo Entrega: " + Convert.ToInt32(PlazoEntrega.TotalDays) + " días", bodyFont));
                    nextPostCell3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell3);
                    nested.AddCell("");
                    PdfPCell nesthousing = new PdfPCell(nested);
                    nesthousing.Border = iTextSharp.text.Rectangle.NO_BORDER;
             
                    nesthousing.Rowspan = 5;
                    nesthousing.PaddingBottom = 10f;
                    Invoicetable.AddCell(nesthousing);
                }


                pdfDoc.Add(headertable);
                Invoicetable.PaddingTop = 10f;

                pdfDoc.Add(Invoicetable);
                #endregion

                #region Items Table
                //Cuerpo de la tabla
                PdfPTable itemTable = new PdfPTable(7);

                itemTable.HorizontalAlignment = 0;
                itemTable.WidthPercentage = 100;
                itemTable.SetWidths(new float[] { 5, 40, 10, 10, 10, 10, 15 });  // ancho relativo 
                itemTable.SpacingAfter = 40;
                itemTable.DefaultCell.Border = iTextSharp.text.Rectangle.BOX;
                PdfPCell cell1 = new PdfPCell(new Phrase("ITEM", boldTableFont));
                cell1.BackgroundColor = TabelHeaderBackGroundColor;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase("DESCRIPCION", boldTableFont));
                cell2.BackgroundColor = TabelHeaderBackGroundColor;
                cell2.HorizontalAlignment = 1;
                itemTable.AddCell(cell2);
                PdfPCell cell3 = new PdfPCell(new Phrase("CANTIDAD", boldTableFont));
                cell3.BackgroundColor = TabelHeaderBackGroundColor;
                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(cell3);
                PdfPCell cell4 = new PdfPCell(new Phrase("PRECIO UNITARIO", boldTableFont));
                cell4.BackgroundColor = TabelHeaderBackGroundColor;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase("% IVA", boldTableFont));
                cell5.BackgroundColor = TabelHeaderBackGroundColor;
                cell5.HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(cell5);
                PdfPCell cell6 = new PdfPCell(new Phrase("IVA ITEM", boldTableFont));
                cell6.BackgroundColor = TabelHeaderBackGroundColor;
                cell6.HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(cell6);
                PdfPCell cell7 = new PdfPCell(new Phrase("TOTAL ITEM", boldTableFont));
                cell7.BackgroundColor = TabelHeaderBackGroundColor;
                cell7.HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(cell7);

                int Item = 1;
                foreach (PresupuestoItemBE item in Presup.Items)
                {
                    PdfPCell numberCell = new PdfPCell(new Phrase(Item.ToString(), bodyFont)); // Num Item
                    numberCell.HorizontalAlignment = 1;
                    numberCell.PaddingLeft = 10f;
                    numberCell.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(numberCell);

                    var _phrase = new Phrase();
                    _phrase.Add(new Chunk("Codigo: " + item.Producto.Id + "\n", EmailFont));
                    _phrase.Add(new Chunk(item.Producto.Descripcion, bodyFont));
                    PdfPCell descCell = new PdfPCell(_phrase);
                    descCell.HorizontalAlignment = 0;
                    descCell.PaddingLeft = 10f;
                    descCell.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(descCell);

                    PdfPCell qtyCell = new PdfPCell(new Phrase(item.Cantidad.ToString(), bodyFont));
                    qtyCell.HorizontalAlignment = 1;
                    qtyCell.PaddingLeft = 10f;
                    qtyCell.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(qtyCell);

                    PdfPCell amountCell = new PdfPCell(new Phrase("$" + item.PrecioUnitario.ToString(), bodyFont));
                    amountCell.HorizontalAlignment = 1;
                    amountCell.PaddingLeft = 10f;
                    amountCell.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(amountCell);

                    PdfPCell porIvaCell = new PdfPCell(new Phrase(item.PorcIVA.ToString() + "%", bodyFont));
                    porIvaCell.HorizontalAlignment = 1;
                    porIvaCell.PaddingLeft = 10f;
                    porIvaCell.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(porIvaCell);

                    PdfPCell ivaItemCell = new PdfPCell(new Phrase("$" + item.IvaItem.ToString(), bodyFont));
                    ivaItemCell.HorizontalAlignment = 1;
                    ivaItemCell.PaddingLeft = 10f;
                    ivaItemCell.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(ivaItemCell);

                    PdfPCell totalamtCell = new PdfPCell(new Phrase("$" + item.TotalItem.ToString(), bodyFont));
                    totalamtCell.HorizontalAlignment = 1;
                    totalamtCell.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(totalamtCell);

                    Item++;
                }

                PdfPCell cella = new PdfPCell(new Phrase("Impuestos", boldTableFont));
                cella.Colspan = 6;
                cella.HorizontalAlignment = 2;
               
                itemTable.AddCell(cella);

                PdfPCell cellz = new PdfPCell(new Phrase("$ " + Presup.Iva.ToString(), boldTableFont));
                cellz.Colspan = 1;
                cellz.HorizontalAlignment = 2;
              
                itemTable.AddCell(cellz);

                PdfPCell cellb = new PdfPCell(new Phrase("Descuentos", boldTableFont));
                cellb.Colspan = 6;
                cellb.HorizontalAlignment = 2;
                // cellz.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                itemTable.AddCell(cellb);


                PdfPCell celly = new PdfPCell(new Phrase("$ " + Presup.Descuento.ToString() , boldTableFont));
                celly.Colspan = 1;
                celly.HorizontalAlignment = 2;
                // cellz.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                itemTable.AddCell(celly);

                PdfPCell cellc = new PdfPCell(new Phrase("Total Oferta", boldTableFont));
                cellc.Colspan = 6;
                cellc.HorizontalAlignment = 2;
                // cellz.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                itemTable.AddCell(cellc);


                PdfPCell cellx = new PdfPCell(new Phrase("$ "+Presup.Total.ToString(), boldTableFont));
                cellx.Colspan = 1;
                cellx.HorizontalAlignment = 2;
                // cellz.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                itemTable.AddCell(cellx);


                PdfPCell cell = new PdfPCell(new Phrase("***Oferta válida hasta el " + Presup.FechaValidez.ToShortDateString() + "***", bodyFont));
                cell.Colspan = 7;
                cell.HorizontalAlignment = 1;
                itemTable.AddCell(cell);
                pdfDoc.Add(itemTable);
                #endregion

                PdfContentByte cb = new PdfContentByte(writer);


                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                cb = new PdfContentByte(writer);
                cb = writer.DirectContent;
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(pageSize.GetLeft(120), 20);
                cb.ShowText("Observaciones: "+Presup.Observaciones);
                cb.EndText();


                cb.MoveTo(40, pdfDoc.PageSize.GetBottom(50));
                cb.LineTo(pdfDoc.PageSize.Width - 40, pdfDoc.PageSize.GetBottom(50));
                cb.Stroke();

                pdfDoc.Close();

                System.Diagnostics.Process.Start("C:\\OneDrive - EQA SAIC\\00_Trabajo de Campo\\Proyecto\\Sistema\\UI\\bin\\Debug\\Presupuesto.pdf");

            } // Fin TRY

            catch (Exception ex)
            {
                MessageBox.Show("Errror al crear Layout. "+ ex.Message);

            }
            
        }
    }
    

      
  


}

