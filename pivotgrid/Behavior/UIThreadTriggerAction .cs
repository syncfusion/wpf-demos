#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using System;
    using Syncfusion.Windows.Controls.PivotGrid;
    using System.Windows;
    using Microsoft.Xaml.Behaviors;

    class UIThreadTriggerAction : TargetedTriggerAction<PivotGridControl>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is RoutedEventArgs)
            {
                try
                {
                    MessageBox.Show("PivotGrid is loading at the background through a unique thread.", "UIThreading");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
