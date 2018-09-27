#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.TreeGrid.Helpers;
using Syncfusion.Windows.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;


namespace ContextMenuDemo
{
    public static class ContextMenuCommands
    {
        #region Expand
        static BaseCommand expand;
        public static BaseCommand Expand
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
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            grid.ExpandNode(contextMenuInfo.TreeNode);
        }

        private static bool CanExpandClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return false;
            var grid = contextMenuInfo.TreeGrid;
            var node = contextMenuInfo.TreeNode;
            return !node.IsExpanded;
        }

        #endregion

        #region Collapse
        static BaseCommand collapse;
        public static BaseCommand Collapse
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
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            var node = contextMenuInfo.TreeNode;
            grid.CollapseNode(node);
        }

        private static bool CanCollapseClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return false;
            var grid = contextMenuInfo.TreeGrid;
            var treeNode = contextMenuInfo.TreeNode as TreeNode;
            return treeNode.IsExpanded;
        }
        #endregion


        #region SortAscending
        static BaseCommand sortAscending;
        public static BaseCommand SortAscending
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
            var contextMenuInfo = obj as TreeGridColumnContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            grid.SortColumnDescriptions.Clear();
            grid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = column.MappingName, SortDirection = ListSortDirection.Ascending });
        }

        private static bool CanSortAscending(object obj)
        {
            var contextMenuInfo = obj as TreeGridColumnContextMenuInfo;
            if (contextMenuInfo == null)
                return false;
            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            var sortColumn = grid.SortColumnDescriptions.FirstOrDefault(x => x.ColumnName == column.MappingName);
            if (sortColumn != null)
            {
                if ((sortColumn as SortColumnDescription).SortDirection == ListSortDirection.Ascending)
                    return false;
            }
            return grid.AllowSorting;
        }

        #endregion

        #region SortDescending
        static BaseCommand sortDescending;
        public static BaseCommand SortDescending
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
            var contextMenuInfo = obj as TreeGridColumnContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            grid.SortColumnDescriptions.Clear();
            grid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = column.MappingName, SortDirection = ListSortDirection.Descending });

        }

        private static bool CanSortDescending(object obj)
        {
            var contextMenuInfo = obj as TreeGridColumnContextMenuInfo;
            if (contextMenuInfo == null)
                return false;
            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            var sortColumn = grid.SortColumnDescriptions.FirstOrDefault(x => x.ColumnName == column.MappingName);
            if (sortColumn != null)
            {
                if ((sortColumn as SortColumnDescription).SortDirection == ListSortDirection.Descending)
                    return false;
            }
            return grid.AllowSorting;
        }
        #endregion

        #region ClearSorting
        static BaseCommand clearSorting;
        public static BaseCommand ClearSorting
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
            var contextMenuInfo = obj as TreeGridColumnContextMenuInfo;
            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            return grid.SortColumnDescriptions.Any(x => x.ColumnName == column.MappingName);
        }

        private static void OnClearSortingClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridColumnContextMenuInfo;
            if (contextMenuInfo == null)
                return;

            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            if (grid.SortColumnDescriptions.Any(x => x.ColumnName == column.MappingName))
                grid.SortColumnDescriptions.Remove(grid.SortColumnDescriptions.FirstOrDefault(x => x.ColumnName == column.MappingName));

        }
        #endregion

        #region BestFit
        static BaseCommand bestFit;
        public static BaseCommand BestFit
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
            var contextMenuInfo = obj as TreeGridColumnContextMenuInfo;
            if (contextMenuInfo == null)
                return;

            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            column.ColumnSizer = TreeColumnSizer.Auto;
        }
        #endregion

        #region Cut
        static BaseCommand cut;
        public static BaseCommand Cut
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
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            grid.GridCopyOption = GridCopyOption.CutData;
            grid.TreeGridCopyPaste.Cut();
        }
        #endregion

        #region Copy
        static BaseCommand copy;
        public static BaseCommand Copy
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
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            grid.GridCopyOption = GridCopyOption.CopyData;
            grid.TreeGridCopyPaste.Copy();
        }

        #endregion

        #region Paste
        static BaseCommand paste;
        public static BaseCommand Paste
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
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = (obj as TreeGridNodeContextMenuInfo).TreeGrid;
            grid.TreeGridCopyPaste.Paste();
        }


        #endregion

        #region Delete
        static BaseCommand delete;
        public static BaseCommand Delete
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
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            var node = contextMenuInfo.TreeNode;
            var item = node.Item as PersonInfo;
            if (item != null && node.Level == 0)
                (grid.DataContext as ViewModel).PersonDetails.Remove(item);
            else
            {
                var collection = grid.View.GetPropertyAccessProvider().GetValue(node.ParentNode.Item, grid.ChildPropertyName) as IList;
                collection.Remove(item);
            }
        }
        #endregion


        #region AddAbove
        static BaseCommand addAbove;
        public static BaseCommand AddAbove
        {
            get
            {
                if (addAbove == null)
                    addAbove = new BaseCommand(OnAddAboveClicked);

                return addAbove;
            }
        }


        private static void OnAddAboveClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            Random random = new Random(123123);
            var treeGrid = contextMenuInfo.TreeGrid;
            var treeNode = contextMenuInfo.TreeNode;
            var parentNode = treeNode.ParentNode;
            var item = treeNode.Item as PersonInfo;
            var newItem = new PersonInfo() { Id = PersonInfo._globalId++,Children = new System.Collections.ObjectModel.ObservableCollection<PersonInfo>(), FirstName = ViewModel.names1[random.Next(ViewModel.names1.GetLength(0))], LastName = ViewModel.names2[random.Next(ViewModel.names2.GetLength(0))] };
            IList collection = null;
            if (treeNode.ParentNode != null)
            {
                collection = treeGrid.View.GetPropertyAccessProvider().GetValue(parentNode.Item, treeGrid.ChildPropertyName) as IList;
            }
            else
                collection = treeGrid.ItemsSource as IList;

            var itemIndex = collection.IndexOf(item);
            collection.Insert(itemIndex, newItem);
        }


        static BaseCommand addBelow;
        public static BaseCommand AddBelow
        {
            get
            {
                if (addBelow == null)
                    addBelow = new BaseCommand(OnAddBelowClicked);

                return addBelow;
            }
        }


        private static void OnAddBelowClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            Random random = new Random(123123);
            var treeGrid = contextMenuInfo.TreeGrid;
            var treeNode = contextMenuInfo.TreeNode;
            var parentNode = treeNode.ParentNode;
            var item = treeNode.Item as PersonInfo;
            var newItem = new PersonInfo() { Id = PersonInfo._globalId++, Children = new System.Collections.ObjectModel.ObservableCollection<PersonInfo>(), FirstName = ViewModel.names1[random.Next(ViewModel.names1.GetLength(0))], LastName = ViewModel.names2[random.Next(ViewModel.names2.GetLength(0))] };
            IList collection = null;
            if (treeNode.ParentNode != null)
            {
                collection = treeGrid.View.GetPropertyAccessProvider().GetValue(parentNode.Item, treeGrid.ChildPropertyName) as IList;
            }
            else
                collection = treeGrid.ItemsSource as IList;

            var itemIndex = collection.IndexOf(item);

            collection.Insert(itemIndex + 1, newItem);
        }

        static BaseCommand addAsChild;
        public static BaseCommand AddAsChild
        {
            get
            {
                if (addAsChild == null)
                    addAsChild = new BaseCommand(OnAddAsChildClicked);

                return addAsChild;
            }
        }


        private static void OnAddAsChildClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            Random random = new Random(123123);
            var treeGrid = contextMenuInfo.TreeGrid;
            var treeNode = contextMenuInfo.TreeNode;
            var item = treeNode.Item as PersonInfo;
            var newItem = new PersonInfo() { Id = PersonInfo._globalId++, Children = new System.Collections.ObjectModel.ObservableCollection<PersonInfo>(),FirstName = ViewModel.names1[random.Next(ViewModel.names1.GetLength(0))], LastName = ViewModel.names2[random.Next(ViewModel.names2.GetLength(0))] };
            var rowIndex = treeGrid.ResolveToRowIndex(treeNode);
            var collection = treeGrid.View.GetPropertyAccessProvider().GetValue(treeNode.Item, treeGrid.ChildPropertyName) as IList;

            collection.Insert(collection.Count, newItem);
            if (!treeNode.HasChildNodes)
            {
                treeGrid.ResetNode(treeNode);
                treeGrid.UpdateDataRow(rowIndex);
            }
        }
        #endregion
    }

}
