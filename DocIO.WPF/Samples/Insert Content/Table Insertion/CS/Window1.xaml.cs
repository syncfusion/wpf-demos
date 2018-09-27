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
using Syncfusion.DocIO.DLS;
using System.Data;
using Syncfusion.DocIO;
using System.ComponentModel;
using System.Data.SqlServerCe;
using Syncfusion.Windows.Shared;
using System.IO;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;

namespace TableInsertion
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Creating a new document.
                WordDocument document = new WordDocument();
                // Adding a new section to the document.
                IWSection section = document.AddSection();
                IWParagraph paragraph = section.AddParagraph();
                paragraph.ParagraphFormat.BeforeSpacing = 20f;

                //Format the heading.
                IWTextRange text = paragraph.AppendText("Northwind Report");
                text.CharacterFormat.Bold = true;
                text.CharacterFormat.FontName = "Cambria";
                text.CharacterFormat.FontSize = 14.0f;
                text.CharacterFormat.TextColor = System.Drawing.Color.DarkBlue;
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;

                paragraph = section.AddParagraph();
                paragraph.ParagraphFormat.BeforeSpacing = 18f;

                //Access the database and get the NorthWind
                SqlCeConnection conn = new SqlCeConnection();
                if (conn.ServerVersion.StartsWith("3.5"))
                conn.ConnectionString = "Data Source = " + (@"..\..\..\..\..\..\..\Common\Data\" + "NorthwindIO_3.5.sdf");
                else
                conn.ConnectionString = "Data Source = " + (@"..\..\..\..\..\..\..\Common\Data\" + "NorthwindIO.sdf");
                conn.Open();
                SqlCeDataAdapter adapter = new SqlCeDataAdapter("Select CustomerID,CompanyName,ContactName,Address,Country,Phone from Customers", conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                //Create a new table
                WTextBody textBody = section.Body;
                IWTable docTable = textBody.AddTable();

                //Set the format for rows
                RowFormat format = new RowFormat();
                format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                format.Borders.LineWidth = 1.0F;
                format.Borders.Color = System.Drawing.Color.Black;

                //Initialize number of rows and cloumns.
                docTable.ResetCells(table.Rows.Count + 1, table.Columns.Count, format, 84);

                //Repeat the header.
                docTable.Rows[0].IsHeader = true;

                string colName;

                //Format the header rows
                for (int c = 0; c <= table.Columns.Count - 1; c++)
                {
                    string[] Cols = table.Columns[c].ColumnName.Split('|');
                    colName = Cols[Cols.Length - 1];
                    IWTextRange theadertext = docTable.Rows[0].Cells[c].AddParagraph().AppendText(colName);
                    theadertext.CharacterFormat.FontSize = 12f;
                    theadertext.CharacterFormat.Bold = true;
                    theadertext.CharacterFormat.TextColor = System.Drawing.Color.White;
                    docTable.Rows[0].Cells[c].CellFormat.BackColor = System.Drawing.Color.FromArgb(33, 67, 126);
                    docTable.Rows[0].Cells[c].CellFormat.Borders.Color = System.Drawing.Color.Black;
                    docTable.Rows[0].Cells[c].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                    docTable.Rows[0].Cells[c].CellFormat.Borders.LineWidth = 1.0f;

                    docTable.Rows[0].Cells[c].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                }

                //Format the table body rows
                for (int r = 0; r <= table.Rows.Count - 1; r++)
                {
                    for (int c = 0; c <= table.Columns.Count - 1; c++)
                    {
                        string Value = table.Rows[r][c].ToString();
                        IWTextRange theadertext = docTable.Rows[r + 1].Cells[c].AddParagraph().AppendText(Value);
                        theadertext.CharacterFormat.FontSize = 10;

                        docTable.Rows[r + 1].Cells[c].CellFormat.BackColor = ((r & 1) == 0) ? System.Drawing.Color.FromArgb(237, 240, 246) : System.Drawing.Color.FromArgb(192, 201, 219);

                        docTable.Rows[r + 1].Cells[c].CellFormat.Borders.Color = System.Drawing.Color.Black;
                        docTable.Rows[r + 1].Cells[c].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                        docTable.Rows[r + 1].Cells[c].CellFormat.Borders.LineWidth = 0.5f;
                        docTable.Rows[r + 1].Cells[c].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                    }
                }

                // Add a footer paragraph text to the document.
                WParagraph footerPar = new WParagraph(document);
                // Add text.
                footerPar.AppendText("Copyright Northwind Inc. 2001 - 2017");
                // Add page and Number of pages field to the document.
                footerPar.AppendText("			Page ");
                footerPar.AppendField("Page", FieldType.FieldPage);

                section.HeadersFooters.Footer.Paragraphs.Add(footerPar);

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
                // Shows the Message box with Exception message, if an exception throws.
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {

            }
        }
    }
}