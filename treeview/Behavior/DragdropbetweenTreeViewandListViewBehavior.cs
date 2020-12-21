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
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;
using System.Windows.Media;
using Syncfusion.UI.Xaml.TreeView;
using Syncfusion.UI.Xaml.TreeView.Engine;
using Syncfusion.UI.Xaml.TreeView.Helpers;

namespace syncfusion.treeviewdemos.wpf
{
    /// <summary>
    /// Describes the DragDropBehavior
    /// </summary>
   public class DragDropBetweenTreeViewAndListViewBehavior : Behavior<DragDropBetweenTreeViewAndListViewDemo>
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
            this.AssociatedObject.listView.PreviewMouseMove += ListView_PreviewMouseMove;
            this.AssociatedObject.listView.Drop += ListView_Drop;
            this.AssociatedObject.treeView.ItemDropping += TreeView_ItemDropping;
        }

        private void TreeView_ItemDropping(object sender, TreeViewItemDroppingEventArgs e)
        {
            var dragSource = e.DragSource as SfTreeView;
            var dropSource = sender as SfTreeView;
            IList sourceCollection = null;

            if (dragSource == null || (dragSource != dropSource))
            {
                var item = e.Data.GetData("ListViewRecords") as ObservableCollection<object>;
                var record = item[0] as Folder;
                var dropPosition = e.DropPosition.ToString();
                var folderData = new Folder();
                var fileData = new File();

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
                                folderData = new Folder() { FileName = record.FileName, ImageIcon = record.ImageIcon };
                            else
                            {
                                fileData = new File() { FileName = record.FileName, ImageIcon = record.ImageIcon };
                            }
                        }

                        else if (dropPosition == "DropAsChild")
                        {
                            if (!treeViewNode.IsExpanded)
                                AssociatedObject.treeView.ExpandNode(treeViewNode);
                            parentNode = treeViewNode;
                            if (treeViewNode.Level == 0)
                            {
                                fileData = new File() { FileName = record.FileName , ImageIcon = record.ImageIcon};
                            } 
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
                            if (parentNode != null && parentNode.IsExpanded)
                            { 
                                IEnumerable collection = null;
                                var tempItem = descriptors.Find(AssociatedObject.treeView.ChildPropertyName, true);
                                if (tempItem != null)
                                    collection = tempItem.GetValue(treeViewNode.Content) as IEnumerable;

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
                            }
                            itemIndex = sourceCollection.Count;
                        }

                        if (parentNode != null)
                            sourceCollection.Insert(itemIndex, fileData);
                        else
                            sourceCollection.Insert(itemIndex, folderData);

                        (AssociatedObject.listView.ItemsSource as ObservableCollection<Folder>).Remove(record as Folder);
                        e.Handled = true;
                    }                    
                }
                else
                {
                    sourceCollection = GetSourceListCollection(null);
                    sourceCollection.Insert(0, record);
                    (AssociatedObject.listView.ItemsSource as ObservableCollection<Folder>).Remove(record as Folder);
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
                collection = AssociatedObject.treeView.ItemsSource as IList;//.GetSourceCollection();
            if ((collection as IList) != null)
            {
                list = collection as IList;
            }
            return list;
        }
        List<Folder> list = new List<Folder>();


        /// <summary>
        /// Handle the Drop event of ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_Drop(object sender, DragEventArgs e)
        {
            ObservableCollection<TreeViewNode> treeNodes = new ObservableCollection<TreeViewNode>();
            if (e.Data.GetDataPresent("Nodes"))
                treeNodes = e.Data.GetData("Nodes") as ObservableCollection<TreeViewNode>;

            if (treeNodes.Count == 0 || treeNodes == null)
                return;

            foreach (var node in treeNodes)
            {
                if (node.Content is File)
                {
                    ((node.ParentNode.Content as Folder).Files as ObservableCollection<File>).Remove(node.Content as File);
                }
                else
                    (AssociatedObject.treeView.ItemsSource as ObservableCollection<Folder>).Remove(node.Content as Folder);
                if (node.HasChildNodes)
                {
                    list.Add(node.Content as Folder);
                    GetChildNodes(node);
                }
                else
                {
                    if (node.Content is Folder)
                        list.Add(node.Content as Folder);
                    else
                        list.Add(new Folder() { FileName = (node.Content as File).FileName, ImageIcon = (node.Content as File).ImageIcon });
                }
            }

            foreach (var listItem in list)
            {
                (this.AssociatedObject.DataContext as FileManagerViewModel).ListViewCollection.Add(listItem);
            }
            list.Clear();
        }

        /// <summary>
        /// Get the child nodes from parent node
        /// </summary>
        /// <param name="node"></param>
        private void GetChildNodes(TreeViewNode node)
        {
            foreach (var childNode in node.ChildNodes)
            {
                if (childNode.Content is Folder)
                    list.Add(childNode.Content as Folder);
                else
                    list.Add(new Folder() { FileName = (childNode.Content as File).FileName, ImageIcon = (childNode.Content as File).ImageIcon });
                GetChildNodes(childNode);
            }
        }

        /// <summary>
        /// Descrides the PreviewMouseMove event of ListView and start the drag operaion of ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                ListView listview = sender as ListView;
                var records = new ObservableCollection<object>();
                object data = GetDataFromListBox(listview, e.GetPosition(listview));

                records.Add(data);

                var dataObject = new DataObject();
                dataObject.SetData("ListViewRecords", records);
                dataObject.SetData("ListView", this.AssociatedObject.listView);

                
                if (data != null)
                {
                    DragDrop.DoDragDrop(listview, dataObject, DragDropEffects.Move);
                }
            }
            e.Handled = true;
        }
        /// <summary>
        /// Get the data from list box control
        /// </summary>
        /// <param name="source"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private static object GetDataFromListBox(ListBox listView, Point point)
        {
            UIElement element = listView.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = listView.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }
                    if (element == listView)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
        }
        /// <summary>
        /// Initialize the OnDetaching method
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            this.AssociatedObject.listView.PreviewMouseMove -= ListView_PreviewMouseMove;
            this.AssociatedObject.listView.Drop -= ListView_Drop;
            this.AssociatedObject.treeView.ItemDropping -= TreeView_ItemDropping;
        }
    }

 }
