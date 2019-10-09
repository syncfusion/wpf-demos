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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
namespace UMLDiagramDesigner
{
    public class PathHelper : DependencyObject
    {
        public static object GetData(Path obj)
        {
            return (object)obj.GetValue(DataProperty);
        }

        public static void SetData(Path obj, object value)
        {
            obj.SetValue(DataProperty, value);
        }

        // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.RegisterAttached("Data", typeof(object), typeof(PathHelper), new PropertyMetadata(null, OnDataChanged));

        private static void OnDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Path path = d as Path;
            path.Loaded += (src, evt) =>
            {
                path.Data = PathStyle.Clone(e.NewValue.ToString());
            };
        }

        public static DoubleCollection GetStrokeDashArray(Path obj)
        {
            return (DoubleCollection)obj.GetValue(StrokeDashArrayProperty);
        }

        public static void SetStrokeDashArray(Path obj, DoubleCollection value)
        {
            obj.SetValue(StrokeDashArrayProperty, value);
        }

        // Using a DependencyProperty as the backing store for StrokeDashArray.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeDashArrayProperty =
            DependencyProperty.RegisterAttached("StrokeDashArray", typeof(DoubleCollection), typeof(PathHelper), new PropertyMetadata(null, OnStrokeDashArrayChanged));

        private static void OnStrokeDashArrayChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Path path = d as Path;
            DoubleCollection clone = new DoubleCollection();
            if (e.NewValue is DoubleCollection)
            {
                foreach (var item in e.NewValue as DoubleCollection)
                {
                    clone.Add(item);
                }
            }
            path.StrokeDashArray = clone;
        }



        //public static Geometry GetGeometry(DependencyObject obj)
        //{
        //    return (Geometry)obj.GetValue(GeometryProperty);
        //}

        //public static void SetGeometry(DependencyObject obj, Geometry value)
        //{
        //    obj.SetValue(GeometryProperty, value);
        //}

        //// Using a DependencyProperty as the backing store for Geometry.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty GeometryProperty =
        //    DependencyProperty.RegisterAttached("Geometry", typeof(Geometry), typeof(PathHelper), new PropertyMetadata(null, OnGeometryChanged));

        //private static void OnGeometryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //}
    }
}
