#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Grid.Converter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Windows.Controls.Grid;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using Syncfusion.Windows.Shared;
using System.Data;
using Syncfusion.Windows.GridCommon;

namespace PdfExportDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        Random random;
        DataTable dataTable;

        public MainWindow()
        {
            InitializeComponent();
            Width = 1000;
            Height = 600;

            this.LoadData();
            this.grid.Model.TableStyle.ReadOnly = true;
            this.grid.Model.RowCount = dataTable.Rows.Count;
            this.grid.Model.ColumnCount = dataTable.Columns.Count;
            this.grid.Model.RowHeights.DefaultLineSize = 29;
            this.grid.Model.ColumnWidths.DefaultLineSize = 115;
            this.grid.Model.ColumnWidths[0] = 115;
            this.grid.QueryCellInfo += new GridQueryCellInfoEventHandler(grid_QueryCellInfo);
        }

        void grid_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if (e.Style.ColumnIndex == 0 || e.Style.RowIndex == 0)
            {
                e.Style.CellType = "DataBoundTemplate";
                e.Style.CellItemTemplateKey = "TextBlocktemplate";
                if (e.Style.RowIndex == 0)
                    e.Style.CellValue = dataTable.Columns[e.Style.ColumnIndex];
                else
                    e.Style.CellValue = dataTable.Rows[e.Style.RowIndex][e.Style.ColumnIndex];
            }
            else
            {
                e.Style.CellValue = dataTable.Rows[e.Style.RowIndex][e.Style.ColumnIndex];
                e.Style.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                e.Style.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                e.Style.DataValidationTooltip = " " + dataTable.Rows[e.Style.RowIndex][0].ToString() +
                                ": \n Population rate in " +
                                dataTable.Columns[e.Style.ColumnIndex] + " is " +
                                e.Style.CellValue.ToString();
                e.Style.ShowDataValidationTooltip = true;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                DefaultExt = ".pdf",
                Filter = "Adobe PDF Files(*.pdf)|*.pdf",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            PdfDocument document;
            if (sfd.ShowDialog() == true)
            {
                using (Stream stream = sfd.OpenFile())
                {
                    DrawingHeaderFooter();
                    document = this.grid.Model.ExportToPdfGridDocument(GridRangeInfo.Table());
                    document.Save(stream);
                    Process.Start(sfd.FileName);
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                DefaultExt = ".pdf",
                Filter = "Adobe PDF Files(*.pdf)|*.pdf",
                FilterIndex = 1
            };
            PdfDocument document;
            if (sfd.ShowDialog() == true)
            {
                using (Stream stream = sfd.OpenFile())
                {
                    DrawingHeaderFooter();
                    document = this.grid.Model.ExportToPdfLightTableDocument(GridRangeInfo.Table());
                    document.Save(stream);
                    Process.Start(sfd.FileName);
                }
            }
        }

        private void DrawingHeaderFooter()
        {
            if (checkBox1.IsChecked == true)
                GridPdfExportExtension.DrawPdfHeader += new DrawPdfHeaderFooterEventHandler(GridPdfExportExtension_DrawPdfHeader);
            else
                GridPdfExportExtension.DrawPdfHeader -= new DrawPdfHeaderFooterEventHandler(GridPdfExportExtension_DrawPdfHeader);

            if (checkBox2.IsChecked == true)
                GridPdfExportExtension.DrawPdfFooter += new DrawPdfHeaderFooterEventHandler(GridPdfExportExtension_DrawPdfFooter);
            else
                GridPdfExportExtension.DrawPdfFooter -= new DrawPdfHeaderFooterEventHandler(GridPdfExportExtension_DrawPdfFooter);
        }

        void GridPdfExportExtension_DrawPdfHeader(object sender, PdfHeaderFooterEventArgs e)
        {
            PdfPageTemplateElement header = e.HeaderFooterTemplate;
            header.Graphics.DrawImage(PdfImage.FromFile(@"..\..\..\Images\Footer.png"), 0, 0, header.Width, header.Height);
        }

        void GridPdfExportExtension_DrawPdfFooter(object sender, PdfHeaderFooterEventArgs e)
        {
            PdfPageTemplateElement header = e.HeaderFooterTemplate;
            header.Graphics.DrawImage(PdfImage.FromFile(@"..\..\..\Images\Footer.png"), 0, 0, header.Width, header.Height);
        }

        #region DataTable

        public void LoadData()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Country"));
            dataTable.Columns.Add(new DataColumn("2005"));
            dataTable.Columns.Add(new DataColumn("2006"));
            dataTable.Columns.Add(new DataColumn("2007"));
            dataTable.Columns.Add(new DataColumn("2008"));
            dataTable.Columns.Add(new DataColumn("2009"));
            dataTable.Columns.Add(new DataColumn("2010"));
            dataTable.Columns.Add(new DataColumn("2011"));
            random = new Random();

            var row = dataTable.NewRow();
            row["Country"] = "USA";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "India";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "China";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "Japan";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "Russia";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "Canada";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "Germany";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "Iran";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "Thailand";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "Bangladesh";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "Nigeria";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "Mexico";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "Egypt";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "France";
            LoadCellValues(row);
            dataTable.Rows.Add(row);
        }

        public void LoadCellValues(DataRow dataRow)
        {
            for (int row = 1; row <= 7; row++)
            {
                dataRow[row] = ((double)random.Next(2, 18)).ToString() + "%";
            }
        }

        #endregion
    }
}
