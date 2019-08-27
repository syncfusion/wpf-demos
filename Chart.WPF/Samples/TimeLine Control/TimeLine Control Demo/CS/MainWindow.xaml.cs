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
using System.Collections.ObjectModel;
using Syncfusion.Windows.Chart;
using Syncfusion.Windows.Gauge;

namespace TimeLineControlSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataCollection collection = new DataCollection();
            timelineControl.HoldUpdate = true;
            timelineControl.PrimaryAxis.DateTimeInterval = new TimeSpan(268, 0, 0, 0);
            timelineControl.DataSource = collection.datalist;
            timelineControl.BindingPathX = "TimeStamp";
            timelineControl.BindingPathsY = new string[] { "High" };
            timelineControl.HoldUpdate = false;
            timelineControl.EndInit();
            this.DataContext = collection.datalist;

            this.CircularGauge2.Scales[0].Pointers[0].Value = timelineControl.StartValue;

            Binding binding = new Binding();
            binding.Source = timelineControl;
            binding.Path = new PropertyPath("StartValue");
            binding.Mode = BindingMode.TwoWay;
            this.CircularGauge2.SetBinding(ScaleBase.MinimumProperty, binding);
            
            Binding binding1 = new Binding();
            binding1.Source = timelineControl;
            binding1.Path = new PropertyPath("EndValue");
            binding1.Mode = BindingMode.TwoWay;
            this.CircularGauge2.SetBinding(ScaleBase.MaximumProperty, binding1);
          //  this.CircularGauge2.Scales[0].Pointers[0].SetBinding()
        }

        private void ChartArea_MouseMove(object sender, MouseEventArgs e)
        {           
            //for (int i = 0; i < series1.Data.Count; i++)
            //{
            //    if (series1.Data[i].X == Math.Round((sender as ChartArea).PointToValue((sender as ChartArea).PrimaryAxis, e.GetPosition((sender as ChartArea)))))
            //    {
            //        date.Text = ((TimeLineControlSample.TimeLineData)(series1.Data[i].Item)).TimeStamp.ToString();
            //        vol.Text = ((TimeLineControlSample.TimeLineData)(series1.Data[i].Item)).High.ToString();
            //    }
            //}

            //interactive.OffsetX = e.GetPosition((sender as ChartArea)).X - (sender as ChartArea).AxesThickness.Left;
            //Canvas.SetLeft(stackdata, e.GetPosition((sender as ChartArea)).X - (sender as ChartArea).AxesThickness.Left);
        }

        private void timelineControl_ViewPortChanged(object sender, ViewPortChangedEventArgs e)
        {
            if (null != timelineControl.SelectedData) 
            {
                this.CircularGauge2.Scales[0].Pointers[0].Value = ((ObservableCollection<object>)timelineControl.SelectedData).Min(t => (t as TimeLineData).Low);
                this.CircularGauge1.Scales[0].Pointers[0].Value = ((ObservableCollection<object>)timelineControl.SelectedData).Max(t => (t as TimeLineData).High);
            }
        }

    }

    public class LabelConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.GetType() == typeof(ChartAxisLabel))
            {
                DateTime date;
                DateTime.TryParse((value as ChartAxisLabel).Content.ToString(), out date);
                if (date.Month >= 1 && date.Month <= 3)
                {
                    return "Q1";
                }
                else if (date.Month >= 4 && date.Month <= 6)
                {
                    return "Q2";
                }
                else if (date.Month >= 7 && date.Month <= 9)
                {
                    return "Q3";
                }
                else if (date.Month >= 10 && date.Month <= 12)
                {
                    return "Q4";
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
