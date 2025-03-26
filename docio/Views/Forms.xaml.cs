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
using System.Drawing;
using System.ComponentModel;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;
using syncfusion.demoscommon.wpf;
using System.Reflection;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Forms : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Forms()
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
        /// Create Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create a new document.
                using (WordDocument document = new WordDocument())
                {

                    // Adding a new section to the document.
                    IWSection section = document.AddSection();

                    // Adding a new paragraph to the section.
                    IWParagraph paragraph = section.AddParagraph();

                    #region Document formatting
                    //Set background color.
                    document.Background.Gradient.Color1 = System.Drawing.Color.FromArgb(232, 232, 232);
                    document.Background.Gradient.Color2 = System.Drawing.Color.FromArgb(255, 255, 255);
                    document.Background.Type = BackgroundType.Gradient;
                    document.Background.Gradient.ShadingStyle = GradientShadingStyle.Horizontal;
                    document.Background.Gradient.ShadingVariant = GradientShadingVariant.ShadingDown;

                    section.PageSetup.Margins.All = 30f;
                    section.PageSetup.PageSize = new SizeF(600, 600f);

                    #endregion

                    #region Title Section
                    IWTable table = section.Body.AddTable();
                    table.ResetCells(1, 2);

                    WTableRow row = table.Rows[0];
                    row.Height = 25f;

                    IWParagraph cellPara = row.Cells[0].AddParagraph();
                    System.Drawing.Image img = System.Drawing.Image.FromStream(GetFileStream("image.jpg"));
                    IWPicture pic = cellPara.AppendPicture(img);
                    pic.Height = 80;
                    pic.Width = 180;

                    cellPara = row.Cells[1].AddParagraph();
                    row.Cells[1].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                    row.Cells[1].CellFormat.BackColor = System.Drawing.Color.FromArgb(173, 215, 255);
                    IWTextRange txt = cellPara.AppendText("Job Application Form");
                    cellPara.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    txt.CharacterFormat.Bold = true;
                    txt.CharacterFormat.FontName = "Arial";
                    txt.CharacterFormat.FontSize = 18f;

                    row.Cells[0].Width = 200;
                    row.Cells[1].Width = 300;
                    row.Cells[1].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Hairline;
                    #endregion

                    section.AddParagraph();

                    #region General Information
                    table = section.Body.AddTable();
                    table.ResetCells(2, 1);
                    row = table.Rows[0];
                    row.Height = 20;
                    row.Cells[0].Width = 500;
                    cellPara = row.Cells[0].AddParagraph();
                    row.Cells[0].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Thick;
                    row.Cells[0].CellFormat.Borders.Color = System.Drawing.Color.FromArgb(155, 205, 255);
                    row.Cells[0].CellFormat.BackColor = System.Drawing.Color.FromArgb(198, 227, 255);
                    row.Cells[0].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                    txt = cellPara.AppendText(" General Information");
                    txt.CharacterFormat.FontName = "Arial";
                    txt.CharacterFormat.Bold = true;
                    txt.CharacterFormat.FontSize = 11f;

                    row = table.Rows[1];
                    cellPara = row.Cells[0].AddParagraph();
                    row.Cells[0].Width = 500;
                    row.Cells[0].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Hairline;
                    row.Cells[0].CellFormat.Borders.Color = System.Drawing.Color.FromArgb(155, 205, 255);
                    row.Cells[0].CellFormat.BackColor = System.Drawing.Color.FromArgb(222, 239, 255);

                    txt = cellPara.AppendText("\n Full Name:\t\t\t\t");
                    txt.CharacterFormat.FontName = "Arial";
                    txt.CharacterFormat.FontSize = 11f;
                    WTextFormField txtField = cellPara.AppendTextFormField(null);
                    txtField.TextRange.CharacterFormat.TextColor = System.Drawing.Color.MidnightBlue;
                    txtField.TextRange.CharacterFormat.FontName = "Arial";
                    txtField.TextRange.CharacterFormat.FontSize = 11f;

                    txt = cellPara.AppendText("\n\n Birth Date:\t\t\t\t");
                    txt.CharacterFormat.FontName = "Arial";
                    txt.CharacterFormat.FontSize = 11f;
                    txtField = cellPara.AppendTextFormField("BirthDayField", DateTime.Now.ToString("M/d/yyyy"));
                    txtField.StringFormat = "M/d/yyyy";
                    txtField.Type = TextFormFieldType.DateText;
                    txtField.TextRange.CharacterFormat.TextColor = System.Drawing.Color.MidnightBlue;
                    txtField.TextRange.CharacterFormat.FontName = "Arial";
                    txtField.TextRange.CharacterFormat.FontSize = 11f;
                    txtField.CharacterFormat.TextColor = System.Drawing.Color.MidnightBlue;
                    txtField.CharacterFormat.FontName = "Arial";
                    txtField.CharacterFormat.FontSize = 11f;

                    txt = cellPara.AppendText("\n\n Address:\t\t\t\t");
                    txt.CharacterFormat.FontName = "Arial";
                    txt.CharacterFormat.FontSize = 11f;
                    txtField = cellPara.AppendTextFormField(null);
                    txtField.Type = TextFormFieldType.RegularText;
                    txtField.TextRange.CharacterFormat.TextColor = System.Drawing.Color.MidnightBlue;
                    txtField.TextRange.CharacterFormat.FontName = "Arial";
                    txtField.TextRange.CharacterFormat.FontSize = 11f;

                    txt = cellPara.AppendText("\n\n Phone:\t\t\t\t");
                    txt.CharacterFormat.FontName = "Arial";
                    txt.CharacterFormat.FontSize = 11f;
                    txtField = cellPara.AppendTextFormField(null);
                    txtField.TextRange.CharacterFormat.TextColor = System.Drawing.Color.MidnightBlue;
                    txtField.TextRange.CharacterFormat.FontName = "Arial";
                    txtField.TextRange.CharacterFormat.FontSize = 11f;

                    txt = cellPara.AppendText("\n\n Email:\t\t\t\t\t");
                    txt.CharacterFormat.FontName = "Arial";
                    txt.CharacterFormat.FontSize = 11f;
                    txtField = cellPara.AppendTextFormField(null);
                    txtField.TextRange.CharacterFormat.TextColor = System.Drawing.Color.MidnightBlue;
                    txtField.TextRange.CharacterFormat.FontName = "Arial";
                    txtField.TextRange.CharacterFormat.FontSize = 11f;
                    cellPara.AppendText("\n");
                    #endregion

                    section.AddParagraph();

                    #region Educational Qualification
                    table = section.Body.AddTable();
                    table.ResetCells(2, 1);
                    row = table.Rows[0];
                    row.Height = 20;
                    row.Cells[0].Width = 500;
                    cellPara = row.Cells[0].AddParagraph();
                    row.Cells[0].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Thick;
                    row.Cells[0].CellFormat.Borders.Color = System.Drawing.Color.FromArgb(155, 205, 255);
                    row.Cells[0].CellFormat.BackColor = System.Drawing.Color.FromArgb(198, 227, 255);
                    row.Cells[0].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                    txt = cellPara.AppendText(" Educational Qualification");
                    txt.CharacterFormat.FontName = "Arial";
                    txt.CharacterFormat.Bold = true;
                    txt.CharacterFormat.FontSize = 11f;

                    row = table.Rows[1];
                    cellPara = row.Cells[0].AddParagraph();
                    row.Cells[0].Width = 500;
                    row.Cells[0].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Hairline;
                    row.Cells[0].CellFormat.Borders.Color = System.Drawing.Color.FromArgb(155, 205, 255);
                    row.Cells[0].CellFormat.BackColor = System.Drawing.Color.FromArgb(222, 239, 255);

                    txt = cellPara.AppendText("\n Type:\t\t\t\t\t");
                    txt.CharacterFormat.FontName = "Arial";
                    txt.CharacterFormat.FontSize = 11f;
                    WDropDownFormField dropField = cellPara.AppendDropDownFormField();
                    dropField.DropDownItems.Add("Higher");
                    dropField.DropDownItems.Add("Vocational");
                    dropField.DropDownItems.Add("Universal");
                    dropField.CharacterFormat.TextColor = System.Drawing.Color.MidnightBlue;
                    dropField.CharacterFormat.FontName = "Arial";
                    dropField.CharacterFormat.FontSize = 11f;

                    txt = cellPara.AppendText("\n\n Institution:\t\t\t\t");
                    txt.CharacterFormat.FontName = "Arial";
                    txt.CharacterFormat.FontSize = 11f;
                    txtField = cellPara.AppendTextFormField(null);
                    txtField.TextRange.CharacterFormat.TextColor = System.Drawing.Color.MidnightBlue;
                    txtField.TextRange.CharacterFormat.FontName = "Arial";
                    txtField.CharacterFormat.FontSize = 11f;

                    txt = cellPara.AppendText("\n\n Programming Languages:");
                    txt.CharacterFormat.FontName = "Arial";
                    txt.CharacterFormat.FontSize = 11f;
                    txt = cellPara.AppendText("\n\n\t C#:\t\t\t\t");
                    txt.CharacterFormat.FontName = "Arial";
                    txt.CharacterFormat.FontSize = 9f;
                    dropField = cellPara.AppendDropDownFormField();
                    dropField.DropDownItems.Add("Perfect");
                    dropField.DropDownItems.Add("Good");
                    dropField.DropDownItems.Add("Excellent");
                    dropField.CharacterFormat.TextColor = System.Drawing.Color.MidnightBlue;
                    dropField.CharacterFormat.FontName = "Arial";
                    dropField.CharacterFormat.FontSize = 11f;

                    txt = cellPara.AppendText("\n\n\t VB:\t\t\t\t");
                    txt.CharacterFormat.FontName = "Arial";
                    txt.CharacterFormat.FontSize = 9f;
                    dropField = cellPara.AppendDropDownFormField();
                    dropField.DropDownItems.Add("Perfect");
                    dropField.DropDownItems.Add("Good");
                    dropField.DropDownItems.Add("Excellent");
                    dropField.CharacterFormat.TextColor = System.Drawing.Color.MidnightBlue;
                    dropField.CharacterFormat.FontName = "Arial";
                    dropField.CharacterFormat.FontSize = 11f;
                    #endregion

                    btnFill.IsEnabled = true;

                    //Protect document
                    document.ProtectionType = ProtectionType.AllowOnlyFormFields;
                    document.Save("Forms.doc", FormatType.Doc);
                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            document.Save("Forms.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Forms.doc") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Forms.doc" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //Save as docx format
                    else if (worddocx.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document as .docx
                            document.Save("Forms.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Forms.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Forms.doc" + ") then try generating the document.", "File is already open",
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
                            PdfDocument pdfDoc = converter.ConvertToPDF(document);
                            //Save the pdf file
                            pdfDoc.Save("Forms.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Forms.pdf") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Forms.doc" + ") then try generating the document.", "File is already open",
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

        /// <summary>
        /// Fill Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            // Create a new document.
            WordDocument document = new WordDocument("Forms.doc");

            IWSection sec = document.LastSection;
            WTextFormField textFF;
            WDropDownFormField dropFF;

            //Access the text field
            textFF = sec.Body.FormFields[0] as WTextFormField;

            //Fill value for the textfield
            textFF.TextRange.Text = "John";

            //Access the form field with feild name
            textFF = sec.Body.FormFields["BirthDayField"] as WTextFormField;
            textFF.TextRange.Text = "5.13.1980";

            textFF = sec.Body.FormFields[2] as WTextFormField;
            textFF.TextRange.Text = "221b Baker Street";

            textFF = sec.Body.FormFields[3] as WTextFormField;
            textFF.TextRange.Text = "(206)555-3412";

            textFF = sec.Body.FormFields[4] as WTextFormField;
            textFF.TextRange.Text = "John@company.com";

            dropFF = sec.Body.FormFields[5] as WDropDownFormField;

            //Set the value
            dropFF.DropDownSelectedIndex = 1;

            textFF = sec.Body.FormFields[6] as WTextFormField;
            textFF.TextRange.Text = "Michigan University";

            dropFF = sec.Body.FormFields[7] as WDropDownFormField;
            dropFF.DropDownSelectedIndex = 1;

            dropFF = sec.Body.FormFields[8] as WDropDownFormField;
            dropFF.DropDownSelectedIndex = 2;

            //Allow only to fill the form.
            document.ProtectionType = ProtectionType.AllowOnlyFormFields;

            //Save as doc format
            if (worddoc.IsChecked.Value)
            {
                try
                {
                    //Saving the document to disk.
                    document.Save("Forms.doc");

                    //Message box confirmation to view the created document.
                    if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo("Forms.doc") { UseShellExecute = true };
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
                        MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Forms.doc" + ") then try generating the document.", "File is already open",
                             MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            //Save as docx format
            else if (worddocx.IsChecked.Value)
            {
                try
                {
                    //Saving the document as .docx
                    document.Save("Forms.docx", FormatType.Docx);
                    //Message box confirmation to view the created document.
                    if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo("Forms.docx") { UseShellExecute = true };
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
                        MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Forms.doc" + ") then try generating the document.", "File is already open",
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
                    PdfDocument pdfDoc = converter.ConvertToPDF(document);
                    //Save the pdf file
                    pdfDoc.Save("Forms.pdf");
                    //Message box confirmation to view the created document.
                    if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo("Forms.pdf") { UseShellExecute = true };
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
                        MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Forms.doc" + ") then try generating the document.", "File is already open",
                             MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Get the file as stream from assets
        /// </summary>
        private Stream GetFileStream(string fileName)
        {
            Assembly assembly = typeof(Forms).Assembly;
            return assembly.GetManifestResourceStream("syncfusion.dociodemos.wpf.Assets.DocIO." + fileName);
        }

        # endregion
    }
}