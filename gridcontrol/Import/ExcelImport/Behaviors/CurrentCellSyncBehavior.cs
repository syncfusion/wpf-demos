#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.ComponentModel;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.gridcontroldemos.wpf
{
    public class CurrentCellSyncBehavior : Behavior<GridControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.CurrentCellActivated += new GridRoutedEventHandler(AssociatedObject_CurrentCellActivated);
        }

        void AssociatedObject_CurrentCellActivated(object sender, SyncfusionRoutedEventArgs args)
        {
            var rowIndex = AssociatedObject.CurrentCell.RowIndex;
            var colIndex = AssociatedObject.CurrentCell.ColumnIndex;
            var style = AssociatedObject.Model[rowIndex, colIndex];
            var dataContext = AssociatedObject.DataContext as ExcelImportViewModel;
            if (dataContext != null)
            {
                dataContext.FontFamily = style.Font.FontFamily;
                dataContext.FontSize = style.Font.FontSize;
                dataContext.FontStyle = style.Font.FontStyle;
                dataContext.FontWeight = style.Font.FontWeight;
                dataContext.HorizontalAlignment = style.HorizontalAlignment;
                dataContext.TextDecorations = style.Font.TextDecorations;
                dataContext.VerticalAlignment = style.VerticalAlignment;
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.CurrentCellActivated -= new GridRoutedEventHandler(AssociatedObject_CurrentCellActivated);
        }
    }
}