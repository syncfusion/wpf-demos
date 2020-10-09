#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Media;
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for VirtualCell.xaml
    /// </summary>
    public partial class VirtualCell : DemoControl
    {
        public VirtualCell()
        {
            InitializeComponent();
            InitializeGridControl();
        }
        public VirtualCell(string themename) : base(themename)
        {
            InitializeComponent();
            InitializeGridControl();
        }
        private void InitializeGridControl()
        {
            grid.Model.RowCount = 100 + 1;
            grid.Model.ColumnCount = 25 + 1;

            grid.Model.CellModels.Add("VirtualizedCell", new VirtualizedCellModel());
            grid.Model.TableStyle.CellType = "VirtualizedCell";
            grid.Model.TableStyle.CellValue = "Edit Me!";
            grid.Model.HeaderStyle.CellValue = "";
        }

        protected override void Dispose(bool disposing)
        {
            if (this.grid != null)
            {
                this.grid.Dispose();
                this.grid = null;
            }
            base.Dispose(disposing);
        }
    }
}
