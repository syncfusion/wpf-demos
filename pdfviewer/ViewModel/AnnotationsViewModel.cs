#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.PdfViewer;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Resources;

namespace syncfusion.pdfviewerdemos.wpf
{
    /// <summary>
    /// Represents the view model class
    /// </summary>
    public class AnnotationsViewModel : INotifyPropertyChanged
    {
        private Stream m_documentStream;
        ICommand m_showAnnotationsCommand;
        ICommand m_documentLoadedCommand;
        bool m_showAnnotationsParameter = true;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextMarkupsViewModel"/> class.
        /// </summary>
        public AnnotationsViewModel()
        {
            m_documentStream = GetFileStream("Annotations.pdf");
        }

        /// <summary>
        /// Gets or sets the value to show or hide annotations
        /// </summary>
        public bool ShowAnnotationsParameter
        {
            get
            {
                return m_showAnnotationsParameter;
            }
            set
            {
                m_showAnnotationsParameter = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ShowAnnotationsParameter"));
            }
        }

        /// <summary>
        /// Gets or sets the document path.
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
            }
        }

        /// <summary>
        /// Command to show or hide annotations
        /// </summary>
        public ICommand ShowAnnotationsCommand
        {
            get
            {
                if (m_showAnnotationsCommand == null)
                {
                    m_showAnnotationsCommand = new DelegateCommand<PdfViewerControl>(ShowAnnotations);
                }
                return m_showAnnotationsCommand;
            }
        }

        /// <summary>
        /// Command for document loaded
        /// </summary>
        public ICommand DocumentLoadedCommand
        {
            get
            {
                if (m_documentLoadedCommand == null)
                {
                    m_documentLoadedCommand = new DelegateCommand<object>(OnDocumentLoaded);
                }
                return m_documentLoadedCommand;
            }
        }

        void OnDocumentLoaded(object sender)
        {
            ShowAnnotationsParameter = true;
        }

        void ShowAnnotations(PdfViewerControl pdfViewerControl)
        {
            PdfLoadedDocument pdfLoadedDocument = pdfViewerControl.LoadedDocument;
            for (int i = 0; i < pdfLoadedDocument.Pages.Count; i++)
            {
                for (int j = 0; j < pdfLoadedDocument.Pages[i].Annotations.Count; j++)
                {
                    string annotationName = pdfLoadedDocument.Pages[i].Annotations[j].Name;
                    if (ShowAnnotationsParameter)
                        pdfViewerControl.ShowAnnotation(annotationName);
                    else
                        pdfViewerControl.HideAnnotation(annotationName);
                }
            }
        }

        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfviewerdemos.wpf;component/Assets/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
