#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Input;

namespace Serialization.ViewModel.Command
{
    public class SerializeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public CategoryDataViewModel currentViewModel;

        public SerializeCommand(CategoryDataViewModel viewModel)
        {
            currentViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var executeCommand = parameter.ToString();

            if(executeCommand == "Save")
            {
                currentViewModel.Save();
            }
            else
            {
                currentViewModel.Load();
            }
        }
    }
}
