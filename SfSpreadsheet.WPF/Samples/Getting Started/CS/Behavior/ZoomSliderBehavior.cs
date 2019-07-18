#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Syncfusion.UI.Xaml.CellGrid.Helpers;
using Syncfusion.UI.Xaml.Spreadsheet;

namespace SpreadsheetDemo.Behavior
{
    public class ZoomSliderBehavior : Behavior<StackPanel>
    {
        private Slider zoomSlider;
        private Button zoomDecreaseButton;
        private Button zoomIncreaseButton;

        protected override void OnAttached()
        {
            zoomSlider = this.AssociatedObject.Children[1] as Slider;
            zoomDecreaseButton = this.AssociatedObject.Children[0] as Button;
            zoomIncreaseButton = this.AssociatedObject.Children[2] as Button;

            zoomSlider.ValueChanged += zoomSlider_ValueChanged;
            zoomDecreaseButton.Click += zoomDecreaseButton_Click;
            zoomIncreaseButton.Click += zoomIncreaseButton_Click;
        }

        void zoomIncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            var value = (int)((zoomSlider.Value + 10) / 10);
            zoomSlider.Value = value * 10;
        }

        void zoomDecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            var value = (int)((zoomSlider.Value - 10) / 10);
            zoomSlider.Value = value * 10;
        }

        void zoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var spreadsheet = this.AssociatedObject.DataContext as SfSpreadsheet;
            if (spreadsheet.ActiveSheet != null && e.NewValue != spreadsheet.ActiveSheet.Zoom)
                spreadsheet.SetZoomFactor(spreadsheet.ActiveSheet.Name, (int) e.NewValue);
        }

        protected override void OnDetaching()
        {
            zoomSlider.ValueChanged += zoomSlider_ValueChanged;
            zoomDecreaseButton.Click += zoomDecreaseButton_Click;
            zoomIncreaseButton.Click += zoomIncreaseButton_Click;
        }
    }
}
