#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Media;
using Syncfusion.ReportWriter;
using Syncfusion.Windows.Reports;

namespace LinearGauge
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string file = @"..\..\..\..\..\..\Common\Images\XlsIO\reportwriter_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
            string file2 = @"..\..\..\..\..\..\Common\Images\XlsIO\xlsio_button.png";
            this.image2.Source = (ImageSource)img.ConvertFromString(file2);
            this.Icon = this.image2.Source;
        }
        # endregion

        # region Events
        /// <summary>
        /// Creates spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string reportPath = @"..\..\..\..\..\..\Common\Data\ReportTemplate\LinearReport.rdl";

                string fileName = null;
                WriterFormat format;

                //Step 1 : Instantiate the report writer with the parameter "ReportPath".
                ReportWriter reportWriter = new ReportWriter(reportPath);
                //Step 2 : Save the report as Pdf or Word or Excel
                if (pdf.IsChecked == true)
                {
                    fileName = "LinearGauge.pdf";
                    format = WriterFormat.PDF;
                }
                else if (word.IsChecked == true)
                {
                    fileName = "LinearGauge.doc";
                    format = WriterFormat.Word;
                }
                else if (excel.IsChecked == true)
                {
                    fileName = "LinearGauge.xls";
                    format = WriterFormat.Excel;
                }
                else
                {
                    fileName = "LinearGauge.html";
                    format = WriterFormat.HTML;
                }
                reportWriter.Save(fileName, format);
                //Message box confirmation to view the created report document.
                if (MessageBox.Show("Do you want to view the " + format + " file?", "" + format + " report Created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the PDF file using the default Application.[Acrobat Reader]
                    System.Diagnostics.Process.Start(fileName);
                }
            }
            catch (System.Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        # endregion
    }
}
