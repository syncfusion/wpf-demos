#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.gridcontroldemos.wpf
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
    using syncfusion.demoscommon.wpf;
    using Syncfusion.Windows.Controls.Cells;
    using Syncfusion.Windows.Controls.Grid;
    using Syncfusion.Windows.GridCommon;
    using Syncfusion.Windows.Shared;
    /// <summary>
    /// Interaction logic for CustomDropDown.xaml
    /// </summary>
    public partial class CustomDropDown : DemoControl
    {
        public CustomDropDown()
        {
            this.InitializeComponent();
            GridSettings();
        }

        public CustomDropDown(string themename) : base(themename)
        {
            this.InitializeComponent();
            GridSettings();
        }

        void GridSettings()
        {

            this.grid.Model.RowCount = 35;
            this.grid.Model.ColumnCount = 25;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(1, 1, 3, 4));

            var cell = this.grid.Model[1, 1];
            cell.CellValue = "Custom Drop-down";
            cell.Foreground = Brushes.Black;
            cell.Background = Brushes.LightBlue;
            cell.Font.FontSize = 18;
            cell.HorizontalAlignment = HorizontalAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.Font.FontWeight = FontWeights.Bold;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(4, 1, 5, 8));

            cell = this.grid.Model[4, 1];
            cell.CellValue = "This sample showcases how we can create custom drop downs. This sample creates a image and text display inside the drop down";
            cell.Foreground = Brushes.Black;
            cell.HorizontalAlignment = HorizontalAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.Font.FontWeight = FontWeights.Bold;
            this.grid.Model.CellModels.Add("CustomDropDown", new CustomeDropDownCellModel());
            var dropdown1 = this.grid.Model[7, 2];
            dropdown1.CellType = "CustomDropDown";
            dropdown1.ItemsSource = new ListBoxContent().GenerateListBoxContent();
            dropdown1.DisplayMember = "Text";
            dropdown1.DropDownStyle = GridDropDownStyle.Exclusive;
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
