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
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for AutoShape.xaml
    /// </summary>
    public partial class AutoShape : DemoControl
    {
        #region
        /// <summary>
        /// File Name
        /// </summary>
	    private string fileName;
        #endregion

        #region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public AutoShape()
        {
            InitializeComponent();            
        }
        # endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        # region Events
        /// <summary>
        /// Creates spreadsheet with chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
                       
            application.DefaultVersion = ExcelVersion.Excel2016;
            
            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 1 worksheet.
            IWorkbook workbook = application.Workbooks.Create(1);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet worksheet = workbook.Worksheets[0];

            #region AddAutoShapes
            IShape shape;
            string text;

            IFont font = workbook.CreateFont();
            font.Color = ExcelKnownColors.White;
            font.Italic = true;
            font.Size = 12;


            IFont font2 = workbook.CreateFont();
            font2.Color = ExcelKnownColors.Black;
            font2.Size = 15;
            font2.Italic = true;
            font2.Bold = true;

            text = "Requirement";
            shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.RoundedRectangle, 2, 7, 60, 192);
            shape.TextFrame.TextRange.Text = text;
            shape.TextFrame.TextRange.RichText.SetFont(0, text.Length - 1, font);
            shape.TextFrame.TextRange.RichText.SetFont(0, 0, font2);
            shape.Fill.ForeColorIndex = ExcelKnownColors.Light_blue;
            shape.Line.Visible = false;
            shape.TextFrame.VerticalAlignment = ExcelVerticalAlignment.MiddleCentered;

            shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.DownArrow, 5, 8, 40, 64);
            shape.Fill.ForeColorIndex = ExcelKnownColors.White;
            shape.Line.ForeColorIndex = ExcelKnownColors.Blue;
            shape.Line.Weight = 1;

            text = "Design";
            shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.RoundedRectangle, 7, 7, 60, 192);
            shape.TextFrame.TextRange.Text = text;
            shape.TextFrame.TextRange.RichText.SetFont(0, text.Length - 1, font);
            shape.TextFrame.TextRange.RichText.SetFont(0, 0, font2);
            shape.Line.Visible = false;
            shape.Fill.ForeColorIndex = ExcelKnownColors.Light_orange;
            shape.TextFrame.VerticalAlignment = ExcelVerticalAlignment.MiddleCentered;


            shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.DownArrow, 10, 8, 40, 64);
            shape.Fill.ForeColorIndex = ExcelKnownColors.White;
            shape.Line.ForeColorIndex = ExcelKnownColors.Blue;
            shape.Line.Weight = 1;

            text = "Execution";
            shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.RoundedRectangle, 12, 7, 60, 192);
            shape.TextFrame.TextRange.Text = text;
            shape.TextFrame.TextRange.RichText.SetFont(0, text.Length - 1, font);
            shape.TextFrame.TextRange.RichText.SetFont(0, 0, font2);
            shape.Line.Visible = false;
            shape.Fill.ForeColorIndex = ExcelKnownColors.Blue;
            shape.TextFrame.VerticalAlignment = ExcelVerticalAlignment.MiddleCentered;

            shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.DownArrow, 15, 8, 40, 64);
            shape.Fill.ForeColorIndex = ExcelKnownColors.White;
            shape.Line.ForeColorIndex = ExcelKnownColors.Blue;
            shape.Line.Weight = 1;

            text = "Testing";
            shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.RoundedRectangle, 17, 7, 60, 192);
            shape.TextFrame.TextRange.Text = text;
            shape.TextFrame.TextRange.RichText.SetFont(0, text.Length - 1, font);
            shape.TextFrame.TextRange.RichText.SetFont(0, 0, font2);
            shape.Line.Visible = false;
            shape.Fill.ForeColorIndex = ExcelKnownColors.Green;
            shape.TextFrame.VerticalAlignment = ExcelVerticalAlignment.MiddleCentered;

            shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.DownArrow, 20, 8, 40, 64);
            shape.Fill.ForeColorIndex = ExcelKnownColors.White;
            shape.Line.ForeColorIndex = ExcelKnownColors.Blue;
            shape.Line.Weight = 1;

            text = "Release";
            shape = worksheet.Shapes.AddAutoShapes(AutoShapeType.RoundedRectangle, 22, 7, 60, 192);
            shape.TextFrame.TextRange.Text = text;
            shape.TextFrame.TextRange.RichText.SetFont(0, text.Length - 1, font);
            shape.TextFrame.TextRange.RichText.SetFont(0, 0, font2);
            shape.Line.Visible = false;
            shape.Fill.ForeColorIndex = ExcelKnownColors.Lavender;
            shape.TextFrame.VerticalAlignment = ExcelVerticalAlignment.MiddleCentered;
            #endregion           
            
            try
            {
                //Saving the workbook to disk.

                fileName = "AutoShapes.xlsx";

                workbook.SaveAs(fileName);

                //Close the workbook.
                workbook.Close();

                //No exception will be thrown if there are unsaved workbooks.
                excelEngine.ThrowNotSavedOnDestroy = false;
                excelEngine.Dispose();

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName) { UseShellExecute = true };
                    process.Start();
                }                
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
        # endregion
    }
}