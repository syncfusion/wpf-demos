#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Syncfusion.Presentation;
using System.Diagnostics;
using System.IO;
using Syncfusion.Windows.Shared;
using System.Data;
//using CreatePresentation;
using syncfusion.demoscommon.wpf;

namespace syncfusion.presentationdemos.wpf
{
    /// <summary>
    /// Interaction logic for Tables.xaml
    /// </summary>
    public partial class Tables : DemoControl
    {

        public Tables()
        {
            InitializeComponent();
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        private void btnCreatePresn_Click(object sender, EventArgs e)
        {
            //Creates a new instance of the presentation.
            using (IPresentation presentation = Presentation.Create())
            {
                #region Slide1
                //To add a slide to PowerPoint presentation
                ISlide slide = presentation.Slides.Add(SlideLayoutType.TitleOnly);
                //To set the table title in a slide
                SetTableTitle(slide);
                //Get table data from xml file
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(@"Assets\Presentation\TableData.xml");

                int columnCount = dataSet.Tables[0].Rows.Count + 1;
                int rowCount = dataSet.Tables.Count - 1;
                //To add a new table in slide.
                ITable table = slide.Shapes.AddTable(rowCount, columnCount, 61.92, 95.76, 856.8, 378.72);
                //To set the style for the table.
                table.BuiltInStyle = BuiltInTableStyle.MediumStyle2Accent6;

                //To set category title
                SetCategoryTitle(table);
                //Iterates and sets the values to the table cells.
                for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                {
                    IRow row = table.Rows[rowIndex];
                    if (rowIndex == 0)
                        AddHeaderRow(row, dataSet.Tables[0].Rows);
                    else
                        AddCell(row, dataSet.Tables[rowIndex + 1]);
                }
                #endregion

                //Saves the presentation
                presentation.Save("Tables.pptx");

                if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Tables.pptx") { UseShellExecute = true };
                    process.Start();
                }
            }
        }

        #region HelperMethods        

        /// <summary>
        /// Sets the table title.
        /// </summary>
        /// <param name="slide">Represents the slide instance of the presentation.</param>
        private void SetTableTitle(ISlide slide)
        {
            IShape shape = slide.Shapes[0] as IShape;
            shape.Left = 84.24;
            shape.Top = 0;
            shape.Width = 792;
            shape.Height = 126.72;
            ITextBody textFrame = shape.TextBody;
            IParagraphs paragraphs = textFrame.Paragraphs;
            paragraphs.Add();
            IParagraph paragraph = paragraphs[0];
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;

            //Instance to hold textparts in paragraph.
            ITextParts textParts = paragraph.TextParts;
            textParts.Add();
            ITextPart textPart = textParts[0];
            textPart.Text = "Target ";
            IFont font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 28;
            font.Bold = true;
            font.CapsType = TextCapsType.All;
            textParts.Add();

            //Creates a textpart and assigns value to it.
            textPart = textParts[1];
            textPart.Text = "Vs ";
            font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 18;
            textParts.Add();

            //Creates a textpart and assigns value to it.
            textPart = textParts[2];
            textPart.Text = "PERFORMANCE";
            font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 28;
            font.Bold = true;
        }

        /// <summary>
        /// Adds the cell content to the table.
        /// </summary>
        /// <param name="row">Represents the instance of row.</param>
        /// <param name="dataTable">Represents the table of the data.</param>
        private void AddCell(IRow row, DataTable dataTable)
        {
            DataRowCollection dataRowCollection = dataTable.Rows;
            for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
            {
                ICell cell = row.Cells[cellIndex];
                //Instance to hold paragraphs in cell.
                IParagraphs paragraphs = cell.TextBody.Paragraphs;
                paragraphs.Add();
                IParagraph paragraph = paragraphs[0];
                paragraph.HorizontalAlignment = HorizontalAlignmentType.Left;
                ITextParts textParts = paragraph.TextParts;
                textParts.Add();

                //Creates a textpart and assigns value to it.
                ITextPart textPart = textParts[0];
                if (cellIndex == 0)
                    textPart.Text = dataTable.TableName;
                else
                    textPart.Text = dataRowCollection[cellIndex - 1].ItemArray[0].ToString();
                IFont font = textPart.Font;
                font.FontName = "Arial";
                font.FontSize = 14;
            }
        }

        /// <summary>
        /// Adds the content for the row and column for the table.
        /// </summary>
        /// <param name="row">Represents the particular row.</param>
        /// <param name="dataRowCollections">Represents the row collections of the data.</param>
        private void AddHeaderRow(IRow row, DataRowCollection dataRowCollections)
        {
            for (int cellIndex = 1; cellIndex < row.Cells.Count; cellIndex++)
            {
                ICell cell = row.Cells[cellIndex];
                cell.TextBody.VerticalAlignment = VerticalAlignmentType.Middle;
                //To add a paragraph inside cell
                IParagraphs paragraphs = cell.TextBody.Paragraphs;
                if (paragraphs.Count == 0)
                    paragraphs.Add();
                IParagraph paragraph = paragraphs[0];
                paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;
                ITextParts textParts = paragraph.TextParts;
                if (textParts.Count == 0)
                    textParts.Add();

                //Creates a textpart and assigns value to it.
                ITextPart textPart = textParts[0];
                textPart.Text = dataRowCollections[cellIndex - 1].ItemArray[0].ToString();
                IFont font = textPart.Font;
                font.FontName = "Arial";
                font.FontSize = 14;
                font.Bold = true;
            }
        }

        /// <summary>
        /// Sets the title for the category in the table.
        /// </summary>
        /// <param name="table">Instance to access the table from the presentation.</param>
        void SetCategoryTitle(ITable table)
        {
            //Instance to hold rows in the table
            table.Rows[0].Height = 81.44;
            //To set text alignment type inside cell
            //ICell cell11 = ;
            table.Rows[0].Cells[0].TextBody.VerticalAlignment = VerticalAlignmentType.Middle;

            //To add a paragraph inside cell
            IParagraphs paragraphs = table.Rows[0].Cells[0].TextBody.Paragraphs;
            paragraphs.Add();
            IParagraph paragraph = paragraphs[0];
            paragraph.HorizontalAlignment = HorizontalAlignmentType.Center;
            ITextParts textParts = paragraph.TextParts;
            textParts.Add();

            //Creates a textpart and assigns value to it.
            ITextPart textPart = textParts[0];
            textPart.Text = "Month";
            IFont font = textPart.Font;
            font.FontName = "Arial";
            font.FontSize = 14;
            font.Bold = true;
        }
        #endregion HelperMethods				
    }
}