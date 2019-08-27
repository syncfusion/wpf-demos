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
    public class ComputeCmd : ICommand
    {
        #region API Defintion

        private ViewModel viewModel;

        #endregion

        #region Constructor
        public ComputeCmd(ViewModel _viewModel)
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
            //Initialize calcsheet with input values from the form:
            viewModel.SetSheetInputs();

            // Calculations not suspended so just getting the value triggers the computation,
            // so these two lines are not needed.....
            //this.calcWB.Engine.UpdateCalcID();
            //this.calcWB.Engine.PullUpdatedValue(this.calcWB.GetSheetID("Outputs"), 1, 1);

            //Get the value from cell 1,1 on the output sheet:
            double d;
            if (double.TryParse(viewModel.CalcWB["Outputs"][1, 1].ToString(), NumberStyles.Any, null, out d))
            {
                //Cell 1,1 on the output sheet has the result:
                viewModel.TxtPrice = string.Format("{0:C2}", d);
            }
            else
                viewModel.TxtPrice = "---";
        }

        #endregion
    }
}
