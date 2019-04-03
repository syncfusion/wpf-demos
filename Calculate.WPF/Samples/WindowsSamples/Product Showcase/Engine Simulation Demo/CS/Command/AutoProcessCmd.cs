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
using System.Windows.Input;
using System.Windows;
using Syncfusion.Calculate;
using System.Globalization;

namespace XlsFileUsingXlsIO
{
    public class AutoProcessCmd : ICommand
    {
        #region API Definition
        private ViewModel viewModel;
        #endregion

        #region Constructor
        public AutoProcessCmd(ViewModel _viewModel)
        {
            viewModel = _viewModel;            
        }
        #endregion 

        #region Method

        public bool CanExecute(object parameter)
        {
            return true;
        }
#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67
        public void Execute(object parameter)
        {
            Generate();
        }

        private void Generate()
        {
            //Run 1000 interations:
            int num = 1000;


            DateTime start = DateTime.Now;
            CalcSheet inputSheet = viewModel.CalcWB["Inputs"];
            Random r = new Random();

            viewModel.CalcWB.Engine.CalculatingSuspended = true;

            for (int i = 0; i < num; ++i)
            {
                //1) Set random values into the Inputs sheet:
                inputSheet[viewModel.AgeRow, 2] = (r.Next(74) + 15).ToString();
                inputSheet[viewModel.SexRow, 2] = r.Next(2) == 1 ? "M" : "F";
                inputSheet[viewModel.StateRow, 2] = viewModel.ItemState[r.Next(50)];
                inputSheet[viewModel.PointsRow, 2] = r.Next(15).ToString();
                inputSheet[viewModel.ModelRow, 2] = r.Next(11).ToString();
                inputSheet[viewModel.ModelYearRow, 2] = (33 + r.Next(1972)).ToString();
                inputSheet[viewModel.MultipleDiscountRow, 2] = r.Next(2) == 1 ? "Yes" : "No";
                inputSheet[3, 5] = viewModel.TxtBAmt;

                //2) Calculations are suspended so need to pull the computed value to
                //make sure it has been calculated with the latest changes:
                viewModel.CalcWB.Engine.UpdateCalcID();
                viewModel.CalcWB.Engine.PullUpdatedValue(viewModel.CalcWB.GetSheetID("Outputs"), 1, 1);

                //3) Get the value from cell 1,1 on the output sheet:
                double d;
                if (double.TryParse(viewModel.CalcWB["Outputs"][1, 1].ToString(), NumberStyles.Any, null, out d))
                {
                    viewModel.TxtPrice = string.Format("{0:C2}", d); //cell 1,1 on the outputs sheet has the result
                }
                else
                    viewModel.TxtPrice = "---";

                //this.txtPrice.Text = string.Empty;
                viewModel.CalcWB.Engine.CalculatingSuspended = false;

                viewModel.TxtPrice = string.Format("{0} updates in {1} seconds", num, (TimeSpan)(DateTime.Now - start));
            }
        }
        #endregion
    }
}
