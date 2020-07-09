#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Diagnostics;
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
using Syncfusion.XlsIO;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace OleObject_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
#if NETCORE
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#else
            string file = @"..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#endif
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            if (this.rdButtonxlsx.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2007;
            }
            else if (this.rdButtonexcel2010.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2010;
            }
            else if (this.rdButtonexcel2013.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2013;
            }

            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet sheet = workbook.Worksheets[0];

            sheet.IsGridLinesVisible = false;
#if NETCORE
            sheet.Pictures.AddPicture(2, 5, @"..\..\..\..\..\..\..\Common\Images\XlsIO\header.gif");
#else
            sheet.Pictures.AddPicture(2, 5, @"..\..\..\..\..\..\Common\Images\XlsIO\header.gif");
#endif

            sheet["E5:M6"].Merge();
            sheet[5, 5].Text = "Syncfusion accept fax orders from customers worldwide. You can also order online through our secure web server.";
            sheet[5, 5].WrapText = true;

            sheet[8, 6].Text = "PDF Order Form";

#if NETCORE
            IOleObject oleObject1 = sheet.OleObjects.Add(@"..\..\..\..\..\..\..\Common\Data\XlsIO\FaxOrderForm.pdf", System.Drawing.Image.FromFile(@"..\..\..\..\..\..\..\Common\Images\XlsIO\pdfIcon.jpg"), OleLinkType.Embed);
#else
            IOleObject oleObject1 = sheet.OleObjects.Add(@"..\..\..\..\..\..\Common\Data\XlsIO\FaxOrderForm.pdf", System.Drawing.Image.FromFile(@"..\..\..\..\..\..\Common\Images\XlsIO\pdfIcon.jpg"), OleLinkType.Embed);
#endif
            oleObject1.Location = sheet[8, 11];
            oleObject1.Size = new System.Drawing.Size(100, 100);

            sheet[17, 6].Text = "Word Order Form";

#if NETCORE
            IOleObject oleObject2 = sheet.OleObjects.Add(@"..\..\..\..\..\..\..\Common\Data\XlsIO\FaxOrderForm.doc", System.Drawing.Image.FromFile(@"..\..\..\..\..\..\..\Common\Images\XlsIO\wordIcon.jpg"), OleLinkType.Embed);
#else
            IOleObject oleObject2 = sheet.OleObjects.Add(@"..\..\..\..\..\..\Common\Data\XlsIO\FaxOrderForm.doc", System.Drawing.Image.FromFile(@"..\..\..\..\..\..\Common\Images\XlsIO\wordIcon.jpg"), OleLinkType.Embed);
#endif
            oleObject2.Location = sheet[17, 11];
            oleObject2.Size = new System.Drawing.Size(100, 100);

            sheet[25, 5].Text = "Download the order form, print it out and fill in the required information.";

            try
            {
                workbook.SaveAs("OleObject.xlsx");
                workbook.Close();
                excelEngine.Dispose();

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
#if NETCORE
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("OleObject.xlsx")
                        {
                            UseShellExecute = true
                        };
                        process.Start();
#else
                        Process.Start("OleObject.xlsx");
#endif
                        //Exit
                        this.Close();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("Excel 2007 is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                    // Exit
                    this.Close();
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
    }
}
