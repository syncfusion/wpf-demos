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
using Syncfusion.Windows.Shared;

namespace MetroCustomization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            MetroBrushes.Items.Add(new BrushModel() { Brush = Brushes.Magenta, Name = "Magenta" });
            MetroBrushes.Items.Add(new BrushModel() { Brush = Brushes.Purple, Name = "Purple" });
            MetroBrushes.Items.Add(new BrushModel() { Brush = Brushes.Teal, Name = "Teal" });
            MetroBrushes.Items.Add(new BrushModel() { Brush = Brushes.Lime, Name = "Lime" });
            MetroBrushes.Items.Add(new BrushModel() { Brush = Brushes.Brown, Name = "Brown" });
            MetroBrushes.Items.Add(new BrushModel() { Brush = Brushes.Pink, Name = "Pink" });
            MetroBrushes.Items.Add(new BrushModel() { Brush = Brushes.Orange, Name = "Orange" });
            MetroBrushes.Items.Add(new BrushModel() { Brush = Brushes.LightBlue, Name = "Blue" });
            MetroBrushes.Items.Add(new BrushModel() { Brush = Brushes.Red, Name = "Red" });
            MetroBrushes.Items.Add(new BrushModel() { Brush = Brushes.Green, Name = "Green" });

            BckBrushes.Items.Add(new BrushModel() { Name = "Black", Brush = Brushes.Black });
            BckBrushes.Items.Add(new BrushModel() { Name = "White", Brush = Brushes.White });
            BckBrushes.Items.Add(new BrushModel() { Name = "Gray", Brush = Brushes.Gray });

            FgBrushes.Items.Add(new BrushModel() { Name = "Black", Brush = Brushes.Black });
            FgBrushes.Items.Add(new BrushModel() { Name = "White", Brush = Brushes.White });
            FgBrushes.Items.Add(new BrushModel() { Name = "Gray", Brush = Brushes.Gray });
            FgBrushes.Items.Add(new BrushModel() { Brush = Brushes.Pink, Name = "Pink" });
            FgBrushes.Items.Add(new BrushModel() { Brush = Brushes.Orange, Name = "Orange" });
            FgBrushes.Items.Add(new BrushModel() { Brush = Brushes.LightBlue, Name = "Blue" });
            FgBrushes.Items.Add(new BrushModel() { Brush = Brushes.Red, Name = "Red" });
            FgBrushes.Items.Add(new BrushModel() { Brush = Brushes.Green, Name = "Green" });

        }

        private void MetroBrushes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MetroBrushes.SelectedItem != null)
            {
                SkinStorage.SetMetroBrush(this, ((BrushModel)MetroBrushes.SelectedItem).Brush);
            }
        }

        private void BgBrushes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BckBrushes.SelectedItem != null)
            {
                SkinStorage.SetMetroPanelBackgroundBrush(this, ((BrushModel)BckBrushes.SelectedItem).Brush);
            }
        }

        private void FgBrushes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FgBrushes.SelectedItem != null)
            {
                SkinStorage.SetMetroForegroundBrush(this, ((BrushModel)FgBrushes.SelectedItem).Brush);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary dic = new ResourceDictionary();
            dic.Source = new Uri("../../Dictionary1.xaml", UriKind.RelativeOrAbsolute);
            this.Resources.MergedDictionaries[0]["Metro"] = Brushes.Green;
        }
    }

    public class MetroNameConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BrushModel
    {
        public Brush Brush { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
