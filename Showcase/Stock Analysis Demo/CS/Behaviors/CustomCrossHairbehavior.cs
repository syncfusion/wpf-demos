#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace StockAnalysis
{
    public class CustomCrossHairbehavior : ChartCrossHairBehavior
    {

        public ItemsControl SummaryControl;

        public Style SummaryItemsStyle
        {
            get { return (Style)GetValue(SummaryItemsStyleProperty); }
            set { SetValue(SummaryItemsStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SummaryItemsStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SummaryItemsStyleProperty =
            DependencyProperty.Register("SummaryItemsStyle", typeof(Style), typeof(CustomCrossHairbehavior), new PropertyMetadata(null));

        int yCount;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            try
            {
                SummaryControl.Visibility = Visibility.Visible;
                if (PointInfos != null)
                    PointInfos.Clear();
                if (ChartArea == null || !IsActivated) return;
                SetItemsSource(CurrentPoint, ChartArea.Series[0] as ISupportAxes2D);
                if (PointInfos != null) SummaryControl.ItemsSource = PointInfos.Reverse().ToList();
            }
            catch
            {}
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            if(customInfo!=null)
                customInfo.Visibility = Visibility.Collapsed;
            base.OnMouseLeave(e);
        }

        
        ChartCustomInfo customInfo;

        private void SetItemsSource(Point point, ISupportAxes2D series)
        {
            try
            {
                var chartSeries = series as ChartSeries;
                double pointx = Math.Truncate(ChartArea.PointToValue(series.ActualXAxis, point));
                double pointy = Math.Truncate(ChartArea.PointToValue(series.ActualYAxis, point));
                if (chartSeries == null || (!(pointx >= 0) || !(pointx < chartSeries.DataCount))) return;
                customInfo = new ChartCustomInfo
                {
                    LabelX = chartSeries.Label,
                    LabelY = ChartArea.SecondaryAxis.Header.ToString()
                };
                var dataSource = chartSeries.ItemsSource as List<StockData>;
                if (dataSource != null)
                    customInfo.ValueX = dataSource[(int) pointx].TimeStamp.ToString("MM-dd-yyyy");
                customInfo.ValueY = pointy.ToString(series.ActualYAxis.LabelFormat, CultureInfo.CurrentCulture);
                customInfo.YValues = GetYValuesBasedOnIndex(pointx, chartSeries);
                yCount = customInfo.YValues.Count;
                customInfo.LabelYValues = GetLabelYValues();
                customInfo.Visibility = Visibility.Visible;
                PointInfos.Add(customInfo);
                PositionSummaryControl(pointx, chartSeries);
            }
            catch
            {

            }
        }


        private List<string> GetLabelYValues()
        {
            var values = yCount > 1 ? new List<string> { "High", "Low", "Open", "Close" } : new List<string> { "Volume" };
            return values;
        }

        protected override void AttachElements()
        {
            base.AttachElements();
            SummaryControl = new ItemsControl();
            var binding = new Binding {Source = this, Path = new PropertyPath("SummaryItemsStyle")};
            SummaryControl.SetBinding(FrameworkElement.StyleProperty, binding);
            AdorningCanvas.Children.Add(SummaryControl);
            Panel.SetZIndex(SummaryControl, 120);
        }

        private void PositionSummaryControl(double pointx,ChartSeries series)
        {
            var rect=ChartArea.SeriesClipRect;
            var supportAxes = series as ISupportAxes;
            if (supportAxes == null) return;
            var width = Math.Truncate(ChartArea.PointToValue(supportAxes.ActualXAxis, new Point(SummaryControl.ActualWidth,0)));
            if (pointx < rect.Left + width)
            {
                Canvas.SetLeft(SummaryControl, pointx + SummaryControl.ActualWidth);
                Canvas.SetTop(SummaryControl, Convert.ToDouble(ChartArea.SeriesClipRect.Top));
            }
            else
            {
                Canvas.SetLeft(SummaryControl, ChartArea.SeriesClipRect.Left);
                Canvas.SetTop(SummaryControl, Convert.ToDouble(ChartArea.SeriesClipRect.Top));
            }
        }

        protected override void GenerateLabel(ChartPointInfo pointInfo, ChartAxis axis)
        {

        }
    }

    public class ChartCustomInfo : ChartPointInfo
    {
        private IList<double> yValues;

        public IList<double> YValues
        {
            get
            {
                return yValues;
            }
            set
            {
                if (value == yValues) return;
                yValues = value;
                OnPropertyChanged("YValues");
            }
        }

        private Visibility visibility;

        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                if (value != visibility)
                {
                    visibility = value;
                    OnPropertyChanged("Visibility");
                }
            }
        }

        private List<string> ylabelValues;

        public List<string> LabelYValues
        {
            get
            {
                return ylabelValues;
            }
            set
            {
                if (value != ylabelValues)
                {
                    ylabelValues = value;
                    OnPropertyChanged("LabelYValues");
                }
            }
        }

        private string labelX;
        private string labelY;

        /// <summary>
        /// Gets or Sets the x label.
        /// </summary>
        public string LabelX
        {
            get
            {
                return labelX;
            }
            set
            {
                if (value != labelX)
                {
                    labelX = value;
                    OnPropertyChanged("LabelX");
                }
            }
        }

        /// <summary>
        /// Gets or Sets the y label.
        /// </summary>
        public string LabelY
        {
            get
            {
                return labelY;
            }
            set
            {
                if (value != labelY)
                {
                    labelY = value;
                    OnPropertyChanged("LabelY");
                }
            }
        }
    }
}
