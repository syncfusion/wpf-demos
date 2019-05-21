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
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;
using Syncfusion.Windows.GridCommon;
using Zooming.Model;
using System.Windows;

namespace Zooming.Behaviors
{
    public class ImportingBehavior : Behavior<GridControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Model.QueryCellInfo += Model_QueryCellInfo;
        }

        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            List<Order> orders = this.AssociatedObject.DataContext as List<Order>;
            if (e.Cell.RowIndex == 0 && e.Cell.ColumnIndex == 0)
            {}
            else if (e.Cell.RowIndex == 0)
            {
                e.Style.CellValue = Order.GetPropertyName(e.Cell.ColumnIndex);
            }
            else if (e.Cell.ColumnIndex == 0)
            {
                e.Style.CellValue = e.Cell.RowIndex;
            }
            else
            {
                e.Style.CellValue = orders[e.Cell.RowIndex - 1][e.Cell.ColumnIndex];
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.QueryCellInfo -= Model_QueryCellInfo;
        }
    }
}
