#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace syncfusion.dropdowndemos.wpf
{
    public class TextBoxFilterAction : TargetedTriggerAction<SfMultiColumnDropDownControl>
    {
        protected override void Invoke(object parameter)
        {
            var dataGrid = this.Target.GetDropDownGrid();
            if (dataGrid == null || dataGrid.View == null)
                return;

            var selectedItems = new ObservableCollection<object>();
            foreach (var selectedItem in dataGrid.SelectedItems.ToList())
                selectedItems.Add(selectedItem);

            if (dataGrid.View.Filter != null)
                dataGrid.View.RefreshFilter();

            dataGrid.ClearSelections(false);
            dataGrid.SelectedItems = selectedItems;
        }
    }

    public class MultiColumnDropDownFilterAction : TriggerAction<SfMultiColumnDropDownControl>
    {
        protected override void Invoke(object parameter)
        {
            if (this.AssociatedObject == null)
                return;

            var viewmodel = this.AssociatedObject.DataContext as MovieInfoViewModel;
            if (viewmodel == null)
                return;

            viewmodel.SearchText = string.Empty;
            var grid = this.AssociatedObject.GetDropDownGrid();
            if (grid != null)
            {
                
                grid.View.Filter = SearchTextFilter;
                grid.View.RefreshFilter();
            }
        }

        private bool SearchTextFilter(object item)
        {
            if (this.AssociatedObject == null)
                return true;

            var viewmodel = this.AssociatedObject.DataContext as MovieInfoViewModel;
            if (viewmodel == null)
                return true;

            var movie = item as GrossingMoviesList;
            return movie.Title.ToLower().Contains(viewmodel.SearchText.ToLower());
        }
    }
}
