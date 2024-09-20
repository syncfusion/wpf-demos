#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for WhatIfAnalysis.xaml
    /// </summary>
    public partial class WhatIfAnalysis : DemoControl
    {
        # region Constructor
        /// <summary>
        /// WhatIfAnalysis constructor
        /// </summary>
        public WhatIfAnalysis()
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

        #region Create the Document
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //Initialize ExcelEngine
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Initialize IApplication and set the default application version
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                //Load the Excel template into IWorkbook and get the worksheet into IWorksheet
                IWorkbook workbook = application.Workbooks.Open(@"Assets\XlsIO\WhatIfAnalysisTemplate.xlsx");
                IWorksheet worksheet = workbook.Worksheets[0];

                //Initailize list objects with different values for scenarios
                List<object> currentChange_Values = new List<object> { 0.23, 0.8, 1.1, 0.5, 0.35, 0.2, 0.4, 0.37, 1.1, 1, 0.94, 0.75 };
                List<object> increasedChange_Values = new List<object> { 0.45, 0.56, 0.9, 0.5, 0.58, 0.43, 0.39, 0.89, 1.45, 1.2, 0.99, 0.8 };
                List<object> decreasedChange_Values = new List<object> { 0.3, 0.2, 0.5, 0.3, 0.5, 0.23, 0.2, 0.3, 0.8, 0.6, 0.87, 0.4 };

                List<object> currentQuantity_Values = new List<object> { 1500, 3000, 5000, 4000, 500, 4000, 1200, 1500, 750, 750, 1200, 7900 };
                List<object> increasedQuantity_Values = new List<object> { 1000, 5000, 4500, 3900, 10000, 8900, 8000, 3500, 15000, 5500, 4500, 4200 };
                List<object> decreasedQuantity_Values = new List<object> { 1000, 2000, 3000, 3000, 300, 4000, 1200, 1000, 550, 650, 800, 6900 };

                //Add scenarios in the worksheet
                IScenarios scenarios = worksheet.Scenarios;
                scenarios.Add("Current % of Change", worksheet.Range["F5:F16"], currentChange_Values);
                scenarios.Add("Increased % of Change", worksheet.Range["F5:F16"], increasedChange_Values);
                scenarios.Add("Decreased % of Change", worksheet.Range["F5:F16"], decreasedChange_Values);

                scenarios.Add("Current Quantity", worksheet.Range["D5:D16"], currentQuantity_Values);
                scenarios.Add("Increased Quantity", worksheet.Range["D5:D16"], increasedQuantity_Values);
                scenarios.Add("Decreased Quantity", worksheet.Range["D5:D16"], decreasedQuantity_Values);

                //Create Summary
                if (chkboxCreateSummary.IsChecked.Value)
                {
                    worksheet.Scenarios.CreateSummary(worksheet.Range["L7"]);
                }

                string filename = "What-If Analysis.xlsx";
                workbook.SaveAs(filename);

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the Workbook?", "Creation successful",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
                        process.Start();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
        }
        #endregion 

        #region View the Input Template
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\XlsIO\WhatIfAnalysisTemplate.xlsx") { UseShellExecute = true };
            process.Start();
        }
        #endregion
    }
}
