#region Copyright Syncfusion Inc. 2001 - 2020
//
//  Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;
using System.Drawing;

namespace UsingBuiltInStyles
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        #region Private Members
        string fileName, dataBase;
        #endregion

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
            fileName = @"..\..\..\..\..\..\..\Common\Data\DocIO\";
            dataBase = @"..\..\..\..\..\..\..\Common\Data\Northwind.mdb";
#else
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
            fileName = @"..\..\..\..\..\..\Common\Data\DocIO\";
            dataBase = @"..\..\..\..\..\..\Common\Data\Northwind.mdb";
#endif
        }
        # endregion

        #region Events
        /// <summary>
        /// Creates word document with built - in styles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Open the template document
                WordDocument document = new WordDocument(fileName + "TemplateTableStyle.doc");

                //Gets Data from the Database
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dataBase);
                conn.Open();
                DataSet ds = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Suppliers", conn);
                adapter.Fill(ds);
                ds.Tables[0].TableName = "Suppliers";
                adapter.Dispose();
                conn.Close();

                //Execute Mail Merge with groups
                document.MailMerge.ExecuteGroup(ds.Tables[0]);

                #region Built-in table styles
                //Get table to apply style
                WTable table = (WTable)document.LastSection.Tables[0];

                //Apply built-in table style to the table
                table.ApplyStyle(BuiltinTableStyle.MediumShading1Accent5);
                #endregion

                #region Save Document
                //Save as docx format
                if (worddocx.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document as .docx
                        document.Save("Sample.docx", FormatType.Docx);
                        //Message box confirmation to view the created document
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.docx" + ") then try generating the document.", "File is already open",
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
                        pdfDoc.Save("Sample.pdf");
                        //Message box confirmation to view the created document
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.pdf" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    //Exit
                    this.Close();
                }
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        /// <summary>
        /// Creates word document with Custom styles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //Open the template document
                WordDocument document = new WordDocument(fileName + "TemplateTableStyle.doc");

                //Gets Data from the Database
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dataBase);
                conn.Open();
                DataSet ds = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Suppliers", conn);
                adapter.Fill(ds);
                ds.Tables[0].TableName = "Suppliers";
                adapter.Dispose();
                conn.Close();

                //Execute Mail Merge with groups
                document.MailMerge.ExecuteGroup(ds.Tables[0]);

                #region Custom table styles
                //Get table to apply style
                WTable table = (WTable)document.LastSection.Tables[0];
                //Apply custom table style to the table
                #region Apply Table style
                WTableStyle tableStyle = document.AddTableStyle("Tablestyle") as WTableStyle;
                System.Drawing.Color borderColor = System.Drawing.Color.WhiteSmoke;
                System.Drawing.Color firstRowBackColor = System.Drawing.Color.Blue;
                System.Drawing.Color backColor = System.Drawing.Color.WhiteSmoke;
                ConditionalFormattingStyle firstRowStyle, lastRowStyle, firstColumnStyle, lastColumnStyle, oddColumnBandingStyle, oddRowBandingStyle, evenRowBandingStyle;

                #region Table Properties
                tableStyle.TableProperties.RowStripe = 1;
                tableStyle.TableProperties.ColumnStripe = 1;
                tableStyle.TableProperties.LeftIndent = 0;

                tableStyle.TableProperties.Paddings.Top = 0;
                tableStyle.TableProperties.Paddings.Bottom = 0;
                tableStyle.TableProperties.Paddings.Left = 5.4f;
                tableStyle.TableProperties.Paddings.Right = 5.4f;

                tableStyle.TableProperties.Borders.Top.BorderType = BorderStyle.Single;
                tableStyle.TableProperties.Borders.Top.LineWidth = 1f;
                tableStyle.TableProperties.Borders.Top.Color = System.Drawing.Color.AliceBlue;
                tableStyle.TableProperties.Borders.Top.Space = 0;

                tableStyle.TableProperties.Borders.Bottom.BorderType = BorderStyle.Single;
                tableStyle.TableProperties.Borders.Bottom.LineWidth = 1f;
                tableStyle.TableProperties.Borders.Bottom.Color = borderColor;
                tableStyle.TableProperties.Borders.Bottom.Space = 0;

                tableStyle.TableProperties.Borders.Left.BorderType = BorderStyle.Single;
                tableStyle.TableProperties.Borders.Left.LineWidth = 1f;
                tableStyle.TableProperties.Borders.Left.Color = borderColor;
                tableStyle.TableProperties.Borders.Left.Space = 0;

                tableStyle.TableProperties.Borders.Right.BorderType = BorderStyle.Single;
                tableStyle.TableProperties.Borders.Right.LineWidth = 1f;
                tableStyle.TableProperties.Borders.Right.Color = borderColor;
                tableStyle.TableProperties.Borders.Right.Space = 0;

                tableStyle.TableProperties.Borders.Horizontal.BorderType = BorderStyle.Single;
                tableStyle.TableProperties.Borders.Horizontal.LineWidth = 1f;
                tableStyle.TableProperties.Borders.Horizontal.Color = borderColor;
                tableStyle.TableProperties.Borders.Horizontal.Space = 0;
                #endregion

                #region Conditional Formatting Properties
                #region First Row Conditional Formatting Style
                firstRowStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.FirstRow);

                #region Character format
                firstRowStyle.CharacterFormat.Bold = true;
                firstRowStyle.CharacterFormat.BoldBidi = true;
                firstRowStyle.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                #endregion

                #region Table Cell Properties
                firstRowStyle.CellProperties.Borders.Top.BorderType = BorderStyle.Single;
                firstRowStyle.CellProperties.Borders.Top.LineWidth = 1f;
                firstRowStyle.CellProperties.Borders.Top.Color = borderColor;
                firstRowStyle.CellProperties.Borders.Top.Space = 0;

                firstRowStyle.CellProperties.Borders.Bottom.BorderType = BorderStyle.Single;
                firstRowStyle.CellProperties.Borders.Bottom.LineWidth = 1f;
                firstRowStyle.CellProperties.Borders.Bottom.Color = borderColor;
                firstRowStyle.CellProperties.Borders.Bottom.Space = 0;

                firstRowStyle.CellProperties.Borders.Left.BorderType = BorderStyle.Single;
                firstRowStyle.CellProperties.Borders.Left.LineWidth = 1f;
                firstRowStyle.CellProperties.Borders.Left.Color = borderColor;
                firstRowStyle.CellProperties.Borders.Left.Space = 0;

                firstRowStyle.CellProperties.Borders.Right.BorderType = BorderStyle.Single;
                firstRowStyle.CellProperties.Borders.Right.LineWidth = 1f;
                firstRowStyle.CellProperties.Borders.Right.Color = borderColor;
                firstRowStyle.CellProperties.Borders.Right.Space = 0;

                firstRowStyle.CellProperties.Borders.Horizontal.BorderType = BorderStyle.Cleared;

                firstRowStyle.CellProperties.Borders.Vertical.BorderType = BorderStyle.Cleared;

                firstRowStyle.CellProperties.BackColor = firstRowBackColor;
                firstRowStyle.CellProperties.ForeColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);
                firstRowStyle.CellProperties.TextureStyle = TextureStyle.TextureNone;
                #endregion
                #endregion

                #region Last Row Conditional Formatting Style
                lastRowStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.LastRow);

                #region Character format
                lastRowStyle.CharacterFormat.Bold = true;
                lastRowStyle.CharacterFormat.BoldBidi = true;
                #endregion

                #region Table Cell Properties
                lastRowStyle.CellProperties.Borders.Top.BorderType = BorderStyle.Double;
                lastRowStyle.CellProperties.Borders.Top.LineWidth = .75f;
                lastRowStyle.CellProperties.Borders.Top.Color = borderColor;
                lastRowStyle.CellProperties.Borders.Top.Space = 0;

                lastRowStyle.CellProperties.Borders.Bottom.BorderType = BorderStyle.Single;
                lastRowStyle.CellProperties.Borders.Bottom.LineWidth = 1f;
                lastRowStyle.CellProperties.Borders.Bottom.Color = borderColor;
                lastRowStyle.CellProperties.Borders.Bottom.Space = 0;

                lastRowStyle.CellProperties.Borders.Left.BorderType = BorderStyle.Single;
                lastRowStyle.CellProperties.Borders.Left.LineWidth = 1f;
                lastRowStyle.CellProperties.Borders.Left.Color = borderColor;
                lastRowStyle.CellProperties.Borders.Left.Space = 0;

                lastRowStyle.CellProperties.Borders.Right.BorderType = BorderStyle.Single;
                lastRowStyle.CellProperties.Borders.Right.LineWidth = 1f;
                lastRowStyle.CellProperties.Borders.Right.Color = borderColor;
                lastRowStyle.CellProperties.Borders.Right.Space = 0;

                lastRowStyle.CellProperties.Borders.Horizontal.BorderType = BorderStyle.Cleared;

                lastRowStyle.CellProperties.Borders.Vertical.BorderType = BorderStyle.Cleared;
                #endregion
                #endregion

                #region First Column Conditional Formatting Style
                firstColumnStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.FirstColumn);
                #region Character format
                firstColumnStyle.CharacterFormat.Bold = true;
                firstColumnStyle.CharacterFormat.BoldBidi = true;
                #endregion
                #endregion

                #region Last Column Conditional Formatting Style
                lastColumnStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.LastColumn);
                #region Character format
                lastColumnStyle.CharacterFormat.Bold = true;
                lastColumnStyle.CharacterFormat.BoldBidi = true;
                #endregion
                #endregion

                #region Odd Column Banding Conditional Formatting Style
                oddColumnBandingStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.OddColumnBanding);
                #region Table Cell Properties
                oddColumnBandingStyle.CellProperties.BackColor = backColor;
                oddColumnBandingStyle.CellProperties.ForeColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);
                oddColumnBandingStyle.CellProperties.TextureStyle = TextureStyle.TextureNone;
                #endregion
                #endregion

                #region Odd Row Banding Conditional Formatting Style
                oddRowBandingStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.OddRowBanding);
                #region Table Cell Properties
                oddRowBandingStyle.CellProperties.Borders.Horizontal.BorderType = BorderStyle.Cleared;

                oddRowBandingStyle.CellProperties.Borders.Vertical.BorderType = BorderStyle.Cleared;

                oddRowBandingStyle.CellProperties.BackColor = backColor;
                oddRowBandingStyle.CellProperties.ForeColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);
                oddRowBandingStyle.CellProperties.TextureStyle = TextureStyle.TextureNone;
                #endregion
                #endregion

                #region Even Row Banding Conditional Formatting Style
                evenRowBandingStyle = tableStyle.ConditionalFormattingStyles.Add(ConditionalFormattingType.EvenRowBanding);
                #region Table Cell Properties
                evenRowBandingStyle.CellProperties.Borders.Horizontal.BorderType = BorderStyle.Cleared;
                evenRowBandingStyle.CellProperties.Borders.Vertical.BorderType = BorderStyle.Cleared;
                #endregion
                #endregion
                #endregion
                #endregion
                table.ApplyStyle("Tablestyle");
                #endregion

                #region Save Document
                //Save as docx format
                if (worddocx.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document as .docx
                        document.Save("Sample.docx", FormatType.Docx);
                        //Message box confirmation to view the created document
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.docx" + ") then try generating the document.", "File is already open",
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
                        pdfDoc.Save("Sample.pdf");
                        //Message box confirmation to view the created document
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.pdf" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    //Exit
                    this.Close();
                }
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
