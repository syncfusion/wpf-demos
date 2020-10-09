#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.datagriddemos.wpf
{
    public static class ContextMenuCommands
    {
        #region clearSummary
        static ICommand clearSummary;
        public static ICommand ClearSummary
        {
            get
            {
                if (clearSummary == null)
                    clearSummary = new BaseCommand(OnClearSummaryClicked);

                return clearSummary;
            }
        }


        private static void OnClearSummaryClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                if (grid.GroupSummaryRows.Any())
                    grid.GroupSummaryRows.Clear();
            }
        }

        #endregion

        #region ExpandAll
        static ICommand expandAll;
        public static ICommand ExpandAll
        {
            get
            {
                if (expandAll == null)
                    expandAll = new BaseCommand(OnFullExpandClicked, CanFullExpand);

                return expandAll;
            }
        }

        private static void OnFullExpandClicked(object obj)
        {
            if (obj is Syncfusion.UI.Xaml.Grid.GridContextMenuInfo)
            {
                var grid = (obj as Syncfusion.UI.Xaml.Grid.GridContextMenuInfo).DataGrid;
                grid.ExpandAllGroup();
            }
        }

        private static bool CanFullExpand(object obj)
        {
            if (obj is Syncfusion.UI.Xaml.Grid.GridContextMenuInfo)
            {
                var grid = (obj as Syncfusion.UI.Xaml.Grid.GridContextMenuInfo).DataGrid;
                if (grid.View.TopLevelGroup != null && grid.View.TopLevelGroup.Groups.Count > 0)
                    return grid.View.TopLevelGroup.Groups.Any(x => !x.IsExpanded);
            }
            return false;
        }
        #endregion

        #region CollapseAll
        static ICommand collapseAll;
        public static ICommand CollapseAll
        {
            get
            {
                if (collapseAll == null)
                    collapseAll = new BaseCommand(OnFullCollapseClicked, CanFullCollapse);

                return collapseAll;
            }
        }

        private static void OnFullCollapseClicked(object obj)
        {
            if (obj is GridContextMenuInfo)
            {
                var grid = (obj as GridContextMenuInfo).DataGrid;
                grid.CollapseAllGroup();
            }
        }

        private static bool CanFullCollapse(object obj)
        {
            if (obj is Syncfusion.UI.Xaml.Grid.GridContextMenuInfo)
            {
                var grid = (obj as Syncfusion.UI.Xaml.Grid.GridContextMenuInfo).DataGrid;
                if (grid.View.TopLevelGroup != null && grid.View.TopLevelGroup.Groups.Count > 0)
                    return grid.View.TopLevelGroup.Groups.Any(x => x.IsExpanded);
            }
            return false;
        }
        #endregion

        #region Expand
        static ICommand expand;
        public static ICommand Expand
        {
            get
            {
                if (expand == null)
                    expand = new BaseCommand(OnExpandClicked, CanExpandClicked);

                return expand;
            }
        }

        private static void OnExpandClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                var group = (obj as GridRecordContextMenuInfo).Record as Group;
                grid.ExpandGroup(group);
            }
        }

        private static bool CanExpandClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                var group = (obj as GridRecordContextMenuInfo).Record as Group;
                return !group.IsExpanded;
            }
            return false;
        }
        #endregion

        #region Collapse
        static ICommand collapse;
        public static ICommand Collapse
        {
            get
            {
                if (collapse == null)
                    collapse = new BaseCommand(OnCollapseClicked, CanCollapseClicked);

                return collapse;
            }
        }

        private static void OnCollapseClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                var group = (obj as GridRecordContextMenuInfo).Record as Group;
                grid.CollapseGroup(group);
            }
        }

        private static bool CanCollapseClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                var group = (obj as GridRecordContextMenuInfo).Record as Group;
                return group.IsExpanded;
            }
            return false;
        }
        #endregion

        #region ClearGroups
        static ICommand clearGroups;
        public static ICommand ClearGroups
        {
            get
            {
                if (clearGroups == null)
                    clearGroups = new BaseCommand(OnClearGroupsClicked, CanClearGroupsClicked);

                return clearGroups;
            }
        }

        private static void OnClearGroupsClicked(object obj)
        {
            if (obj is GridContextMenuInfo)
            {
                var grid = (obj as GridContextMenuInfo).DataGrid;
                grid.GroupColumnDescriptions.Clear();
            }
        }

        private static bool CanClearGroupsClicked(object obj)
        {
            if (obj is GridContextMenuInfo)
            {
                var grid = (obj as GridContextMenuInfo).DataGrid;
                return grid.GroupColumnDescriptions.Any();
            }
            return false;
        }
        #endregion

        #region ClearGrouping
        static ICommand clearGroup;
        public static ICommand ClearGroup
        {
            get
            {
                if (clearGroup == null)
                    clearGroup = new BaseCommand(OnClearGroupClicked);

                return clearGroup;
            }
        }

        private static void OnClearGroupClicked(object obj)
        {
            if (obj is GridColumnContextMenuInfo)
            {
                var grid = (obj as GridContextMenuInfo).DataGrid;
                var column = (obj as GridColumnContextMenuInfo).Column;
                if (grid.GroupColumnDescriptions.Any(x => x.ColumnName == column.MappingName))
                    grid.GroupColumnDescriptions.Remove(grid.GroupColumnDescriptions.FirstOrDefault(x => x.ColumnName == column.MappingName));
            }
        }

        #endregion

        #region SortAscending
        static ICommand sortAscending;
        public static ICommand SortAscending
        {
            get
            {
                if (sortAscending == null)
                    sortAscending = new BaseCommand(OnSortAscendingClicked, CanSortAscending);

                return sortAscending;
            }
        }


        private static void OnSortAscendingClicked(object obj)
        {
            if (obj is GridColumnContextMenuInfo)
            {
                var grid = (obj as GridContextMenuInfo).DataGrid;
                var column = (obj as GridColumnContextMenuInfo).Column;
                grid.SortColumnDescriptions.Clear();
                grid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = column.MappingName, SortDirection = ListSortDirection.Ascending });
            }
        }

        private static bool CanSortAscending(object obj)
        {
            if (obj is GridColumnContextMenuInfo)
            {
                var grid = (obj as GridContextMenuInfo).DataGrid;
                var column = (obj as GridColumnContextMenuInfo).Column;
                var sortColumn = grid.SortColumnDescriptions.FirstOrDefault(x => x.ColumnName == column.MappingName);
                if (sortColumn != null)
                {
                    if ((sortColumn as SortColumnDescription).SortDirection == ListSortDirection.Ascending)
                        return false;
                }
                return grid.AllowSorting;
            }
            return false;
        }
        #endregion

        #region SortDescending
        static ICommand sortDescending;
        public static ICommand SortDescending
        {
            get
            {
                if (sortDescending == null)
                    sortDescending = new BaseCommand(OnSortDescendingClicked, CanSortDescending);

                return sortDescending;
            }
        }


        private static void OnSortDescendingClicked(object obj)
        {
            if (obj is GridColumnContextMenuInfo)
            {
                var grid = (obj as GridContextMenuInfo).DataGrid;
                var column = (obj as GridColumnContextMenuInfo).Column;
                grid.SortColumnDescriptions.Clear();
                grid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = column.MappingName, SortDirection = ListSortDirection.Descending });
            }
        }

        private static bool CanSortDescending(object obj)
        {
            if (obj is GridColumnContextMenuInfo)
            {
                var grid = (obj as GridContextMenuInfo).DataGrid;
                var column = (obj as GridColumnContextMenuInfo).Column;
                var sortColumn = grid.SortColumnDescriptions.FirstOrDefault(x => x.ColumnName == column.MappingName);
                if (sortColumn != null)
                {
                    if ((sortColumn as SortColumnDescription).SortDirection == ListSortDirection.Descending)
                        return false;
                }
                return grid.AllowSorting;
            }
            return false;
        }
        #endregion

        #region ClearSorting
        static ICommand clearSorting;
        public static ICommand ClearSorting
        {
            get
            {
                if (clearSorting == null)
                    clearSorting = new BaseCommand(OnClearSortingClicked, CanClearSort);

                return clearSorting;
            }
        }

        private static bool CanClearSort(object obj)
        {
           if (obj == null)
                return false;

            var grid = (obj as GridContextMenuInfo).DataGrid;
            var column = (obj as GridColumnContextMenuInfo).Column;
            return grid.SortColumnDescriptions.Any(x => x.ColumnName == column.MappingName);

        }

        private static void OnClearSortingClicked(object obj)
        {
            if (obj is GridColumnContextMenuInfo)
            {
                var grid = (obj as GridContextMenuInfo).DataGrid;
                var column = (obj as GridColumnContextMenuInfo).Column;
                if (grid.SortColumnDescriptions.Any(x => x.ColumnName == column.MappingName))
                    grid.SortColumnDescriptions.Remove(grid.SortColumnDescriptions.FirstOrDefault(x => x.ColumnName == column.MappingName));
            }
        }
        #endregion

        #region ClearFiltering
        static ICommand clearFiltering;
        public static ICommand ClearFiltering
        {
            get
            {
                if (clearFiltering == null)
                    clearFiltering = new BaseCommand(OnClearFilteringClicked, CanClearFiltering);

                return clearFiltering;
            }
        }


        private static void OnClearFilteringClicked(object obj)
        {
            if (obj is GridColumnContextMenuInfo)
            {
                var column = (obj as GridColumnContextMenuInfo).Column;
                if (column.FilterPredicates.Any())
                    column.FilterPredicates.Clear();
            }
        }

        private static bool CanClearFiltering(object obj)
        {
            if (obj is GridColumnContextMenuInfo)
            {
                var column = (obj as GridColumnContextMenuInfo).Column;
                return column.FilterPredicates.Any();
            }
            return false;
        }
        #endregion

        #region ShowHideGroupArea
        static BaseCommand showHideGroupArea;
        public static BaseCommand ShowHideGroupArea
        {
            get
            {
                if (showHideGroupArea == null)
                    showHideGroupArea = new BaseCommand(OnShowHideGroupAreaClicked);

                return showHideGroupArea;
            }
        }


        private static void OnShowHideGroupAreaClicked(object obj)
        {
            if (obj is GridColumnContextMenuInfo)
            {
                var grid = (obj as GridColumnContextMenuInfo).DataGrid;
                grid.IsGroupDropAreaExpanded = !grid.IsGroupDropAreaExpanded;
            }
        }

        #endregion

        #region GroupThisColumn
        static ICommand groupThisColumn;
        public static ICommand GroupThisColumn
        {
            get
            {
                if (groupThisColumn == null)
                    groupThisColumn = new BaseCommand(OnGroupThisColumnClicked, CanGroupThisColumn);

                return groupThisColumn;
            }
        }


        private static void OnGroupThisColumnClicked(object obj)
        {
            if (obj is GridColumnContextMenuInfo)
            {
                var grid = (obj as GridColumnContextMenuInfo).DataGrid;
                var column = (obj as GridColumnContextMenuInfo).Column;
                if (!grid.GroupColumnDescriptions.Any(x => x.ColumnName == column.MappingName))
                    grid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = column.MappingName });
            }
        }

        private static bool CanGroupThisColumn(object obj)
        {
            if (obj is GridColumnContextMenuInfo)
            {
                var grid = (obj as GridColumnContextMenuInfo).DataGrid;
                var column = (obj as GridColumnContextMenuInfo).Column;
                bool canGroup = false;
                if (!grid.GroupColumnDescriptions.Any(x => x.ColumnName == column.MappingName))
                {
                    var groupcolumn = column.ReadLocalValue(GridColumn.AllowGroupingProperty);
                    if (grid.AllowGrouping)
                        canGroup = true;
                    if (groupcolumn != DependencyProperty.UnsetValue || canGroup)
                        canGroup = column.AllowGrouping;
                }
                return canGroup;
            }
            return false;
        }
        #endregion

        #region BestFit
        static ICommand bestFit;
        public static ICommand BestFit
        {
            get
            {
                if (bestFit == null)
                    bestFit = new BaseCommand(OnBestFitClicked);

                return bestFit;
            }
        }


        private static void OnBestFitClicked(object obj)
        {
            if (obj is GridColumnContextMenuInfo)
            {
                var grid = (obj as GridColumnContextMenuInfo).DataGrid;
                var column = (obj as GridColumnContextMenuInfo).Column;
                column.ColumnSizer = GridLengthUnitType.SizeToCells;
            }
        }
        #endregion

        #region Cut
        static ICommand cut;
        public static ICommand Cut
        {
            get
            {
                if (cut == null)
                    cut = new BaseCommand(OnCutClicked);

                return cut;
            }
        }

        private static void OnCutClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                var copypasteoption = grid.GridCopyOption;
                grid.GridCopyOption = GridCopyOption.CutData;
                grid.GridCopyPaste.Cut();
                grid.GridCopyOption = copypasteoption;
            }
        }
        #endregion

        #region Copy
        static ICommand copy;
        public static ICommand Copy
        {
            get
            {
                if (copy == null)
                    copy = new BaseCommand(OnCopyClicked);

                return copy;
            }
        }


        private static void OnCopyClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                grid.GridCopyPaste.Copy();
            }
        }

        #endregion

        #region Paste
        static ICommand paste;
        public static ICommand Paste
        {
            get
            {
                if (paste == null)
                    paste = new BaseCommand(OnPasteClicked, CanPaste);

                return paste;
            }
        }

        private static bool CanPaste(object obj)
        {
            if (Clipboard.GetDataObject() != null && (Clipboard.GetDataObject() as DataObject).ContainsText())
                return true;
            return false;
        }

        private static void OnPasteClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                grid.GridCopyPaste.Paste();
            }
        }


        #endregion

        #region Delete
        static ICommand delete;
        public static ICommand Delete
        {
            get
            {
                if (delete == null)
                    delete = new BaseCommand(OnDeleteClicked);

                return delete;
            }
        }


        private static void OnDeleteClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                var record = (obj as GridRecordContextMenuInfo).Record as Employee;
                if (record != null)
                    (grid.DataContext as EmployeeViewModel).EmployeesCollection.Remove(record);
            }
        }

        #endregion

        #region TotalSummaryCount
        static ICommand totalsummaryCount;
        public static ICommand TotalSummaryCount
        {
            get
            {
                if (totalsummaryCount == null)
                    totalsummaryCount = new BaseCommand(OnTotalSummaryCountClicked);

                return totalsummaryCount;
            }
        }


        private static void OnTotalSummaryCountClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                var record = (obj as GridRecordContextMenuInfo).Record as SummaryRecordEntry;
                if (record != null)
                {
                    var summaryrow = new GridSummaryRow() { Name = "totalgroupsummaryrow", Title = "{totalSummary}", ShowSummaryInRow = true };
                    summaryrow.SummaryColumns.Add(new GridSummaryColumn() { Name = "totalSummary", MappingName = "EmployeeId", SummaryType = SummaryType.CountAggregate, Format = "Total Employee Count : {Count}" });
                    grid.TableSummaryRows.Clear();
                    grid.TableSummaryRows.Add(summaryrow);

                }


            }
        }

        #endregion

        #region TotalSummaryMax
        static ICommand totalsummaryMax;
        public static ICommand TotalSummaryMax
        {
            get
            {
                if (totalsummaryMax == null)
                    totalsummaryMax = new BaseCommand(OnTotalSummaryMaxClicked);

                return totalsummaryMax;
            }
        }


        private static void OnTotalSummaryMaxClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                var record = (obj as GridRecordContextMenuInfo).Record as SummaryRecordEntry;
                if (record != null)
                {
                    var summaryrow = new GridSummaryRow() { ShowSummaryInRow = true, Name = "totalgroupsummaryrow", Title = "{totalSummary}" };
                    summaryrow.SummaryColumns.Add(new GridSummaryColumn() { Name = "totalSummary", MappingName = "EmployeeAge", SummaryType = SummaryType.DoubleAggregate, Format = "Maximum age of Employee : {Max}" });
                    grid.TableSummaryRows.Clear();
                    grid.TableSummaryRows.Add(summaryrow);
                }


            }
        }

        #endregion

        #region TotalSummaryMin
        static ICommand totalsummaryMin;
        public static ICommand TotalSummaryMin
        {
            get
            {
                if (totalsummaryMin == null)
                    totalsummaryMin = new BaseCommand(OnTotalSummaryMinClicked);

                return totalsummaryMin;
            }
        }


        private static void OnTotalSummaryMinClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                var record = (obj as GridRecordContextMenuInfo).Record as SummaryRecordEntry;
                if (record != null)
                {
                    var summaryrow = new GridSummaryRow() { ShowSummaryInRow = true, Name = "totalgroupsummaryrow", Title = "{totalSummary}" };
                    summaryrow.SummaryColumns.Add(new GridSummaryColumn() { Name = "totalSummary", MappingName = "EmployeeAge", SummaryType = SummaryType.DoubleAggregate, Format = "Minimum age of Employee : {Min}" });
                    grid.TableSummaryRows.Clear();
                    grid.TableSummaryRows.Add(summaryrow);
                }


            }
        }

        #endregion

        #region TableAverage
        static ICommand tableAverage;
        public static ICommand TableAverage
        {
            get
            {
                if (tableAverage == null)
                    tableAverage = new BaseCommand(OnTableAverageClicked);

                return tableAverage;
            }
        }


        private static void OnTableAverageClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                var record = (obj as GridRecordContextMenuInfo).Record as SummaryRecordEntry;
                if (record != null)
                {
                    var summaryrow = new GridSummaryRow() { ShowSummaryInRow = true, Name = "totalgroupsummaryrow", Title = "{totalSummary}" };
                    summaryrow.SummaryColumns.Add(new GridSummaryColumn() { Name = "totalSummary", MappingName = "EmployeeAge", SummaryType = SummaryType.DoubleAggregate, Format = "Average Employee age : {Average}" });
                    grid.TableSummaryRows.Clear();
                    grid.TableSummaryRows.Add(summaryrow);
                }


            }
        }

        #endregion

        #region TableSum
        static ICommand tableSum;
        public static ICommand TableSum
        {
            get
            {
                if (tableSum == null)
                    tableSum = new BaseCommand(OnTableSumClicked);

                return tableSum;
            }
        }


        private static void OnTableSumClicked(object obj)
        {
            if (obj is GridRecordContextMenuInfo)
            {
                var grid = (obj as GridRecordContextMenuInfo).DataGrid;
                var record = (obj as GridRecordContextMenuInfo).Record as SummaryRecordEntry;
                if (record != null)
                {
                    var summaryrow = new GridSummaryRow() { ShowSummaryInRow = true, Name = "totalgroupsummaryrow", Title = "{totalSummary}" };
                    summaryrow.SummaryColumns.Add(new GridSummaryColumn() { Name = "totalSummary", MappingName = "EmployeeAge", SummaryType = SummaryType.DoubleAggregate, Format = "Sum Employee Salary : {Sum}" });
                    grid.TableSummaryRows.Clear();
                    grid.TableSummaryRows.Add(summaryrow);
                }


            }
        }

        #endregion

    }

}
