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
using Syncfusion.Windows.Chart;
using System.Reflection;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls.Primitives;
using Syncfusion.Windows.SampleLayout;

namespace ChartTechnicalIndicatorDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : SampleLayoutWindow
    {
        public string PathToData = @"C:\Data";
        ListBox lb= new ListBox ();
        Popup pu = new Popup();
        public Window1()
        {
            InitializeComponent();
            
            #region Constructor
            DataCollection collection = new DataCollection();
            lb.Name = "L_b";
            lb.ItemsSource = new CheckBox[] { new CheckBox() { Margin = new Thickness(0), Content = IndicatorTypes.AccumulationDistribution.ToString() }, new CheckBox() { Margin = new Thickness(0), Content = IndicatorTypes.BollingerBands.ToString() }, new CheckBox() { Margin = new Thickness(0), Content = IndicatorTypes.ExponentialAverage.ToString() }, new CheckBox() { Margin = new Thickness(0), Content = IndicatorTypes.MACD.ToString() }, new CheckBox() { Margin = new Thickness(0), Content = IndicatorTypes.Momentum.ToString() }, new CheckBox() { Margin = new Thickness(0), Content = IndicatorTypes.Stochastics.ToString() }, new CheckBox() { Margin = new Thickness(0), Content = IndicatorTypes.TriangularAverage.ToString() }, new CheckBox() { Margin = new Thickness(0), Content = IndicatorTypes.RelativeStrengthIndex.ToString() }, new CheckBox() { Margin = new Thickness(0), Content = IndicatorTypes.SimpleAverage.ToString() } };
            #region events
            (lb.Items[0] as CheckBox).Checked += new RoutedEventHandler(Window1_Checked1);
            (lb.Items[0] as CheckBox).Unchecked += new RoutedEventHandler(Window1_Unchecked1);
            (lb.Items[1] as CheckBox).Checked += new RoutedEventHandler(Window1_Checked2);
            (lb.Items[1] as CheckBox).Unchecked += new RoutedEventHandler(Window1_Unchecked2);
            (lb.Items[2] as CheckBox).Checked += new RoutedEventHandler(Window1_Checked3);
            (lb.Items[2] as CheckBox).Unchecked += new RoutedEventHandler(Window1_Unchecked3);
            (lb.Items[3] as CheckBox).Checked += new RoutedEventHandler(Window1_Checked4);
            (lb.Items[3] as CheckBox).Unchecked += new RoutedEventHandler(Window1_Unchecked4);
            (lb.Items[4] as CheckBox).Checked += new RoutedEventHandler(Window1_Checked5);
            (lb.Items[4] as CheckBox).Unchecked += new RoutedEventHandler(Window1_Unchecked5);
            (lb.Items[5] as CheckBox).Checked += new RoutedEventHandler(Window1_Checked6);
            (lb.Items[5] as CheckBox).Unchecked += new RoutedEventHandler(Window1_Unchecked6);
            (lb.Items[6] as CheckBox).Checked += new RoutedEventHandler(Window1_Checked7);
            (lb.Items[6] as CheckBox).Unchecked += new RoutedEventHandler(Window1_Unchecked7);
            (lb.Items[7] as CheckBox).Checked += new RoutedEventHandler(Window1_Checked8);
            (lb.Items[7] as CheckBox).Unchecked += new RoutedEventHandler(Window1_Unchecked8);
            (lb.Items[8] as CheckBox).Checked += new RoutedEventHandler(Window1_Checked9);
            (lb.Items[8] as CheckBox).Unchecked += new RoutedEventHandler(Window1_Unchecked9);
            #endregion  
            ser1.DataSource = collection.datalist;
            xaxis.IsAutoSetRange = false  ;
            xaxis.DateTimeRange = new DateTimeRange(DateTime.FromOADate(ser1.Data[ser1.Data.Count - 1].X), DateTime.FromOADate(ser1.Data[0].X));
            SetPointText(new DoubleRange(xaxis.DateTimeRange.Start.ToOADate(), xaxis.DateTimeRange.End.ToOADate()));                       
            #endregion
        }

        #region EventHandling
        void Window1_Unchecked1(object sender, RoutedEventArgs e)
        {   
                for (int j = 0; j < ser1.Indicators.Items.Count; j++)
                {
                    if (ser1.Indicators.Items[j].IndicatorType  == IndicatorTypes.AccumulationDistribution)
                    {                        
                        syncChart1.Areas.Remove(ser1.Indicators.Items[j].accumulationArea);
                        ser1.Indicators.Items.RemoveAt(j);                        
                    }
                }
                if (ser1.Indicators.Count < 1)
                {
                    reset.IsEnabled = false;
                }
                if (syncChart1.Areas.Count == 1)
                {
                    syncChart1.Areas[0].SplitterPosition = 1;
                }            

        }

        void Window1_Checked1(object sender, RoutedEventArgs e)
        {
            if (reset.IsEnabled == false)
            {
                reset.IsEnabled = true;
            }
            ChartTechnicalIndicator indicator = new ChartTechnicalIndicator();
            indicator.IndicatorType = IndicatorTypes.AccumulationDistribution;
            ser1.Indicators.Items.Add(indicator);
            ChartAccumulationDistribution.SetSignalLineColor(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], new SolidColorBrush(Color.FromRgb(0x00,0xD3,0x0A)));                        
                            
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].accumulationArea.SecondaryAxis.LineStroke = this.Resources["pen1"] as Pen;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].accumulationArea.SecondaryAxis.TickLineStroke = this.Resources["pen1"] as Pen;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].accumulationArea.SecondaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
                ChartArea.SetGridLineStroke(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].accumulationArea.SecondaryAxis, this.Resources["pen1"] as Pen);
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].accumulationArea.SecondaryAxis.LabelForeground = this.Resources["gradient2"] as LinearGradientBrush;                        
                      
            indicator.accumulationArea.Loaded += new RoutedEventHandler(accumulationArea_Loaded);
        }

        void accumulationArea_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (ChartArea area in this.syncChart1.Areas)
            {
                if (area == sender as ChartArea)
                {
                    area.Margin = new Thickness(-syncChart1.AxesThickness.Left, area.AxesThickness.Top, 0, area.AxesThickness.Bottom);
                }
            }            
        }
        void Window1_Unchecked2(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < ser1.Indicators.Items.Count; j++)
            {
                if (ser1.Indicators.Items[j].IndicatorType == IndicatorTypes.BollingerBands)
                {                    
                    ser1.Indicators.Items.RemoveAt(j);
                }
            }
            if (ser1.Indicators.Count < 1)
            {
                reset.IsEnabled = false;
            }
        }

        void Window1_Checked2(object sender, RoutedEventArgs e)
        {
            if (reset.IsEnabled == false)
            {
                reset.IsEnabled = true;
            }          
            
            ChartTechnicalIndicator indicator = new ChartTechnicalIndicator();
            indicator.IndicatorType = IndicatorTypes.BollingerBands;           
            ser1.Indicators.Items.Add(indicator);
            
            ChartBollingerBand.SetUpperLineColor(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], new SolidColorBrush(Color.FromRgb(0x00,0xD3,0x0A)));
            ChartBollingerBand.SetLowerLineColor(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], new SolidColorBrush(Color.FromRgb(0x00,0xF3,0xFF)));
            ChartBollingerBand.SetSignalLineColor(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], new SolidColorBrush(Color.FromRgb(0xFF,0xF2,0x00)));
            
        }
        void Window1_Unchecked3(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < ser1.Indicators.Items.Count; j++)
            {
                if (ser1.Indicators.Items[j].IndicatorType == IndicatorTypes.ExponentialAverage )
                {                    
                    ser1.Indicators.Items.RemoveAt(j);
                }
            }
            if (ser1.Indicators.Count < 1)
            {
                reset.IsEnabled = false;
            }
        }

        void Window1_Checked3(object sender, RoutedEventArgs e)
        {
            if (reset.IsEnabled == false)
            {
                reset.IsEnabled = true;
            }
            ChartTechnicalIndicator indicator = new ChartTechnicalIndicator();
            indicator.IndicatorType = IndicatorTypes.ExponentialAverage;
            ser1.Indicators.Items.Add(indicator);
            ChartExponentialAverage.SetSignalLineInterior(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], new SolidColorBrush(Color.FromRgb(0x00,0xF3,0xFF))); 
        }
        void Window1_Unchecked4(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < ser1.Indicators.Items.Count; j++)
            {
                if (ser1.Indicators.Items[j].IndicatorType == IndicatorTypes.MACD)
                {
                    syncChart1.Areas.Remove(ser1.Indicators.Items[j].MACDArea);
                    ser1.Indicators.Items.RemoveAt(j);
                }
            }
            if (ser1.Indicators.Count < 1)
            {
                reset.IsEnabled = false;
            }
            if (syncChart1.Areas.Count == 1)
            {
                syncChart1.Areas[0].SplitterPosition = 1;
            }
            
        }

        void Window1_Checked4(object sender, RoutedEventArgs e)
        {
            if (reset.IsEnabled == false)
            {
                reset.IsEnabled = true;
            }
            
            ChartTechnicalIndicator indicator = new ChartTechnicalIndicator();
            indicator.IndicatorType = IndicatorTypes.MACD;
            ser1.Indicators.Items.Add(indicator);
            syncChart1.Areas[syncChart1.Areas.Count-1].BeginInit();            
            if (syncChart1.Areas.Count > 1)
            {
                ChartMACD.SetDivergenceLineColor(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], new SolidColorBrush(Color.FromRgb(0x00, 0xD3, 0x0A)));
                ChartMACD.SetConvergenceLineColor(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], new SolidColorBrush(Color.FromRgb(0x00, 0xF3, 0xFF)));
                ChartMACD.SetSignalLineInterior(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], new SolidColorBrush(Color.FromRgb(0xFF, 0xF2, 0xFF))); 
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].MACDArea.SecondaryAxis.LineStroke = this.Resources["pen1"] as Pen;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].MACDArea.SecondaryAxis.TickLineStroke = this.Resources["pen1"] as Pen;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].MACDArea.SecondaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
                ChartArea.SetGridLineStroke(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].MACDArea.SecondaryAxis, this.Resources["pen1"] as Pen);
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].MACDArea.SecondaryAxis.LabelForeground = this.Resources["gradient2"] as LinearGradientBrush;
            }            
            syncChart1.Areas[syncChart1.Areas.Count - 1].EndInit();

        }
        void Window1_Unchecked5(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < ser1.Indicators.Items.Count; j++)
            {
                if (ser1.Indicators.Items[j].IndicatorType == IndicatorTypes.Momentum)
                {
                    syncChart1.Areas.Remove(ser1.Indicators.Items[j].momentumArea);
                    ser1.Indicators.Items.RemoveAt(j);
                }
            }
            if (ser1.Indicators.Count < 1)
            {
                reset.IsEnabled = false;
            }
            if (syncChart1.Areas.Count == 1)
            {
                syncChart1.Areas[0].SplitterPosition = 1;
            }            
        }

        void Window1_Checked5(object sender, RoutedEventArgs e)
        {
            if (reset.IsEnabled == false)
            {
                reset.IsEnabled = true;
            }
            ChartTechnicalIndicator indicator = new ChartTechnicalIndicator();
            indicator.IndicatorType = IndicatorTypes.Momentum;
            ser1.Indicators.Items.Add(indicator);
            if (syncChart1.Areas.Count > 1)            
            {
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].momentumArea.SecondaryAxis.LineStroke = this.Resources["pen1"] as Pen;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].momentumArea.SecondaryAxis.TickLineStroke = this.Resources["pen1"] as Pen;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].momentumArea.SecondaryAxis.IntersectAction = ChartLabelIntersectAction.Hide;
                ChartArea.SetGridLineStroke(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].momentumArea.SecondaryAxis, this.Resources["pen1"] as Pen);
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].momentumArea.SecondaryAxis.LabelForeground = this.Resources["gradient2"] as LinearGradientBrush;

            }
        }
        void Window1_Unchecked6(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < ser1.Indicators.Items.Count; j++)
            {
                if (ser1.Indicators.Items[j].IndicatorType == IndicatorTypes.Stochastics)
                {
                    syncChart1.Areas.Remove(ser1.Indicators.Items[j].stocasticsArea);
                    ser1.Indicators.Items.RemoveAt(j);
                }
            }
            if (ser1.Indicators.Count < 1)
            {
                reset.IsEnabled = false;
            }
            if (syncChart1.Areas.Count == 1)
            {
                syncChart1.Areas[0].SplitterPosition = 1;
            }            

        }

        void Window1_Checked6(object sender, RoutedEventArgs e)
        {
            if (reset.IsEnabled == false)
            {
                reset.IsEnabled = true;
            }
            ChartTechnicalIndicator indicator = new ChartTechnicalIndicator();
            indicator.IndicatorType = IndicatorTypes.Stochastics ;
            ser1.Indicators.Items.Add(indicator);
            if (syncChart1.Areas.Count > 1)
            {
                ChartStochastics.SetLowerLineColor(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], new SolidColorBrush(Color.FromRgb(0x00, 0xD3, 0x0A)));
                ChartStochastics.SetUpperLineColor(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], new SolidColorBrush(Color.FromRgb(0x00, 0xF3, 0xFf)));
                ChartStochastics.SetSignalLineColor(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], new SolidColorBrush(Color.FromRgb(0xFF, 0xF2, 0x00)));
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].stocasticsArea.SecondaryAxis.LineStroke = this.Resources["pen1"] as Pen;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].stocasticsArea.SecondaryAxis.TickLineStroke = this.Resources["pen1"] as Pen;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].stocasticsArea.SecondaryAxis.IntersectAction = ChartLabelIntersectAction.Hide;
                ChartArea.SetGridLineStroke(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].stocasticsArea.SecondaryAxis, this.Resources["pen1"] as Pen);
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].stocasticsArea.SecondaryAxis.LabelForeground = this.Resources["gradient2"] as LinearGradientBrush;
            }

        }
        void Window1_Unchecked7(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < ser1.Indicators.Items.Count; j++)
            {
                if (ser1.Indicators.Items[j].IndicatorType == IndicatorTypes.TriangularAverage)
                {                    
                    ser1.Indicators.Items.RemoveAt(j);
                }
            }
            if (ser1.Indicators.Count < 1)
            {
                reset.IsEnabled = false;
            }
        }

        void Window1_Checked7(object sender, RoutedEventArgs e)
        {
            if (reset.IsEnabled == false)
            {
                reset.IsEnabled = true;
            }
            ChartTechnicalIndicator indicator = new ChartTechnicalIndicator();
            indicator.IndicatorType = IndicatorTypes.TriangularAverage ;            
            ser1.Indicators.Items.Add(indicator);
            ChartTriangularAverage.SetSignalLineColor(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], new SolidColorBrush(Color.FromRgb(0x7A, 0x00, 0x93)));
        }
        void Window1_Unchecked8(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < ser1.Indicators.Items.Count; j++)
            {
                if (ser1.Indicators.Items[j].IndicatorType == IndicatorTypes.RelativeStrengthIndex)
                {
                    syncChart1.Areas.Remove(ser1.Indicators.Items[j].rsiArea);
                    ser1.Indicators.Items.RemoveAt(j);
                }
            }
            if (ser1.Indicators.Count < 1)
            {
                reset.IsEnabled = false;
            }

            if (syncChart1.Areas.Count == 1)
            {
                syncChart1.Areas[0].SplitterPosition = 1;
            }            

        }

        void Window1_Checked8(object sender, RoutedEventArgs e)
        {
            if (reset.IsEnabled == false)
            {
                reset.IsEnabled = true;
            }
            ChartTechnicalIndicator indicator = new ChartTechnicalIndicator();
            indicator.IndicatorType = IndicatorTypes.RelativeStrengthIndex ;
            ser1.Indicators.Items.Add(indicator);
            if (syncChart1.Areas.Count > 1)
            {
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.SecondaryAxis.LineStroke = this.Resources["pen1"] as Pen;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.SecondaryAxis.TickLineStroke = this.Resources["pen1"] as Pen;
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.SecondaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
                ChartArea.SetGridLineStroke(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.SecondaryAxis, this.Resources["pen1"] as Pen);
                ser1.Indicators.Items[ser1.Indicators.Items.Count - 1].rsiArea.SecondaryAxis.LabelForeground = this.Resources["gradient2"] as LinearGradientBrush;
            }
            

        }
        void Window1_Unchecked9(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < ser1.Indicators.Items.Count; j++)
            {
                if (ser1.Indicators.Items[j].IndicatorType == IndicatorTypes.SimpleAverage)
                {                    
                    ser1.Indicators.Items.RemoveAt(j);
                }
            }
            if (ser1.Indicators.Count < 1)
            {
                reset.IsEnabled = false;
            }
        }

        void Window1_Checked9(object sender, RoutedEventArgs e)
        {
            if (reset.IsEnabled == false)
            {
                reset.IsEnabled = true;
            }
            ChartTechnicalIndicator indicator = new ChartTechnicalIndicator();
            indicator.IndicatorType = IndicatorTypes.SimpleAverage;
            ser1.Indicators.Items.Add(indicator);
            ChartSimpleAverage.SetSignalLineInterior(ser1.Indicators.Items[ser1.Indicators.Items.Count - 1], new SolidColorBrush(Color.FromRgb(0xDD,0x00,0x00)));
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            syncChart1.PrimaryAxis.ZoomFactor = 0.398;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            syncChart1.PrimaryAxis.ZoomFactor = 0.599;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            syncChart1.PrimaryAxis.ZoomFactor = 1;
            ChartAreaCommands.ZoomReset.Execute(null, syncChart1);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            syncChart1.PrimaryAxis.ZoomFactor = 0.197;

        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            syncChart1.PrimaryAxis.ZoomFactor = 0.108;

        }         
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ClearIndicators();
            int count = syncChart1.Areas.Count;
            for (int i = 1; i < count; i++)
            {
                syncChart1.Areas.RemoveAt(1);
            }
            syncChart1.Areas[0].SplitterPosition = 1;
            analyse.IsEnabled = true;
            reset.IsEnabled = false;            
            ChartAreaCommands.ZoomReset.Execute(null, syncChart1);
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {              
            pu.Child = lb;
            pu.MouseLeave += new MouseEventHandler(pu_MouseLeave);
            pu.LostFocus += new RoutedEventHandler(pu_LostFocus);
            pu.IsOpen = true;
            pu.PlacementTarget = this.analyse;

        }

        void pu_LostFocus(object sender, RoutedEventArgs e)
        {
            pu.IsOpen = false;
        }

        void pu_MouseLeave(object sender, MouseEventArgs e)
        {
            pu.IsOpen = false;
        }
        private void xaxis_RangeChanged(object sender, ChartAxisRangeArgs e)
        {
            SetPointText(new DoubleRange(xaxis.Range.Start, xaxis.Range.End));
        }

        private void ser1_PropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.Property.ToString() == "FastTypePen" && xaxis.ZoomFactor !=1)
            {               
                SetPointText(new DoubleRange(xaxis.Area.ZoomedXRange.Start, xaxis.Area.ZoomedXRange.End));                
                syncChart1.UpdateChartArea();
            }
        }
        #endregion
        private bool isSetZooming = false;
        double zoom1 = 0.9, zoom2 = 0.8;
        private void setZooming()
        {
            syncChart1.PrimaryAxis.ZoomFactor = zoom1;
            isSetZooming = true;
        }
        private void unsetZooming()
        {
            syncChart1.PrimaryAxis.ZoomFactor = zoom2;
            isSetZooming = false;
        }  

        private void ClearIndicators()
        {
            if (ser1.Indicators.Items.Count >= 1)
            {
                for(int k=1;k<syncChart1.Areas.Count ;k++)
                {
                    syncChart1.Areas.RemoveAt(k);
                }                   
                ser1.Indicators.Items.Clear();
                syncChart1.PrimaryAxis.ZoomFactor = 1;                
            }
            for (int c = 0; c < lb.Items.Count; c++)
            {
                if ((bool)(lb.Items[c] as CheckBox).IsChecked)
                {
                    (lb.Items[c] as CheckBox).IsChecked = false;
                }
            }
        }      

        private void SetPointText(DoubleRange axisrange)
        {
            double[] val = new double[ser1.Data.Count - 1];
            double[] val1 = new double[ser1.Data.Count - 1];
            double min = 0d; int j = 0;            
            if (axisrange.Start != 0 && axisrange.End != 0)
            {
                for (int i = 0; i < ser1.Data.Count - 1; i++)
                {
                    if (((ChartTechnicalIndicatorDemo.TechnicalIndicatorData)(ser1.Data[i].Item)).TimeStamp >= DateTime.FromOADate(axisrange.Start) && ((ChartTechnicalIndicatorDemo.TechnicalIndicatorData)(ser1.Data[i].Item)).TimeStamp <= DateTime.FromOADate(axisrange.End))
                    {
                        val[i] = ser1.Data[i].Y;
                        j++;
                        if (min == 0d)
                        {
                            min = val[i];
                        }
                        if (val[i] < min)
                        {
                            min = val[i];
                        }
                    }
                    val1[i] = ser1.Data[i].Y;
                }
                if (j != 0)
                {
                    low1.Text = val1.Min().ToString();
                    high1.Text = val1.Max().ToString();
                    range1.Text = Math.Round((val1.Max() - val1.Min()), 2).ToString();
                    key.Text = min.ToString();
                    high.Text = val.Max().ToString();
                    range.Text = Math.Round((val.Max() - min), 2).ToString();
                    volume.Text = ser1.Data[(int)j - 1].Values[3].ToString();
                    prevclose.Text = ser1.Data[(int)j - 1].Values[2].ToString();
                }
            }            
        }         
    }    
}

