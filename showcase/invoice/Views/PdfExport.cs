#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using Syncfusion.Pdf.Grid;
using System.Windows;
using System.Data;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Diagnostics;

namespace syncfusion.invoice.wpf
{
    class PdfExport
    {
        public PdfExport()
        {
        }

        /// <summary>
        /// Creates PDF
        /// </summary>
        public  void CreatePDF(IList<InvoiceItem> dataSource, BillingInformation billInfo, double totalDue)
        {
             PdfDocument document = new PdfDocument();
            document.PageSettings.Orientation = PdfPageOrientation.Portrait;
            document.PageSettings.Margins.All = 50;
            PdfPage page = document.Pages.Add();
            PdfGraphics g = page.Graphics;
            PdfTextElement element = new PdfTextElement(@"Syncfusion Software 
2501 Aerial Center Parkway 
Suite 200 Morrisville, NC 27560 USA 
Tel +1 888.936.8638 Fax +1 919.573.0306");
            element.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            element.Brush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            PdfLayoutResult result = element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width / 2, 200));
            Assembly assembly = typeof(PdfExport).Assembly;
            Stream imgStream = assembly.GetManifestResourceStream("Invoice.Assets.SyncfusionLogo.jpg");
            PdfImage img = PdfImage.FromStream(imgStream);
            page.Graphics.DrawImage(img, new RectangleF(g.ClientSize.Width - 200, result.Bounds.Y, 190, 45));
            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            g.DrawRectangle(new PdfSolidBrush(new PdfColor(34, 83, 142)), new RectangleF(0, result.Bounds.Bottom + 40, g.ClientSize.Width, 30));
            element = new PdfTextElement("INVOICE " + billInfo.InvoiceNumber.ToString(), subHeadingFont);
            element.Brush = PdfBrushes.White;
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 48));
            string currentDate = "DATE " + billInfo.Date.ToString("d");
            SizeF textSize = subHeadingFont.MeasureString(currentDate);
            g.DrawString(currentDate, subHeadingFont, element.Brush, new PointF(g.ClientSize.Width - textSize.Width - 10, result.Bounds.Y));

            element = new PdfTextElement("BILL TO ", new PdfStandardFont(PdfFontFamily.TimesRoman, 12));
            element.Brush = new PdfSolidBrush(new PdfColor(34, 83, 142));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 25));

            g.DrawLine(new PdfPen(new PdfColor(34, 83, 142), 0.70f), new PointF(0, result.Bounds.Bottom + 3), new PointF(g.ClientSize.Width, result.Bounds.Bottom + 3));

            element = new PdfTextElement(billInfo.Name, new PdfStandardFont(PdfFontFamily.TimesRoman, 11));
            element.Brush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            result = element.Draw(page, new RectangleF(10, result.Bounds.Bottom + 5, g.ClientSize.Width / 2, 100));

            element = new PdfTextElement(billInfo.Address, new PdfStandardFont(PdfFontFamily.TimesRoman, 11));
            element.Brush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            result = element.Draw(page, new RectangleF(10, result.Bounds.Bottom + 3, g.ClientSize.Width / 2, 100));

            PdfGrid grid = new PdfGrid();
            grid.DataSource = ConvertToDataTable(dataSource);
            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.Borders.All = PdfPens.White;
            PdfGridRow header = grid.Headers[0];

            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Borders.All = new PdfPen(new PdfColor(34, 83, 142));
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(34, 83, 142));
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12f, PdfFontStyle.Regular);

            for (int i = 0; i < header.Cells.Count; i++)
            {
                if (i == 0)
                    header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                else
                    header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
            }
            header.Cells[0].Value = "ITEM";
            header.Cells[1].Value = "QUANTITY";
            header.Cells[2].Value = "RATE";
            header.Cells[3].Value = "TAXES";
            header.Cells[4].Value = "AMOUNT";
            header.ApplyStyle(headerStyle);
            grid.Columns[0].Width = 180;
            cellStyle.Borders.Bottom = new PdfPen(new PdfColor(34, 83, 142), 0.70f);
            cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 11f);
            cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(0, 0, 0));
            foreach (PdfGridRow row in grid.Rows)
            {
                row.ApplyStyle(cellStyle);
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    PdfGridCell cell = row.Cells[i];
                    if (i == 0)
                        cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                    else
                        cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

                    if (i > 1)
                    {
                        if (cell.Value.ToString().Contains("$"))
                        {
                            cell.Value = cell.Value.ToString();
                        }
                        else
                        {
                            if (cell.Value is double)
                                cell.Value = "$" + ((double)cell.Value).ToString("#,###.00", CultureInfo.InvariantCulture);
                            else
                                cell.Value = "$" + cell.Value.ToString();
                        }
                    }
                }
            }

            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            layoutFormat.Layout = PdfLayoutType.Paginate;

            PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new PointF(0, result.Bounds.Bottom + 40), new SizeF(g.ClientSize.Width, g.ClientSize.Height - 100)), layoutFormat);
            float pos = 0.0f;
            for (int i = 0; i < grid.Columns.Count - 1; i++)
                pos += grid.Columns[i].Width;

            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12f, PdfFontStyle.Bold);
            gridResult.Page.Graphics.DrawString("TOTAL DUE", font, new PdfSolidBrush(new PdfColor(34, 83, 142)), new RectangleF(new PointF(pos, gridResult.Bounds.Bottom + 10), new SizeF(grid.Columns[3].Width - pos, 20)), new PdfStringFormat(PdfTextAlignment.Right));
            gridResult.Page.Graphics.DrawString("Thank you for your business!", new PdfStandardFont(PdfFontFamily.TimesRoman, 12), new PdfSolidBrush(new PdfColor(0, 0, 0)), new PointF(pos - 210, gridResult.Bounds.Bottom + 60));
            pos += grid.Columns[4].Width;
            gridResult.Page.Graphics.DrawString("$" + totalDue.ToString("#,###.00", CultureInfo.InvariantCulture), font, new PdfSolidBrush(new PdfColor(0, 0, 0)), new RectangleF(pos, gridResult.Bounds.Bottom + 10, grid.Columns[4].Width - pos, 20), new PdfStringFormat(PdfTextAlignment.Right));

            document.Save("Invoice.pdf");
            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                 MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
#if !NETCORE
                System.Diagnostics.Process.Start("Invoice.pdf");
#else
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Arguments = "/c start Invoice.pdf"
                };
                Process.Start(psi);
#endif
                //this.Close();
            }
            //else
                // Exit
                //this.Close();
            
            document.Close(true);
           
        }
        /// <summary>
        /// Convert IEnummberable to DataTable Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
           TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                if (prop.PropertyType == typeof(double))
                    table.Columns.Add(prop.Name, typeof(string));
                else
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    object value = prop.GetValue(item) ?? DBNull.Value;
                    if (value is double)
                        row[prop.Name] = ((double)value).ToString("#,###.00", CultureInfo.InvariantCulture);
                    else
                        row[prop.Name] = value;
                }
                table.Rows.Add(row);
            }
            return table;
        }


    }
}
