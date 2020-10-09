#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.navigationdemos.wpf
{
    public class GettingStartedViewModel 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStartedViewModel" /> class.
        /// </summary>    
        public GettingStartedViewModel()
        {
            DownloadCommand = new DelegateCommand(Execute);
        }

        /// <summary>
        /// Command implementation for download button in accordion <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand DownloadCommand { get; set; }

        /// <summary>
        /// Method which is used to implement button action.
        /// </summary>
        /// <param name="parameter">Button to show the action.</param>
        public void Execute(object parameter)
        {
            MessageBox.Show("Click operation has been performed.");
        }
    }
}
