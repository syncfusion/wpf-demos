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
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    /// Represents the view model class for edit control
    /// </summary>
    public class CSharpEditorViewModel:NotificationObject
    {
        
        /// <summary>
        /// Maintains the document source of the edit control
        /// </summary>
        private string documentSource;

        /// <summary>
        /// Maintains the language of the content in edit control
        /// </summary>
        private Languages language;

        /// <summary>
        /// Maintains the font family of the edit control
        /// </summary>
        private FontFamily selectedFont;

        /// <summary>
        /// Initializes the instance of <see cref="CSharpEditorViewModel"/>class
        /// </summary>
        public CSharpEditorViewModel()
        {
            Language = Languages.CSharp;
            DocumentSource = "Data/syntaxeditor/CSharpEditorSource.cs";
            SelectedFont = new FontFamily("Verdana");
        }

        /// <summary>
        /// Gets or sets the font family of the edit contro;
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
        /// Gets or sets the Language of teh content in edit control
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
    }
}
