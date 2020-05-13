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
using Syncfusion.Presentation;
using System.Diagnostics;
using System.IO;
using Syncfusion.Windows.Shared;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        //private const string DEFAULTOUTPUTPATH = "../../Output/Hello World.pptx";
        public MainWindow()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
#if !NETCore
            string file = @"..\..\..\..\..\..\Common\Images\Presentation\ppt_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\Presentation\App.ico"); 
#else
            string file = @"..\..\..\..\..\..\..\Common\Images\Presentation\ppt_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\Presentation\App.ico");
#endif
        }

        private void btnCreatePresn_Click(object sender, EventArgs e)
        {
            string input = @"..\..\..\..\..\..\Common\Data\Presentation\HelloWorld.pptx";
#if NETCore
            input = @"..\..\..\..\..\..\..\Common\Data\Presentation\HelloWorld.pptx";
#endif
            IPresentation presentation = Presentation.Open(input);
            //New Instance of PowerPoint is Created.[Equivalent to launching MS PowerPoint with no slides].

            //Method call to create slides
            CreateSlide(presentation);

            //Saves the presentation
            presentation.Save("HelloWorldSample.pptx");
            if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                  MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
#if !NETCore
                System.Diagnostics.Process.Start("HelloWorldSample.pptx");
#else
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("HelloWorldSample.pptx")
                {
                    UseShellExecute = true
                };
                process.Start();
#endif
                this.Close();
            }
        }

        # region Slide
        private void CreateSlide(IPresentation presentation)
        {
            ISlide slide1 = presentation.Slides[0];
            IShape titleShape = slide1.Shapes[0] as IShape;
            titleShape.Left = 0.33 * 72;
            titleShape.Top = 0.58 * 72;
            titleShape.Width = 12.5 * 72;
            titleShape.Height = 1.75 * 72;

            ITextBody textFrame1 = (slide1.Shapes[0] as IShape).TextBody;
            IParagraphs paragraphs1 = textFrame1.Paragraphs;
            IParagraph paragraph = paragraphs1.Add();
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;
            ITextPart textPart1 = paragraph.AddTextPart();
            textPart1.Text = "Essential Presentation";
            textPart1.Font.CapsType = TextCapsType.All;
            textPart1.Font.FontName = "Adobe Garamond Pro";
            textPart1.Font.Bold = true;
            textPart1.Font.FontSize = 40;

            IShape subtitle = slide1.Shapes[1] as IShape;
            subtitle.Left = 0.5 * 72;
            subtitle.Top = 3 * 72;
            subtitle.Width = 11.8 * 72;
            subtitle.Height = 1.7 * 72;

            ITextBody textFrame2 = (slide1.Shapes[1] as IShape).TextBody;
            textFrame2.VerticalAlignment = VerticalAlignmentType.Top;
            IParagraphs paragraphs2 = textFrame2.Paragraphs;
            IParagraph para = paragraphs2.Add();
            para.HorizontalAlignment = HorizontalAlignmentType.Left;
            ITextPart textPart2 = para.AddTextPart();
            textPart2.Text = "Lorem ipsum dolor sit amet, lacus amet amet ultricies. Quisque mi venenatis morbi libero, orci dis, mi ut et class porta, massa ligula magna enim, aliquam orci vestibulum tempus.Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet.";
            textPart2.Font.FontName = "Adobe Garamond Pro";
            textPart2.Font.FontSize = 21;

            para = paragraphs2.Add();
            para.HorizontalAlignment = HorizontalAlignmentType.Left;
            textPart2 = para.AddTextPart();
            textPart2.Text = "Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet. Auctor eleifend in omnis elit vestibulum, donec non elementum tellus est mauris, id aliquam, at lacus, arcu pretium proin lacus dolor et. Eu tortor, vel ultrices amet dignissim mauris vehicula.";
            textPart2.Font.FontName = "Adobe Garamond Pro";
            textPart2.Font.FontSize = 21;

        }
        #endregion		
    }
}

