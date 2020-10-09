#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.floorplanner.wpf
{
    /// <summary>
    /// Specifies the shapes.
    /// </summary>
    public enum Shapes
    {
        DoubleBed,
        SingleBed,
        Door,
        CenterSofa,
        SideSofa,
        Table,
        DinningTable,
        Chair,
        None

    }

    public enum BasicShapes
    {
        RightTriangle,
        Circle,
       
        Rectangle,
        Sqaure,
        RSqaure,
        Star,
        FlowChart_Start,
        FlowChart_Decision,
        FlowChart_Predefined,
        FlowChart_Card,
        Hexagon,
        Octagon,
        Pentagon,
        Plus,
        Heptagon,
        InternalStorage,
        ManualInput,
        LoopLimit,
        CircleWithCross,
        Star6,
        Star7,
        None
    }

    internal static class ShapeHelper
    {
        public static Dictionary<BasicShapes, string> GeometryDictionary = new Dictionary<BasicShapes, string>();

        static ShapeHelper()
        {
            GeometryDictionary.Add(BasicShapes.RightTriangle, "M0,0 L0,1 1,1 1,0z");
            GeometryDictionary.Add(BasicShapes.Star, "M 392,248.504L 399.868,272.722L 425.333,272.722L 404.732,287.689L 412.602,311.908L 392,296.94L 371.398,311.908L 379.268,287.689L 358.667,272.722L 384.132,272.722L 392,248.504 Z ");
            //GeometryDictionary.Add(BasicShapes.Star, "M 9,2 11,7 17,7 12,10 14,15 9,12 4,15 6,10 1,7 7,7 Z");
            GeometryDictionary.Add(BasicShapes.FlowChart_Start, "M 10,20 A 20,20 0 1 1 50,20 A 20,20 0 1 1 10,20");
            GeometryDictionary.Add(BasicShapes.FlowChart_Decision, "M 0,20 L 30 0 L 60,20 L 30,40 Z");
            GeometryDictionary.Add(BasicShapes.FlowChart_Predefined, "M 50,0 V 40 M 10,0 V 40 M 0 0 H 60 V 40 H 0 Z");
            GeometryDictionary.Add(BasicShapes.FlowChart_Card, "M 0 10 L 10,0 H 60 V 40 H 0 Z");
            GeometryDictionary.Add(BasicShapes.Hexagon, "M165.5,-1.50000000000001L-2.5,213 167,444 444.5,442.5 621.5,214.5 438.5,-1.50000000000002z");
            GeometryDictionary.Add(BasicShapes.Octagon,"M160.329212944922,-3.01862318403769L-2.5,130.5 -5.00506481618589,311.336343115124 163.335290725089,448.012415349887 436.888368720338,448.012420654297 593,309 591.5,133.5 429.5,-1.5z");
            GeometryDictionary.Add(BasicShapes.Pentagon,"M284.5,0.5L-2.49999999999999,126 132.460005030756,444 450.460016884495,442.5 586.96,127.5z");
            GeometryDictionary.Add(BasicShapes.Plus, "M19.833,0L32.5,0 32.5,19.833999 52.334,19.833999 52.334,32.500999 32.5,32.500999 32.5,52.333 19.833,52.333 19.833,32.500999 0,32.500999 0,19.833999 19.833,19.833999z");
            GeometryDictionary.Add(BasicShapes.Heptagon, " M20,10 L55,40 95,40 130,10 120,-20 75,-40 30,-20 20,10z");
            
            GeometryDictionary.Add(BasicShapes.InternalStorage,"M 0,10 H 60 M 10,0 V 40 M 0,0 H 60 V 40 H 0 Z");
            GeometryDictionary.Add(BasicShapes.ManualInput, "M 0 10 L 60,0 V 40 H 0 Z");
            GeometryDictionary.Add(BasicShapes.LoopLimit, "M 0 10 L 10,0 H 50 L 60,10 V 40 H 0 Z");
            GeometryDictionary.Add(BasicShapes.CircleWithCross, "M147.5,71.5C147.5,110.712217237986,114.592929112563,142.5,74,142.5C33.4070708874367,142.5,0.5,110.712217237986,0.5,71.5C0.5,32.2877827620137,33.4070708874367,0.5,74,0.5C114.592929112563,0.5,147.5,32.2877827620137,147.5,71.5z M38,9.99999628458352L114.000012530205,10.9999963147899 37.0000007353631,133.000004396599 113.000010937603,133z");
            GeometryDictionary.Add(BasicShapes.Star6, "M158.5,95.1283269797681L26.5,105.628322653968 121,219.628166664837 29.5,339.62822625042 160,342.628225014478 236.915602847904,446.724181328487 316,341.128225632449 461.5,344.128224396506 361,213.628172103343 460,113.128319564111 317.5,92.1283282157111 242.5,-0.871633462889512z");
            GeometryDictionary.Add(BasicShapes.Star7, "M175.768495340047,99.6281981998809L45.268674011238,83.1282072536303 108.268592959668,191.128209802699 21.0397062662198,260.738443497483 121.768575281759,306.628115521466 156.268522038041,420.628022063302 241.768328666687,342.628098491491 333.26824572924,420.628022464666 370.768249222555,306.628115521466 466.768098970632,258.628154703277 369.268251186767,191.128209802699 423.268156480892,74.128212192039 298.768326937315,98.128199022949 242.998438310582,0.912252349553812z");
            GeometryDictionary.Add(BasicShapes.Circle, "M38.5,20C38.5,30.218 30.218,38.5 20,38.5 9.782,38.5 1.5,30.218 1.5,20 1.5,9.782 9.782,1.5 20,1.5 30.218,1.5 38.5,9.782 38.5,20z");
           // GeometryDictionary.Add(BasicShapes.RRectangle, "M 0 10 L 10,0 H 50 L 60,10 V 40 H 0 Z");
            GeometryDictionary.Add(BasicShapes.Rectangle, "M43.5,31.5L1.5,31.5 1.5,1.5 43.5,1.5z");
            GeometryDictionary.Add(BasicShapes.Sqaure, "M38.5,38.5L1.5,38.5 1.5,1.5 38.5,1.5z");
            GeometryDictionary.Add(BasicShapes.RSqaure, "M43.5,27.362C43.5,29.647,41.647,31.5,39.362,31.5L5.638,31.5C3.353,31.5,1.5,29.647,1.5,27.362L1.5,5.637C1.5,3.352,3.353,1.5,5.638,1.5L39.362,1.5C41.647,1.5,43.5,3.352,43.5,5.637z");
            //GeometryDictionary.Add(Shapes.DoubleBed, "M95,96 C95,98.209 93.209,100 91,100 L4,100 C1.791,100 0,98.209 0,96 L0,4 C0,1.791 1.791,0 4,0 L91,0 C93.209,0 95,1.791 95,4 z M45,26 L8.99999,26 L8.99999,8 L45,8 z M86,26 L50,26 L50,8 L86,8 z");
            //GeometryDictionary.Add(Shapes.SingleBed, "F1M52,100L0,100 0,0 52,0z");
            //GeometryDictionary.Add(Shapes.Door, "M1.44,34.88L33.736,1.388");
            //GeometryDictionary.Add(Shapes.CenterSofa, "M5.5,0 C2.463,0 0,2.462 0,5.5 C0,8.538 2.463,11 5.5,11 L78.5,11 C81.538,11 84,8.538 84,5.5 C84,2.462 81.538,0 78.5,0 z M3.391,11 C1.517,11 0,12.517 0,14.391 L0,32.609 C0,34.483 1.517,36 3.391,36 L80.609,36 C82.482,36 84,34.483 84,32.609 L84,14.391 C84,12.517 82.482,11 80.609,11 z");
            //GeometryDictionary.Add(Shapes.SideSofa, "M0,5.5 L0,32.5 C0,35.538 2.463,38 5.5,38 C8.537,38 11,35.538 11,32.5 L11,5.5 C11,2.463 8.537,0 5.5,0 C2.463,0 0,2.463 0,5.5 M14.392,0 C12.519,0 11,1.518 11,3.39 L11,34.61 C11,36.482 12.519,38 14.392,38 L32.608,38 C34.482,38 36,36.482 36,34.61 L36,3.39 C36,1.518 34.482,0 32.608,0 z");
            //GeometryDictionary.Add(Shapes.Table, "M0,22.001L41,22.001 41,0 0,0z");
            //GeometryDictionary.Add(Shapes.DinningTable, "F1M90,22.5C90,34.926,79.927,45,67.5,45L22.5,45C10.073,45 0,34.926 0,22.5 0,10.074 10.073,0 22.5,0L67.5,0C79.927,0,90,10.074,90,22.5");
            //GeometryDictionary.Add(Shapes.Chair, "M5.23805,1.09802 C7.52505,1.09802 9.38005,2.95202 9.38005,5.23902 C9.38005,7.52602 7.52505,9.38002 5.23805,9.38002 C2.95105,9.38002 1.09705,7.52602 1.09705,5.23902 C1.09705,2.95202 2.95105,1.09802 5.23805,1.09802 M5.238,10.478 C2.345,10.478 0,8.132 0,5.239 C0,2.345 2.345,0 5.238,0");

            //"M347,427 L428,427 L428,310 L626,310 L626,5 L5,5 L5,310 L152,310 L152,427 L246,427 M341.311,218.364 C339.024,218.364 337.169,220.218 337.169,222.505 C337.169,224.792 339.024,226.646 341.311,226.646 C343.598,226.646 345.452,224.792 345.452,222.505 C345.452,220.218 343.598,218.364 341.311,218.364 M341.311,227.744 C344.204,227.744 346.549,225.398 346.549,222.505 C346.549,219.611 344.204,217.266 341.311,217.266");
        }

        public static Geometry ToGeometry(this BasicShapes source)
        {
            if (source == BasicShapes.None)
            {
                return null;
            }
            return Clone(GeometryDictionary[source]);
        }

        private static PathGeometry Clone(string data)
        {
           // string p = "<Path xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Data=\"" + data + "\"/>";
           //Path o = XamlReader.Load(p) as Path;
           // PathGeometry geo = Clone(o.Data as PathGeometry);
            return new PathGeometry();
        }

        private static PathGeometry Clone(PathGeometry pathGeometry)
        {
            PathFigureCollection collClone = new PathFigureCollection();
            foreach (PathFigure item in pathGeometry.Figures)
            {
                PathFigure clone = new PathFigure()
                {
                    IsClosed = item.IsClosed,
                    IsFilled = item.IsFilled,
                    Segments = Clone(item.Segments),
                    StartPoint = item.StartPoint
                };
                collClone.Add(clone);
            }
            return new PathGeometry()
            {
                Figures = collClone,
                FillRule = pathGeometry.FillRule,
                Transform = pathGeometry.Transform
            };
        }

        private static PathSegmentCollection Clone(PathSegmentCollection pathSegColl)
        {
            PathSegmentCollection collClone = new PathSegmentCollection();

            foreach (PathSegment item in pathSegColl)
            {
                PathSegment clone = null;
                if (item is LineSegment)
                {
                    LineSegment seg = item as LineSegment;
                    clone = new LineSegment() { Point = seg.Point };
                }
                else if (item is PolyLineSegment)
                {
                    PolyLineSegment seg = item as PolyLineSegment;
                    clone = new PolyLineSegment() { Points = getPoints(seg.Points) };
                }
                else if (item is BezierSegment)
                {
                    BezierSegment seg = item as BezierSegment;
                    clone = new BezierSegment()
                    {
                        Point1 = seg.Point1,
                        Point2 = seg.Point2,
                        Point3 = seg.Point3
                    };
                }
                else if (item is PolyBezierSegment)
                {
                    PolyBezierSegment seg = item as PolyBezierSegment;
                    clone = new PolyBezierSegment() { Points = getPoints(seg.Points) };
                }
                else if (item is PolyQuadraticBezierSegment)
                {
                    PolyQuadraticBezierSegment seg = item as PolyQuadraticBezierSegment;
                    clone = new PolyQuadraticBezierSegment() { Points = getPoints(seg.Points) };
                }
                else if (item is QuadraticBezierSegment)
                {
                    QuadraticBezierSegment seg = item as QuadraticBezierSegment;
                    clone = new QuadraticBezierSegment() { Point1 = seg.Point1, Point2 = seg.Point2 };
                }
                else if (item is System.Windows.Media.ArcSegment)
                {
                    System.Windows.Media.ArcSegment seg = item as System.Windows.Media.ArcSegment;
                    clone = new System.Windows.Media.ArcSegment()
                    {
                        IsLargeArc = seg.IsLargeArc,
                        Point = seg.Point,
                        RotationAngle = seg.RotationAngle,
                        Size = seg.Size,
                        SweepDirection = seg.SweepDirection
                    };
                }

                collClone.Add(clone);
            }
            return collClone;
        }

        private static PointCollection getPoints(PointCollection pointCollection)
        {
            PointCollection coll = new PointCollection();
            foreach (var item in pointCollection)
            {
                coll.Add(item);
            }
            return coll;
        }

    }

    public class EnableCheckedState : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            if (!val)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class EnabelAppbar : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int val = (int)value;
            if (val == 0)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TypetoVisibilityConverter : IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (value is FloorPlanNode)
                {
                    if ((value as FloorPlanNode).IsTextNode)
                    {
                        return Visibility.Collapsed;
                    }
                    else
                    {
                        return Visibility.Visible;
                    }
                }
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TypetoVisibilityConverter1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (value is FloorPlanNode)
                {
                    if ((value as FloorPlanNode).IsShapeNode)
                    {
                        return Visibility.Visible;
                    }
                    else
                    {
                        return Visibility.Collapsed;
                    }
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (value is Connector)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class Extension
    {
        public static T GetParent<T>(this DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = null;
            try
            {
                if (child.Dispatcher != null)
                {
                    parent = (child as FrameworkElement).Parent ?? VisualTreeHelper.GetParent(child);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            if (parent is T)
            {
                return parent as T;
            }
            else if (parent == null)
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
    }
}
