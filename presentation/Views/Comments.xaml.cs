#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
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
using Syncfusion.Presentation;
using System.Diagnostics;
using System.IO;
using Syncfusion.Windows.Shared;
using Syncfusion.OfficeChart;
using syncfusion.demoscommon.wpf;
using System.Windows.Resources;
using System.Reflection;

namespace syncfusion.presentationdemos.wpf
{
    /// <summary>
    /// Interaction logic for Comments.xaml
    /// </summary>
    public partial class Comments : DemoControl
    {
        private double xValue = 0.0;
        private double yValue = 0.0;

        public Comments()
        {
            InitializeComponent();
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion


        private void btnCreatePresn_Click(object sender, EventArgs e)
        {
            string input = @"Assets\Presentation\Images.pptx";

            using (IPresentation presentation = Presentation.Open(input))
            {
                CreateSlide1(presentation);
                CreateSlide2(presentation);
                CreateSlide3(presentation);
                presentation.Save("Comments.pptx");
            }

            if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Comments.pptx") { UseShellExecute = true };
                process.Start();
            }

        }

        private void CreateSlide3(IPresentation presentation)
        {
            xValue = 250;
            yValue = 100;
            ISlide slide3 = presentation.Slides.Add(SlideLayoutType.ContentWithCaption);
            slide3.Background.Fill.FillType = FillType.Solid;
            slide3.Background.Fill.SolidFill.Color = ColorObject.White;

            //Adds shape in slide
            IShape shape2 = (IShape)slide3.Shapes[0];
            shape2.Left = 0.47 * 72;
            shape2.Top = 1.15 * 72;
            shape2.Width = 3.5 * 72;
            shape2.Height = 4.91 * 72;

            ITextBody textFrame1 = shape2.TextBody;

            //Instance to hold paragraphs in textframe
            IParagraphs paragraphs1 = textFrame1.Paragraphs;
            IParagraph paragraph1 = paragraphs1.Add();
            paragraph1.HorizontalAlignment = HorizontalAlignmentType.Left;
            ITextPart textpart1 = paragraph1.AddTextPart();
            textpart1.Text = "Lorem ipsum dolor sit amet, lacus amet amet ultricies. Quisque mi venenatis morbi libero, orci dis, mi ut et class porta, massa ligula magna enim, aliquam orci vestibulum tempus.";
            textpart1.Font.Color = ColorObject.White;
            textpart1.Font.FontName = "Calibri (Body)";
            textpart1.Font.FontSize = 15;
            paragraphs1.Add();

            IParagraph paragraph2 = paragraphs1.Add();
            paragraph2.HorizontalAlignment = HorizontalAlignmentType.Left;
            textpart1 = paragraph2.AddTextPart();
            textpart1.Text = "Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet.";
            textpart1.Font.Color = ColorObject.White;
            textpart1.Font.FontName = "Calibri (Body)";
            textpart1.Font.FontSize = 15;
            paragraphs1.Add();

            IParagraph paragraph3 = paragraphs1.Add();
            paragraph3.HorizontalAlignment = HorizontalAlignmentType.Left;
            textpart1 = paragraph3.AddTextPart();
            textpart1.Text = "Auctor eleifend in omnis elit vestibulum, donec non elementum tellus est mauris, id aliquam, at lacus, arcu pretium proin lacus dolor et. Eu tortor, vel ultrices amet dignissim mauris vehicula.";
            textpart1.Font.Color = ColorObject.White;
            textpart1.Font.FontName = "Calibri (Body)";
            textpart1.Font.FontSize = 15;
            paragraphs1.Add();

            IParagraph paragraph4 = paragraphs1.Add();
            paragraph4.HorizontalAlignment = HorizontalAlignmentType.Left;
            textpart1 = paragraph4.AddTextPart();
            textpart1.Text = "Lorem tortor neque, purus taciti quis id. Elementum integer orci accumsan minim phasellus vel.";
            textpart1.Font.Color = ColorObject.White;
            textpart1.Font.FontName = "Calibri (Body)";
            textpart1.Font.FontSize = 15;
            paragraphs1.Add();

            slide3.Shapes.RemoveAt(1);
            slide3.Shapes.RemoveAt(1);

            //Adds picture in the shape

            Stream imageStream = GetFileStream("tablet.jpg");

            IPicture picture1 = slide3.Shapes.AddPicture(imageStream, 5.18 * 72, 1.15 * 72, 7.3 * 72, 5.31 * 72);
            imageStream.Close();

            //Add comment to the slide
            IComment comment = slide3.Comments.Add(xValue, yValue, "Author3", "A3", "Can we use a different font family for this text?", DateTime.Now);
            //Add reply to a parent comment
            slide3.Comments.Add("Author1", "A1", "Please specify the desired font for modification", DateTime.Now, comment);
        }

