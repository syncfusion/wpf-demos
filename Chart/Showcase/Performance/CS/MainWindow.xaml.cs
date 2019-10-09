#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace High_Volume_Data_Demo
{

    public partial class MainWindow : SampleLayoutWindow
    {
        Stopwatch sw = new Stopwatch();  
      
        public MainWindow()
        {
            InitializeComponent();              
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataGenerator viewModel = new DataGenerator();            
            ObservableCollection<Data> collection = viewModel.GenerateData();
            sw.Restart();
            chart1.Series[0].ItemsSource = collection;
        }

        private void Chart_LayoutUpdated(object sender, EventArgs e)
        {
            if (sw != null)
            {
                sw.Stop();                
                text.Text = "Total Time Taken : " + sw.ElapsedMilliseconds.ToString() + " ms";
            }
        }
    }

    public class DataGenerator
    {
        public int DataCount = 500000;

        private Random randomNumber;

        public DataGenerator()
        {
            randomNumber = new Random();
        }

        public ObservableCollection<Data> GenerateData()
        {
            ObservableCollection<Data> datas = new ObservableCollection<Data>();
            DateTime date = new DateTime(2009, 1, 1);
            double value = 1000;

            for (int i = 0; i < this.DataCount; i++)
            {
                datas.Add(new Data(date, value));
                date = date.Add(TimeSpan.FromSeconds(5));

                if (randomNumber.NextDouble() > .5)
                {
                    value += randomNumber.NextDouble();
                }
                else
                {
                    value -= randomNumber.NextDouble();
                }
            }

            return datas;
        }
    }

    public class Data
    {
        public Data(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public double Value
        {
            get;
            set;
        }
    }
}
