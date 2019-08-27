#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace UMLDiagramDesigner
{
    public class PathStyle : INotifyPropertyChanged
    {
        public PathStyle()
        {
            this.PropertyChanged += PathStyle_PropertyChanged;
        }

        void PathStyle_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Style")
            {
                PrepareStyle();
            }
        }

        #region HelperMethods

        private void PrepareStyle()
        {
            Style style = new Style(typeof(Path));
            Setter setter = null;
            if (Data != null)
            {
                //setter = new Setter(Path.DataProperty, this.Data);
                //style.Setters.Add(setter);
                setter = new Setter(Path.DataProperty, Data);
                style.Setters.Add(setter);
            }
            if (Stroke != null)
            {
                System.Windows.Media.Color color = (Color)System.Windows.Media.ColorConverter.ConvertFromString(this.Stroke);
                SolidColorBrush bru = new SolidColorBrush(color);
                setter = new Setter(Path.StrokeProperty, bru);
                style.Setters.Add(setter);
            }
            if (Fill != null)
            {
                System.Windows.Media.Color color = (Color)System.Windows.Media.ColorConverter.ConvertFromString(this.Fill);
                SolidColorBrush bru = new SolidColorBrush(color);
                setter = new Setter(Path.FillProperty, bru);
                style.Setters.Add(setter);
            }
            setter = new Setter(Path.StrokeThicknessProperty, this.StrokeThickness);
            style.Setters.Add(setter);
            if (StrokeDashArray != null)
            {
                setter = new Setter(Path.StrokeDashArrayProperty, this.StrokeDashArray);
                style.Setters.Add(setter);
            }
            if (!double.IsNaN(this.Width))
            {
                setter = new Setter(Path.WidthProperty, this.Width);
                style.Setters.Add(setter);
            }
            if (!double.IsNaN(this.Height))
            {
                setter = new Setter(Path.HeightProperty, this.Height);
                style.Setters.Add(setter);
            }
            setter = new Setter(Path.StretchProperty, this.Stretch);
            style.Setters.Add(setter);
            this.Style = style;
        }

        public static PathGeometry Clone(string data)
        {
            string p = "<Path xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Data=\"" + data + "\"/>";
            //Path o = XamlReader.Load(p) as Path;
            //PathGeometry geo = Clone(o.Data as PathGeometry);
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
                else if (item is ArcSegment)
                {
                    ArcSegment seg = item as ArcSegment;
                    clone = new ArcSegment()
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

        #endregion

        #region Properties

        private string m_Data;

        public string Data
        {
            get { return m_Data; }
            set
            {
                if (m_Data != value)
                {
                    m_Data = value;
                    OnPropertyChanged("Data");
                }
            }
        }

        private string m_Stroke;

        public string Stroke
        {
            get { return m_Stroke; }
            set
            {
                if (m_Stroke != value)
                {
                    m_Stroke = value;
                    OnPropertyChanged("Stroke");
                }
            }
        }

        private string m_Fill;

        public string Fill
        {
            get { return m_Fill; }
            set
            {
                if (m_Fill != value)
                {
                    m_Fill = value;
                    OnPropertyChanged("Fill");
                }
            }
        }

        private double m_StrokeThickness;

        public double StrokeThickness
        {
            get { return m_StrokeThickness; }
            set
            {
                if (m_StrokeThickness != value)
                {
                    m_StrokeThickness = value;
                    OnPropertyChanged("StrokeThickness");
                }
            }
        }

        private DoubleCollection m_StrokeDashArray;

        public DoubleCollection StrokeDashArray
        {
            get { return m_StrokeDashArray; }
            set
            {
                if (m_StrokeDashArray != value)
                {
                    m_StrokeDashArray = value;
                    OnPropertyChanged("StrokeDashArray");
                }
            }
        }

        private Style m_Style;

        public Style Style
        {
            get { return m_Style; }
            set
            {
                if (m_Style != value)
                {
                    m_Style = value;
                    OnPropertyChanged("Style");
                }
            }
        }

        private double m_Width = double.NaN;

        public double Width
        {
            get { return m_Width; }
            set
            {
                if (m_Width != value)
                {
                    m_Width = value;
                    OnPropertyChanged("Width");
                }
            }
        }

        private double m_Height = double.NaN;

        public double Height
        {
            get { return m_Height; }
            set
            {
                if (m_Height != value)
                {
                    m_Height = value;
                    OnPropertyChanged("Height");
                }
            }
        }

        private Stretch m_Stretch;

        public Stretch Stretch
        {
            get { return m_Stretch; }
            set
            {
                if (m_Stretch != value)
                {
                    m_Stretch = value;
                    OnPropertyChanged("Stretch");
                }
            }
        }

        #endregion

        #region PropertyChanged

        protected virtual void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
