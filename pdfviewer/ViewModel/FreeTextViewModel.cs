#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public class FreeTextViewModel : INotifyPropertyChanged
    {
        private Stream m_documentStream;
        private ICommand annotationConstraintsCommand;
        private ICommand documentLoadedCommand;
        private bool annotationConstraintsParameter = false;

        public event PropertyChangedEventHandler PropertyChanged;

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
            }
        }

        /// <summary>
        /// Gets or sets the value to show or hide annotations
        /// </summary>
        public bool AnnotationConstraintsParameter
        {
            get
            {
                return annotationConstraintsParameter;
            }
            set
            {
                annotationConstraintsParameter = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ShowAnnotationsParameter"));
            }
        }

        /// <summary>
        /// Command to show or hide annotations
        /// </summary>
        public ICommand AnnotationConstraintsCommand
        {
            get
            {
                if (annotationConstraintsCommand == null)
                {
                    annotationConstraintsCommand = new DelegateCommand<PdfViewerControl>(AnnotationConstraints);
                }
                return annotationConstraintsCommand;
            }
        }

        /// <summary>
        /// Command for document loaded
        /// </summary>
        public ICommand DocumentLoadedCommand
        {
            get
            {
                if (documentLoadedCommand == null)
                {
                    documentLoadedCommand = new DelegateCommand<PdfViewerControl>(OnDocumentLoaded);
                }
                return documentLoadedCommand;
            }
        }

        private void OnDocumentLoaded(PdfViewerControl pdfViewerControl)
        {
            Syncfusion.Windows.PdfViewer.AnnotationConstraints constraints = Syncfusion.Windows.PdfViewer.AnnotationConstraints.Selectable;
            if (AnnotationConstraintsParameter)
            {
                constraints = ~Syncfusion.Windows.PdfViewer.AnnotationConstraints.Selectable;
            }

            pdfViewerControl.FreeTextAnnotationSettings.Constraints = constraints;
            pdfViewerControl.HighlightAnnotationSettings.Constraints = constraints;
            pdfViewerControl.UnderlineAnnotationSettings.Constraints = constraints;
            pdfViewerControl.SquigglyAnnotationSettings.Constraints = constraints;
            pdfViewerControl.StrikethroughAnnotationSettings.Constraints = constraints;
            pdfViewerControl.InkAnnotationSettings.Constraints = constraints;
            pdfViewerControl.StampAnnotationSettings.Constraints = constraints;
            pdfViewerControl.RectangleAnnotationSettings.Constraints = constraints;
            pdfViewerControl.CircleAnnotationSettings.Constraints = constraints;
            pdfViewerControl.LineAnnotationSettings.Constraints = constraints;
            pdfViewerControl.ArrowAnnotationSettings.Constraints = constraints;
            pdfViewerControl.PolygonAnnotationSettings.Constraints = constraints;
            pdfViewerControl.PolylineAnnotationSettings.Constraints = constraints;
            pdfViewerControl.StickyNoteAnnotationSettings.Constraints = constraints;
        }

        void AnnotationConstraints(PdfViewerControl pdfViewerControl)
        {
            MemoryStream stream = new MemoryStream();
            pdfViewerControl.LoadedDocument.Save(stream);
            pdfViewerControl.Load(stream);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FreeTextViewModel"/> class.
        /// </summary>
        public FreeTextViewModel()
        {
            m_documentStream = GetFileStream("Free text.pdf");
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfviewerdemos.wpf;component/Assets/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }
    }
}

