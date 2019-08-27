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
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.Drawing;
using System.IO;
using Syncfusion.Windows.Shared;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;

namespace FormattingTable
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
                // Create a new document.
                WordDocument document = new WordDocument();

                // Adding a new section to the document.
                IWSection section = document.AddSection();
                section.PageSetup.DifferentFirstPage = true;
                IWTextRange textRange;
                IWParagraph paragraph = section.AddParagraph();

                // --------------------------------------------
                // Table in page header 
                // --------------------------------------------

                IWParagraph hParagraph = new WParagraph(document);
                hParagraph.AppendText("Header text\r\n").CharacterFormat.FontSize = 14;

                section.HeadersFooters.FirstPageHeader.Paragraphs.Add(hParagraph);
                IWTable hTable = document.LastSection.HeadersFooters.FirstPageHeader.AddTable();
                hTable.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                hTable.TableFormat.Paddings.All = 5.4f;
                hTable.ResetCells(2, 2);

                hTable[0, 0].AddParagraph().AppendText("1");
                hTable[0, 1].AddParagraph().AppendText("2");
                hTable[1, 0].AddParagraph().AppendText("3");
                hTable[1, 1].AddParagraph().AppendText("4");

                // --------------------------------------------
                // Tiny table
                // --------------------------------------------

                paragraph = section.AddParagraph();

                paragraph.AppendText("Tiny table\r\n").CharacterFormat.FontSize = 14;
                paragraph = section.AddParagraph();
                WTextBody textBody = section.Body;
                IWTable table = textBody.AddTable();
                table.ResetCells(2, 2);
                table.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                table.TableFormat.Paddings.All = 5.4f;
                WTableRow row_0 = table.Rows[0];
                row_0.Cells[0].AddParagraph().AppendText("A");
                row_0.Cells[0].AddParagraph().AppendText("AA");
                row_0.Cells[0].AddParagraph().AppendText("AAA");

                WTableRow row_1 = table.Rows[1];
                row_1.Cells[1].AddParagraph().AppendText("B");
                row_1.Cells[1].AddParagraph().AppendText("BB\r\nBBB");
                row_1.Cells[1].AddParagraph().AppendText("BBB");

                textBody.AddParagraph().AppendText("Text after table...").CharacterFormat.FontSize = 14;

                // --------------------------------------------
                // Table with different formatting 
                // --------------------------------------------

                section.AddParagraph();
                paragraph = section.AddParagraph();
                paragraph.AppendText("Table with different formatting\r\n").CharacterFormat.FontSize = 14;
                paragraph = section.AddParagraph();
                textBody = section.Body;
                table = textBody.AddTable();
                table.ResetCells(3, 3);

                /* ------- First Row -------- */

                WTableRow row0 = table.Rows[0];

                paragraph = (IWParagraph)row0.Cells[0].AddParagraph();
                textRange = paragraph.AppendText("1");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                textRange.CharacterFormat.FontName = "Arial";
                textRange.CharacterFormat.Bold = true;
                textRange.CharacterFormat.FontSize = 14f;
                row0.Cells[0].CellFormat.Borders.LineWidth = 2f;
                row0.Cells[0].CellFormat.Borders.Color = System.Drawing.Color.Magenta;

                paragraph = (IWParagraph)row0.Cells[1].AddParagraph();
                textRange = paragraph.AppendText("2");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                textRange.CharacterFormat.Emboss = true;
                textRange.CharacterFormat.FontSize = 15f;
                row0.Cells[1].CellFormat.Borders.LineWidth = 1.3f;
                row0.Cells[1].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.DoubleWave;

                paragraph = (IWParagraph)row0.Cells[2].AddParagraph();
                textRange = paragraph.AppendText("3");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Left;
                textRange.CharacterFormat.Engrave = true;
                textRange.CharacterFormat.FontSize = 15f;
                row0.Cells[2].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Emboss3D;

                /* ------- Second Row -------- */

                WTableRow row1 = table.Rows[1];

                paragraph = (IWParagraph)row1.Cells[0].AddParagraph();
                textRange = paragraph.AppendText("4");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                textRange.CharacterFormat.SmallCaps = true;
                textRange.CharacterFormat.FontName = "Comic Sans MS";
                textRange.CharacterFormat.FontSize = 16;
                row1.Cells[0].CellFormat.Borders.LineWidth = 2f;
                row1.Cells[0].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.DashDotStroker;

                paragraph = (IWParagraph)row1.Cells[1].AddParagraph();
                textRange = paragraph.AppendText("5");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                textRange.CharacterFormat.FontName = "Times New Roman";
                textRange.CharacterFormat.Shadow = true;
                textRange.CharacterFormat.TextBackgroundColor = System.Drawing.Color.Orange;
                textRange.CharacterFormat.FontSize = 15f;
                row1.Cells[1].CellFormat.Borders.LineWidth = 2f;
                row1.Cells[1].CellFormat.Borders.Color = System.Drawing.Color.Brown;

                paragraph = (IWParagraph)row1.Cells[2].AddParagraph();
                textRange = paragraph.AppendText("6");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                textRange.CharacterFormat.Bold = true;
                textRange.CharacterFormat.FontSize = 14f;
                row1.Cells[2].CellFormat.BackColor = System.Drawing.Color.FromArgb(51, 51, 101);
                row1.Cells[2].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;

                /* ------- Third Row -------- */

                WTableRow row2 = table.Rows[2];

                paragraph = (IWParagraph)row2.Cells[0].AddParagraph();
                textRange = paragraph.AppendText("7");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                textRange.CharacterFormat.FontSize = 13f;
                row2.Cells[0].CellFormat.Borders.LineWidth = 1.5f;
                row2.Cells[0].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.DashLargeGap;

                paragraph = (IWParagraph)row2.Cells[1].AddParagraph();
                textRange = paragraph.AppendText("8");
                textRange.CharacterFormat.TextColor = System.Drawing.Color.Blue;
                textRange.CharacterFormat.FontSize = 16f;
                row2.Cells[1].CellFormat.Borders.LineWidth = 3f;
                row2.Cells[1].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Wave;

                paragraph = (IWParagraph)row2.Cells[2].AddParagraph();
                textRange = paragraph.AppendText("9");
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                row2.Cells[2].CellFormat.Borders.LineWidth = 2f;
                row2.Cells[2].CellFormat.Borders.Color = System.Drawing.Color.Cyan;
                row2.Cells[2].CellFormat.Borders.Shadow = true;
                row2.Cells[2].CellFormat.Borders.Space = 20;

                // --------------------------------------------
                // Table Cell Merging.
                // --------------------------------------------

                section.AddParagraph();
                paragraph = section.AddParagraph();
                paragraph.AppendText("Table Cell Merging...").CharacterFormat.FontSize = 14;
                section.AddParagraph();
                paragraph = section.AddParagraph();
                textBody = section.Body;

                // Adding a new Table to the textbody.
                table = textBody.AddTable();
                table.TableFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                table.TableFormat.Paddings.All = 5.4f;

                RowFormat format = new RowFormat();
                format.Paddings.All = 5;
                format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Dot;
                format.Borders.LineWidth = 2;

                // Inserting rows to the table.
                table.ResetCells(6, 6, format, 80);

                // Table formatting with cell merging.
                table.Rows[0].Cells[0].CellFormat.HorizontalMerge = CellMerge.Start;
                table.Rows[0].Cells[1].CellFormat.HorizontalMerge = CellMerge.Continue;
                table.Rows[0].Cells[0].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                table.Rows[0].Cells[0].CellFormat.BackColor = System.Drawing.Color.FromArgb(218, 230, 246);
                IWParagraph par = table.Rows[0].Cells[0].AddParagraph();
                par.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                par.AppendText("Horizontal Merge").CharacterFormat.Bold = true;

                table.Rows[2].Cells[3].CellFormat.VerticalMerge = CellMerge.Start;
                table.Rows[3].Cells[3].CellFormat.VerticalMerge = CellMerge.Continue;

                table.Rows[2].Cells[3].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                par = table.Rows[2].Cells[3].AddParagraph();
                table.Rows[2].Cells[3].CellFormat.BackColor = System.Drawing.Color.FromArgb(252, 172, 85);
                par.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                par.AppendText("Vertical Merge").CharacterFormat.Bold = true;

                // --------------------------------------------
                // Table Cell Spacing.
                // --------------------------------------------

                section.AddParagraph();
                paragraph = section.AddParagraph();
                paragraph.AppendText("Table Cell spacing...").CharacterFormat.FontSize = 14;

                section.AddParagraph();
                paragraph = section.AddParagraph();
                textBody = section.Body;

                // Adding a new Table to the textbody.
                table = textBody.AddTable();

                format = new RowFormat();

                format.Paddings.All = 5;
                format.CellSpacing = 2;
                format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.DotDash;
                format.IsBreakAcrossPages = true;
                table.ResetCells(25, 5, format, 90);
                IWTextRange text;
                table.Rows[0].IsHeader = true;

                for (int i = 0; i < table.Rows[0].Cells.Count; i++)
                {
                    paragraph = table[0, i].AddParagraph() as WParagraph;
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    text = paragraph.AppendText(string.Format("Header {0}", i + 1));
                    text.CharacterFormat.Font = new Font("Bitstream Vera Serif", 10);
                    text.CharacterFormat.Bold = true;
                    text.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(0, 21, 84);
                    table[0, i].CellFormat.BackColor = System.Drawing.Color.FromArgb(203, 211, 226);
                }

                for (int i = 1; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        paragraph = table[i, j].AddParagraph() as WParagraph;
                        paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;

                        text = paragraph.AppendText(string.Format("Cell {0} , {1}", i, j + 1));
                        text.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(242, 151, 50);
                        text.CharacterFormat.Bold = true;
                        if (i % 2 != 1)
                            table[i, j].CellFormat.BackColor = System.Drawing.Color.FromArgb(231, 235, 245);
                        else
                            table[i, j].CellFormat.BackColor = System.Drawing.Color.FromArgb(246, 249, 255);
                    }
                }
                // --------------------------------------------
                // Nested Table.
                // --------------------------------------------

                section.AddParagraph();
                paragraph = section.AddParagraph();
                paragraph.ParagraphFormat.PageBreakBefore = true;
                paragraph.AppendText("Nested Table...").CharacterFormat.FontSize = 14;

                section.AddParagraph();
                paragraph = section.AddParagraph();
                textBody = section.Body;

                // Adding a new Table to the textbody.
                table = textBody.AddTable();

                format = new RowFormat();
                format.Paddings.All = 5;
                format.CellSpacing = 2.5f;
                format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.DotDash;
                table.ResetCells(5, 3, format, 100);

                for (int i = 0; i < table.Rows[0].Cells.Count; i++)
                {
                    paragraph = table[0, i].AddParagraph() as WParagraph;
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    text = paragraph.AppendText(string.Format("Header {0}", i + 1));
                    text.CharacterFormat.Font = new Font("Bitstream Vera Serif", 10);
                    text.CharacterFormat.Bold = true;
                    text.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(0, 21, 84);
                    table[0, i].CellFormat.BackColor = System.Drawing.Color.FromArgb(242, 151, 50);
                }

                table[0, 2].Width = 200;
                for (int i = 1; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        paragraph = table[i, j].AddParagraph() as WParagraph;
                        paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;

                        if ((i == 2) && (j == 2))
                            text = paragraph.AppendText("Nested Table");
                        else
                            text = paragraph.AppendText(string.Format("Cell {0} , {1}", i, j + 1));

                        if ((j == 2))
                            table[i, j].Width = 200;
                        text.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(242, 151, 50);
                        text.CharacterFormat.Bold = true;
                    }
                }

                // Adding a nested Table.
                IWTable nestTable = table[2, 2].AddTable();
                format = new RowFormat();

                format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.DotDash;
                format.HorizontalAlignment = RowAlignment.Center;
                nestTable.ResetCells(3, 3, format, 45);

                for (int i = 0; i < nestTable.Rows.Count; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        paragraph = nestTable[i, j].AddParagraph() as WParagraph;
                        paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;

                        nestTable[i, j].CellFormat.BackColor = System.Drawing.Color.FromArgb(231, 235, 245);
                        text = paragraph.AppendText(string.Format("Cell {0} , {1}", i, j + 1));
                        text.CharacterFormat.TextColor = System.Drawing.Color.Black;
                        text.CharacterFormat.Bold = true;
                    }
                }

                #region Table with Images
                string dataPath = @"..\..\..\..\..\..\..\Common\Images\DocIO\";
                //Add a new section to the document.
                section = document.AddSection();
                //Add paragraph to the section.
                paragraph = section.AddParagraph();
                //Writing text.
                textRange = paragraph.AppendText("Table with Images");
                textRange.CharacterFormat.FontSize = 13f;
                textRange.CharacterFormat.TextColor = System.Drawing.Color.DarkBlue;
                textRange.CharacterFormat.Bold = true;

                //Add paragraph to the section.
                section.AddParagraph();
                paragraph = section.AddParagraph();

                text = null;

                //Adding a new Table to the paragraph.
                table = section.Body.AddTable();
                table.ResetCells(1, 3);

                //Adding rows to the table.
                WTableRow row = table.Rows[0];
                //Set heading row height
                row.Height = 25f;
                //set heading values to the Table.
                for (int i = 0; i < 3; i++)
                {
                    //Add paragraph for writing Text to the cells.
                    paragraph = (IWParagraph)row.Cells[i].AddParagraph();
                    //Set Horizontal Alignment as Center.
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    //Writing Row Heading
                    switch (i)
                    {
                        case 0: text = paragraph.AppendText("SNO");
                            row.Cells[i].Width = 50f; break;
                        case 1: text = paragraph.AppendText("Drinks"); break;
                        case 2: text = paragraph.AppendText("Showcase Image"); row.Cells[i].Width = 200f; break;
                    }
                    //Set row Heading formatting
                    text.CharacterFormat.Bold = true;
                    text.CharacterFormat.FontName = "Cambria";
                    text.CharacterFormat.FontSize = 11f;
                    text.CharacterFormat.TextColor = System.Drawing.Color.White;

                    //Set row cells formatting
                    row.Cells[i].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                    row.Cells[i].CellFormat.BackColor = System.Drawing.Color.FromArgb(157, 161, 190);

                    row.Cells[i].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                }

                int sno = 1;
                //Writing Sno, Product name and Product Images to the Table.

                row1 = table.AddRow(false);

                //Writing SNO to the table with formatting text.
                paragraph = (IWParagraph)row1.Cells[0].AddParagraph();
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                text = paragraph.AppendText(sno.ToString());
                text.CharacterFormat.Bold = true;
                text.CharacterFormat.FontSize = 10f;
                row1.Cells[0].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                row1.Cells[0].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                row1.Cells[0].CellFormat.BackColor = System.Drawing.Color.FromArgb(217, 223, 239);
                //Writing Product Name to the table with Formatting.
                paragraph = (IWParagraph)row1.Cells[1].AddParagraph();
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                text = paragraph.AppendText("Apple Juice");
                text.CharacterFormat.Bold = true;
                text.CharacterFormat.FontSize = 10f;
                text.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(50, 65, 124);
                row1.Cells[1].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                row1.Cells[1].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                row1.Cells[1].CellFormat.BackColor = System.Drawing.Color.FromArgb(217, 223, 239);

                //Writing Product Images to the Table.
                paragraph = (IWParagraph)row1.Cells[2].AddParagraph();
                paragraph.AppendPicture(System.Drawing.Image.FromFile(dataPath + "Apple Juice.png"));
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                row1.Cells[2].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                row1.Cells[2].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                row1.Cells[2].CellFormat.BackColor = System.Drawing.Color.FromArgb(217, 223, 239);
                sno++;
                row1 = table.AddRow(false);

                //Writing SNO to the table with formatting text.
                paragraph = (IWParagraph)row1.Cells[0].AddParagraph();
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                text = paragraph.AppendText(sno.ToString());
                text.CharacterFormat.Bold = true;
                text.CharacterFormat.FontSize = 10f;
                row1.Cells[0].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                row1.Cells[0].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                row1.Cells[0].CellFormat.BackColor = System.Drawing.Color.FromArgb(217, 223, 239);
                //Writing Product Name to the table with Formatting.
                paragraph = (IWParagraph)row1.Cells[1].AddParagraph();
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                text = paragraph.AppendText("Grape Juice");
                text.CharacterFormat.Bold = true;
                text.CharacterFormat.FontSize = 10f;
                text.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(50, 65, 124);
                row1.Cells[1].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                row1.Cells[1].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                row1.Cells[1].CellFormat.BackColor = System.Drawing.Color.FromArgb(217, 223, 239);

                //Writing Product Images to the Table.
                paragraph = (IWParagraph)row1.Cells[2].AddParagraph();
                paragraph.AppendPicture(System.Drawing.Image.FromFile(dataPath + "Grape Juice.png"));
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                row1.Cells[2].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                row1.Cells[2].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                row1.Cells[2].CellFormat.BackColor = System.Drawing.Color.FromArgb(217, 223, 239);
                sno++;
                row1 = table.AddRow(false);

                //Writing SNO to the table with formatting text.
                paragraph = (IWParagraph)row1.Cells[0].AddParagraph();
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                text = paragraph.AppendText(sno.ToString());
                text.CharacterFormat.Bold = true;
                text.CharacterFormat.FontSize = 10f;
                row1.Cells[0].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                row1.Cells[0].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                row1.Cells[0].CellFormat.BackColor = System.Drawing.Color.FromArgb(217, 223, 239);
                //Writing Product Name to the table with Formatting.
                paragraph = (IWParagraph)row1.Cells[1].AddParagraph();
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                text = paragraph.AppendText("Hot Soup");
                text.CharacterFormat.Bold = true;
                text.CharacterFormat.FontSize = 10f;
                text.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(50, 65, 124);
                row1.Cells[1].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                row1.Cells[1].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                row1.Cells[1].CellFormat.BackColor = System.Drawing.Color.FromArgb(217, 223, 239);

                //Writing Product Images to the Table.
                paragraph = (IWParagraph)row1.Cells[2].AddParagraph();
                paragraph.AppendPicture(System.Drawing.Image.FromFile(dataPath + "Hot Soup.png"));
                paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                row1.Cells[2].CellFormat.VerticalAlignment = Syncfusion.DocIO.DLS.VerticalAlignment.Middle;
                row1.Cells[2].CellFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                row1.Cells[2].CellFormat.BackColor = System.Drawing.Color.FromArgb(217, 223, 239);
                sno++;
                #endregion Table with Images
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
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        # endregion
    }
}