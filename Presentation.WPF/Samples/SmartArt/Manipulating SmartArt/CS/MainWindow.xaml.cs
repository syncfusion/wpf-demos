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
                //Opens the specified presentation
                string input = @"..\..\..\..\..\..\..\Common\Data\Presentation\SmartArtNode.pptx";
                IPresentation presentation = Presentation.Open(input);

                //Adds new node to the main node collection of the SmartArt.
                AddNodeInMainNodes(presentation);
                //Adds new node to the child node collection of the SmartArt.
                AddNodeInChildNodes(presentation);
                //Saves presentation with .pptx format.
                presentation.Save("SmartArtResave.pptx");
                if (System.Windows.MessageBox.Show("Do you want to view the generated PowerPoint Presentation?", "SmartArt Node Insertion",
                        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start("SmartArtResave.pptx");
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show("This Presentation could not be created, please contact Syncfusion Direct-Trac system at http://www.syncfusion.com/support/default.aspx for any queries. ", "OOPS..Sorry!",
                    MessageBoxButton.OK);
                this.Close();
            }
        }
        # region Slide1
        private void AddNodeInMainNodes(IPresentation presentation)
        {
            ISlide slide1 = presentation.Slides[0];
            ISmartArt smartArt = slide1.Shapes[0] as ISmartArt;
            smartArt.Background.FillType = FillType.Solid;
            smartArt.Background.SolidFill.Color = ColorObject.Lavender;
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
          
