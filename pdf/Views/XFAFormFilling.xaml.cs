#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
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
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.Shared;
using Syncfusion.Pdf.Interactive;
using System.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Xfa;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class XFAFormFilling : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public XFAFormFilling()
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
        # endregion
        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Load the existing XFA document.
            PdfLoadedXfaDocument ldoc = new PdfLoadedXfaDocument(@"Assets\PDF\xfaTemplate.pdf");

            //Loaded the existing XFA form.
            PdfLoadedXfaForm lform = ldoc.XfaForm;

            //Fill the XFA form fields.
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["title[0]"] as PdfLoadedXfaComboBoxField).SelectedIndex = 0;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["fn[0]"] as PdfLoadedXfaTextBoxField).Text = "Simons";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["ln[0]"] as PdfLoadedXfaTextBoxField).Text = "Bistro";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["dob[0]"] as PdfLoadedXfaDateTimeField).Value = new DateTime(1989, 5, 21);
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["company[0]"] as PdfLoadedXfaTextBoxField).Text = "XYZ Pvt Ltd";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["jt[0]"] as PdfLoadedXfaTextBoxField).Text = "Developer";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["jd[0]"] as PdfLoadedXfaTextBoxField).Text = "Develop and maintain components and applications for the web, desktop and mobile platforms. \nWork with some of the best UI/UX designers in the world to craft Stunning user interfaces. \nRegular appraisals to ensure quick growth if you deliver on the job.";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["st[0]"] as PdfLoadedXfaTextBoxField).Text = "Vinbaeltet 34";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["ad1[0]"] as PdfLoadedXfaTextBoxField).Text = "Kobenhaven";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["city[0]"] as PdfLoadedXfaTextBoxField).Text = "Denmark";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["state[0]"] as PdfLoadedXfaComboBoxField).SelectedIndex = 1;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["zip[0]"] as PdfLoadedXfaNumericField).NumericValue = 24534;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["country[0]"] as PdfLoadedXfaTextBoxField).Text = "US";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["em[0]"] as PdfLoadedXfaTextBoxField).Text = "simonsbistro@outlook.com";
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["phone[0]"] as PdfLoadedXfaNumericField).NumericValue = 8765456789;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["sdn[0]"] as PdfLoadedXfaListBoxField).SelectedItems = new string[] { "Vegan", "Diary Free" };
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["san[0]"] as PdfLoadedXfaListBoxField).SelectedIndex = 0;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["email[0]"] as PdfLoadedXfaCheckBoxField).IsChecked = true;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["phone[1]"] as PdfLoadedXfaCheckBoxField).IsChecked = true;
            (((lform.Fields["subform1[0]"] as PdfLoadedXfaForm).Fields["subform3[0]"] as PdfLoadedXfaForm).Fields["group1[0]"] as PdfLoadedXfaRadioButtonGroup).Fields[1].IsChecked = true;

            if(this.checkBox.IsChecked == true)
            {
                //Flatten the XFA form.
                ldoc.Flatten = true;
            }

            //Save the XFA document.
            ldoc.Save("XFAFormFilling.pdf");

            //Close the XFA document
            ldoc.Close();

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("XFAFormFilling.pdf") { UseShellExecute = true };
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
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\PDF\xfaTemplate.pdf") { UseShellExecute = true };
            process.Start();
        }
        # endregion
    }
}
