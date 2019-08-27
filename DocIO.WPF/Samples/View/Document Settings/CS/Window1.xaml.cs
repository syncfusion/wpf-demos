#region Copyright Syncfusion Inc. 2001 - 2019
//
//  Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using System.Drawing;
using Syncfusion.Windows.Shared;
using System.IO;

namespace Document_Properties
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
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
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
                //A new document is created.
                WordDocument document = new WordDocument();

                //Adding a section to the document.
                IWSection section = document.AddSection();

                //Adding a paragraph to the section.			
                IWParagraph paragraph = section.AddParagraph();

                #region DocVariable
                string name = "John Smith";
                string address = "Cary, NC";
                //Gets the variables in the existing document
                DocVariables dVariable = document.Variables;
                //Add doc variables
                dVariable.Add("Customer Name", name);
                dVariable.Add("Customer Address", address);
                #endregion DocVariable

                #region Document Properties
                //Setting document Properties
                document.BuiltinDocumentProperties.Author = "Essential DocIO";
                document.BuiltinDocumentProperties.ApplicationName = "Essential DocIO";
                document.BuiltinDocumentProperties.Category = "Document Generator";
                document.BuiltinDocumentProperties.Comments = "This document was generated using Essential DocIO";
                document.BuiltinDocumentProperties.Company = "Syncfusion Inc";
                document.BuiltinDocumentProperties.Subject = "Native Word Generator";
                document.BuiltinDocumentProperties.Keywords = "Syncfusion";
                document.BuiltinDocumentProperties.Manager = "Sync Manager";
                document.BuiltinDocumentProperties.Title = "Essential DocIO";

                // Add a custom document Property
                document.CustomDocumentProperties.Add("My_Doc_Date", DateTime.Today);
                document.CustomDocumentProperties.Add("My_Doc", true);
                document.CustomDocumentProperties.Add("My_ID", 1031);
                document.CustomDocumentProperties.Add("My_Comment", "Essential DocIO");
                //Remove a custome property
                document.CustomDocumentProperties.Remove("My_Doc");

                #endregion

                IWTextRange text = paragraph.AppendText("");
                text.CharacterFormat.FontName = "Calibri";
                text.CharacterFormat.FontSize = 13;
                text = paragraph.AppendText("This document is created with various Document Properties Summary Information and page settings information \n\n You can view Document Properties through: File -> Properties -> Summary/Custom.");
                text.CharacterFormat.FontName = "Calibri";
                text.CharacterFormat.FontSize = 13;

                #region Page setup

                // Write section properties
                section.PageSetup.PageSize = new SizeF(500, 750);
                section.PageSetup.Orientation = PageOrientation.Landscape;
                section.PageSetup.Margins.Bottom = 100;
                section.PageSetup.Margins.Top = 100;
                section.PageSetup.Margins.Left = 50;
                section.PageSetup.Margins.Right = 50;
                section.PageSetup.PageBordersApplyType = PageBordersApplyType.AllPages;
                section.PageSetup.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.DoubleWave;
                section.PageSetup.Borders.Color = System.Drawing.Color.DarkBlue;
                section.PageSetup.VerticalAlignment = PageAlignment.Middle;

                #endregion

                paragraph = section.AddParagraph();
                text = paragraph.AppendText("");
                text.CharacterFormat.FontName = "Calibri";
                text.CharacterFormat.FontSize = 13;

                text = paragraph.AppendText("\n\n You can view Page setup options through File -> PageSetup.");
                text.CharacterFormat.FontName = "Calibri";
                text.CharacterFormat.FontSize = 13;

                #region Get document variables
                paragraph = document.LastSection.AddParagraph();
                dVariable = document.Variables;
                text = paragraph.AppendText("\n\n Document Variables\n");
                text.CharacterFormat.FontName = "Calibri";
                text.CharacterFormat.FontSize = 13;
                text.CharacterFormat.Bold = true;
                text = paragraph.AppendText("\n" + dVariable.GetNameByIndex(1) + ": " + dVariable.GetValueByIndex(1));
                text.CharacterFormat.FontName = "Calibri";
                text.CharacterFormat.FontSize = 13;
                //Display the current variable count
                text = paragraph.AppendText("\n\nDocument Variables Count: " + dVariable.Count);
                text.CharacterFormat.FontName = "Calibri";
                text.CharacterFormat.FontSize = 13;

                #endregion Get document variables


                # region Save Document
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
                # endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        # endregion
    }
}