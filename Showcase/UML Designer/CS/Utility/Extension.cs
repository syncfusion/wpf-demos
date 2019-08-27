#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace UMLDiagramDesigner
{
    public static class Extension
    {
        public static T GetParent<T>(this DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);
            if (parent is T)
            {
                return parent as T;
            }
            else if(parent == null)
            {
                return null;
            }
            else
            {
                return parent.GetParent<T>();
            }
        }

        public static T FindChild<T>(this DependencyObject parent) where T : DependencyObject
        {
            if (parent == null)
            {
                return null;
            }

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (!(child is T))
                {
                    foundChild = FindChild<T>(child);

                    if (foundChild != null)
                        break;
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }

        public static T FindChild<T>(this DependencyObject parent, string Name) where T : DependencyObject
        {
            if (parent == null)
            {
                return null;
            }

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is T && child is FrameworkElement && (child as FrameworkElement).Name == Name)
                {
                    foundChild = (T)child;
                    break;
                }
                else
                {
                    foundChild = FindChild<T>(child, Name);

                    if (foundChild != null)
                        break;
                }
            }
            return foundChild;
        }

        public static void CenterNode(this Node node)
        {
            //node.Loaded += node_Loaded;
        }

        private static void node_Loaded(object sender, RoutedEventArgs e)
        {
            Node node = sender as Node;
            node.Loaded -= node_Loaded;
            node.OffsetX = node.OffsetX - node.ActualWidth / 2;
            node.OffsetY = node.OffsetY - node.ActualHeight / 2;
        }
        
        public static void BringToFront(this Node top)
        {
            top.Loaded += (s, e) =>
                {
                    Canvas.SetZIndex((s as Node), 1000);
                };
        }

    }

    public class ColorList : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<String> colors = new List<String>()
            {
                "#FF45B5B2",
                "#FF25a0da",
                "#FFFF7300",
                "#FFED0006",
                "#FF00B25A",
                "#FFFFC425",
                "#FFE02B5F",
                "#FF6B9531",
                "#FF1D6080",
                "#FF9F8E7C",
                "#FFDD789B",
                "#FF808080",
                "#FF5D3AB8",
                "#FFF2875A",
                "#FF6E8FD4"
            };
            foreach (var item in colors)
            {
                yield return item;
            }
        }
    }

    public class CustomGrid : Grid
    {
        public int ColumnCount
        {
            get { return (int)GetValue(ColumnCountProperty); }
            set { SetValue(ColumnCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RowCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnCountProperty =
            DependencyProperty.Register("ColumnCount", typeof(int), typeof(CustomGrid), new PropertyMetadata(0));

        protected override Size MeasureOverride(Size availableSize)
        {
            int index = 0;
            int row = 0;
            int column = 0;
            this.RowDefinitions.Clear();
            this.ColumnDefinitions.Clear();
            while (Children.Count > index)
            {
                this.RowDefinitions.Add(new RowDefinition());
                for (column = 0; column < ColumnCount; column++)
                {
                    if (Children.Count > index)
                    {
                        SetRow(Children[index] as FrameworkElement, row);
                        SetColumn(Children[index] as FrameworkElement, column);
                        if (row == 0)
                        {
                            this.ColumnDefinitions.Add(new ColumnDefinition());
                        }
                    }
                    
                    index++;
                }
                row++;
            }
            return base.MeasureOverride(availableSize);
        }

    }

    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter == null)
            {
                return value;
            }

            return String.Format((String)parameter, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

}
