#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockZoomingDemo
{
    public class RangeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ViewModel m_viewModel;
        public RangeCommand(ViewModel viewModel)
        {
            m_viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            m_viewModel.SetRange(parameter.ToString());
        }
    }
}
