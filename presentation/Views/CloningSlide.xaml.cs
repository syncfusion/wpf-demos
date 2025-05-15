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
    /// Interaction logic for CloningSlide.xaml
    /// </summary>
    public partial class CloningSlide : DemoControl
    {
        Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();

        public CloningSlide()
        {
            InitializeComponent();
            this.txtFile.Text = "Template.pptx";
            this.txtFile.Tag = @"Assets\Presentation\Template.pptx";
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


        private void destButton_Click(object sender, RoutedEventArgs e)
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

        private void btnGeneateDocument_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFile.Text))
                {
                    MessageBox.Show("Please browse the files to generate document", "Input missing", MessageBoxButton.OK);
                }
                else
                {
                    if (this.radioDestination.IsChecked == true)
                    {
                        //Creates presentation instance for source
                        IPresentation sourcePresentation = Presentation.Open(txtFile.Tag.ToString());

                        //Clones the first slide of the presentation
                        ISlide slide = sourcePresentation.Slides[0].Clone();

                        //Creates instance for the destination presentation
                        IPresentation destinationPresentation = Presentation.Open(destTextBox.Tag.ToString());

                        //Adding the cloned slide to the destination presentation by using Destination option.
                        destinationPresentation.Slides.Add(slide, PasteOptions.UseDestinationTheme, sourcePresentation);

                        //Closing the Source presentation
                        sourcePresentation.Close();

                        //Saving the Destination presentaiton.
                        destinationPresentation.Save("ClonedUsingDestination.pptx");

                        //Closing the destination presentation
                        destinationPresentation.Close();

                        if (MessageBox.Show("First slide is cloned and added as last slide to the Presentation,Do you want to view the resultant Presentation?", "Finished Cloning",
                                  MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo("ClonedUsingDestination.pptx") { UseShellExecute = true };
                            process.Start();
                        }
                    }
                    else
                    {
                        //Creates instance for the source presentation
                        IPresentation sourcePresentation = Presentation.Open(txtFile.Tag.ToString());

                        //Clones the first slide of the presentation
                        ISlide slide = sourcePresentation.Slides[0].Clone();

                        //Creates instance for the destination presentation
                        IPresentation destinationPresentation = Presentation.Open(destTextBox.Tag.ToString());

                        //Adding the cloned slide to the destination presentation by using Destination option.
                        destinationPresentation.Slides.Add(slide, PasteOptions.SourceFormatting, sourcePresentation);

                        //Closing the Source presentation
                        sourcePresentation.Close();

                        //Saving the Destination presentaiton.
                        destinationPresentation.Save("ClonedUsingSource.pptx");

                        //Closing the destinatin presentation
                        destinationPresentation.Close();

                        if (MessageBox.Show("First slide is cloned and added as last slide to the Presentation,Do you want to view the resultant Presentation?", "Finished Cloning",
                                  MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo("ClonedUsingSource.pptx") { UseShellExecute = true };
                            process.Start();
                        }
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Please close the generated Presentation", "File is open", MessageBoxButton.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("This file could not be cloned , please contact Syncfusion Direct-Trac system at http://www.syncfusion.com/support/default.aspx for any queries. ", "OOPS..Sorry!",
                        MessageBoxButton.OK);
            }
        }		    
    }
}





