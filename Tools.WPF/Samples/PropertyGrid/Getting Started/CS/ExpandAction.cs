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
