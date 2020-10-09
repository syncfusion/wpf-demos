#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for CustomDataTemplateCell.xaml
    /// </summary>
    public partial class CustomDataTemplateCell : DemoControl
    {
        EmployeesSource employeesSource = new EmployeesSource();

        public CustomDataTemplateCell()
        {
            InitializeComponent();

            grid.Model.RowCount = 35;
            grid.Model.ColumnCount = 25;

            grid.Model.CellModels.Add("DataTemplate", new DataTemplateCellModel());
            grid.Model.QueryCellInfo += new Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventHandler(Model_QueryCellInfo);

            grid.Model.ColumnWidths[2] = 250;
        }

        public CustomDataTemplateCell(string themename) : base(themename)
        {
            InitializeComponent();

            grid.Model.RowCount = 35;
            grid.Model.ColumnCount = 25;

            grid.Model.CellModels.Add("DataTemplate", new DataTemplateCellModel());
            grid.Model.QueryCellInfo += new Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventHandler(Model_QueryCellInfo);

            grid.Model.ColumnWidths[2] = 250;
        }

        void Model_QueryCellInfo(object sender, Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs e)
        {
            
            if (e.Cell.RowIndex > 1 && e.Cell.ColumnIndex == 2)
            {
                e.Style.CellType = "DataTemplate";
                e.Style.CellItemTemplateKey = "editableEmployee";
                e.Style.CellValue = employeesSource.Employees[e.Cell.RowIndex % employeesSource.Employees.Count];
                e.Style.Background = Brushes.Linen;

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
