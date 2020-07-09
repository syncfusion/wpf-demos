#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PdfViewer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ExportasImage_2008
{
    public class ViewModel
    {
        #region Private Members
        private PdfDocumentView pdfViewer1;
        ImageSource m_windowIcon;
        ImageSource m_backgroundImage;
        ImageSourceConverter converter = new ImageSourceConverter();
        List<int> m_pageNumbers = new List<int>();
        int m_startPageNumber=0;
        int m_endPageNumber = 0;
        ICommand m_exportCommand;
        #endregion

        public ViewModel()
        {
            pdfViewer1 = new PdfDocumentView();
            pdfViewer1.Load(GetFullTemplatePath("EmpDetails.pdf", false));
            int pageCount = pdfViewer1.PageCount;
            m_pageNumbers.Clear();
            for (int i = 1; i <= pageCount; i++)
            {
                m_pageNumbers.Add(i);
            }
            if(m_pageNumbers.Count>0)
            {
                m_startPageNumber = m_pageNumbers[0];
                m_endPageNumber = m_pageNumbers[m_pageNumbers.Count - 1];
            }
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

        public List<int> PageNumbers
        {
            get
            {
                return m_pageNumbers;
            }
        }

        public int StartPageNumber
        {
            get
            {
                return m_startPageNumber;
            }
            set
            {
                m_startPageNumber = value;
            }
        }

        public int EndPageNumber
        {
            get
            {
                return m_endPageNumber;
            }
            set
            {
                m_endPageNumber = value;
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
                    m_backgroundImage = (ImageSource)converter.ConvertFromString(file);
                }
                return m_backgroundImage;
            }
        }

        public ICommand ExportCommand
        {
            get
            {
                if (m_exportCommand == null)
                {
                    m_exportCommand = new DelegateCommand<Window>(ExportPages);
                }
                return m_exportCommand;
            }
        }

        #region Helper Methods

        void ExportPages(Window window)
        {
            int from = StartPageNumber-1;
            int to = EndPageNumber-1;

            if (from > to)
            {
                MessageBox.Show("The 'From' value cannot be greater than the 'To' value.", "Error");
                return;
            }
            BitmapSource image = null;
            BitmapSource[] images = null;

            if (from == to)
                image = pdfViewer1.ExportAsImage(from);
            else
                images = pdfViewer1.ExportAsImage(from, to);
#if NETCORE
            string output = @"..\..\..\Output\Image";

            System.IO.Directory.CreateDirectory(@"..\..\..\Output\");

#else
            string output = @"..\..\Output\Image";

            System.IO.Directory.CreateDirectory(@"..\..\Output\");
#endif

            BitmapEncoder encoder = null;
            if (image != null)
            {
                encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                using (FileStream stream = new FileStream(output + Guid.NewGuid().ToString() + ".png", FileMode.Create))
                {
                    encoder.Save(stream);
                }
            }
            else
            {
                foreach (BitmapSource img in images)
                {
                    encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(img));
                    using (FileStream stream = new FileStream(output + Guid.NewGuid().ToString() + ".png", FileMode.Create))
                    {
                        encoder.Save(stream);
                    }
                }
            }

            if (image != null || images != null)
            {
                //Message box confirmation to view the created PDF document.
                if (System.Windows.MessageBox.Show("Do you want to view the exported image files?", "Image Exported",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the PDF file using the default Application.[Acrobat Reader]
#if NETCORE
            				System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"..\..\..\Output\")
                            {
                                UseShellExecute = true
                            };
                            process.Start();
#else
                    System.Diagnostics.Process.Start(@"..\..\Output\");
#endif
                    if(window!=null)
                        window.Close();
                }
                else
                    // Exit
                    if (window != null)
                    window.Close();
            }
        }

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
        #endregion
    }
}
