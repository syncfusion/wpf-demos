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
using Syncfusion.Windows.PdfViewer;
using Syncfusion.Windows.Shared;


namespace SilentPrinting_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        private PdfDocumentView pdfViewer1;
        # endregion

        # region Constructor
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter converter = new ImageSourceConverter();
            this.Icon = (ImageSource)converter.ConvertFromString(GetFullTemplatePath("pdf viewer.png", true));
#if NETCORE
			string filePath = @"..\..\..\..\..\..\..\Common\";
#else
			string filePath = @"..\..\..\..\..\..\Common\";
#endif
			string file = System.IO.Path.Combine(filePath, @"images\PDF\pdf_header.png");
            this.image1.Source = (ImageSource)converter.ConvertFromString(file);

            pdfViewer1 = new PdfDocumentView();
            SkinStorage.SetMetroBrush(this, new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)));
        }
        # endregion

        # region Events
        /// <summary>
        /// Prints the select pages.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            print.PrintDocument(pdfViewer1.PrintDocument.DocumentPaginator, "Essential PDF Viewer");
        }

        /// <summary>
        /// Loads PDF into PdfViewer.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
#if NETCORE
            pdfViewer1.ReferencePath = @"..\..\..\..\..\..\..\Common\Data\PDF";
#else
            pdfViewer1.ReferencePath = @"..\..\..\..\..\..\Common\Data\PDF";
#endif
            pdfViewer1.Load(GetFullTemplatePath("Barcode.pdf", false));
        }
        #endregion

        # region Helper Methods
        /// <summary>
        /// Gets the full path of the PDF template or image.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="image">True if image</param>
        /// <returns>Path of the file</returns>
        private string GetFullTemplatePath(string fileName, bool image)
        {
#if NETCORE
            string fullPath = @"..\..\..\..\..\..\..\Common\";
#else
            string fullPath = @"..\..\..\..\..\..\Common\";
#endif
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }
        # endregion
    }
}
