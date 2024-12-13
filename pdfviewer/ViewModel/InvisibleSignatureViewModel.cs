#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Pdf.Graphics;
using Syncfusion.Windows.PdfViewer;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Resources;
using System.Drawing;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using Syncfusion.Pdf;
using System.Security.Cryptography.X509Certificates;
using Syncfusion.Pdf.Interactive;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;

namespace syncfusion.pdfviewerdemos.wpf
{
    public class InvisibleSignatureViewModel : INotifyPropertyChanged
    {
        private Stream m_documentStream;
        internal InvisibleSignature invisibleSignature = null;
        private bool isSignatureAdded = false;
        internal int SignaturePageIndex = -1;
        private ICommand documentLoadedCommand;
        private ICommand loadedCommand;
        private ICommand downloadCommand;
        private ICommand completeSigningCommand;
        ToolTip tooltip = new ToolTip();
        private MemoryStream signatureStream;
        private Visibility isSuccessMsgVisible = Visibility.Collapsed;
        private string validationMessage = "";
        private Visibility isInvalidMsgVisible= Visibility.Collapsed;
        private Visibility isErrorMsgVisible = Visibility.Collapsed;
        private bool isCompleteSigning;
        private bool isSaved;
        private Visibility isValidationMsgVisibility = Visibility.Collapsed;
        internal string keyFileName = "localhost.pfx";
        private PdfViewerControl pdfViewer;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the path for the document.
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
        /// Gets or sets the path for the validated document.
        /// </summary>
        public MemoryStream SignatureStream
        {
            get
            {
                return signatureStream;
            }
            set
            {
                signatureStream = value;
            }
        }

        /// <summary>
        /// Bool property for signature added case
        /// </summary>
        internal bool IsSignatureAdded
        {
            get
            {
                return isSignatureAdded;
            }
            set
            {
                isSignatureAdded = value;
               
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


        /// <summary>
        /// Command for  page loaded
        /// </summary>
        public ICommand LoadedCommand
        {
            get
            {
                if (loadedCommand == null)
                {
                    loadedCommand = new DelegateCommand<PdfViewerControl>(OnLoaded);
                }
                return loadedCommand;
            }
        }

        /// <summary>
        /// Command for Download
        /// </summary>
        public ICommand DownloadCommand
        {
            get
            {
                if (downloadCommand == null)
                {
                    downloadCommand = new DelegateCommand<ICommand>(OnDownload);
                }
                return downloadCommand;
            }
        }

        /// <summary>
        /// Command for CompleteSigning
        /// </summary>

        public ICommand CompleteSigningCommand
        {
            get
            {
                if (completeSigningCommand == null)
                {
                    completeSigningCommand = new DelegateCommand<ICommand>(OnCompleteSigning);
                }
                return completeSigningCommand;
            }
        }

        /// <summary>
        /// Gets or sets the validation message
        /// </summary>
        public string ValidationMessage
        {
            get => validationMessage;
            set
            {
                validationMessage = value;
                OnPropertyChanged("ValidationMessage");
            }
        }

        /// <summary>
        /// Gets or sets the visibility for successfully signed document
        /// </summary>
        public Visibility IsSuccessMsgVisible
        {
            get => isSuccessMsgVisible;
            set
            {
                isSuccessMsgVisible = value;
                OnPropertyChanged("IsSuccessMsgVisible");
            }
        }

        /// <summary>
        /// Gets or sets the visibility for invalid document
        /// </summary>
        public Visibility IsInvalidMsgVisible
        {
            get => isInvalidMsgVisible;
            set
            {
                isInvalidMsgVisible = value;
                OnPropertyChanged("IsInvalidMsgVisible");
            }
        }

        /// <summary>
        /// Gets or sets the visibility for error document
        /// </summary>
        public Visibility IsErrorMsgVisible
        {
            get => isErrorMsgVisible;
            set
            {
                isErrorMsgVisible = value;
                OnPropertyChanged("IsErrorMsgVisible");
            }
        }

        /// <summary>
        /// Gets or sets to enable the complete signing button 
        /// </summary>
        public bool IsCompleteSigning
        {
            get => isCompleteSigning;
            set
            {
                isCompleteSigning = value;
                OnPropertyChanged("IsCompleteSigning");
            }
        }


        /// <summary>
        /// Gets or Sets to enable the Save button 
        /// </summary>
        public bool IsSaved
        {
            get => isSaved;
            set
            {
                isSaved = value;
                OnPropertyChanged("IsSaved");
            }
        }

        /// <summary>
        /// Gets or Sets the visibility for document status
        /// </summary>
        public Visibility IsValidationMsgVisibility
        {
            get => isValidationMsgVisibility;
            set
            {
                isValidationMsgVisibility = value;
                OnPropertyChanged("IsValidationMsgVisibility");
            }
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="FormFillingViewModel"/> class.
        /// </summary>
        public InvisibleSignatureViewModel()
        {
            m_documentStream = GetFileStream("InvisibleDigitalSignature.pdf");

        }

        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfviewerdemos.wpf;component/Assets/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }

        private void OnCompleteSigning(ICommand command)
        {
            MemoryStream stream = new MemoryStream();
            pdfViewer.LoadedDocument.Save(stream);
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream);
            PdfPageBase loadedPage = loadedDocument.Pages[0];
            PdfLoadedForm loadedForm = loadedDocument.Form;
            if (loadedForm != null)
            {
                for (int index = 0; index < loadedForm.Fields.Count; index++)
                {
                    loadedForm.Fields[index].ReadOnly = true;
                }
            }
            Stream pfxFile = GetFileStream("localhost.pfx");
            X509Certificate2Collection collection = new X509Certificate2Collection();
            byte[] data = new byte[pfxFile.Length];
            pfxFile.Read(data, 0, data.Length);
            PdfCertificate pdfCertificate = new PdfCertificate(pfxFile, "password123");
            PdfSignature signature = new PdfSignature(loadedDocument, loadedPage, pdfCertificate, "Signature1");          
            signatureStream = new MemoryStream();
            loadedDocument.Save(signatureStream);
            pdfViewer.Load(signatureStream);
            IsCompleteSigning = false;
            IsSignatureAdded = true;
        }

        private void OnDownload(ICommand command)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.FileName = "SaveDocument.pdf";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllBytes(saveFileDialog.FileName, signatureStream.ToArray());
                IsSaved = false;
            }
        }

