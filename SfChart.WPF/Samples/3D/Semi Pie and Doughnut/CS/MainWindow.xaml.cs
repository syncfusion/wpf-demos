#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace Semi_PieSeries3D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
      
        PieSeriesDemo3D pieSeriesDemo3D = new PieSeriesDemo3D();

        DoughnutSeriesDemo3D doughnutSeriesDemo3D = new DoughnutSeriesDemo3D();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            if (contentcontrol != null && combobox != null)
            {
                if (combobox.SelectedIndex == 0)
                {
                    contentcontrol.Content = new PieSeriesDemo3D();
                    if (StartSlider != null) StartSlider.Value = 180;
                    if (EndSlider != null) EndSlider.Value = 360;
                }
                else if (combobox.SelectedIndex == 1)
                {
                   contentcontrol.Content = new DoughnutSeriesDemo3D();
                    if (StartSlider != null) StartSlider.Value = 180;
                    if (EndSlider != null) EndSlider.Value = 360;
                }
            }
        }

        private void StartSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
             if (contentcontrol.Content is PieSeriesDemo3D)
            {
                (contentcontrol.Content as PieSeriesDemo3D).PieSeries.StartAngle = (sender as Slider).Value;
            }
            else if (contentcontrol.Content is DoughnutSeriesDemo3D)
            {
                (contentcontrol.Content as DoughnutSeriesDemo3D).DoughnutSeries.StartAngle = (sender as Slider).Value;
            }   
        }

        private void EndSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (contentcontrol.Content is PieSeriesDemo3D)
            {
                (contentcontrol.Content as PieSeriesDemo3D).PieSeries.EndAngle = (sender as Slider).Value;
            }
            else if (contentcontrol.Content is DoughnutSeriesDemo3D)
            {
                (contentcontrol.Content as DoughnutSeriesDemo3D).DoughnutSeries.EndAngle = (sender as Slider).Value;
            }
        }
    }

    public class ViewModel : ObservableCollection<DataValues>
    {
        public ViewModel()
        {
            Add(new DataValues(43, 32));
            Add(new DataValues(20, 34));
            Add(new DataValues(67, 41));
            Add(new DataValues(52, 42));
            Add(new DataValues(71, 48));
            Add(new DataValues(30, 45));
        }
    }

    public class DataValues
    {
        public double Utilization { get; set; }

        public double ResponseTime { get; set; }

        public DataValues(double utilization, double responseTime)
        {
            Utilization = utilization;
            ResponseTime = responseTime;
        }
    }
}
