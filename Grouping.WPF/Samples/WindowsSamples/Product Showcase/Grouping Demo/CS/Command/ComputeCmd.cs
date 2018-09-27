#region Copyright Syncfusion Inc. 2001 - 2013
// Copyright Syncfusion Inc. 2001 - 2013. All rights reserved.
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

namespace GroupingWithDataGrid
{
    public class ComputeCmd:ICommand
    {

        public ViewModel ViewModel;
        public ComputeCmd(ViewModel Model)
        {
            this.ViewModel = Model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
           ViewModel.PopulateDataTable((int)ViewModel.NNum, ViewModel.MyTable);
           ViewModel.RefreshStatsPanel();
        }
    }
}
