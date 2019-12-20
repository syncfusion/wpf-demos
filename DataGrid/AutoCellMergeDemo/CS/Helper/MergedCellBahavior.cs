#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Threading.Tasks;
using System.Windows.Interactivity;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System.ComponentModel;
using System.Reflection;
using Syncfusion.Data;


namespace AutoCellMergeDemo
{
    public class MergedCellBahavior: Behavior<SfDataGrid> 
    {
        /// <summary>
        /// DataGrid defined thats defined in xaml.
        /// </summary>
        SfDataGrid dataGrid = null;

        /// <summary>
        /// to get the particular column data from a record.
        /// </summary>
        IPropertyAccessProvider reflector = null;

        /// <summary>
        /// to remove the conflict range once teh given range has been edited.
        /// </summary>
        bool isEditted = false;

        /// <summary>
        /// To enusre teh current cell value has been changed.
        /// </summary>
        bool isCurrentCellValueChanged = false;

        /// <summary>
        /// Attaching event for SfDataGrid.
        /// </summary>
        protected override void OnAttached()
        {
            dataGrid = this.AssociatedObject as SfDataGrid;
            dataGrid.AutoGeneratingColumn += dataGrid_AutoGeneratingColumn;
            dataGrid.QueryCoveredRange += dataGrid_QueryCoveredRange;
            dataGrid.CurrentCellEndEdit += dataGrid_CurrentCellEndEdit;
            dataGrid.ItemsSourceChanged += dataGrid_ItemsSourceChanged;
            dataGrid.CurrentCellValueChanged += dataGrid_CurrentCellValueChanged;
        }

        /// <summary>
        /// Methdo to handle current cell value changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void dataGrid_CurrentCellValueChanged(object sender, CurrentCellValueChangedEventArgs args)
        {
            isCurrentCellValueChanged = true;
        }

        /// <summary>
        /// Method that handles ItemsSourceChanged event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dataGrid_ItemsSourceChanged(object sender, GridItemsSourceChangedEventArgs e)
        {
            if (dataGrid.View != null)
                reflector = dataGrid.View.GetPropertyAccessProvider();
            else
                reflector = null;
        }

        /// <summary>
        /// Method that handles AutoGenerating column event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dataGrid_AutoGeneratingColumn(object sender, AutoGeneratingColumnArgs e)
        {
            if (e.Column.MappingName.Equals("DeliveryDelay"))
            {
                var column = new GridTimeSpanColumn();
                column.MappingName = e.Column.MappingName;
                e.Column = column;
            }
        }

        /// <summary>
        /// Method that handles teh end edit event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void dataGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs args)
        {
            if (!isCurrentCellValueChanged)
                return;

            var rowIndex = args.RowColumnIndex.RowIndex;
            var columnIndex = args.RowColumnIndex.ColumnIndex;

            var range = dataGrid.CoveredCells.GetCoveredCellInfo(rowIndex, columnIndex);
            dataGrid.RemoveRange(range);
            isEditted = true;
            dataGrid.GetVisualContainer().InvalidateMeasure();
        }

