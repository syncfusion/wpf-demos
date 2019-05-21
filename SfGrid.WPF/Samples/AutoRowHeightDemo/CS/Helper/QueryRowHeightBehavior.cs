#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interactivity;
using Syncfusion.UI.Xaml.Grid.Helpers;

namespace AutoRowHeightDemo
{
    public class QueryRowHeightBehaviour: Behavior<SfDataGrid>
    {
        GridRowSizingOptions gridRowResizingOptions = new GridRowSizingOptions();
        List<string> excludeColumns = new List<string>();
        double Height = double.NaN;

        protected override void OnAttached()
        {            
            this.AssociatedObject.ItemsSourceChanged += AssociatedObject_ItemsSourceChanged;
            this.AssociatedObject.QueryRowHeight += AssociatedObject_QueryRowHeight;   
        }

        void AssociatedObject_ItemsSourceChanged(object sender, GridItemsSourceChangedEventArgs e)
        {            
            foreach (var column in this.AssociatedObject.Columns)
                if (!column.MappingName.Equals("Address") && !column.MappingName.Equals("CompanyName"))
                    excludeColumns.Add(column.MappingName);

            gridRowResizingOptions.ExcludeColumns = excludeColumns;
        }

        void AssociatedObject_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
        {            
            if (this.AssociatedObject.IsTableSummaryIndex(e.RowIndex))
            {
                e.Height = 40;
                e.Handled = true;
            }
            else if (this.AssociatedObject.GridColumnSizer.GetAutoRowHeight(e.RowIndex, gridRowResizingOptions, out Height))
            {
                if (Height > this.AssociatedObject.RowHeight)
                {
                    e.Height = Height;
                    e.Handled = true;
                }
            }
        }

        protected override void OnDetaching()
        {             
            this.AssociatedObject.QueryRowHeight -= AssociatedObject_QueryRowHeight;
            this.AssociatedObject.ItemsSourceChanged -= AssociatedObject_ItemsSourceChanged;     
        }
    }
}
