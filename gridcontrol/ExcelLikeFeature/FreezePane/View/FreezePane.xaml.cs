#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.gridcontroldemos.wpf
{
    using System.Windows;
    using System.Windows.Media;
    using syncfusion.demoscommon.wpf;
    using Syncfusion.Windows.GridCommon;
    using Syncfusion.Windows.Shared;

    /// <summary>
    /// Interaction logic for FreezePane.xaml
    /// </summary>
    public partial class FreezePane : DemoControl, IFreezePanel
    {
        public FreezePane()
        {
            InitializeComponent();
            this.DataContext = new FreezePanelViewModel(this);
        }

        public FreezePane(string themename) : base(themename)
        {
            InitializeComponent();
            this.DataContext = new FreezePanelViewModel(this);
        }
        bool frozen = false;

        public void Initialize()
        {
            this.grid.Model.Options.ExcelLikeFreezePane = true;
            this.grid.AllowDragColumns = true;
            this.grid.Model.RowCount = 50;
            this.grid.Model.ColumnCount = 50;
            for (int i = 1; i < 50; i++)
            {
                for (int j = 1; j < 50; j++)
                {
                    this.grid.Model[i, j].CellValue = string.Format("Row{0} Col{1}", i, j);
                }
            }
        }

        public void SetFreezePane()
        {
            if (this.grid.CurrentCell.RowIndex == -1)
            {
                MessageBox.Show("Select any Cell");
                return;
            }

            frozen = !frozen;

            if (frozen)
            {
                this.grid.Model.FrozenRows = this.grid.CurrentCell.RowIndex;
                this.grid.Model.FrozenColumns = this.grid.CurrentCell.ColumnIndex;
                this.button1.Content = this.button1.Content.ToString().Replace("Freeze", "Unfreeze");
            }
            else
            {
                this.grid.Model.FrozenRows = 1;
                this.grid.Model.FrozenColumns = 1;
                this.button1.Content = this.button1.Content.ToString().Replace("Unfreeze", "Freeze");
            }
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
