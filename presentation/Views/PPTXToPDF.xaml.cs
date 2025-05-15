#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Diagnostics;
using System.IO;
using Syncfusion.Presentation;
using Syncfusion.Presentation.Drawing;
using Syncfusion.PresentationToPdfConverter;
using Syncfusion.Pdf;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.presentationdemos.wpf
{
    /// <summary>
    /// Interaction logic for PPTXToPDF.xaml
    /// </summary>
    public partial class PPTXToPDF : DemoControl
    {
        public PPTXToPDF()
        {
            InitializeComponent();
            this.txtFile.Text = "Input_Template.pptx";
            this.txtFile.Tag = @"Assets\Presentation\Input_Template.pptx";
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
            openFileDialog1.InitialDirectory = Path.GetFullPath(@"Assets\Presentation\");
            openFileDialog1.FileName = "";
			openFileDialog1.Filter = "PowerPoint Presentations|*.pptx";
            Nullable<bool> result = openFileDialog1.ShowDialog();

            //Get the selected file name and display in a TextBox
            if (result == true)
            {
                this.txtFile.Text = openFileDialog1.SafeFileName;
                this.txtFile.Tag = openFileDialog1.FileName;
            }
        }

        private void btnCreatePdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string outputFileName = Path.GetFileNameWithoutExtension(txtFile.Tag.ToString());
                //Opens the specified presentation
                using (IPresentation presentation = Presentation.Open(txtFile.Tag.ToString()))
                {
                    //To set each slide in a pdf page.
                    PresentationToPdfConverterSettings settings = new PresentationToPdfConverterSettings();
                    settings.ShowHiddenSlides = true;
                    //Enables a flag to preserve form fields by converting shapes with names starting with 'FormField_' into editable text form fields in the PDF.
                    settings.PreserveFormFields = checkBox1.IsChecked.Value;
                    //Instance to create pdf document from presentation
                    using (PdfDocument doc = PresentationToPdfConverter.Convert(presentation, settings))
                    {
                        //Saves the pdf document
                        doc.Save(outputFileName + ".pdf");
                    }
                }
                    
                if (System.Windows.MessageBox.Show("Do you want to view the PDF document?", "Pdf document created",
                        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(outputFileName + ".pdf") { UseShellExecute = true };
                    process.Start();
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("This file could not be converted, please contact Syncfusion Direct-Trac system at http://www.syncfusion.com/support/default.aspx for any queries. ", "OOPS..Sorry!",
                    MessageBoxButton.OKCancel);
            }
        }

       
    }
}
