#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.CellGrid;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.UI.Xaml.Spreadsheet.Commands;
using Syncfusion.XlsIO;
using Syncfusion.XlsIO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;
using System.Windows.Media;

namespace syncfusion.spreadsheetdemos.wpf
{
    public class ClickBehavior : Behavior<Button>
    {
        private SfSpreadsheet spreadsheet;

        protected override void OnAttached()
        {
            spreadsheet = AssociatedObject.DataContext as SfSpreadsheet;
            this.AssociatedObject.PreviewMouseDown += AssociatedObject_PreviewMouseDown;
            base.OnAttached();
        }
        private void AssociatedObject_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var outlineWrappers = (spreadsheet.ActiveSheet as WorksheetImpl).OutlineWrappers;
            var buttonTemplate = (sender as Button);

            DependencyObject parent = sender as Button;
            while (parent != null)
            {
                parent = VisualTreeHelper.GetParent(parent);
                if (parent is GridCell)
                    break;
            }
            var rowIndex = (parent as GridCell).RowIndex;

            foreach (var item in outlineWrappers)
            {
                if (rowIndex.Equals(item.FirstIndex - 1))
                {
                    if (item.IsCollapsed)
                    {
                        VisualStateManager.GoToState(buttonTemplate, "Expanded", true);
                        spreadsheet.ActiveSheet.Range[item.OutlineRange.AddressLocal].ExpandGroup(ExcelGroupBy.ByRows);
                        spreadsheet.ActiveGrid.RowHeights.SetHidden(item.FirstIndex, item.LastIndex, false);
                    }
                    else
                    {
                        VisualStateManager.GoToState(buttonTemplate, "Collapsed", true);
                        spreadsheet.ActiveSheet.Range[item.OutlineRange.AddressLocal].CollapseGroup(ExcelGroupBy.ByRows);
                        spreadsheet.ActiveGrid.RowHeights.SetHidden(item.FirstIndex, item.LastIndex, true);
                    }
                    break;
                }
            }
        }
        protected override void OnDetaching()
        {
            this.AssociatedObject.PreviewMouseDown -= AssociatedObject_PreviewMouseDown;
            spreadsheet = null;
            base.OnDetaching();
        }
    }
}
