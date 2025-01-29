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
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AutoShapes : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public AutoShapes()
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
                //Initialize Word document
                using (WordDocument doc = new WordDocument())
                {
                    //Ensure Minimum
                    doc.EnsureMinimal();
                    //Append AutoShape
                    Syncfusion.DocIO.DLS.Shape shape = doc.LastParagraph.AppendShape(AutoShapeType.RoundedRectangle, 130, 45);
                    //Set horizontal alignment
                    shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
                    //Set horizontal origin
                    shape.HorizontalOrigin = HorizontalOrigin.Page;
                    //Set vertical origin
                    shape.VerticalOrigin = VerticalOrigin.Page;
                    //Set vertical position
                    shape.VerticalPosition = 50;
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

                    shape = doc.LastParagraph.AppendShape(AutoShapeType.DownArrow, 45, 45);
                    shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
                    shape.HorizontalOrigin = HorizontalOrigin.Page;
                    shape.VerticalOrigin = VerticalOrigin.Page;
                    shape.VerticalPosition = 95;
                    shape.WrapFormat.AllowOverlap = true;

                    shape = doc.LastParagraph.AppendShape(AutoShapeType.RoundedRectangle, 130, 45);
                    shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
                    shape.HorizontalOrigin = HorizontalOrigin.Page;
                    shape.VerticalOrigin = VerticalOrigin.Page;
                    shape.VerticalPosition = 140;
                    shape.WrapFormat.AllowOverlap = true;
                    shape.FillFormat.Color = System.Drawing.Color.Orange;
                    shape.TextFrame.TextVerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                    para = shape.TextBody.AddParagraph();
                    para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    para.AppendText("Design").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = System.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });

                    shape = doc.LastParagraph.AppendShape(AutoShapeType.DownArrow, 45, 45);
                    shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
                    shape.HorizontalOrigin = HorizontalOrigin.Page;
                    shape.VerticalOrigin = VerticalOrigin.Page;
                    shape.VerticalPosition = 185;
                    shape.WrapFormat.AllowOverlap = true;

                    shape = doc.LastParagraph.AppendShape(AutoShapeType.RoundedRectangle, 130, 45);
                    shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
                    shape.HorizontalOrigin = HorizontalOrigin.Page;
                    shape.VerticalOrigin = VerticalOrigin.Page;
                    shape.VerticalPosition = 230;
                    shape.WrapFormat.AllowOverlap = true;
                    shape.FillFormat.Color = System.Drawing.Color.Blue;
                    shape.TextFrame.TextVerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                    para = shape.TextBody.AddParagraph();
                    para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    para.AppendText("Execution").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = System.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });

                    shape = doc.LastParagraph.AppendShape(AutoShapeType.DownArrow, 45, 45);
                    shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
                    shape.HorizontalOrigin = HorizontalOrigin.Page;
                    shape.VerticalOrigin = VerticalOrigin.Page;
                    shape.VerticalPosition = 275;
                    shape.WrapFormat.AllowOverlap = true;

                    shape = doc.LastParagraph.AppendShape(AutoShapeType.RoundedRectangle, 130, 45);
                    shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
                    shape.HorizontalOrigin = HorizontalOrigin.Page;
                    shape.VerticalOrigin = VerticalOrigin.Page;
                    shape.VerticalPosition = 320;
                    shape.WrapFormat.AllowOverlap = true;
                    shape.FillFormat.Color = System.Drawing.Color.Violet;
                    shape.TextFrame.TextVerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                    para = shape.TextBody.AddParagraph();
                    para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    para.AppendText("Testing").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = System.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });

                    shape = doc.LastParagraph.AppendShape(AutoShapeType.DownArrow, 45, 45);
                    shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
                    shape.HorizontalOrigin = HorizontalOrigin.Page;
                    shape.VerticalOrigin = VerticalOrigin.Page;
                    shape.VerticalPosition = 365;
                    shape.WrapFormat.AllowOverlap = true;

                    shape = doc.LastParagraph.AppendShape(AutoShapeType.RoundedRectangle, 130, 45);
                    shape.HorizontalAlignment = ShapeHorizontalAlignment.Center;
                    shape.HorizontalOrigin = HorizontalOrigin.Page;
                    shape.VerticalOrigin = VerticalOrigin.Page;
                    shape.VerticalPosition = 410;
                    shape.WrapFormat.AllowOverlap = true;
                    shape.FillFormat.Color = System.Drawing.Color.PaleVioletRed;
                    shape.TextFrame.TextVerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                    para = shape.TextBody.AddParagraph();
                    para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    para.AppendText("Release").ApplyCharacterFormat(new WCharacterFormat(doc) { Bold = true, TextColor = System.Drawing.Color.White, FontSize = 12, FontName = "Verdana" });

                    //Save as docx format
                    if (worddocx.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document as .docx
                            doc.Save("Auto Shapes.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Auto Shapes.docx") { UseShellExecute = true };
                                    process.Start();
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Auto Shapes.doc" + ") then try generating the document.", "File is already open",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
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
                            pdfDoc.Save("Auto Shapes.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Auto Shapes.pdf") { UseShellExecute = true };
                                    process.Start();
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Auto Shapes.doc" + ") then try generating the document.", "File is already open",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
#endregion
    }
}