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
using Syncfusion.Pdf;
using Syncfusion.Windows.Shared;

namespace MergeDocuments
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        private string filepath1, filepath2;
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
		   
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
#if NETCORE
            string file = @"..\..\..\..\..\..\..\Common\images\PDF\pdf_header.png";
#else
            string file = @"..\..\..\..\..\..\Common\images\PDF\pdf_header.png";
#endif
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
#if NETCORE
			this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\images\PDF\pdf_button.png");
#else
			this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\images\PDF\pdf_button.png");
#endif
#if NETCORE
            filepath1 = @"..\..\..\..\..\..\..\Common\Data\PDF\HTTP Succinctly.pdf";
#else
            filepath1 = @"..\..\..\..\..\..\Common\Data\PDF\HTTP Succinctly.pdf";
#endif
#if NETCORE
            filepath2 = @"..\..\..\..\..\..\..\Common\Data\PDF\HTTP Succinctly.pdf";
#else
            filepath2 = @"..\..\..\..\..\..\Common\Data\PDF\HTTP Succinctly.pdf";
#endif
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
            if (checkBox1.IsChecked.Value)
            {
                PdfMergeOptions mergeOption = new PdfMergeOptions();
                mergeOption.OptimizeResources = true;
                doc = PdfDocument.Merge(paths, mergeOption);
            }
            else
            {
                 doc = PdfDocument.Merge(paths);
            }

            doc.Save("Sample.pdf");

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
#if NETCORE
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.pdf")
                {
                    UseShellExecute = true
                };
                process.Start();
#else
                System.Diagnostics.Process.Start("Sample.pdf");
#endif
                this.Close();
            }
            else
                // Exit
                this.Close();
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
