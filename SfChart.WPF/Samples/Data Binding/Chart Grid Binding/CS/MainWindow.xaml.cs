#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using VisualDataEditing.Annotations;
using Syncfusion.UI.Xaml.Charts;
using System.Windows.Controls;

namespace ChartDataEditing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();      
        }

        private void SfChart_SelectionChanged(object sender, ChartSelectionChangedEventArgs e)
        {
            var selectedSegment = e.SelectedSegment as DoughnutSegment;

            if (selectedSegment != null)
            {
                XText.Text = "FY" + " " + selectedSegment.XData.FromOADate().ToString("yyyy");
                YText.Text = selectedSegment.YData.ToString();
            }         
        }
    }

    public class Model : INotifyPropertyChanged
    {
        private DateTime xValue;

        public DateTime XValue
        {
            get { return xValue; }
            set
            {
                if (value != xValue)
                {
                    xValue = value;
                    OnPropertyChanged("XValue");
                }
            }
        }

        private double yValue;

        public double YValue
        {
            get { return yValue; }
            set
            {
                if (value != yValue)
                {
                    yValue = value;
                    OnPropertyChanged("YValue");
                }
            }
        }

        private double scatter;

        public double Scatter
        {
            get { return scatter; }
            set
            {
                if (value != scatter)
                {
                    scatter = value;
                    OnPropertyChanged("Scatter");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            var date = new DateTime(2015, 1, 1);
            var random = new Random();

            Data = new ObservableCollection<Model>();

            Data.Add(new Model() { XValue = date.AddYears(0), YValue = 35, Scatter = 94 });
            Data.Add(new Model() { XValue = date.AddYears(1), YValue = 18, Scatter = 20 });
            Data.Add(new Model() { XValue = date.AddYears(2), YValue = 60, Scatter = 65 });
            Data.Add(new Model() { XValue = date.AddYears(3), YValue = 75, Scatter = 30 });
            Data.Add(new Model() { XValue = date.AddYears(4), YValue = 65, Scatter = 85 });
        }

        public ObservableCollection<Model> Data { get; set; }
    }

    public class CenterViewSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }

            var size = (double)value;

            return double.IsNaN(size) ? 0 : size * 1.80;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

