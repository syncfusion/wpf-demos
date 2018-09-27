using Syncfusion.Windows.Shared;
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
namespace WeatherAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void gridButton_Clicked(object sender, RoutedEventArgs e)
        {
            GridView gridView=new GridView();
            //this.gridButton.IsEnabled = false;
            this.ContentHolder.Content = gridView;
        }

        private void chartButton_Clicked(object sender, RoutedEventArgs e)
        {
            //this.chartButton.IsEnabled = false;
            ChartView chartView = new ChartView();
            this.ContentHolder.Content = chartView;
        }
    }
}
