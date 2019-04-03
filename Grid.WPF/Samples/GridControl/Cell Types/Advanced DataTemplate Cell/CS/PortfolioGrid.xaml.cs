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
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;
using PortfolioManager1.Model;

using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Chart;
using System.Collections.ObjectModel;
using System.Collections;
using Syncfusion.Windows.Controls.Cells;
using System.Xml.Serialization;
using System.Reflection;
using Syncfusion.Windows.ComponentModel;
using Syncfusion.Windows.Data;
using PortfolioManager1.Helpers;
using PortfolioManager1.ViewModel;
using Syncfusion.Windows.Shared;

namespace PortfolioManager1
{
    /// <summary>
    /// Interaction logic for PortfolioGrid.xaml
    /// </summary>
    public partial class PortfolioGrid : ChromelessWindow, IMainView
    {
        public PortfolioGrid()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(this);
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
    }
}
