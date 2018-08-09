using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace PPTXToImage
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
            string file = @"..\..\..\..\..\..\..\Common\Images\Presentation\ppt_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\Presentation\App.ico");
        }


        private void btnCreateImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //New Instance of PowerPoint is Created.[Equivalent to launching MS PowerPoint with no slides].
                IPresentation presentation = Presentation.Create();

                //Method call to create SmartArt and add it into slides.
                CreateSlide1(presentation);
                CreateSlide2(presentation);
                CreateSlide3(presentation);
                CreateSlide4(presentation);
                if (this.radioButton.IsChecked.Value)
                {
                    presentation.Save("SmartArtSample.pptx");
                    if (System.Windows.MessageBox.Show("Do you want to view the generated PowerPoint Presentation?", "SmartArt Creation",
                            MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start("SmartArtSample.pptx");
                    }
                }
                else if(this.radioButton1.IsChecked.Value)
                {
                    //To set each slide in a pdf page.
                    PresentationToPdfConverterSettings settings = new PresentationToPdfConverterSettings();

                    settings.ShowHiddenSlides = true;

                    //Instance to create pdf document from presentation
                    PdfDocument doc = PresentationToPdfConverter.Convert(presentation, settings);

                    //Saves the pdf document
                    doc.Save("Sample.pdf");
                    if (System.Windows.MessageBox.Show("Do you want to view the generated PDF document?", "SmartArt Creation",
                            MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start("Sample.pdf");

                    }
                }
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show("This file could not be converted, please contact Syncfusion Direct-Trac system at http://www.syncfusion.com/support/default.aspx for any queries. ", "OOPS..Sorry!",
                    MessageBoxButton.OK);
                this.Close();
            }
        }
        # region Slide1
        private void CreateSlide1(IPresentation presentation)
        {
            ISlide slide1 = presentation.Slides.Add(SlideLayoutType.Blank);
            ISmartArt smartArt = slide1.Shapes.AddSmartArt(SmartArtType.BasicBlockList, 100, 100, 640, 427);
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
            node1.TextBody.AddParagraph("First");
            ISmartArtNode node2 = smartArt.Nodes[1];
            node2.TextBody.AddParagraph("Second");
            ISmartArtNode node3 = smartArt.Nodes[2];
            node3.TextBody.AddParagraph("Three");



        }

        #endregion

        # region Slide3
        private void CreateSlide3(IPresentation presentation)
        {
            ISlide slide = presentation.Slides.Add(SlideLayoutType.Blank);
            ISmartArt smartArt = slide.Shapes.AddSmartArt(SmartArtType.BasicCycle, 100, 100, 640, 427);
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
            ISmartArt smartArt = slide.Shapes.AddSmartArt(SmartArtType.Hierarchy, 100, 100, 640, 427);
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
          
