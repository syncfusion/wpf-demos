using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Scroll;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.GridCommon;

namespace VirtualGrid
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        public Window1()
        {
            InitializeComponent();
            this.DataContext = new Dictionary<RowColumnIndex, object>();
            InitializeGridControl();
        }

        private void InitializeGridControl()
        {
            // a really large row and column count.
            grid.Model.RowCount = 99000000; // 99 million
            grid.Model.ColumnCount = 1000000; // 1 million
            // Resize millions of rows instantly - pixel scrolling is updated accordingly.
            grid.Model.RowHeights.SetRange(10, 1999999, 28);
            grid.Model.RowHeights.SetRange(21111111, 21999999, 36);
            grid.Model.TableStyle.CellType = "Static"; 
        }
    }
}
