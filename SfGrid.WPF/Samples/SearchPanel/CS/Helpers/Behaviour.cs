#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using System.Windows.Interactivity;

namespace SearchPanel
{
   public class Behaviour:Behavior<Window>
    {
       SfDataGrid dataGrid;
       SearchControl searchControl;      
       protected override void OnAttached()
       {
           var window = this.AssociatedObject;
           this.dataGrid = window.FindName("dataGrid") as SfDataGrid;
           this.dataGrid.KeyDown += OnDataGridKeyDown;
           this.searchControl = window.FindName("searchControl") as SearchControl;
       }

       /// <summary>
       /// Invokes thid Event to show the AdonerDecorator in the view.
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
       }
    }
}
