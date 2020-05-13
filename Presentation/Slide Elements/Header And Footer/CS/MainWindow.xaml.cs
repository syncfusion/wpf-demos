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

namespace HeaderAndFooter
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
            string input = @"..\..\..\..\..\..\Common\Data\Presentation\HeaderFooter.pptx";
#if NETCore
            input = @"..\..\..\..\..\..\..\Common\Data\Presentation\HeaderFooter.pptx";
#endif

            //Opens an existing PowerPoint presentation.
            IPresentation pptxDoc = Presentation.Open(input);

            //Add footers into all the PowerPoint slides.
            foreach (ISlide slide in pptxDoc.Slides)
            {
                //Enable a date and time footer in slide.
                slide.HeadersFooters.DateAndTime.Visible = true;
                //Enable a footer in slide.
                slide.HeadersFooters.Footer.Visible = true;
                //Sets the footer text.
                slide.HeadersFooters.Footer.Text = "Footer";
                //Enable a slide number footer in slide.
                slide.HeadersFooters.SlideNumber.Visible = true;
            }

            //Add header into first slide notes page.
            //Add a notes slide to the slide.
            INotesSlide notesSlide = pptxDoc.Slides[0].AddNotesSlide();
            //Enable a header in notes slide.
            notesSlide.HeadersFooters.Header.Visible = true;
            //Sets the header text.
            notesSlide.HeadersFooters.Header.Text = "Header";

            //Saves Presentation with specified file name with extension.
            pptxDoc.Save("HeaderFooterSample.pptx");

            if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
#if !NETCore
                System.Diagnostics.Process.Start("HeaderFooterSample.pptx");
#else
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("HeaderFooterSample.pptx")
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

