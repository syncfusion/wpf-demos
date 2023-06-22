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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using System.Windows.Resources;
using System.IO;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ImageInsertion : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public ImageInsertion()
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
        #endregion
        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PdfDocument doc = new PdfDocument();
            doc.ViewerPreferences.PageMode = PdfPageMode.FullScreen;
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Tahoma", 22f, System.Drawing.FontStyle.Bold), false);
            PdfSolidBrush brush = new PdfSolidBrush(System.Drawing.Color.DarkBlue);

            PdfSection section = doc.Sections.Add();
            PdfPage page = section.Pages.Add();
            PdfGraphics g = page.Graphics;

            //Bitmap with Tiff image mask
            PdfImage image = new PdfBitmap(GetFileStream("256.tif"));
            (image as PdfBitmap).Mask = new PdfImageMask(new PdfBitmap(GetFileStream("mask2.bmp")));
            page.Graphics.DrawString("Image mask", font, brush, new PointF(10, 0));
            g.DrawImage(image, 80, 40);

            //Metafile
            PdfMetafile metafile;

            page = section.Pages.Add();
            g = page.Graphics;
            metafile = new PdfMetafile(GetFileStream("metachart.emf"));
            page.Graphics.DrawString("Metafile", font, brush, new PointF(10, 0));
            g.DrawImage(metafile, new PointF(0, 50));

            //Image pagination -jpg
            image = new PdfBitmap(GetFileStream("Autumn Leaves.jpg"));

            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Layout = PdfLayoutType.Paginate;

            PointF location = new PointF(0, 400);
            SizeF size = new SizeF(400, -1);
            RectangleF rect = new RectangleF(location, size);
            page.Graphics.DrawString("Image Pagination", font, brush, new PointF(10, 360));
            image.Draw(page, rect, format);

            //Multiframe Tiff image
            PdfBitmap tiffImage = new PdfBitmap(GetFileStream("Image.tiff"));

            int frameCount = tiffImage.FrameCount;

            for (int i = 0; i < frameCount; i++)
            {
                page = section.Pages.Add();
                section.PageSettings.Margins.All = 0;
                g = page.Graphics;
                tiffImage.ActiveFrame = i;
                g.DrawImage(tiffImage, 0, 0, page.GetClientSize().Width, page.GetClientSize().Height);
            }

            page = section.Pages.Add();
            g = page.Graphics;
            image = new PdfBitmap(GetFileStream("Ani.gif"));
            g.DrawImage(image, 0, 0, page.Graphics.ClientSize.Width, image.Height);
            page.Graphics.DrawString("Gif Image", font, brush, new PointF(10, 0));

            section.Pages[section.Pages.Count - 3].Graphics.DrawString("Multiframe Tiff Image", font, brush, new PointF(10, 10));
            section.PageSettings.Transition.PageDuration = 1;
            section.PageSettings.Transition.Duration = 1;
            section.PageSettings.Transition.Style = PdfTransitionStyle.Fly;

            doc.Save("ImageInsertion.pdf");
			doc.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("ImageInsertion.pdf") { UseShellExecute = true };
                process.Start();
            }
        }
        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfdemos.wpf;component/Assets/PDF/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }
        # endregion
    }
}
