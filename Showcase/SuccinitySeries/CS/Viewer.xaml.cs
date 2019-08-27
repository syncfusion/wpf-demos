#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Windows.Shapes;
using Syncfusion.PdfViewer.WPF;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.Shared;

namespace SuccinitySeries
{
    /// <summary>
    /// Interaction logic for Viewer.xaml
    /// </summary>
    public partial class Viewer:Window
    {

        public Viewer()
        {
            InitializeComponent();
            ImageSourceConverter converter = new ImageSourceConverter();
            this.Icon = (ImageSource)converter.ConvertFromString(GetFullTemplatePath("pdf viewer.png", true));
        }
        /// <summary>
        /// Load the Pdf file in pdfviewer control
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        public void LoadPdf(string fileName)
        {
            pdfViewerControl1.Load(fileName);
        }
        # region Helper Methods
        /// <summary>
        /// Gets the full path of the PDF template or image.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="image">True if image</param>
        /// <returns>Path of the file</returns>
        private string GetFullTemplatePath(string fileName, bool image)
        {
#if !NETCORE
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\Common\";
#else
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\Common\";
#endif
            string folder = image ? "Images" : "Data";
            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }

#endregion
    }
}