        private void CreateSlide2(IPresentation presentation)
        {
            xValue = 650;
            yValue = 90;

            ISlide slide2 = presentation.Slides.Add(SlideLayoutType.Blank);

            IPresentationChart chart = slide2.Shapes.AddChart(230, 80, 500, 400);

            //Specifies the chart title

            chart.ChartTitle = "Sales Analysis";

            //Sets chart data - Row1

            chart.ChartData.SetValue(1, 2, "Jan");

            chart.ChartData.SetValue(1, 3, "Feb");

            chart.ChartData.SetValue(1, 4, "March");

            //Sets chart data - Row2

            chart.ChartData.SetValue(2, 1, 2010);

            chart.ChartData.SetValue(2, 2, 60);

            chart.ChartData.SetValue(2, 3, 70);

            chart.ChartData.SetValue(2, 4, 80);

            //Sets chart data - Row3

            chart.ChartData.SetValue(3, 1, 2011);

            chart.ChartData.SetValue(3, 2, 80);

            chart.ChartData.SetValue(3, 3, 70);

            chart.ChartData.SetValue(3, 4, 60);

            //Sets chart data - Row4

            chart.ChartData.SetValue(4, 1, 2012);

            chart.ChartData.SetValue(4, 2, 60);

            chart.ChartData.SetValue(4, 3, 70);

            chart.ChartData.SetValue(4, 4, 80);

            //Creates a new chart series with the name

            IOfficeChartSerie serieJan = chart.Series.Add("Jan");

            //Sets the data range of chart serie – start row, start column, end row, end column

            serieJan.Values = chart.ChartData[2, 2, 4, 2];

            //Creates a new chart series with the name

            IOfficeChartSerie serieFeb = chart.Series.Add("Feb");

            //Sets the data range of chart serie – start row, start column, end row, end column

            serieFeb.Values = chart.ChartData[2, 3, 4, 3];

            //Creates a new chart series with the name

            IOfficeChartSerie serieMarch = chart.Series.Add("March");

            //Sets the data range of chart series – start row, start column, end row, end column

            serieMarch.Values = chart.ChartData[2, 4, 4, 4];

            //Sets the data range of the category axis

            chart.PrimaryCategoryAxis.CategoryLabels = chart.ChartData[2, 1, 4, 1];

            //Specifies the chart type

            chart.ChartType = OfficeChartType.Column_Clustered_3D;


            slide2.Comments.Add(xValue, yValue, "Author2", "A2", "Do all 3D-chart types support in Presentation library?", DateTime.Now);

        }

        private void CreateSlide1(IPresentation presentation)
        {
            xValue = 410;
            yValue = 60;
            ISlide slide1 = presentation.Slides[0];
            IShape shape1 = (IShape)slide1.Shapes[0];
            shape1.Left = 1.27 * 72;
            shape1.Top = 0.85 * 72;
            shape1.Width = 10.86 * 72;
            shape1.Height = 3.74 * 72;

            ITextBody textFrame = shape1.TextBody;
            IParagraphs paragraphs = textFrame.Paragraphs;
            paragraphs.Add();
            IParagraph paragraph = paragraphs[0];
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Left;
            ITextParts textParts = paragraph.TextParts;
            textParts.Add();
            ITextPart textPart = textParts[0];
            textPart.Text = "Essential Presentation ";
            textPart.Font.CapsType = TextCapsType.All;
            textPart.Font.FontName = "Calibri Light (Headings)";
            textPart.Font.FontSize = 80;
            textPart.Font.Color = ColorObject.Black;

             IComment comment = slide1.Comments.Add(xValue, yValue, "Author1", "A1", "Essential Presentation is available from 13.1 versions of Essential Studio", DateTime.Now);
            //Author2 add reply to a parent comment
            slide1.Comments.Add("Author2", "A2", "Does it support rendering of slides as images or PDF?", DateTime.Now, comment);
            //Author1 add reply to a parent comment
            slide1.Comments.Add("Author1", "A1", "Yes, you may render slides as images and PDF.", DateTime.Now, comment);
        }

        private Stream GetFileStream(string fileName)
        {
            Assembly assembly = typeof(Comments).Assembly;
            return assembly.GetManifestResourceStream("syncfusion.presentationdemos.wpf.Assets.Presentation." + fileName);
        }
    }
}