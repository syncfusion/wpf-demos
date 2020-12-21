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
using System.Drawing;
using Syncfusion.Pdf;
using System.IO;
using Syncfusion.Pdf.Graphics;
using System.Diagnostics;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using System.Windows.Resources;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PDFCompressionLevel : DemoControl
    {
        # region Fields
        PdfPage page;
        # endregion

        # region Constructor
        public PDFCompressionLevel()
        {
		   
            InitializeComponent();
            this.compComBox.SelectedIndex = 5;
            this.imgComBox.SelectedIndex = 2;
        }
        #endregion
        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        # endregion
        # region Events
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.textBox1.Text = string.Empty;
            int quality = GetTargetQuality(this.imgComBox.Text);

            PdfDocument document = new PdfDocument();
            document.PageSettings.Margins.All = 0;
            document.Compression = (PdfCompressionLevel)Enum.Parse(typeof(PdfCompressionLevel), this.compComBox.Text, true);

            # region Text and Image content

            // Add a new page to the document.
            page = document.Pages.Add();

            // Get page size
            SizeF size = page.GetClientSize();

            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Layout = PdfLayoutType.Paginate;

            PdfBitmap image = PdfImage.FromStream(GetFileStream("page1.png")) as PdfBitmap;
            image.Quality = quality;
            page.Graphics.DrawImage(image, PointF.Empty, new SizeF(size.Width, image.PhysicalDimension.Height));

            float yPos = image.PhysicalDimension.Height + 100;
            float xPos = size.Width / 4;

            PdfFont headerFont = new PdfTrueTypeFont(new Font("Arial", 18.16f), true);
            PdfFont bodyFont = new PdfTrueTypeFont(new Font("Arial", 10f), true);
            PdfTextElement elem = new PdfTextElement("Essential Studio Enterprise Edition");
            elem.Font = headerFont;
            PdfLayoutResult result = elem.Draw(page, new PointF(xPos, yPos), size.Width / 2, format);
            yPos = result.Bounds.Bottom + 10;

            elem = new PdfTextElement("If you need it all, and want to do it all, then Essential Studio Enterprise Edition is all you could want. This comprehensive suite of components and controls is comprised of all the user interface, business intelligence, and reporting tools and libraries that we offer. It’s the one package you need to develop across every platform—WinRT, Mobile MVC, ASP.NET, ASP.NET MVC, WPF, Silverlight, Windows Phone, and Windows Forms.");
            elem.Font = bodyFont;
            elem.Brush = PdfBrushes.Gray;
            elem.StringFormat = new PdfStringFormat();
            elem.StringFormat.LineSpacing = 5;
            result = elem.Draw(page, new PointF(xPos, yPos), size.Width / 2, format);
            yPos = result.Bounds.Bottom + 25;

            elem = new PdfTextElement("Essential Studio for ASP.NET");
            elem.Font = headerFont;
            result = elem.Draw(page, new PointF(xPos, yPos), size.Width / 2, format);
            yPos = result.Bounds.Bottom + 10;

            elem = new PdfTextElement("Essential Studio for ASP.NET contains 66 unique controls, everything you need to build line-of-business web applications—including grids, charts, gauges, menus, calendars, editors, and much more. It also comes with high-performance libraries that enable your applications to read and write Excel, Word, and PDF documents.");
            elem.Font = bodyFont;
            elem.Brush = PdfBrushes.Gray;
            elem.StringFormat = new PdfStringFormat();
            elem.StringFormat.LineSpacing = 5;
            result = elem.Draw(page, new PointF(xPos, yPos), size.Width / 2, format);
            yPos = result.Bounds.Bottom + 25;

            elem = new PdfTextElement("Essential Studio for ASP.NET MVC");
            elem.Font = headerFont;
            result = elem.Draw(page, new PointF(xPos, yPos), size.Width / 2, format);
            yPos = result.Bounds.Bottom + 10;

            elem = new PdfTextElement("Our very first natively written MVC control suite contains 50 unique controls essential for assembling enterprise-grade web applications—including grids, charts, gauges, menus, calendars, editors, and much more. It comes with high-performance libraries that enable your applications to read and write Excel, Word, and PDF documents. You will also find several one-of-a-kind MVC controls like OlapClient, PDF Viewer, and Report Viewer.");
            elem.Font = bodyFont;
            elem.Brush = PdfBrushes.Gray;
            elem.StringFormat = new PdfStringFormat();
            elem.StringFormat.LineSpacing = 5;
            result = elem.Draw(page, new PointF(xPos, yPos), size.Width / 2, format);

            page = document.Pages.Add();
            PdfBitmap tiff1 = PdfImage.FromStream(GetFileStream("page2.tif")) as PdfBitmap;
            tiff1.Quality = quality;
            tiff1.Encoding = EncodingType.JBIG2;
            page.Graphics.DrawImage(tiff1, PointF.Empty);

            page = document.Pages.Add();
            PdfBitmap tiff2 = PdfImage.FromStream(GetFileStream("page3.tif")) as PdfBitmap;
            tiff2.Quality = quality;
            tiff2.Encoding = EncodingType.JBIG2;
            page.Graphics.DrawImage(tiff2, PointF.Empty);

            # endregion

            # region Footer
            PdfBitmap fooImage = PdfImage.FromStream(GetFileStream("footer.png")) as PdfBitmap;
            fooImage.Quality = quality;
            PdfPageTemplateElement footer = new PdfPageTemplateElement(page.Graphics.ClientSize.Width, fooImage.PhysicalDimension.Height);
            footer.Graphics.DrawImage(fooImage, new PointF(0, 0));
            document.Template.Bottom = footer;
            # endregion

            document.Save("PDFCompressionLevel.pdf");
            document.Close(true);

            StreamReader reader = new StreamReader("PDFCompressionLevel.pdf");

            this.textBox1.Text += "Original Filesize: 256611 bytes" + Environment.NewLine;
            this.textBox1.Text += "Generated Filesize: " + reader.BaseStream.Length.ToString() + " bytes" + Environment.NewLine;
            this.textBox1.Text += "Done!";

            reader.Close();
            reader.Dispose();

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("PDFCompressionLevel.pdf") { UseShellExecute = true };
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

        # region Helpher methods
        private int GetTargetQuality(string p)
        {
            int quality = 100;

            switch (p)
            {
                case "Minimum":
                    quality = 20;
                    break;

                case "Low":
                    quality = 40;
                    break;

                case "Medium":
                    quality = 60;
                    break;

                case "High":
                    quality = 80;
                    break;

                case "Maximum":
                default:
                    quality = 100;
                    break;
            }

            return quality;
        }

        # endregion
    }
}
