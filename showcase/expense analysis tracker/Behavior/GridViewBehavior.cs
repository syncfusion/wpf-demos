#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.expenseanalysis.wpf
{
    public class GridViewBehavior : Behavior<GridView>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += GridView_Loaded;            
            base.OnAttached();
        }
         
        private void GridView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.comboBoxAdv.SelectionChanged += ComboBoxAdv_SelectionChanged;
            (this.AssociatedObject.DataContext as ViewModel).PropertyChanged += GridView_PropertyChanged;            
        }

        private void ComboBoxAdv_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.AssociatedObject.comboBoxAdv.SelectedValue == null)
                return;

            var selectedItem = this.AssociatedObject.comboBoxAdv.SelectedValue as ComboBoxItemAdv;
            (this.AssociatedObject.DataContext as ViewModel).ComboBoxExportSelectedItem = selectedItem.Content.ToString();
        }

        private void GridView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (this.AssociatedObject.sfDataPager == null)
                return;

            if (e.PropertyName.Equals("Expenses"))
                this.AssociatedObject.sfDataPager.MoveToFirstPage();
        }

        protected override void OnDetaching()
        {
            (this.AssociatedObject as GridView).Loaded -= GridView_Loaded;
            (this.AssociatedObject.DataContext as ViewModel).PropertyChanged -= GridView_PropertyChanged;
            this.AssociatedObject.comboBoxAdv.SelectionChanged -= ComboBoxAdv_SelectionChanged;
            base.OnDetaching();
        }
    }
}
