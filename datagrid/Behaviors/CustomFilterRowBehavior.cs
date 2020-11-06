#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Class for representing the behavior for clearing the filter and remove the default renderer and
    /// assign the custom renderer
    /// </summary>
    public class CustomFilterRowBehavior : Behavior<SfDataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            //Assign the new NumericFilterComboBoxRenderer custom renderer 
            this.AssociatedObject.FilterRowCellRenderers.Add("NumericComboBoxExt", new GridNumericFilterComboBoxRendererExt());
            //Assign the new DateTimeFilterComboBoxRenderer custom renderer
            this.AssociatedObject.FilterRowCellRenderers.Add("DateTimeComboBoxExt", new GridDateTimeComboBoxRendererExt());
            //Assign the new TextFilterComboBoxRenderer custom renderer 
            this.AssociatedObject.FilterRowCellRenderers.Add("TextComboBoxExt", new GridTextFilterComboBoxRendererExt());
            this.AssociatedObject.PreviewMouseDown += OnSfDataGridPreviewMouseDown;
        }

        /// <summary>
        /// Process of clearing the filter when click the filter icon in the RowHeader of FilterRow
        /// </summary>
        /// <param name="sender">SfDataGrid</param>
        /// <param name="e"></param>
        private void OnSfDataGridPreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Get the point of SfDataGrid
            var point = e.GetPosition(this.AssociatedObject);
            //Get the VisualCointainer
            var visualContainer = this.AssociatedObject.GetVisualContainer();
            //Get the row and column index based on the point
            var rowColumnIndex = visualContainer.PointToCellRowColumnIndex(point);
            //Clear the filter based on FilerRow and RowHeader
            if (this.AssociatedObject.IsFilterRowIndex(rowColumnIndex.RowIndex) && this.AssociatedObject.ShowRowHeader && rowColumnIndex.ColumnIndex == 0)
                this.AssociatedObject.ClearFilters();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.PreviewMouseDown -= OnSfDataGridPreviewMouseDown;
        }
    }
}
