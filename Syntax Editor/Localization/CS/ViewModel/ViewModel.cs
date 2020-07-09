#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using SyntaxHighlight;
using System;
using System.Windows;
using System.Windows.Input;
namespace Localization
{
    /// <summary>
    /// Represents the view model class for edit control
    /// </summary>
    public class ViewModel:NotificationObject
    {
        /// <summary>
        /// Maintains the command for exit option
        /// </summary>
        private ICommand exitCommand;
        
        /// <summary>
        /// Maintains the document source of the edit control
        /// </summary>
        private string documentSource;

        /// <summary>
        /// Maintains the language of the edit control
        /// </summary>
        private Languages language;

        /// <summary>
        /// Maintains the flow direction of the window
        /// </summary>
        private FlowDirection direction;
        
        /// <summary>
        /// Maintains the command for edit control load
        /// </summary>
        private ICommand editControlLoaded;

        /// <summary>
        /// Initializes the instance of <see cref="ViewModel"/>class
        /// </summary>
        public ViewModel()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");
            Direction = FlowDirection.RightToLeft;
            editControlLoaded = new DelegateCommand<object>(ExecuteWindowLoaded);
            exitCommand = new DelegateCommand<object>(ExecuteExitCommand);
            Language = Languages.XML;
#if NETCORE
            DocumentSource = "../../../Products.xml";
#else
            DocumentSource = "../../Products.xml";
#endif         
        }

        /// <summary>
        /// Gets or sets the flow direction for the window
        /// </summary>
        public FlowDirection Direction
        {
            get
            {
                return direction;
            }
            set
            {
                direction = value;
                RaisePropertyChanged("FlowDirection");
            }
        }

        /// <summary>
        /// Gets or sets the language of the edit control
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
        /// Gets or sets the command for exit option
        /// </summary>
        public ICommand ExitCommand
        {
            get 
            {
                return exitCommand; 
            }
        }

        /// <summary>
        /// Gets or sets the command for edit control loaded
        /// </summary>
        public ICommand EditControlLoaded
        {
            get
            {
                return editControlLoaded;
            }
        }

        /// <summary>
        /// Method to execute window loaded
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteWindowLoaded(object param)
        {
            (param as EditControl).FindOptions.StatusMessage = "جاهز";
        }

        /// <summary>
        /// Method to execute exit option
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteExitCommand(object param)
        {
            Application.Current.Shutdown();
        }
    }
}
