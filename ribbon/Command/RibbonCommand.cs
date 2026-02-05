#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;

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
        /// Maintains the command to show the save dialog.
        /// </summary>
        private static ICommand saveAsCommand;

        /// <summary>
        /// Maintains the command to show the open dialog.
        /// </summary>
        private static ICommand openCommand;

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
            saveAsCommand = new DelegateCommand<object>(ExecuteSaveAsCommand);
            openCommand = new DelegateCommand<object>(ExecuteOpenCommand);
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
        /// Gets or sets the command to show the save dialog. <see cref="RibbonCommand"/> class.
        /// </summary>
        public static ICommand SaveAsCommand
        {
            get
            {
                return saveAsCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command to show the open dialog. <see cref="RibbonCommand"/> class.
        /// </summary>
        public static ICommand OpenCommand
        {
            get
            {
                return openCommand;
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
            System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/welcome-to-syncfusion-essential-wpf");
        }

        /// <summary>
        /// Method to execute the command for button in help backstage tab.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private static void ExecuteGettingStartedCommand(object parameter)
        {
            System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/ribbon/gettingstarted");
        }

        /// <summary>
        /// Method which is used to execute the saveas command.
        /// </summary>
        /// <param name="parameter">Specifies the parameter of saveas command.</param>
        private static void ExecuteSaveAsCommand(object parameter)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "FlowDocument Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            saveFile.ShowDialog();
        }

        /// <summary>
        /// Method which is used to execute the open command.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private static void ExecuteOpenCommand(object parameter)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "FlowDocument Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            openFile.ShowDialog();
        }
    }
}
