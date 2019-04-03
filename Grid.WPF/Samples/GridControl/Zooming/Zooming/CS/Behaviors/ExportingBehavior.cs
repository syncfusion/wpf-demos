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
using Zooming.Model;

namespace Zooming.Behaviors
{
    public class ExportingBehavior : Behavior<GridControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Model.CommittedCellInfo += Model_CommittedCellInfo;
        }

        void Model_CommittedCellInfo(object sender, GridCommitCellInfoEventArgs e)
        {
            List<Order> orders = this.AssociatedObject.DataContext as List<Order>;
            if (e.Cell.RowIndex > 0 && e.Cell.ColumnIndex > 0 && e.Style.HasCellValue)
            {
                orders[e.Cell.RowIndex - 1][e.Cell.ColumnIndex] = e.Style.CellValue.ToString();
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.CommittedCellInfo -= Model_CommittedCellInfo;
        }
    }
}
