#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using syncfusion.demoscommon.wpf;

namespace syncfusion.presentationdemos.wpf
{
    /// <summary>
    /// Interaction logic for HeaderAndFooter.xaml
    /// </summary>
    public partial class HeaderAndFooter : DemoControl
    {
        public HeaderAndFooter()
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
            string input = @"Assets\Presentation\HeaderFooter.pptx";

            //Opens an existing PowerPoint presentation.
            using (IPresentation pptxDoc = Presentation.Open(input))
            {
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
                pptxDoc.Save("HeaderFooter.pptx");
            }

            if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("HeaderFooter.pptx") { UseShellExecute = true };
                process.Start();
            }
        }
    }
}

