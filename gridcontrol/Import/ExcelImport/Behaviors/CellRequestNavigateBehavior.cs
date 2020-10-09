#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.gridcontroldemos.wpf
{
    public class CellRequestNavigateBehavior : Microsoft.Xaml.Behaviors.Behavior<GridControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Model.CellRequestNavigate += new CellRequestNavigateEventHandler(Model_CellRequestNavigate);
        }

        void Model_CellRequestNavigate(object sender, CellRequestNavigateEventArgs e)
        {
            var dataContext = AssociatedObject.DataContext as ExcelImportViewModel;
            if (dataContext != null && dataContext.MainView != null)
                dataContext.MainView.GidCellRequestNavigate(e.Name, e.RowIndex, e.ColumnIndex);
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.CellRequestNavigate -= new CellRequestNavigateEventHandler(Model_CellRequestNavigate);
        }
    }
}
