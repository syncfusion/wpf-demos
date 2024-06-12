#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors; 
using System.Windows.Controls;

namespace syncfusion.stockanalysisdemo.wpf 
{
    public class ListViewRealTimeUpdateBehavior : Behavior<ListView>
    { 
        protected override void OnAttached()
        {
            (this.AssociatedObject as ListView).Loaded += OnLoaded;
            (this.AssociatedObject as ListView).Unloaded += OnUnloaded;
            base.OnAttached();
        }

        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.AssociatedObject.DataContext is StockViewModel)
                (this.AssociatedObject.DataContext as StockViewModel).StartTimer();
        }

        private void OnUnloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.AssociatedObject.DataContext is StockViewModel)
                (this.AssociatedObject.DataContext as StockViewModel).StopTimer(); 
        }
         
        protected override void OnDetaching()
        {
            (this.AssociatedObject as ListView).Loaded -= OnLoaded;
            (this.AssociatedObject as ListView).Unloaded -= OnUnloaded; 
            base.OnDetaching();
        }
    }
}
