#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
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
using Syncfusion.Pdf.Interactive;
using System.Drawing;
using Syncfusion.Pdf.Graphics;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class NamedDestination : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public NamedDestination()
        {
            InitializeComponent();

        }
        #endregion
        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        # endregion
        # region Fields
        PdfDocument document = new PdfDocument();
        PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);
        PdfBrush brush = new PdfSolidBrush(System.Drawing.Color.Black);
        #endregion

        # region Methods
        public PdfBookmark AddBookmark(PdfPage page, string title, PointF point, bool isnamaedDestination)
        {
            PdfBookmark bookMarks = document.Bookmarks.Add(title);
            PdfGraphics graphics = page.Graphics;
            graphics.DrawString(title, font, brush, new PointF(point.X, point.Y));
            if (isnamaedDestination == true)
            {
                PdfNamedDestination namedDestination = new PdfNamedDestination(title);
                namedDestination.Destination = new PdfDestination(page, new PointF(point.X, point.Y));
                namedDestination.Destination.Mode = PdfDestinationMode.FitToPage;
                document.NamedDestinationCollection.Add(namedDestination);
                bookMarks.NamedDestination = namedDestination;
            }
            else
            {
                bookMarks.Destination = new PdfDestination(page, new PointF(point.X, point.Y));
                bookMarks.Destination.Mode = PdfDestinationMode.FitToPage;
            }

            return bookMarks;
        }

        public PdfBookmark AddSection(PdfBookmark bookmark, PdfPage page, string title, PointF point, bool isnamaedDestination)
        {
            PdfBookmark bookMarks = bookmark.Add(title);
            PdfGraphics graphics = page.Graphics;
            graphics.DrawString(title, font, brush, new PointF(point.X, point.Y));
            if (isnamaedDestination == true)
            {
                PdfNamedDestination namedDestination = new PdfNamedDestination(title);
                namedDestination.Destination = new PdfDestination(page, new PointF(point.X, point.Y));
                namedDestination.Destination.Zoom = 1f;
                document.NamedDestinationCollection.Add(namedDestination);
                bookMarks.NamedDestination = namedDestination;
            }
            else
            {
                bookMarks.Destination = new PdfDestination(page, new PointF(point.X, point.Y));
                bookMarks.Destination.Zoom = 1f;
            }
            return bookMarks;
        }

        public PdfBookmark AddSubSection(PdfBookmark bookmark, PdfPage page, string title, PointF point, bool isnamaedDestination)
        {
            PdfBookmark bookMarks = bookmark.Add(title);
            PdfGraphics graphics = page.Graphics;
            graphics.DrawString(title, font, brush, new PointF(point.X, point.Y));
            if (isnamaedDestination == true)
            {
                PdfNamedDestination namedDestination = new PdfNamedDestination(title);
                namedDestination.Destination = new PdfDestination(page, new PointF(point.X, point.Y));
                namedDestination.Destination.Zoom = 2f;
                document.NamedDestinationCollection.Add(namedDestination);
                bookMarks.NamedDestination = namedDestination;
            }
            else
            {
                bookMarks.Destination = new PdfDestination(page, new PointF(point.X, point.Y));
                bookMarks.Destination.Zoom = 2f;
            }
            return bookMarks;
        }
        #endregion

        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            # region Body
            for (int i = 1; i <= 6; i++)
            {
                PdfPage pages = document.Pages.Add();
                PdfBookmark bookmark = AddBookmark(pages, "Chapter " + i, new PointF(10, 10), true);
                PdfBookmark section1 = AddSection(bookmark, pages, "Section " + i + ".1", new PointF(30, 30), true);
                PdfBookmark section2 = AddSection(bookmark, pages, "Section " + i + ".2", new PointF(30, 400), false);
                PdfBookmark subsection1 = AddSubSection(section1, pages, "Paragraph " + i + ".1.1", new PointF(50, 50), true);
                PdfBookmark subsection2 = AddSubSection(section1, pages, "Paragraph " + i + ".1.2", new PointF(50, 150), true);
                PdfBookmark subsection3 = AddSubSection(section1, pages, "Paragraph " + i + ".1.3", new PointF(50, 250), true);
                PdfBookmark subsection4 = AddSubSection(section2, pages, "Paragraph " + i + ".2.1", new PointF(50, 420), false);
                PdfBookmark subsection5 = AddSubSection(section2, pages, "Paragraph " + i + ".2.2", new PointF(50, 560), false);
                PdfBookmark subsection6 = AddSubSection(section2, pages, "Paragraph " + i + ".2.3", new PointF(50, 680), false);
            }
            #endregion
            document.Save("NamedDestination.pdf");
            document.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("NamedDestination.pdf") { UseShellExecute = true };
                process.Start();
            }

        }
        # endregion

        private void DemoControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
