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
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using System.IO;
using System.Windows.Resources;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AdventureCycle : DemoControl
    {
        # region Private Members    

        string styleName;
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public AdventureCycle()
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
        #endregion
        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            styleName = this.comboBox1.SelectedItem.ToString();
            //Create a new instance of PdfDocument class.
            PdfDocument document = new PdfDocument();

            //Set font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 7);

            // Add a new page to the document.
            PdfPage page = document.Pages.Add();

            //Creating PdfGrid
            PdfGrid grid = new PdfGrid();

            //Create dataset with the "Customers" table from Northwind database.
            DataSet dataSet = GetAdventureWorkCycleDataSet();

            DataTable dt = dataSet.Tables[0];
            string[] unwantedColumns = { "Freight", "EmployeeID", "OrderDate", "RequiredDate", "ShippedDate", "ShipVia", "ShipRegion" };
            foreach (string columnIndex in unwantedColumns)
            {
                dt.Columns.Remove(columnIndex);
            }

            grid.DataSource = dt;
            grid.Style.Font = font;
           
            grid.Style.AllowHorizontalOverflow = true;

            #region PdfGridBuiltinStyleSettings
            PdfGridBuiltinStyleSettings setting = new PdfGridBuiltinStyleSettings();
            setting.ApplyStyleForHeaderRow = this.checkBox1.IsChecked.Value;
            setting.ApplyStyleForBandedRows = this.checkBox2.IsChecked.Value;
            setting.ApplyStyleForFirstColumn = this.checkBox3.IsChecked.Value;
            setting.ApplyStyleForLastRow = this.checkBox4.IsChecked.Value;
            setting.ApplyStyleForBandedColumns = this.checkBox5.IsChecked.Value;       
            setting.ApplyStyleForLastColumn = this.checkBox6.IsChecked.Value;         
            #endregion

            PdfGridLayoutFormat format = new PdfGridLayoutFormat();
            format.Break = PdfLayoutBreakType.FitPage;
            format.Layout = PdfLayoutType.Paginate;          

            PdfGridBuiltinStyle style = ConvertToPdfGridBuiltinStyle(styleName);

            //Apply Style to PdfGrid
            grid.ApplyBuiltinStyle(style, setting);

            grid.Draw(page, PointF.Empty, format);

            //Save to disk
            document.Save("AdventureCycle.pdf");
            document.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("AdventureCycle.pdf") { UseShellExecute = true };
                process.Start();
            }
        }
        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfdemos.wpf;component/Assets/PDF/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }

        # endregion

        # region Helpher Methods
        /// <summary>
        /// Convert string to PdfGridBuiltinStyle
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private PdfGridBuiltinStyle ConvertToPdfGridBuiltinStyle(string styleName)
        {
            PdfGridBuiltinStyle value = (PdfGridBuiltinStyle)Enum.Parse(typeof(PdfGridBuiltinStyle), styleName);
            return value;
        }
        # region Dataset

        /// <summary>
        /// Returns dataset.
        /// </summary>
        private DataSet GetAdventureWorkCycleDataSet()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"Assets\PDF\Orders.xml");           
            return dataSet;
        }
      
        # endregion

        # region Header
        /// <summary>
        /// Adds header to the PDF document
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        private void AddHeader(PdfDocument doc, string title, string description)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 54);
            PdfPageTemplateElement header = new PdfPageTemplateElement(rect);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 24);
            float doubleHeight = font.Height * 2;
            System.Drawing.Color activeColor = System.Drawing.Color.FromArgb(44, 71, 120);
            SizeF imageSize = new SizeF(110f, 35f);
            //Locating the logo on the right corner of the Drawing Surface
            PointF imageLocation = new PointF(doc.Pages[0].GetClientSize().Width - imageSize.Width - 20, 8);

            PdfImage img = new PdfBitmap(GetFileStream("logo.jpg"));           
            //Draw the image in the Header.
            header.Graphics.DrawImage(img, imageLocation, imageSize);

            PdfSolidBrush brush = new PdfSolidBrush(activeColor);

            PdfPen pen = new PdfPen(System.Drawing.Color.DarkBlue, 3f);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold);
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;
            header.Graphics.DrawString(title, font, brush, new RectangleF(0, 0, header.Width, header.Height), format);
            brush = new PdfSolidBrush(System.Drawing.Color.Gray);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);

            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            header.Graphics.DrawString(description, font, brush, new RectangleF(0, 0, header.Width, header.Height - 8), format);

            header.Graphics.DrawLine(pen, 0, 0, header.Width, 0);
            pen = new PdfPen(System.Drawing.Color.DarkBlue, 2f);
            header.Graphics.DrawLine(pen, 0, header.Height - 4, header.Width, header.Height - 4);

            doc.Template.Top = header;
        }
        # endregion      

        private void DemoControl_Loaded(object sender, RoutedEventArgs e)
        {
            Array styleArray=Enum.GetValues(typeof(PdfGridBuiltinStyle));
            foreach (PdfGridBuiltinStyle style in styleArray)
            {
                this.comboBox1.Items.Add(style);
            }
        }
        # endregion
    }
}
