#region Copyright Syncfusion Inc. 2001 - 2017
//
//  Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
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
using Syncfusion.PresentationToPdfConverter;
using Syncfusion.Pdf;
using System.Diagnostics;
using System.IO;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.presentationdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FindAndHighlight : DemoControl
    {
        #region Private Members
        bool matchCase, wholeWord, highlightFirstOccurrence;
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public FindAndHighlight()
        {
            InitializeComponent();
#if FindAndHighlight_2008
            btnCreatePresentation.Visibility = Visibility.Hidden;
            btnPresentationToPDF.Visibility = Visibility.Hidden;
#endif
            this.textFind.Text = "product";
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Events
        /// <summary>
        /// Creates PowerPoint document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
			 if (textFind.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the find and hightlight text in the appropriate textbox.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string input = @"Assets\Presentation\FindAndHighlightInput.pptx";

            using (IPresentation presentation = Presentation.Open(input))
            {
                //Highlight only the first occurrence of the text
                if (highlightFirstOccurrence)
                {
                    //Finds the first occurrence of a particular text
                    ITextSelection textSelection = presentation.Find(textFind.Text, matchCase, wholeWord);
                    if (textSelection != null)
                    {
                        //Gets the found text containing text parts
                        foreach (ITextPart textPart in textSelection.GetTextParts())
                        {
                            //Sets highlight color
                            textPart.Font.HighlightColor = ColorObject.Yellow;
                        }
                    }
                }
                else
                {
                    //Finds all the occurrences of a particular text
                    ITextSelection[] textSelections = presentation.FindAll(textFind.Text, matchCase, wholeWord);
                    if (textSelections != null)
                    {
                        foreach (ITextSelection textSelection in textSelections)
                        {
                            //Gets the found text containing text parts
                            foreach (ITextPart textPart in textSelection.GetTextParts())
                            {
                                //Sets highlight color
                                textPart.Font.HighlightColor = ColorObject.Yellow;
                            }
                        }
                    }
                }
                if (btnCreatePresentation.IsChecked.Value)
                {
                    
                    //Saves the presentation
                    presentation.Save("FindAndHightlight.pptx");

                    if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("FindAndHightlight.pptx") { UseShellExecute = true };
                        process.Start();
                    }
                }

                else if (btnPresentationToPDF.IsChecked.Value)
                {
                    //presentation.ChartToImageConverter = new ChartToImageConverter();
                    PresentationToPdfConverterSettings settings = new PresentationToPdfConverterSettings();
                    using (PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation, settings))
                    {
                        pdfDocument.Save("FindAndHightlight.pdf");
                    }
                    if (System.Windows.MessageBox.Show("Do you want to view the generated Pdf?", "PDF Created",
                        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("FindAndHightlight.pdf") { UseShellExecute = true };
                        process.Start();
                    }
                }
            }
        }

        /// <summary>
        /// Toggles between case sensitive and insensitive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxCase_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxCase.IsChecked.Value)
                matchCase = true;
            else
                matchCase = false;
        }

        /// <summary>
        /// Toggles whole word.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxWord_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxWord.IsChecked.Value)
                wholeWord = true;
            else
                wholeWord = false;
        }
        /// <summary>
        /// Toggles First Occurrence word.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxFirstWord_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxFirstWord.IsChecked.Value)
                highlightFirstOccurrence = true;
            else
                highlightFirstOccurrence = false;
        }
        # endregion
    }
}