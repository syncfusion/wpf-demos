#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
using Syncfusion.Pdf.Graphics;
using Microsoft.Win32;

namespace syncfusion.pdfviewerdemos.wpf
{
    /// <summary>
    /// Interaction logic for EsigningPdfForms.xaml.
    /// </summary>
    public partial class EsigningPdfForms : DemoControl
    {
        private ObservableCollection<PdfField> AnneList = new ObservableCollection<PdfField>();
        private ObservableCollection<PdfField> AndrewList = new ObservableCollection<PdfField>();
        private Employee currentUser;
        private string errors;
        private bool isUser = false;
        /// <summary>
        /// Checks whether there are validation error in the Formfields.
        /// </summary>
        public bool isErrorMessage = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="EsigningPdfForms"/> class.
        /// </summary>
        public EsigningPdfForms()
        {
            InitializeComponent();
            this.DataContext = new EsigningPdfFormsViewModel();
           
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EsigningPdfForms"/> class with a theme.
        /// </summary>
        /// <param name="themename">Theme to be applied.</param>
        public EsigningPdfForms(string themename) : base(themename)
        {
            InitializeComponent();
        }

        private void pdfviewer_DocumentLoaded(object sender, System.EventArgs args)
        {
            pdfviewer.ThumbnailSettings.IsVisible = false;
            pdfviewer.IsBookmarkEnabled = false;
            pdfviewer.EnableLayers = false;
            pdfviewer.PageOrganizerSettings.IsIconVisible = false;
            pdfviewer.EnableRedactionTool = false;
            pdfviewer.FormSettings.IsIconVisible = false;
            buttonAdv.IsEnabled = false;
            UpdateFormField();
        }

        private void ComboBoxAdv_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBoxAdv currentComboBox = sender as ComboBoxAdv;
            if(currentComboBox!=null)
            {
                currentUser = currentComboBox.SelectedItem as Employee;
                isUser = true;
            }
            if(pdfviewer != null)
                UpdateFormField();

            if (isErrorMessage && comboBox.SelectedIndex !=0)
            {
                DisplayMessage();
                comboBox.SelectedIndex = 0;
                errors=string.Empty;
            }
        }

        private void DisplayMessage()
        {
            MessageBox.Show(errors.Substring(0,errors.Length-2)+".", "Missing Field Alert", MessageBoxButton.OK);
        }

