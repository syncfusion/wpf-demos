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
    /// Save back cell value into dictionary
    /// </summary>
    public class CommitCellInfoBehavior :  Behavior<GridControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Model.CommittedCellInfo += Model_CommittedCellInfo;
        }

        void Model_CommittedCellInfo(object sender, GridCommitCellInfoEventArgs e)
        {
            Dictionary<RowColumnIndex, object> committedValues = this.AssociatedObject.DataContext as Dictionary<RowColumnIndex, object>;
            if (committedValues != null && e.Style.HasCellValue)
            {
                committedValues[e.Cell] = e.Style.CellValue;
                e.Handled = true;
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.CommittedCellInfo -= Model_CommittedCellInfo;
        }
    }
}
