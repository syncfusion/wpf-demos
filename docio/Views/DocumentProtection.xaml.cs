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
using System.Windows;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using System.IO;
using syncfusion.demoscommon.wpf;
using System.Windows.Controls;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DocumentProtection : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public DocumentProtection()
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

                WordDocument document;
                ProtectionType protectionType;

                //Loads the template document.
                if (comboBox1.SelectedIndex == 0)
                {
                    document = new WordDocument(dataPath + "TemplateFormFields.docx");
                    // Sets the protection type as allow only Form Fields.
                    protectionType = ProtectionType.AllowOnlyFormFields;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    document = new WordDocument(dataPath + "TemplateComments.docx");
                    // If the "Make part of the document editable for everyone" checkbox is checked,
                    // add editable ranges to allow unrestricted editing in specific sections.
                    if (checkBox.IsChecked == true)
                        AddEditableRange(document);
                    // Sets the protection type as allow only Comments.
                    protectionType = ProtectionType.AllowOnlyComments;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    document = new WordDocument(dataPath + "TemplateRevisions.docx");
                    // Enables track changes in the document.
                    document.TrackChanges = true;
                    // Sets the protection type as allow only Revisions.
                    protectionType = ProtectionType.AllowOnlyRevisions;
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    document = new WordDocument(dataPath + "TemplateReading.docx");
                    // If the "Make part of the document editable for everyone" checkbox is checked,
                    // add editable ranges to allow unrestricted editing in specific sections.
                    if (checkBox.IsChecked == true)
                        AddEditableRange(document);
                    // Sets the protection type as allow only Reading.
                    protectionType = ProtectionType.AllowOnlyReading;
                }
                else
                {
                    document = new WordDocument(dataPath + "TemplateFormFields.docx");
                    // Sets the protection type as allow only Form Fields.
                    protectionType = ProtectionType.AllowOnlyFormFields;
                }

                // Enforces protection of the document.
                if (string.IsNullOrEmpty(passwordBox1.Password))
                    document.Protect(protectionType);
                else
                    document.Protect(protectionType, passwordBox1.Password);

                //Saving the document as .docx
                document.Save(comboBox1.Text + ".docx", FormatType.Docx);
                //Message box confirmation to view the created document.
                if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo(comboBox1.Text + ".docx") { UseShellExecute = true };
                        process.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Microsoft Word Viewer or Microsoft Word is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
                document.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ComboBoxSelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            // Add null check for safety since this is called during initialization
            if (checkBox == null || comboBox1 == null)
                return;

            string selectedProtection = (comboBox1.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Enable and check checkbox only for specific protection types
            if (selectedProtection == "AllowOnlyReading" || selectedProtection == "AllowOnlyComments")
            {
                checkBox.IsEnabled = true;
                checkBox.IsChecked = true;
            }
            else
            {
                checkBox.IsEnabled = false;
                checkBox.IsChecked = false;
            }
        }
        private void AddEditableRange(WordDocument document)
        {
           // Access the paragraph
           WParagraph paragraph = document.Sections[0].Body.ChildEntities[5] as WParagraph;
           // Create a new editable range start
           EditableRangeStart editableRangeStart = new EditableRangeStart(document);
           // Insert the editable range start at the beginning of the selected paragraph
           paragraph.ChildEntities.Insert(0, editableRangeStart);
           // Set the editor group for the editable range to allow everyone to edit
           editableRangeStart.EditorGroup = EditorType.Everyone;
           // Append an editable range end to close the editable region
           paragraph.AppendEditableRangeEnd();

           // Access the first table in the first section of the document
           WTable table = document.Sections[0].Tables[0] as WTable;
           // Access the paragraph in the third row and third column of the table
           paragraph = table[2, 2].ChildEntities[0] as WParagraph;
           // Create a new editable range start for the table cell paragraph
           editableRangeStart = new EditableRangeStart(document);
           // Insert the editable range start at the beginning of the paragraph
           paragraph.ChildEntities.Insert(0, editableRangeStart);
           // Set the editor group for the editable range to allow everyone to edit
           editableRangeStart.EditorGroup = EditorType.Everyone;
           // Apply editable range to second column only
           editableRangeStart.FirstColumn = 1;
           editableRangeStart.LastColumn = 1;
           // Access the paragraph
           paragraph = table[5, 2].ChildEntities[0] as WParagraph;
           // Append an editable range end to close the editable region
           paragraph.AppendEditableRangeEnd();
        }
        #endregion
    }
}