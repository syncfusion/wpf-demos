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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MergingPresentation : DemoControl
    {
        Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();

        public MergingPresentation()
        {
            InitializeComponent();
            
            this.txtFile.Text = "MergeContent.pptx";
            this.txtFile.Tag = @"Assets\Presentation\MergeContent.pptx";
            this.destTextBox.Text = "Essential Presentation.pptx";
            this.destTextBox.Tag = @"Assets\Presentation\Essential Presentation.pptx";
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

        private void btnBrowse1_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.InitialDirectory = Path.GetFullPath(@"Assets\Presentation\");

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "PowerPoint Presentations|*.pptx";
            Nullable<bool> result = openFileDialog1.ShowDialog();

            //Get the selected file name and display in a TextBox
            if (result == true)
            {
                this.destTextBox.Text = openFileDialog1.SafeFileName;
                this.destTextBox.Tag = openFileDialog1.FileName;
            }
        }

        private void btnMergeDocument_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.radioDestination.IsChecked == true)
                {
                    //Creates instance for source presentation
                    IPresentation sourcePresentation = Presentation.Open(destTextBox.Tag.ToString());

                    //Creates instance for destination presentation
                    IPresentation destinationPresentation = Presentation.Open(txtFile.Tag.ToString());

                    ISlides slides = sourcePresentation.Slides;

                    foreach (ISlide slide in slides)
                    {
                        //Clones the slides from source to destination
                        destinationPresentation.Slides.Add(slide.Clone(), PasteOptions.UseDestinationTheme, sourcePresentation);
                    }

                    //Closing the Source presentation
                    sourcePresentation.Close();

                    //Saving the Destination presentaiton.
                    destinationPresentation.Save("MergedUsingDestination.pptx");

                    destinationPresentation.Close();
                    if (System.Windows.MessageBox.Show("Do you want to view the merged PowerPoint Presentation?", "Finished Merging",
                              MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("MergedUsingDestination.pptx") { UseShellExecute = true };
                        process.Start();
                    }
                }
                else
                {
                    //Creates instance for source presentation
                    IPresentation sourcePresentation = Presentation.Open(txtFile.Tag.ToString());
                    //Creates instance for destination presentation
                    IPresentation destinationPresentation = Presentation.Open(destTextBox.Tag.ToString());

                    ISlides slides = sourcePresentation.Slides;

                    foreach (ISlide slide in slides)
                    {
                        //Clones the slides from source to destination
                        destinationPresentation.Slides.Add(slide.Clone(), PasteOptions.SourceFormatting, sourcePresentation);
                    }

                    //Closing the Source presentation
                    sourcePresentation.Close();

                    //Saving the Destination presentaiton.
                    destinationPresentation.Save("MergedUsingSource.pptx");

                    //Closing the destination presentation
                    destinationPresentation.Close();

                    if (System.Windows.MessageBox.Show("Do you want to view the merged PowerPoint Presentation?", "Finished Merging",
                               MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("MergedUsingSource.pptx") { UseShellExecute = true };
                        process.Start();
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("This file could not be merged, please contact Syncfusion Direct-Trac system at http://www.syncfusion.com/support/default.aspx for any queries. ", "OOPS..Sorry!",
                        MessageBoxButton.OK);
            }
        }			    
    }
}






