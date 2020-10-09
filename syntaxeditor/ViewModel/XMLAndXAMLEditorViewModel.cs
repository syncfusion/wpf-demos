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
using System.Windows.Media;

namespace syncfusion.syntaxeditordemos.wpf
{
    public class XMLAndXAMLEditorViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the document source for XAML
        /// </summary>
        private string documentSource;

        /// <summary>
        /// Maintains the documetn source for XML 
        /// </summary>
        private string xmlSource;
        
        /// <summary>
        /// Maintains the font family of the edit control
        /// </summary>
        private FontFamily selectedFont;

         /// <summary>
        /// Initializes the oncstance of <see cref="XMLAndXAMLEditorViewModel"/>Class
        /// </summary>
        public XMLAndXAMLEditorViewModel()
        {
            DocumentSource = "Data/syntaxeditor/Test.xaml";
            XMLSource = "Data/syntaxeditor/Products.xml";
            SelectedFont = new FontFamily("Verdana");
        }

        /// <summary>
        /// Gets or sets the document source for XML 
        /// </summary>
        public string XMLSource
        {
            get
            {
                return xmlSource;
            }
            set
            {
                xmlSource = value;
                RaisePropertyChanged("XMLSource");
            }
        }

        /// <summary>
        /// Gets or sets the document source for XAML 
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
    }
}


    