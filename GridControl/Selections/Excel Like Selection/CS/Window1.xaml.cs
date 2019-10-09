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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;

namespace ExcelLikeSelection
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {

        public Window1()
        {
            InitializeComponent();
            gridControl1.Model.ColumnCount = 25;
            gridControl1.Model.RowCount = 100;
            this.gridControl1.Model.Options.ExcelLikeCurrentCell = true;
            this.gridControl1.Model.Options.ExcelLikeSelectionFrame = true;
            GridExcelMarkerMouseController controller = new GridExcelMarkerMouseController(this.gridControl1);
            this.gridControl1.MouseControllerDispatcher.Add(controller);

            Random r = new Random();
            for (int row = 1; row < 400; row++)
            {
                for (int col = 1; col < 400; col++)
                {
                    if (r.Next(100) > 60)
                        gridControl1.Model[row, col].Text = r.Next(5000, 10000).ToString();
                }
            }
        }   
    }
}
