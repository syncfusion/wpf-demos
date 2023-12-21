#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.PdfViewer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace syncfusion.pdfviewerdemos.wpf
{
    public class ExportAsImageViewModel
    {
        #region Private Members
        private PdfDocumentView pdfViewer;
        List<int> m_pageNumbers = new List<int>();
        int m_startPageNumber = 0;
        int m_endPageNumber = 0;
        ICommand m_exportCommand;
        #endregion

        public ExportAsImageViewModel()
        {
            pdfViewer = new PdfDocumentView();
            Uri uriResource = new Uri("/syncfusion.pdfviewerdemos.wpf;component/Assets/EmpDetails.pdf", UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            pdfViewer.Load(streamResourceInfo.Stream);
            int pageCount = pdfViewer.PageCount;
            m_pageNumbers.Clear();
            for (int i = 1; i <= pageCount; i++)
            {
                m_pageNumbers.Add(i);
            }
            if (m_pageNumbers.Count > 0)
            {
                m_startPageNumber = m_pageNumbers[0];
                m_endPageNumber = m_pageNumbers[m_pageNumbers.Count - 1];
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
            int from = StartPageNumber - 1;
            int to = EndPageNumber - 1;

            if (from > to)
            {
                MessageBox.Show("The 'From' value cannot be greater than the 'To' value.", "Error");
                return;
            }
            BitmapSource image = null;
            BitmapSource[] images = null;

            if (from == to)
                image = pdfViewer.ExportAsImage(from);
            else
                images = pdfViewer.ExportAsImage(from, to);
#if NET50
            string output = @"ExportasImage\";

            System.IO.Directory.CreateDirectory(@"ExportasImage\");

#else
            string output = @"ExportasImage\";

            System.IO.Directory.CreateDirectory(@"ExportasImage\");
#endif

            BitmapEncoder encoder = null;
            if (image != null)
            {
                encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                using(FileStream stream = new FileStream(output + Guid.NewGuid().ToString() + ".png", FileMode.Create))
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
                    using(FileStream stream = new FileStream(output + Guid.NewGuid().ToString() + ".png", FileMode.Create))
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
#if NET50
            				System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"ExportasImage\")
                            {
                                UseShellExecute = true
                            };
                            process.Start();
#else
                    System.Diagnostics.Process.Start(@"ExportasImage\");
#endif
                    if (window != null)
                        window.Close();
                }
                else
                    // Exit
                    if (window != null)
                    window.Close();
                pdfViewer.Unload(true);
            }
        }
        #endregion
    }
}
