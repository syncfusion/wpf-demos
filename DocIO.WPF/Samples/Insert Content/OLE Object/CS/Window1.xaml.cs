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
using System.Windows.Media;

using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS ;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.IO;

namespace InsertOLE_Object_2009
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        public Window1()
        {
            InitializeComponent();
              ImageSourceConverter img = new ImageSourceConverter();
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon =(ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
}
        # region Events
        /// <summary>
        /// Insert OLE object from other document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WordDocument dest = new WordDocument();
                dest.EnsureMinimal();

                //Set page margin to the section
                dest.Sections[0].PageSetup.Margins.All = 72;

                WordDocument oleSource;
                if (worddoc.IsChecked.Value)
                    oleSource = new WordDocument(@"..\..\..\..\..\..\..\Common\Data\DocIO\OleTemplate.doc");
                else
                    oleSource = new WordDocument(@"..\..\..\..\..\..\..\Common\Data\DocIO\OleTemplate.docx");

                WOleObject oleObject = null;
                // Get OLE object from source document
                for (int i = 0; i < oleSource.LastSection.Paragraphs[4].Items.Count; i++)
                {
                    if (oleSource.LastSection.Paragraphs[4].Items[i] is WOleObject)
                    {
                        oleObject = oleSource.LastSection.Paragraphs[4].Items[i] as WOleObject;
                        break;
                    }
                }

                WPicture pic = oleObject.OlePicture.Clone() as WPicture;
                dest.LastParagraph.AppendText("OLE Object Demo");
                dest.LastParagraph.ApplyStyle(BuiltinStyle.Heading1);
                dest.LastParagraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;

                dest.Sections[0].AddParagraph();
                dest.LastParagraph.AppendText("MS Excel Object Inserted");
                dest.LastParagraph.ApplyStyle(BuiltinStyle.Heading2);

                dest.Sections[0].AddParagraph();
                // AppendOLE object to the destination document
                oleObject = dest.LastParagraph.AppendOleObject(oleObject.Container, pic, OleLinkType.Embed);

                oleObject.DisplayAsIcon = displayAsIcon.IsChecked.Value;

                #region Save
                //Save as doc format
                if (worddoc.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document to disk.
                        dest.Save("Sample.doc");

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
                        dest.Save("Sample.docx", FormatType.Docx);
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
                #endregion Save
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        #endregion Events
    }
}
