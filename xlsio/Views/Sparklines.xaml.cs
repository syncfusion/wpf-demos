#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Diagnostics;
using System.Windows.Media;
using Syncfusion.XlsIO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for Sparklines.xaml
    /// </summary>
    public partial class Sparklines : DemoControl
    {
        #region
        /// <summary>
        /// File Name
        /// </summary>
        private string filename;
        #endregion

        # region Constructor
        /// <summary>
        /// Sparklines constructor
        /// </summary>
        public Sparklines()
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

        #region Events
        /// <summary>
        /// Creates spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

            //Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            application.DefaultVersion = ExcelVersion.Excel2010;
            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //Open workbook with Data
            IWorkbook workbook;

            workbook = excelEngine.Excel.Workbooks.Open(@"Assets\XlsIO\Sparkline.xlsx");

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];
            #region WholeSale Report

            //A new Sparkline group is added to the sheet sparklinegroups
            ISparklineGroup sparklineGroup = sheet.SparklineGroups.Add();

            //Set the Sparkline group type as line
            sparklineGroup.SparklineType = SparklineType.Line;

            //Set to display the empty cell as line
            sparklineGroup.DisplayEmptyCellsAs = SparklineEmptyCells.Line;

            //Sparkline group style properties
            sparklineGroup.ShowFirstPoint = true;
            sparklineGroup.FirstPointColor = System.Drawing.Color.Green;
            sparklineGroup.ShowLastPoint = true;
            sparklineGroup.LastPointColor = System.Drawing.Color.DarkOrange;
            sparklineGroup.ShowHighPoint = true;
            sparklineGroup.HighPointColor = System.Drawing.Color.DarkBlue;
            sparklineGroup.ShowLowPoint = true;
            sparklineGroup.LowPointColor = System.Drawing.Color.DarkViolet;
            sparklineGroup.ShowMarkers = true;
            sparklineGroup.MarkersColor = System.Drawing.Color.Black;
            sparklineGroup.ShowNegativePoint = true;
            sparklineGroup.NegativePointColor = System.Drawing.Color.Red;

            //set the line weight
            sparklineGroup.LineWeight = 0.3;

            //The sparklines are added to the sparklinegroup.
            ISparklines sparklines = sparklineGroup.Add();

            //Set the Sparkline Datarange .
            IRange dataRange = sheet.Range["D6:G17"];
            //Set the Sparkline Reference range.
            IRange referenceRange = sheet.Range["H6:H17"];

            //Create a sparkline with the datarange and reference range.
            sparklines.Add(dataRange, referenceRange);
            #endregion

            #region Retail Trade

            //A new Sparkline group is added to the sheet sparklinegroups
            sparklineGroup = sheet.SparklineGroups.Add();

            //Set the Sparkline group type as column
            sparklineGroup.SparklineType = SparklineType.Column;

            //Set to display the empty cell as zero
            sparklineGroup.DisplayEmptyCellsAs = SparklineEmptyCells.Zero;

            //Sparkline group style properties
            sparklineGroup.ShowHighPoint = true;
            sparklineGroup.HighPointColor = System.Drawing.Color.Green;
            sparklineGroup.ShowLowPoint = true;
            sparklineGroup.LowPointColor = System.Drawing.Color.Red;
            sparklineGroup.ShowNegativePoint = true;
            sparklineGroup.NegativePointColor = System.Drawing.Color.Black;

            //The sparklines are added to the sparklinegroup.
            sparklines = sparklineGroup.Add();

            //Set the Sparkline Datarange .
            dataRange = sheet.Range["D21:G32"];
            //Set the Sparkline Reference range.
            referenceRange = sheet.Range["H21:H32"];

            //Create a sparkline with the datarange and reference range.
            sparklines.Add(dataRange, referenceRange);

            #endregion

            #region Manufacturing Trade

            //A new Sparkline group is added to the sheet sparklinegroups
            sparklineGroup = sheet.SparklineGroups.Add();

            //Set the Sparkline group type as win/loss
            sparklineGroup.SparklineType = SparklineType.ColumnStacked100;

            sparklineGroup.DisplayEmptyCellsAs = SparklineEmptyCells.Zero;

            sparklineGroup.DisplayAxis = true;
            sparklineGroup.AxisColor = System.Drawing.Color.Black;
            sparklineGroup.ShowFirstPoint = true;
            sparklineGroup.FirstPointColor = System.Drawing.Color.Green;
            sparklineGroup.ShowLastPoint = true;
            sparklineGroup.LastPointColor = System.Drawing.Color.Orange;
            sparklineGroup.ShowNegativePoint = true;
            sparklineGroup.NegativePointColor = System.Drawing.Color.Red;

            sparklines = sparklineGroup.Add();

            dataRange = sheet.Range["D36:G46"];
            referenceRange = sheet.Range["H36:H46"];

            sparklines.Add(dataRange, referenceRange);

            #endregion

            try
            {
                //Saving the workbook to disk.
                workbook.Version = ExcelVersion.Excel2010;
                filename = "Sparklines.xlsx";

                workbook.SaveAs(filename);

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
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
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