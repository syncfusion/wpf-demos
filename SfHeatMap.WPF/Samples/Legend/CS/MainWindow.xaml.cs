#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Legend.ViewModel;
using Syncfusion.UI.Xaml.HeatMap;
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

namespace Legend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData();
            this.DataContext = List;
        }

        private ObservableCollection<EmployeeInfoModel> List = new ObservableCollection<EmployeeInfoModel>();

        private void GetData()
        {
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                EmployeeInfoModel Info = new EmployeeInfoModel();
                Info.EmployeeName = employeeName[i];
                Info.January = r.Next(1,11);
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
                this.List.Add(Info);
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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if(gradient.IsChecked == true)
            {
                Legend.LegendMode = LegendMode.Gradient;
                if(Legend.Orientation == Orientation.Horizontal)
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
            else if(list.IsChecked == true)
            {
                Legend.LegendMode = LegendMode.List;
                if (Legend.Orientation == Orientation.Horizontal)
                {                    
                    Grid.SetRow(Legend, 2);
                    Grid.SetColumn(Legend, 0);
                }
                else
                {
                    Grid.SetColumn(Legend,1);
                    Grid.SetRow(Legend, 1);
                }
            }
        }

        private void RadioButton_Checked1(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (horizontal.IsChecked == true)
            {
                Legend.Orientation = Orientation.Horizontal;
                Legend.Width = 400;
                Legend.Height = double.NaN;
                Grid.SetRow(Legend, 2);
                Grid.SetColumn(Legend, 0);
                Legend.Margin = new Thickness(10,30,10,10);
            }
            else if (vertical.IsChecked == true)
            {
                Legend.Orientation = Orientation.Vertical;
                Legend.Width = double.NaN;
                Legend.Height = 250;
                Grid.SetRow(Legend, 1);
                Grid.SetColumn(Legend, 1);
                Legend.Margin = new Thickness(30, 10, 10, 10);
            }
        }
    }
}
