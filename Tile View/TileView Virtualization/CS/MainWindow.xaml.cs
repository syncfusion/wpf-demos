#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
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

namespace TileViewVirtualization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel viewContext;
        public MainWindow()
        {
            InitializeComponent();
            viewContext = new ViewModel();
            this.DataContext = viewContext;
        }

        private void LoadTileViewItems(object sender, RoutedEventArgs e)
        {
            TileView.Visibility = Visibility.Visible;
            Binding b = new Binding();
            b.Mode = BindingMode.TwoWay;
            b.Source = viewContext;
            b.Path = new PropertyPath("EmployeeDetails");
            BindingOperations.SetBinding(TileView, TileViewControl.ItemsSourceProperty, b);
            (sender as Button).Visibility = Visibility.Collapsed;
        }
    }

    public class StyleConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            MainWindow window = Application.Current.MainWindow as MainWindow;
            Style basestyle = new Style();
            if (window != null && window.Resources.MergedDictionaries.Count > 0 && window.TileView.Resources.MergedDictionaries.Count > 0)
            {
                ResourceDictionary rdic = window.TileView.Resources.MergedDictionaries[window.TileView.Resources.MergedDictionaries.Count - 1] as ResourceDictionary;
                basestyle = rdic[value.ToString() + "TileViewItemStyle"] as Style;
                Style itemcontainerstyle = window.Resources["tileViewItemStyle"] as Style;
                foreach (Setter setter in itemcontainerstyle.Setters)
                {
                    basestyle.Setters.Add(setter);
                }
            }
            return basestyle;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }

}
