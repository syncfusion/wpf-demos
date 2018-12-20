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
using System.ComponentModel;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using Syncfusion.Windows.Shared;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;

namespace Watermark
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
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(radioPic.IsChecked.Value) && !(radioText.IsChecked.Value))
                    MessageBox.Show("Please select a watermark type", Title);

                else
                {
                    //Open an existing word document 
                    WordDocument doc = new WordDocument(@"..\..\..\..\..\..\..\Common\Data\DocIO\Watermark.doc");

                    if (radioText.IsChecked.Value)
                    {
                        //Add text watermark.
                        TextWatermark textWatermark = new TextWatermark();
                        doc.Watermark = textWatermark;

                        //Set the text for the watermark.
                        textWatermark.Text = "Demo";

                        //Set the color for the watermark text.
                        textWatermark.Color = System.Drawing.Color.Gray;

                        //Set the size.
                        textWatermark.Size = 120;
                    }

                    else if (radioPic.IsChecked.Value)
                    {
                        //Add Picture watermark to the word document.
                        PictureWatermark picWatermark = new PictureWatermark();
                        doc.Watermark = picWatermark;

                        //Set the picture.
                        picWatermark.Picture = System.Drawing.Image.FromFile(@"..\..\..\..\..\..\..\Common\Images\DocIO\Northwind_logo.png");

                        //Set the properties for the watermark.
                        picWatermark.Scaling = 100.0f;
                        picWatermark.Washout = false;
                    }

                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            doc.Save("Sample.doc");

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
                            doc.Save("Sample.docx", FormatType.Docx);
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

                    //Save as pdf format
                    else if (pdf.IsChecked.Value)
                    {
                        try
                        {
                            DocToPDFConverter converter = new DocToPDFConverter();
                            //Convert word document into PDF document
                            PdfDocument pdfDoc = converter.ConvertToPDF(doc);
                            //Save the pdf file
                            pdfDoc.Save("Sample.pdf");
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process.Start("Sample.pdf");
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
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        # endregion
    }
}
