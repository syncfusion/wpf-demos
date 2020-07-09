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
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SyntaxHighlighting
{
    /// <summary>
    /// Represents the viewmodel class of edit control
    /// </summary>
    public class ViewModel:NotificationObject
    {
        /// <summary>
        /// Maintains the value indicating whether the menu item is checked
        /// </summary>
        private bool isChecked;

        /// <summary>
        /// Maintains the document source of edit control
        /// </summary>
        private string documentSource;

        /// <summary>
        /// Maintains the type of language used in the document
        /// </summary>
        private Languages language;

        /// <summary>
        /// Maintains the font family of the document in edit control
        /// </summary>
        private FontFamily selectedFont;

        /// <summary>
        /// Maintains the command for code samples
        /// </summary>
        private ICommand sampleCommand;
            
        /// <summary>
        /// Maintains the command for exit menu option
        /// </summary>
        private ICommand exitCommand;

        /// <summary>
        /// Initializes the instance of the <see cref="ViewModel"/> class
        /// </summary>
        public ViewModel()
        {
            SelectedFont = new FontFamily("Verdana");
            IsChecked = false;
            Language = Languages.C;
#if NETCORE
            DocumentSource= @"..//..//..//Resources//CSource.c";
#else
            DocumentSource = @"..//..//Resources//CSource.c";
#endif
            exitCommand = new DelegateCommand<object>(ExecuteExitCommand);
            sampleCommand = new DelegateCommand<object>(ExecuteSampleCommand);
        }

        /// <summary>
        /// Gets or sets the command for code sample 1 in menu items
        /// </summary>
        public ICommand SampleCommand
        {
            get
            {
                return sampleCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for code sample for checked property.
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
        /// Gets or sets the langugae of the content to be displayed in the edit control
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
        /// Gets or sets the font family for the content to  be displayed in the edit control
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
        /// Gets or sets the command for exiting the window
        /// </summary>
        public ICommand ExitCommand
        {
            get
            {
                return exitCommand;
            }
        }

        /// <summary>
        /// Method toe execute code samples
        /// </summary>
        /// <param name="param">Speicfies the object paramter</param>
        private void ExecuteSampleCommand(object param)
        {
            string filePath = "";
#if NETCORE
            filePath = "../../../";
#else
            filePath = "../../";
#endif
            string choice = (param as ComboBoxAdv).SelectedItem.ToString();
            if (choice == "C")
            {
                Language = Languages.C;
                DocumentSource = filePath + "Resources/CSource.c";
            }
            else if (choice == "CSharp")
            {
                Language = Languages.CSharp;
                DocumentSource = filePath + "Resources/CSharpSource.cs";
            }
            else if (choice == "Delphi")
            {
                Language = Languages.Delphi;
                DocumentSource = filePath + "Resources/DelphiSource.pas";
            }
            else if (choice == "HTML")
            {
                Language = Languages.HTML;
                DocumentSource = filePath + "Resources/HTMLSource.html";
            }
            else if (choice == "Java")
            {
                Language = Languages.Java;
                DocumentSource = filePath + "Resources/JavaSource.java";
            }
            else if (choice == "JScript")
            {
                Language = Languages.JScript;
                DocumentSource = filePath + "Resources/JScriptSource.js";
            }
            else if (choice == "PowerShell")
            {
                Language = Languages.PowerShell;
                DocumentSource = filePath + "Resources/PowershellSource.ps1";
            }
            else if (choice == "SQL")
            {
                Language = Languages.SQL;
                DocumentSource = filePath + "Resources/SQLSource.sql";
            }
            else if (choice == "VBScript")
            {
                Language = Languages.VBScript;
                DocumentSource = filePath + "Resources/VBScriptSource.vbs";
            }
            else if (choice == "VisualBasic")
            {
                Language = Languages.VisualBasic;
                DocumentSource = filePath + "Resources/VBSource.vb";
            }
            else if (choice == "XAML")
            {
                Language = Languages.XAML;
                DocumentSource = filePath + "Resources/XAMLSource.xaml";
            }
            else
            {
                Language = Languages.XML;
                DocumentSource = filePath + "Resources/XMLSource.xml";
            }      
        }

        /// <summary>
        /// Method to execute exit menu option
        /// </summary>
        /// <param name="param">Specifes the object parameter</param>
        private void ExecuteExitCommand(object param)
        {
            Application.Current.Shutdown();
        }
    }
}
