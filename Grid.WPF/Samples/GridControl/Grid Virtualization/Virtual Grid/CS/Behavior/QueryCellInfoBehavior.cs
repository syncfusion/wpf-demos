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
using Syncfusion.Windows.Controls.Cells;

namespace VirtualGrid.Behavior
{
    /// <summary>
    /// Fill cell contents on demand.
    /// </summary>
    public class QueryCellInfoBehavior : Behavior<GridControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Model.QueryCellInfo += Model_QueryCellInfo;
        }

        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            Dictionary<RowColumnIndex, object> committedValues = this.AssociatedObject.DataContext as Dictionary<RowColumnIndex, object>;
            if (committedValues != null)
            {
                if (e.Cell.RowIndex == 0)
                {
                    if (e.Cell.ColumnIndex > 0)
                        e.Style.CellValue = e.Cell.ColumnIndex;
                }
                else if (e.Cell.RowIndex > 0)
                {
                    if (e.Cell.ColumnIndex == 0)
                        e.Style.CellValue = e.Cell.RowIndex;
                    else if (e.Cell.ColumnIndex > 0)
                    {
                        if (committedValues.ContainsKey(e.Cell))
                            e.Style.CellValue = committedValues[e.Cell];
                        else
                            e.Style.CellValue = String.Format("{0}/{1}", e.Cell.RowIndex, e.Cell.ColumnIndex);
                    }
                }
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.QueryCellInfo -= Model_QueryCellInfo;
        }
    }
}
