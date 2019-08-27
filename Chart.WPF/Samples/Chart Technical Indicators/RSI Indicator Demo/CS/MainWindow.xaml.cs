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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.SampleLayout;
using Syncfusion.Windows.Chart;

namespace RSIIndicatorDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        private int leftVisibleIndex = 0;
        private int rightVisibleIndex = 100;
        private object[] defaultParams = new object[] { 14 };

        private List<TechnicalIndicatorData> prices;

        public List<TechnicalIndicatorData> Prices
        {
            get
            {
                return prices;
            }
            set
            {
                if (value != prices)
                {
                    prices = value;
                    if (prices != null && SortByDateOrder)
                    {
                        prices.Sort(new DateSorter());
                    }
                }
            }
        }

        private bool sortByDateOrder = false;

        public bool SortByDateOrder
        {
            get { return sortByDateOrder; }
            set
            {
                if (Prices != null && sortByDateOrder != value && value)
                {
                    Prices.Sort();
                }
                sortByDateOrder = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            #region Constructor
            DataCollection collection = new DataCollection();
            this.SortByDateOrder = true;
            this.Prices = collection.datalist;
            #region events

            this.indicator.Checked += new RoutedEventHandler(Indicator_Checked);
            this.indicator.Unchecked += new RoutedEventHandler(Indicator_UnChecked);
            #endregion

            SetHorizontalScale(this.Area1);
            SetVerticalScale(this.Area1);
            ser1.DataSource = this.Prices;
            ser1.Interior = Brushes.DarkSlateGray;
            ser1.StrokeThickness = 1.5d;
            ser1.BindingPathsY = new string[] { "High", "Low", "Open", "Last", "Volume" };

            DateAxisConverter c = this.Resources["dateaxisconverter"] as DateAxisConverter;
            c.StartIndex = leftVisibleIndex;
            c.Prices = this.Prices;
            c.Format = "M/dd";
            c.IsIntraDayData = false;

            DateAxisFontsizeConverter cc = this.Resources["dateaxisfontsizeconverter"] as DateAxisFontsizeConverter;
            cc.Fontsize = 10d;
            #endregion
        }

        #region EventHandling
        private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            Ellipse recta = sender as Ellipse;
            Grid g = recta.Parent as Grid;

            ToolTip tooltip = new ToolTip();
            tooltip.IsOpen = true;
            tooltip.Content = ((TextBlock)g.Children[0]).Text;
            recta.ToolTip = tooltip;
        }
        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            Ellipse recta = sender as Ellipse;
            ToolTip tooltip = recta.ToolTip as ToolTip;
            tooltip.Visibility = Visibility.Collapsed;

        }
        void Indicator_UnChecked(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < ser1.Indicators.Items.Count; j++)
            {
                if (ser1.Indicators.Items[j].IndicatorType == IndicatorTypes.RelativeStrengthIndex)
                {
                    syncChart1.Areas.Remove(ser1.Indicators.Items[j].rsiArea);
                    ser1.Indicators.Items.RemoveAt(j);
                }
            }
            if (syncChart1.Areas.Count == 1)
            {
                syncChart1.Areas[0].SplitterPosition = 1;
                SetHorizontalScale(syncChart1.Areas[0]);
            }
        }
        void Indicator_Checked(object sender, RoutedEventArgs e)
        {
            ChartTechnicalIndicator indicator = new ChartTechnicalIndicator();
            indicator.IndicatorType = IndicatorTypes.RelativeStrengthIndex;
            ser1.Indicators.Items.Add(indicator);
            syncChart1.Areas[0].SplitterPosition = .6;
            if (syncChart1.Areas.Count > 1)
            {
                //ChartStochastics.SetLowerLineColor(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], Brushes.IndianRed);
                //ChartStochastics.SetUpperLineColor(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], Brushes.IndianRed);
                //ChartStochastics.SetSignalLineColor(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], Brushes.IndianRed);
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.Background = this.Resources["transparentBackground"] as SolidColorBrush;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.SecondaryAxis.LineStroke = this.Resources["linestroke"] as Pen;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.SecondaryAxis.IntersectAction = ChartLabelIntersectAction.Hide;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.SecondaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
                ChartArea.SetGridLineStroke(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.SecondaryAxis, this.Resources["gridstroke"] as Pen);
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.SecondaryAxis.OpposedPosition = true;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.SecondaryAxis.LabelTemplate = this.Resources["YAxistemplate"] as DataTemplate;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.SecondaryAxis.IsAutoSetRange = false;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.SecondaryAxis.Range = new DoubleRange(0, 100);

                for (int i = 0; i < syncChart1.Areas.Count; i++)
                {
                    SetHorizontalScale(syncChart1.Areas[i]);
                }

            }
            ChartLayer layer = new ChartLayer();
            layer.LayerIndicatorName = "Relative Strength Index";
            layer.ParmsToParmString(defaultParams);

            foreach (ChartSeries series in ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.Series)
            {
                AddNotes(series, layer, 5);
            }
            for (int i = 0; i < syncChart1.Areas.Count; i++)
            {
                SetHorizontalScale(syncChart1.Areas[i]);
            }
        }

        #endregion
        public virtual void SetHorizontalScale(ChartArea area)
        {
            area.PrimaryAxis.IsFractionEnabledOnZoom = false;
            area.PrimaryAxis.IsAutoSetRange = false;
            area.PrimaryAxis.HidePartialLabel = true;
            area.PrimaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            area.PrimaryAxis.Interval = 5;
            area.PrimaryAxis.Range = new DoubleRange(leftVisibleIndex - 1, rightVisibleIndex + 1);
            area.PrimaryAxis.LabelTemplate = this.Resources["Axistemplate"] as DataTemplate;

            //code that hides the date axis on the existing Area and enlarges the real estate
            if (syncChart1.Areas.Count != 1)
            {
                syncChart1.Areas[syncChart1.Areas.Count - 2].Margin = new Thickness(0, 0, 0, -30);
                syncChart1.Areas[syncChart1.Areas.Count - 2].PrimaryAxis.LabelTemplate = this.Resources["EmptyAxistemplate"] as DataTemplate;
            }
            else
            {
                syncChart1.Areas[0].Margin = new Thickness(0, 0, 0, 0);
            }
        }
        public void SetVerticalScale(ChartArea area)
        {
            area.SecondaryAxis.OpposedPosition = true;
            area.SecondaryAxis.LabelTemplate = this.Resources["YAxistemplate"] as DataTemplate;
            area.SecondaryAxis.IsAutoSetRange = false;
            area.SecondaryAxis.Range = GetPricesMaxMinRange(area.SecondaryAxis.DesiredIntervalsCount);
        }
        private DoubleRange GetPricesMaxMinRange(int desiredIntervalCount)
        {
            double min = double.MaxValue;
            double max = double.MinValue;
            foreach (TechnicalIndicatorData p in this.Prices)
            {
                if (min > p.Low)
                    min = p.Low;
                if (max < p.High)
                    max = p.High;
            }

            double dx = Math.Ceiling((max - min) / (desiredIntervalCount - 1));

            min = ((int)(min / dx)) * dx;
            max = min + desiredIntervalCount * dx;

            return new DoubleRange(min, max);
        }
        public void AddNotes(ChartSeries series, ChartLayer layer, int position)
        {
            AnnotationsCollection annotations = new AnnotationsCollection();
            ChartSeriesAnnotation annotation = new ChartSeriesAnnotation();
            //annotation.Header = layer.Note;
            if (layer.NoteVisibility == NoteVisibilityState.Opened)
            {
                annotation.Stroke = new SolidColorBrush(layer.StrokeColor);
                annotation.Template = this.Resources["AnnotationTemplateText"] as DataTemplate;
            }
            else
            {
                annotation.Template = this.Resources["AnnotationTemplate"] as DataTemplate;
            }

            annotation.X = series.Data[position].X;
            annotation.Y = series.Data[position].Y;

            annotations.Items.Add(annotation);
            series.Annotations = annotations;

        }

        private void ser1_Loaded(object sender, RoutedEventArgs e)
        {
            this.indicator.IsChecked = true;
        }
    }
}

