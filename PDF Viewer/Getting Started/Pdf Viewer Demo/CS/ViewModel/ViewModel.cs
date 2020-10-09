#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Media;

namespace GettingStarted_2008
{
    /// <summary>
    /// Represents the view model class
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        #region Fields
        private ObservableCollection<Document> m_documentCollection;
        private Document m_selectedDocument;
        public string m_filePath;
        private ImageSource m_windowIcon;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the documnets.
        /// </summary>
        public ObservableCollection<Document> DocumentCollection
        {
            get
            {
                return m_documentCollection;
            }
            set
            {
                m_documentCollection = value;
            }
        }

        /// <summary>
        /// Gets or sets the selected document.
        /// </summary>
        public Document SelectedDocument
        {
            get
            {
                return m_selectedDocument;
            }
            set
            {
                m_selectedDocument = value;
                if (value != null)
                    FilePath = GetFullTemplatePath(value.Name, false);
            }
        }

        /// <summary>
        /// Gets or sets the documnet path.
        /// </summary>
        public string FilePath
        {
            get
            {
                return m_filePath;
            }
            set
            {
                m_filePath = value;
                RaisePropertyChanged(new PropertyChangedEventArgs("FilePath"));
            }
        }

        /// <summary>
        /// Gets the window's icon.
        /// </summary>
        public ImageSource WindowIcon
        {
            get
            {
                return m_windowIcon;
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            DocumentCollection = new ObservableCollection<Document>() {
                new Document { Name="Windows Store Apps Succinctly.pdf"},
                   new Document { Name="JavaScript Succinctly.pdf"},
                      new Document { Name="HTTP Succinctly.pdf"},
                         new Document { Name="F# Succinctly.pdf"},
                            new Document { Name="ASP.NET MVC 4 Succinctly.pdf"},
                               new Document { Name="GIS Succinctly.pdf"}
            };
            ImageSourceConverter converter = new ImageSourceConverter();
            m_windowIcon = (ImageSource)converter.ConvertFromString(GetFullTemplatePath("pdf viewer.png", true));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private string GetFullTemplatePath(string fileName, bool image)
        {
#if NETCORE
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\..\Common\";
#else
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\Common\";
#endif
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);

        }
    }
}
