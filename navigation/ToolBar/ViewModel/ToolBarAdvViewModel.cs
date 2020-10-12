#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents the ViewModel class for ToolBarAdv
    /// </summary>
    public class ToolBarAdvViewModel
    {
        /// <summary>
        /// Maintains the command for menu item 
        /// </summary>
        private ICommand clickCommand;

        /// <summary>
        /// Maintains the command for button
        /// </summary>
        private ICommand buttonCommand;

        /// <summary>
        /// Initializes the  instance of the <see cref="ToolBarAdvViewModel"/>class
        /// </summary>
        public ToolBarAdvViewModel()
        {
            clickCommand = new DelegateCommand<object>(ExecuteMenuItemClick);
            buttonCommand = new DelegateCommand<object>(ExecuteButtonClick);
        }

        /// <summary>
        /// Gets or sets the command for menu item <see cref="ToolBarAdvViewModel"/> class.
        /// </summary>
        public ICommand ClickCommand
        {
            get
            {
                return clickCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for button <see cref="ToolBarAdvViewModel"/> class.
        /// </summary>
        public ICommand ButtonCommand
        {
            get
            {
                return buttonCommand;
            }
        }

        /// <summary>
        /// Method to execute button click
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteButtonClick(object param)
        {
            MessageBox.Show("MenuItem has been clicked");
        }

        /// <summary>
        /// Method to execute menu item click
        /// </summary>
        /// <param name="param">Specifies the Obejct parameter</param>
        private void ExecuteMenuItemClick(object param)
        {
            MessageBox.Show("The MenuItem" + " " + (param as MenuItem).Header.ToString() + " has been selected");
        }
    }
}
