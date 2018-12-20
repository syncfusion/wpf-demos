#region Copyright Syncfusion Inc. 2001 - 2018
//
//  Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion
using System;
using System.Windows;
using System.Windows.Media;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.IO;

namespace DocumentProtection
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon =(ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");        
		}
        # endregion

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
                string dataPath = @"..\..\..\..\..\..\..\Common\Data\DocIO\";
                WordDocument document;
                ProtectionType protectionType;

                //Loads the template document.
                if (comboBox1.SelectedIndex == 0)
                {
                    document = new WordDocument(dataPath + "TemplateFormFields.doc");
                    // Sets the protection type as allow only Form Fields.
                    protectionType = ProtectionType.AllowOnlyFormFields;
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    document = new WordDocument(dataPath + "TemplateComments.doc");
                    // Sets the protection type as allow only Comments.
                    protectionType = ProtectionType.AllowOnlyComments;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    document = new WordDocument(dataPath + "TemplateRevisions.doc");
                    // Enables track changes in the document.
                    document.TrackChanges = true;
                    // Sets the protection type as allow only Revisions.
                    protectionType = ProtectionType.AllowOnlyRevisions;
                }
                else
                {
                    document = new WordDocument(dataPath + "Essential DocIO.doc");
                    // Sets the protection type as allow only Reading.
                    protectionType = ProtectionType.AllowOnlyReading;
                }

                // Enforces protection of the document.
                if (string.IsNullOrEmpty(passwordBox1.Password))
                    document.Protect(protectionType);
                else
                    document.Protect(protectionType, passwordBox1.Password);

                //Save as doc format
                if (worddoc.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document to disk.
                        document.Save("Sample.doc");

                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process.Start("Sample.doc");
                                //Exit
                                this.Close();
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.doc" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting"+ "\r\n" + ex.ToString(), "Error",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                //Save as docx format
                else if (worddocx.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document as .docx
                        document.Save("Sample.docx", FormatType.Docx);
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process.Start("Sample.docx");
                                //Exit
                                this.Close();
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.doc" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting"+ "\r\n" + ex.ToString(), "Error",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    // Exit
                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        # endregion
    }
}