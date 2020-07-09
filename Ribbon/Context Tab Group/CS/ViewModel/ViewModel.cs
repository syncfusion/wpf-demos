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

namespace ContextTabGroupSample
{
    /// <summary>
    /// Class represents the business or behaviour logic for MainWindow.xaml
    /// </summary>
    class ViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the command to hide picture tools.
        /// </summary>
        private ICommand hidePictureToolsCommand;

        /// <summary>
        /// Maintains the context tab visibility.
        /// </summary>
        private bool isGroupVisibleProperty;

        /// <summary>
        /// Maintains the border thickness.
        /// </summary>
        private Thickness borderThicknessProperty;

        /// <summary>
        /// Maintains the command to show picture tools.
        /// </summary>
        private ICommand showPictureToolsCommand;

        /// <summary>
        /// Maintains the command for help.
        /// </summary>
        private ICommand helpCommand;

        /// <summary>
        /// Maintains the command for buttons
        /// </summary>
        private ICommand buttonCommand;

        /// <summary>
        /// Maintains the command for dropdown
        /// </summary>
        private ICommand dropdownCommand;

        /// <summary>
        /// Initializes the new instance of <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            hidePictureToolsCommand = new DelegateCommand<object>(ExecuteHidePictureToolsCommand);
            showPictureToolsCommand = new DelegateCommand<object>(ExecuteShowPictureToolsCommand);
            helpCommand = new DelegateCommand<object>(ExecuteHelpCommand);
            buttonCommand = new DelegateCommand<object>(ButtonCommandExecute);
            dropdownCommand = new DelegateCommand<object>(DropDownCommandExecute);

            borderThicknessProperty = new Thickness(0);
        }

        /// <summary>
        /// Gets or sets the image border thickness <see cref="ViewModel"/> class.
        /// </summary>
        public Thickness BorderThicknessProperty { get { return borderThicknessProperty; } set { borderThicknessProperty = value; RaisePropertyChanged("BorderThicknessProperty"); } }

        /// <summary>
        /// Indicates whether the context tab is visible or not <see cref="ViewModel"/> class.
        /// </summary>
        public bool IsGroupVisibleProperty { get { return isGroupVisibleProperty; } set { isGroupVisibleProperty = value; RaisePropertyChanged("IsGroupVisibleProperty"); } }

        /// <summary>
        /// Gets the command for hide the picture tool tabs <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand HidePictureToolsCommand
        {
            get
            {
                return hidePictureToolsCommand;
            }
        }

        /// <summary>
        /// Gets the command for help <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand HelpCommand
        {
            get
            {
                return helpCommand;
            }
        }

        /// <summary>
        /// Gets the command for show the picture tool tabs <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand ShowPictureToolsCommand
        {
            get
            {
                return showPictureToolsCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for button <see cref="ViewModel"/> class.
        /// </summary>      
        public ICommand ButtonCommand
        {
            get
            {
                return buttonCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for dropdown <see cref="ViewModel"/> class.
        /// </summary>      
        public ICommand DropDownCommand
        {
            get
            {
                return dropdownCommand;
            }
        }

        /// <summary>
        /// Method used to execute the hidePictureToolsCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteHidePictureToolsCommand(object parameter)
        {
            IsGroupVisibleProperty = false;
            BorderThicknessProperty = new Thickness(0);
        }

        /// <summary>
        /// Method used to execute the showPictureToolsCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteShowPictureToolsCommand(object parameter)
        {
            IsGroupVisibleProperty = true;
            BorderThicknessProperty = new Thickness(1);
        }

        /// <summary>
        /// Method used to execute the helpCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteHelpCommand(object parameter)
        {
            System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/welcome-to-syncfusion-essential-wpf");
        }

        /// <summary>
        /// Method used to execute the button command.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private void ButtonCommandExecute(object parameter)
        {
            MessageBox.Show("Click operation has been performed.");
        }

        /// <summary>
        /// Method used to execute the dropdown command.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private void DropDownCommandExecute(object parameter)
        {
            MessageBox.Show("The dropdown item has been selected.");
        }
    }
}
