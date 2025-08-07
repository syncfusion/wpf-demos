#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using syncfusion.demoscommon.wpf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.Shared;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FormFilling : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public FormFilling()
        {
            InitializeComponent();
        }
        #endregion
        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion
        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Load the template document
            PdfLoadedDocument doc = new PdfLoadedDocument(@"Assets\PDF\Form.pdf");

            PdfLoadedForm form = doc.Form;

            // fill the fields from the first page
            (form.Fields["f1-1"] as PdfLoadedTextBoxField).Text = "1";
            (form.Fields["f1-2"] as PdfLoadedTextBoxField).Text = "1";
            (form.Fields["f1-3"] as PdfLoadedTextBoxField).Text = "1";
            (form.Fields["f1-4"] as PdfLoadedTextBoxField).Text = "3";
            (form.Fields["f1-5"] as PdfLoadedTextBoxField).Text = "1";
            (form.Fields["f1-6"] as PdfLoadedTextBoxField).Text = "1";
            (form.Fields["f1-7"] as PdfLoadedTextBoxField).Text = "22";
            (form.Fields["f1-8"] as PdfLoadedTextBoxField).Text = "30";
            (form.Fields["f1-9"] as PdfLoadedTextBoxField).Text = "John";
            (form.Fields["f1-10"] as PdfLoadedTextBoxField).Text = "Doe";
            (form.Fields["f1-11"] as PdfLoadedTextBoxField).Text = "3233 Spring Rd.";
            (form.Fields["f1-12"] as PdfLoadedTextBoxField).Text = "Atlanta, GA 30339";
            (form.Fields["f1-13"] as PdfLoadedTextBoxField).Text = "332";
            (form.Fields["f1-14"] as PdfLoadedTextBoxField).Text = "43";
            (form.Fields["f1-15"] as PdfLoadedTextBoxField).Text = "4556";
            (form.Fields["f1-16"] as PdfLoadedTextBoxField).Text = "3";
            (form.Fields["f1-17"] as PdfLoadedTextBoxField).Text = "2000";
            (form.Fields["f1-18"] as PdfLoadedTextBoxField).Text = "Exempt";
            (form.Fields["f1-19"] as PdfLoadedTextBoxField).Text = "Syncfusion, Inc";
            (form.Fields["f1-20"] as PdfLoadedTextBoxField).Text = "200";
            (form.Fields["f1-21"] as PdfLoadedTextBoxField).Text = "22";
            (form.Fields["f1-22"] as PdfLoadedTextBoxField).Text = "56654";
            (form.Fields["c1-1[0]"] as PdfLoadedCheckBoxField).Items[0].Checked = true;
            (form.Fields["c1-1[1]"] as PdfLoadedCheckBoxField).Items[0].Checked = true;

            // fill the fields from the second page
            (form.Fields["f2-1"] as PdfLoadedTextBoxField).Text = "3200";
            (form.Fields["f2-2"] as PdfLoadedTextBoxField).Text = "4850";
            (form.Fields["f2-3"] as PdfLoadedTextBoxField).Text = "0";
            (form.Fields["f2-4"] as PdfLoadedTextBoxField).Text = "500";
            (form.Fields["f2-5"] as PdfLoadedTextBoxField).Text = "500";
            (form.Fields["f2-6"] as PdfLoadedTextBoxField).Text = "800";
            (form.Fields["f2-7"] as PdfLoadedTextBoxField).Text = "0";
            (form.Fields["f2-8"] as PdfLoadedTextBoxField).Text = "0";
            (form.Fields["f2-9"] as PdfLoadedTextBoxField).Text = "3";
            (form.Fields["f2-10"] as PdfLoadedTextBoxField).Text = "3";
            (form.Fields["f2-11"] as PdfLoadedTextBoxField).Text = "3";
            (form.Fields["f2-12"] as PdfLoadedTextBoxField).Text = "2";
            (form.Fields["f2-13"] as PdfLoadedTextBoxField).Text = "3";
            (form.Fields["f2-14"] as PdfLoadedTextBoxField).Text = "3";
            (form.Fields["f2-15"] as PdfLoadedTextBoxField).Text = "2";
            (form.Fields["f2-16"] as PdfLoadedTextBoxField).Text = "1";
            (form.Fields["f2-17"] as PdfLoadedTextBoxField).Text = "200";
            (form.Fields["f2-18"] as PdfLoadedTextBoxField).Text = "600";
            (form.Fields["f2-19"] as PdfLoadedTextBoxField).Text = "250";

            doc.Save("FormFilling.pdf");
			doc.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("FormFilling.pdf") { UseShellExecute = true };
                process.Start();
            }
        }

        /// <summary>
        /// Opens the template PDF document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\PDF\Form.pdf") { UseShellExecute = true };
            process.Start();
        }
        # endregion
    }
}
