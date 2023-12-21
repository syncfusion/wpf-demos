#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Pdf;
using System.Drawing;
using System.Data;
using Syncfusion.Pdf.Tables;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using System.Windows.Resources;
using System.IO;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TableFeatures : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public TableFeatures()
        {
            InitializeComponent();

        }
        #endregion
        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        # endregion
        # region Fields
        PdfPen borderPen;
        PdfPen transparentPen;
        float cellSpacing = 7f;
        float margin = 40f;
        PdfFont smallFont;
        # endregion
        # region Events
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            # region Field Definitions
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 8f);
            smallFont = new PdfStandardFont(font, 5f);
            PdfFont bigFont = new PdfStandardFont(font, 16f);
            PdfBrush orangeBrush = new PdfSolidBrush(new PdfColor(247, 148, 29));
            PdfBrush grayBrush = new PdfSolidBrush(new PdfColor(170, 171, 171));

            borderPen = new PdfPen(new PdfColor(System.Drawing.Color.FromArgb(System.Drawing.Color.DarkGray.A, System.Drawing.Color.DarkGray.R, System.Drawing.Color.DarkGray.G, System.Drawing.Color.DarkGray.B)), .3f);
            borderPen.LineCap = PdfLineCap.Square;
            transparentPen = new PdfPen(new PdfColor(System.Drawing.Color.FromArgb(System.Drawing.Color.Transparent.A, System.Drawing.Color.Transparent.R, System.Drawing.Color.Transparent.G, System.Drawing.Color.Transparent.B)), .3f);
            transparentPen.LineCap = PdfLineCap.Square;
            # endregion

            PdfDocument document = new PdfDocument();
            document.PageSettings.Margins.All = 0;

            # region Footer
            PdfPageTemplateElement footer = new PdfPageTemplateElement(new RectangleF(new PointF(0, document.PageSettings.Height - 40), new SizeF(document.PageSettings.Width, 40)));
            footer.Graphics.DrawRectangle(new PdfSolidBrush(new PdfColor(77, 77, 77)), footer.Bounds);
            footer.Graphics.DrawString("http://www.syncfusion.com", font, grayBrush, new PointF(footer.Width - (footer.Width / 4), 15));
            footer.Graphics.DrawString("Copyright © 2001 - 2015 Syncfusion Inc.", font, grayBrush, new PointF(0, 15));
            document.Template.Bottom = footer;
            # endregion

            PdfPage page = document.Pages.Add();

            page.Graphics.DrawRectangle(orangeBrush, new RectangleF(PointF.Empty, new SizeF(page.Graphics.ClientSize.Width, margin)));
            page.Graphics.DrawString("Essential Studio Reporting Edition", bigFont, PdfBrushes.White, new PointF(10, 10));

            # region PdfLightTable
            PdfLightTable pdfLightTable = new PdfLightTable();
            pdfLightTable.DataSource = GetProductsDataSet();
            pdfLightTable.Style.DefaultStyle.BorderPen = transparentPen;

            for (int i = 0; i < pdfLightTable.Columns.Count; i++)
            {
                if (i % 2 == 0)
                    pdfLightTable.Columns[i].Width = 16.5f;
            }

            pdfLightTable.Style.CellSpacing = cellSpacing;
            pdfLightTable.BeginRowLayout += new BeginRowLayoutEventHandler(pdfLightTable_BeginRowLayout);
            pdfLightTable.BeginCellLayout += new BeginCellLayoutEventHandler(pdfLightTable_BeginCellLayout);
            pdfLightTable.Style.DefaultStyle.Font = font;
            PdfLayoutResult result = pdfLightTable.Draw(page, new RectangleF(new PointF(margin, 70), new SizeF(page.Graphics.ClientSize.Width - (2 * margin), page.Graphics.ClientSize.Height - margin)));

            # endregion

            page.Graphics.DrawString("What You Get with Syncfusion", bigFont, orangeBrush, new PointF(margin, result.Bounds.Bottom + 50));

            # region PdfGrid
            PdfGrid pdfGrid = new PdfGrid();
            pdfGrid.DataSource = GetReportsDataSet();
            pdfGrid.Headers.Clear();
            pdfGrid.Columns[0].Width = 80;
            pdfGrid.Style.Font = font;
            pdfGrid.Style.CellSpacing = 15f;

            for (int i = 0; i < pdfGrid.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    PdfGridCell cell = pdfGrid.Rows[i].Cells[0];
                    cell.RowSpan = 2;

                    cell.Style.BackgroundImage = new PdfBitmap(GetFileStream(string.Format("{0}.jpg", cell.Value.ToString().ToLower())));
                    cell.Value = "";

                    cell = pdfGrid.Rows[i].Cells[1];
                    cell.Style.Font = bigFont;
                }
                for (int j = 0; j < pdfGrid.Columns.Count; j++)
                {
                    pdfGrid.Rows[i].Cells[j].Style.Borders.All = transparentPen;
                }
            }

            PdfGridLayoutFormat gridLayoutFormat = new PdfGridLayoutFormat();
            gridLayoutFormat.Layout = PdfLayoutType.Paginate;

            pdfGrid.Draw(page, new RectangleF(new PointF(margin, result.Bounds.Bottom + 75), new SizeF(page.Graphics.ClientSize.Width - (2 * margin), page.Graphics.ClientSize.Height - margin)), gridLayoutFormat);

            # endregion
            // Save and close the document.
            document.Save("TableFeatures.pdf");
            document.Close(true);
            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("TableFeatures.pdf") { UseShellExecute = true };
                process.Start();
            }

        }

        /// <summary>
        /// Returns dataset.
        /// </summary>
        private DataSet GetProductsDataSet()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"Assets\PDF\Products.xml");
            return dataSet;
        }
        /// <summary>
        /// Returns dataset.
        /// </summary>
        private DataSet GetReportsDataSet()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"Assets\PDF\Report.xml");
            return dataSet;
        }
        /// <summary>
        /// Draws ellipse inside the cell using cell bounds.
        /// </summary>
        void table_StartCellLayout(object sender, BeginCellLayoutEventArgs args)
        {
            int rowIndex = args.RowIndex;
            int cellIndex = args.CellIndex;

            if (rowIndex < 30 && rowIndex >= 0 && (rowIndex & 1) == 0)
            {
                PdfGraphics g = args.Graphics;
                g.DrawEllipse(PdfBrushes.LightBlue, args.Bounds);
            }
        }
        # region PdfLightTable Events

        void pdfLightTable_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
        {
            if (args.RowIndex % 2 == 0)
                args.MinimalHeight = 20;
            else
                args.MinimalHeight = 30;
        }

        void pdfLightTable_BeginCellLayout(object sender, BeginCellLayoutEventArgs args)
        {
            if (args.RowIndex > -1 && args.CellIndex > -1)
            {
                float x = args.Bounds.X;
                float y = args.Bounds.Y;
                float width = args.Bounds.Right;
                float height = args.Bounds.Bottom;

                if (args.Value == "dummy")
                {
                    args.Skip = true;
                    return;
                }

                if (args.CellIndex % 2 == 0 && !string.IsNullOrEmpty(args.Value))
                {
                    args.Skip = true;
                    PdfBitmap img = new PdfBitmap(GetFileStream(string.Format("{0}.jpg", args.Value.ToString().ToLower())));
                    RectangleF rect = args.Bounds;
                    args.Graphics.DrawImage(img, new RectangleF(rect.X + 2, rect.Y + 2, rect.Width - 2, rect.Height - 2));
                }

                if (args.Value.Contains("http"))
                {
                    args.Skip = true;

                    // Create the Text Web Link
                    PdfTextWebLink textLink = new PdfTextWebLink();
                    textLink.Url = args.Value;
                    textLink.Text = "Know more...";
                    textLink.Brush = PdfBrushes.Black;
                    textLink.Font = smallFont;
                    textLink.DrawTextWebLink(args.Graphics, new PointF(args.Bounds.X + 2 * args.Bounds.Width / 3, args.Bounds.Y));
                }

                # region Draw manual borders
                if (args.RowIndex % 3 == 0)//top
                {
                    if (args.CellIndex % 2 == 0)
                        width += cellSpacing;
                    args.Graphics.DrawLine(borderPen, new PointF(x, y), new PointF(width, y));
                }
                else if (args.RowIndex % 3 == 2)//bottom
                {
                    if (args.CellIndex % 2 == 0)
                        width += cellSpacing;
                    args.Graphics.DrawLine(borderPen, new PointF(x, height), new PointF(width, height));
                }

                if (args.CellIndex % 2 == 0)//left
                {
                    if (args.RowIndex % 3 != 2)
                        height += cellSpacing;
                    args.Graphics.DrawLine(borderPen, new PointF(x, y), new PointF(x, height));
                }
                else if (args.CellIndex % 2 != 0)//right
                {
                    if (args.RowIndex % 3 != 2)
                        height += cellSpacing;
                    args.Graphics.DrawLine(borderPen, new PointF(width, y), new PointF(width, height));
                }
                # endregion
            }
        }

        # endregion

        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfdemos.wpf;component/Assets/PDF/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }
        # endregion

    }
}
