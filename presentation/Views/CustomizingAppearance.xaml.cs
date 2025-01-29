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
using Syncfusion.PresentationToPdfConverter;
using Syncfusion.Pdf;
using syncfusion.demoscommon.wpf;

namespace syncfusion.presentationdemos.wpf
{
    /// <summary>
    /// Interaction logic for CustomizingAppearance.xaml
    /// </summary>
    public partial class CustomizingAppearance : DemoControl
    {
        public CustomizingAppearance()
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
                //Opens the specified presentation
                using (IPresentation presentation = Presentation.Open(@"Assets\Presentation\SmartArts.pptx"))
                {
                    //Method call to edit slides
                    CreateSlide1(presentation);
                    CreateSlide2(presentation);
                    CreateSlide3(presentation);
                    if (this.radioButton.IsChecked.Value)
                    {
                        presentation.Save("CustomizingAppearance.pptx");
                        if (System.Windows.MessageBox.Show("Do you want to view the generated PowerPoint Presentation?", "SmartArt Modification",
                                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo("CustomizingAppearance.pptx") { UseShellExecute = true };
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
                        if (System.Windows.MessageBox.Show("Do you want to view the generated PDF document?", "SmartArt Modification",
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
            ISlide slide1 = presentation.Slides[0];
            ISmartArt smartArt = slide1.Shapes[0] as ISmartArt;
            smartArt.Background.FillType = FillType.Solid;
            smartArt.Background.SolidFill.Color = ColorObject.Wheat;
            smartArt.Background.SolidFill.Transparency = 100;
            smartArt.Nodes[0].Shapes[0].Fill.FillType = FillType.Solid;
            smartArt.Nodes[0].Shapes[0].Fill.SolidFill.Color = ColorObject.CornflowerBlue;
            smartArt.Nodes[1].Shapes[0].Fill.FillType = FillType.Solid;
            smartArt.Nodes[1].Shapes[0].Fill.SolidFill.Color = ColorObject.CornflowerBlue;
            smartArt.Nodes[2].Shapes[0].Fill.FillType = FillType.Solid;
            smartArt.Nodes[2].Shapes[0].Fill.SolidFill.Color = ColorObject.CornflowerBlue;


        }
        #endregion

        # region Slide2
        private void CreateSlide2(IPresentation presentation)
        {
            ISlide slide2 = presentation.Slides[1];
            ISmartArt smartArt = slide2.Shapes[0] as ISmartArt;
            smartArt.Background.FillType = FillType.Solid;
            smartArt.Background.SolidFill.Color = ColorObject.Wheat;
            smartArt.Background.SolidFill.Transparency = 100;
            smartArt.Nodes[0].Shapes[0].Fill.FillType = FillType.Solid;
            smartArt.Nodes[0].Shapes[0].Fill.SolidFill.Color = ColorObject.CornflowerBlue;
            smartArt.Nodes[0].Shapes[0].LineFormat.Weight = 5;
            smartArt.Nodes[1].Shapes[0].Fill.FillType = FillType.Solid;
            smartArt.Nodes[1].Shapes[0].Fill.SolidFill.Color = ColorObject.CornflowerBlue;
            smartArt.Nodes[1].Shapes[0].LineFormat.Weight = 5;
            smartArt.Nodes[2].Shapes[0].Fill.FillType = FillType.Solid;
            smartArt.Nodes[2].Shapes[0].Fill.SolidFill.Color = ColorObject.CornflowerBlue;
            smartArt.Nodes[2].Shapes[0].LineFormat.Weight = 5;
            smartArt.Nodes[3].Shapes[0].Fill.FillType = FillType.Solid;
            smartArt.Nodes[3].Shapes[0].Fill.SolidFill.Color = ColorObject.CornflowerBlue;
            smartArt.Nodes[3].Shapes[0].LineFormat.Weight = 5;
            smartArt.Nodes[4].Shapes[0].Fill.FillType = FillType.Solid;
            smartArt.Nodes[4].Shapes[0].Fill.SolidFill.Color = ColorObject.CornflowerBlue;
            smartArt.Nodes[4].Shapes[0].LineFormat.Weight = 5;
        }

        #endregion

        # region Slide3
        private void CreateSlide3(IPresentation presentation)
        {
            ISlide slide2 = presentation.Slides[2];
            ISmartArt smartArt = slide2.Shapes[1] as ISmartArt;
            smartArt.Background.FillType = FillType.Solid;
            smartArt.Background.SolidFill.Color = ColorObject.Wheat;
            smartArt.Background.SolidFill.Transparency = 100;
            smartArt.Nodes[0].ChildNodes[0].Shapes[0].Fill.FillType = FillType.Solid;
            smartArt.Nodes[0].ChildNodes[0].Shapes[0].Fill.SolidFill.Color = ColorObject.CornflowerBlue;
            smartArt.Nodes[0].ChildNodes[0].Shapes[0].LineFormat.Weight = 5;
            smartArt.Nodes[0].ChildNodes[1].Shapes[0].Fill.FillType = FillType.Solid;
            smartArt.Nodes[0].ChildNodes[1].Shapes[0].Fill.SolidFill.Color = ColorObject.CornflowerBlue;
            smartArt.Nodes[0].ChildNodes[1].Shapes[0].LineFormat.Weight = 5;
            smartArt.Nodes[1].ChildNodes[0].Shapes[0].Fill.FillType = FillType.Solid;
            smartArt.Nodes[1].ChildNodes[0].Shapes[0].Fill.SolidFill.Color = ColorObject.CornflowerBlue;
            smartArt.Nodes[1].ChildNodes[0].Shapes[0].LineFormat.Weight = 5;
            smartArt.Nodes[1].ChildNodes[1].Shapes[0].Fill.FillType = FillType.Solid;
            smartArt.Nodes[1].ChildNodes[1].Shapes[0].Fill.SolidFill.Color = ColorObject.CornflowerBlue;
            smartArt.Nodes[1].ChildNodes[1].Shapes[0].LineFormat.Weight = 5;
            smartArt.Nodes[1].ChildNodes[2].Shapes[0].Fill.FillType = FillType.Solid;
            smartArt.Nodes[1].ChildNodes[2].Shapes[0].Fill.SolidFill.Color = ColorObject.CornflowerBlue;
            smartArt.Nodes[1].ChildNodes[2].Shapes[0].LineFormat.Weight = 5;
        }

        #endregion
    }
}
          
