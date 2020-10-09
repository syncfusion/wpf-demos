#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.Model;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class SfDiagram_Binding_With_TreeView_ViewModel : DiagramViewModel
    {
        #region field

        private ObservableCollection<Items> _datas;
        private ICommand _addnode;
        private ICommand _deletenode;
        private Items _selecteditem;
        int newid = 18;

        #endregion

        #region Property and Command
        public Items SelectedItem
        {
            get
            {
                return _selecteditem;
            }
            set
            {
                if (_selecteditem != value)
                {
                    _selecteditem = value;
                    OnPropertyChanged("SelectedItem");
                    SelectedItemChanged(value);
                }
            }
        }

        public ICommand AddNode
        {
            get { return _addnode; }
            set { _addnode = value; }
        }

        public ICommand DeleteNode
        {
            get { return _deletenode; }
            set { _deletenode = value; }
        }

        public ObservableCollection<Items> Datas
        {
            get
            {
                return _datas;
            }
            set
            {
                if (_datas != value)
                {
                    _datas = value;
                    OnPropertyChanged("Datas");
                }
            }
        }

        #endregion

        #region Constructor
        public SfDiagram_Binding_With_TreeView_ViewModel()
        {
            #region Commands

            AddNode = new DelegateCommand(OnAddNode);
            DeleteNode = new DelegateCommand(OnDeleteNode);
            ItemAddedCommand = new DelegateCommand(OnItemAdded);
            ItemDeletingCommand = new DelegateCommand(OnItemDeleting);
            ItemSelectedCommand = new DelegateCommand(OnItemSelected);

            #endregion

            #region Initialize Properties      

            Tool = Tool.SingleSelect;

            Datas = new ObservableCollection<Items>()
            {
                new Items() { Name = "Plant Manager", ID = 1, SubItems = new ObservableCollection<Items>()
                {
                    new Items() { Name = "Production Manager", ID = 2, ParentID = 1, SubItems = new ObservableCollection<Items>()
                    {
                        new Items() { Name = "Control Room", ID = 3, ParentID = 2, SubItems = new ObservableCollection<Items>()
                        {
                            new Items() { Name = "Foreman1", ID = 4, ParentID = 3, SubItems = new ObservableCollection<Items>()
                            {
                                new Items() { Name = "Craft Personnel5", ID = 5, ParentID = 4 },
                                new Items() { Name = "Craft Personnel6", ID = 6, ParentID = 4 }, },
                            }, },
                        },
                        new Items() { Name = "Plant Operator", ID = 7, ParentID = 2, SubItems = new ObservableCollection<Items>()
                        {
                            new Items() { Name = "Foreman2", ID = 8, ParentID = 7, SubItems = new ObservableCollection<Items>()
                            {
                                new Items() { Name = "Craft Personnel7", ID = 9, ParentID = 8 }, },
                            }, },
                        }, },
                    },
                    new Items() { Name = "Administrative Officer", ID = 10, ParentID = 1 },
                    new Items() { Name = "Maintenance Manager", ID = 11, ParentID=1, SubItems = new ObservableCollection<Items>()
                    {
                        new Items() { Name = "Electrical Supervisor", ID = 12, ParentID = 11, SubItems = new ObservableCollection<Items>()
                        {
                            new Items() { Name = "Craft Personnel1", ID = 13, ParentID = 12 },
                            new Items() { Name = "Craft Personnel2", ID = 14, ParentID = 12 }, },
                        },
                        new Items() { Name = "Mechanical Supervisor", ID=15, ParentID = 11, SubItems = new ObservableCollection<Items>()
                        {
                            new Items() { Name = "Craft Personnel3", ID = 16, ParentID = 15 },
                            new Items() { Name = "Craft Personnel4", ID = 17, ParentID = 15 }, },
                        },
                    },},
                },},
            };

            DefaultConnectorType = ConnectorType.Orthogonal;

            PageSettings = new PageSettings()
            {
                PageBackground = new SolidColorBrush(Colors.Transparent),
                PageBorderBrush = new SolidColorBrush(Colors.Transparent),
            };

            SelectedItems = new SelectorViewModel()
            {
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.QuickCommands & ~SelectorConstraints.Rotator & ~SelectorConstraints.Tooltip & ~SelectorConstraints.Pivot,
            };

            LayoutManager = new Syncfusion.UI.Xaml.Diagram.Layout.LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    HorizontalSpacing = 20,
                    VerticalSpacing = 40,
                    Orientation = TreeOrientation.TopToBottom,
                    Type = LayoutType.Hierarchical,
                },
                RefreshFrequency = RefreshFrequency.ArrangeParsing,
            };

            DataSourceSettings = new DataSourceSettings()
            {
                Id = "ID",
                ParentId = "ParentID",
                DataSource = GetData(Datas),
            };

            #endregion

        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Method to set the Annotations as null for Nodes
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemAdded(object obj)
        {
            var args = obj as ItemAddedEventArgs;
            if (args.Item is NodeViewModel)
            {
                (args.Item as NodeViewModel).Annotations = null;
                var resourceDictionary = new ResourceDictionary()
                {
                    Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
                };
                (args.Item as NodeViewModel).Shape = resourceDictionary["Rectangle"];
            }
        }

        /// <summary>
        /// Method to get the SelectedItem
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemSelected(object obj)
        {
            var args = obj as ItemSelectedEventArgs;
            if (args.Item is NodeViewModel)
            {
                SelectedItem = (args.Item as NodeViewModel).Content as Items;
                ((args.Item as NodeViewModel).Info as INodeInfo).BringIntoViewport();
            }
        }

        /// <summary>
        /// Method to delete the Successors
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemDeleting(object obj)
        {
            var args = obj as ItemDeletingEventArgs;
            args.DeleteSuccessors = true;
        }

        /// <summary>
        /// Method to change the selected item based on the items selected in TreeViewAdv
        /// </summary>
        /// <param name="value"></param>
        private void SelectedItemChanged(Items value)
        {
            if ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object> != null)
            {
                if (((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0)
                {
                    NodeViewModel node = ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).First() as NodeViewModel;
                    if (value as Items != node.Content as Items)
                    {
                        foreach (NodeViewModel nodes in Nodes as NodeCollection)
                        {
                            if (nodes.Content as Items == value)
                            {
                                node.IsSelected = false;
                                nodes.IsSelected = true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (NodeViewModel nodes in Nodes as NodeCollection)
                    {
                        if (nodes.Content as Items == value)
                        {
                            nodes.IsSelected = true;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Method to delete the selected node and remove the selected item from TreeViewAdv
        /// </summary>
        /// <param name="obj"></param>
        private void OnDeleteNode(object obj)
        {
            if ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object> != null && ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0)
            {
                NodeViewModel node = ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).First() as NodeViewModel;
                Items item = node.Content as Items;
                Items items = Datas[0];
                if (item == items)
                {
                    (Info as IGraphInfo).Commands.Delete.Execute(node);
                    Datas.Remove(items);
                }
                else
                {
                    RemoveItem(items, item, node);
                }
            }
        }

        /// <summary>
        /// Method to remove the item.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="item"></param>
        /// <param name="node"></param>
        private void RemoveItem(Items items, Items item, NodeViewModel node)
        {
            if (items != null && items.SubItems != null)
            {
                int items_subitems_count = items.SubItems.Count;
                for (int i = 0; i < items_subitems_count; i++)
                {
                    var subitem = items.SubItems[i];
                    if (subitem == item)
                    {
                        (Info as IGraphInfo).Commands.Delete.Execute(node);
                        items.SubItems.Remove(subitem);
                        break;
                    }
                    else
                    {
                        RemoveItem(subitem, item, node);
                    }
                }
            }
        }

        /// <summary>
        /// Method to Add new node in SfDiagram and TreeViewAdv
        /// </summary>
        /// <param name="obj"></param>
        private void OnAddNode(object obj)
        {
            if ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object> != null && ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 0)
            {
                NodeViewModel node = ((SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).First() as NodeViewModel;
                Items item = node.Content as Items;
                Items NewData = new Items() { Name = "New Node", ID = newid, ParentID = item.ID, };
                if (item.SubItems != null)
                {
                    (item.SubItems as ObservableCollection<Items>).Add(NewData);
                    (DataSourceSettings.DataSource as ObservableCollection<Items>).Add(item.SubItems.Last());
                    newid++;

                }
                else
                {
                    item.SubItems = new ObservableCollection<Items>()
                    {
                        NewData,
                    };
                    (DataSourceSettings.DataSource as ObservableCollection<Items>).Add(item.SubItems.Last());
                    newid++;
                }
            }
        }

        /// <summary>
        /// Method to create a datasource based on the itemsource of TreeViewAdv
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        private ObservableCollection<Items> GetData(ObservableCollection<Items> datas)
        {
            ObservableCollection<Items> data = new ObservableCollection<Items>();
            data.Add(datas[0]);
            if (datas[0].SubItems != null)
            {
                AddData(datas[0], data);
            }
            return data;
        }

        private void AddData(Items items, ObservableCollection<Items> data)
        {
            if (items.SubItems != null)
            {
                foreach (Items item in items.SubItems)
                {
                    if (item.SubItems == null)
                    {
                        data.Add(item);
                    }
                    else
                    {
                        data.Add(item);
                        AddData(item, data);
                    }
                }
            }
        }

        #endregion
    }
}
