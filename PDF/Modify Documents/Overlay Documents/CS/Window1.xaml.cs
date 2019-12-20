#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using Syncfusion.Windows.Shared;


namespace Overlay_Documents
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        PdfLoadedDocument ldDoc1;
        string filePath;
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
			this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\images\PDF\pdf_button.png");
#else
			this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\images\PDF\pdf_button.png");
#endif
#if NETCORE
            ldDoc1 = new PdfLoadedDocument(@"..\..\..\..\..\..\..\Common\Data\PDF\BorderTemplate.pdf");
#else
            ldDoc1 = new PdfLoadedDocument(@"..\..\..\..\..\..\Common\Data\PDF\BorderTemplate.pdf");
#endif
#if NETCORE
            filePath = @"..\..\..\..\..\..\..\Common\Data\PDF\SourceTemplate.pdf";
#else
            filePath = @"..\..\..\..\..\..\Common\Data\PDF\SourceTemplate.pdf";
#endif
        }
        # endregion

        # region Events
        /// <summary>
        /// Gets the input file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PDF Documents (*.pdf)|*.PDF";

            if (dialog.ShowDialog().Value)
                textBox2.Text = dialog.FileName;
        }

        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //PdfLoadedDocument ldDoc1 = new PdfLoadedDocument(textBox1.Text);
            if (textBox2.Text != string.Empty && filePath != string.Empty)
            {
                if (textBox2.Text.Contains("\\"))
                    filePath = textBox2.Text;
            }
            PdfLoadedDocument ldDoc2 = new PdfLoadedDocument(filePath);
            PdfDocument doc = new PdfDocument();

            for (int i = 0, count = ldDoc2.Pages.Count; i < count; ++i)
            {
                PdfPage page = doc.Pages.Add();
                PdfGraphics g = page.Graphics;

                PdfPageBase lpage = ldDoc2.Pages[i];
                PdfTemplate template = lpage.CreateTemplate();

                g.DrawPdfTemplate(template, PointF.Empty, page.GetClientSize());

                lpage = ldDoc1.Pages[0];
                template = lpage.CreateTemplate();

                g.DrawPdfTemplate(template, PointF.Empty, page.GetClientSize());
            }

            doc.Save("sample.pdf");

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

        # endregion
    }
}
