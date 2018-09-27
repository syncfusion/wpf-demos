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
using System.Diagnostics;
using Syncfusion.Pdf.Interactive;
using System.IO;
using Syncfusion.Windows.Shared;
using Syncfusion.Pdf.Parsing;
namespace Hello_World
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
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            document.PageSettings.SetMargins(0);

            RectangleF bounds = new RectangleF(350, 50, 80, 80);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);
            PdfBrush brush = new PdfSolidBrush(System.Drawing.Color.Black);
            PdfCircleAnnotation circleannotation = new PdfCircleAnnotation(bounds);
            circleannotation.InnerColor = new PdfColor(System.Drawing.Color.Yellow);
            circleannotation.Color = new PdfColor(System.Drawing.Color.Red);
            circleannotation.AnnotationFlags = PdfAnnotationFlags.Default;
            circleannotation.Author = "Syncfusion";
            circleannotation.Subject = "CircleAnnotation";
            circleannotation.ModifiedDate = new DateTime(2015, 1, 18);
            page.Annotations.Add(circleannotation);
            page.Graphics.DrawString("CircleAnnotation", font, brush, new PointF(350, 10));

            PdfEllipseAnnotation ellipseannotation = new PdfEllipseAnnotation(new RectangleF(30, 30, 50, 100), "Ellipse Annotation");
            ellipseannotation.Color = new PdfColor(System.Drawing.Color.Red);
            ellipseannotation.InnerColor = new PdfColor(System.Drawing.Color.Yellow);
            page.Graphics.DrawString("EllipseAnnotation", font, brush, new PointF(30, 10));
            page.Annotations.Add(ellipseannotation);

            PdfSquareAnnotation squareannotation = new PdfSquareAnnotation(new RectangleF(30, 200, 80, 80));
            squareannotation.Text = "SquareAnnotation";
            squareannotation.InnerColor = new PdfColor(System.Drawing.Color.Red);
            squareannotation.Color = new PdfColor(System.Drawing.Color.Yellow);
            page.Graphics.DrawString("SquareAnnotation", font, brush, new PointF(30, 180));
            page.Annotations.Add(squareannotation);

            RectangleF rectangle1 = new RectangleF(350, 220, 100, 50);
            PdfRectangleAnnotation rectangleannotation = new PdfRectangleAnnotation(rectangle1, "RectangleAnnotation");
            rectangleannotation.InnerColor = new PdfColor(System.Drawing.Color.Red);
            rectangleannotation.Color = new PdfColor(System.Drawing.Color.Yellow);
            page.Graphics.DrawString("RectangleAnnotation", font, brush, new PointF(350, 180));
            page.Annotations.Add(rectangleannotation);

            int[] points = new int[] { 400, 450, 550, 450 };
            PdfLineAnnotation lineAnnotation = new PdfLineAnnotation(points, "Line Annoation is the one of the annotation type...");
            lineAnnotation.Author = "Syncfusion";
            lineAnnotation.Subject = "LineAnnotation";
            lineAnnotation.ModifiedDate = new DateTime(2015, 1, 18);
            lineAnnotation.Text = "PdfLineAnnotation";
            lineAnnotation.BackColor = new PdfColor(System.Drawing.Color.Red);
            page.Graphics.DrawString("LineAnnotation", font, brush, new PointF(400, 320));
            page.Annotations.Add(lineAnnotation);

            int[] points1 = new int[] { 50, 398, 100, 425, 200, 455, 300, 330, 180, 330 };
            PdfPolygonAnnotation polygonannotation = new PdfPolygonAnnotation(points1, "PolygonAnnotation");
            polygonannotation.Bounds = new RectangleF(30, 350, 300, 200);
            PdfPen pen = new PdfPen(System.Drawing.Color.Red);
            polygonannotation.Text = "polygon";
            polygonannotation.Color = new PdfColor(System.Drawing.Color.Red);
            polygonannotation.InnerColor = new PdfColor(System.Drawing.Color.LightPink);
            page.Graphics.DrawString("PolygonAnnotation", font, brush, new PointF(50, 320));
            page.Annotations.Add(polygonannotation);

            RectangleF freetextrect = new RectangleF(405, 525, 80, 30);
            PdfFreeTextAnnotation freeText = new PdfFreeTextAnnotation(freetextrect);
            freeText.MarkupText = "Free Text with Callouts";
            freeText.TextMarkupColor = new PdfColor(System.Drawing.Color.Green);
            freeText.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 7f);
            freeText.BorderColor = new PdfColor(System.Drawing.Color.Blue);
            freeText.Border = new PdfAnnotationBorder(.5f);
            freeText.AnnotationFlags = PdfAnnotationFlags.Default;
            freeText.Text = "Free Text";
            freeText.Color = new PdfColor(System.Drawing.Color.Yellow);
            PointF[] Freetextpoints = { new PointF(365, 605), new PointF(379, 534), new PointF(401, 534), new PointF(401, 534) };
            freeText.CalloutLines = Freetextpoints;
            page.Graphics.DrawString("FreetextAnnotation", font, brush, new PointF(400, 510));
            page.Annotations.Add(freeText);

            string s = "This is TextMarkup annotation!!!";
            RectangleF Textmarkuprect = new RectangleF(30, 540, 200, 20);
            page.Graphics.DrawString(s, font, brush, new PointF(30, 540));
            PdfTextMarkupAnnotation textannot = new PdfTextMarkupAnnotation("sample", "Highlight", s, new PointF(70, 580), font);
            textannot.Author = "Annotation";
            textannot.Opacity = 1.0f;
            textannot.Subject = "pdftextmarkupannotation";
            textannot.ModifiedDate = new DateTime(2015, 1, 18);
            textannot.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.StrikeOut;
            textannot.TextMarkupColor = new PdfColor(System.Drawing.Color.Yellow);
            textannot.InnerColor = new PdfColor(System.Drawing.Color.Red);
            textannot.Color = new PdfColor(System.Drawing.Color.Yellow);
            page.Graphics.DrawString("TextMarkupAnnotation", font, brush, new PointF(30, 510));
            page.Annotations.Add(textannot);


            document.PageSettings.SetMargins(0);
            float[] inkPoints = new float[] { 72.919f, 136.376f, 72.264f, 136.376f, 62.446f, 142.922f, 61.137f, 142.922f, 55.901f, 139.649f, 55.246f, 138.34f, 54.592f, 132.449f, 54.592f, 127.867f, 55.901f, 125.904f, 59.828f, 121.976f, 63.101f, 121.322f, 65.719f, 122.631f, 68.992f, 125.249f, 70.301f, 130.485f, 71.61f, 133.104f, 72.264f, 136.376f, 72.919f, 140.304f, 74.883f, 144.885f, 76.192f, 150.776f, 76.192f, 151.431f, 76.192f, 152.085f, 76.192f, 158.631f, 76.192f, 159.94f, 75.537f, 155.358f, 74.228f, 150.122f, 74.228f, 146.195f, 73.574f, 141.613f, 73.574f, 137.685f, 74.228f, 132.449f, 74.883f, 128.522f, 75.537f, 124.594f, 76.192f, 123.285f, 76.846f, 122.631f, 80.774f, 122.631f, 82.737f, 123.285f, 85.355f, 125.249f, 88.628f, 129.831f, 89.283f, 133.104f, 89.937f, 137.031f, 90.592f, 140.958f, 89.937f, 142.267f, 86.665f, 141.613f, 85.355f, 140.304f, 84.701f, 138.34f, 84.701f, 137.685f, 85.355f, 137.031f, 87.974f, 135.722f, 90.592f, 136.376f, 92.555f, 137.031f, 96.483f, 139.649f, 98.446f, 140.958f, 101.719f, 142.922f, 103.028f, 142.922f, 100.41f, 138.34f, 99.756f, 134.413f, 99.101f, 131.14f, 99.101f, 128.522f, 99.756f, 127.213f, 101.065f, 125.904f, 102.374f, 123.94f, 103.683f, 123.94f, 107.61f, 125.904f, 110.228f, 129.831f, 114.156f, 135.067f, 117.428f, 140.304f, 119.392f, 143.576f, 121.356f, 144.231f, 122.665f, 144.231f, 123.974f, 142.267f, 126.592f, 139.649f, 127.247f, 140.304f, 126.592f, 142.922f, 124.628f, 143.576f, 122.01f, 142.922f, 118.083f, 141.613f, 114.81f, 136.376f, 114.81f, 131.14f, 113.501f, 127.213f, 114.156f, 125.904f, 118.083f, 125.904f, 120.701f, 126.558f, 123.319f, 130.485f, 125.283f, 136.376f, 125.937f, 140.304f, 125.937f, 142.922f, 126.592f, 143.576f, 125.937f, 135.722f, 125.937f, 131.794f, 125.937f, 131.14f, 127.247f, 129.176f, 129.21f, 127.213f, 131.828f, 127.213f, 134.447f, 128.522f, 136.41f, 136.376f, 139.028f, 150.122f, 141.647f, 162.558f, 140.992f, 163.213f, 138.374f, 160.595f, 135.756f, 153.395f, 135.101f, 148.158f, 134.447f, 140.304f, 134.447f, 130.485f, 133.792f, 124.594f, 133.792f, 115.431f, 133.792f, 110.194f, 133.792f, 105.612f, 134.447f, 105.612f, 137.065f, 110.194f, 137.719f, 116.74f, 139.028f, 120.013f, 139.028f, 123.94f, 137.719f, 127.213f, 135.756f, 130.485f, 134.447f, 130.485f, 133.792f, 130.485f, 137.719f, 131.794f, 141.647f, 135.722f, 146.883f, 142.922f, 152.774f, 153.395f, 153.428f, 159.286f, 150.156f, 159.94f, 147.537f, 156.667f, 146.883f, 148.813f, 146.883f, 140.958f, 146.883f, 134.413f, 146.883f, 125.904f, 145.574f, 118.703f, 145.574f, 114.776f, 145.574f, 112.158f, 146.228f, 111.503f, 147.537f, 111.503f, 148.192f, 112.158f, 150.156f, 112.812f, 150.81f, 113.467f, 152.119f, 114.776f, 154.083f, 117.394f, 155.392f, 119.358f, 156.701f, 120.667f, 157.356f, 121.976f, 156.701f, 121.322f, 156.047f, 120.013f, 155.392f, 119.358f, 154.083f, 117.394f, 154.083f, 116.74f, 152.774f, 114.776f, 152.119f, 114.121f, 150.81f, 113.467f, 149.501f, 113.467f, 147.537f, 112.158f, 146.883f, 112.158f, 145.574f, 111.503f, 144.919f, 112.158f, 144.265f, 114.121f, 144.265f, 115.431f, 144.265f, 116.74f, 144.265f, 117.394f, 144.265f, 118.049f, 144.919f, 118.703f, 145.574f, 120.667f, 146.228f, 122.631f, 147.537f, 123.285f, 147.537f, 124.594f, 148.192f, 125.904f, 147.537f, 128.522f, 147.537f, 129.176f, 147.537f, 130.485f, 147.537f, 132.449f, 147.537f, 134.413f, 147.537f, 136.376f, 147.537f, 138.34f, 147.537f, 138.994f, 145.574f, 138.994f, 142.956f, 138.252f };
            List<float> linePoints = new List<float>(inkPoints);
            RectangleF rectangle = new RectangleF(30, 580, 300, 400);
            PdfInkAnnotation inkAnnotation = new PdfInkAnnotation(rectangle, linePoints);
            inkAnnotation.Bounds = rectangle;
            inkAnnotation.Color = new PdfColor(System.Drawing.Color.Red);
            page.Graphics.DrawString("InkAnnotation", font, brush, new PointF(30, 610));
            page.Annotations.Add(inkAnnotation);

            //Creates a new popup annotation.
            RectangleF popupRect = new RectangleF(430, 670, 30, 30);
            PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation();
            popupAnnotation.Border.Width = 4;
            popupAnnotation.Border.HorizontalRadius = 20;
            popupAnnotation.Border.VerticalRadius = 30;
            popupAnnotation.Opacity = 1;
            popupAnnotation.Open = true;
            popupAnnotation.Text = "Popup Annotation";
            popupAnnotation.Color = System.Drawing.Color.Green;
            popupAnnotation.InnerColor = System.Drawing.Color.Blue;
            popupAnnotation.Bounds = popupRect;
            if (this.flatten.IsChecked == true)
            {
                 popupAnnotation.FlattenPopUps = true;
                popupAnnotation.Flatten = true;
            }
            page.Graphics.DrawString("Popup Annotation", font, brush, new PointF(400, 610));
            page.Annotations.Add(popupAnnotation);

            page = document.Pages.Add();

            //Creates a new Rubberstamp measurement annotation.
            rectangle = new RectangleF(10, 40, 200, 50);
            PdfRubberStampAnnotation rubberStampAnnotation = new PdfRubberStampAnnotation(rectangle, " Approved Rubber Stamp Annotation");
            rubberStampAnnotation.Icon = PdfRubberStampAnnotationIcon.Approved;
            rubberStampAnnotation.Author = "Syncfusion";
            rubberStampAnnotation.Subject = "Rubber Stamp";
            rubberStampAnnotation.Color = new PdfColor(System.Drawing.Color.Blue);
            page.Graphics.DrawString("Rubber Stamp Annotation", font, brush, new PointF(40, 10));
            if (this.flatten.IsChecked == true)
            {
                rubberStampAnnotation.Flatten = true;
            }
            page.Annotations.Add(rubberStampAnnotation);

            //Creates a new Line measurement annotation.
            points = new int[] { 350, 750, 500, 750 };
            PdfLineMeasurementAnnotation lineMeasureAnnot = new PdfLineMeasurementAnnotation(points);
            lineMeasureAnnot.Author = "Syncfusion";
            lineMeasureAnnot.Subject = "LineAnnotation";
            lineMeasureAnnot.ModifiedDate = new DateTime(2015, 1, 18);
            lineMeasureAnnot.Unit = PdfMeasurementUnit.Inch;
            lineMeasureAnnot.lineBorder.BorderWidth = 2;             
            lineMeasureAnnot.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f, PdfFontStyle.Regular);
            lineMeasureAnnot.Color = new PdfColor(System.Drawing.Color.Red);
            if (this.flatten.IsChecked == true)
            {
                lineMeasureAnnot.Flatten = true;
            }
            page.Graphics.DrawString("Line Measurement Annotation", font, brush, new PointF(320, 10));
            page.Annotations.Add(lineMeasureAnnot);

            MemoryStream SourceStream = new MemoryStream();

            document.Save(SourceStream);
            document.Close(true);

            PdfLoadedDocument lDoc = new PdfLoadedDocument(SourceStream);
            PdfLoadedPage lpage = lDoc.Pages[0] as PdfLoadedPage;
            if (this.flatten.IsChecked == true)
            {
                lpage.Annotations.Flatten = true;
            }
            lDoc.Save(@"Sample.pdf");


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