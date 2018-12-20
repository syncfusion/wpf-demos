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
using Syncfusion.XlsIO;
using Syncfusion.Windows.Shared;

namespace GroupShapes
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
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            // The instantiation process consists of two steps.

            // Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();

            // Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            // An existing workbook is opened.
            IWorkbook workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\GroupShapes.xlsx");

            // The first worksheet object in the worksheets collection is accessed.
            IWorksheet worksheet;

            string fileName = string.Empty;

            if (groupRBtn.IsChecked.Value)
            {
                // The first worksheet object in the worksheets collection is accessed.
                worksheet = workbook.Worksheets[0];
                IShapes shapes = worksheet.Shapes;

                IShape[] groupItems;
                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes[i].Name == "Development" || shapes[i].Name == "Production" || shapes[i].Name == "Sales")
                    {
                        groupItems = new IShape[] { shapes[i], shapes[i + 1], shapes[i + 2], shapes[i + 3], shapes[i + 4], shapes[i + 5] };
                        shapes.Group(groupItems);
                        i = -1;
                    }
                }

                groupItems = new IShape[] { shapes[0], shapes[1], shapes[2], shapes[3], shapes[4], shapes[5], shapes[6] };
                shapes.Group(groupItems);

                fileName = "Group.xlsx";
                workbook.SaveAs(fileName);
            }
            else if(ungroupRBtnAll.IsChecked.Value)
            {
                // The second worksheet object in the worksheets collection is accessed.
                worksheet = workbook.Worksheets[1];
                IShapes shapes = worksheet.Shapes;
                shapes.Ungroup(shapes[0] as IGroupShape, true);
                worksheet.Activate();
                fileName = "Ungroup.xlsx";
                workbook.SaveAs(fileName);
            }
            else if (ungroupRBtn.IsChecked.Value)
            {
                // The second worksheet object in the worksheets collection is accessed.
                worksheet = workbook.Worksheets[1];
                IShapes shapes = worksheet.Shapes;
                shapes.Ungroup(shapes[0] as IGroupShape);
                worksheet.Activate();
                fileName = "Ungroup.xlsx";
                workbook.SaveAs(fileName);
            }
            //Close the workbook.
            workbook.Close();
            excelEngine.Dispose();

            //Message box confirmation to view the created spreadsheet.
            if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                try
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                    System.Diagnostics.Process.Start(fileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
                // Exit
                this.Close();
        }

        /// <summary>
        /// Opens input template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Input_Click(object sender, RoutedEventArgs e)
        {
            //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]
            System.Diagnostics.Process.Start(@"..\..\..\..\..\..\..\Common\Data\XlsIO\GroupShapes.xlsx");
        }
    }
}
