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
using System.Windows.Data;
using System.Windows;
using Syncfusion.Windows.Chart;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace CustomChartTypeDemo_2008
{
    public class HybridChartSegment : ChartAreaSegment
    {
        ChartPoint m_HybirdLineValue;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartSplineAreaSegment"/> class.
        /// </summary>
        /// <param name="splinePoints">The spline points.</param>
        /// <param name="correspondingPoints">The corresponding points.</param>
        /// <param name="parentSeries">The parent series.</param>
        public HybridChartSegment(IChartDataPoint[] splinePoints, ChartIndexedDataPoint[] correspondingPoints, ChartSeries parentSeries, double? HybirdLineValue)
            : base(splinePoints, correspondingPoints, parentSeries)
        {
            Binding binding1 = new Binding();
            binding1.Path = new PropertyPath(HybridChartType.HighValueInteriorProperty);
            binding1.Source = this.Series;
            BindingOperations.SetBinding(this, HybridChartSegment.HighValueColorProperty, binding1);

            Binding binding2 = new Binding();
            binding2.Path = new PropertyPath(HybridChartType.LowValueInteriorProperty);
            binding2.Source = this.Series;
            BindingOperations.SetBinding(this, HybridChartSegment.LowValueColorProperty, binding2);

            Binding binding3 = new Binding();
            binding3.Path = new PropertyPath(HybridChartType.LineStrokeProperty);
            binding3.Source = this.Series;
            BindingOperations.SetBinding(this, HybridChartSegment.LineColorProperty, binding3);

            double val = HybirdLineValue == null ? parentSeries.YAxis.VisibleRange.Median : (double)HybirdLineValue;
            m_HybirdLineValue = new ChartPoint(0d, val);

        }
        #endregion

        #region DependencyProperty


        public static readonly DependencyProperty HybirdMarginProperty =
        DependencyProperty.Register("HybirdMargin", typeof(Thickness), typeof(HybridChartSegment), new PropertyMetadata(new Thickness(0)));
        /// <summary>
        /// Gets or sets the HybirdMargin for segment. This is a dependency property.
        /// </summary>
        /// <value>The Thicknees value .</value>
        public Thickness HybirdMargin
        {
            get
            {
                return (Thickness)GetValue(HybirdMarginProperty);
            }

            set
            {
                SetValue(HybirdMarginProperty, value);
            }
        }

        public static readonly DependencyProperty LineColorProperty =
          DependencyProperty.Register("LineColor", typeof(Brush), typeof(HybridChartSegment), new PropertyMetadata(Brushes.Black));
        /// <summary>
        /// Gets or sets the HybirdMargin for segment. This is a dependency property.
        /// </summary>
        /// <value>The Thicknees value .</value>
        public Brush LineColor
        {
            get
            {
                return (Brush)GetValue(LineColorProperty);
            }

            set
            {
                SetValue(LineColorProperty, value);
            }
        }
        public static readonly DependencyProperty HighValueColorProperty =
        DependencyProperty.Register("HighValueColor", typeof(Brush), typeof(HybridChartSegment), new PropertyMetadata(Brushes.BlanchedAlmond));
        /// <summary>
        /// Gets or sets the HighValueColor for segment. This is a dependency property.
        /// </summary>
        /// <value>The brush color.</value>
        public Brush HighValueColor
        {
            get
            {
                return (Brush)GetValue(HighValueColorProperty);
            }

            set
            {
                SetValue(HighValueColorProperty, value);
            }
        }

        public static readonly DependencyProperty LowValueColorProperty =
       DependencyProperty.Register("LowValueColor", typeof(Brush), typeof(HybridChartSegment), new PropertyMetadata(Brushes.BurlyWood));
        /// <summary>
        /// Gets or sets the LowValueColor for segment. This is a dependency property.
        /// </summary>
        /// <value>The brush color.</value>
        public Brush LowValueColor
        {
            get
            {
                return (Brush)GetValue(LowValueColorProperty);
            }

            set
            {
                SetValue(LowValueColorProperty, value);
            }
        }



        #endregion

        #region Implmentation

        /// <summary>
        /// Updates the real coordinates of segment.
        /// </summary>
        /// <param name="transformer">Instance of class that implements <see cref="IChartTransformer"/> interface.</param>
        public override void Update(IChartTransformer transformer)
        {
            if (this.Interior.CanFreeze)
            {
                this.Interior.Freeze();
            }
            if (this.Stroke.CanFreeze)
            {
                this.Stroke.Freeze();
            }


            // Generate the Spline Curve Geomentry
            PathFigure figure = new PathFigure();
            figure.StartPoint = transformer.TransformToVisible(AreaPoints[0].X, 0);
            figure.Segments.Add(new LineSegment(transformer.TransformToVisible(AreaPoints[0].X, AreaPoints[0].Y), true));
            int i;

            for (i = 1; i < CorrespondingPoints.Length; i++)
            {
                Point point1 = transformer.TransformToVisible(i, CorrespondingPoints[i].DataPoint.Y);
                Point point2 = transformer.TransformToVisible(i, CorrespondingPoints[i].DataPoint.Y);
                Point point3 = transformer.TransformToVisible(i, CorrespondingPoints[i].DataPoint.Y);

                figure.Segments.Add(new BezierSegment(point1, point2, point3, true));
            }
            Point point11 = transformer.TransformToVisible(CorrespondingPoints[CorrespondingPoints.Length - 1].DataPoint.X, CorrespondingPoints[CorrespondingPoints.Length - 1].DataPoint.Y);
            Point point21 = transformer.TransformToVisible(CorrespondingPoints[CorrespondingPoints.Length - 1].DataPoint.X, CorrespondingPoints[CorrespondingPoints.Length - 1].DataPoint.Y);
            Point point31 = transformer.TransformToVisible(CorrespondingPoints[CorrespondingPoints.Length - 1].DataPoint.X, m_HybirdLineValue.Y);
            figure.Segments.Add(new BezierSegment(point11, point21, point31, true));

            figure.Segments.Add(new LineSegment(transformer.TransformToVisible(0, m_HybirdLineValue.Y), false));
            figure.IsClosed = true;

            PathGeometry pathgeomentry = new PathGeometry();
            pathgeomentry.Figures.Add(figure);

            PathFigureCollection PathFigurecoll = new PathFigureCollection();
            PathFigurecoll.Add(figure);

            //Initialize the Spline curve Geometry data
            this.Geometry = pathgeomentry;

            // Calculates the value for HybridLine
            Point point = transformer.TransformToVisible(0d, m_HybirdLineValue.Y);
            this.HybirdMargin = new Thickness(0, point.Y, 0, 0);
        }
        #endregion
    }

    public class HybridChartType : ChartSplineType
    {
        #region Attached properties

        /// <summary>
        /// Gets the value of the HighValueInterior dependency property.
        /// </summary>
        /// <param name="obj">The DependencyObjectobj.</param>
        /// <returns>The HighValueInterior brush</returns>
        public static Brush GetHighValueInterior(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HighValueInteriorProperty);
        }

        /// <summary>
        /// Sets the value of the HighValueInterior dependency property.
        /// </summary>
        /// <param name="obj">The DependencyObject obj.</param>
        /// <param name="value">The value.</param>
        public static void SetHighValueInterior(DependencyObject obj, Brush value)
        {
            obj.SetValue(HighValueInteriorProperty, value);
        }

        /// <summary>
        /// Indicates the HighValueInterior Dependency Property
        /// </summary>
        public static readonly DependencyProperty HighValueInteriorProperty =
                DependencyProperty.RegisterAttached("HighValueInterior", typeof(Brush), typeof(HybridChartType), new FrameworkPropertyMetadata(Brushes.BurlyWood));

        /// <summary>
        /// Gets the value of the HighValueInterior dependency property.
        /// </summary>
        /// <param name="obj">The DependencyObjectobj.</param>
        /// <returns>The HighValueInterior brush</returns>
        public static Brush GetLineStroke(DependencyObject obj)
        {
            return (Brush)obj.GetValue(LineStrokeProperty);
        }

        /// <summary>
        /// Sets the value of the HighValueInterior dependency property.
        /// </summary>
        /// <param name="obj">The DependencyObject obj.</param>
        /// <param name="value">The value.</param>
        public static void SetLineStroke(DependencyObject obj, Brush value)
        {
            obj.SetValue(LineStrokeProperty, value);
        }

        /// <summary>
        /// Indicates the HighValueInterior Dependency Property
        /// </summary>
        public static readonly DependencyProperty LineStrokeProperty =
                DependencyProperty.RegisterAttached("LineStroke", typeof(Brush), typeof(HybridChartType), new FrameworkPropertyMetadata(Brushes.BurlyWood));

        /// <summary>
        /// Gets the value of the LowValueInterior dependency property.
        /// </summary>
        /// <param name="obj">The DependencyObject obj.</param>
        /// <returns>The LowValueInterior Brush</returns>
        public static Brush GetLowValueInterior(DependencyObject obj)
        {
            return (Brush)obj.GetValue(LowValueInteriorProperty);
        }

        /// <summary>
        /// Sets the value of the LowValueInterior dependency property.
        /// </summary>
        /// <param name="obj">The DependencyObject obj.</param>
        /// <param name="value">The value.</param>
        public static void SetLowValueInterior(DependencyObject obj, Brush value)
        {
            obj.SetValue(LowValueInteriorProperty, value);
        }

        /// <summary>
        /// Indicates the LowValueInterior Dependency Property
        /// </summary>
        public static readonly DependencyProperty LowValueInteriorProperty =
                DependencyProperty.RegisterAttached("LowValueInterior", typeof(Brush), typeof(HybridChartType), new FrameworkPropertyMetadata(Brushes.BlanchedAlmond));

        /// <summary>
        /// Indicates the HybirdLineValue Dependency Property
        /// </summary>
        public static readonly DependencyProperty HybirdLineValueProperty =
        DependencyProperty.RegisterAttached("HybirdLineValue", typeof(double?), typeof(HybridChartType), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnlinePropertyChanged)));
        /// <summary>
        /// Gets the value of the HybirdLineValue dependency property.
        /// </summary>
        /// <param name="obj">The DependencyObject obj.</param>
        public static double? GetHybirdLineValue(DependencyObject obj)
        {
            return (double?)obj.GetValue(HybirdLineValueProperty);
        }
        /// <summary>
        /// Sets the value of the HybirdLineValue dependency property.
        /// </summary>
        /// <param name="obj">The DependencyObject obj.</param>
        /// <param name="value">The value.</param>
        public static void SetHybirdLineValue(DependencyObject obj, double? value)
        {
            obj.SetValue(HybirdLineValueProperty, value);
        }
        #endregion

        #region Public methods
        /// <summary>
        ///property Change event for HybirdLineValue
        /// </summary>
        private static void OnlinePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ChartSeries series = d as ChartSeries;
            if (series.Area != null)
            {
                series.Area.UpdateChartArea();
            }
        }

        /// <summary>
        ///To calculate teh Spline values
        /// </summary>
        protected void NaturalSpline1(ChartPoint[] points, out double[] ys2)
        {
            int count = points.Length;

            ys2 = new double[count];

            double a = 6;
            double[] u = new double[count - 1];
            double p;

            ys2[0] = u[0] = 0;
            ys2[count - 1] = 0;

            for (int i = 1; i < count - 1; i++)
            {
                double d1 = points[i].X - points[i - 1].X;
                double d2 = points[i + 1].X - points[i - 1].X;
                double d3 = points[i + 1].X - points[i].X;
                double dy1 = points[i + 1].Y - points[i].Y;
                double dy2 = points[i].Y - points[i - 1].Y;

                if (points[i].X == points[i - 1].X || points[i].X == points[i + 1].X)
                {
                    ys2[i] = 0;
                    u[i] = 0;
                }
                else
                {
                    p = 1 / (d1 * ys2[i - 1] + 2 * d2);

                    ys2[i] = -p * d3;
                    u[i] = p * (a * (dy1 / d3 - dy2 / d1) - d1 * u[i - 1]);
                }
            }

            for (int k = count - 2; k >= 0; k--)
            {
                ys2[k] = ys2[k] * ys2[k + 1] + u[k];
            }
        }

        /// <summary>
        /// Calculates the segments.
        /// </summary>
        /// <param name="series">The series.</param>
        /// <param name="points">The points.</param>
        protected override void CalculateSegments(ChartSeries series, ChartIndexedDataPoint[] points)
        {
            double c1 = GetSplineCoefficient(series);

            //Get the Hybird Area series intersect Line value.
            double? hybirdIntersectLine = HybridChartType.GetHybirdLineValue(series);

            ChartPoint[] point1 = new ChartPoint[points.Length];

            if (points.Length >= 2)
            {
                int i1 = 0;
                double sumy1 = 0;
                foreach (var item in points)
                {
                    point1[i1] = new ChartPoint(item.DataPoint.X, item.DataPoint.Values[0]);
                    sumy1 = sumy1 + item.DataPoint.Values[0] + item.DataPoint.Values[1];
                    i1++;
                }
                double[] yCoef;
                this.NaturalSpline1(point1, out yCoef);

                List<IChartDataPoint> segmentPoints = new List<IChartDataPoint>();

                segmentPoints.Add(points[0].DataPoint);

                for (int i = 1, count = points.Length; i < count; i++)
                {
                    IChartDataPoint startPoint = points[i - 1].DataPoint;
                    IChartDataPoint endPoint = points[i].DataPoint;

                    ChartPoint startControlPoint = null;
                    ChartPoint endControlPoint = null;

                    GetBezierControlPoints(startPoint, endPoint, yCoef[i - 1], yCoef[i], out startControlPoint, out endControlPoint);
                    segmentPoints.AddRange(new IChartDataPoint[] { startControlPoint, endControlPoint, endPoint });

                }

                //Add the HybirdArea segment to the Chart Series
                series.Segments.Add(new HybridChartSegment(segmentPoints.ToArray(), points, series, hybirdIntersectLine));


                //Initialize the Adornment for Chart Series
                if (series.AdornmentsInfo.Visible)
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        series.Adornments.Add(this.CreateAdornment(series, points[i], i));
                    }
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <seealso cref="ChartSplineAreaType"/>
        public override string ToString()
        {
            return "HybirdArea";
        }
        #endregion
    }


    public class FigurePathConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                return value.ToString();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    
   

    public class Model
    {
        public Model()
        {
            this.DataList = new List<Data>();
            DataList.Add(new Data() { X = 2000, Y1 = 20 });
            DataList.Add(new Data() { X = 2002, Y1 = 40 });
            DataList.Add(new Data() { X = 2004, Y1 = 10 });
            DataList.Add(new Data() { X = 2006, Y1 = 40 });
            DataList.Add(new Data() { X = 2008, Y1 = 10 });
        }
        public List<Data> DataList
        {
            get;
            set;
        }
    }
    
}
