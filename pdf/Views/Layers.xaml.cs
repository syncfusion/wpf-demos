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

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Layers : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Layers()
        {
            InitializeComponent();
        }
        # endregion
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
            //Create a new PDF document
            PdfDocument doc = new PdfDocument();
            doc.PageSettings = new PdfPageSettings(new SizeF(350, 300));

            PdfPage page = doc.Pages.Add();

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);

            page.Graphics.DrawString("Layers", font, PdfBrushes.DarkBlue, new PointF(150, 10));

            //Add the first layer
            PdfPageLayer layer = page.Layers.Add("Layer1");

            PdfGraphics graphics = layer.Graphics;
            graphics.TranslateTransform(100, 60);

            //Draw Arc 
            PdfPen pen = new PdfPen(System.Drawing.Color.Red, 50);
            RectangleF rect = new RectangleF(0, 0, 50, 50);
            graphics.DrawArc(pen, rect, 360, 360);

            pen = new PdfPen(System.Drawing.Color.Blue, 30);
            graphics.DrawArc(pen, 0, 0, 50, 50, 360, 360);

            pen = new PdfPen(System.Drawing.Color.Yellow, 20);
            graphics.DrawArc(pen, rect, 360, 360);

            pen = new PdfPen(System.Drawing.Color.Green, 10);
            graphics.DrawArc(pen, 0, 0, 50, 50, 360, 360);

            //Add another layer on the page
            layer = page.Layers.Add("Layer2");

            graphics = layer.Graphics;
            graphics.TranslateTransform(100, 180);
            graphics.SkewTransform(0, 50);

            //Draw another set of elements
            pen = new PdfPen(System.Drawing.Color.Red, 50);
            graphics.DrawArc(pen, rect, 360, 360);
            pen = new PdfPen(System.Drawing.Color.Blue, 30);
            graphics.DrawArc(pen, 0, 0, 50, 50, 360, 360);
            pen = new PdfPen(System.Drawing.Color.Yellow, 20);
            graphics.DrawArc(pen, rect, 360, 360);
            pen = new PdfPen(System.Drawing.Color.Green, 10);
            graphics.DrawArc(pen, 0, 0, 50, 50, 360, 360);

            //Add another layer
            layer = page.Layers.Add("Layer3");
            graphics = layer.Graphics;
            graphics.TranslateTransform(160, 120);

            //Draw another set of elements.
            pen = new PdfPen(System.Drawing.Color.Red, 50);
            graphics.DrawArc(pen, rect, -60, 60);
            pen = new PdfPen(System.Drawing.Color.Blue, 30);
            graphics.DrawArc(pen, 0, 0, 50, 50, -60, 60);
            pen = new PdfPen(System.Drawing.Color.Yellow, 20);
            graphics.DrawArc(pen, rect, -60, 60);
            pen = new PdfPen(System.Drawing.Color.Green, 10);
            graphics.DrawArc(pen, 0, 0, 50, 50, -60, 60);

            //Save to disk
            doc.Save("Layers.pdf");
			doc.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Layers.pdf") { UseShellExecute = true };
                process.Start();
            }
        }
        # endregion
    }
}
