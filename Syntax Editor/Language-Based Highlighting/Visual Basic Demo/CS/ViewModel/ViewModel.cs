#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace EditControl_VisalBasic_Demo
{
    /// <summary>
    /// Represents the view model class of edit control
    /// </summary>
    public class ViewModel:NotificationObject
    {
        /// <summary>
        /// Maintains the command for exit menu option
        /// </summary>
        private ICommand exitCommand;

        /// <summary>
        /// Maintains the document source of the edit control
        /// </summary>
        private string documentSource;

        /// <summary>
        /// Maintains the language of the content to be displayed in the edit control
        /// </summary>
        private Languages language;

        /// <summary>
        /// Maintains the font family of the edit control
        /// </summary>
        private FontFamily selectedFont;

        /// <summary>
        /// Initializes the instance of<see cref="ViewModel"/>class
        /// </summary>
        public ViewModel()
        {
            Language = Languages.VisualBasic;

#if NETCORE
            DocumentSource = "../../../Source.vb";
#else
            DocumentSource = "../../Source.vb";
#endif
            SelectedFont = new FontFamily("Verdana");
            exitCommand = new DelegateCommand<object>(ExecuteExitCommand);
        }

        /// <summary>
        /// Gets or sets the font family of the edit control
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
        /// Gets or sets the language of the content to be displayed in the edit control
        /// </summary>
        public Languages Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
                RaisePropertyChanged("Language");
            }
        }

        /// <summary>
        /// Gets or sets the document source of the edit control
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
        /// Gets or sets the command for exit menu option
        /// </summary>
        public ICommand ExitCommand
        {
            get
            {
                return exitCommand;
            }
        }
        
        /// <summary>
        /// Method to execute exit menu option
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteExitCommand(object param)
        {
            Application.Current.Shutdown();
        }
    }
}
