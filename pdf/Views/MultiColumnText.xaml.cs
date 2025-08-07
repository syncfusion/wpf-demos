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
using System.IO;
using System.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using System.Windows.Resources;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MultiColumnText : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public MultiColumnText()
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
        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Create a PDF document
            PdfDocument doc = new PdfDocument();

            doc.PageSettings.Size = new SizeF(870, 732);

            //Add a page
            PdfPage page = doc.Pages.Add();


            PdfSolidBrush brush = new PdfSolidBrush(System.Drawing.Color.Black);
            PdfPen pen = new PdfPen(System.Drawing.Color.Black, 1f);

            //Create font
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 11.5f);

            Font ttf = new Font("Calibri", 14f,System.Drawing.FontStyle.Bold);
            PdfTrueTypeFont heading = new PdfTrueTypeFont(ttf, true);

            font = new PdfStandardFont(PdfFontFamily.Helvetica, 8.5f);

            //Adding Header
            this.AddHeader(doc, "Syncfusion Essential PDF", "MultiColumnText Demo");

            //Adding Footer
            this.AddFooter(doc, "@Copyright 2015");

            #region htmlText

            string longtext = "<font color='#FF0000F'><b>PDF</b></font> stands for <i>\"Portable Document Format\"</i>." +
                " The key word is <i>portable</i>, intended to combine the qualities of <u>authenticity," +
                " reliability and ease of use together into a single packaged concept</u>.<br/><br/>" +
                "Adobe Systems invented PDF technology in the early 1990s to smooth the " +
                "process of moving text and graphics from publishers to printing-presses." +
                " <font color='#FF0000F'><b>PDF</b></font> turned out to be the very essence of paper, brought to life in a computer." +
                " In creating PDF, Adobe had almost unwittingly invented nothing less than a " +
                "bridge between the paper and computer worlds. <br/><br/>To be truly portable, an authentic electronic " +
                "document would have to appear exactly the same way on any computer at any time," +
                " at no cost to the user. It will deliver the exact same results in print or on-screen " +
                "with near-total reliability. ";
            #endregion


            //Rendering HtmlText
            PdfHTMLTextElement richTextElement = new PdfHTMLTextElement(longtext, font, brush);
            richTextElement.TextAlign = TextAlign.Justify;
            richTextElement.IsNativeRenderingEnabled = false;
            // Formatting Layout
            PdfMetafileLayoutFormat format = new PdfMetafileLayoutFormat();
            format.Layout = PdfLayoutType.OnePage;
            //Drawing htmlString
            richTextElement.Draw(page, new RectangleF(0, 15, 250, page.GetClientSize().Height), format);

            ////Drawing Image
            PdfBitmap image = new PdfBitmap(System.Drawing.Image.FromStream(GetFileStream("PDFImage.png")));
            page.Graphics.DrawImage(image, new RectangleF(50, 200, 130, 140));

            #region HtmlText
            longtext = "<font color='#FF0000F'><b>PDF</b></font> is used for representing two-dimensional documents in " +
            "a manner independent of the application software, hardware, and operating system.<sup>[1]</sup>" +
            "<br/><br/>Each PDF file encapsulates a complete description of a fixed-layout 2-D document " +
            "(and, with Acrobat 3-D, embedded 3-D documents) that includes the text, fonts, images, " +
            "and 2-D vector graphics which comprise the documents." +
            " <br/><br/><b>PDF</b> is an open standard that was officially published on July 1, 2008 by the ISO as" +
            "ISO 32000-1:2008.<sub>[2]</sub><br/><br/>" +
            "The PDF combines the technologies such as A sub-set of the PostScript page description programming " +
            "language, a font-embedding/replacement system to allow fonts to travel with the documents and a " +
            "structured storage system to bundle these elements and any associated content into a single file," +
            "with data compression where appropriate.";
            #endregion

            richTextElement = new PdfHTMLTextElement(longtext, font, brush);
            richTextElement.TextAlign = TextAlign.Justify;
            richTextElement.IsNativeRenderingEnabled = false; 
            richTextElement.Draw(page, new RectangleF(0, 375, 250, page.GetClientSize().Height), format);

            #region HtmlText
            ////HtmlString
            string longText = "<font color='#0000F8'>Essential PDF</font> is a <u><i>.NET</i></u> " +
                "library with the capability to produce Adobe PDF files " +
                "It features a full-fledged object model for the easy creation of PDF files from any .NET language. " +
                " It does not use any external libraries and is built from scratch in C#. ";
            #endregion


            ////Rendering HtmlText
            richTextElement = new PdfHTMLTextElement(longText, font, brush);
            richTextElement.TextAlign = TextAlign.Justify;
            richTextElement.IsNativeRenderingEnabled = false; 
            //Drawing htmlString
            richTextElement.Draw(page, new RectangleF(270, 15, 250, page.GetClientSize().Height), format);

            ////Drawing Image
            image = new PdfBitmap(System.Drawing.Image.FromStream(GetFileStream("Essen PDF.gif")));
            page.Graphics.DrawImage(image, new RectangleF(310, 90, 180, 110));

            #region HtmlText
            string htmlText = "Essential PDF supports many features for creating a PDF document including <b>" +
                "drawing text, images, tables and other shapes</b>. " +
                "<br/><br/><font face='TimesRoman'>The generated PDF document can also be protected using <I>" +
                "40 Bit and 128 Bit encryption.</I></font><br/>" +
                "<p>Essential PDF is compatible with Microsoft Visual Studio .NET 2005 and 2008. " +
                "It is also compatible with the Express editions of Visual Studio.NET. <br/><br/>" +
                "The Essential PDF library can be used in any .NET environment including C#, VB.NET and managed C++.</p>" +
                "The PDF file that is created using Essential PDF can be viewed using Adobe Acrobat or the free " +
                "version of <u> Acrobat Viewer from Adobe only.</u>" +
                "<font color='#0000F8'><b><br/><br/>Essential PDF</b></font> It can be used on the server " +
                "side (ASP.NET or any other environment) or with Windows Forms applications. " +
                "The library is 100% managed, being written in C#.<br/><br/> " +
                "<font color='#FF0000F'>PdfDocument</font> is a top-level object in Essential PDF which implies a " +
                "representation of a PDF document. <br/><br/> " +
                   "The document contains a collection of sections that are represented by the <font color='#FF0000F'>PdfSection</font> class, " +
               "which is a logical entity containing a collection of pages and their settings. <br/><br/> Pages (which are represented by <font color='#FF0000F'>PdfPage</font> class) " +
               "are the main destinations of the graphics output.<br/><br/>" +
               "A document can be saved through its <font color='#0000F8'>Save()</font> method. It can be saved either to a file or stream.<br/><br/>" +
               "In order to use the Essential PDF library in your project, add the PdfConfig component found in the toolbox to a project to enable support for PDF. ";

            #endregion

            //Rendering HtmlText
            PdfHTMLTextElement richTextElement1 = new PdfHTMLTextElement(htmlText, font, brush);
            richTextElement1.TextAlign = TextAlign.Justify;
            richTextElement1.IsNativeRenderingEnabled = false; 
            //Drawing htmlString
            richTextElement1.Draw(page, new RectangleF(270, 225, 250, page.GetClientSize().Height), format);


            #region HtmlText
            htmlText = "<p>Every Syncfusion license includes a <i>one-year subscription</i> for unlimited technical support and new releases." +
               "Syncfusion licenses each product on a simple per-developer basis and charges no royalties," +
               "runtimes, or server deployment fees. A licensee can install his/her " +
               "license on multiple personal machines at <u>no extra charge.</u></p>"
              + "<p> At Syncfusion we are very excited about the Microsoft .NET platform.<br/><br/> " +
                "We believe that one of the key benefits of <font color='#0000F8'>.NET</font> is improved programmer productivity. " +
                "Solutions that used to take a very long time with traditional tools can now be " +
                "implemented in a much shorter time period with the <font color='#0000F8'>.NET</font> platform.</p>" +
                "Essential Studio includes seven component libraries in one great package." +
            "Essential Studio is available with full source code. It incorporates a " +
            "unique debugging support system that allows switching between 'Debug' and " +
            "\'Release\' versions of our library with a single click from inside the Visual" +
            "Studio.NET IDE. <br/><br/> <p> To ensure the highest quality of support possible," +
            "we use a state of the art <font color='#0000F8'>Customer Relationship Management software (CRM)</font> " +
            "based Developer Support System called Direct-Trac. Syncfusion Direc-Trac is a " +
            "support system that is uniquely tailored for developer needs. Support incidents " +
            "can be created and tracked to completion 24 hours a day, 7 days a week.</p><br/><br/> " +
            "We have a simple, royalty-free licensing model. Components are licensed to a single user." +
            " We recognize that you often work at home or on your laptop in addition to your work machine." +
            "Therefore, our license permits our products to be installed in more than one location." +
            " At Syncfusion, we stand behind our products 100%. <br/><br/>We have top notch management" +
            ", architects, product managers, sales people, support personnel, and developers " +
            "all working with you, the customer, as their focal point.";
            #endregion


            richTextElement = new PdfHTMLTextElement(htmlText, font, brush);
            richTextElement.TextAlign = TextAlign.Justify;
            richTextElement.IsNativeRenderingEnabled = false; 
            //Drawing htmlString
            richTextElement.Draw(page, new RectangleF(540, 15, 250, page.GetClientSize().Height), format);

            #region HtmlText
            htmlText = "Each licensed control would need to have an entry in the licx file. This would mean that if you were using 20 licensed controls, you would have 20 different entries complete with a full version number in your licx file." +
                "<br/><br/> This posed major problems when upgrading to a newer version since these entries would need to have their version numbers changed. This also made trouble shooting licensing issues very difficult. ";
            #endregion


            richTextElement = new PdfHTMLTextElement(htmlText, font, brush);
            richTextElement.TextAlign = TextAlign.Justify;
	    richTextElement.IsNativeRenderingEnabled = false; 
            //Drawing htmlString
            richTextElement.Draw(page, new RectangleF(540, 465, 250, page.GetClientSize().Height), format);

            doc.Save("MultiColumnText.pdf");
			doc.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("MultiColumntext.pdf") { UseShellExecute = true };
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
            compositeField.Draw(footer.Graphics, new PointF(650, 40));

            //Add the footer template at the bottom
            doc.Template.Bottom = footer;
        }
        # endregion
    }

}
