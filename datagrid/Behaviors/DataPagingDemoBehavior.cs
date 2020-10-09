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
using System.Windows.Controls;

namespace syncfusion.datagriddemos.wpf
{
    public class DataPagingDemoBehavior : Behavior<DataPagingDemo>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
            base.OnAttached();
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.OrientationComboBox.SelectionChanged += OrientationComboBox_SelectionChanged;
        }

        private void OrientationComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (this.AssociatedObject.sfDataPager != null)
            {
                if (comboBox.SelectedIndex == 0)
                {
                    this.AssociatedObject.sfDataPager.Height = 60;
                    this.AssociatedObject.sfDataPager.Margin = new System.Windows.Thickness();
                }
                else
                {
                    this.AssociatedObject.sfDataPager.Height = 580;
                    this.AssociatedObject.sfDataPager.Margin = new System.Windows.Thickness(30, -20, 0, 0);
                }
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            this.AssociatedObject.OrientationComboBox.SelectionChanged -= OrientationComboBox_SelectionChanged;
            base.OnDetaching();
        }
    }
}
