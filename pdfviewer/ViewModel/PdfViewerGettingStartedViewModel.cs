#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Resources;

namespace syncfusion.pdfviewerdemos.wpf
{
    /// <summary>
    /// Represents the view model class
    /// </summary>
    public class PdfViewerGettingStartedViewModel : NotificationObject
    {
        #region Fields
        private List<string> m_documentCollection;
        private string m_selectedDocument;
        public Stream m_documentStream;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the documnets.
        /// </summary>

        public List<string> DocumentCollection
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
        /// Gets or sets the selected PdfViewerGettingStartedModel.
        /// </summary>
        public string SelectedDocument
        {
            get
            {
                return m_selectedDocument;
            }
            set
            {
                m_selectedDocument = value;
                if (value != null)
                    DocumentStream = GetFileStream(value);
            }
        }

        /// <summary>
        /// Gets or sets the documnet path.
        /// </summary>
        public Stream DocumentStream
        {
            get
            {
                return m_documentStream;
            }
            set
            {
                m_documentStream = value;
                RaisePropertyChanged("DocumentStream");
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfViewerGettingStartedViewModel"/> class.
        /// </summary>
        public PdfViewerGettingStartedViewModel()
        {
            DocumentCollection = new List<string>();
            DocumentCollection.Add("HTTP Succinctly.pdf");
            DocumentCollection.Add("Invoice.pdf");
            DocumentCollection.Add("SyncfusionBrochure.pdf");
            DocumentCollection.Add("EmpDetails.pdf");
            DocumentCollection.Add("MultiColumnReports.pdf");
        }

        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfviewerdemos.wpf;component/Assets/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }
    }
}
