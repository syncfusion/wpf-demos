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
using Syncfusion.Windows.Shared;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;

namespace HelloWorld
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
                //Initialize Word document
                WordDocument doc = new WordDocument();
                //Ensure Minimum
                doc.EnsureMinimal();
                //Set margins for page.
                doc.LastSection.PageSetup.Margins.All = 72;
                //Create new group shape
                GroupShape groupShape = new GroupShape(doc);

                //Append AutoShape
                Shape shape = new Shape(doc, AutoShapeType.RoundedRectangle);
                shape.Width = 130;
                shape.Height = 45;
                //Set horizontal origin
                shape.HorizontalOrigin = HorizontalOrigin.Page;
                //Set vertical origin
                shape.VerticalOrigin = VerticalOrigin.Page;
                //Set vertical position
                shape.VerticalPosition = 122;
                //Set horizontal position
                shape.HorizontalPosition = 220;
                //Set AllowOverlap to true for overlapping shapes
                shape.WrapFormat.AllowOverlap = true;
                //Set Fill Color
                shape.FillFormat.Color = System.Drawing.Color.Blue;
                //Set Content vertical alignment
                shape.TextFrame.TextVerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                //Add Texbody contents to Shape
                IWParagraph para = shape.TextBody.AddParagraph();
                para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                para.AppendText("Requirement").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = System.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });
                groupShape.Add(shape);

                shape = new Shape(doc, AutoShapeType.DownArrow);
                shape.Width = 45;
                shape.Height = 45;
                shape.HorizontalOrigin = HorizontalOrigin.Page;
                shape.VerticalOrigin = VerticalOrigin.Page;
                shape.VerticalPosition = 167;
                //Set horizontal position
                shape.HorizontalPosition = 265;
                shape.WrapFormat.AllowOverlap = true;
                groupShape.Add(shape);

                shape = new Shape(doc, AutoShapeType.RoundedRectangle);
                shape.Width = 130;
                shape.Height = 45;
                shape.HorizontalOrigin = HorizontalOrigin.Page;
                shape.VerticalOrigin = VerticalOrigin.Page;
                shape.VerticalPosition = 212;
                //Set horizontal position
                shape.HorizontalPosition = 220;
                shape.WrapFormat.AllowOverlap = true;
                shape.FillFormat.Color = System.Drawing.Color.Orange;
                shape.TextFrame.TextVerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                para = shape.TextBody.AddParagraph();
                para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                para.AppendText("Design").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = System.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });
                groupShape.Add(shape);

                shape = new Shape(doc, AutoShapeType.DownArrow);
                shape.Width = 45;
                shape.Height = 45;
                shape.HorizontalOrigin = HorizontalOrigin.Page;
                shape.VerticalOrigin = VerticalOrigin.Page;
                shape.VerticalPosition = 257;
                //Set horizontal position
                shape.HorizontalPosition = 265;
                shape.WrapFormat.AllowOverlap = true;
                groupShape.Add(shape);

                shape = new Shape(doc, AutoShapeType.RoundedRectangle);
                shape.Width = 130;
                shape.Height = 45;
                shape.HorizontalOrigin = HorizontalOrigin.Page;
                shape.VerticalOrigin = VerticalOrigin.Page;
                shape.VerticalPosition = 302;
                //Set horizontal position
                shape.HorizontalPosition = 220;
                shape.WrapFormat.AllowOverlap = true;
                shape.FillFormat.Color = System.Drawing.Color.Blue;
                shape.TextFrame.TextVerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                para = shape.TextBody.AddParagraph();
                para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                para.AppendText("Execution").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = System.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });
                groupShape.Add(shape);

                shape = new Shape(doc, AutoShapeType.DownArrow);
                shape.Width = 45;
                shape.Height = 45;
                shape.HorizontalOrigin = HorizontalOrigin.Page;
                shape.VerticalOrigin = VerticalOrigin.Page;
                shape.VerticalPosition = 347;
                //Set horizontal position
                shape.HorizontalPosition = 265;
                shape.WrapFormat.AllowOverlap = true;
                groupShape.Add(shape);

                shape = new Shape(doc, AutoShapeType.RoundedRectangle);
                shape.Width = 130;
                shape.Height = 45;
                shape.HorizontalOrigin = HorizontalOrigin.Page;
                shape.VerticalOrigin = VerticalOrigin.Page;
                shape.VerticalPosition = 392;
                //Set horizontal position
                shape.HorizontalPosition = 220;
                shape.WrapFormat.AllowOverlap = true;
                shape.FillFormat.Color = System.Drawing.Color.Violet;
                shape.TextFrame.TextVerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                para = shape.TextBody.AddParagraph();
                para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                para.AppendText("Testing").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = System.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });
                groupShape.Add(shape);

                shape = new Shape(doc, AutoShapeType.DownArrow);
                shape.Width = 45;
                shape.Height = 45;
                shape.HorizontalOrigin = HorizontalOrigin.Page;
                shape.VerticalOrigin = VerticalOrigin.Page;
                shape.VerticalPosition = 437;
                //Set horizontal position
                shape.HorizontalPosition = 265;
                shape.WrapFormat.AllowOverlap = true;
                groupShape.Add(shape);

                shape = new Shape(doc, AutoShapeType.RoundedRectangle);
                shape.Width = 130;
                shape.Height = 45;
                shape.HorizontalOrigin = HorizontalOrigin.Page;
                shape.VerticalOrigin = VerticalOrigin.Page;
                shape.VerticalPosition = 482;
                //Set horizontal position
                shape.HorizontalPosition = 220;
                shape.WrapFormat.AllowOverlap = true;
                shape.FillFormat.Color = System.Drawing.Color.PaleVioletRed;
                shape.TextFrame.TextVerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                para = shape.TextBody.AddParagraph();
                para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                para.AppendText("Release").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = System.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });
                groupShape.Add(shape);
                doc.LastParagraph.ChildEntities.Add(groupShape);


                //Save as docx format
                if (worddocx.IsChecked.Value)
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
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        # endregion
    }
}