        private void UpdateFormField()
        {
            if (pdfviewer.LoadedDocument.Form != null)
            {
                var FormFieldCollections = pdfviewer.LoadedDocument.Form.Fields;

                if (FormFieldCollections.Count > 0)
                {
                    for (int i = 0; i < FormFieldCollections.Count; i++)
                    {
                        if (FormFieldCollections[i].Name == "LandlordName" || FormFieldCollections[i].Name == "LandlordDate" || FormFieldCollections[i].Name == "LandlordSignature")
                        {
                            AnneList.Add(FormFieldCollections[i]);
                        }
                        else
                        {
                            AndrewList.Add(FormFieldCollections[i]);
                        }
                    }
                }

                if (currentUser.Mail == "anne@mycompany.com")
                {
                    if (isUser)
                    {
                        ValidateAndSaveForm();
                        if (!isErrorMessage)
                        {
                            buttonAdv.IsEnabled = true;
                            foreach (var item in AnneList)
                            {
                                if (item is PdfLoadedTextBoxField textFormField)
                                {
                                    textFormField.Visibility = PdfFormFieldVisibility.Visible;
                                    textFormField.ReadOnly = false;
                                }
                                else if (item is PdfLoadedSignatureField signatureFormField)
                                {
                                    signatureFormField.Visibility = PdfFormFieldVisibility.Visible;
                                    signatureFormField.ReadOnly = false;
                                }
                            }
                            foreach (var item in AndrewList)
                            {
                                if (item is PdfLoadedTextBoxField pdfLoadedTextBoxField)
                                {
                                    PdfLoadedTextBoxField textBoxField = item as PdfLoadedTextBoxField;
                                    PdfLoadedTextBoxField textbox = pdfviewer.LoadedDocument.Form.Fields[0] as PdfLoadedTextBoxField;
                                    textBoxField.BackColor = PdfColor.Empty;
                                    textBoxField.ReadOnly = true;
                                }
                                else if (item is PdfLoadedSignatureField pdfLoadedSignatureField)
                                {
                                    PdfLoadedSignatureField signatureField = item as PdfLoadedSignatureField;
                                    signatureField.ReadOnly = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    buttonAdv.IsEnabled = false;
                    foreach (var item in AnneList)
                    {
                        if (item is PdfLoadedTextBoxField textFormField)
                        {
                            if (textFormField.Text == "")
                                textFormField.Visibility = PdfFormFieldVisibility.Hidden;
                            else
                                textFormField.ReadOnly = true;
                        }
                        else if (item is PdfLoadedSignatureField signatureFormField)
                        {
                            if (!(IsSignatureFieldSigned(signatureFormField)) && signatureFormField.Visibility != PdfFormFieldVisibility.Hidden)
                                signatureFormField.Visibility = PdfFormFieldVisibility.Hidden;
                            else
                                signatureFormField.ReadOnly = true;
                        }
                    }
                }
                AnneList.Clear();
                AndrewList.Clear();
            }
        }

        /// <summary>
        /// Validate the for fields and update the error message.
        /// </summary>
        public void ValidateAndSaveForm()
        {

            errors = "Required field(s) that need to be filled: ";
            foreach (PdfField formField in AndrewList)
            {
                if (formField is PdfLoadedTextBoxField textFormField)
                {
                    if (string.IsNullOrEmpty(textFormField.Text))
                    {
                        errors = errors + textFormField.Name + ", ";
                    }
                }

                else if (formField is PdfLoadedSignatureField signatureFormField)
                {
                    if (!(IsSignatureFieldSigned(signatureFormField)))
                    {
                        errors = errors + signatureFormField.Name + ", ";
                    }
                }
            }

            if (errors != "Required field(s) that need to be filled: ")
            {
                isErrorMessage = true;
            }
            else
            {
                isErrorMessage = false;
            }
        }
        /// <summary>
        /// Checks if a signature field has been signed.
        /// </summary>
        /// <param name="signatureField">The signature field to check.</param>
        public bool IsSignatureFieldSigned(PdfLoadedSignatureField signatureField)
        {
            bool isSigned = false;
            if (signatureField.Page != null && signatureField.Page.Annotations.Count > 0)
            {
                foreach (var annotation in signatureField.Page.Annotations)
                {
                    if (annotation is PdfLoadedInkAnnotation)
                    {
                        PdfLoadedInkAnnotation signature = annotation as PdfLoadedInkAnnotation;
                        if (signature.Name != signatureField.Name)
                        {
                            isSigned = false;
                        }
                        else
                        {
                            isSigned = true;
                            break;
                        }
                    }
                    else if (annotation is PdfInkAnnotation)
                    {
                        PdfInkAnnotation signature = annotation as PdfInkAnnotation;
                        if (signature.Name != signatureField.Name)
                        {
                            isSigned = false;
                        }
                        else
                        {
                            isSigned = true;
                            break;
                        }
                    }
                    else
                    {
                        isSigned = false;
                    }
                }
            }
            return isSigned;
        }

        private void button_Click(object sender, EventArgs e)
        {
            bool hasErrors = false;
            PdfLoadedDocument pdfLoadedDocument =pdfviewer.LoadedDocument;
            if (pdfLoadedDocument.Form != null && pdfLoadedDocument.Form.Fields.Count > 0)
            {
                errors = "Required field(s) that need to be filled: ";
                foreach (var field in pdfLoadedDocument.Form.Fields)
                {
                    if (field is PdfLoadedTextBoxField)
                    {
                        PdfLoadedTextBoxField textBoxField = field as PdfLoadedTextBoxField;
                        if (string.IsNullOrEmpty(textBoxField.Text))
                        {
                            errors = errors + textBoxField.Name + ", ";
                            hasErrors=true;
                        }
                    }
                    else if (field is PdfLoadedSignatureField signatureField)
                    {
                        if (!(IsSignatureFieldSigned(signatureField)))
                        {
                            errors = errors + signatureField.Name + ", ";
                            hasErrors = true;
                        }
                    }
                }
                if (hasErrors)
                {
                    DisplayMessage();
                }
            }
            if (!hasErrors)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files|*.pdf";
                string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                saveFileDialog.InitialDirectory = downloadsFolder;
                saveFileDialog.FileName = "eSign_filling.pdf";

                if (saveFileDialog.ShowDialog() == true)
                {
                    var formFields = pdfviewer.LoadedDocument.Form.Fields;
                    foreach (var item in formFields)
                    {
                        if (item is PdfLoadedTextBoxField pdfLoadedTextBoxField)
                        {
                            PdfLoadedTextBoxField textBoxField = item as PdfLoadedTextBoxField;
                            textBoxField.BackColor = PdfColor.Empty;
                            textBoxField.Flatten = true;
                        }
                        else if (item is PdfLoadedSignatureField pdfLoadedSignatureField)
                        {
                            PdfLoadedSignatureField signatureField = item as PdfLoadedSignatureField;
                            signatureField.Flatten = true;
                        }
                    }
                    using (Stream saveStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        pdfviewer.LoadedDocument.Save(saveStream);
                    }
                    pdfviewer.Load(saveFileDialog.FileName);
                    comboBox.IsEnabled = false;
                    isUser = false;
                }
            }
              
        }

        protected override void Dispose(bool disposing)
        {
            pdfviewer.ShowToolbar = true;
            pdfviewer.ThumbnailSettings.IsVisible = true;
            pdfviewer.IsBookmarkEnabled = true;
            pdfviewer.EnableLayers = true;
            pdfviewer.PageOrganizerSettings.IsIconVisible = true;
            pdfviewer.EnableRedactionTool = true;
            pdfviewer.FormSettings.IsIconVisible = true;
            if (this.DataContext is EsigningPdfFormsViewModel)
            {
                (this.DataContext as EsigningPdfFormsViewModel).DocumentStream.Dispose();
                this.DataContext = null;
            }
            base.Dispose(disposing);
        }
    }
}
