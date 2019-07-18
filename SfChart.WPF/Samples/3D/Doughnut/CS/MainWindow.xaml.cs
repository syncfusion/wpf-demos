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

namespace DoughnutChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Animation.Animate3D(DoughnutChart);
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

    public class ViewModel
    {
        public ViewModel()
        {
            this.Expenditure = new List<Model>();

            Expenditure.Add(new Model() { Expense = "E-Mail", Amount = 20d });
            Expenditure.Add(new Model() { Expense = "Skype", Amount = 23d });
            Expenditure.Add(new Model() { Expense = "Phone", Amount = 12d });
            Expenditure.Add(new Model() { Expense = "Sms", Amount = 19d });
            Expenditure.Add(new Model() { Expense = "Facebook", Amount = 10d });
            Expenditure.Add(new Model() { Expense = "Twitter", Amount = 10d });
            Expenditure.Add(new Model() { Expense = "LinkedIn", Amount = 9d });
        }

        public IList<Model> Expenditure
        {
            get;
            set;
        }
    }

    public class Model
    {
        public string Expense
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }
    }

    /// <summary>
    /// To apply format for the adornment labels
    /// </summary>
    public class Labelconvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ChartAdornment pieAdornment = value as ChartAdornment;
            return String.Format("{0} %", pieAdornment.YData);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// To vary the light proportion of the color.
    /// </summary>
    public class ColorConverter : IValueConverter
    {
        private SolidColorBrush ApplyLight(Color color)
        {
            return new SolidColorBrush(Color.FromArgb(color.A, (byte)(color.R * 0.9), (byte)(color.G * 0.9), (byte)(color.B * 0.9)));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                ChartAdornment pieAdornment = value as ChartAdornment;
                int index = pieAdornment.Series.Adornments.IndexOf(pieAdornment);
                SolidColorBrush brush = pieAdornment.Series.ColorModel.CustomBrushes[index] as SolidColorBrush;
                return ApplyLight(brush.Color);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
