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
using System.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf.HtmlToPdf;
using System.Drawing.Imaging;
using Syncfusion.Windows.Shared;


namespace HtmlToPdf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        private OpenFileDialog openFileDialog;

        PdfImage img = new PdfBitmap(@"..\..\..\..\..\..\..\Common\Images\PDF\logo.png");
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
		    
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            this.Height = this.Height + 30;
            string file = @"..\..\..\..\..\..\..\Common\images\PDF\pdf_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
            imglab.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\PDF\label_Image.gif");
            imglab1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\PDF\label_Image.gif");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\PDF\pdf_button.png");
            openFileDialog = new OpenFileDialog();
            for (int i = 0; i < 51; i++)
                this.comboBoxMargin.Items.Add(i);
            this.comboBoxMargin.SelectedIndex = 0;
            this.textBoxUrl.LostFocus += textBoxUrl_LostFocus;
            openFileDialog.Filter = "HTML Files|*.html;*.htm";
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
            if (this.chkPageBr.IsChecked.Value && this.radioBitmap.IsChecked.Value)
            {
                MessageBox.Show("PageBreak option work only with Metafile ImageType. Page-break will not be recognized if we try convert it to Bitmap.\n\nPlease select Metafile ImageType.");
                return;
            }

            PdfDocument document;

            if (this.chkPDFA1.IsChecked.Value)
            {
                //Create a PDF document in PDF_A1B standard
                document = new PdfDocument(PdfConformanceLevel.Pdf_A1B);
            }
            else
            {
                //Create a PDF document
                document = new PdfDocument();
            }

            //Set page margins
            document.PageSettings.SetMargins((float)this.comboBoxMargin.SelectedIndex);

            //Set page orientation
            if (radioPortrait.IsChecked.Value)
                document.PageSettings.Orientation = PdfPageOrientation.Portrait;
            else
                document.PageSettings.Orientation = PdfPageOrientation.Landscape;

            //Set rotation
            document.PageSettings.Rotate = (PdfPageRotateAngle)Enum.Parse(typeof(PdfPageRotateAngle), this.comboBoxRotate.Text);

            PdfPage page = null;
            SizeF pageSize = SizeF.Empty;
            PdfUnitConvertor convertor = new PdfUnitConvertor();
            float width = -1;
            float height = -1;
            AspectRatio dimension = AspectRatio.None;

            if (!chkTag.IsChecked.Value)
            {
                page = document.Pages.Add();

                pageSize = page.GetClientSize();

                //Calculates the height and width of the pdf image
                if (this.radioHeight.IsChecked.Value)
                {
                    dimension = AspectRatio.KeepHeight;
                    height = convertor.ConvertToPixels(page.GetClientSize().Height, PdfGraphicsUnit.Point);
                }
                else
                {
                    dimension = AspectRatio.KeepWidth;
                    width = convertor.ConvertToPixels(page.GetClientSize().Width, PdfGraphicsUnit.Point);
                }
            }
            else
            {
                width = convertor.ConvertToPixels(document.PageSettings.Width, PdfGraphicsUnit.Point);
                height = convertor.ConvertToPixels(document.PageSettings.Height, PdfGraphicsUnit.Point);
            }

            //Adding Header
            if (comboHeader.IsChecked.Value)
                this.AddHeader(document, "Syncfusion Essential PDF", " ");

            //Adding Footer
            if (comboFooter.IsChecked.Value)
                this.AddFooter(document, "@Copyright 2008");

            // Layout format for Metafile.
            PdfMetafileLayoutFormat metafileFormat = new PdfMetafileLayoutFormat();
            metafileFormat.Break = PdfLayoutBreakType.FitPage;
            metafileFormat.Layout = PdfLayoutType.Paginate;
            metafileFormat.SplitTextLines = this.chkTextBreak.IsChecked.Value;
            metafileFormat.SplitImages = this.chkImageBreak.IsChecked.Value;

            // Layout format for Bitmap.
            PdfLayoutFormat bitmapFormat = new PdfLayoutFormat();
            bitmapFormat.Break = PdfLayoutBreakType.FitPage;
            bitmapFormat.Layout = PdfLayoutType.Paginate;


            using (HtmlConverter html = new HtmlConverter())
            {
                // setting Javascript
                html.EnableJavaScript = this.chkJavaScript.IsChecked.Value;
                // Setting Pagebreak
                html.AutoDetectPageBreak = this.chkPageBr.IsChecked.Value;
                // Setting Hyperlinks
                html.EnableHyperlinks = this.chkHyperlinks.IsChecked.Value;

                if (radioMetafile.IsChecked.Value && !chkTag.IsChecked.Value)
                {
                    HtmlToPdfResult result = html.Convert(textBoxUrl.Text, ImageType.Metafile, (int)width, (int)height, dimension);
                    if (result != null)
                    {
                        if (result.RenderedImage == null)
                            return;

                        // Render the image in PDF document
                        result.Render(page, metafileFormat);
                    }
                }
                else if (radioBitmap.IsChecked.Value)
                {
                    using (System.Drawing.Image img = html.ConvertToImage(textBoxUrl.Text, ImageType.Bitmap, (int)width, (int)height, dimension))
                    {
                        PdfImage image = new PdfBitmap(img);

                        if (img.Size.Width > pageSize.Width)
                            image.Draw(page, new RectangleF(0, 0, pageSize.Width, pageSize.Height), bitmapFormat);
                        else
                            image.Draw(page, new RectangleF(0, 0, img.Width, img.Height), bitmapFormat);
                    }
                }
                else if (chkTag.IsChecked.Value)
                {
                    // Convert to Tagged PDF.
                    html.ConvertToTaggedPDF(document, textBoxUrl.Text);
                }
            }
            if (document != null)
            {
                document.Save("Sample.pdf");
                document.Close(true);

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
        }

        /// <summary>
        /// Gets the file input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog().Value)
                textBoxUrl.Text = openFileDialog.FileName;
        }

        private void radioBitmap_Click(object sender, RoutedEventArgs e)
        {
            if (this.radioBitmap.IsChecked.Value)
            {
                this.chkPageBr.IsEnabled = false;
                this.chkPageBr.IsChecked = false;
                this.chkImageBreak.IsEnabled = false;
                this.chkTextBreak.IsEnabled = false;
                this.chkHyperlinks.IsEnabled = false;
                this.chkPDFA1.IsEnabled = false;
                this.chkPDFA1.IsChecked = false;
                this.chkHyperlinks.IsChecked = false;
                this.groupBox3.IsEnabled = false;
                this.chkTag.IsEnabled = false;
            }
        }

        private void radioMetafile_Click(object sender, RoutedEventArgs e)
        {
            if (this.radioMetafile.IsChecked.Value)
            {
                this.chkPageBr.IsEnabled = true;
                this.chkImageBreak.IsEnabled = true;
                this.chkTextBreak.IsEnabled = true;
                this.chkHyperlinks.IsEnabled = true;
                this.chkPDFA1.IsEnabled = true;
                this.chkHyperlinks.IsChecked = true;
                this.groupBox3.IsEnabled = true;
                this.chkTag.IsEnabled = true;
            }
        }
      

        private void chkTag_Checked(object sender, RoutedEventArgs e)
        {
            if (chkTag.IsChecked.Value)
                this.chkHyperlinks.IsEnabled = false;
            else
                this.chkHyperlinks.IsEnabled = true;
        }

        # endregion

        # region Helpher Methods
        /// <summary>
        /// Adds header to the pdf document
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        private void AddHeader(PdfDocument doc, string title, string description)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            Font f = new Font("Helvetica", 24, System.Drawing.FontStyle.Regular);

            //Create page template
            PdfPageTemplateElement header = new PdfPageTemplateElement(rect);
            PdfFont font = new PdfTrueTypeFont(f, true);
            float doubleHeight = font.Height * 2;
            System.Drawing.Color activeColor = System.Drawing.Color.FromArgb(44, 71, 120);
            SizeF imageSize = new SizeF(110f, 35f);
            //Locating the logo on the right corner of the Drawing Surface
            PointF imageLocation = new PointF(doc.Pages[0].GetClientSize().Width - imageSize.Width - 20, 5);

            //Draw the image in the Header.
            header.Graphics.DrawImage(img, imageLocation, imageSize);

            PdfSolidBrush brush = new PdfSolidBrush(activeColor);

            PdfPen pen = new PdfPen(System.Drawing.Color.DarkBlue, 3f);
            f = new Font("Helvetica", 16, System.Drawing.FontStyle.Bold);
            font = new PdfTrueTypeFont(f, true);
            //font = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold);

            //Set formattings for the text
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            //Draw title
            header.Graphics.DrawString(title, font, brush, new RectangleF(0, 0, header.Width, header.Height), format);
            brush = new PdfSolidBrush(System.Drawing.Color.Gray);
            f = new Font("Helvetica", 6, System.Drawing.FontStyle.Bold);
            font = new PdfTrueTypeFont(f, true);

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
        /// Adds footer to the pdf document
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="footerText"></param>
        private void AddFooter(PdfDocument doc, string footerText)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            //Create a page template
            PdfPageTemplateElement footer = new PdfPageTemplateElement(rect);

            Font f = new Font("Helvetica", 8, System.Drawing.FontStyle.Regular);
            PdfFont font = new PdfTrueTypeFont(f, true);

            PdfSolidBrush brush = new PdfSolidBrush(System.Drawing.Color.Gray);

            PdfPen pen = new PdfPen(System.Drawing.Color.DarkBlue, 3f);
            f = new Font("Helvetica", 6, System.Drawing.FontStyle.Bold);
            font = new PdfTrueTypeFont(f, true);

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

        private void textBoxUrl_LostFocus(object sender, RoutedEventArgs e)
        {
            Uri uri = null;
            if (!Uri.TryCreate(textBoxUrl.Text, UriKind.Absolute, out uri) || null == uri)
            {
                MessageBox.Show("Please enter a valid URL","Warning",MessageBoxButton.OK ,MessageBoxImage.Warning);
            }
            else
            {
                if (uri.IsFile)
                {
                    if (!uri.Segments[uri.Segments.Length - 1].Contains(".htm"))
                    {
                        MessageBox.Show("Please select a valid HTML file", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }
        # endregion
    }
}