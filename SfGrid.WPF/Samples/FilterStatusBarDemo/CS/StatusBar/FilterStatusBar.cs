#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StatusBar
{
    /// <summary>    
    /// This is a control which helps to Display the FilterStatusBar to the SfDataGrid.
    /// </summary>
    [TemplatePart(Name = "PART_ToolTip", Type = typeof(ToolTip))]
    [TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_TextBlock", Type = typeof(TextBlock))]
    public class FilterStatusBar : Control
    {
        #region Field

        private Button ClearFilterButton;
        private ToolTip Tooltip;
        private TextBlock Textblock;
        private bool isdisposed = false;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the type of SfDataGrid binding with FilterStatusBar.
        /// </summary>     
        public SfDataGrid DataGrid
        {
            get { return (SfDataGrid)GetValue(DataGridProperty); }
            set { SetValue(DataGridProperty, value); }
        }

        /// <summary>
        /// Identifies the Syncfusion.UI.Xaml.Grid.FilterStatusBar.DataGrid dependency property.
        /// </summary>
        /// <remarks>
        /// The identifier for the Syncfusion.UI.Xaml.Grid.FilterStatusBar.DataGrid dependency property.
        /// </remarks>

        public static readonly DependencyProperty DataGridProperty =
            DependencyProperty.Register("DataGrid", typeof(SfDataGrid), typeof(FilterStatusBar), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the string that is used to displayed on the FilterStatusBar in SfDataGrid.
        /// </summary>
        /// <value>
        /// The string that is used to display on the FilterStatusBar.
        /// </value>      
        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            private set { SetValue(FilterTextProperty, value); }
        }

        /// <summary>
        /// Identifies the Syncfusion.UI.Xaml.Grid.FilterStatusBar.FilterText dependency property.
        /// </summary>
        /// <remarks>
        /// The identifier for the Syncfusion.UI.Xaml.Grid.FilterStatusBar.FilterText dependency property.
        /// </remarks>

        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(FilterStatusBar), new PropertyMetadata(null));

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes the <see cref="FilterStatusBar"/> class.
        /// </summary>
        public FilterStatusBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FilterStatusBar), new FrameworkPropertyMetadata(typeof(FilterStatusBar)));          
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="FilterStatusBar"/> class.
        /// </summary>
        /// <param name="datagrid"></param>
        public FilterStatusBar(SfDataGrid datagrid)
        {
            DataGrid = datagrid;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Builds the visual tree for the FilterStatusBar when a new template is applied.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.UpdateFilterStatusBarVisibility(false);
            ClearFilterButton = this.GetTemplateChild("PART_CloseButton") as Button;
            Textblock = this.GetTemplateChild("PART_TextBlock") as TextBlock;
            Tooltip = this.GetTemplateChild("PART_ToolTip") as ToolTip;
            this.UnWireEvents();
            this.WireEvents();
        }

        /// <summary>
        /// Occurs when FilterStatusBar loaded.
        /// </summary>
        /// <param name="sender">FilterStatusBar</param>
        /// <param name="e">RoutedEventArgs</param>
        private void OnFilterStatusBarLoaded(object sender, RoutedEventArgs e)
        {
            DataGrid.FilterChanged += OnDataGridFilterChanged;
        }
        
        /// <summary>
        /// Occurs after the column is filtered in SfDataGrid. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnDataGridFilterChanged(object sender, GridFilterEventArgs e)
        {
            string filters = "";            
            foreach (var item in this.DataGrid.Columns)
            {
                if (item != null && item.FilterPredicates.Count > 0)
                {
                    foreach (var filterItem in item.FilterPredicates)
                    {
                        if (filters == "")
                            filters += GetFilterInfo(filterItem, item);
                        else
                            filters += " " + this.GetPredicateType(filterItem.PredicateType) + " " + GetFilterInfo(filterItem, item);
                    }
                }
            }
            UpdateFilterText(filters);
            this.UpdateFilterStatusBarVisibility(filters.Trim() != "");
        }
	   
        /// <summary>
        /// Gets the Filter information from the specified filter predicates of the particular column.
        /// </summary>
        /// <param name="filter">The corresponding filterpredicates value.</param>
        /// <param name="visColumn">The corresponding filtered column </param>
        /// <returns>Returns the Filter information from the specified column.</returns>
        protected virtual string GetFilterInfo(FilterPredicate filter, GridColumn visColumn)
        {
            string filtervalue = (filter.FilterValue != null) ? filter.FilterValue.ToString() : null;                      
            FilterType filterType = filter.FilterType;
            string colname = "";
                        
            if (filtervalue != null)
            {
                if (visColumn.CellType == "DateTime")
                    filtervalue = this.DateTimeFormatString(visColumn as GridDateTimeColumn, Convert.ToDateTime(filtervalue));
                else if (visColumn.CellType == "Currency")
                    filtervalue = "$" + (String.Format("{0:0.00}",Convert.ToDecimal(filtervalue)));                
                else if (visColumn.CellType == "Percent")
                    filtervalue += "%";
            }

            if(visColumn != null)            
                colname = (visColumn.HeaderText != "") ? visColumn.HeaderText : (visColumn.MappingName != "" ? visColumn.MappingName : "");            
            switch (filterType)
            {
                case FilterType.LessThan:
                    return "[" + colname + "]" + " < '" + filtervalue + "'";
                case FilterType.LessThanOrEqual:
                    return "[" + colname + "]" + " <= '" + filtervalue + "'";
                case FilterType.Equals:
                    if (filtervalue == "")
                        return "[" + colname + "]" + " == Empty";
                    if (filtervalue != null)
                        return "[" + colname + "]" + " == '" + filtervalue + "'";
                    return "[" + colname + "]" + " = Null";
                case FilterType.NotEquals:
                    if (filtervalue == "")
                        return "[" + colname + "]" + " != Empty";
                    if (filtervalue != null)
                        return "[" + colname + "]" + " != '" + filtervalue + "'";
                    return "[" + colname + "]" + " != Null";
                case FilterType.GreaterThanOrEqual:
                    return "[" + colname + "]" + " >= '" + filtervalue + "'";
                case FilterType.GreaterThan:
                    return "[" + colname + "]" + " > '" + filtervalue + "'";
                case FilterType.EndsWith:
                    return "[" + colname + "]" + " Ends with '" + filtervalue + "'";
                case FilterType.StartsWith:
                    return "[" + colname + "]" + " Begins with '" + filtervalue + "'";
                case FilterType.Contains:
                    return "[" + colname + "]" + " Contains '" + filtervalue + "'";
                default:
                    return "[" + colname + "]" + " '" + filtervalue + "'";
            }
        }

        /// <summary>        
        /// Gets the formatted string for the specified filter value.
        /// </summary>
        /// <param name="column">The corresponding GridDateTimeColumn</param>
        /// <param name="columnValue">The corresponding GridDateTimeColumn's filter value</param>
        /// <returns>Returns formatted filter value filter value.</returns>
        private string DateTimeFormatString(GridDateTimeColumn column, DateTime columnValue)
        {
            switch (column.Pattern)
            {
                case DateTimePattern.ShortDate:
                    return columnValue.ToString("d", column.DateTimeFormat);
                case DateTimePattern.LongDate:
                    return columnValue.ToString("D", column.DateTimeFormat);
                case DateTimePattern.LongTime:
                    return columnValue.ToString("T", column.DateTimeFormat);
                case DateTimePattern.ShortTime:
                    return columnValue.ToString("t", column.DateTimeFormat);
                case DateTimePattern.FullDateTime:
                    return columnValue.ToString("F", column.DateTimeFormat);
                case DateTimePattern.RFC1123:
                    return columnValue.ToString("R", column.DateTimeFormat);
                case DateTimePattern.SortableDateTime:
                    return columnValue.ToString("s", column.DateTimeFormat);
                case DateTimePattern.UniversalSortableDateTime:
                    return columnValue.ToString("u", column.DateTimeFormat);
                case DateTimePattern.YearMonth:
                    return columnValue.ToString("Y", column.DateTimeFormat);
                case DateTimePattern.MonthDay:
                    return columnValue.ToString("M", column.DateTimeFormat);
                case DateTimePattern.CustomPattern:
                    return columnValue.ToString(column.CustomPattern, column.DateTimeFormat);
                default:
                    return columnValue.ToString("MMMM", column.DateTimeFormat);
            }
        }

        ///<summary>
        ///Get the PredicateType based on the FilterPredicates.         
        ///</summary>
        ///<returns>
        ///Return the PredicateType as symbol based on FilterPredicates.
        ///</returns>
        private string GetPredicateType(PredicateType predicate)
        {
            if (predicate == PredicateType.And || predicate == PredicateType.AndAlso)
                return "&&";
            else
                return "||";
        }

        /// <summary>
        /// Methed to Update the FilterText value.
        /// </summary>
        /// <param name="filter">The corresponding filtervalue.</param>
        /// <returns>Return the FilterStatusBar information from filtervalue.</returns>
        private string UpdateFilterText(string filter)
        {
            return this.FilterText = filter;
        }

        /// <summary>
        /// Method to Display the FilterStatusBar.
        /// </summary>
        /// <param name="visible">Indicates whether the filter value is available or not</param>
        private void UpdateFilterStatusBarVisibility(bool visible)
        {
            if (visible)
                this.Visibility = Visibility.Visible;
            else
                this.Visibility = Visibility.Collapsed;
        }      
       
        /// <summary>
        /// Method to Update the ToolTip visible if the TextBlock content is trimmed
        /// </summary>
        /// <param name="sender">ToolTip</param>
        /// <param name="e">ToolTipEventArgs</param>
        private void OnTextBlockToolTipOpening(object sender, ToolTipEventArgs e)
        {
            var textblock = sender as TextBlock;

            if (textblock.Text == null)
                Tooltip.Visibility = Visibility.Collapsed;

            FrameworkElement textBlock = (FrameworkElement)textblock;

            textBlock.Measure(new System.Windows.Size(Double.PositiveInfinity, Double.PositiveInfinity));

            if (((FrameworkElement)textblock).ActualWidth < ((FrameworkElement)textblock).DesiredSize.Width)
                Tooltip.Visibility = Visibility.Visible;
            else
                Tooltip.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Clear Filtering for SfDataGrid        
        /// </summary>
        /// <param name="sender">ClearFilterButton</param>
        /// <param name="e">RoutedEventArgs</param>
        private void OnClearFilterButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectionController.CurrentCellManager.HasCurrentCell)
                DataGrid.SelectionController.CurrentCellManager.EndEdit();
            DataGrid.ClearFilters();
        }

        /// <summary>
        /// Disposes all the resources used by the FilterStatusBar class.
        /// </summary>   
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all the resources by the FilterStatusBar class.
        /// </summary>
        /// <param name="isDisposing">Indicates whether the call is from Dispose method or from a finalizer.</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (isdisposed) return;

            UnWireEvents();
            if (isDisposing)
            {
                this.DataGrid = null;
            }

            isdisposed = true;
        }

        #endregion

        #region Events

        /// <summary>
        /// Wires the events associated with the FilterStatusBar.
        /// </summary>
        private void WireEvents()
        {           
            this.Loaded += OnFilterStatusBarLoaded;
            ClearFilterButton.Click += OnClearFilterButtonClick;
            Textblock.ToolTipOpening += OnTextBlockToolTipOpening;
        }

        /// <summary>
        /// UnWires the events associated with the FilterStatusBar.
        /// </summary>
        private void UnWireEvents()
        {
            if (DataGrid != null)
                DataGrid.FilterChanged -= OnDataGridFilterChanged;
            ClearFilterButton.Click -= OnClearFilterButtonClick;
            Textblock.ToolTipOpening -= OnTextBlockToolTipOpening;
        }

        #endregion
    }
}
