#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Resources;

namespace syncfusion.pdfviewerdemos.wpf
{
    public class ReadOnlyViewModel : INotifyPropertyChanged
    {
        private Stream m_documentStream;
        private ICommand documentLoadedCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyViewModel"/> class.
        /// </summary>
        public ReadOnlyViewModel()
        {
            m_documentStream = GetFileStream("restricted-formfield.pdf");
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
            Syncfusion.Windows.PdfViewer.AnnotationConstraints constraints = ~Syncfusion.Windows.PdfViewer.AnnotationConstraints.Selectable;
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
            Syncfusion.Windows.PdfViewer.DocumentToolbar toolbar = pdfViewerControl.Template.FindName("PART_Toolbar", pdfViewerControl) as Syncfusion.Windows.PdfViewer.DocumentToolbar;
            //Get the instance of the open file button using its template name.
            ToggleButton textSearchButton = (ToggleButton)toolbar.Template.FindName("PART_Annotations", toolbar);
            //Set the visibility of the button to collapsed.
            textSearchButton.Visibility = System.Windows.Visibility.Collapsed;
            Button signatureButton = (Button)toolbar.Template.FindName("PART_ButtonSignature", toolbar);
            //Set the visibility of the button to collapsed.
            signatureButton.Visibility = System.Windows.Visibility.Collapsed;
            ToggleButton selectionTool = (ToggleButton)toolbar.Template.FindName("PART_SelectTool", toolbar);
            //Set the visibility of the button to collapsed.
            selectionTool.Visibility = System.Windows.Visibility.Collapsed;
            System.Windows.Shapes.Rectangle separator = (System.Windows.Shapes.Rectangle)toolbar.Template.FindName("PART_AnnotationToolsSeparator", toolbar);
            //Set the visibility of the button to collapsed.
            separator.Visibility = System.Windows.Visibility.Collapsed;
            pdfViewerControl.PreviewMouseRightButtonUp += PdfViewerControl_PreviewMouseRightButtonUp;
            PdfLoadedDocument loadedDocument = pdfViewerControl.LoadedDocument;
            PdfLoadedForm loadedForm = loadedDocument.Form;
            if (loadedForm != null)
            {
                for (int index = 0; index < loadedForm.Fields.Count; index++)
                {
                    loadedForm.Fields[index].ReadOnly = true;
                }
            }
        }

        private void PdfViewerControl_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
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
