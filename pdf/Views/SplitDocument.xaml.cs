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
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.Shared;


namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SplitDocument : DemoControl
    {
        # region Private Members
        PdfLoadedDocument ldoc = null;
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public SplitDocument()
        {

            InitializeComponent();
            this.comboBoxPage.Items.Add("1");
            ldoc = new PdfLoadedDocument(@"Assets\PDF\Essential_XlsIO.pdf");
            this.textBoxSplit.TextChanged += new TextChangedEventHandler(textBoxSplit_TextChanged);
        }
        #endregion
        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (ldoc != null)
            {
                ldoc.Close(true);
            }
            //Release all resources
            base.Dispose(disposing);
        }
        # endregion
        # region Events
        /// <summary>
        /// Updates the page combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void textBoxSplit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ldoc != null)
            {
                comboBoxPage.Items.Clear();
                for (int i = 1; i <= ldoc.Pages.Count; i++)
                    comboBoxPage.Items.Add(i);
                this.comboBoxPage.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Gets the input file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "PDF Documents (*.pdf)|*.PDF";

            if (file.ShowDialog().Value)
            {
                ldoc = new PdfLoadedDocument(file.FileName);
                textBoxSplit.Text = file.FileName;
            }
        }

        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Create pdf split options
            PdfSplitOptions options = new PdfSplitOptions();

            //Enable split tags
            options.SplitTags = true;

            //Split at the specified page number
            int splitAtPage = (int)comboBoxPage.SelectedValue;
            int[,] ranges;
            bool flag = false;
            if (splitAtPage != ldoc.Pages.Count)
            {
                ranges = new int[,] { { 0, splitAtPage - 1 }, { splitAtPage, ldoc.Pages.Count - 1 } };
                flag = true;
            }
            else
            {
                ranges = new int[,] { { 0, splitAtPage - 1 } };
            }

            ldoc.SplitByRanges("SplitDocument{0}.pdf", ranges, options);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("SplitDocument1.pdf") { UseShellExecute = true };
                process.Start();
                if (flag)
                {
                    System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                    process1.StartInfo = new System.Diagnostics.ProcessStartInfo("SplitDocument2.pdf") { UseShellExecute = true };
                    process1.Start();
                }

            }

        }

        /// <summary>
        /// Validates the page number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Convert.ToInt32(comboBoxPage.SelectedValue) > ldoc.Pages.Count)
                MessageBox.Show("Invalid page number");
        }

        /// <summary>
        /// Window Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxSplit.Text = @"Essential_Studio.pdf";
        }

        # endregion
    }
}
