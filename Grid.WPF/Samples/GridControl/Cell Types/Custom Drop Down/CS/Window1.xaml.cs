#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace CustomDD_2008
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
    using Syncfusion.Windows.Controls.Cells;
    using Syncfusion.Windows.Controls.Grid;
    using Syncfusion.Windows.GridCommon;
    using Syncfusion.Windows.Shared;

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        public Window1()
        {
            this.InitializeComponent();
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
    }
}
