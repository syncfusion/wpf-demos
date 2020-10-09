#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.TreeGrid;
using System.Collections;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.TreeGrid.Helpers;
using syncfusion.demoscommon.wpf;
using System.Windows.Input;

namespace syncfusion.treegriddemos.wpf
{
    public class ContextMenuViewModel  : EmployeeInfoViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextMenuViewModel"/> class.
        /// </summary>
        public ContextMenuViewModel()
        {
            this.PersonDetails = this.CreateGenericPersonData(5, 8);
            Expand = new BaseCommand(OnExpandClicked, CanExpandClicked);
            SortAscending = new BaseCommand(OnSortAscendingClicked, CanSortAscending);
            Collapse = new BaseCommand(OnCollapseClicked, CanCollapseClicked);
            SortDescending = new BaseCommand(OnSortDescendingClicked, CanSortDescending);
            ClearSorting = new BaseCommand(OnClearSortingClicked, CanClearSort);
            BestFit = new DelegateCommand(OnBestFitClicked);
            Cut = new DelegateCommand(OnCutClicked);
            Copy = new DelegateCommand(OnCopyClicked);
            Paste = new BaseCommand(OnPasteClicked, CanPaste);
            Delete = new DelegateCommand(OnDeleteClicked);
            AddAbove = new DelegateCommand(OnAddAboveClicked);
            AddBelow = new DelegateCommand(OnAddBelowClicked);
            AddAsChild = new DelegateCommand(OnAddAsChildClicked);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileExplorerViewModel"/> class.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        public ContextMenuViewModel(int count, int maxGenerations)
        {
            CreateGenericPersonData(count, maxGenerations);
        }

        #region ContextMenuCommands

        #region Expand

        private ICommand expand;
        public ICommand Expand
        {
            get
            {               
                return expand;
            }
            set
            {
                expand = value;
            }
        }

        private void OnExpandClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            grid.ExpandNode(contextMenuInfo.TreeNode);
        }

        private bool CanExpandClicked(object obj)
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
        private ICommand collapse;
        public ICommand Collapse
        {
            get
            {
                return collapse;
            }
            set
            {
                collapse = value;
            }
        }

