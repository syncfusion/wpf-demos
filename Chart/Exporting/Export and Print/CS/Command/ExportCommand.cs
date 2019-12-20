#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Input;

namespace ExportChartDemo
{
    public class ExportCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ViewModel m_viewModel;

        public ExportCommand(ViewModel viewModel)
        {
            m_viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter.ToString() == "Save")
            {
                m_viewModel.Save();
            }
            else
            {
                m_viewModel.Print();
            }
        }
    }
}
