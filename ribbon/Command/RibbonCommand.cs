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

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Class maintains the common commands for all samples.
    /// </summary>
    public static class RibbonCommand
    {
        /// <summary>
        /// Maintains the command for buttons
        /// </summary>
        private static ICommand buttonCommand;

        /// <summary>
        /// Maintains the command for dropdown
        /// </summary>
        private static ICommand dropdownCommand;

        /// <summary>
        /// Maintains the command for help.
        /// </summary>
        private static ICommand helpCommand;

        /// <summary>
        /// Maintains the command for getting started button in help backStage.
        /// </summary>
        private static ICommand gettingStartedCommand;

        /// <summary>
        /// Maintains the command for ribbon combobox.
        /// </summary>
        private static ICommand ribbonComboBoxCommand;

        /// <summary>
        /// Initializes the new instance of <see cref="RibbonCommand"/> class.
        /// </summary>
        static RibbonCommand()
        {
            buttonCommand = new DelegateCommand<object>(ButtonCommandExecute);
            dropdownCommand = new DelegateCommand<object>(DropDownCommandExecute);
            helpCommand = new DelegateCommand<object>(ExecuteHelpCommand);
            gettingStartedCommand = new DelegateCommand<object>(ExecuteGettingStartedCommand);
            ribbonComboBoxCommand = new DelegateCommand<object>(ExecuteRibbonComboBoxCommand);
        }


        /// <summary>
        /// Gets or sets the command for button <see cref="RibbonCommand"/> class.
        /// </summary>      
        public static ICommand ButtonCommand
        {
            get
            {
                return buttonCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for dropdown <see cref="RibbonCommand"/> class.
        /// </summary>      
        public static ICommand DropDownCommand
        {
            get
            {
                return dropdownCommand;
            }
        }

        /// <summary>
        /// Gets the command for help <see cref="RibbonCommand"/> class.
        /// </summary>
        public static ICommand HelpCommand
        {
            get
            {
                return helpCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for online getting started button in help backstage <see cref="RibbonCommand"/> class.
        /// </summary>
        public static ICommand GettingStartedCommand
        {
            get
            {
                return gettingStartedCommand;
            }
        }

        /// <summary>
        /// Gets the command for ribbon comboBox <see cref="RibbonCommand"/> class.
        /// </summary>
        public static ICommand RibbonComboBoxCommand
        {
            get
            {
                return ribbonComboBoxCommand;
            }
        }


        /// <summary>
        /// Method used to execute the button command.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private static void ButtonCommandExecute(object parameter)
        {
            MessageBox.Show("Click operation has been performed.");
        }

        /// <summary>
        /// Method used to execute the dropdown command.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private static void DropDownCommandExecute(object parameter)
        {
            MessageBox.Show("The dropdown item has been selected.");
        }

        /// <summary>
        /// Method used to execute the ribbon comboBox command.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private static void ExecuteRibbonComboBoxCommand(object parameter)
        {
            if ((parameter != null && (int)parameter >= 0))
            {
                MessageBox.Show("The dropdown item has been selected.");
            }
        }

        /// <summary>
        /// Method used to execute the helpCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private static void ExecuteHelpCommand(object parameter)
        {
            if (MessageBox.Show("Are you sure to visit the help page ?", "Online Help", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/welcome-to-syncfusion-essential-wpf");
            }
        }

        /// <summary>
        /// Method to execute the command for button in help backstage tab.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private static void ExecuteGettingStartedCommand(object parameter)
        {
            if (MessageBox.Show("Are you sure to visit the getting started page ?", "Getting Started", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/ribbon/gettingstarted");
            }
        }
    }
}
