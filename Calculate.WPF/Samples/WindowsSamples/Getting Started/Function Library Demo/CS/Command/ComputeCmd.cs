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
using Syncfusion.Calculate;
using Syncfusion.Windows.Calculate;

namespace FormulaSupport
{
    public class ComputeCmd : ICommand
    {
        private ViewModel viewModel;

        #region Constructor
        public ComputeCmd(ViewModel _viewModel)
        {
            viewModel = _viewModel;
        }
        #endregion

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67
        //Initialize calculate object
        CalcQuick calculate = new CalcQuick();

        #region Methods

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            calculate["A"] = viewModel.TxtA;
            calculate["B"] = viewModel.TxtB;
            calculate["C"] = viewModel.TxtC;
            calculate["D"] = viewModel.TxtD;
            calculate["Gen"] = viewModel.TxtGen;

            calculate.SetDirty();

            viewModel.TxtA = calculate["A"];
            viewModel.TxtB = calculate["B"];
            viewModel.TxtC = calculate["C"];
            viewModel.TxtD = calculate["D"];
            viewModel.TxtGen = calculate["Gen"];
        }
        #endregion

    }
}
