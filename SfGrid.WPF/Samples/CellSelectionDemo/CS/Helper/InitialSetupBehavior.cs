#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace CellSelectionDemo
{
    public class InitialSetupBehaviour: Behavior<MainWindow>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += MainWindow_Loaded;
        }

        public double AverageValue
        {
            get { return (double)GetValue(AverageValueProperty); }
            set { SetValue(AverageValueProperty, value); }
        }

        public static readonly DependencyProperty AverageValueProperty =
            DependencyProperty.Register("AverageValue", typeof(double), typeof(InitialSetupBehaviour), new PropertyMetadata(0.0d));



        public int CellsCount
        {
            get { return (int)GetValue(CellsCountProperty); }
            set { SetValue(CellsCountProperty, value); }
        }

        public static readonly DependencyProperty CellsCountProperty =
            DependencyProperty.Register("CellsCount", typeof(int), typeof(InitialSetupBehaviour), new PropertyMetadata(0));



        public int CellsNumCount
        {
            get { return (int)GetValue(CellNumCountProperty); }
            set { SetValue(CellNumCountProperty, value); }
        }

        public static readonly DependencyProperty CellNumCountProperty =
            DependencyProperty.Register("CellsNumCount", typeof(int), typeof(InitialSetupBehaviour), new PropertyMetadata(0));



        public double MinimumValue
        {
            get { return (double)GetValue(MinimumValueProperty); }
            set { SetValue(MinimumValueProperty, value); }
        }
        
        public static readonly DependencyProperty MinimumValueProperty =
            DependencyProperty.Register("MinimumValue", typeof(double), typeof(InitialSetupBehaviour), new PropertyMetadata(0.0d));



        public double MaximumValue
        {
            get { return (double)GetValue(MaximumValueProperty); }
            set { SetValue(MaximumValueProperty, value); }
        }

        public static readonly DependencyProperty MaximumValueProperty =
            DependencyProperty.Register("MaximumValue", typeof(double), typeof(InitialSetupBehaviour), new PropertyMetadata(0.0d));



        public double SumValue
        {
            get { return (double)GetValue(SumValueProperty); }
            set { SetValue(SumValueProperty, value); }
        }

        public static readonly DependencyProperty SumValueProperty =
            DependencyProperty.Register("SumValue", typeof(double), typeof(InitialSetupBehaviour), new PropertyMetadata(0.0d));

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.dataGrid.SelectionChanged += DataGrid_SelectionChanged;
            this.AssociatedObject.cmbSelectionMode.SelectionChanged += ComboBox_SelectionChanged;
            (this.AssociatedObject.dataGrid.SelectionController as CellSelectionController).FilterApplied += DataGrid_FilterApplied;
        }

        void DataGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            this.UpdateStatusBar();
        }

        void DataGrid_FilterApplied()
        {
            this.UpdateStatusBar();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.UpdateStatusBar();
        }

        public void UpdateStatusBar()
        {
            var SelectedCells = this.AssociatedObject.dataGrid.GetSelectedCells();
            var propertyCollection = this.AssociatedObject.dataGrid.View.GetPropertyAccessProvider();
            if (SelectedCells.Count > 0)
            {
                double sumValue = 0;
                int numCount = 0;
                List<double> cellValue = new List<double>();
                SelectedCells.ForEach(cellInfo =>
                {
                    if (cellInfo.IsDataRowCell)
                    {
                        var value = propertyCollection.GetValue(cellInfo.RowData, cellInfo.Column.MappingName);
                        if (value is double)
                        {
                            cellValue.Add((double)value);
                            sumValue += (double)value;
                            this.CellsNumCount = ++numCount;
                        }
                    }
                });
                if (numCount != 0)
                {
                    this.SumValue = sumValue;
                    this.AverageValue = Math.Round(this.SumValue / numCount, 2);
                    this.MinimumValue = cellValue.Min();
                    this.MaximumValue = cellValue.Max();
                }
                else
                {
                    this.Reset();
                }
                this.CellsCount = SelectedCells.Count;
            }
            else
            {
                this.Reset();
            }
        }

        private void Reset()
        {
            this.MinimumValue = 0;
            this.MaximumValue = 0;
            this.SumValue = 0;
            this.AverageValue = 0;
            this.CellsNumCount = 0;
            this.CellsCount = 0;
        }
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= MainWindow_Loaded;
            this.AssociatedObject.dataGrid.SelectionChanged -= DataGrid_SelectionChanged;
            this.AssociatedObject.cmbSelectionMode.SelectionChanged -= ComboBox_SelectionChanged;
            (this.AssociatedObject.dataGrid.SelectionController as CellSelectionController).FilterApplied -= DataGrid_FilterApplied;
        }
    }

    public class CellSelectionController : GridCellSelectionController
    {
        public event GridFilterAppliedEventHandler FilterApplied;
        public delegate void GridFilterAppliedEventHandler(); 

        public CellSelectionController(SfDataGrid dataGrid)
            : base(dataGrid)
        {
        }

        protected override void ProcessOnFilterApplied(GridFilteringEventArgs args)
        {
            base.ProcessOnFilterApplied(args);
            this.RaiseFilterApplied();
        }

        private void RaiseFilterApplied()
        {
            if (FilterApplied != null)
                this.FilterApplied();
        }
    }
}
