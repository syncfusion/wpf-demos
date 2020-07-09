#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PdfViewer;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SilentPrinting_2008
{
    public class ViewModel
    {
        #region Private Members
        private PdfDocumentView pdfViewer;
        ImageSource m_windowIcon;
        ImageSource m_backgroundImage;
        ImageSourceConverter converter = new ImageSourceConverter();
        ICommand m_printCommand;
        # endregion

        public ViewModel()
        {
            pdfViewer = new PdfDocumentView();
            pdfViewer.Load(GetFullTemplatePath("Barcode.pdf", false));
        }

        public ImageSource WindowIcon
        {
            get
            {
                if (m_windowIcon == null)
                    m_windowIcon = (ImageSource)converter.ConvertFromString(GetFullTemplatePath("pdf viewer.png", true));
                return m_windowIcon;
            }
        }

        public ImageSource BackgroundImage
        {
            get
            {
                if (m_backgroundImage == null)
                {
#if NETCORE
		            string filePath = @"..\..\..\..\..\..\..\Common\";
#else
                    string filePath = @"..\..\..\..\..\..\Common\";
#endif
                    string file = System.IO.Path.Combine(filePath, @"images\PDF\pdf_header.png");
                    m_backgroundImage= (ImageSource)converter.ConvertFromString(file);
                }
                return m_backgroundImage;
            }
        }

        public ICommand PrintCommand
        {
            get
            {
                if (m_printCommand == null)
                {
                    m_printCommand = new DelegateCommand<Window>(Print);
                }
                return m_printCommand;
            }
        }

        #region Helper Methods
        /// <summary>
        /// Gets the full path of the PDF template or image.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="image">True if image</param>
        /// <returns>Path of the file</returns>
        private string GetFullTemplatePath(string fileName, bool image)
        {
#if NETCORE
		    string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\..\Common\";
#else
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\Common\";
#endif
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }

        void Print(Window window)
        {
            pdfViewer.Print();
            if (MessageBox.Show("Do you want to close the window?", "Silent Printing",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                if (window != null)
                    window.Close();
            }
        }
        #endregion
    }
}
