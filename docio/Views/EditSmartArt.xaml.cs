#region Copyright Syncfusion Inc. 2001 - 2017
//
//  Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion
using System;
using System.Data;
using System.Windows;
using System.Windows.Media;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using System.IO;
using syncfusion.demoscommon.wpf;
using Syncfusion.Office;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditSmartArt : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public EditSmartArt()
        {
            InitializeComponent();
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {            
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        # region Events
        /// <summary>
        /// Creates word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get Template document and database path.
                string dataPath = @"Assets\DocIO\";

                //Loads the template document.
                WordDocument document = new WordDocument();
                document.OpenReadOnly(dataPath + "EditSmartArtInput.docx", FormatType.Automatic);

                //Gets the last paragraph in the document.
                WParagraph paragraph = document.LastParagraph;
                //Retrieves the SmartArt object from the paragraph.
                WSmartArt smartArt = paragraph.ChildEntities[0] as WSmartArt;
                //Sets the background fill type of the SmartArt to solid.
                smartArt.Background.FillType = OfficeShapeFillType.Solid;
                //Sets the background color of the SmartArt.
                smartArt.Background.SolidFill.Color = System.Drawing.Color.FromArgb(255, 242, 169, 132);
                //Gets the first node of the SmartArt.
                IOfficeSmartArtNode node = smartArt.Nodes[0];
                //Modifies the text content of the first node.
                node.TextBody.Text = "Goals";
                //Retrieves the first shape of the node.
                IOfficeSmartArtShape shape = node.Shapes[0];
                //Sets the fill color of the shape.
                shape.Fill.SolidFill.Color = System.Drawing.Color.FromArgb(255, 160, 43, 147);
                //Sets the line format color of the shape.
                shape.LineFormat.Fill.SolidFill.Color = System.Drawing.Color.FromArgb(255, 160, 43, 147);
                //Gets the first child node of the current node.
                IOfficeSmartArtNode childNode = node.ChildNodes[0];
                //Modifies the text content of the child node.
                childNode.TextBody.Text = "Set clear goals to the team.";
                //Sets the line format color of the first shape in the child node.
                childNode.Shapes[0].LineFormat.Fill.SolidFill.Color = System.Drawing.Color.FromArgb(255, 160, 43, 147);

                //Retrieves the second node in the SmartArt and updates its text content.
                node = smartArt.Nodes[1];
                node.TextBody.Text = "Progress";

                //Retrieves the third node in the SmartArt and updates its text content.
                node = smartArt.Nodes[2];
                node.TextBody.Text = "Result";
                //Retrieves the first shape of the third node.
                shape = node.Shapes[0];
                //Sets the fill color of the shape.
                shape.Fill.SolidFill.Color = System.Drawing.Color.FromArgb(255, 78, 167, 46);
                //Sets the line format color of the shape.
                shape.LineFormat.Fill.SolidFill.Color = System.Drawing.Color.FromArgb(255, 78, 167, 46);
                //Sets the line format color of the first shape in the child node.
                node.ChildNodes[0].Shapes[0].LineFormat.Fill.SolidFill.Color = System.Drawing.Color.FromArgb(255, 78, 167, 46);

                try
                {
                    //Saving the document as .docx
                    document.Save("EditSmartArt.docx", FormatType.Docx);
                    //Message box confirmation to view the created document.
                    if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo("EditSmartArt.docx") { UseShellExecute = true };
                            process.Start();
                        }
                        catch (Win32Exception ex)
                        {
                            MessageBox.Show("Microsoft Word Viewer or Microsoft Word is not installed in this system");
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex is IOException)
                        MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Update Fields.doc" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                } 
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        /// <summary>
        /// Opens the template document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to view the template document?", "Template document", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Get Template document and database path.            
                string dataPath = @"Assets\DocIO\";
                string path = System.IO.Path.Combine(dataPath, @"EditSmartArtInput.docx");
                //Opens the template document.
                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true };
                process.Start();
            }
        }
        # endregion
    }
}