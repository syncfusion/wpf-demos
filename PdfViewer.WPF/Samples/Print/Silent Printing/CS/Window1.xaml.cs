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
			string filePath = @"..\..\..\..\..\..\..\Common\";
			string file = System.IO.Path.Combine(filePath, @"images\PDF\pdf_header.png");
            this.image1.Source = (ImageSource)converter.ConvertFromString(file);
            this.Closed += Window1_Closed;
            pdfViewer1 = new PdfDocumentView();
            SkinStorage.SetMetroBrush(this, new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)));
        }
        # endregion

        # region Events
        /// <summary>
        /// Occurs when the window is about to close
        /// </summary>
        private void Window1_Closed(object sender, EventArgs e)
        {
            pdfViewer1.Unload();
        }
        /// <summary>
        /// Prints the select pages.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pdfViewer1.Print();
        }

        /// <summary>
        /// Loads PDF into PdfViewer.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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
            string fullPath = @"..\..\..\..\..\..\..\Common\";
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }
        # endregion
    }
}