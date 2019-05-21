#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;

namespace FloatingCells
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.grid.Model.Options.EnableFloatingCell = true;
            InitGrid();
        }

        private void InitGrid()
        {
            this.grid.Model.RowCount = 30;
            this.grid.Model.ColumnCount = 25;
            grid.Model.Options.WrapCell = false;
            grid.Model.TableStyle.TextWrapping = TextWrapping.NoWrap;
            grid.Model.TableStyle.FloatCellMode = GridFloatCellsMode.OnDemandCalculation;
            this.grid.Model.Options.EnableFloatingCell = true;
            this.grid.Model.Options.ActivateCurrentCellBehavior = Syncfusion.Windows.Controls.Grid.GridCellActivateAction.DblClickOnCell;
            this.grid.Model.Options.FloatCellMode = GridFloatCellsMode.OnDemandCalculation;
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(1, 1, 2, 8));
            grid.Model[1, 1].CellValue = "Floating Cell Demo";
            grid.Model[1, 1].Font.FontSize = 18;
            grid.Model[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
            grid.Model[1, 1].Font.FontWeight = FontWeights.Bold;

            this.grid.Model[4, 1].CellValue = "Control overview";
            this.grid.Model[5, 1].CellValue = "Public Constructor";
            this.grid.Model[5, 2].CellValue = "Gets the AccessibleObject assigned to the control";
            this.grid.Model[6, 1].CellValue = "Control Constructor Overloaded";
            this.grid.Model[6, 2].CellValue = "Initializes a new instance of the Control class.";
            this.grid.Model[7, 1].CellValue = "Public Properties";
            this.grid.Model[8, 1].CellValue = "Accessibility Object";
            this.grid.Model[8, 2].CellValue = "Gets the AccessibleObject assigned to the control.";
            this.grid.Model[9, 1].CellValue = "AccessibleDefaultAction";
            this.grid.Model[9, 2].CellValue = "Gets or sets the default action description of the control for use by accessibility client applications.";
            this.grid.Model[10, 1].CellValue = "AccessibleDescription";
            this.grid.Model[10, 2].CellValue = "Gets or sets the description of the control used by accessibility client applications.";
            this.grid.Model[11, 1].CellValue = "AccessibleName";
            this.grid.Model[11, 2].CellValue = "Gets or sets the name of the control used by accessibility client applications.";
            this.grid.Model[12, 1].CellValue = "AccessibleRole";
            this.grid.Model[12, 2].CellValue = "Gets or sets the accessible role of the control";
            this.grid.Model[13, 1].CellValue = "AllowDrop";
            this.grid.Model[13, 2].CellValue = "Gets or sets a value indicating whether the control can accept data that the user drags onto it.";
            this.grid.Model[14, 1].CellValue = "Anchor";
            this.grid.Model[14, 2].CellValue = "Gets or sets which edges of the control are anchored to the edges of its container.";
            this.grid.Model[15, 1].CellValue = "BackColor";
            this.grid.Model[15, 2].CellValue = "Gets or sets the background color for the control.";
            this.grid.Model[16, 1].CellValue = "BackgroundImage";
            this.grid.Model[16, 2].CellValue = "Gets or sets the background image displayed in the control. ";
            this.grid.Model[17, 1].CellValue = "BindingContext";
            this.grid.Model[17, 2].CellValue = "Gets or sets the BindingContext for the control.";
            this.grid.Model[18, 1].CellValue = "Bottom";
            this.grid.Model[18, 2].CellValue = "Gets the distance between the bottom edge of the control and the top edge of its container's client area.";
        }

        private void floatingcells_Click(object sender, RoutedEventArgs e)
        {
            this.grid.Model.Options.EnableFloatingCell = (bool)this.floatingcells.IsChecked;
        }
    }
}
