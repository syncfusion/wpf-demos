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
using Syncfusion.Presentation;
using System.Diagnostics;
using System.IO;
using Syncfusion.Windows.Shared;

namespace OLEObject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {

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
            //New Instance of PowerPoint is Created.[Equivalent to launching MS PowerPoint with no slides].
            IPresentation presentation = Presentation.Create();
            //Add slide with titleonly layout to presentation
            ISlide slide = presentation.Slides.Add(SlideLayoutType.TitleOnly);
            //Get the title placeholder
            IShape titleShape = slide.Shapes[0] as IShape;
            //Set size and position of the title shape
            titleShape.Left = 0.92 * 72;
            titleShape.Top = 0.4 * 72;
            titleShape.Width = 11.5 * 72;
            titleShape.Height = 1.01 * 72;

            //Add title content
            titleShape.TextBody.AddParagraph("Ole Object Demo");
            //Set the title content as bold
            titleShape.TextBody.Paragraphs[0].Font.Bold = true;
            //Set the horizontal alignment as center
            titleShape.TextBody.Paragraphs[0].HorizontalAlignment = HorizontalAlignmentType.Center;
            //Add text box of specific size and position
            IShape heading = slide.Shapes.AddTextBox(3.2 * 72, 1.51 * 72, 1.86 * 72, 0.71 * 72);
            //Add paragraph to text box
            heading.TextBody.AddParagraph("MS Excel Object");
            //Set the text content as italic
            heading.TextBody.Paragraphs[0].Font.Italic = true;
            //Set the text content as bold
            heading.TextBody.Paragraphs[0].Font.Bold = true;
            //Set the font size
            heading.TextBody.Paragraphs[0].Font.FontSize = 18;

#if !NETCore
            string excelPath = @"..\..\..\..\..\..\Common\Data\Presentation\OleTemplate.xlsx";
            string imagePath = @"..\..\..\..\..\..\Common\Images\Presentation\OlePicture.png";
#else
            string excelPath = @"..\..\..\..\..\..\..\Common\Data\Presentation\OleTemplate.xlsx";
            string imagePath = @"..\..\..\..\..\..\..\Common\Images\Presentation\OlePicture.png";
#endif
            //Get the excel file as stream
            Stream excelStream = File.Open(excelPath, FileMode.Open);
            //Image to be displayed, This can be any image
            Stream imageStream = File.Open(imagePath, FileMode.Open);
            //Add ole object to the slide
            IOleObject oleObject = slide.Shapes.AddOleObject(imageStream, "Excel.Sheet.12", excelStream);
            //Set size and position of the ole object
            oleObject.Left = 3.29 * 72;
            oleObject.Top = 2.01 * 72;
            oleObject.Width = 6.94 * 72;
            oleObject.Height = 5.13 * 72;

            //Save the presentation
            presentation.Save("OleObjectSample.pptx");
            //Close the presentation
            presentation.Close();

            if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
#if !NETCore
                System.Diagnostics.Process.Start("OleObjectSample.pptx");
#else
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("OleObjectSample.pptx")
                {
                    UseShellExecute = true
                };
                process.Start();
#endif
                this.Close();
            }
        }			
    }
}