#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
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
            (this.AssociatedObject.DataContext as ViewModel).PropertyChanged += GridView_PropertyChanged;
        }

        private void GridView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Expenses"))
                this.AssociatedObject.sfDataPager.MoveToFirstPage();
        }

        protected override void OnDetaching()
        {
            (this.AssociatedObject as GridView).Loaded -= GridView_Loaded;
            (this.AssociatedObject.DataContext as ViewModel).PropertyChanged -= GridView_PropertyChanged;
            base.OnDetaching();
        }
    }
}
