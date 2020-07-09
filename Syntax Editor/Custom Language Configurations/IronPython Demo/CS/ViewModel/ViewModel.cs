#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace IronPythonDemo
{
    /// <summary>
    /// Represents the view model class for edit control
    /// </summary>
    public class ViewModel:NotificationObject
    {
        /// <summary>
        /// Maitains the command for exit menu option
        /// </summary>
        private ICommand exitCommand;

        /// <summary>
        /// Maintains the document source of the edit control
        /// </summary>
        private string documentSource;

        /// <summary>
        /// Maintains the loaded command for edit control
        /// </summary>
        private ICommand editLoadedCommand;

        /// <summary>
        /// Maintains the language of the edit control
        /// </summary>
        private Languages language;

        /// <summary>
        /// Maintains the font family of the content in edit control
        /// </summary>
        private FontFamily selectedFont;

        /// <summary>
        /// Initializes the instance of <see cref="ViewModel"/>class
        /// </summary>
        public ViewModel()
        {
            
#if NETCORE
            DocumentSource = "../../../Source.py";
#else
           DocumentSource = "../../Source.py";
#endif
            SelectedFont = new FontFamily("Verdana");
            Language = Languages.Custom;
            exitCommand = new DelegateCommand<object>(ExecuteExitCommand);
            editLoadedCommand = new DelegateCommand<object>(ExecuteEditLoaded);
        }
        
        /// <summary>
        /// Gets or sets the loaded command for edit control
        /// </summary>
        public ICommand EditLoadedCommand
        {
            get
            {
                return editLoadedCommand;
            }
        }

        /// <summary>
        /// Gets or sets the font family of the content in edit control
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
        /// Gets or sets the language of the content in edit control
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
            get { return documentSource; }
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
        /// Method to execute edit control loaded
        /// </summary>
        /// <param name="obj">Specifies the object parameter</param>
        private void ExecuteEditLoaded(object obj)
        {
            PythonLanguage customLanguage = new PythonLanguage(obj as EditControl);
            customLanguage.Lexem = Application.Current.MainWindow.Resources["pythonLanguageLexems"] as LexemCollection;
            customLanguage.Formats = Application.Current.MainWindow.Resources["pythonLanguageFormats"] as FormatsCollection;
            (obj as EditControl).CustomLanguage = customLanguage;
        }
  
        /// <summary>
        /// Method to execute exit menu option
        /// </summary>
        /// <param name="obj">Specifies the object parameter</param>
        private void ExecuteExitCommand(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
