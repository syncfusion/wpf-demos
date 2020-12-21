#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.expenseanalysis.wpf
{
    public class ChartViewBehavior : Behavior<ChartView>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += ChartView_Loaded;            
            base.OnAttached();
        }        

        private void ChartView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.Chart.SelectionChanged += Chart_SelectionChanged;
            (this.AssociatedObject.DataContext as ViewModel).PropertyChanged += ChartView_PropertyChanged;
        }

        private void ChartView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("PieExpense"))
            {
                this.AssociatedObject.Chart.Series[0].ItemsSource = (sender as ViewModel).PieExpense;
                (this.AssociatedObject.DataContext as ViewModel).BackButtonVisibility = Visibility.Hidden;
            }
        }

        private void Chart_SelectionChanged(object sender, Syncfusion.UI.Xaml.Charts.ChartSelectionChangedEventArgs e)
        {
            if (e.SelectedSegment == null)
                return;

            ViewModel viewModel = (sender as SfChart).Series[0].DataContext as ViewModel;
            string Category = (e.SelectedSegment.Item as CompanyExpense).Category; 

            if (Category == "Home")
            {
                (sender as SfChart).Series[0].ItemsSource = (e.SelectedSeries.DataContext as ViewModel).Home;
                viewModel.PieConverter = viewModel.Home;
            }
            else if (Category == "Daily Living")
            {
                (sender as SfChart).Series[0].ItemsSource = (e.SelectedSeries.DataContext as ViewModel).DailyLiving;
                viewModel.PieConverter = viewModel.DailyLiving;
            }
            else if (Category == "Entertainment")
            {
                (sender as SfChart).Series[0].ItemsSource = (e.SelectedSeries.DataContext as ViewModel).Entertainment;
                viewModel.PieConverter = viewModel.Entertainment;
            }
            else if (Category == "Health")
            {
                (sender as SfChart).Series[0].ItemsSource = (e.SelectedSeries.DataContext as ViewModel).Health;
                viewModel.PieConverter = viewModel.Health;
            }
            else if (Category == "Transportation")
            {
                (sender as SfChart).Series[0].ItemsSource = (e.SelectedSeries.DataContext as ViewModel).Transportation;
                viewModel.PieConverter = viewModel.Transportation;
            }
            else if (Category == "Personal")
            {
                (sender as SfChart).Series[0].ItemsSource = (e.SelectedSeries.DataContext as ViewModel).Personal;
                viewModel.PieConverter = viewModel.Personal;
            }
            (this.AssociatedObject.DataContext as ViewModel).BackButtonVisibility = Visibility.Visible;
        }

        protected override void OnDetaching()
        {
            if (this.AssociatedObject != null)
            {
                this.AssociatedObject.Loaded -= ChartView_Loaded;
                (this.AssociatedObject.DataContext as ViewModel).PropertyChanged -= ChartView_PropertyChanged;

                if (this.AssociatedObject.Chart != null)
                    this.AssociatedObject.Chart.SelectionChanged -= Chart_SelectionChanged;
            }
            base.OnDetaching();
        }
    }
}
