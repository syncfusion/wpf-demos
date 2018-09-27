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

namespace InsertingImages
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
		    
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string file = @"..\..\..\..\..\..\..\Common\images\PDF\pdf_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\PDF\pdf_button.png");
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
            const string jpgImage = @"..\..\..\..\..\..\..\Common\Images\PDF\Autumn Leaves.jpg";
            const string tifImage = @"..\..\..\..\..\..\..\Common\Images\PDF\256.tif";
            const string bmpImage = @"..\..\..\..\..\..\..\Common\Images\PDF\mask2.bmp";
            const string emfImage = @"..\..\..\..\..\..\..\Common\Images\PDF\metachart.emf";
            const string multiframeImage = @"..\..\..\..\..\..\..\Common\Images\PDF\Image.tiff";
            const string gifImage = @"..\..\..\..\..\..\..\Common\Images\PDF\Ani.gif";

            PdfDocument doc = new PdfDocument();
            doc.ViewerPreferences.PageMode = PdfPageMode.FullScreen;
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Tahoma", 22f, System.Drawing.FontStyle.Bold), false);
            PdfSolidBrush brush = new PdfSolidBrush(System.Drawing.Color.DarkBlue);

            PdfSection section = doc.Sections.Add();
            PdfPage page = section.Pages.Add();
            PdfGraphics g = page.Graphics;

            //Bitmap with Tiff image mask
            PdfImage image = new PdfBitmap(tifImage);
            (image as PdfBitmap).Mask = new PdfImageMask(new PdfBitmap(bmpImage));
            page.Graphics.DrawString("Image mask", font, brush, new PointF(10, 0));
            g.DrawImage(image, 80, 40);

            //Metafile
            PdfMetafile metafile;

            page = section.Pages.Add();
            g = page.Graphics;
            metafile = new PdfMetafile(emfImage);
            page.Graphics.DrawString("Metafile", font, brush, new PointF(10, 0));
            g.DrawImage(metafile, new PointF(0, 50));

            //Image pagination -jpg
            image = new PdfBitmap(jpgImage);

            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Layout = PdfLayoutType.Paginate;

            PointF location = new PointF(0, 400);
            SizeF size = new SizeF(400, -1);
            RectangleF rect = new RectangleF(location, size);
            page.Graphics.DrawString("Image Pagination", font, brush, new PointF(10, 360));
            image.Draw(page, rect, format);

            //Multiframe Tiff image
            PdfBitmap tiffImage = new PdfBitmap(multiframeImage);

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
            image = new PdfBitmap(gifImage);
            g.DrawImage(image, 0, 0, page.Graphics.ClientSize.Width, image.Height);
            page.Graphics.DrawString("Gif Image", font, brush, new PointF(10, 0));

            section.Pages[section.Pages.Count - 3].Graphics.DrawString("Multiframe Tiff Image", font, brush, new PointF(10, 10));
            section.PageSettings.Transition.PageDuration = 1;
            section.PageSettings.Transition.Duration = 1;
            section.PageSettings.Transition.Style = PdfTransitionStyle.Fly;

            doc.Save("Sample.pdf");

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process.Start("Sample.pdf");
                this.Close();
            }
            else
                // Exit
                this.Close();
        }
        # endregion
    }
}