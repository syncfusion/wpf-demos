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
using Syncfusion.Windows.Shared;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MergeDocuments : DemoControl
    {
        private string filepath1, filepath2;
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public MergeDocuments()
        {
		   
            InitializeComponent();
            filepath1 = @"Assets\PDF\HTTP Succinctly.pdf";
            filepath2 = @"Assets\PDF\HTTP Succinctly.pdf";

        }
        # endregion
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
            if (this.textBox1.Text != String.Empty && textBox2.Text != string.Empty && filepath1 != string.Empty && filepath2 != string.Empty)
            {
                if (this.textBox1.Text.Contains("\\"))
                    filepath1 = this.textBox1.Text;
                if (this.textBox2.Text.Contains("\\"))
                    filepath2 = this.textBox2.Text;
            }

            string[] paths = { filepath1, filepath2 };

            PdfDocument doc;
            if (checkBox1.IsChecked.Value || checkBox2.IsChecked.Value)
            {
                PdfMergeOptions mergeOption = new PdfMergeOptions();
                mergeOption.OptimizeResources = this.checkBox1.IsChecked.Value ? true : false;
                mergeOption.MergeAccessibilityTags = this.checkBox2.IsChecked.Value ? true : false;
                doc = PdfDocument.Merge(paths, mergeOption);
            }
            else
            {
                 doc = PdfDocument.Merge(paths);
            }

            doc.Save("MergeDocuments.pdf");
			doc.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {

                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("MergeDocuments.pdf") { UseShellExecute = true };
                process.Start();
            }

        }

        /// <summary>
        /// Gets the first document to merge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "PDF Documents (*.pdf)|*.PDF";

            if (file.ShowDialog().Value)
                textBox1.Text = file.FileName;
        }

        /// <summary>
        /// Gets the second document to merge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "PDF Documents (*.pdf)|*.PDF";

            if (file.ShowDialog().Value)
                textBox2.Text = file.FileName;
        }
        # endregion
    }
}
