#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using Syncfusion.Pdf.Exporting;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for RemoveImage.xaml
    /// </summary>
    public partial class RemoveImage : DemoControl
    {
        private string filepath;
        # region Constructor
        public RemoveImage()
        {
            InitializeComponent();
            filepath = @"Assets\PDF\RemoveImage.pdf";
        }
        #endregion
        #region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBoxUrl.Text != String.Empty && filepath != string.Empty)
            {
                if (this.textBoxUrl.Text.Contains("\\"))
                    filepath = this.textBoxUrl.Text;

            }
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(filepath);
            PdfImageInfo[] imagesInfo = loadedDocument.Pages[0].ImagesInfo;
            foreach (PdfImageInfo imgInfo in imagesInfo)
            {
                //Removing Image
                loadedDocument.Pages[0].RemoveImage(imgInfo);

            }
            loadedDocument.Save("RemoveImages.pdf");
            loadedDocument.Close(true);;
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
               MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("RemoveImages.pdf") { UseShellExecute = true };
                process.Start();

            }


        }

        /// <summary>
        /// Gets the input file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "PDF Documents (*.pdf)|*.PDF";

            if (file.ShowDialog().Value)
                textBoxUrl.Text = file.FileName;
            filepath = file.FileName;
        }
        #endregion
    }
}
