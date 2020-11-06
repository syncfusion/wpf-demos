#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.datagriddemos.wpf
{
    public class DataBindingDemoBehavior : Behavior<DataBindingDemo>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
            base.OnAttached();
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.comboBinding.SelectionChanged += ComboBinding_SelectionChanged;
        }

        private void ComboBinding_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedItem = this.AssociatedObject.comboBinding.SelectedItem as ComboBoxItem;

            if (!(this.AssociatedObject.dataGridArea.Content is ListViewPage) && selectedItem.Content.ToString().Equals("Binding List"))
                this.AssociatedObject.dataGridArea.Content = new ListViewPage();

            if (!(this.AssociatedObject.dataGridArea.Content is ObservableCollectionPage) && selectedItem.Content.ToString().Equals("Observable Collection"))
                this.AssociatedObject.dataGridArea.Content = new ObservableCollectionPage();

            if (!(this.AssociatedObject.dataGridArea.Content is DynamicObjectsPage) && selectedItem.Content.ToString().Equals("Dynamic Objects"))
                this.AssociatedObject.dataGridArea.Content = new DynamicObjectsPage();

            if (!(this.AssociatedObject.dataGridArea.Content is DataTablePage) && selectedItem.Content.ToString().Equals("Data Table"))
                this.AssociatedObject.dataGridArea.Content = new DataTablePage();
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            this.AssociatedObject.comboBinding.SelectionChanged -= ComboBinding_SelectionChanged;
            base.OnDetaching();
        } 
    }
}
