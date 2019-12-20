#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FloorPlanner
{
    public class FloorPlanSymbolItem : ISymbol
    {
        public object Symbol
        {
            get;
            set;
        }

        public DataTemplate SymbolTemplate
        {
            get;
            set;
        }

        public string GroupName { get; set; }


        public ISymbol Clone()
        {
            return new FloorPlanSymbolItem()
            {
                Symbol = this.Symbol,
                SymbolTemplate = this.SymbolTemplate
            };
        }


        public object Key
        {
            get;
            set;
        }
    }

    public class SymbolCollection : ObservableCollection<ISymbol>
    {

    }

    public class StencilDataTemplator : DataTemplateSelector
    {
        public override DataTemplate
           SelectTemplate(object item, DependencyObject container)
        {
            if (item != null && item is FloorPlannerViewModel)
            {
                if ((item as FloorPlannerViewModel).ValueType == "Prop")
                {
                    return App.Current.Resources["floorplanstencil"] as DataTemplate;
                }
                else if ((item as FloorPlannerViewModel).ValueType == "Shape")
                {
                    return App.Current.Resources["shapestencil"] as DataTemplate;
                }
                else if ((item as FloorPlannerViewModel).ValueType == "Text")
                {
                    return App.Current.Resources["FloorPlanText"] as DataTemplate;
                }               
                return null;
            }
           
            return null;
        }

       
    }

    public static class FrameworkElementExtensions
    {
        public static FrameworkElement FindDescendantByName(this FrameworkElement element, string name)
        {
            if (element == null || string.IsNullOrWhiteSpace(name)) { return null; }

            if (name.Equals(element.Name, StringComparison.OrdinalIgnoreCase))
            {
                return element;
            }
            var childCount = VisualTreeHelper.GetChildrenCount(element);
            for (int i = 0; i < childCount; i++)
            {
                var result = (VisualTreeHelper.GetChild(element, i) as FrameworkElement).FindDescendantByName(name);
                if (result != null) { return result; }
            }
            return null;
        }
    }
}
