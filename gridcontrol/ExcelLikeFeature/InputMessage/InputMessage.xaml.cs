#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Syncfusion.Windows.GridCommon;
using System.Data;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for InputMessage.xaml
    /// </summary>
    public partial class InputMessage : DemoControl
    {
        Random random;
        DataTable dataTable;
        public InputMessage()
        {
            InitializeComponent();
            this.LoadData();
            gridControl1.Model.RowCount = dataTable.Rows.Count;
            gridControl1.Model.ColumnCount = dataTable.Columns.Count;
            gridControl1.Model.RowHeights.DefaultLineSize = 30;
            gridControl1.Model.ColumnWidths.DefaultLineSize = 115;
            gridControl1.Model.ColumnWidths[0] = 115;
            Width = 1000;
            Height = 600;
            gridControl1.Model.HeaderStyle.BorderMargins = new Syncfusion.Windows.Controls.Cells.CellMarginsInfo(5);
            gridControl1.Model.Options.ActivateCurrentCellBehavior = Syncfusion.Windows.Controls.Grid.GridCellActivateAction.DblClickOnCell;
            gridControl1.QueryCellInfo += new Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventHandler(gridControl1_QueryCellInfo);
        }
        public InputMessage(string themename) : base(themename)
        {
            InitializeComponent();
            this.LoadData();
            gridControl1.Model.RowCount = dataTable.Rows.Count;
            gridControl1.Model.ColumnCount = dataTable.Columns.Count;
            gridControl1.Model.RowHeights.DefaultLineSize = 30;
            gridControl1.Model.ColumnWidths.DefaultLineSize = 115;
            gridControl1.Model.ColumnWidths[0] = 115;
            Width = 1000;
            Height = 600;
            gridControl1.Model.HeaderStyle.BorderMargins = new Syncfusion.Windows.Controls.Cells.CellMarginsInfo(5);
            gridControl1.Model.Options.ActivateCurrentCellBehavior = Syncfusion.Windows.Controls.Grid.GridCellActivateAction.DblClickOnCell;
            gridControl1.QueryCellInfo += new Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventHandler(gridControl1_QueryCellInfo);
        }
        void gridControl1_QueryCellInfo(object sender, Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs e)
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

        protected override void Dispose(bool disposing)
        {
            if (this.gridControl1 != null)
            {
                this.gridControl1.Dispose();
                this.gridControl1 = null;
            }
            base.Dispose(disposing);
        }
    }
}
