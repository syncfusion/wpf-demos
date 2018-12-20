#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using Syncfusion.Pdf.Tables;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Data.SqlServerCe;
using Syncfusion.Windows.Shared;

namespace NorthwindReport
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        private const string DEF_DB_COMMAND2 = "SELECT CustomerID,CompanyName,ContactName,Address,City,PostalCode,Country,Phone,Fax FROM Customers";
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string file = @"..\..\..\..\..\..\..\Common\images\PDF\pdf_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
			this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\images\PDF\pdf_button.png");
            this.Height = 200;
            Array styleArray = Enum.GetValues(typeof(PdfLightTableBuiltinStyle));
            
            foreach (PdfLightTableBuiltinStyle style in styleArray)
            {
                this.styleName.Items.Add(style);
            }
            this.styleName.SelectedIndex = 26;
           // this.styleName
        }
        # endregion

        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Create PDF document
            PdfDocument doc = new PdfDocument();

            //Set font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 8);

            //Create Pdf ben for drawing broder
            PdfPen borderPen = new PdfPen(PdfBrushes.DarkBlue);
            borderPen.Width = 0;

            //Create brush
            PdfColor color = new PdfColor(192, 201, 219);
            PdfSolidBrush brush = new PdfSolidBrush(color);

            //Create cell styles
            PdfCellStyle altStyle = new PdfCellStyle();
            altStyle.Font = font;
            altStyle.BackgroundBrush = brush;
            altStyle.BorderPen = borderPen;

            PdfCellStyle defStyle = new PdfCellStyle();
            defStyle.Font = font;
            defStyle.BackgroundBrush = PdfBrushes.White;
            defStyle.BorderPen = borderPen;

            PdfCellStyle headerStyle = new PdfCellStyle(font, PdfBrushes.White, PdfPens.DarkBlue);
            brush = new PdfSolidBrush(System.Drawing.Color.FromArgb(33, 67, 126));
            headerStyle.BackgroundBrush = brush;

            //Create DataTable for source
            PdfPage page = doc.Pages.Add();

            //Adding Header
            this.AddHeader(doc, "Northwind Customers", "");

            //Use DataTable as source
            PdfLightTable table = new PdfLightTable();

            //Create dataset with the "Customers" table from Norwind database
            DataSet dataSet = GetNorthwindDataSet(DEF_DB_COMMAND2);


            //Create datatable
            DataTable dataTable = dataSet.Tables[0];

            //Set Data source
            table.DataSource = dataTable;

            //Set table alternate row style
            table.Style.AlternateStyle = altStyle;

            //Set default style
            table.Style.DefaultStyle = defStyle;

            //Set header row style         
            table.Style.HeaderStyle = headerStyle;

            //Show the header row
            table.Style.ShowHeader = true;

            //Repeate header in all the pages
            table.Style.RepeatHeader = true;

            //Set header data from column caption
            table.Style.HeaderSource = PdfHeaderSource.ColumnCaptions;

            table.Style.BorderPen = borderPen;
            table.Style.CellPadding = 2;
            table.Columns[1].Width = 65;
            table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            table.Style.DefaultStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);

            //Set layout properties
            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Break = PdfLayoutBreakType.FitElement;
            format.Layout = PdfLayoutType.Paginate;

            if (this.builtinStyle.IsChecked.Value)
            {                
                string styleName = this.styleName.SelectedItem.ToString();
                PdfLightTableBuiltinStyle style = ConvertPdfLightTableBultinStyle(styleName);

                PdfLightTableBuiltinStyleSettings setting = new PdfLightTableBuiltinStyleSettings();
                setting.ApplyStyleForBandedColumns = this.bandedColumn.IsChecked.Value;
                setting.ApplyStyleForBandedRows = this.bandedRow.IsChecked.Value;
                setting.ApplyStyleForFirstColumn = this.firstColumn.IsChecked.Value;
                setting.ApplyStyleForHeaderRow = this.headerRow.IsChecked.Value;
                setting.ApplyStyleForLastColumn = this.lastColumn.IsChecked.Value;
                setting.ApplyStyleForLastRow = this.lastRow.IsChecked.Value;
                table.ApplyBuiltinStyle(style, setting);
            }


            //Draw table
            table.Draw(page, new PointF(0, 10), format);

            //Save to disk
            doc.Save("Sample.pdf");

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process.Start("Sample.pdf");
                this.Close();
            }
            else
                // Exit
                this.Close();
        }

        # endregion

        # region Helpher Methods

        private PdfLightTableBuiltinStyle ConvertPdfLightTableBultinStyle(string styleName)
        {
            PdfLightTableBuiltinStyle value = (PdfLightTableBuiltinStyle)Enum.Parse(typeof(PdfLightTableBuiltinStyle), styleName);
            return value;
        }

        # region Dataset
        /// <summary>
        /// Generates dataset
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="selectCommand"></param>
        /// <returns></returns>
        private DataSet GetNorthwindDataSet(string selectCommand)
        {

            DataSet dataSet = new DataSet();
            try
            {
                AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
                SqlCeConnection connection = new SqlCeConnection();
                if (connection.ServerVersion.StartsWith("3.5"))
                    connection.ConnectionString = "Data Source = " + (@"..\..\..\..\..\..\..\Common\Data\NorthwindIO_3.5.sdf");
                else
                    connection.ConnectionString = "Data Source = " + (@"..\..\..\..\..\..\..\Common\Data\NorthwindIO.sdf");
                connection.Open();
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(DEF_DB_COMMAND2, connection);
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {

            }

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

            PdfImage img = new PdfBitmap(@"..\..\..\..\..\..\..\Common\Images\PDF\logo.jpg");

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

        private void builtinStyle_Checked(object sender, RoutedEventArgs e)
        {
            if (this.builtinStyle.IsChecked.Value)
            {
                this.grpRegion.Visibility = Visibility.Visible;
                this.Height = 330;
            }
            else 
            {
                this.grpRegion.Visibility = Visibility.Hidden;
                this.Height = 200;
            }
        }

        private void ChromelessWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Array styleArray = Enum.GetValues(typeof(PdfLightTableBuiltinStyle));
            foreach (PdfLightTableBuiltinStyle style in styleArray)
            {
                this.styleName.Items.Add(style);
            }
        }
        # endregion
    }
}