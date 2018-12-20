#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using System.Drawing;
using Syncfusion.Pdf.Graphics;
using System.IO;
using Syncfusion.Windows.Shared;


namespace RTLSupport
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Constructor
        /// <summary>
        /// Window Constructor
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
            //Create a new PDF document
            PdfDocument doc = new PdfDocument();

            //Add a page
            PdfPage page = doc.Pages.Add();

            //Create font
            Font f = new Font("Arial", 14);
            PdfFont font = new PdfTrueTypeFont(f, true);
            string path = @"..\..\..\..\..\..\..\Common\Data\PDF\arabic.txt";

            //Read the text from text file
            StreamReader reader = new StreamReader(path, Encoding.Unicode);
            string text = reader.ReadToEnd();
            reader.Close();

            //Create a brush
            PdfBrush brush = new PdfSolidBrush(System.Drawing.Color.Black);
            PdfPen pen = new PdfPen(System.Drawing.Color.Black);
            SizeF clipBounds = page.Graphics.ClientSize;
            RectangleF rect = new RectangleF(0, 0, clipBounds.Width / 2f, clipBounds.Height / 3f);

            //Set the property for RTL text
            PdfStringFormat format = new PdfStringFormat();
            format.TextDirection = PdfTextDirection.RightToLeft;
            format.Alignment = PdfTextAlignment.Left;
            format.ParagraphIndent = 35f;

            page.Graphics.DrawString(text, font, brush, rect, format);
            page.Graphics.DrawRectangle(pen, rect);

            //Set the alignment
            format.Alignment = PdfTextAlignment.Center;
            rect.Offset(rect.Width, 0);
            page.Graphics.DrawString(text, font, brush, rect, format);
            page.Graphics.DrawRectangle(pen, rect);

            format.Alignment = PdfTextAlignment.Right;
            rect.Offset(-rect.Width, rect.Height);
            page.Graphics.DrawString(text, font, brush, rect, format);
            page.Graphics.DrawRectangle(pen, rect);

            format.Alignment = PdfTextAlignment.Justify;
            format.LineAlignment = PdfVerticalAlignment.Middle;
            rect.Offset(rect.Width, 0);
            page.Graphics.DrawString(text, font, brush, rect, format);
            page.Graphics.DrawRectangle(pen, rect);

            doc.Save("sample.pdf");

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