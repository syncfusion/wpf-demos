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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Syncfusion.Presentation;
using Syncfusion.Windows.Shared;
using Syncfusion.Pdf;
using Syncfusion.PresentationToPdfConverter;
using syncfusion.demoscommon.wpf;

namespace syncfusion.presentationdemos.wpf
{
    /// <summary>
    /// Interaction logic for SmartArtCreation.xaml
    /// </summary>
    public partial class SmartArtCreation : DemoControl
    {
        public SmartArtCreation()
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

        private void btnCreateImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //New Instance of PowerPoint is Created.[Equivalent to launching MS PowerPoint with no slides].
                using (IPresentation presentation = Presentation.Create())
                {
                    //Method call to create SmartArt and add it into slides.
                    CreateSlide1(presentation);
                    CreateSlide2(presentation);
                    CreateSlide3(presentation);
                    CreateSlide4(presentation);
                    if (this.radioButton.IsChecked.Value)
                    {
                        presentation.Save("SmartArtCreation.pptx");
                        if (System.Windows.MessageBox.Show("Do you want to view the generated PowerPoint Presentation?", "SmartArt Creation",
                                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo("SmartArtCreation.pptx") { UseShellExecute = true };
                            process.Start();
                        }
                    }
                    else if (this.radioButton1.IsChecked.Value)
                    {
                        //To set each slide in a pdf page.
                        PresentationToPdfConverterSettings settings = new PresentationToPdfConverterSettings();

                        settings.ShowHiddenSlides = true;

                        //Instance to create pdf document from presentation
                        using (PdfDocument doc = PresentationToPdfConverter.Convert(presentation, settings))
                        {
                            //Saves the pdf document
                            doc.Save("Sample.pdf");
                        }                            
                        if (System.Windows.MessageBox.Show("Do you want to view the generated PDF document?", "SmartArt Creation",
                                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.pdf") { UseShellExecute = true };
                            process.Start();
                        }
                    }
                }                    
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("This file could not be converted, please contact Syncfusion Direct-Trac system at http://www.syncfusion.com/support/default.aspx for any queries. ", "OOPS..Sorry!",
                    MessageBoxButton.OK);
            }
        }
        # region Slide1
        private void CreateSlide1(IPresentation presentation)
        {
            ISlide slide1 = presentation.Slides.Add(SlideLayoutType.Blank);
            ISmartArt smartArt = slide1.Shapes.AddSmartArt(SmartArtType.BasicBlockList, 160, 65, 640, 427);
            ISmartArtNode node1 = smartArt.Nodes[0];
            node1.TextBody.AddParagraph("One");
            ISmartArtNode node2 = smartArt.Nodes[1];
            node2.TextBody.AddParagraph("Two");
            ISmartArtNode node3 = smartArt.Nodes[2];
            node3.TextBody.AddParagraph("Three");
            ISmartArtNode node4 = smartArt.Nodes[3];
            node4.TextBody.AddParagraph("Four");
            ISmartArtNode node5 = smartArt.Nodes[4];
            node5.TextBody.AddParagraph("Five");
        }
        #endregion

        # region Slide2
        private void CreateSlide2(IPresentation presentation)
        {
            ISlide slide = presentation.Slides.Add(SlideLayoutType.Blank);
            ISmartArt smartArt = slide.Shapes.AddSmartArt(SmartArtType.StepUpProcess, 100, 100, 640, 427);
            ISmartArtNode node1 = smartArt.Nodes[0];
            node1.TextBody.AddParagraph("Goal");
            ISmartArtNode node2 = smartArt.Nodes[1];
            node2.TextBody.AddParagraph("Implement");
            ISmartArtNode node3 = smartArt.Nodes[2];
            node3.TextBody.AddParagraph("Achieve");
        }

        #endregion

        # region Slide3
        private void CreateSlide3(IPresentation presentation)
        {
            ISlide slide = presentation.Slides.Add(SlideLayoutType.Blank);
            ISmartArt smartArt = slide.Shapes.AddSmartArt(SmartArtType.BasicCycle, 160, 65, 640, 427);
            ISmartArtNode node1 = smartArt.Nodes[0];
            node1.TextBody.AddParagraph("Requirement");
            ISmartArtNode node2 = smartArt.Nodes[1];
            node2.TextBody.AddParagraph("Analyzing");
            ISmartArtNode node3 = smartArt.Nodes[2];
            node3.TextBody.AddParagraph("Estimation");
            ISmartArtNode node4 = smartArt.Nodes[3];
            node4.TextBody.AddParagraph("Implementing");
            ISmartArtNode node5 = smartArt.Nodes[4];
            node5.TextBody.AddParagraph("Testing");
        }
        #endregion

        # region Slide4
        private void CreateSlide4(IPresentation presentation)
        {
            ISlide slide = presentation.Slides.Add(SlideLayoutType.Blank);
            ISmartArt smartArt = slide.Shapes.AddSmartArt(SmartArtType.Hierarchy, 160, 65, 640, 427);
            ISmartArtNode node1 = smartArt.Nodes[0];
            node1.TextBody.AddParagraph("Grand Father");
            ISmartArtNode childNode1 = node1.ChildNodes[0];
            childNode1.TextBody.AddParagraph("Son1");
            ISmartArtNode childNode2 = node1.ChildNodes[1];
            childNode2.TextBody.AddParagraph("Son2");
            ISmartArtNode childnode1 = childNode1.ChildNodes[0];
            childnode1.TextBody.AddParagraph("Son1");
            ISmartArtNode childnode2 = childNode1.ChildNodes[1];
            childnode2.TextBody.AddParagraph("Son2");
            ISmartArtNode childnode2s1 = childNode2.ChildNodes[0];
            childnode2s1.TextBody.AddParagraph("Son1");
        }
        #endregion				
    }
}
          
