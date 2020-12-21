#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Cells;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for AdvancedDataTemplateCell.xaml
    /// </summary>
    public partial class AdvancedDataTemplateCell : DemoControl, IAdvancedDataTemplateCell
    {
        public AdvancedDataTemplateCell()
        {
            InitializeComponent();
            this.DataContext = new AdvancedDataTemplateCellViewModel(this);
        }

        public AdvancedDataTemplateCell(string themename) : base(themename)
        {
            InitializeComponent();
            this.DataContext = new AdvancedDataTemplateCellViewModel(this);
        }

        public void Initialize()
        {
            GridHost.Model.Options.ShowCurrentCell = false;
            this.GridHost.Model.Options.AllowSelection = GridSelectionFlags.None;
            this.GridHost.Model.Options.ListBoxSelectionMode = GridSelectionMode.None;
            GridHost.Model.ColumnWidths.SetHidden(0, 0, true);
            GridHost.Model.RowHeights.SetHidden(0, 0, true);
            GridHost.Model.TableStyle.Borders.Bottom = null;
            GridHost.Model.TableStyle.Borders.Right = null;

            GridHost.Model.RowHeights[1] = 320;
            GridHost.Model.RowHeights[2] = 240;
            GridHost.Model.RowHeights[3] = 400;
            GridHost.Model.ColumnWidths[1] = GridHost.Model.ColumnWidths[2] = 410;
            GridHost.Model.ColumnWidths[3] = 450;

            GridHost.CoveredCells.Add(new CoveredCellInfo(1, 1, 2, 2));
            GridHost.Model[1, 1].CellType = "DataBoundTemplate";
            GridHost.Model[1, 1].CellItemTemplateKey = "MainGrid";
            GridHost.Model[1, 1].CellEditTemplateKey = "MainGrid";
            GridHost.Model[3, 1].CellType = "DataBoundTemplate";
            GridHost.Model[3, 1].CellItemTemplateKey = "SectorIndustryGrid";
            GridHost.Model[3, 1].CellEditTemplateKey = "SectorIndustryGrid";
            GridHost.Model[3, 2].CellType = "DataBoundTemplate";
            GridHost.Model[3, 2].CellItemTemplateKey = "StockExhangeGrid";
            GridHost.Model[3, 2].CellEditTemplateKey = "StockExhangeGrid";
            GridHost.Model[1, 3].CellType = "DataBoundTemplate";
            GridHost.Model[1, 3].CellItemTemplateKey = "Performance";
            GridHost.Model[1, 3].CellEditTemplateKey = "Performance";
            GridHost.CoveredCells.Add(new CoveredCellInfo(2, 3, 4, 3));
            GridHost.Model[2, 3].CellType = "DataBoundTemplate";
            GridHost.Model[2, 3].CellItemTemplateKey = "Contribution";
            GridHost.Model[2, 3].CellEditTemplateKey = "Contribution";
        }
        protected override void Dispose(bool disposing)
        {
            if (this.GridHost != null)
            {
                this.GridHost.Dispose();
                this.GridHost = null;
            }
            base.Dispose(disposing);
        }
    }
}
