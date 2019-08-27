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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Animation.Animate3D(columnChart);
        }
    }

    public static class Animation
    {
        public static void Animate3D(SfChart3D chart)
        {
            var sb = new Storyboard();

            DoubleAnimation animation = new DoubleAnimation() { From = 0, To = chart.Rotation, };
            Storyboard.SetTarget(animation, chart);
            Storyboard.SetTargetProperty(animation, new PropertyPath(SfChart3D.RotationProperty));

            sb.Children.Add(animation);

            animation = new DoubleAnimation() { From = 0, To = chart.Tilt, };
            Storyboard.SetTarget(animation, chart);
            Storyboard.SetTargetProperty(animation, new PropertyPath(SfChart3D.TiltProperty));
            sb.Children.Add(animation);

            EventHandler handler = (object sender, EventArgs e) =>
            {
                var rotation = chart.Rotation;
                var tilt = chart.Tilt;
                chart.BeginAnimation(SfChart3D.RotationProperty, null);
                chart.BeginAnimation(SfChart3D.TiltProperty, null);

                chart.Rotation = rotation;
                chart.Tilt = tilt;
            };

            sb.Completed += handler;
            sb.Begin();

        }
    }

    public class CategoryDataViewModel
    {
        public CategoryDataViewModel()
        {
            CategoricalDatas = new ObservableCollection<CategoryData>();

            CategoricalDatas.Add(new CategoryData(7, 5, "2008"));
            CategoricalDatas.Add(new CategoryData(13, 10, "2009"));
            CategoricalDatas.Add(new CategoryData(15, 12, "2010"));
            CategoricalDatas.Add(new CategoryData(21, 20, "2011"));
            CategoricalDatas.Add(new CategoryData(25, 23, "2012"));
        }

        public ObservableCollection<CategoryData> CategoricalDatas
        {
            get;
            set;
        }
    }

    public class CategoryData : INotifyPropertyChanged
    {
        private double value;

        public CategoryData(double metal, double plastic, string year)
        {
            Plastic = plastic;
            Year = year;
            Metal = metal;
        }

        public string Year
        {
            get;
            set;
        }

        public double Plastic
        {
            get
            {
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged("Value");
                }
            }
        }

        public double Metal
        {
            get;
            set;
        }

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

   
