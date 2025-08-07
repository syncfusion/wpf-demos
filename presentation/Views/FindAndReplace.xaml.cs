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
using System.Diagnostics;
using System.IO;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace syncfusion.presentationdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FindAndReplace : DemoControl
    {
        # region Private Members
        string pptxFileName = null;
        bool matchCase, wholeWord, replaceFirstOccurrence;
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public FindAndReplace()
        {
            InitializeComponent();
            // Initialize variables.
            matchCase = false;
            wholeWord = false;
            replaceFirstOccurrence = false;
            this.textLook.Text = "Input Template.pptx";
            this.textFind.Text = "{product}";
            this.regexFind.Text = "{[A-Za-z]+}";
            this.textReplace.Text = "Service";
            pptxFileName = @"Assets\Presentation\Input Template.pptx";
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
        /// Replaces the text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplace_Click(object sender, RoutedEventArgs e)
        {
            // Checking whether the find and replacement text boxes are filled.
            if (textLook.Text.Trim() == "")
            {
                MessageBox.Show("Browse a file to perform find and replace functionality", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (textFind.Text.Trim() == "" && textReplace.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the find and replacement text in appropriate textboxes...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (textFind.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the find text in the appropriate textbox.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (regexFind.Text.Trim() == "" && textReplace.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the find regex and replacement text in appropriate textboxes...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (regexFind.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the find regex in the appropriate textbox.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (textReplace.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the replace text in the appropriate textbox.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            using (IPresentation presentation = Presentation.Open(pptxFileName))
            {
                //Replaces only the first occurrence of the text
                if (replaceFirstOccurrence)
                {
                    ITextSelection textSelection = null;
                    if (comboBoxFindUsing.SelectedIndex == 0)
                    {
                        //Finds the first occurrence of a particular text
                        textSelection = presentation.Find(textFind.Text, matchCase, wholeWord);
                    }
                    else
                    {
                        //Finds the first occurrence of a particular pattern
                        textSelection = presentation.Find(new Regex(regexFind.Text));
                    }   
                    if(textSelection != null)
                    {
                        //Gets the found text as single text part
                        ITextPart textPart = textSelection.GetAsOneTextPart();
                        //Replace the text
                        textPart.Text = textReplace.Text;
                    }
                }
                else
                {
                    ITextSelection[] textSelections = null;
                    if (comboBoxFindUsing.SelectedIndex == 0)
                    {
                        //Finds all the occurrences of a particular text
                        textSelections = presentation.FindAll(textFind.Text, matchCase, wholeWord);
                    }
                    else
                    {
                        //Finds all the occurrences of a particular pattern
                        textSelections = presentation.FindAll(new Regex(regexFind.Text));
                    }
                    if (textSelections != null)
                    {
                        foreach (ITextSelection textSelection in textSelections)
                        {
                            //Gets the found text as single text part
                            ITextPart textPart = textSelection.GetAsOneTextPart();
                            //Replace the text
                            textPart.Text = textReplace.Text;
                        }
                    }
                }
                //Saves the presentation
                presentation.Save("FindAndReplace.pptx");
            }

            if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                  MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("FindAndReplace.pptx") { UseShellExecute = true };
                process.Start();
            }
            
        }

        /// <summary>
        /// Gets the input file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // Create a openfile dialog box for open an existing Powerpoint document.
            OpenFileDialog file = new OpenFileDialog();
            // set the file filter type as document.
            file.Filter = "Document Files (*.ppt)|*.pptx";
            // Show the open file dialog box.
            if (file.ShowDialog().Value)
            {
                pptxFileName = file.FileName;
                textLook.Text = System.IO.Path.GetFileName(pptxFileName);
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
                replaceFirstOccurrence = true;
            else
                replaceFirstOccurrence = false;
        }
        /// <summary>
        /// Modifies the required changes if combo box value changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            //If none author selected disable the radio button, otherwise enabled
            if (comboBoxFindUsing.SelectedIndex != 0)
            {
                if (checkBoxCase != null || checkBoxFirstWord != null || checkBoxWord != null)
                {
                    checkBoxCase.IsChecked = false;
                    checkBoxFirstWord.IsChecked = false;
                    checkBoxWord.IsChecked = false;
                    checkBoxCase.IsEnabled = false;
                    checkBoxWord.IsEnabled = false;
                    checkBoxFirstWord.IsChecked = false;
                }
                if (regexFind != null && TextBlock7 != null)
                {
                    regexFind.Visibility = Visibility.Visible;
                    TextBlock7.Visibility = Visibility.Visible;
                    textFind.Visibility = Visibility.Hidden;
                    TextBlock6.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                if (checkBoxCase != null || checkBoxFirstWord != null || checkBoxWord != null)
                {
                    checkBoxCase.IsChecked = false;
                    checkBoxFirstWord.IsChecked = false;
                    checkBoxWord.IsChecked = false;
                    checkBoxCase.IsEnabled = true;
                    checkBoxWord.IsEnabled = true;
                }
                if(regexFind != null && TextBlock7 != null)
                {
                    regexFind.Visibility = Visibility.Hidden;
                    TextBlock7.Visibility = Visibility.Hidden;
                    textFind.Visibility = Visibility.Visible;
                    TextBlock6.Visibility = Visibility.Visible;
                }
            }
        }
        #endregion
    }
}