        /// <summary>
        /// Method that reruns coveredcellinfo based on same data.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <param name="rowData"></param>
        /// <returns></returns>
        private CoveredCellInfo GetRange(GridColumn column, int rowIndex, int columnIndex, object rowData)
        {
            var range = new CoveredCellInfo(columnIndex, columnIndex, rowIndex, rowIndex);
            object data = reflector.GetFormattedValue(rowData, column.MappingName);


            GridColumn leftColumn = null;
            GridColumn rightColumn = null;


            // total rows count.
            int recordsCount = this.dataGrid.GroupColumnDescriptions.Count != 0 ? (this.dataGrid.View.TopLevelGroup.DisplayElements.Count + this.dataGrid.TableSummaryRows.Count + this.dataGrid.UnBoundRows.Count + (this.dataGrid.AddNewRowPosition == AddNewRowPosition.Top ? +1 : 0)) : (this.dataGrid.View.Records.Count + this.dataGrid.TableSummaryRows.Count + this.dataGrid.UnBoundRows.Count + (this.dataGrid.AddNewRowPosition == AddNewRowPosition.Top ? +1 : 0));

            // Merge Horizontally
            // compare right column               
            for (int i = dataGrid.Columns.IndexOf(column); i < this.dataGrid.Columns.Count - 1; i++)
            {
                var compareData = reflector.GetFormattedValue(rowData, dataGrid.Columns[i + 1].MappingName);

                if (compareData == null)
                    break;

                if (!compareData.Equals(data))
                    break;
                rightColumn = dataGrid.Columns[i + 1];
            }

            // compare left column.
            for (int i = dataGrid.Columns.IndexOf(column); i > 0; i--)
            {
                var compareData = reflector.GetFormattedValue(rowData, dataGrid.Columns[i - 1].MappingName);

                if (compareData == null)
                    break;

                if (!compareData.Equals(data))
                    break;
                leftColumn = dataGrid.Columns[i - 1];
            }

            if (leftColumn != null || rightColumn != null)
            {
                // set left index
                if (leftColumn != null)
                {
                    var leftColumnIndex = this.dataGrid.ResolveToScrollColumnIndex(this.dataGrid.Columns.IndexOf(leftColumn));
                    range = new CoveredCellInfo(leftColumnIndex, range.Right, range.Top, range.Bottom);
                }

                // set right index
                if (rightColumn != null)
                {
                    var rightColumIndex = this.dataGrid.ResolveToScrollColumnIndex(this.dataGrid.Columns.IndexOf(rightColumn));
                    range = new CoveredCellInfo(range.Left, rightColumIndex, range.Top, range.Bottom);
                }
                return range;
            }

            // Merge Vertically from the row index.

            int previousRowIndex = -1;
            int nextRowIndex = -1;

            // Get previous row data.                
            var startIndex = dataGrid.ResolveStartIndexBasedOnPosition();
            for (int i = rowIndex - 1; i >= startIndex; i--)
            {
                var previousData = this.dataGrid.GetRecordEntryAtRowIndex(i);
                if (previousData == null || !previousData.IsRecords)
                    break;

                var compareData = reflector.GetFormattedValue((previousData as RecordEntry).Data, column.MappingName);

                if (compareData == null)
                    break;

                if (!compareData.Equals(data))
                    break;
                previousRowIndex = i;
            }

            // get next row data.
            for (int i = rowIndex + 1; i < recordsCount + 1; i++)
            {
                var nextData = this.dataGrid.GetRecordEntryAtRowIndex(i);
                if (nextData == null || !nextData.IsRecords)
                    break;

                var compareData = reflector.GetFormattedValue((nextData as RecordEntry).Data, column.MappingName);

                if (compareData == null)
                    break;

                if (!compareData.Equals(data))
                    break;
                nextRowIndex = i;
            }

            if (previousRowIndex != -1 || nextRowIndex != -1)
            {
                if (previousRowIndex != -1)
                    range = new CoveredCellInfo(range.Left, range.Right, previousRowIndex, range.Bottom);

                if (nextRowIndex != -1)
                    range = new CoveredCellInfo(range.Left, range.Right, range.Top, nextRowIndex);
                return range;
            }

            return null;
        }

        /// <summary>
        /// Method to hanlde the QueryCoveredRange event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dataGrid_QueryCoveredRange(object sender, GridQueryCoveredRangeEventArgs e)
        {
            // Merging cells for flat grid                      
            var range = GetRange(e.GridColumn, e.RowColumnIndex.RowIndex, e.RowColumnIndex.ColumnIndex, e.Record);

            if (range == null)
                return;

            // While editing we need to remove the range.
            if (this.dataGrid.CoveredCells.IsInRange(range))
            {
                CoveredCellInfo coveredCellInfo = this.dataGrid.GetConflictRange(range);

                while (coveredCellInfo != null)
                {
                    if (isEditted)
                    {
                        this.dataGrid.CoveredCells.Remove(coveredCellInfo);
                        coveredCellInfo = this.dataGrid.GetConflictRange(range);
                        if (coveredCellInfo == null)
                            isEditted = false;
                    }
                }
            }

            e.Range = range;
            e.Handled = true;
        }


        /// <summary>
        /// Detaching event for SfDataGrid.
        /// </summary>
        protected override void OnDetaching()
        {
            dataGrid.ItemsSourceChanged -= dataGrid_ItemsSourceChanged;
            dataGrid.QueryCoveredRange -= dataGrid_QueryCoveredRange;
            dataGrid.AutoGeneratingColumn -= dataGrid_AutoGeneratingColumn;
            dataGrid.CurrentCellEndEdit -= dataGrid_CurrentCellEndEdit;
            dataGrid.CurrentCellValueChanged -= dataGrid_CurrentCellValueChanged;
        }
    } 
}
