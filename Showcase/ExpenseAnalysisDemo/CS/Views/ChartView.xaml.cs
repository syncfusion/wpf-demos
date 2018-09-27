using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace ExpenseAnalysisDemo
{
    /// <summary>
    /// Interaction logic for ChartView.xaml
    /// </summary>
    public partial class ChartView : UserControl
    {
        public ChartView()
        {
            InitializeComponent();
            this.Loaded += ChartView_Loaded;
        }

        void ChartView_Loaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ViewModel).PropertyChanged += ChartView_PropertyChanged;
        }

        void ChartView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("PieExpense"))
            {
                Chart.Series[0].ItemsSource = (sender as ViewModel).PieExpense;
                this.backbtn.Visibility = Visibility.Hidden;
            }
        }

        private void SfChart_SelectionChanged_1(object sender, ChartSelectionChangedEventArgs e)
        {
            ViewModel view = (sender as SfChart).Series[0].DataContext as ViewModel;
            if (e.SelectedSegment == null)
                return;
            if((e.SelectedSegment.Item as CompanyExpense).Category=="Home")
            {
                (sender as SfChart).Series[0].ItemsSource = (e.SelectedSeries.DataContext as ViewModel).Home;                
                view.PieConverter = view.Home;
            }
            else if ((e.SelectedSegment.Item as CompanyExpense).Category == "Daily Living")
            {
                (sender as SfChart).Series[0].ItemsSource = (e.SelectedSeries.DataContext as ViewModel).DailyLiving;
                view.PieConverter = view.DailyLiving;
            }
            else if ((e.SelectedSegment.Item as CompanyExpense).Category == "Entertainment")
            {
                (sender as SfChart).Series[0].ItemsSource = (e.SelectedSeries.DataContext as ViewModel).Entertainment;
                view.PieConverter = view.Entertainment;
            }
            else if ((e.SelectedSegment.Item as CompanyExpense).Category == "Health")
            {
                (sender as SfChart).Series[0].ItemsSource = (e.SelectedSeries.DataContext as ViewModel).Health;
                view.PieConverter = view.Health;
            }
            else if ((e.SelectedSegment.Item as CompanyExpense).Category == "Transportation")
            {
                (sender as SfChart).Series[0].ItemsSource = (e.SelectedSeries.DataContext as ViewModel).Transportation;
                view.PieConverter = view.Transportation;
            }
            else if ((e.SelectedSegment.Item as CompanyExpense).Category == "Personal")
            {
                (sender as SfChart).Series[0].ItemsSource = (e.SelectedSeries.DataContext as ViewModel).Personal;
                view.PieConverter = view.Personal;
            }
            this.backbtn.Visibility = System.Windows.Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewModel view = Chart.Series[0].DataContext as ViewModel;
            view.PieConverter = new List<CompanyExpense>();
            view.PieConverter = view.PieExpense;
            Chart.Series[0].ItemsSource = (Chart.Series[0].DataContext as ViewModel).PieExpense;
            this.backbtn.Visibility = System.Windows.Visibility.Hidden;
        }
    }

    public class ColorConverter: IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                ChartPieAdornment pieAdornment = value as ChartPieAdornment;
                int index = pieAdornment.Series.Adornments.IndexOf(pieAdornment);
                return pieAdornment.Series.ColorModel.GetMetroBrushes()[index];
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ChartPieAdornment pieAdornment = value as ChartPieAdornment;
            int index = pieAdornment.Series.Adornments.IndexOf(pieAdornment);
            ViewModel view = pieAdornment.Series.DataContext as ViewModel;
            return (string)view.PieConverter[index].Category + " $" + view.PieConverter[index].Amount;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
