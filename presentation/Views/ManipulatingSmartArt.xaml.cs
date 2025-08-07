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
using syncfusion.demoscommon.wpf;

namespace syncfusion.presentationdemos.wpf
{
    /// <summary>
    /// Interaction logic for ManipulatingSmartArt.xaml
    /// </summary>
    public partial class ManipulatingSmartArt : DemoControl
    {
        public ManipulatingSmartArt()
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
                string input = @"Assets\Presentation\SmartArtNode.pptx";
                using (IPresentation presentation = Presentation.Open(input))
                {
                    //Adds new node to the main node collection of the SmartArt.
                    AddNodeInMainNodes(presentation);
                    //Adds new node to the child node collection of the SmartArt.
                    AddNodeInChildNodes(presentation);
                    //Saves presentation with .pptx format.
                    presentation.Save("ManipulatingSmartArt.pptx");
                }
                    
                if (System.Windows.MessageBox.Show("Do you want to view the generated PowerPoint Presentation?", "SmartArt Node Insertion",
                        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("ManipulatingSmartArt.pptx") { UseShellExecute = true };
                    process.Start();
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("This Presentation could not be created, please contact Syncfusion Direct-Trac system at http://www.syncfusion.com/support/default.aspx for any queries. ", "OOPS..Sorry!",
                    MessageBoxButton.OK);
            }
        }
        # region Slide1
        private void AddNodeInMainNodes(IPresentation presentation)
        {
            ISlide slide1 = presentation.Slides[0];
            ISmartArt smartArt = slide1.Shapes[0] as ISmartArt;
            //New node adds to the node collection.
            ISmartArtNode newNode = smartArt.Nodes.Add();
            //Text content to the newly added node.
            newNode.TextBody.AddParagraph("Marketing");

        }
        #endregion

        # region Slide2
        private void AddNodeInChildNodes(IPresentation presentation)
        {
            ISlide slide2 = presentation.Slides[2];
            ISmartArt smartArt = slide2.Shapes[1] as ISmartArt;
            // Gets first node from the node collection using index value.
            ISmartArtNode firstNode = smartArt.Nodes[0];
            //Adds new child node to the first node's child node collection.
            ISmartArtNode childNode = firstNode.ChildNodes.Add();
            //Gives the text content to the newly added child node.
            childNode.TextBody.AddParagraph("Make Simple");
        }

        #endregion

    }
}
          
