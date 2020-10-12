#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;
using System.Windows.Media;
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.TreeGrid.Helpers;
using Syncfusion.Data.Extensions;
using Syncfusion.UI.Xaml.TreeView;
using Syncfusion.UI.Xaml.TreeView.Helpers;
using Syncfusion.UI.Xaml.TreeView.Engine;
using System.ComponentModel;
using System.Linq.Expressions;

namespace syncfusion.treeviewdemos.wpf
{
    /// <summary>
    /// Describes the DragDropBehavior
    /// </summary>
    public class DragdropbetweenTreeViewnandTreeGridBehavior : Behavior<DragDropBetweenTreeViewAndTreeGridDemo>
    {
        /// <summary>
        /// Initialize the OnAttached method
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        /// <summary>
        /// Denotes the Loaded event of this class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.treeGrid.RowDragDropController.Drop += RowDragDropController_Drop;
            this.AssociatedObject.treeView.ItemDropping += TreeView_ItemDropping;
        }

        private void TreeView_ItemDropping(object sender, TreeViewItemDroppingEventArgs e)
        {
            var dragSource = e.DragSource as SfTreeView;
            var dropSource = sender as SfTreeView;
            IList sourceCollection = null;

            if (dragSource == null || (dragSource != dropSource))
            {
                var item = e.Data.GetData("Nodes") as ObservableCollection<TreeNode>;
                var treeNode = item[0] as TreeNode;
                var record = treeNode.Item as PersonInfo;
                var dropPosition = e.DropPosition.ToString();
                var newItem = new PersonInfo();
                if (e.TargetNode != null)
                {
                    var itemInfo = AssociatedObject.treeView.GetItemInfo(e.TargetNode.Content);
                    int rowIndex = (int)itemInfo.ItemIndex;
                    if (dropPosition != "None" && rowIndex != -1)
                    {
                        var treeViewNode = AssociatedObject.treeView.GetNodeAtRowIndex(rowIndex);

                        if (treeViewNode == null)
                            return;
                        var data = treeViewNode.Content;
                        var itemIndex = -1;

                        TreeViewNode parentNode = null;

                        if (dropPosition == "DropBelow" || dropPosition == "DropAbove")
                        {
                            parentNode = treeViewNode.ParentNode;

                            if (parentNode == null)
                                newItem = new PersonInfo() { FirstName = record.FirstName, LastName = record.LastName, ID = record.ID, DOB = record.DOB, Children = record.Children };
                            else
                            {
                                var parentkey = parentNode.Content as PersonInfo;
                                newItem = new PersonInfo() { FirstName = record.FirstName, LastName = record.LastName, ID = record.ID,  DOB = record.DOB, Children = record.Children };
                            }
                        }

                        else if (dropPosition == "DropAsChild")
                        {

                            if (!treeViewNode.IsExpanded)
                                AssociatedObject.treeView.ExpandNode(treeViewNode);
                            parentNode = treeViewNode;
                            var parentkey = parentNode.Content as PersonInfo;
                            newItem = new PersonInfo() { FirstName = record.FirstName, LastName = record.LastName, ID = record.ID, Children = record.Children };
                        }

                        if (dropPosition == "DropBelow" || dropPosition == "DropAbove")
                        {
                            if (treeViewNode.ParentNode != null)
                            {
                                IEnumerable collection = null;
                                if (AssociatedObject.treeView.HierarchyPropertyDescriptors != null && AssociatedObject.treeView.HierarchyPropertyDescriptors.Count > 0)
                                {
                                    foreach (var propertyDescriptor in AssociatedObject.treeView.HierarchyPropertyDescriptors)
                                    {
                                        if (propertyDescriptor.TargetType == treeViewNode.ParentNode.Content.GetType())
                                        {
                                            var descriptors = TypeDescriptor.GetProperties(treeViewNode.ParentNode.Content.GetType());
                                            var tempItem = descriptors.Find(AssociatedObject.treeView.ChildPropertyName, true);
                                            if (tempItem != null)
                                                collection = tempItem.GetValue(treeViewNode.ParentNode.Content) as IEnumerable;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    var descriptors = TypeDescriptor.GetProperties(treeViewNode.ParentNode.Content.GetType());
                                    var tempItem = descriptors.Find(AssociatedObject.treeView.ChildPropertyName, true);
                                    if (tempItem != null)
                                        collection = tempItem.GetValue(treeViewNode.ParentNode.Content) as IEnumerable;
                                }
                                sourceCollection = GetSourceListCollection(collection);
                            }
                            else
                            {
                                sourceCollection = GetSourceListCollection(null);
                            }
                            itemIndex = sourceCollection.IndexOf(data);

                            if (dropPosition == "DropBelow")
                            {
                                itemIndex += 1;
                            }
                        }

                        else if (dropPosition == "DropAsChild")
                        {
                            var descriptors = TypeDescriptor.GetProperties(treeViewNode.Content.GetType());
                            if (parentNode != null)
                            {
                                IEnumerable collection = null;
                                var tempItem = descriptors.Find(AssociatedObject.treeView.ChildPropertyName, true);
                                if (tempItem != null)
                                    collection = tempItem.GetValue(treeViewNode.Content) as IEnumerable;
                                if (collection != null)
                                    sourceCollection = GetSourceListCollection(collection);
                            }

                            if (sourceCollection == null)
                            {
                                var type = data.GetType().GetProperty(AssociatedObject.treeView.ChildPropertyName).PropertyType;
                                var paramExp = System.Linq.Expressions.Expression.Parameter(type, type.Name);
                                var instance = System.Linq.Expressions.Expression.MemberInit(System.Linq.Expressions.Expression.New(type), new List<MemberBinding>());
                                var lambda = System.Linq.Expressions.Expression.Lambda(instance, paramExp);
                                var delg = lambda.Compile();
                                var list = delg.DynamicInvoke(new object[] { null }) as IList;

                                if (list != null)
                                {
                                    var tempitem = descriptors.Find(AssociatedObject.treeView.ChildPropertyName, true);
                                    tempitem.SetValue(treeViewNode.Content, list);
                                    sourceCollection = list;
                                }
                                itemInfo.Node.PopulateChildNodes(sourceCollection);
                            }
                            itemIndex = sourceCollection.Count;

                        }
                        sourceCollection.Insert(itemIndex, newItem);
                        e.Handled = true;
                        (AssociatedObject.treeGrid.ItemsSource as ObservableCollection<PersonInfo>).Remove(record as PersonInfo);
                    }
                }
                else
                {
                    sourceCollection = GetSourceListCollection(null);
                    sourceCollection.Insert(0, record);
                    (AssociatedObject.treeGrid.ItemsSource as ObservableCollection<PersonInfo>).Remove(record as PersonInfo);
                }
            }
        }


        /// <summary>
        /// Descrides the Drop event of the RowDragDroController and handles the drop items from ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowDragDropController_Drop(object sender, Syncfusion.UI.Xaml.TreeGrid.TreeGridRowDropEventArgs e)
        {
            if (e.IsFromOutSideSource)
            {
                var item = e.Data.GetData("Nodes") as ObservableCollection<TreeViewNode>;
                var treeViewNode = item[0] as TreeViewNode;
                var record = treeViewNode.Content as PersonInfo;
                var dropPosition = e.DropPosition.ToString();
                var newItem = new PersonInfo();
                IList sourceCollection = null;

                if (e.TargetNode != null)   
                {
                    var rowIndex = AssociatedObject.treeGrid.ResolveToRowIndex(e.TargetNode.Item);
                    int nodeIndex = (int)rowIndex;
                    if (dropPosition != "None" && rowIndex != -1)
                    {
                        var treeNode = AssociatedObject.treeGrid.GetNodeAtRowIndex(rowIndex);
                        if (treeNode == null)
                            return;
                        if (AssociatedObject.treeGrid.View is TreeGridNestedView)
                        {
                            
                            var data = treeNode.Item;
                            AssociatedObject.treeGrid.SelectionController.SuspendUpdates();
                            var itemIndex = -1;

                            TreeNode parentNode = null;

                            if (dropPosition == "DropBelow" || dropPosition == "DropAbove")
                            {
                                parentNode = treeNode.ParentNode;
                                newItem = new PersonInfo() { FirstName = record.FirstName, LastName = record.LastName, ID = record.ID, DOB = record.DOB, Children = record.Children};
                            }
                            else if (dropPosition == "DropAsChild")
                            {

                                if (!treeNode.IsExpanded)
                                    AssociatedObject.treeGrid.ExpandNode(treeNode);
                                parentNode = treeNode;
                                newItem = new PersonInfo() { FirstName = record.FirstName, LastName = record.LastName, ID = record.ID,  DOB = record.DOB, Children = record.Children};
                            }

                            if (dropPosition == "DropBelow" || dropPosition == "DropAbove")
                            {
                                if (treeNode.ParentNode != null)
                                {
                                    var collection = AssociatedObject.treeGrid.View.GetPropertyAccessProvider().GetValue(treeNode.ParentNode.Item, AssociatedObject.treeGrid.ChildPropertyName) as IEnumerable;
                                    sourceCollection = GetSourceListCollection(collection);
                                }
                                else
                                    sourceCollection = GetSourceListCollection(AssociatedObject.treeGrid.View.SourceCollection);
                                itemIndex = sourceCollection.IndexOf(data);

                                if (dropPosition == "DropBelow")
                                    itemIndex += 1;
                            }
                            else if (dropPosition == "DropAsChild")
                            {
                                var collection = AssociatedObject.treeGrid.View.GetPropertyAccessProvider().GetValue(data, AssociatedObject.treeGrid.ChildPropertyName) as IEnumerable;
                                sourceCollection = GetSourceListCollection(collection);

                                if (sourceCollection == null)
                                {
                                    var list = data.GetType().GetProperty(AssociatedObject.treeGrid.ChildPropertyName).PropertyType.CreateNew() as IList;
                                    if (list != null)
                                    {
                                        AssociatedObject.treeGrid.View.GetPropertyAccessProvider().SetValue(treeNode.Item, AssociatedObject.treeGrid.ChildPropertyName, list);
                                        sourceCollection = list;
                                    }
                                }
                                itemIndex = sourceCollection.Count;
                            }
                            sourceCollection.Insert(itemIndex, newItem);
                            AssociatedObject.treeGrid.SelectionController.ResumeUpdates();
                            (AssociatedObject.treeGrid.SelectionController as TreeGridRowSelectionController).RefreshSelection();

                        }
                        if (treeViewNode.Level == 0)
                            (AssociatedObject.treeView.ItemsSource as ObservableCollection<PersonInfo>).Remove(record as PersonInfo);
                        else
                        {
                            ((treeViewNode.ParentNode.Content as PersonInfo).Children as ObservableCollection<PersonInfo>).Remove(treeViewNode.Content as PersonInfo);
                        }
                    }
                }
                else
                {
                    sourceCollection = GetSourceListCollection(AssociatedObject.treeGrid.View.SourceCollection);
                    sourceCollection.Insert(0, record);
                    (AssociatedObject.treeView.ItemsSource as ObservableCollection<PersonInfo>).Remove(record as PersonInfo);
                }
            }
        }

        /// <summary>
        /// Gets the source collection of TreeGrid
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private IList GetSourceListCollection(IEnumerable collection)
        {
            IList list = null;
            if (collection == null)
            {
                collection = AssociatedObject.treeView.ItemsSource as IEnumerable;
            }
            if ((collection as IList) != null)
            {
                list = collection as IList;
            }
            return list;
        }

        /// <summary>
        /// Initialize the OnDetaching method
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            this.AssociatedObject.treeGrid.RowDragDropController.Drop -= RowDragDropController_Drop;
            this.AssociatedObject.treeView.ItemDropping -= TreeView_ItemDropping;
        }
    }
}


