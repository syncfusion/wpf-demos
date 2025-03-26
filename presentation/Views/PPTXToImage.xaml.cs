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
    /// Interaction logic for PPTXToImage.xaml
    /// </summary>
    public partial class PPTXToImage : DemoControl
    {
        public PPTXToImage()
        {
            InitializeComponent();
            this.txtFile.Text = "Input_Template.pptx";
            this.txtFile.Tag = @"Assets\Presentation\Input_Template.pptx";
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
            openFileDialog1.InitialDirectory = Path.GetFullPath(@"Assets\Presentation\");
            openFileDialog1.FileName = "";
			openFileDialog1.Filter = "PowerPoint Presentations|*.pptx";
            Nullable<bool> result = openFileDialog1.ShowDialog();

            //Get the selected file name and display in a TextBox
            if (result == true)
            {
                this.txtFile.Text = openFileDialog1.SafeFileName;
                this.txtFile.Tag = openFileDialog1.FileName;
            }
        }


        private void btnCreateImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = 1;
                string path = null;
                //Opens the specified presentation
                using (IPresentation presentation = Presentation.Open(txtFile.Tag.ToString()))
                {
                    //Gets all the slides in presentation and manipulates one by one
                    foreach (ISlide slide in presentation.Slides)
                    {
                        //Converts slide to image
                        using (Image image = Image.FromStream(slide.ConvertToImage(Syncfusion.Drawing.ImageFormat.Emf)))
                        {
                            //Gets the file name without extension from the textbox.
                            string name = Path.GetFileNameWithoutExtension(txtFile.Tag.ToString());
                            string fileName = Path.GetFullPath("Output/") + name;
                            Directory.CreateDirectory(fileName);
                            fileName = fileName + "/" + name + i++ + ".png";

                            //Saves the image
                            image.Save(fileName);
                            if (i == 2)
                                path = fileName;
                        }
                    }
                }
                    
                if (System.Windows.MessageBox.Show("Do you want to view the converted images?", "PPTX To Image",
                        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true };
                    process.Start();
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("This file could not be converted, please contact Syncfusion Direct-Trac system at http://www.syncfusion.com/support/default.aspx for any queries. ", "OOPS..Sorry!",
                    MessageBoxButton.OK);
            }
        }
    }    
        
}
          
