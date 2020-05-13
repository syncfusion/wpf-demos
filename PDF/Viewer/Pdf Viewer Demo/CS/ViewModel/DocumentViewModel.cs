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


namespace GettingStarted_2008
{
    /// <summary>
    /// Represents the view model class
    /// </summary>
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region Fields
        private ObservableCollection<Document> m_documentCollection;
        private string m_filePath;
        private Document m_selectedDocument;
        public string m_docStream;
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
        /// Gets or sets the selected documnet .
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
                if (m_selectedDocument != null)
                    LoadDocument(m_selectedDocument);

            }
        }

        /// <summary>
        /// Gets or sets the documnet path.
        /// </summary>
        public string FilePath
        {
            get
            {
                return m_docStream;
            }
            set
            {
                m_docStream = value;
                RaisePropertyChanged(new PropertyChangedEventArgs("FilePath"));
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel()
        {
            m_filePath = GetFullTemplatePath(string.Empty, false);
            DocumentCollection = new ObservableCollection<Document>() {
                new Document { Name="Windows Store Apps Succinctly.pdf"},
                   new Document { Name="JavaScript Succinctly.pdf"},
                      new Document { Name="HTTP Succinctly.pdf"},
                         new Document { Name="F# Succinctly.pdf"},
                            new Document { Name="ASP.NET MVC 4 Succinctly.pdf"},
                               new Document { Name="GIS Succinctly.pdf"}
            };

        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        internal void LoadDocument(Document pdf)
        {
            string filePath = string.Format("{0}{1}", m_filePath, pdf.Name);
            FilePath = filePath;
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
