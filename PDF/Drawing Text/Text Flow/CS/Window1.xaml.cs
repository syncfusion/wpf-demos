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


namespace TextFlow
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
#if NETCORE
            string file = @"..\..\..\..\..\..\..\Common\images\PDF\pdf_header.png";
#else
            string file = @"..\..\..\..\..\..\Common\images\PDF\pdf_header.png";
#endif
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
#if NETCORE
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\PDF\pdf_button.png");     
#else
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\PDF\pdf_button.png");     
#endif
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
            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();

            //Set compression level
            doc.Compression = PdfCompressionLevel.None;

            //Add a page to the document.
            PdfPage page = doc.Pages.Add();

            //Read the text from the text file
#if NETCORE
            string path = @"..\..\..\..\..\..\..\Common\Data\PDF\Manual.txt";
#else
            string path = @"..\..\..\..\..\..\Common\Data\PDF\Manual.txt";
#endif
            StreamReader reader = new StreamReader(path, Encoding.ASCII);
            string text = reader.ReadToEnd();
            reader.Close();

            //Set the font
            Font f = new Font("Arial", 12);
            PdfTrueTypeFont font = new PdfTrueTypeFont(f, false);

            //Set the formats for the text
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Justify;
            format.LineAlignment = PdfVerticalAlignment.Top;
            format.ParagraphIndent = 15f;

            //Create a text element 
            PdfTextElement element = new PdfTextElement(text, font);
            element.Brush = new PdfSolidBrush(System.Drawing.Color.Black);
            element.StringFormat = format;
            element.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

            //Set the properties to paginate the text.
            PdfLayoutFormat layoutFormat = new PdfLayoutFormat();
            layoutFormat.Break = PdfLayoutBreakType.FitPage;
            layoutFormat.Layout = PdfLayoutType.Paginate;

            RectangleF bounds = new RectangleF(new PointF(10, 10), new SizeF(page.Graphics.ClientSize.Width - 20, page.Graphics.ClientSize.Height - 10));

            if (checkBoxStamp.IsChecked.Value)
            {
                element.EndPageLayout += new EndPageLayoutEventHandler(EndPageLayout);

                //Draw the text element with the properties and formats set.
                PdfTextLayoutResult result = element.Draw(page, bounds, layoutFormat);
                //Set the font
                PdfFont stampFont = new PdfStandardFont(PdfFontFamily.Helvetica, 60, PdfFontStyle.Bold);
                PdfPageTemplateElement stamp = new PdfPageTemplateElement(new SizeF(500, 500));
                stamp.Background = true;
                stamp.Graphics.SetTransparency(0.25f);
                stamp.Graphics.RotateTransform(-45);
                stamp.Graphics.DrawString("DEMO", stampFont, PdfBrushes.Blue, new PointF(-150, 400), format);
                doc.Template.Stamps.Add(stamp);
            }
            else
            {
                //Raise the events to draw the graphic elements for each page.
                 element.EndPageLayout += new EndPageLayoutEventHandler(EndPageLayout);

                //Draw the text element with the properties and formats set.
                PdfTextLayoutResult result = element.Draw(page, bounds, layoutFormat);
            }

            //Save the document.
            doc.Save("Sample.pdf");

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
#if NETCORE
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.pdf")
                {
                    UseShellExecute = true
                };
                process.Start();
#else
                System.Diagnostics.Process.Start("Sample.pdf");
#endif
                this.Close();
            }
            else
                // Exit
                this.Close();
        }

        /// <summary>
        /// Called to draw the graphic elements for each page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndPageLayout(object sender, EndPageLayoutEventArgs e)
        {
            EndTextPageLayoutEventArgs args = (EndTextPageLayoutEventArgs)e;
            PdfPage page = args.Result.Page;
            PdfPen pen = PdfPens.Black;
            page.Graphics.DrawRectangle(pen, new RectangleF(System.Drawing.Point.Empty, page.Graphics.ClientSize));
        }
        # endregion
    }
}
