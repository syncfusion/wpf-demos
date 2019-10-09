#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace UnBoundRowDemo
{    
    public class UnBoundRowBehavior : Behavior<ChromelessWindow>
    {
        SfDataGrid SfDataGrid;

        // totalSales used to store sumamry of each column.
        Dictionary<string, double> totalSales;
        // totalSelectedSales used to store selected rows.
        Dictionary<string, double> totalSelectedSales;
        // percentSales used to store percentage of selected Rows summary.
        Dictionary<string, double> percentSales;
     
        protected override void OnAttached()
        {
            base.OnAttached();
            var window = this.AssociatedObject;
            this.SfDataGrid = window.FindName("sfDataGrid") as SfDataGrid;
            
            totalSales = new Dictionary<string, double>();
            totalSelectedSales = new Dictionary<string, double>();
            percentSales = new Dictionary<string, double>();
            
            // Hooks event here.
            this.SfDataGrid.Loaded += SfDataGrid_Loaded;            
            this.SfDataGrid.QueryRowHeight += SfDataGrid_QueryRowHeight;
            this.SfDataGrid.QueryUnBoundRow += SfDataGrid_QueryUnBoundRow;
            this.SfDataGrid.SelectionChanged += SfDataGrid_SelectionChanged;
            this.SfDataGrid.CurrentCellEndEdit += SfDataGrid_CurrentCellEndEdit;            
        }

        void SfDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // populate the totalSales by summary value.
            foreach (GridColumn column in this.SfDataGrid.Columns)
                totalSales[column.MappingName] = GetSummaryValue(column.MappingName);

            // populate the percentSales by default value fro QS1 column alone.
            foreach (GridColumn column in this.SfDataGrid.Columns)
                percentSales[column.MappingName] = column.MappingName.Equals("QS1") ? 2.25: 0;

            // Refresh the UnboundRows.
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[0]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[1]);    
            this.SfDataGrid.GetVisualContainer().InvalidateMeasureInfo();

            // Add selecetd items to SfDataGrid.
            var collection = this.SfDataGrid.DataContext as SalesInfoViewModel;
            foreach (SalesByYear sales in collection.YearlySalesDetails.Skip(3).Take(3))
                this.SfDataGrid.SelectedItems.Add(sales);            
        }
        
        void SfDataGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {           
            // Populate selected rows summary values.
            foreach (GridColumn column in this.SfDataGrid.Columns)
                totalSelectedSales[column.MappingName] = GetSummaryValue(column.MappingName,false);

            // Refresh the UnBound rows.
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[1]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[2]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[3]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[4]);
            this.SfDataGrid.GetVisualContainer().InvalidateMeasureInfo();
        }

        void SfDataGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs args)
        {                      
            // Updates the totals with edited values.
            foreach (GridColumn column in this.SfDataGrid.Columns)
                totalSales[column.MappingName] = GetSummaryValue(column.MappingName);

            foreach (GridColumn column in this.SfDataGrid.Columns)
                totalSelectedSales[column.MappingName] = GetSummaryValue(column.MappingName,false);

            // Refresh unboudnRow after complete editing.

            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[0]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[1]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[2]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[3]);
            this.SfDataGrid.InValidateUnBoundRow(this.SfDataGrid.UnBoundRows[4]);  
            this.SfDataGrid.GetVisualContainer().InvalidateMeasureInfo();
        }

        // which customize the UnBoundRow values.
        void SfDataGrid_QueryUnBoundRow(object sender, GridUnBoundRowEventsArgs e)
        {
            if (!(totalSales.ContainsKey(e.Column.MappingName)))
                return;

            if (e.UnBoundAction == UnBoundActions.QueryData)
            {
                if (e.RowColumnIndex.RowIndex == 1)
                {
                    if (e.RowColumnIndex.ColumnIndex == 0)
                    {
                        e.Value = "Total Sales By Month";
                        e.CellTemplate = App.Current.Resources["UnBoundCellTemplate"] as DataTemplate;
                    }
                    else
                    {                       
                        e.Value = totalSales[e.Column.MappingName];
                        e.CellTemplate = App.Current.Resources["UnBoundRowCellTemplate"] as DataTemplate;
                    }
                }
                else if (e.GridUnboundRow.UnBoundRowIndex == 0 && e.GridUnboundRow.Position == UnBoundRowsPosition.Bottom && e.GridUnboundRow.ShowBelowSummary == true )
                {                
                    if (e.RowColumnIndex.ColumnIndex == 0)
                    {
                        e.Value = "Percent of Selected Rows";
                        e.CellTemplate = App.Current.Resources["UnBoundCellTemplate"] as DataTemplate;
                    }
                    else
                    {
                        if (!(totalSelectedSales.ContainsKey(e.Column.MappingName)))
                            return; 

                        e.Value =  totalSelectedSales[e.Column.MappingName] *(percentSales[e.Column.MappingName]/100);
                        e.CellTemplate = App.Current.Resources["UnBoundRowCellTemplate"] as DataTemplate;      
                    }
                }
                else if (e.GridUnboundRow.UnBoundRowIndex == 1 && e.GridUnboundRow.Position == UnBoundRowsPosition.Bottom && e.GridUnboundRow.ShowBelowSummary == true )
                {                    
                    if (e.RowColumnIndex.ColumnIndex == 0)
                    {
                        e.Value = "Summary of Selected Rows";
                        e.CellTemplate = App.Current.Resources["UnBoundCellTemplate"] as DataTemplate;
                    }
                    else
                    {
                        if (!(totalSelectedSales.ContainsKey(e.Column.MappingName)))
                            return; 

                        e.Value = totalSelectedSales[e.Column.MappingName];
                        e.CellTemplate = App.Current.Resources["UnBoundRowCellTemplate"] as DataTemplate;                      
                    }                    
                }

                else if (e.GridUnboundRow.UnBoundRowIndex == 2 && e.GridUnboundRow.Position == UnBoundRowsPosition.Bottom && e.GridUnboundRow.ShowBelowSummary == true)
                {                   
                    int count = this.SfDataGrid.SelectedItems.Count;
                    if (e.RowColumnIndex.ColumnIndex == 0)
                    {
                        e.Value = "Average of Selected Rows";
                        e.CellTemplate = App.Current.Resources["UnBoundCellTemplate"] as DataTemplate;                        
                    }
                    else
                    {
                        if (!(totalSelectedSales.ContainsKey(e.Column.MappingName)))
                            return; 

                        e.Value = (totalSelectedSales[e.Column.MappingName] / count);
                        e.Value = double.IsNaN((double)e.Value) ? 0.0 : e.Value;
                        e.CellTemplate = App.Current.Resources["UnBoundRowCellTemplate"] as DataTemplate;

                        if (e.RowColumnIndex.ColumnIndex > 7)
                            e.CellTemplate = null;
                    }                   
                }
                else if (e.GridUnboundRow.Position == UnBoundRowsPosition.Bottom && e.GridUnboundRow.ShowBelowSummary == false)
                {
                    if (e.RowColumnIndex.ColumnIndex == 0)
                    {
                        e.Value = "Edit the Row to get the Percent of Selected Rows Summary";
                    }
                    else
                    {
                        e.Value = percentSales[e.Column.MappingName];
                        e.EditTemplate = App.Current.Resources["UnBoundRowEditTemplate"] as DataTemplate;
                        e.CellTemplate = App.Current.Resources["UnBoundRowCellPercentTemplate"] as DataTemplate;   
                    }
                }
                e.Handled = true;
            }
            else if(e.UnBoundAction == UnBoundActions.CommitData)
            {               
                    if (e.Value.ToString().Equals(string.Empty))
                        return;
                    double data;             
                 foreach(char character in e.Value.ToString().ToCharArray())
                    if(char.IsLetter(character))
                        return;

                    if (e.Value.ToString().Contains("$"))
                        data = Convert.ToDouble(e.Value.ToString().Substring(1, e.Value.ToString().Length - 1));
                    else
                        data = Convert.ToDouble(e.Value);
                    var value = Convert.ToDouble(data);
                    percentSales[e.Column.MappingName] = value;
                    e.CellTemplate = App.Current.Resources["UnBoundRowCellTemplate"] as DataTemplate;                                   
            }
        }

        void SfDataGrid_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                e.Height = 30;
                e.Handled = true;
            }
            // Which customize the height of UnBoundRow.
            else if (this.SfDataGrid.IsUnBoundRow(e.RowIndex) )
            {                                           
                e.Height = 40;
                e.Handled = true;                
            }            
            else
            {
                e.Height = this.SfDataGrid.RowHeight;
                e.Handled = true;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            // Un Hooks the event.
            this.SfDataGrid.Loaded -= SfDataGrid_Loaded;
            this.SfDataGrid.CurrentCellEndEdit -= SfDataGrid_CurrentCellEndEdit;
            this.SfDataGrid.QueryRowHeight -= SfDataGrid_QueryRowHeight;
            this.SfDataGrid.QueryUnBoundRow -= SfDataGrid_QueryUnBoundRow;
        }

        // Calculates summary value based on column names.
        double GetSummaryValue(string column,bool totalSummary = true)
        {
            double summary = 0.0;
            var view = this.SfDataGrid.View;            
            if (this.SfDataGrid.SelectedItems.Count != 0 && !totalSummary)
            {
                foreach(var data in this.SfDataGrid.SelectedItems)
                {
                    if (column.Equals("QS1"))
                        summary += (data as SalesByYear).QS1;
                    else if (column.Equals("QS2"))
                        summary += (data as SalesByYear).QS2;
                    else if (column.Equals("QS3"))
                        summary += (data as SalesByYear).QS3;
                    else if (column.Equals("QS4"))
                        summary += (data as SalesByYear).QS4;
                    else if (column.Equals("Total"))
                        summary += (data as SalesByYear).Total;
                }                    
            }
            else if(totalSummary)
            {
                foreach (var data in view.Records)
                {
                    if (column.Equals("QS1"))
                        summary += ((data as RecordEntry).Data as SalesByYear).QS1;
                    else if (column.Equals("QS2"))
                        summary += ((data as RecordEntry).Data as SalesByYear).QS2;
                    else if (column.Equals("QS3"))
                        summary += ((data as RecordEntry).Data as SalesByYear).QS3;
                    else if (column.Equals("QS4"))
                        summary += ((data as RecordEntry).Data as SalesByYear).QS4;
                    else if (column.Equals("Total"))
                        summary += ((data as RecordEntry).Data as SalesByYear).Total;
                }
            }
            return summary;
        }
    }
}
