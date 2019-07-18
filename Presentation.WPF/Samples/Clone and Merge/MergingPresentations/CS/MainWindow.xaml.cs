#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace Cloning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();

        public MainWindow()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();			
            string file = @"..\..\..\..\..\..\..\Common\Images\Presentation\ppt_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\Presentation\App.ico");
            this.txtFile1.Text = "MergeContent.pptx";
            this.txtFile1.Tag = @"..\..\..\..\..\..\..\Common\Data\Presentation\MergeContent.pptx";
            this.txtFile.Text = "Essential Presentation.pptx";
            this.txtFile.Tag = @"..\..\..\..\..\..\..\Common\Data\Presentation\Essential Presentation.pptx";
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.InitialDirectory = Path.GetFullPath(@"..\..\..\..\..\..\..\Common\Data\Presentation\");
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
            openFileDialog1.InitialDirectory = Path.GetFullPath(@"..\..\..\..\..\..\..\Common\Data\Presentation\");
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "PowerPoint Presentations|*.pptx";
            Nullable<bool> result = openFileDialog1.ShowDialog();

            //Get the selected file name and display in a TextBox
            if (result == true)
            {
                this.txtFile1.Text = openFileDialog1.SafeFileName;
                this.txtFile1.Tag = openFileDialog1.FileName;
            }
        }

        private void btnMergeDocument_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.radioDestination.IsChecked == true)
                {
                    //Creates instance for source presentation
                    IPresentation sourcePresentation = Presentation.Open(txtFile1.Tag.ToString());

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
                        System.Diagnostics.Process.Start("MergedUsingDestination.pptx");
                      
                    }
                }
                else
                {
                    //Creates instance for source presentation
                    IPresentation sourcePresentation = Presentation.Open(txtFile1.Tag.ToString());
                    //Creates instance for destination presentation
                    IPresentation destinationPresentation = Presentation.Open(txtFile.Tag.ToString());

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
                        System.Diagnostics.Process.Start("MergedUsingSource.pptx");
                        
                    }

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("This file could not be merged, please contact Syncfusion Direct-Trac system at http://www.syncfusion.com/support/default.aspx for any queries. ", "OOPS..Sorry!",
                        MessageBoxButton.OK);
                this.Close();
            }
        }			    
    }
}






