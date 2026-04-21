#region Copyright Syncfusion Inc. 2001 - 2026
// Copyright Syncfusion Inc. 2001 - 2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace syncfusion.datagriddemos.wpf
{
    public class ExcelStyleSelectionBehavior : Behavior<ExcelStyleSelectionDemo>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += ExcelStyleSelectionDemo_Loaded;
        }

        void ExcelStyleSelectionDemo_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.AssociatedObject.syncgrid != null)
                this.AssociatedObject.syncgrid.SelectedIndex = -1;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= ExcelStyleSelectionDemo_Loaded;
        }
    }
}
