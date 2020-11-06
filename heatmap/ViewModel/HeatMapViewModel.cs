#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.HeatMap;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.heatmapdemos.wpf
{
    public class HeatMapViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<EmployeeInfoModel> _productlist;

        private ICommand _gradientcommand;
        private ICommand _listcommand;
        private ICommand _horizontalcommand;
        private ICommand _verticalcommand;

        public ICommand GradientCommand
        {
            get { return _gradientcommand; }
            set { _gradientcommand = value; }
        }

        public ICommand ListCommand
        {
            get { return _listcommand; }
            set { _listcommand = value; }
        }
        public ICommand HorizontalCommand
        {
            get { return _horizontalcommand; }
            set { _horizontalcommand = value; }
        }
        public ICommand VerticalCommand
        {
            get { return _verticalcommand; }
            set { _verticalcommand = value; }
        }


        public HeatMapViewModel()
        {
            GradientCommand = new DelegateCommand(OnGradientchanged);
            ListCommand = new DelegateCommand(OnListChanged);
            HorizontalCommand = new DelegateCommand(OnHorizontalChanged);
            VerticalCommand = new DelegateCommand(OnVerticalChanged);

            ProductList = new ObservableCollection<EmployeeInfoModel>();
            GetData();
        }

        private void OnVerticalChanged(object obj)
        {
            SfHeatMapLegend Legend = obj as SfHeatMapLegend;
            Legend.Orientation = Orientation.Vertical;
            Legend.Width = double.NaN;
            Legend.Height = 250;
            Grid.SetRow(Legend, 1);
            Grid.SetColumn(Legend, 1);
            Legend.Margin = new Thickness(30, 10, 10, 10);
        }

        private void OnHorizontalChanged(object obj)
        {
            SfHeatMapLegend Legend = obj as SfHeatMapLegend;
            Legend.Orientation = Orientation.Horizontal;
            Legend.Width = 400;
            Legend.Height = double.NaN;
            Grid.SetRow(Legend, 2);
            Grid.SetColumn(Legend, 0);
            Legend.Margin = new Thickness(10, 30, 10, 10);
        }

        private void OnListChanged(object obj)
        {
            SfHeatMapLegend Legend = obj as SfHeatMapLegend;
            Legend.LegendMode = LegendMode.List;
            if (Legend.Orientation == Orientation.Horizontal)
            {
                Grid.SetRow(Legend, 2);
                Grid.SetColumn(Legend, 0);
            }
            else
            {
                Grid.SetColumn(Legend, 1);
                Grid.SetRow(Legend, 1);
            }
        }

        private void OnGradientchanged(object obj)
        {
            SfHeatMapLegend Legend = obj as SfHeatMapLegend;
            Legend.LegendMode = LegendMode.Gradient;
            if (Legend.Orientation == Orientation.Horizontal)
            {
                Legend.Width = 400;
                Legend.Height = double.NaN;
                Grid.SetRow(Legend, 2);
            }
            else
            {
                Legend.Width = double.NaN;
                Legend.Height = 250;
                Grid.SetRow(Legend, 1);
            }
        }

        public ObservableCollection<EmployeeInfoModel> ProductList
        {
            get
            {
                return _productlist;
            }
            set
            {
                if (value != _productlist)
                {
                    _productlist = value;
                    onpropertychanged("ProductList");
                }
            }
        }

        private void onpropertychanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void GetData()
        {
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                EmployeeInfoModel Info = new EmployeeInfoModel();
                Info.EmployeeName = employeeName[i];
                Info.January = r.Next(1, 11);
                Info.February = r.Next(1, 11);
                Info.March = r.Next(1, 11);
                Info.April = r.Next(1, 11);
                Info.May = r.Next(1, 11);
                Info.June = r.Next(1, 11);
                Info.July = r.Next(1, 11);
                Info.August = r.Next(1, 11);
                Info.September = r.Next(1, 11);
                Info.October = r.Next(1, 11);
                Info.November = r.Next(1, 11);
                Info.December = r.Next(1, 11);
                this.ProductList.Add(Info);
            }
        }

        string[] employeeName = new string[]
        {
            "Peter Scott",
            "Maria Anders",
            "John Camino",
            "Philips Cramer",
            "Robert King",
            "Simon Crowther",
        };

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