        private void OnCollapseClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            var node = contextMenuInfo.TreeNode;
            grid.CollapseNode(node);
        }

        private bool CanCollapseClicked(object obj)
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
        private ICommand sortAscending;
        public ICommand SortAscending
        {
            get
            {
                return sortAscending;
            }
            set
            {
                sortAscending = value;
            }
        }
        private void OnSortAscendingClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridColumnContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            grid.SortColumnDescriptions.Clear();
            grid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = column.MappingName, SortDirection = ListSortDirection.Ascending });
        }

        private bool CanSortAscending(object obj)
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
        private ICommand sortDescending;
        public ICommand SortDescending
        {
            get
            {
                return sortDescending;
            }
            set
            {
                sortDescending = value;
            }
        }


        private void OnSortDescendingClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridColumnContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            grid.SortColumnDescriptions.Clear();
            grid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = column.MappingName, SortDirection = ListSortDirection.Descending });

        }

        private bool CanSortDescending(object obj)
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
        private ICommand clearSorting;
        public ICommand ClearSorting
        {
            get
            {
                return clearSorting;
            }
            set
            {
                clearSorting = value;
            }
        }

        private bool CanClearSort(object obj)
        {
            if (obj == null)
                return false;
            var contextMenuInfo = obj as TreeGridColumnContextMenuInfo;
            var grid = contextMenuInfo.TreeGrid;
            var column = contextMenuInfo.Column;
            return grid.SortColumnDescriptions.Any(x => x.ColumnName == column.MappingName);
        }

        private void OnClearSortingClicked(object obj)
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
        private ICommand bestFit;
        public ICommand BestFit
        {
            get
            {
                return bestFit;
            }
            set
            {
                bestFit = value;
            }
        }


        private void OnBestFitClicked(object obj)
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
        private ICommand cut;
        public ICommand Cut
        {
            get
            {
                return cut;
            }
            set
            {
                cut = value;
            }
        }

        private void OnCutClicked(object obj)
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
        private ICommand copy;
        public ICommand Copy
        {
            get
            {
                return copy;
            }
            set
            {
                copy = value;
            }
        }


        private void OnCopyClicked(object obj)
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
        private ICommand paste;
        public ICommand Paste
        {
            get
            {
                return paste;
            }
            set
            {
                paste = value;
            }
        }

        private bool CanPaste(object obj)
        {
            if (Clipboard.GetDataObject() != null && (Clipboard.GetDataObject() as DataObject).ContainsText())
                return true;
            return false;
        }

        private void OnPasteClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = (obj as TreeGridNodeContextMenuInfo).TreeGrid;
            grid.TreeGridCopyPaste.Paste();
        }


        #endregion

        #region Delete
        private ICommand delete;
        public ICommand Delete
        {
            get
            {
                return delete;
            }
            set
            {
                delete = value;
            }
        }


        private void OnDeleteClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            var grid = contextMenuInfo.TreeGrid;
            var node = contextMenuInfo.TreeNode;
            var item = node.Item as EmployeeInfo;
            if (item != null && node.Level == 0)
                (grid.DataContext as ContextMenuViewModel).PersonDetails.Remove(item);
            else
            {
                var collection = grid.View.GetPropertyAccessProvider().GetValue(node.ParentNode.Item, grid.ChildPropertyName) as IList;
                collection.Remove(item);
            }
        }
        #endregion

        #region AddAbove
        private ICommand addAbove;
        public ICommand AddAbove
        {
            get
            {
                return addAbove;
            }
            set
            {
                addAbove = value;
            }
        }


        private void OnAddAboveClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            Random random = new Random(123123);
            var treeGrid = contextMenuInfo.TreeGrid;
            var treeNode = contextMenuInfo.TreeNode;
            var parentNode = treeNode.ParentNode;
            var item = treeNode.Item as EmployeeInfo;
            var newItem = new EmployeeInfo() { ID = EmployeeInfo._globalId++, Children = new System.Collections.ObjectModel.ObservableCollection<EmployeeInfo>(), FirstName = ContextMenuViewModel.names1[random.Next(ContextMenuViewModel.names1.GetLength(0))], LastName = ContextMenuViewModel.names2[random.Next(ContextMenuViewModel.names2.GetLength(0))] };
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

        #endregion

        #region AddBelow
        private ICommand addBelow;
        public ICommand AddBelow
        {
            get
            {
                return addBelow;
            }
            set
            {
                addBelow = value;
            }
        }


        private void OnAddBelowClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            Random random = new Random(123123);
            var treeGrid = contextMenuInfo.TreeGrid;
            var treeNode = contextMenuInfo.TreeNode;
            var parentNode = treeNode.ParentNode;
            var item = treeNode.Item as EmployeeInfo;
            var newItem = new EmployeeInfo() { ID = EmployeeInfo._globalId++, Children = new System.Collections.ObjectModel.ObservableCollection<EmployeeInfo>(), FirstName = ContextMenuViewModel.names1[random.Next(ContextMenuViewModel.names1.GetLength(0))], LastName = ContextMenuViewModel.names2[random.Next(ContextMenuViewModel.names2.GetLength(0))] };
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

        #endregion

        #region AddAsChild
        private ICommand addAsChild;
        public ICommand AddAsChild
        {
            get
            {
                return addAsChild;
            }
            set
            {
                addAsChild = value;
            }
        }


        private void OnAddAsChildClicked(object obj)
        {
            var contextMenuInfo = obj as TreeGridNodeContextMenuInfo;
            if (contextMenuInfo == null)
                return;
            Random random = new Random(123123);
            var treeGrid = contextMenuInfo.TreeGrid;
            var treeNode = contextMenuInfo.TreeNode;
            var item = treeNode.Item as EmployeeInfo;
            var newItem = new EmployeeInfo() { ID = EmployeeInfo._globalId++, Children = new System.Collections.ObjectModel.ObservableCollection<EmployeeInfo>(), FirstName = ContextMenuViewModel.names1[random.Next(ContextMenuViewModel.names1.GetLength(0))], LastName = ContextMenuViewModel.names2[random.Next(ContextMenuViewModel.names2.GetLength(0))] };
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

        #endregion
    }
}
