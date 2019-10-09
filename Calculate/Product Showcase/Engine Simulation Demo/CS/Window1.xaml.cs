#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Windows.Shapes;
using Syncfusion.Calculate;
using System.Globalization;
using Syncfusion.Windows.Shared;

namespace XlsFileUsingXlsIO
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        #region Construtor

        public Window1()
        {
            InitializeComponent();

            this.cboState.SelectedIndex = 0;
            this.cboSex.SelectedIndex = 0;
            this.cboModel.SelectedIndex = 0;
            this.txtBAmt.Text = "600";
            NumberFormatInfo info = new NumberFormatInfo();
            info.NumberGroupSizes = new int[] { 0 };
            nModelYear.NumberFormatInfo = info;
        }

        #endregion

        #region FindFile Utility
        /// <summary>
        /// Finds a file of the given name in the current directory or sibling "Data" directory.
        /// If file is not found, the parent folder is checked until the file is found. This method
        /// is used by our samples when they load data from a separate "Data" folder.
        /// </summary>
        /// <param name="dataDirName">The name of the "Data" folder.</param>
        /// <param name="fileName">The filename to be searched.</param>
        /// <returns>The full path of the file that was found; an empty string is returned if file is not found.</returns>

        public static string FindFile(string dataDirName, string fileName)
        {
            dataDirName = dataDirName.TrimEnd('\\', '/');
            // Check both in parent folder and Parent\Data folders.
            string dataFileName = dataDirName + "\\" + fileName;
            for (int n = 0; n < 10; n++)
            {
                if (System.IO.File.Exists(fileName))
                {
                    return fileName;
                }
                if (System.IO.File.Exists(dataFileName))
                {
                    return dataFileName;
                }
                fileName = @"..\" + fileName;
                dataFileName = @"..\" + dataFileName;
            }

            return "";
        }
        #endregion

        #region Declerations

        private XlsIOCalcWorkbook calcWB;
        private int ageRow = 3;
        private int sexRow = 4;
        private int stateRow = 5;
        private int pointsRow = 6;
        private int modelRow = 7;
        private int modelYearRow = 8;
        private int multipleDiscountRow = 9;

        #endregion

        #region SetSheetInputs
        //Set the input values into the CalcSheets:
        private void SetSheetInputs()
        {
            CalcSheet inputSheet = this.calcWB["Inputs"];
            inputSheet[ageRow, 2] = this.nA.Value.ToString();

            inputSheet[sexRow, 2] = ((XlsFileUsingXlsIO.Data)this.cboSex.SelectedItem).Sex;
            inputSheet[stateRow, 2] = ((XlsFileUsingXlsIO.Data)this.cboState.SelectedItem).State;
            inputSheet[pointsRow, 2] = this.nPoint.Value.ToString();
            inputSheet[modelRow, 2] = ((XlsFileUsingXlsIO.Data)this.cboModel.SelectedItem).Model;
            inputSheet[modelYearRow, 2] = this.nModelYear.Value.ToString();
            if (this.chkDiscount.IsChecked == true)
                inputSheet[multipleDiscountRow, 2] = "Yes";
            else
                inputSheet[multipleDiscountRow, 2] = "No";
            inputSheet[3, 5] = this.txtBAmt.Text;
        }

        #endregion

        #region Event Handlers

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
#if NETCORE
            calcWB = XlsIOCalcWorkbook.CreateFromXLS(@"..\..\..\..\CarIns.xls");
#else
            calcWB = XlsIOCalcWorkbook.CreateFromXLS(@"..\..\..\CarIns.xls");
#endif
            this.calcWB.Engine.LockDependencies = false;
            this.calcWB.CalculateAll();
            this.calcWB.Engine.LockDependencies = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Initialize calcsheet with input values from the form:
            SetSheetInputs();

            // Calculations not suspended so just getting the value triggers the computation,
            // so these two lines are not needed.....
            //this.calcWB.Engine.UpdateCalcID();
            //this.calcWB.Engine.PullUpdatedValue(this.calcWB.GetSheetID("Outputs"), 1, 1);

            //Get the value from cell 1,1 on the output sheet:
            double d;
            if (double.TryParse(calcWB["Outputs"][1, 1].ToString(), NumberStyles.Any, null, out d))
            {
                //Cell 1,1 on the output sheet has the result:
                this.txtPrice.Text = string.Format("{0:C2}", d);
            }
            else
                this.txtPrice.Text = "---";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //Run 1000 interations:
            int num = 1000;

            this.Cursor = Cursors.Wait;
            DateTime start = DateTime.Now;
            CalcSheet inputSheet = this.calcWB["Inputs"];
            Random r = new Random();

            this.calcWB.Engine.CalculatingSuspended = true;

            for (int i = 0; i < num; ++i)
            {
                //1) Set random values into the Inputs sheet:
                inputSheet[ageRow, 2] = (r.Next(74) + 15).ToString();
                inputSheet[sexRow, 2] = r.Next(2) == 1 ? "M" : "F";
                inputSheet[stateRow, 2] = this.cboState.Items[r.Next(50)];
                inputSheet[pointsRow, 2] = r.Next(15).ToString();
                inputSheet[modelRow, 2] = r.Next(11).ToString();
                inputSheet[modelYearRow, 2] = (33 + r.Next(1972)).ToString();
                inputSheet[multipleDiscountRow, 2] = r.Next(2) == 1 ? "Yes" : "No";
                inputSheet[3, 5] = this.txtBAmt.Text;

                //2) Calculations are suspended so need to pull the computed value to
                //make sure it has been calculated with the latest changes:
                this.calcWB.Engine.UpdateCalcID();
                this.calcWB.Engine.PullUpdatedValue(this.calcWB.GetSheetID("Outputs"), 1, 1);

                //3) Get the value from cell 1,1 on the output sheet:
                double d;
                if (double.TryParse(calcWB["Outputs"][1, 1].ToString(), NumberStyles.Any, null, out d))
                {
                    this.txtPrice.Text = string.Format("{0:C2}", d); //cell 1,1 on the outputs sheet has the result
                }
                else
                    this.txtPrice.Text = "---";

                //this.txtPrice.Text = string.Empty;
                this.calcWB.Engine.CalculatingSuspended = false;
                this.Cursor = Cursors.Arrow;
                this.txtPrice.Text = string.Format("{0} updates in {1} seconds", num, (TimeSpan)(DateTime.Now - start));
            }
        }

#endregion
    }
}

