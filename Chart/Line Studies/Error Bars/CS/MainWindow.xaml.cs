#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.SampleLayout;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.Shared;

namespace ErrorBarSeriesDemo
{
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
       
        

        #region Horizontal LineStyle method

        private void Strokethickness_TextChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sfchart == null) return;
            (sfchart.Series[1] as ErrorBarSeries).HorizontalLineStyle.StrokeThickness = e.NewValue;
        }

        private void HorLineStroke_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker color = d as ColorPicker;
            (sfchart.Series[1] as ErrorBarSeries).HorizontalLineStyle.Stroke = new SolidColorBrush(color.Color);
        }
      
        private void HorStroke_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (sfchart == null) return;
            switch (combo.SelectedIndex)
            {
                case 0:

                    (sfchart.Series[1] as ErrorBarSeries).HorizontalLineStyle.StrokeDashArray = new DoubleCollection() { 2, 2 };
                    break;
                case 1:
                    (sfchart.Series[1] as ErrorBarSeries).HorizontalLineStyle.StrokeDashArray = new DoubleCollection() { 2, 4 };
                    break;
                case 2:
                    (sfchart.Series[1] as ErrorBarSeries).HorizontalLineStyle.StrokeDashArray = new DoubleCollection() { 4, 2 };
                    break;
                case 3:
                    (sfchart.Series[1] as ErrorBarSeries).HorizontalLineStyle.StrokeDashArray = new DoubleCollection() { 1,0};
                    break;
            }
        }
        
        #endregion

        #region Horizontal Cap LineStyle method
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sfchart == null) return;
            (sfchart.Series[1] as ErrorBarSeries).HorizontalCapLineStyle.Visibility = Visibility.Visible;
          }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sfchart == null) return;
            (sfchart.Series[1] as ErrorBarSeries).HorizontalCapLineStyle.Visibility = Visibility.Collapsed;
        }

        private void HorizontalCapStroke_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker color = d as ColorPicker;
            (sfchart.Series[1] as ErrorBarSeries).HorizontalCapLineStyle.Stroke = new SolidColorBrush(color.Color);
        }
       
        #endregion

        #region Vertical LineStyle method

        private void VerStrokethickness_TextChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sfchart == null) return;
            (sfchart.Series[1] as ErrorBarSeries).VerticalLineStyle.StrokeThickness = e.NewValue;
        }

        private void VerLineStroke_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker color = d as ColorPicker;
            (sfchart.Series[1] as ErrorBarSeries).VerticalLineStyle.Stroke = new SolidColorBrush(color.Color);
        }
       
        private void VerStroke_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (sfchart == null) return;
            switch (combo.SelectedIndex)
            {
                case 0:

                    (sfchart.Series[1] as ErrorBarSeries).VerticalLineStyle.StrokeDashArray = new DoubleCollection() { 2, 2 };
                    break;
                case 1:
                    (sfchart.Series[1] as ErrorBarSeries).VerticalLineStyle.StrokeDashArray = new DoubleCollection() { 2, 4 };
                    break;
                case 2:
                    (sfchart.Series[1] as ErrorBarSeries).VerticalLineStyle.StrokeDashArray = new DoubleCollection() { 4, 2 };
                    break;
                case 3:
                    (sfchart.Series[1] as ErrorBarSeries).VerticalLineStyle.StrokeDashArray = new DoubleCollection() { 1, 0 };
                    break;
            }
        }

     
        #endregion

        #region Vertical Cap LineStyle method

        private void VerticalCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sfchart == null) return;
            (sfchart.Series[1] as ErrorBarSeries).VerticalCapLineStyle.Visibility = Visibility.Visible;
        }

        private void VerticalCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (sfchart == null) return;
            (sfchart.Series[1] as ErrorBarSeries).VerticalCapLineStyle.Visibility = Visibility.Collapsed;
        }
        private void VerticalCapStroke_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker color = d as ColorPicker;
            (sfchart.Series[1] as ErrorBarSeries).VerticalCapLineStyle.Stroke = new SolidColorBrush(color.Color);
        }
        #endregion


        private string previousText;
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        
            double num = 0;
            bool success = double.TryParse(((TextBox)sender).Text, out num);
            if (success & num >= 0)
                previousText = ((TextBox)sender).Text;
            else
                ((TextBox)sender).Text = previousText;
        }     
    }

    public class EnergyProductionDataSample 
    {
        public  EnergyProductionDataSample()
        {
            EnergyProductions = new ObservableCollection<EnergyProduction>();
            EnergyProductions.Add(new EnergyProduction
            {
                ID  = 1,
                Region = "America",
                Country = "Canada",
                Coal = 400,
                Oil = 100,
                Gas = 175,
                Nuclear = 225,
                VerticalErrorValue = 20,
                HorizontalErrorValue = 5
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 2,
                Region = "Asia",
                Country = "China",
                Coal = 925,
                Oil = 200,
                Gas = 350,
                Nuclear = 400,
                VerticalErrorValue = 30,
                HorizontalErrorValue = 3
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 3,
                Region = "Europe",
                Country = "Russia",
                Coal = 550,
                Oil = 200,
                Gas = 250,
                Nuclear = 475,
                VerticalErrorValue = 28,
                HorizontalErrorValue = 2
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 4,
                Region = "Asia",
                Country = "Australia",
                Coal = 450,
                Oil = 100,
                Gas = 150,
                Nuclear = 175,
                VerticalErrorValue = 20,
                HorizontalErrorValue = 1
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 5,
                Region = "America",
                Country = "United States",
                Coal = 800,
                Oil = 250,
                Gas = 475,
                Nuclear = 575,
                VerticalErrorValue = 40,
                HorizontalErrorValue = 2.5
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 6,
                Region = "Europe",
                Country = "France",
                Coal = 375,
                Oil = 150,
                Gas = 350,
                Nuclear = 275,
                VerticalErrorValue = 55,
                HorizontalErrorValue = 0.5
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 7,
                Region = "Europe",
                Country = "Itly",
                Coal = 289,
                Oil = 150,
                Gas = 350,
                Nuclear = 275,
                VerticalErrorValue = 15,
                HorizontalErrorValue = 0.11
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 8,
                Region = "Asia",
                Country = "India",
                Coal = 654,
                Oil = 150,
                Gas = 350,
                Nuclear = 275,
                VerticalErrorValue = 20,
                HorizontalErrorValue = 0.4
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 9,
                Region = "Asia",
                Country = "China",
                Coal = 765,
                Oil = 180,
                Gas = 450,
                Nuclear = 375,
                VerticalErrorValue = 65,
                HorizontalErrorValue = 0.2
            });
        }

        public ObservableCollection<EnergyProduction> EnergyProductions { get; set; }
    }

    public class EnergyProduction
    {
        public double ID { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Year { get; set; }

        public double Nuclear { get; set; }

        public double Coal
        {
            get; set;
        }
        
        public double Oil { get; set; }

        public double Gas
        {
            get; set;
        }

        public double HorizontalErrorValue { get; set; }

        public double VerticalErrorValue { get; set; }
    }
}