        private void OnLoaded(PdfViewerControl control)
        {
            pdfViewer = control;
            pdfViewer.Load(DocumentStream);
            pdfViewer.ShowToolbar = false;
            pdfViewer.IsBookmarkEnabled = false;
            pdfViewer.ThumbnailSettings.IsVisible = false;
            pdfViewer.EnableLayers = false;
            pdfViewer.PageOrganizerSettings.IsIconVisible = false;
            pdfViewer.EnableRedactionTool = false;
            pdfViewer.FormSettings.IsIconVisible = false;
            pdfViewer.InkAnnotationChanged += PdfViewer_InkAnnotationChanged;
        }

        private async void OnDocumentLoaded(PdfViewerControl pdfviewer1)
        {
            if (isSignatureAdded)
            {
                await Task.Delay(2000);
                ValidateSiganture();
                await Task.Delay(4000);
                IsValidationMsgVisibility = Visibility.Collapsed;
                IsSignatureAdded = false;
            }
            else
            {
                IsCompleteSigning = false;
                IsSaved = false;
            }
        }

        private void PdfViewer_InkAnnotationChanged(object sender, Syncfusion.Windows.PdfViewer.InkAnnotationChangedEventArgs e)
        {
            if (e.Action == Syncfusion.Windows.PdfViewer.AnnotationChangedAction.Add)
            {
               IsCompleteSigning = true;
            }
        }

        private void ValidateSiganture()
        {
            //Loads a PDF document.
            if (signatureStream != null)
            {
                PdfLoadedDocument document = new PdfLoadedDocument(signatureStream);
                PdfLoadedForm form = document.Form;
                if (form != null)
                {
                    foreach (PdfLoadedField field in form.Fields)
                    {
                        if (field is PdfLoadedSignatureField)
                        {
                            //Gets the first signature field of the PDF document.
                            PdfLoadedSignatureField signatureField = field as PdfLoadedSignatureField;
                            if (signatureField.IsSigned)
                            {
                                //X509Certificate2Collection to check the signers identity using root certificates.
                                X509Certificate2Collection collection = new X509Certificate2Collection();
                                //Create new X509Certificate2 with the root certificate.
                                Stream pfxFile = GetFileStream("localhost.pfx");
                                byte[] data = new byte[pfxFile.Length];
                                pfxFile.Read(data, 0, data.Length);
                                X509Certificate2 certificate = new X509Certificate2(data, "password123");
                                //Add the certificate to the collection.
                                collection.Add(certificate);
                                //Validate all signatures in loaded PDF document and get the list of validation result.
                                PdfSignatureValidationResult result = signatureField.ValidateSignature(collection);
                                //Checks whether the document is modified or not.
                                if (result.IsDocumentModified)
                                {
                                    ValidationMessage = "The document has been digitally signed, but it has been modified since it was signed and at least one signature is invalid .";
                                    IsValidationMsgVisibility = Visibility.Visible;
                                    IsSuccessMsgVisible = Visibility.Collapsed;
                                    IsInvalidMsgVisible = Visibility.Collapsed;
                                    IsErrorMsgVisible = Visibility.Visible;
                                    IsSaved = false;

                                }
                                else
                                {
                                    //Checks whether the signature is valid or not.
                                    if (result.IsSignatureValid)
                                    {
                                        if (result.SignatureStatus.ToString() == "Unknown")
                                        {
                                            ValidationMessage = "The document has been digitally signed and at least one signature has problem";
                                            IsValidationMsgVisibility = Visibility.Visible;
                                            IsInvalidMsgVisible = Visibility.Visible;
                                            IsSuccessMsgVisible = Visibility.Collapsed;
                                            IsErrorMsgVisible = Visibility.Collapsed;
                                            IsSaved = false;
                                        }
                                        else
                                        {
                                            ValidationMessage = "The document has been digitally signed and all the signatures are valid.";
                                            IsValidationMsgVisibility = Visibility.Visible;
                                            IsSuccessMsgVisible = Visibility.Visible;
                                            IsErrorMsgVisible = Visibility.Collapsed;
                                            IsInvalidMsgVisible = Visibility.Collapsed;
                                            IsSaved = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
