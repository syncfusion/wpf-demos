#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Edit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Represents the view model class for edit control
    /// </summary>
    public class SyntaxEditorGettingStartedViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the command for status bar option
        /// </summary>
        private ICommand statusBarCommand;

        /// <summary>
        /// Maintains the command for insert tab option
        /// </summary>
        private ICommand insertTabCommand;

        /// <summary>
        /// Maintains the command for insert space option
        /// </summary>
        private ICommand insertSpaceCommand;

        /// <summary>
        /// Maintains the command for single line mode
        /// </summary>
        private ICommand singleLineCommand;

        /// <summary>
        /// Maintains the tab key behavior of edit control
        /// </summary>
        private TabKeyBehavior tabBehavior;

        /// <summary>
        /// Maintains the value indicating the statu bar is visible
        /// </summary>
        private bool statusBarChecked;

        /// <summary>
        /// Maintains the document source of  edit control
        /// </summary>
        private string documentSource;

        /// <summary>
        /// Maintains the font family
        /// </summary>
        private FontFamily selectedFont;

        /// <summary>
        /// Maintains the value indicating whether the insert tab option is checked
        /// </summary>
        private bool isChecked;

        /// <summary>
        /// Maintains the value indicating whether the line number is visible
        /// </summary>
        private bool lineNumber;

        /// <summary>
        /// Maintians the value indicating the single line mode
        /// </summary>
        private bool singleLineChecked;

        /// <summary>
        /// Maintains the command for edit control loaded event
        /// </summary>
        private ICommand editLoadedCommand;

        /// <summary>
        /// Initializes the instance of<see cref="SyntaxEditorGettingStartedViewModel"/>class
        /// </summary>
        public SyntaxEditorGettingStartedViewModel()
        {
            DocumentSource = "Data/syntaxeditor/Content.txt";
            SelectedFont = new FontFamily("Verdana");
            StatusBarChecked = true;
            TabBehavior = TabKeyBehavior.VS;
            IsChecked = true;
            LineNumber = false;
            SingleLineChecked = true;
            statusBarCommand = new DelegateCommand<object>(ExecuteStatusBarCommand);
            insertTabCommand = new DelegateCommand<object>(ExecuteInsertTabCommand);
            insertSpaceCommand = new DelegateCommand<object>(ExecuteInsertSpaceCommand);
            singleLineCommand = new DelegateCommand<object>(ExecuteSingleLineCommand);
            editLoadedCommand = new DelegateCommand<object>(ExecuteEditLoaded);
        }

        /// <summary>
        /// Gets or sets the command for edit control loaded event
        /// </summary>
        public ICommand EditLoadedCommand
        {
            get
            {
                return editLoadedCommand;
            }
        }

        /// <summary>
        /// Gets or sets the value indicating single line mode 
        /// </summary>
        public bool SingleLineChecked
        {
            get
            {
                return singleLineChecked;
            }
            set
            {
                singleLineChecked = value;
                RaisePropertyChanged("SingleLineChecked");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating the line number is visible
        /// </summary>
        public bool LineNumber
        {
            get
            {
                return lineNumber;
            }
            set
            {
                lineNumber = value;
                RaisePropertyChanged("LineNumber");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating the insert tab option is checked
        /// </summary>
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                RaisePropertyChanged("IsChecked");
            }
        }

        /// <summary>
        /// Gets or sets the font family of edit control
        /// </summary>
        public FontFamily SelectedFont
        {
            get
            {
                return selectedFont;
            }
            set
            {
                selectedFont = value;
                RaisePropertyChanged("SelectedFont");
            }
        }

        /// <summary>
        /// Gets or sets the document source of edit control
        /// </summary>
        public string DocumentSource
        {
            get
            {
                return documentSource;
            }
            set
            {
                documentSource = value;
                RaisePropertyChanged("DocumentSource");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the status bar is visible
        /// </summary>
        public bool StatusBarChecked
        {
            get
            {
                return statusBarChecked;
            }
            set
            {
                statusBarChecked = value;
                RaisePropertyChanged("StatusBarChecked");
            }
        }

        /// <summary>
        /// Gets or sets the tab key behavior of edit control
        /// </summary>
        public TabKeyBehavior TabBehavior
        {
            get
            {
                return tabBehavior;
            }
            set
            {
                tabBehavior = value;
                RaisePropertyChanged("TabBehavior");
            }
        }

        /// <summary>
        /// Gets or sets the command for single line mode
        /// </summary>
        public ICommand SingleLineCommand
        {
            get
            {
                return singleLineCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for insert space option
        /// </summary>
        public ICommand InsertSpaceCommand
        {
            get
            {
                return insertSpaceCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for insert tab option
        /// </summary>
        public ICommand InsertTabCommand
        {
            get
            {
                return insertTabCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for status bar option
        /// </summary>
        public ICommand StatusBarCommand
        {
            get
            {
                return statusBarCommand;
            }
        }

        /// <summary>
        ///Method toe execute edit control loaded event  
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteEditLoaded(object param)
        {
            (param as EditControl).StatusBarSettings.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Method to execute insert space command
        /// </summary>
        /// <param name="param">Specifies the object parmaeter</param>
        private void ExecuteInsertSpaceCommand(object param)
        {
            TabBehavior = TabKeyBehavior.VS;
            IsChecked = false;
            (param as MenuItem).IsChecked = true;
        }

        /// <summary>
        /// Method to execute single line command
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteSingleLineCommand(object param)
        {
            LineNumber = false;
            (param as EditControl).StatusBarSettings.Visibility = Visibility.Collapsed;
            if (SingleLineChecked == true)
            {
                (param as EditControl).StatusBarSettings.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Method to execute insert tab command
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteInsertTabCommand(object param)
        {
            TabBehavior = TabKeyBehavior.Default;
            (param as MenuItem).IsChecked = false;
            IsChecked = true;
        }

        /// <summary>
        /// Method to execute status bar command
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteStatusBarCommand(object param)
        {
            if (StatusBarChecked)
            {
                (param as EditControl).StatusBarSettings.Visibility = Visibility.Visible;
            }
            else
            {
                (param as EditControl).StatusBarSettings.Visibility = Visibility.Collapsed;
            }
        }
    }
}
