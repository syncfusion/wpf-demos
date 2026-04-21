#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;

namespace syncfusion.datagriddemos.wpf
{
   public class SearchDemoBehavior : Behavior<SearchPanelDemo>
    {
       SfDataGrid dataGrid;
       SearchControl searchControl;      
       protected override void OnAttached()
       {
           var window = this.AssociatedObject;
           this.dataGrid = window.FindName("dataGrid") as SfDataGrid;
           this.dataGrid.KeyDown += OnDataGridKeyDown;
           this.dataGrid.DetailsViewExpanded += OnDetailsViewExpanded;
           this.searchControl = window.FindName("searchControl") as SearchControl;
       }

       /// <summary>
       /// Handles the DetailsView expansion event and updates the search navigation buttons (FindNext and FindPrevious).
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>     
       private void OnDetailsViewExpanded(object sender, GridDetailsViewExpandedEventArgs e)
       {
            var item = this.searchControl?.ComboBox?.SelectedItem as string;
            if (item == null)
                return;
            var grid = this.searchControl?.GetDataGrid(item);
            var dataGrid = sender as SfDataGrid;
            if(grid == null || dataGrid == null)
                return;
            dataGrid?.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                this.searchControl?.UpdateSearchNavigationButtons(grid);
            }));            
       }

       /// <summary>
       /// Handles key down events on the SfDataGrid to update the visibility of the SearchControl.
       /// Displays the search control when Ctrl+F is pressed and hides it when Escape is pressed.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
       private void OnDataGridKeyDown(object sender, KeyEventArgs e)
       {
           if ((e.Key == Key.F) && (e.KeyboardDevice.Modifiers & ModifierKeys.Control) != ModifierKeys.None)
               searchControl.UpdateSearchControlVisiblity(true);
           else if (e.Key == Key.Escape)
               searchControl.UpdateSearchControlVisiblity(false);
       }

       protected override void OnDetaching()
       {
           this.dataGrid.KeyDown -= OnDataGridKeyDown;
           this.dataGrid.DetailsViewExpanded -= OnDetailsViewExpanded;
       }
    }
}
