#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.TreeView;
using Syncfusion.UI.Xaml.TreeView.Engine;
using Syncfusion.UI.Xaml.TreeView.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.treeviewdemos.wpf
{
    public class DragDropBetweenTreeViewAndDataGridBehavior : Behavior<DragDropBetweenTreeViewAndDataGridDemo>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;           
            base.OnAttached();
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.sfTreeView.ItemDropping += TreeView_ItemDropping;
            this.AssociatedObject.sfDataGrid.RowDragDropController.Drop += RowDragDropController_Drop;
        }

        private void RowDragDropController_Drop(object sender, Syncfusion.UI.Xaml.Grid.GridRowDropEventArgs e)
        {
            if (e.IsFromOutSideSource)
            {
                var item = e.Data.GetData("Nodes") as ObservableCollection<TreeViewNode>;
                var treeViewNode = item[0] as TreeViewNode;

                var record = treeViewNode.Content as EmployeeInfo;
                int dropIndex = (int)e.TargetRecord;
                var dropPosition = e.DropPosition.ToString();
                var newItem = new EmployeeInfo();

                if (e.TargetRecord != null)
                {
                    IList collection = null;

                    collection = AssociatedObject.sfDataGrid.View.SourceCollection as IList;
                    if (dropPosition == "DropAbove")
                    {
                        if (dropIndex > 0)
                            dropIndex--;
                        collection.Insert(dropIndex, record);

                    }
                    else
                    {
                        dropIndex++;
                        collection.Insert(dropIndex, record);

                    }
                    if (treeViewNode.Level == 0)
                        (AssociatedObject.sfTreeView.ItemsSource as ObservableCollection<EmployeeInfo>).Remove(record as EmployeeInfo);
                    else
                        ((treeViewNode.ParentNode.Content as EmployeeInfo).Children as ObservableCollection<EmployeeInfo>).Remove(treeViewNode.Content as EmployeeInfo);
                    e.Handled = true;
                } 
            } 
        } 

        private void TreeView_ItemDropping(object sender, TreeViewItemDroppingEventArgs e)
        {
            var dragSource = e.DragSource as SfTreeView;
            var dropSource = sender as SfTreeView;
            IList sourceCollection = null;
            TreeViewNode parentNode = null;

            if (dragSource == null || (dragSource != dropSource))
            {
                var draggingRecord = e.Data.GetData("Records") as ObservableCollection<object>;
                var record = draggingRecord[0] as EmployeeInfo;
                var dropPosition = e.DropPosition.ToString();
                var newItem = new EmployeeInfo();

                if (e.TargetNode != null)
                {
                    var itemInfo = AssociatedObject.sfTreeView.GetItemInfo(e.TargetNode.Content);
                    int rowIndex = (int)itemInfo.ItemIndex;
                    if (dropPosition != "None" && rowIndex != -1)
                    {
                        var treeViewNode = AssociatedObject.sfTreeView.GetNodeAtRowIndex(rowIndex);

                        if (treeViewNode == null)
                            return;
                        var data = treeViewNode.Content;
                        var itemIndex = -1;

                        if (dropPosition == "DropBelow" || dropPosition == "DropAbove")
                        {
                            parentNode = treeViewNode.ParentNode;
                            newItem = new EmployeeInfo() { FirstName = record.FirstName, LastName = record.LastName, Title = record.Title, Children = record.Children, ID = record.ID, Salary = record.Salary};
                        }

                        else if (dropPosition == "DropAsChild")
                        {
                            if (!treeViewNode.IsExpanded)
                                AssociatedObject.sfTreeView.ExpandNode(treeViewNode);
                            parentNode = treeViewNode;
                            var parentkey = parentNode.Content as EmployeeInfo;
                            newItem = new EmployeeInfo() { FirstName = record.FirstName, LastName = record.LastName, Title = record.Title, Children = record.Children, ID = record.ID, Salary = record.Salary};
                        }
                        if (dropPosition == "DropBelow" || dropPosition == "DropAbove")
                        {
                            if (treeViewNode.ParentNode != null)
                            {
                                IEnumerable collection = null;
                                if (AssociatedObject.sfTreeView.HierarchyPropertyDescriptors != null && AssociatedObject.sfTreeView.HierarchyPropertyDescriptors.Count > 0)
                                {
                                    foreach (var propertyDescriptor in AssociatedObject.sfTreeView.HierarchyPropertyDescriptors)
                                    {
                                        if (propertyDescriptor.TargetType == treeViewNode.ParentNode.Content.GetType())
                                        {
                                            var descriptors = TypeDescriptor.GetProperties(treeViewNode.ParentNode.Content.GetType());
                                            var tempItem = descriptors.Find(AssociatedObject.sfTreeView.ChildPropertyName, true);
                                            if (tempItem != null)
                                                collection = tempItem.GetValue(treeViewNode.ParentNode.Content) as IEnumerable;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    var descriptors = TypeDescriptor.GetProperties(treeViewNode.ParentNode.Content.GetType());
                                    var tempItem = descriptors.Find(AssociatedObject.sfTreeView.ChildPropertyName, true);
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
                                var tempItem = descriptors.Find(AssociatedObject.sfTreeView.ChildPropertyName, true);
                                if (tempItem != null)
                                    collection = tempItem.GetValue(treeViewNode.Content) as IEnumerable;
                                if (collection != null)
                                    sourceCollection = GetSourceListCollection(collection);
                            }

                            if (sourceCollection == null)
                            {
                                var type = data.GetType().GetProperty(AssociatedObject.sfTreeView.ChildPropertyName).PropertyType;
                                var paramExp = System.Linq.Expressions.Expression.Parameter(type, type.Name);
                                var instance = System.Linq.Expressions.Expression.MemberInit(System.Linq.Expressions.Expression.New(type), new List<MemberBinding>());
                                var lambda = System.Linq.Expressions.Expression.Lambda(instance, paramExp);
                                var delg = lambda.Compile();
                                var list = delg.DynamicInvoke(new object[] { null }) as IList;

                                if (list != null)
                                {
                                    var tempitem = descriptors.Find(AssociatedObject.sfTreeView.ChildPropertyName, true);
                                    tempitem.SetValue(treeViewNode.Content, list);
                                    sourceCollection = list;
                                }
                                itemInfo.Node.PopulateChildNodes(sourceCollection);
                            }
                            itemIndex = sourceCollection.Count;
                        }
                        sourceCollection.Insert(itemIndex, newItem);
                        (AssociatedObject.sfDataGrid.ItemsSource as ObservableCollection<EmployeeInfo>).Remove(record as EmployeeInfo);
                        e.Handled = true;

                    }
                }
                else
                {
                    sourceCollection = GetSourceListCollection(null);
                    sourceCollection.Insert(0, record);
                    (AssociatedObject.sfDataGrid.ItemsSource as ObservableCollection<EmployeeInfo>).Remove(record as EmployeeInfo);
                }
            }
        }

        // <summary>
        /// Gets the source collection of TreeGrid
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private IList GetSourceListCollection(IEnumerable collection)
        {
            IList list = null;
            if (collection == null)
            {
                collection = AssociatedObject.sfTreeView.ItemsSource as IEnumerable;
            }
            if ((collection as IList) != null)
            {
                list = collection as IList;
            }
            return list;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            this.AssociatedObject.sfTreeView.ItemDropping -= TreeView_ItemDropping;
            this.AssociatedObject.sfDataGrid.RowDragDropController.Drop -= RowDragDropController_Drop;
            base.OnDetaching();
        }
    }
}
