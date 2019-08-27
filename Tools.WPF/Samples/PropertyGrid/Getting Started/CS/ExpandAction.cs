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
using Syncfusion.Windows.PropertyGrid;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows;

namespace PropertyGridConfigurationDemo
{
    class ExpandAction : TargetedTriggerAction<PropertyGrid>
    {
#if Framework3_5
        public FrameworkElement TargetObject
        {
            get { return (FrameworkElement)GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }


        public static readonly DependencyProperty TargetObjectProperty =
            DependencyProperty.Register("TargetObject", typeof(FrameworkElement), typeof(ExpandAction), new UIPropertyMetadata(null));
#endif
        protected override void Invoke(object parameter)
        {
            if (((parameter as SelectionChangedEventArgs).AddedItems[0] as ComboBoxItem).Content.ToString() == "Flat")
            {
                ((PropertyGrid)TargetObject).PropertyExpandMode = PropertyExpandModes.FlatMode;
                ((PropertyGrid)TargetObject).RefreshPropertygrid();
            }
            else
            {
                ((PropertyGrid)TargetObject).PropertyExpandMode = PropertyExpandModes.NestedMode;
                ((PropertyGrid)TargetObject).RefreshPropertygrid();
            }                                 
        }

    }
}
