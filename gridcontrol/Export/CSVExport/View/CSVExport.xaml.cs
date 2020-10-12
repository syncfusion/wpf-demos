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
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Controls.Grid.Converter;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for CSVExport.xaml
    /// </summary>
    public partial class CSVExport : DemoControl
    {
        public CSVExport()
        {
            InitializeComponent();
            this.gc.Model.TableStyle.ReadOnly = true;
            this.gc.Model.RowCount = 35;
            this.gc.Model.ColumnCount = 25;
            this.gc.Model.QueryCellInfo += (s, e) =>
            {
                if (e.Style.RowIndex > 0 && e.Style.ColumnIndex > 0)
                    e.Style.CellValue = string.Format("R{0}C{1}", e.Cell.RowIndex, e.Cell.ColumnIndex);
            };
            //this.gc.Model.ColumnWidths[0] = 80;
       
            gc.Model.Options.ColumnSizer = GridControlLengthUnitType.AutoWithLastColumnFill;
        }

        public CSVExport(string themename) : base(themename)
        {
            InitializeComponent();
            this.gc.Model.TableStyle.ReadOnly = true;
            this.gc.Model.RowCount = 35;
            this.gc.Model.ColumnCount = 25;
            this.gc.Model.QueryCellInfo += (s, e) =>
            {
                if (e.Style.RowIndex > 0 && e.Style.ColumnIndex > 0)
                    e.Style.CellValue = string.Format("R{0}C{1}", e.Cell.RowIndex, e.Cell.ColumnIndex);
            };
            //this.gc.Model.ColumnWidths[0] = 80;

            gc.Model.Options.ColumnSizer = GridControlLengthUnitType.AutoWithLastColumnFill;
        }

        private void selExport_Click(object sender, RoutedEventArgs e)
        {
            GridRangeInfoList rangeList = gc.Model.SelectedRanges;
            if (rangeList.Count > 0)
            {
                GridRangeInfo range = rangeList[0];
                gc.Model.ExportToCSV(range, @"Sample.csv");
                try
                {
                    System.Diagnostics.Process.Start("Sample.csv");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Select the range first");
            }
        }

        private void fullExport_Click(object sender, RoutedEventArgs e)
        {
            this.gc.Model.ExportToCSV("Sample.csv");
            try
            {
                System.Diagnostics.Process.Start("Sample.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
