#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;

namespace Sparkline_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Model();
        }

        private void RibbonGalleryItem_Click(object sender, RoutedEventArgs e)
        {
            spark1.Interior = new SolidColorBrush(Colors.Blue);
            spark2.Interior = new SolidColorBrush(Colors.Blue);
            spark3.Interior = new SolidColorBrush(Colors.Blue);
            spark4.Interior = new SolidColorBrush(Colors.Blue);
            spark5.Interior = new SolidColorBrush(Colors.Blue);
            spark6.Interior = new SolidColorBrush(Colors.Blue);
            spark7.Interior = new SolidColorBrush(Colors.Blue);
            spark8.Interior = new SolidColorBrush(Colors.Blue);
            spark9.Interior = new SolidColorBrush(Colors.Blue);
            spark10.Interior = new SolidColorBrush(Colors.Blue);
            spark11.Interior = new SolidColorBrush(Colors.Blue);
            spark12.Interior = new SolidColorBrush(Colors.Blue);
            spark13.Interior = new SolidColorBrush(Colors.Blue);
            spark14.Interior = new SolidColorBrush(Colors.Blue);
            
        }

        private void BackStageCommandButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            MarkerEnabled.IsEnabled = true;
           
                spark1.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                spark2.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                spark3.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                spark4.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                spark5.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                spark6.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                spark7.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                spark8.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                spark9.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                spark10.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                spark11.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                spark12.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                spark13.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                spark14.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Line;
                
           
        }

        private void RibbonButton_Click_1(object sender, RoutedEventArgs e)
        {
            MarkerEnabled.IsEnabled = false;
            spark1.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
            spark2.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
            spark3.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
            spark4.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
            spark5.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
            spark6.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
            spark7.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
            spark8.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
            spark9.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
            spark10.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
            spark11.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
            spark12.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
            spark13.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
            spark14.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.Column;
        }

        private void RibbonButton_Click_2(object sender, RoutedEventArgs e)
        {
            MarkerEnabled.IsEnabled = false;
            NegetivePointsHighlighted.IsChecked = true;
            spark1.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
            spark2.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
            spark3.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
            spark4.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
            spark5.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
            spark6.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
            spark7.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
            spark8.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
            spark9.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
            spark10.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
            spark11.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
            spark12.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
            spark13.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
            spark14.SparkLineType = Syncfusion.Windows.Chart.SparkLineTypes.WinLoss;
        }

        private void RibbonGalleryItem_Click_1(object sender, RoutedEventArgs e)
        {
            spark1.Interior = new SolidColorBrush(Colors.Maroon);
            spark2.Interior = new SolidColorBrush(Colors.Maroon);
            spark3.Interior = new SolidColorBrush(Colors.Maroon);
            spark4.Interior = new SolidColorBrush(Colors.Maroon);
            spark5.Interior = new SolidColorBrush(Colors.Maroon);
            spark6.Interior = new SolidColorBrush(Colors.Maroon);
            spark7.Interior = new SolidColorBrush(Colors.Maroon);
            spark8.Interior = new SolidColorBrush(Colors.Maroon);
            spark9.Interior = new SolidColorBrush(Colors.Maroon);
            spark10.Interior = new SolidColorBrush(Colors.Maroon);
            spark11.Interior = new SolidColorBrush(Colors.Maroon);
            spark12.Interior = new SolidColorBrush(Colors.Maroon);
            spark13.Interior = new SolidColorBrush(Colors.Maroon);
            spark14.Interior = new SolidColorBrush(Colors.Maroon);
        }

        private void RibbonGalleryItem_Click_2(object sender, RoutedEventArgs e)
        {
            spark1.Interior = new SolidColorBrush(Colors.Green);
            spark2.Interior = new SolidColorBrush(Colors.Green);
            spark3.Interior = new SolidColorBrush(Colors.Green);
            spark4.Interior = new SolidColorBrush(Colors.Green);
            spark5.Interior = new SolidColorBrush(Colors.Green);
            spark6.Interior = new SolidColorBrush(Colors.Green);
            spark7.Interior = new SolidColorBrush(Colors.Green);
            spark8.Interior = new SolidColorBrush(Colors.Green);
            spark9.Interior = new SolidColorBrush(Colors.Green);
            spark10.Interior = new SolidColorBrush(Colors.Green);
            spark11.Interior = new SolidColorBrush(Colors.Green);
            spark12.Interior = new SolidColorBrush(Colors.Green);
            spark13.Interior = new SolidColorBrush(Colors.Green);
            spark14.Interior = new SolidColorBrush(Colors.Green);
            
        }

        private void RibbonGalleryItem_Click_3(object sender, RoutedEventArgs e)
        {
            spark1.Interior = new SolidColorBrush(Colors.DarkBlue);
            spark2.Interior = new SolidColorBrush(Colors.DarkBlue);
            spark3.Interior = new SolidColorBrush(Colors.DarkBlue);
            spark4.Interior = new SolidColorBrush(Colors.DarkBlue);
            spark5.Interior = new SolidColorBrush(Colors.DarkBlue);
            spark6.Interior = new SolidColorBrush(Colors.DarkBlue);
            spark7.Interior = new SolidColorBrush(Colors.DarkBlue);
            spark8.Interior = new SolidColorBrush(Colors.DarkBlue);
            spark9.Interior = new SolidColorBrush(Colors.DarkBlue);
            spark10.Interior = new SolidColorBrush(Colors.DarkBlue);
            spark11.Interior = new SolidColorBrush(Colors.DarkBlue);
            spark12.Interior = new SolidColorBrush(Colors.DarkBlue);
            spark13.Interior = new SolidColorBrush(Colors.DarkBlue);
            spark14.Interior = new SolidColorBrush(Colors.DarkBlue);
        }

        private void RibbonGalleryItem_Click_4(object sender, RoutedEventArgs e)
        {
            spark1.Interior = new SolidColorBrush(Colors.GreenYellow);
            spark2.Interior = new SolidColorBrush(Colors.GreenYellow);
            spark3.Interior = new SolidColorBrush(Colors.GreenYellow);
            spark4.Interior = new SolidColorBrush(Colors.GreenYellow);
            spark5.Interior = new SolidColorBrush(Colors.GreenYellow);
            spark6.Interior = new SolidColorBrush(Colors.GreenYellow);
            spark7.Interior = new SolidColorBrush(Colors.GreenYellow);
            spark8.Interior = new SolidColorBrush(Colors.GreenYellow);
            spark9.Interior = new SolidColorBrush(Colors.GreenYellow);
            spark10.Interior = new SolidColorBrush(Colors.GreenYellow);
            spark11.Interior = new SolidColorBrush(Colors.GreenYellow);
            spark12.Interior = new SolidColorBrush(Colors.GreenYellow);
            spark13.Interior = new SolidColorBrush(Colors.GreenYellow);
            spark14.Interior = new SolidColorBrush(Colors.GreenYellow);
        }

        private void RibbonGalleryItem_Click_5(object sender, RoutedEventArgs e)
        {
            spark1.Interior = new SolidColorBrush(Colors.Brown);
            spark2.Interior = new SolidColorBrush(Colors.Brown);
            spark3.Interior = new SolidColorBrush(Colors.Brown);
            spark4.Interior = new SolidColorBrush(Colors.Brown);
            spark5.Interior = new SolidColorBrush(Colors.Brown);
            spark6.Interior = new SolidColorBrush(Colors.Brown);
            spark7.Interior = new SolidColorBrush(Colors.Brown);
            spark8.Interior = new SolidColorBrush(Colors.Brown);
            spark9.Interior = new SolidColorBrush(Colors.Brown);
            spark10.Interior = new SolidColorBrush(Colors.Brown);
            spark11.Interior = new SolidColorBrush(Colors.Brown);
            spark12.Interior = new SolidColorBrush(Colors.Brown);
            spark13.Interior = new SolidColorBrush(Colors.Brown);
            spark14.Interior = new SolidColorBrush(Colors.Brown);
        }

        private void RibbonGalleryItem_Click_6(object sender, RoutedEventArgs e)
        {
            spark1.Interior = new SolidColorBrush(Colors.LightBlue);
            spark2.Interior = new SolidColorBrush(Colors.LightBlue);
            spark3.Interior = new SolidColorBrush(Colors.LightBlue);
            spark4.Interior = new SolidColorBrush(Colors.LightBlue);
            spark5.Interior = new SolidColorBrush(Colors.LightBlue);
            spark6.Interior = new SolidColorBrush(Colors.LightBlue);
            spark7.Interior = new SolidColorBrush(Colors.LightBlue);
            spark8.Interior = new SolidColorBrush(Colors.LightBlue);
            spark9.Interior = new SolidColorBrush(Colors.LightBlue);
            spark10.Interior = new SolidColorBrush(Colors.LightBlue);
            spark11.Interior = new SolidColorBrush(Colors.LightBlue);
            spark12.Interior = new SolidColorBrush(Colors.LightBlue);
            spark13.Interior = new SolidColorBrush(Colors.LightBlue);
            spark14.Interior = new SolidColorBrush(Colors.LightBlue);
        }

        private void RibbonGalleryItem_Click_7(object sender, RoutedEventArgs e)
        {
            spark1.Interior = new SolidColorBrush(Colors.LightCoral);
            spark2.Interior = new SolidColorBrush(Colors.LightCoral);
            spark3.Interior = new SolidColorBrush(Colors.LightCoral);
            spark4.Interior = new SolidColorBrush(Colors.LightCoral);
            spark5.Interior = new SolidColorBrush(Colors.LightCoral);
            spark6.Interior = new SolidColorBrush(Colors.LightCoral);
            spark7.Interior = new SolidColorBrush(Colors.LightCoral);
            spark8.Interior = new SolidColorBrush(Colors.LightCoral);
            spark9.Interior = new SolidColorBrush(Colors.LightCoral);
            spark10.Interior = new SolidColorBrush(Colors.LightCoral);
            spark11.Interior = new SolidColorBrush(Colors.LightCoral);
            spark12.Interior = new SolidColorBrush(Colors.LightCoral);
            spark13.Interior = new SolidColorBrush(Colors.LightCoral);
            spark14.Interior = new SolidColorBrush(Colors.LightCoral);
        }

        private void RibbonGalleryItem_Click_8(object sender, RoutedEventArgs e)
        {
            spark1.Interior = new SolidColorBrush(Colors.LightGreen);
            spark2.Interior = new SolidColorBrush(Colors.LightGreen);
            spark3.Interior = new SolidColorBrush(Colors.LightGreen);
            spark4.Interior = new SolidColorBrush(Colors.LightGreen);
            spark5.Interior = new SolidColorBrush(Colors.LightGreen);
            spark6.Interior = new SolidColorBrush(Colors.LightGreen);
            spark7.Interior = new SolidColorBrush(Colors.LightGreen);
            spark8.Interior = new SolidColorBrush(Colors.LightGreen);
            spark9.Interior = new SolidColorBrush(Colors.LightGreen);
            spark10.Interior = new SolidColorBrush(Colors.LightGreen);
            spark11.Interior = new SolidColorBrush(Colors.LightGreen);
            spark12.Interior = new SolidColorBrush(Colors.LightGreen);
            spark13.Interior = new SolidColorBrush(Colors.LightGreen);
            spark14.Interior = new SolidColorBrush(Colors.LightGreen);
        }

        private void RibbonGalleryItem_Click_9(object sender, RoutedEventArgs e)
        {
            spark1.Interior = new SolidColorBrush(Colors.Violet);
            spark2.Interior = new SolidColorBrush(Colors.Violet);
            spark3.Interior = new SolidColorBrush(Colors.Violet);
            spark4.Interior = new SolidColorBrush(Colors.Violet);
            spark5.Interior = new SolidColorBrush(Colors.Violet);
            spark6.Interior = new SolidColorBrush(Colors.Violet);
            spark7.Interior = new SolidColorBrush(Colors.Violet);
            spark8.Interior = new SolidColorBrush(Colors.Violet);
            spark9.Interior = new SolidColorBrush(Colors.Violet);
            spark10.Interior = new SolidColorBrush(Colors.Violet);
            spark11.Interior = new SolidColorBrush(Colors.Violet);
            spark12.Interior = new SolidColorBrush(Colors.Violet);
            spark13.Interior = new SolidColorBrush(Colors.Violet);
            spark14.Interior = new SolidColorBrush(Colors.Violet);
        }



        

       
    }

    public class Data
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public class Model
    {
        public Model()
        {
            Collections = new DataCollection();
        }

        public DataCollection Collections
        { get; set; }
    }

    public class DataCollection : ObservableCollection<Data>
    {
        public DataCollection()
        {
            Random r1 = new Random();
            this.Add(new Data() { X = 0, Y = 4, Y1 = 2, Y2 = 0, Y3 = -1 });
            this.Add(new Data() { X = 0, Y = -5, Y1 = 4, Y2 = 1, Y3 = -2 });
            this.Add(new Data() { X = 0, Y = -7, Y1 = -4, Y2 = -1, Y3 = 0 });
            this.Add(new Data() { X = 0, Y = -10, Y1 = 0, Y2 = 1, Y3 = 1 });
            this.Add(new Data() { X = 0, Y = 10, Y1 = -2, Y2 = 0, Y3 = 0 });
            this.Add(new Data() { X = 0, Y = 8, Y1 = 1, Y2 = 1, Y3 = 2 });
            this.Add(new Data() { X = 0, Y = 4, Y1 = 3, Y2 = 10, Y3 = 10 });
            this.Add(new Data() { X = 0, Y = 5, Y1 = 10, Y2 = 0, Y3 = 30 });
            this.Add(new Data() { X = 0, Y = 0, Y1 = 15, Y2 = -10, Y3 = 2 });
            this.Add(new Data() { X = 0, Y = -1, Y1 = 0, Y2 = 10, Y3 = 1 });

        }
    }

    
}
