#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using Syncfusion.Windows.Shared;
using ContextMenuDemo;
using Syncfusion.UI.Xaml.TreeGrid;
using System.Collections;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.TreeGrid.Helpers;

namespace ContextMenuDemo
{
    class ViewModel
    {
        private static Random random = new Random(123123);
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.PersonDetails = this.CreateGenericPersonData(5, 8);
            Expand = new BaseCommand(OnExpandClicked, CanExpandClicked);
            SortAscending = new BaseCommand(OnSortAscendingClicked, CanSortAscending);
            Collapse = new BaseCommand(OnCollapseClicked, CanCollapseClicked);
            SortDescending = new BaseCommand(OnSortDescendingClicked, CanSortDescending);
            ClearSorting = new BaseCommand(OnClearSortingClicked, CanClearSort);
            BestFit = new BaseCommand(OnBestFitClicked);
            Cut = new BaseCommand(OnCutClicked);
            Copy = new BaseCommand(OnCopyClicked);
            Paste = new BaseCommand(OnPasteClicked, CanPaste);
            Delete = new BaseCommand(OnDeleteClicked);
            AddAbove = new BaseCommand(OnAddAboveClicked);
            AddBelow = new BaseCommand(OnAddBelowClicked);
            AddAsChild = new BaseCommand(OnAddAsChildClicked);
        }

        private ObservableCollection<PersonInfo> _PersonDetails;

        /// <summary>
        /// Gets or sets the person details.
        /// </summary>
        /// <value>The person details.</value>
        public ObservableCollection<PersonInfo> PersonDetails
        {
            get { return _PersonDetails; }
            set { _PersonDetails = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        public ViewModel(int count, int maxGenerations)
        {
            CreateGenericPersonData(count, maxGenerations);
        }

        private List<string> _comboBoxItemsSource = new List<string>();

        public List<string> ComboBoxItemsSource
        {
            get { return _comboBoxItemsSource; }
            set { _comboBoxItemsSource = value; }
        }


        /// <summary>
        /// Creates the child list.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        public ObservableCollection<PersonInfo> CreateChildList(int count, int maxGenerations, string lastName)
        {
            ObservableCollection<PersonInfo> _children = new ObservableCollection<PersonInfo>();
            if (count > 0 && maxGenerations > 0)
            {
                _children = CreateGenericPersonData(count, maxGenerations - 1);
                foreach (PersonInfo p in _children)
                    p.LastName = lastName;
            }
            return _children;
        }

        /// <summary>
        /// Creates the generic person data.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        /// <returns></returns>
        public ObservableCollection<PersonInfo> CreateGenericPersonData(int count, int maxGenerations)
        {
            var personList = new ObservableCollection<PersonInfo>();
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var lastname = names2[random.Next(names2.GetLength(0))];
                    personList.Add(new PersonInfo()
                    {
                        FirstName = names1[random.Next(names1.GetLength(0))],
                        LastName = lastname,
                        Children = this.CreateChildList(count, (int)Math.Max(0, maxGenerations - 1), lastname),
                        MyEyeColor = color[random.Next(color.GetLength(0))],
                        DOB = GenerateRandomDate()
                    });
                    if (!_comboBoxItemsSource.Contains(personList.FirstOrDefault().LastName))
                        _comboBoxItemsSource.Add(personList.FirstOrDefault().LastName);
                }
            }
            return personList;
        }

        /// <summary>
        /// Generates the random date.
        /// </summary>
        /// <returns></returns>
        private DateTime GenerateRandomDate()
        {
            int randInt = random.Next(4000);
            return DateTime.Now.AddDays(-8000 + randInt);
        }

        #region Array Collection

        internal static string[] names1 = new string[]{
            "George","John","Thomas","James","Andrew","Martin","William","Zachary",
            "Millard","Franklin","Abraham","Ulysses","Rutherford","Chester","Grover","Benjamin",
            "Theodore","Woodrow","Warren","Calvin","Herbert","Franklin","Harry","Dwight","Lyndon",
            "Richard","Gerald","Jimmy","Ronald","George","Bill", "Barack", "Warner","Peter", "Larry"
        };
        internal static string[] names2 = new string[]{
             "Washington","Adams","Jefferson","Madison","Monroe","Jackson","Van Buren","Harrison","Tyler",
             "Polk","Taylor","Fillmore","Pierce","Buchanan","Lincoln","Johnson","Grant","Hayes","Garfield",
             "Arthur","Cleveland","Harrison","McKinley","Roosevelt","Taft","Wilson","Harding","Coolidge",
             "Hoover","Truman","Eisenhower","Kennedy","Johnson","Nixon","Ford","Carter","Reagan","Bush",
             "Clinton","Bush","Obama","Smith","Jones","Stogner"
        };
        internal static string[] color = new string[]{
            "Red", "Blue", "Brown", "Unknown"
        };
        #endregion

        #region ContextMenuCommands

        #region Expand
        private BaseCommand expand;
        public BaseCommand Expand
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
        private BaseCommand collapse;
        public BaseCommand Collapse
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
        private BaseCommand sortAscending;
        public BaseCommand SortAscending
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
        private BaseCommand sortDescending;
        public BaseCommand SortDescending
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
        private BaseCommand clearSorting;
        public BaseCommand ClearSorting
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
        private BaseCommand bestFit;
        public BaseCommand BestFit
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
        private BaseCommand cut;
        public BaseCommand Cut
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
        private BaseCommand copy;
        public BaseCommand Copy
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
        private BaseCommand paste;
        public BaseCommand Paste
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
        private BaseCommand delete;
        public BaseCommand Delete
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
        private BaseCommand addAbove;
        public BaseCommand AddAbove
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
            collection.Insert(itemIndex, newItem);
        }

        #endregion

        #region AddBelow
        private BaseCommand addBelow;
        public BaseCommand AddBelow
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

        #endregion

        #region AddAsChild
        private BaseCommand addAsChild;
        public BaseCommand AddAsChild
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
            var item = treeNode.Item as PersonInfo;
            var newItem = new PersonInfo() { Id = PersonInfo._globalId++, Children = new System.Collections.ObjectModel.ObservableCollection<PersonInfo>(), FirstName = ViewModel.names1[random.Next(ViewModel.names1.GetLength(0))], LastName = ViewModel.names2[random.Next(ViewModel.names2.GetLength(0))] };
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
