#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Input;

namespace Accordion
{
    /// <summary>
    ///  Represents the behaviour or business logic code for MainWindow1.xaml.
    /// </summary>
    public class ViewModel
    {
        /// <summary>
        /// Maintains the comand for button.
        /// </summary>
        private ICommand downloadCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>    
        public ViewModel()
        {
            downloadCommand = new DelegateCommand(Execute, CanExecute);
        }

        /// <summary>
        /// Command implementation for download button in accordion.
        /// </summary>
        public ICommand DownloadCommand
        {
            get
            {
                return downloadCommand;
            }
        }

        /// <summary>
        /// Method which is used to implement button action.
        /// </summary>
        /// <param name="parameter">Button to show the action.</param>
        private void Execute(object parameter)
        {
            MessageBox.Show("Download button clicked.");       
        }

        /// <summary>
        /// Method indicates boolean type execution.
        /// </summary>
        /// <param name="parameter">Specifies the parameter of canexecute.</param>
        /// <returns>Specifies the boolean.</returns>
        private bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
