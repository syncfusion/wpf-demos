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
using System.IO;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using System.Windows.Resources;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class HeadersAndFooters : DemoControl
    {
        # region Private Members
        private bool m_paginateStart = true;
        RectangleF bounds;
        private RectangleF m_columnBounds;
        # endregion

        # region Constructor
        /// <summary>
        /// Window Constructor
        /// </summary>
        public HeadersAndFooters()
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
        /// Creates the PDF file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Create a PDF document
            PdfDocument doc = new PdfDocument();

            //Add a page
            PdfPage page = doc.Pages.Add();
            RectangleF rect = new RectangleF(0, 0, page.GetClientSize().Width, 50);

            PdfSolidBrush brush = new PdfSolidBrush(System.Drawing.Color.Black);
            PdfPen pen = new PdfPen(System.Drawing.Color.Black, 1f);

            //Create font
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 11.5f);

            Font ttf = new Font("Calibri", 14f, System.Drawing.FontStyle.Bold);
            PdfTrueTypeFont heading = new PdfTrueTypeFont(ttf, true);

            //Adding Header
            this.AddHeader(doc, "Syncfusion Essential PDF", "Header and Footer Demo");

            //Adding Footer
            this.AddFooter(doc, "@Copyright 2015");

            //Set formats
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Justify;

            string path = @"Assets\PDF\Essential studio.txt";

            StreamReader reader = new StreamReader(path, Encoding.ASCII);
            string text = reader.ReadToEnd();
            reader.Close();
            RectangleF column = new RectangleF(0, 20, page.Graphics.ClientSize.Width / 2f - 10f, page.Graphics.ClientSize.Height);
            bounds = column;
            m_columnBounds = column;

            //Create text element to control the text flow
            PdfTextElement element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element.StringFormat = format;
            PdfLayoutFormat layoutFormat = new PdfLayoutFormat();
            layoutFormat.Break = PdfLayoutBreakType.FitPage;
            layoutFormat.Layout = PdfLayoutType.Paginate;

            //Get the remaining text that flows beyond the boundary.
            PdfTextLayoutResult result = element.Draw(page, bounds, layoutFormat);
            path = @"Assets\PDF\Essential PDF.txt";
            reader = new StreamReader(path, Encoding.ASCII);
            text = reader.ReadToEnd();
            reader.Close();

            element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element.StringFormat = format;

            // Next paragraph flow from last line of the previous paragraph.
            bounds.Y = result.LastLineBounds.Y + 35f;

            //Raise the event when the text flows to next page.
            element.BeginPageLayout += new BeginPageLayoutEventHandler(BeginPageLayout2);

            //Raise the event when the text reaches the end of the page.
            element.EndPageLayout += new EndPageLayoutEventHandler(EndPageLayout2);
            result.Page.Graphics.DrawString("Essential PDF", heading, PdfBrushes.DarkBlue, new PointF(bounds.X, bounds.Y));

            bounds.Y = result.LastLineBounds.Y + 60f;
            result = element.Draw(result.Page, new RectangleF(bounds.X, bounds.Y, bounds.Width, -1), layoutFormat);
            PdfImage image = new PdfBitmap(GetFileStream("Essen PDF.gif"));
            bounds.Y = result.LastLineBounds.Y + 20f;
            bounds.X = bounds.Width + 20f;

            result.Page.Graphics.DrawImage(image, new PointF(bounds.X, bounds.Y));
            result.Page.Graphics.DrawString("Essential DocIO", heading, PdfBrushes.DarkBlue, new PointF(bounds.X, bounds.Y + image.Height - 20));
            path = @"Assets\PDF\Essential DocIO.txt";
            reader = new StreamReader(path, Encoding.ASCII);
            text = reader.ReadToEnd();
            reader.Close();

            element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element.StringFormat = format;

            bounds.Y = result.LastLineBounds.Y + image.Height + 20;
            bounds.X = bounds.Width + 20f;

            result = element.Draw(result.Page, new RectangleF(bounds.X, bounds.Y, bounds.Width, -1), layoutFormat);
            image = new PdfBitmap(GetFileStream("Essen DocIO.gif"));
            bounds.Y = result.LastLineBounds.Y + 20f;
            bounds.X = bounds.Width + 20f;

            result.Page.Graphics.DrawImage(image, new PointF(bounds.X, bounds.Y));
            path = @"Assets\PDF\Essential XlsIO.txt";
            reader = new StreamReader(path, Encoding.ASCII);
            text = reader.ReadToEnd();
            reader.Close();

            element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element.StringFormat = format;

            result.Page.Graphics.DrawString("Essential XlsIO", heading, PdfBrushes.DarkBlue, new PointF(bounds.X, bounds.Y + image.Height - 20));

            bounds.Y = result.LastLineBounds.Y + image.Height + 20;
            bounds.X = bounds.Width + 20f;
            result = element.Draw(result.Page, new RectangleF(bounds.X, bounds.Y, bounds.Width, -1), layoutFormat);
            image = new PdfBitmap(GetFileStream("Essen XlsIO.gif"));

            bounds.Y = result.LastLineBounds.Y + 20f;
            bounds.X = bounds.Width + 20f;

            result.Page.Graphics.DrawImage(image, new PointF(bounds.X, bounds.Y));
            doc.Save("HeadersAndFooters.pdf");
			doc.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("HeadersAndFooters.pdf") { UseShellExecute = true };
                process.Start();

            }

        }
        
        /// <summary>
        /// Called when the text reaches end of the page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndPageLayout2(object sender, EndPageLayoutEventArgs e)
        {
            EndTextPageLayoutEventArgs args = (EndTextPageLayoutEventArgs)e;
            PdfTextLayoutResult tlr = args.Result;
            RectangleF bounds = tlr.Bounds;
            args.NextPage = tlr.Page;
        }

        /// <summary>
        /// Called when the text flows to next page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeginPageLayout2(object sender, BeginPageLayoutEventArgs e)
        {
            RectangleF bounds = e.Bounds;

            // First column.
            if (!m_paginateStart)
            {
                bounds.X = bounds.Width + 20f;
                bounds.Y = 10f;
            }
            else
            {
                // Second column.
                bounds.X = 0f;
                m_paginateStart = false;
            }

            e.Bounds = bounds;
            m_columnBounds = bounds;
        }
        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfdemos.wpf;component/Assets/PDF/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }
        # endregion

        # region Helpher Methods

        /// <summary>
        /// Addds header to the pdf document.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        private void AddHeader(PdfDocument doc, string title, string description)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            //Create page template
            PdfPageTemplateElement header = new PdfPageTemplateElement(rect);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 24);
            float doubleHeight = font.Height * 2;
            System.Drawing.Color activeColor = System.Drawing.Color.FromArgb(44, 71, 120);
            SizeF imageSize = new SizeF(110f, 35f);
            //Locating the logo on the right corner of the Drawing Surface
            PointF imageLocation = new PointF(doc.Pages[0].GetClientSize().Width - imageSize.Width - 20, 5);
            PdfImage img = new PdfBitmap(GetFileStream("logo.png"));


            //Draw the image in the Header.
            header.Graphics.DrawImage(img, imageLocation, imageSize);

            PdfSolidBrush brush = new PdfSolidBrush(activeColor);

            PdfPen pen = new PdfPen(System.Drawing.Color.DarkBlue, 3f);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold);

            //Set formattings for the text
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            //Draw title
            header.Graphics.DrawString(title, font, brush, new RectangleF(0, 0, header.Width, header.Height), format);
            brush = new PdfSolidBrush(System.Drawing.Color.Gray);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);

            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            //Draw description
            header.Graphics.DrawString(description, font, brush, new RectangleF(0, 0, header.Width, header.Height - 8), format);

            //Draw some lines in the header
            pen = new PdfPen(System.Drawing.Color.DarkBlue, 0.7f);
            header.Graphics.DrawLine(pen, 0, 0, header.Width, 0);
            pen = new PdfPen(System.Drawing.Color.DarkBlue, 2f);
            header.Graphics.DrawLine(pen, 0, 03, header.Width + 3, 03);
            pen = new PdfPen(System.Drawing.Color.DarkBlue, 2f);
            header.Graphics.DrawLine(pen, 0, header.Height - 3, header.Width, header.Height - 3);
            header.Graphics.DrawLine(pen, 0, header.Height, header.Width, header.Height);

            //Add header template at the top.
            doc.Template.Top = header;
        }

        /// <summary>
        /// Adds footer to the pdf document.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="footerText"></param>
        private void AddFooter(PdfDocument doc, string footerText)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            //Create a page template
            PdfPageTemplateElement footer = new PdfPageTemplateElement(rect);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 8);

            PdfSolidBrush brush = new PdfSolidBrush(System.Drawing.Color.Gray);

            PdfPen pen = new PdfPen(System.Drawing.Color.DarkBlue, 3f);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;
            footer.Graphics.DrawString(footerText, font, brush, new RectangleF(0, 18, footer.Width, footer.Height), format);

            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Right;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            //Create page number field
            PdfPageNumberField pageNumber = new PdfPageNumberField(font, brush);

            //Create page count field
            PdfPageCountField count = new PdfPageCountField(font, brush);

            PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Page {0} of {1}", pageNumber, count);
            compositeField.Bounds = footer.Bounds;
            compositeField.Draw(footer.Graphics, new PointF(470, 40));

            //Add the footer template at the bottom
            doc.Template.Bottom = footer;
        }
        # endregion
    }
}
