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
    public partial class DrawingShapes : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public DrawingShapes()
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
            // Create a new PDF document.
            PdfDocument doc = new PdfDocument();
            int i;
            // Create a new page.
            PdfPage page = doc.Pages.Add();
            // Obtain PdfGraphics object.
            PdfGraphics g = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);

            #region Polygon
            PdfPen pen = new PdfPen(System.Drawing.Color.Black);
            pen.Width = 3;
            PointF p1 = new PointF(05, 10);
            PointF p2 = new PointF(05, 10);
            PointF p3 = new PointF(60, 70);
            PointF p4 = new PointF(40, 70);

            PointF[] points = { p1, p2, p3, p4 };

            int pointNum = 16;
            points = new PointF[pointNum];
            double f = 360.0 / pointNum * Math.PI / 180.0;
            const double r = 100;
            PointF center = new PointF(140, 140);

            for (i = 0; i < pointNum; ++i)
            {
                PointF p = new PointF();
                double theta = i * f;

                p.Y = (float)(Math.Sin(theta) * r + center.Y);
                p.X = (float)(Math.Cos(theta) * r + center.X);

                points[i] = p;
            }

            PdfSolidBrush brush = new PdfSolidBrush(System.Drawing.Color.Green);
            pen.Color = System.Drawing.Color.Brown;
            pen.Width = 10;
            pen.LineJoin = PdfLineJoin.Round;
            g.DrawString("Polygon", font, PdfBrushes.DarkBlue, new PointF(50, 0));
            g.DrawPolygon(pen, brush, points);

            #endregion

            #region  Pie

            RectangleF rect = new RectangleF(200, 50, 200, 200);
            brush.Color =System.Drawing.Color.Green;
            pen.Color = System.Drawing.Color.Brown;
            pen.Width = 10;

            rect.Location = new PointF(20, 280);
            pen.LineJoin = PdfLineJoin.Round;
            g.DrawString("Pie shape", font, PdfBrushes.DarkBlue, new PointF(50, 250));
            g.DrawPie(pen, brush, rect, 180, 60);
            g.DrawPie(pen, brush, rect, 360 - 60, 60);
            g.DrawPie(pen, brush, rect, 60, 60);

            #endregion

            #region Arc

            g.DrawString("Arcs", font, PdfBrushes.DarkBlue, new PointF(330, 0));
            pen = new PdfPen(System.Drawing.Color.Black);
            pen.Width = 11;
            pen.LineCap = PdfLineCap.Round;
            pen.Color = System.Drawing.Color.Brown;
            rect = new RectangleF(310, 40, 200, 200);
            g.DrawArc(pen, rect, 0, 90);

            pen.Color = System.Drawing.Color.DarkGreen;
            rect.X -= 10;
            g.DrawArc(pen, rect, 90, 90);

            pen.Color = System.Drawing.Color.Brown;
            rect.Y -= 10;
            g.DrawArc(pen, rect, 180, 90);

            pen.Color = System.Drawing.Color.DarkGreen;
            rect.X += 10;
            g.DrawArc(pen, rect, 270, 90);

            #endregion

            #region Rectangle
            rect = new RectangleF(310, 280, 200, 100);
            brush.Color = System.Drawing.Color.Green;
            pen.Color = System.Drawing.Color.Brown;
            g.DrawString("Simple Rectangle", font, PdfBrushes.DarkBlue, new PointF(310, 255));
            g.DrawRectangle(pen, brush, rect);
            #endregion

            #region ellipse

            // Draw a simple ellipse.
            pen = new PdfPen(System.Drawing.Color.Black);
            rect = new RectangleF(80, 520, 100, 200);
            //page = doc.Pages[0];
            //g = page.Graphics;
            PdfLinearGradientBrush lgBrush = new PdfLinearGradientBrush(rect, System.Drawing.Color.DarkGreen, System.Drawing.Color.White, 90);

            brush = new PdfSolidBrush(System.Drawing.Color.Black);
            brush.Color = System.Drawing.Color.DarkGreen;
            pen.Color = System.Drawing.Color.Brown;
            pen.Width = 10.0f;
            g.DrawString("Ellipse with Gradient", font, PdfBrushes.DarkBlue, new PointF(50, 490));
            g.DrawEllipse(pen, lgBrush, rect);

            rect = new RectangleF(270, 400, 160, 1000);
            g.DrawString("Shape with pagination", font, PdfBrushes.DarkBlue, new PointF(300, 390));
            PdfEllipse ellipse = new PdfEllipse(rect);
            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Break = PdfLayoutBreakType.FitPage;
            format.Layout = PdfLayoutType.Paginate;
            ellipse.Brush = PdfBrushes.Brown;
            ellipse.Draw(page, 20, 20, format);

            brush = new PdfSolidBrush(System.Drawing.Color.Black);
            ellipse.Brush = PdfBrushes.DarkGreen;
            ellipse.Draw(page, 40, 40, format);

            #endregion

            #region Transaparency

            page = doc.Pages[1];
            g = page.Graphics;
            g.DrawString("Transparent Rectangles", font, PdfBrushes.DarkBlue, new PointF(50, 80));
            PdfBrush gBrush;
            rect = new RectangleF(10, 150, 100, 100);

            pen = new PdfPen(System.Drawing.Color.Black);
            gBrush = new PdfSolidBrush(System.Drawing.Color.DarkGreen);

            g.DrawRectangle(pen, gBrush, rect);
            gBrush = new PdfSolidBrush(System.Drawing.Color.Brown);
            rect.X += 20;
            rect.Y += 20;
            pen = new PdfPen(System.Drawing.Color.Brown);
            g.SetTransparency(0.7f);
            g.DrawRectangle(pen, gBrush, rect);

            rect.X += 20;
            rect.Y += 20;
            gBrush = new PdfLinearGradientBrush(rect, System.Drawing.Color.DarkGreen, System.Drawing.Color.Brown, PdfLinearGradientMode.BackwardDiagonal);
            g.SetTransparency(0.5f);
            g.DrawRectangle(pen, gBrush, rect);

            rect.X += 20;
            rect.Y += 20;
            pen = new PdfPen(System.Drawing.Color.Blue);
            gBrush = new PdfSolidBrush(System.Drawing.Color.Gray);
            g.SetTransparency(0.25f);
            g.DrawRectangle(pen, gBrush, rect);

            rect.X += 20;
            rect.Y += 20;
            pen = new PdfPen(System.Drawing.Color.Black);
            gBrush = new PdfSolidBrush(System.Drawing.Color.Green);
            g.SetTransparency(0.1f);
            g.DrawRectangle(pen, gBrush, rect);

            #endregion

            #region Rectangle with Color space

            PointF location = new PointF(10, 50);
            page = doc.Pages.Add();
            g = page.Graphics;

            doc.ColorSpace = (PdfColorSpace)i;

            // SolidBrush
            gBrush = new PdfSolidBrush(System.Drawing.Color.Red);
            DrawRectangles(location, g, font, gBrush, pen,doc);

            // LinearGradient
            location = new PointF(180, 50);

            PointF point2 = location;

            point2.X += 100;
            gBrush = new PdfLinearGradientBrush(location, point2, System.Drawing.Color.Blue, System.Drawing.Color.Red);
            DrawRectangles(location, g, font, gBrush, pen,doc);

            // Raidal Gradient
            location = new PointF(360, 50);
            point2 = location;
            point2.Y += 250;
            point2.X = 150;
            gBrush = new PdfRadialGradientBrush(point2, 210, point2, 400, System.Drawing.Color.Blue, System.Drawing.Color.Red);
            (gBrush as PdfRadialGradientBrush).Extend = PdfExtend.End;
            DrawRectangles(location, g, font, gBrush, pen,doc);

            g.DrawString("Rectangle with color spaces", font, PdfBrushes.DarkBlue, new PointF(150, 0));
            #endregion

            doc.Save("DrawingShapes.pdf");
			doc.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                 MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("DrawingShapes.pdf") { UseShellExecute = true };
                process.Start();
            }

        }

        # endregion

        # region Helpher Methods
        /// <summary>
        /// Draw rectangles
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="g"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <param name="pen"></param>
        private void DrawRectangles(PointF startPoint, PdfGraphics g, PdfFont font, PdfBrush brush, PdfPen pen,PdfDocument doc)
        {
            PdfBrush textBrush = new PdfSolidBrush(System.Drawing.Color.Black);
            RectangleF rect = new RectangleF(startPoint.X, startPoint.Y, 100, 100);

            g.Save();

            g.DrawString("Default: " + doc.ColorSpace.ToString(), font, textBrush, rect.Location);
            rect.Y += 20;
            g.DrawRectangle(pen, brush, rect);
            rect.Y += 106;

            doc.ColorSpace = PdfColorSpace.RGB;

            g.DrawString("RGB color space.", font, textBrush, rect.Location);
            rect.Y += 20;
            g.DrawRectangle(pen, brush, rect);
            rect.Y += 106;

            doc.ColorSpace = PdfColorSpace.CMYK;

            g.DrawString("CMYK color space.", font, textBrush, rect.Location);
            rect.Y += 20;
            g.DrawRectangle(pen, brush, rect);
            rect.Y += 106;

            doc.ColorSpace = PdfColorSpace.GrayScale;

            g.DrawString("Gray scale color space.", font, textBrush, rect.Location);
            rect.Y += 20;
            g.DrawRectangle(pen, brush, rect);
            rect.Y += 106;

            g.Restore();
        }
        # endregion
    }
}
