#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace AxisStringValueTypeDemo
{
    public class SampleBehavior:Behavior<MainWindow>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.IsAutoSetRangeState.Unchecked += new System.Windows.RoutedEventHandler(IsAutoSetRangeState_Unchecked);
            
            this.AssociatedObject.IsAutoSetRangeState.Checked += new System.Windows.RoutedEventHandler(IsAutoSetRangeState_Checked);
            this.AssociatedObject.Interval.TextChanged+=Interval_TextChanged;
        }

        private void Interval_TextChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBox Interval = sender as TextBox;
            if (Interval.Text != "0" && Interval.Text != "")
            {
                this.AssociatedObject.PrimaryAxis.Interval = double.Parse(Interval.Text);
            }
        }

        void IsIndexedState_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.Chart.Areas[0].PrimaryAxis.IsAutoSetRange = true;
        }

        void IsAutoSetRangeState_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.PrimaryAxis.Interval = double.NaN;
        }
        void IsAutoSetRangeState_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
          //  this.AssociatedObject.PrimaryAxisGroupBox.Visibility = System.Windows.Visibility.Visible;
          
        }
    }
}
