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

namespace syncfusion.datagriddemos.wpf
{
    public class CheckBoxSelectorColumnBehavior : Behavior<SfDataGrid>
    {
        /// <summary>
        /// Attaching event for SfDataGrid.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
            
        }

        /// <summary>
        /// Methdo to handle loaded event of SfDataGrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var items = this.AssociatedObject.ItemsSource as List<ProductInfo>;
            this.AssociatedObject.SelectedItems.Add(items[4]);
            this.AssociatedObject.SelectedItems.Add(items[6]);
            this.AssociatedObject.SelectedItems.Add(items[10]);
            this.AssociatedObject.SelectedItems.Add(items[15]);
            this.AssociatedObject.SelectedItems.Add(items[16]);
        }

        /// <summary>
        /// Detaching event for SfDataGrid.
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            base.OnDetaching();
        }
    }
}
