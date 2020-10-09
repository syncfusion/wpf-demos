#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Represents the viewmodel class of edit control
    /// </summary>
    public class SyntaxHighlightingViewModel:NotificationObject
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
        /// Initializes the instance of the <see cref="SyntaxHighlightingViewModel"/> class
        /// </summary>
        public SyntaxHighlightingViewModel()
        {
            SelectedFont = new FontFamily("Verdana");
            IsChecked = false;
            Language = Languages.C;
            DocumentSource = @"Data/syntaxeditor/CSource.c";
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
        /// Method toe execute code samples
        /// </summary>
        /// <param name="param">Speicfies the object paramter</param>
        private void ExecuteSampleCommand(object param)
        {
            string choice = (param as ComboBoxAdv).SelectedItem.ToString();
            if (choice == "C")
            {
                Language = Languages.C;
                DocumentSource = @"Data/syntaxeditor/CSource.c";
            }
            else if (choice == "CSharp")
            {
                Language = Languages.CSharp;
                DocumentSource = @"Data/syntaxeditor/CSharpSource.cs";
            }
            else if (choice == "Delphi")
            {
                Language = Languages.Delphi;
                DocumentSource = @"Data/syntaxeditor/DelphiSource.pas";
            }
            else if (choice == "HTML")
            {
                Language = Languages.HTML;
                DocumentSource = @"Data/syntaxeditor/HTMLSource.html";
            }
            else if (choice == "Java")
            {
                Language = Languages.Java;
                DocumentSource = @"Data/syntaxeditor/JavaSource.java";
            }
            else if (choice == "JScript")
            {
                Language = Languages.JScript;
                DocumentSource = @"Data/syntaxeditor/JScriptSource.js";
            }
            else if (choice == "PowerShell")
            {
                Language = Languages.PowerShell;
                DocumentSource = @"Data/syntaxeditor/PowershellSource.ps1";
            }
            else if (choice == "SQL")
            {
                Language = Languages.SQL;
                DocumentSource = @"Data/syntaxeditor/SQLSource.sql";
            }
            else if (choice == "VBScript")
            {
                Language = Languages.VBScript;
                DocumentSource = @"Data/syntaxeditor/VBScriptSource.vbs";
            }
            else if (choice == "VisualBasic")
            {
                Language = Languages.VisualBasic;
                DocumentSource = @"Data/syntaxeditor/VBSource.vb";
            }
            else if (choice == "XAML")
            {
                Language = Languages.XAML;
                DocumentSource = @"Data/syntaxeditor/XAMLSource.xaml";
            }
            else
            {
                Language = Languages.XML;
                DocumentSource = @"Data/syntaxeditor/XMLSource.xml";
            }      
        }
    }
}
