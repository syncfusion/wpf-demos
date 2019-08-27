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
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Controls.Grid;
using System.Data;
using Syncfusion.Windows.Shared;

namespace GridControlCommentService
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
            gridControl1.Model.RowCount = dataTable.Rows.Count;
            gridControl1.Model.ColumnCount = dataTable.Columns.Count;
            gridControl1.Model.RowHeights.DefaultLineSize = 30;
            gridControl1.Model.ColumnWidths.DefaultLineSize = 115;
            gridControl1.Model.ColumnWidths[0] = 115;
            gridControl1.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
            gridControl1.QueryCellInfo += new GridQueryCellInfoEventHandler(gridControl1_QueryCellInfo);
        }

        void gridControl1_QueryCellInfo(object sender, Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs e)
        {
            GridCommentStyleInfo styleinfo = new GridCommentStyleInfo();

            if (e.Style.ColumnIndex == 0 || e.Style.RowIndex == 0)
            {
                e.Style.CellType = "DataBoundTemplate";
                e.Style.CellItemTemplateKey = "TextBlocktemplate";
            }

            if (e.Style.RowIndex == 0)
                e.Style.CellValue = dataTable.Columns[e.Style.ColumnIndex];
            else
            {
                e.Style.CellValue = dataTable.Rows[e.Style.RowIndex][e.Style.ColumnIndex];

                if ((e.Style.ColumnIndex == 2 || e.Style.ColumnIndex == 4 || e.Style.ColumnIndex == 6) && e.Style.RowIndex > 0)
                {
                    string comment = " " + dataTable.Rows[e.Style.RowIndex][0].ToString() + ": \n Population rate in " + dataTable.Columns[e.Style.ColumnIndex] + " is " + e.Style.CellValue.ToString();
                    if (e.Style.ColumnIndex == 2)
                    {
                        e.Style.Background = Brushes.WhiteSmoke;
                        styleinfo.TopLeftCommentBrush = Brushes.Black;
                        styleinfo.BottomRightCommentBrush = Brushes.Green;
                        styleinfo.TopLeftComment = styleinfo.BottomRightComment = comment;
                        e.Style.GridCommentStyleInfo = styleinfo;
                    }
                    else if (e.Style.ColumnIndex == 6)
                    {
                        styleinfo.BottomLeftCommentBrush = Brushes.BlueViolet;
                        styleinfo.TopRightCommentBrush = Brushes.DarkMagenta;
                        styleinfo.BottomLeftComment = styleinfo.TopRightComment = comment;
                        e.Style.GridCommentStyleInfo = styleinfo;
                    }
                    else
                        e.Style.Comment = comment;
                }
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

    }
}