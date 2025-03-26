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
using System.Windows.Resources;
using System.Reflection;

namespace syncfusion.presentationdemos.wpf
{
    /// <summary>
    /// Interaction logic for OLEObject.xaml
    /// </summary>
    public partial class OLEObject : DemoControl
    {

        public OLEObject()
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
            //New Instance of PowerPoint is Created.[Equivalent to launching MS PowerPoint with no slides].
            IPresentation presentation = Presentation.Create();
            //Add slide with titleonly layout to presentation
            ISlide slide = presentation.Slides.Add(SlideLayoutType.TitleOnly);
            //Get the title placeholder
            IShape titleShape = slide.Shapes[0] as IShape;
            //Set size and position of the title shape
            titleShape.Left = 0.65 * 72;
            titleShape.Top = 0.24 * 72;
            titleShape.Width = 11.5 * 72;
            titleShape.Height = 1.45 * 72;

            //Add title content
            titleShape.TextBody.AddParagraph("Ole Object");
            //Set the title content as bold
            titleShape.TextBody.Paragraphs[0].Font.Bold = true;
            //Set the horizontal alignment as center
            titleShape.TextBody.Paragraphs[0].HorizontalAlignment = HorizontalAlignmentType.Left;
            //Add text box of specific size and position
            IShape heading = slide.Shapes.AddTextBox(0.84 * 72, 1.65 * 72, 2.23 * 72, 0.51 * 72);
            //Add paragraph to text box
            heading.TextBody.AddParagraph("MS Word Object");
            //Set the text content as italic
            heading.TextBody.Paragraphs[0].Font.Italic = true;
            //Set the text content as bold
            heading.TextBody.Paragraphs[0].Font.Bold = true;
            //Set the font size
            heading.TextBody.Paragraphs[0].Font.FontSize = 18;

            string mswordPath = @"Assets\Presentation\OleTemplate.docx";

            //Get the word file as stream
            Stream wordStream = File.Open(mswordPath, FileMode.Open);
            //Image to be displayed, This can be any image
            Stream imageStream = GetFileStream("OlePicture.png");
            //Add ole object to the slide
            IOleObject oleObject = slide.Shapes.AddOleObject(imageStream, "Word.Document.12", wordStream);
            //Set size and position of the ole object
            oleObject.Left = 4.53 * 72;
            oleObject.Top = 0.79 * 72;
            oleObject.Width = 4.26 * 72;
            oleObject.Height = 5.92 * 72;
            //Set DisplayAsIcon as true, to open the embedded document in separate (default) application.
            oleObject.DisplayAsIcon = true;
            //Save the presentation
            presentation.Save("OLEObject.pptx");
            //Close the presentation
            presentation.Close();

            if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("OLEObject.pptx") { UseShellExecute = true };
                process.Start();
            }
        }

        private void btnOpenEmbeddedFile_Click(object sender, EventArgs e)
        {
            string filePath = @"Assets\Presentation\EmbeddedOleObject.pptx";

            IPresentation pptxDoc = Presentation.Open(filePath);
            //Gets the first slide of the Presentation
            ISlide slide = pptxDoc.Slides[0];
            //Gets the Ole Object of the slide
            IOleObject oleObject = slide.Shapes[2] as IOleObject;
            //Gets the file data of embedded Ole Object
            byte[] array = oleObject.ObjectData;
            //Gets the file name of embedded Ole Object
            string outputFile = oleObject.FileName;

            //Save the extracted Ole data into file system
            MemoryStream memoryStream = new MemoryStream(array);
            FileStream fileStream = File.Create(outputFile);
            memoryStream.CopyTo(fileStream);
            memoryStream.Dispose();
            fileStream.Dispose();
            //Close the presentation
            pptxDoc.Close();

            if (System.Windows.MessageBox.Show("Do you want to view the extracted Embedded file?", "Extracted Embedded OLE File",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(outputFile) { UseShellExecute = true };
                process.Start();
            }
        }
        
        private Stream GetFileStream(string fileName)
        {
            Assembly assembly = typeof(OLEObject).Assembly;
            return assembly.GetManifestResourceStream("syncfusion.presentationdemos.wpf.Assets.Presentation." + fileName);
        }
    }
}