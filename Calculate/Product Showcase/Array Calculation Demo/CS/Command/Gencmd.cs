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

namespace ArrayICalcData
{
    public class Gencmd : ICommand
    {
        private Data viewModel;

        #region Constructor

        public Gencmd(Data _viewModel)
        {
            viewModel = _viewModel;
        }

        #endregion

        #region Method

        //Return boolean value
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
            //create some sample data
            viewModel.NRows = viewModel.r.Next(10) + 2;
            viewModel.nCols = viewModel.r.Next(3) + 1;
            double[,] a = new double[viewModel.nRows, viewModel.nCols];//{{1.1,2.1},{3.1,4.1}};
            for (int row = 0; row < viewModel.nRows; ++row)
            {
                for (int col = 0; col < viewModel.nCols; ++col)
                {
                    a[row, col] = ((double)viewModel.r.Next(100)) / 10;
                }
            }
            //create a ArrayCalcData object and pass it this array
            viewModel.data = new ArrayCalcData(a);

            //create an CalcEngine object using this ArrayCalcData object
            CalcEngine engine = new CalcEngine(viewModel.data);

            //Turn on dependency tracking so values set with the Set button
            //take effect immediately
            engine.UseDependencies = true;

            //call RecalculateRange so any formulas in the data can be initially computed.
            engine.RecalculateRange(RangeInfo.Cells(1, 1, viewModel.nRows + 1, viewModel.nCols + 1), viewModel.data);

            viewModel.ShowObject();
        }

        #endregion
    }
}
