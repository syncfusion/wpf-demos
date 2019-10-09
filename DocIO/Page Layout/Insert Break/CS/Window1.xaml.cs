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
using System.ComponentModel;
using System.IO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using Syncfusion.Windows.Shared;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;

namespace InsertBreak
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
#if NETCORE
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");                      
#else
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
#endif
        }
        # endregion

        # region Events
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Getting Image files Path.                 
#if NETCORE
                string dataPath = @"..\..\..\..\..\..\..\Common\Images\DocIO";
#else
                string dataPath = @"..\..\..\..\..\..\Common\Images\DocIO";
#endif
                //Creating a new document
                WordDocument document = new WordDocument();
                //Adding a new section.
                IWSection section = document.AddSection();
                IWParagraph paragraph = section.AddParagraph();
                paragraph = section.AddParagraph();
                section.PageSetup.Margins.All = 72f;
                IWTextRange text = paragraph.AppendText("Adventure products");
                //Formatting Text
                text.CharacterFormat.FontName = "Bitstream Vera Sans";
                text.CharacterFormat.FontSize = 12f;
                text.CharacterFormat.Bold = true;
                section.AddParagraph();
                paragraph = section.AddParagraph();
                paragraph.ParagraphFormat.LineSpacing = 20f;
                paragraph.AppendText("In 2000, Adventure Works Cycles bought a small manufacturing plant, Importadores Neptuno, located in Mexico. Importadores Neptuno manufactures several critical subcomponents for the Adventure Works Cycles product line. These subcomponents are shipped to the Bothell location for final product assembly. In 2001, Importadores Neptuno, became the sole manufacturer and distributor of the touring bicycle product group ");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Justify;

                #region Line break
                paragraph.AppendBreak(BreakType.LineBreak);
                paragraph.AppendBreak(BreakType.LineBreak);
                #endregion

                section = document.AddSection();

                section.BreakCode = SectionBreakCode.NoBreak;
                section.PageSetup.Margins.All = 72f;
                //Adding three columns to section.
                section.AddColumn(100, 15);
                section.AddColumn(100, 15);
                section.AddColumn(100, 15);
                //Set the columns to be of equal width.
                section.MakeColumnsEqual();

                //Adding a new paragraph to the section.
                paragraph = section.AddParagraph();
                //Adding text.
                text = paragraph.AppendText("Mountain-200");
                //Formatting Text
                text.CharacterFormat.FontName = "Bitstream Vera Sans";
                text.CharacterFormat.FontSize = 12f;
                text.CharacterFormat.Bold = true;
                //Adding a new paragraph to the section.
                section.AddParagraph();
                paragraph = section.AddParagraph();
                //Inserting an Image.
                WPicture picture = paragraph.AppendPicture(new System.Drawing.Bitmap(System.IO.Path.Combine(dataPath, "Mountain-200.jpg"))) as WPicture;
                picture.Width = 120f;
                picture.Height = 90f;
                //Adding a new paragraph to the section.
                section.AddParagraph();
                paragraph = section.AddParagraph();
                paragraph.ParagraphFormat.LineSpacing = 20f;
                //Adding text.           
                paragraph.AppendText(@"Product No:BK-M68B-38" + "\n" + "Size: 38" + "\n" + "Weight: 25\n" + "Price: $2,294.99");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Justify;

                // Set column break as true. It navigates the cursor position to the next Column.
                paragraph.ParagraphFormat.ColumnBreakAfter = true;

                paragraph = section.AddParagraph();
                text = paragraph.AppendText("Mountain-300");
                text.CharacterFormat.FontName = "Bitstream Vera Sans";
                text.CharacterFormat.FontSize = 12f;
                text.CharacterFormat.Bold = true;

                section.AddParagraph();
                paragraph = section.AddParagraph();
                picture = paragraph.AppendPicture(new System.Drawing.Bitmap(System.IO.Path.Combine(dataPath, "Mountain-300.jpg"))) as WPicture;
                picture.Width = 120f;
                picture.Height = 90f;
                section.AddParagraph();
                paragraph = section.AddParagraph();
                paragraph.ParagraphFormat.LineSpacing = 20f;
                paragraph.AppendText(@"Product No:BK-M4-38" + "\n" + "Size: 35\n" + "Weight: 22" + "\n" + "Price: $1,079.99");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Justify;

                paragraph.ParagraphFormat.ColumnBreakAfter = true;

                paragraph = section.AddParagraph();
                text = paragraph.AppendText("Road-150");
                text.CharacterFormat.FontName = "Bitstream Vera Sans";
                text.CharacterFormat.FontSize = 12f;
                text.CharacterFormat.Bold = true;

                section.AddParagraph();
                paragraph = section.AddParagraph();
                picture = paragraph.AppendPicture(new System.Drawing.Bitmap(System.IO.Path.Combine(dataPath, "Road-550-W.jpg"))) as WPicture;
                picture.Width = 120f;
                picture.Height = 90f;
                section.AddParagraph();
                paragraph = section.AddParagraph();
                paragraph.ParagraphFormat.LineSpacing = 20f;
                paragraph.AppendText(@"Product No: BK-R93R-44" + "\n" + "Size: 44" + "\n" + "Weight: 14" + "\n" + "Price: $3,578.27");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Justify;

                section = document.AddSection();
                section.BreakCode = SectionBreakCode.NoBreak;
                section.PageSetup.Margins.All = 72f;

                text = section.AddParagraph().AppendText("First Look\n");
                //Formatting Text
                text.CharacterFormat.FontName = "Bitstream Vera Sans";
                text.CharacterFormat.FontSize = 12f;
                text.CharacterFormat.Bold = true;

                paragraph = section.AddParagraph();
                paragraph.ParagraphFormat.LineSpacing = 20f;
                paragraph.AppendText("Adventure Works Cycles, the fictitious company, is a large, multinational manufacturing company. The company manufactures and sells metal and composite bicycles to North American, European and Asian commercial markets. While its base operation is located in Bothell, Washington with 290 employees, several regional sales teams are located throughout their market base.");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Justify;
                paragraph.ParagraphFormat.PageBreakAfter = true;

                paragraph = section.AddParagraph();
                text = paragraph.AppendText("Introduction\n");
                //Formatting Text
                text.CharacterFormat.FontName = "Bitstream Vera Sans";
                text.CharacterFormat.FontSize = 12f;
                text.CharacterFormat.Bold = true;
                paragraph = section.AddParagraph();
                paragraph.ParagraphFormat.LineSpacing = 20f;
                paragraph.AppendText("In 2000, Adventure Works Cycles bought a small manufacturing plant, Importadores Neptuno, located in Mexico. Importadores Neptuno manufactures several critical subcomponents for the Adventure Works Cycles product line. These subcomponents are shipped to the Bothell location for final product assembly. In 2001, Importadores Neptuno, became the sole manufacturer and distributor of the touring bicycle product group.");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Justify;

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
#if NETCORE
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.doc") { UseShellExecute = true };
                                process.Start();
#else
                                System.Diagnostics.Process.Start("Sample.doc");
#endif
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
#if NETCORE
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.docx") { UseShellExecute = true };
                                process.Start();
#else
                                System.Diagnostics.Process.Start("Sample.docx");
#endif
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

                //Save as pdf format
                else if (pdf.IsChecked.Value)
                {
                    try
                    {
                        DocToPDFConverter converter = new DocToPDFConverter();
                        //Convert word document into PDF document
                        PdfDocument pdfDoc = converter.ConvertToPDF(document);
                        //Save the pdf file
                        pdfDoc.Save("Sample.pdf");
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
#if NETCORE
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.pdf") { UseShellExecute = true };
                                process.Start();
#else
                                System.Diagnostics.Process.Start("Sample.pdf");
#endif
                                //Exit
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("PDF Viewer is not installed in this system");
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