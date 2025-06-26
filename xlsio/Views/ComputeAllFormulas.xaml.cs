#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
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
    /// Interaction logic for ComputeAllFormulas.xaml
    /// </summary>
    public partial class ComputeAllFormulas : DemoControl
    {
        # region Private Members
        private string filename;
        private const string DEFAULTPATH = @"Assets\XlsIO\{0}";

        #endregion

        #region Constructor
        /// <summary>
        /// ComputeAllFormulas constructor
        /// </summary>
        public ComputeAllFormulas()
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
        /// Creates spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.
            string inputPath = GetFullTemplatePath("TimelogTemplate.xls");
            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //Open the workbook
            IWorkbook workbook = application.Workbooks.Open(inputPath, ExcelOpenType.Automatic);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            if (this.rdbtnXLS.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel97to2003;
                filename = "ComputeAllFormulas.xls";
            }
            else if (this.rdbtnXLSX.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Xlsx;
                filename = "ComputeAllFormulas.xlsx";
            }            

            #region Compute Formulas
            //Enable to calculate formulas in the sheet.
            sheet.EnableSheetCalculations();

            //hourly rate
            sheet["G7"].Number = 11;

            //overtime rate.
            sheet["J7"].Formula = "=SUM(G7*1.5)";

            //Regular hours
            sheet["F10"].Formula = "=IF((((C10-B10)+(E10-D10))*24)>8,8,((C10-B10)+(E10-D10))*24)";
            sheet["F11"].Formula = "=IF((((C11-B11)+(E11-D11))*24)>8,8,((C11-B11)+(E11-D11))*24)";
            sheet["F12"].Formula = "=IF((((C12-B12)+(E12-D12))*24)>8,8,((C12-B12)+(E12-D12))*24)";
            sheet["F13"].Formula = "=IF((((C13-B13)+(E13-D13))*24)>8,8,((C13-B13)+(E13-D13))*24)";
            sheet["F14"].Formula = "=IF((((C14-B14)+(E14-D14))*24)>8,8,((C14-B14)+(E14-D14))*24)";
            sheet["F15"].Formula = "=IF((((C15-B15)+(E15-D15))*24)>8,8,((C15-B15)+(E15-D15))*24)";

            //overtime hours
            sheet["G10"].Formula = "=IF(((C10-B10)+(E10-D10))*24>8, ((C10-B10)+(E10-D10))*24-8,0)";
            sheet["G11"].Formula = "=IF(((C11-B11)+(E11-D11))*24>8, ((C11-B11)+(E11-D11))*24-8,0)";
            sheet["G12"].Formula = "=IF(((C12-B12)+(E12-D12))*24>8, ((C12-B12)+(E12-D12))*24-8,0)";
            sheet["G13"].Formula = "=IF(((C13-B13)+(E13-D13))*24>8, ((C13-B13)+(E13-D13))*24-8,0)";
            sheet["G14"].Formula = "=IF(((C14-B14)+(E14-D14))*24>8, ((C14-B14)+(E14-D14))*24-8,0)";
            sheet["G15"].Formula = "=IF(((C15-B15)+(E15-D15))*24>8, ((C15-B15)+(E15-D15))*24-8,0)";

            //regular pay
            sheet["H10"].Formula = "=SUM(F10*G7)";
            sheet["H11"].Formula = "=SUM(F11*G7)";
            sheet["H12"].Formula = "=SUM(F12*G7)";
            sheet["H13"].Formula = "=SUM(F13*G7)";
            sheet["H14"].Formula = "=SUM(F14*G7)";
            sheet["H15"].Formula = "=SUM(F15*G7)";

            //overtime pay
            sheet["I10"].Formula = "=SUM(G10*J7)";
            sheet["I11"].Formula = "=SUM(G11*J7)";
            sheet["I12"].Formula = "=SUM(G12*J7)";
            sheet["I13"].Formula = "=SUM(G13*J7)";
            sheet["I14"].Formula = "=SUM(G14*J7)";
            sheet["I15"].Formula = "=SUM(G15*J7)";

            //total pay
            sheet["J10"].Formula = "=SUM(H10+I10)";
            sheet["J11"].Formula = "=SUM(H11+I11)";
            sheet["J12"].Formula = "=SUM(H12+I12)";
            sheet["J13"].Formula = "=SUM(H13+I13)";
            sheet["J14"].Formula = "=SUM(H14+I14)";
            sheet["J15"].Formula = "=SUM(H15+I15)";

            //total regular hours
            sheet["F17"].Formula = "=SUM(F10:F15)";

            //total overtime hours
            sheet["G17"].Formula = "=SUM(G10:G15)";

            //total regular pay
            sheet["H17"].Formula = "=SUM(H10:H15)";

            //total overtime pay
            sheet["I17"].Formula = "=SUM(I10:I15)";

            //total pay
            sheet["J17"].Formula = "=SUM(J10:J15)";

            //consolidated pay
            sheet["C20"].Formula = "=J17";
            //allowance
            sheet["C21"].Number = 20;
            //PF
            sheet["C22"].Number = 38;

            //Net pay
            sheet["C24"].Formula = "=SUM(C20:C21)-C22";
            #endregion

            #region Workbook Save and Close
            try
            {
                //Saving the workbook to disk.
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
        #region HelperMethods
        /// <summary>
        /// Get the file path of input file and return the same
        /// </summary>
        /// <param name="inputPath">Input file</param>
        /// <returns>path of the input file</returns>
        private string GetFullTemplatePath(string inputFile)
        {
            return string.Format(DEFAULTPATH, inputFile);
        }
        #endregion
        #endregion

    }
}