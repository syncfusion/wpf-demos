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
using Syncfusion.Windows.Controls.Grid.Converter;
using Syncfusion.Windows.Shared;

namespace GCExport
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        public Window1()
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
    }
}
