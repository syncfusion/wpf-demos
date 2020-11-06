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
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class MindMapViewModel : DiagramViewModel
    {
        #region fields, properties and command

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };

        public ICommand _AddLeftCommand;
        public ICommand _AddRightCommand;
        public ICommand _DeleteCommand;

        public ICommand AddLeftCommand
        {
            get { return _AddLeftCommand; }
            set { _AddLeftCommand = value; }
        }

        public ICommand AddRightCommand
        {
            get { return _AddRightCommand; }
            set { _AddRightCommand = value; }
        }

        public ICommand DeleteCommand
        {
            get { return _DeleteCommand; }
            set { _DeleteCommand = value; }
        }

        #endregion

        #region constructor

        public MindMapViewModel()
        {
            this.Tool = Tool.SingleSelect;
            this.Nodes = new NodeCollection();
            this.Connectors = new ObservableCollection<CustomMindMapConnector>();
            this.DefaultConnectorType = ConnectorType.CubicBezier;
            this.DataSourceSettings = new DataSourceSettings()
            {
                DataSource = this.GetEmployeeCollection(),
                ParentId = "ParentId",
                Id = "EmpId"
            };
            this.LayoutManager = new LayoutManager()
            {
                Layout = new SfMindMapTreeLayout()
                {
                    HorizontalSpacing = 50,
                    VerticalSpacing = 30,
                    Orientation = Orientation.Horizontal,
                    SplitMode = MindMapTreeMode.Custom
                },
                RefreshFrequency = RefreshFrequency.ArrangeParsing
            };

            SelectedItems = new SelectorViewModel()
            {
                Commands = null,
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.Rotator & ~SelectorConstraints.Resizer &~ SelectorConstraints.Pivot,
            };

            ItemAddedCommand = new DelegateCommand(OnItemAdded);
            ItemSelectedCommand = new DelegateCommand(OnItemSelected);
            ItemDeletingCommand = new DelegateCommand(OnItemDeleting);
            NodeChangedCommand = new DelegateCommand(OnNodeChanged);
            AddLeftCommand = new DelegateCommand(OnAddLeftChild);
            AddRightCommand = new DelegateCommand(OnAddRightChild);
            DeleteCommand = new DelegateCommand(OnItemDelete);
        }

        #endregion

        #region Helper Methods

        private void OnNodeChanged(object obj)
        {
            var args = obj as ChangeEventArgs<object,NodeChangedEventArgs>;
            if(args.NewValue.InteractionState == NodeChangedInteractionState.Dragged)
            {
                this.LayoutManager.Layout.InvalidateLayout();
            }

        }

        private void OnItemDeleting(object obj)
        {
            var args = obj as ItemDeletingEventArgs;
            var item = args.Item as NodeViewModel;
            if (item != null && (item.Content as MindmapEmployee).ParentId != null)
            {
                args.DeleteDependentConnector = true;
                args.DeleteSuccessors = true;
            }
            else
            {
                args.Cancel = true;
            }
        }

        public MindmapEmployees GetEmployeeCollection()
        {
            var employees = new MindmapEmployees();
            employees.Add(GetEmployee("1", "Business Planning", "#034d6d"));
            employees.Add(GetEmployee("2", "Requirements", "#1b80c6", "1", RootChildDirection.Left));
            employees.Add(GetEmployee("3", "Budgets", "#1b80c6", "1", RootChildDirection.Left));
            employees.Add(GetEmployee("4", "Director", "#3dbfc9", "2", RootChildDirection.Left));
            employees.Add(GetEmployee("5", "Accounts Department", "#3dbfc9", "2", RootChildDirection.Left));
            employees.Add(GetEmployee("6", "Administration", "#3dbfc9", "2", RootChildDirection.Left));
            employees.Add(GetEmployee("7", "Development", "#3dbfc9", "2", RootChildDirection.Left));
            employees.Add(GetEmployee("8", "Estimation", "#3dbfc9", "3", RootChildDirection.Left));
            employees.Add(GetEmployee("9", "Profit", "#3dbfc9", "3", RootChildDirection.Left));
            employees.Add(GetEmployee("10", "Funds", "#3dbfc9", "3", RootChildDirection.Left));
            employees.Add(GetEmployee("11", "Expectation", "#1b80c6", "1", RootChildDirection.Right));
            employees.Add(GetEmployee("12", "Marketing", "#1b80c6", "1", RootChildDirection.Right));
            employees.Add(GetEmployee("13", "Situation in Market", "#1b80c6", "1", RootChildDirection.Right));
            employees.Add(GetEmployee("14", "Product Sales", "#3dbfc9", "11", RootChildDirection.Right));
            employees.Add(GetEmployee("15", "Strategy", "#3dbfc9", "11", RootChildDirection.Right));
            employees.Add(GetEmployee("16", "Contacts", "#3dbfc9", "11", RootChildDirection.Right));
            employees.Add(GetEmployee("17", "Customer Groups", "#3dbfc9", "12", RootChildDirection.Right));
            employees.Add(GetEmployee("18", "Branding", "#3dbfc9", "12", RootChildDirection.Right));
            employees.Add(GetEmployee("19", "Advertising", "#3dbfc9", "12", RootChildDirection.Right));
            employees.Add(GetEmployee("20", "Competitors", "#3dbfc9", "13", RootChildDirection.Right));
            employees.Add(GetEmployee("21", "Location", "#3dbfc9", "13", RootChildDirection.Right));
            return employees;
        }

        public MindmapEmployee GetEmployee(string id, string name, string color, string parent = default(string), RootChildDirection direction = RootChildDirection.Left)
        {
            return new MindmapEmployee()
            {
                EmpId = id,
                Name = name,
                Color = color,
                ParentId = parent,
                Direction = direction
            };
        }

        private void OnItemDelete(object obj)
        {
            (this.Info as IGraphInfo).Commands.Delete.Execute(null);
        }

        private void OnAddRightChild(object obj)
        {
            if (this.SelectedItems is SelectorViewModel sv)
            {
                if (sv.Nodes is ObservableCollection<object> nodes && nodes.Any())
                {
                    var employee = new MindmapEmployee()
                    {
                        EmpId = Guid.NewGuid().ToString(),
                        Name = "New Child",
                        ParentId = ((nodes.First() as NodeViewModel).Content as MindmapEmployee).EmpId,
                        Direction = RootChildDirection.Right
                    };
                    var layout = this.LayoutManager.Layout as SfMindMapTreeLayout;
                    var node = nodes.First() as NodeViewModel;
                    if (node == layout.LayoutRoot)
                    {
                        employee.Color = "#1b80c6";
                    }
                    else
                    {
                        employee.Color = "#3dbfc9";
                    }
                    (this.DataSourceSettings.DataSource as MindmapEmployees).Add(employee);
                    this.LayoutManager.Layout.InvalidateLayout();
                }
            }
        }

        private void OnAddLeftChild(object obj)
        {
            if (this.SelectedItems is SelectorViewModel sv)
            {
                if (sv.Nodes is ObservableCollection<object> nodes && nodes.Any())
                {
                    var employee = new MindmapEmployee()
                    {
                        EmpId = Guid.NewGuid().ToString(),
                        Name = "New Child",
                        ParentId = ((nodes.First() as NodeViewModel).Content as MindmapEmployee).EmpId,
                        Direction = RootChildDirection.Left
                    }; 
                    var layout = this.LayoutManager.Layout as SfMindMapTreeLayout;
                    var node = nodes.First() as NodeViewModel;
                    if (node == layout.LayoutRoot)
                    {
                        employee.Color = "#1b80c6";
                    }
                    else
                    {
                        employee.Color = "#3dbfc9";
                    }
                    (this.DataSourceSettings.DataSource as MindmapEmployees).Add(employee);
                    this.LayoutManager.Layout.InvalidateLayout();
                }
            }
        }

        private void OnItemSelected(object obj)
        {
            var args = obj as ItemSelectedEventArgs;

            if (this.SelectedItems is SelectorViewModel)
            {
                SelectorViewModel sv = this.SelectedItems as SelectorViewModel;
                if (sv.Nodes is ObservableCollection<object> nodes && nodes.Any())
                {
                    var layout = this.LayoutManager.Layout as SfMindMapTreeLayout;
                    var node = nodes.First() as NodeViewModel;
                    if (node == layout.LayoutRoot)
                    {
                        (this.SelectedItems as SelectorViewModel).Commands = new QuickCommandCollection()
                        {
                            new QuickCommandViewModel()
                            {
                                Shape = resourceDictionary["Ellipse"],
                                OffsetX = 0,
                                OffsetY = 0.5,
                                Command = AddLeftCommand,
                                Content = "M4.0000001,0 L6,0 6,4.0000033 10,4.0000033 10,6.0000033 6,6.0000033 6,10 4.0000001,10 4.0000001,6.0000033 0,6.0000033 0,4.0000033 4.0000001,4.0000033 z",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Margin = new Thickness(-20,0,0,0),
                            },

                            new QuickCommandViewModel()
                            {
                                Shape = resourceDictionary["Ellipse"],
                                OffsetX = 1,
                                OffsetY = 0.5,
                                Command = AddRightCommand,
                                Content = "M4.0000001,0 L6,0 6,4.0000033 10,4.0000033 10,6.0000033 6,6.0000033 6,10 4.0000001,10 4.0000001,6.0000033 0,6.0000033 0,4.0000033 4.0000001,4.0000033 z",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Margin = new Thickness(20,0,0,0),
                            }
                        };
                    }
                    else
                    {
                        if (layout.Orientation == Orientation.Horizontal)
                        {
                            if (node.OffsetX < (layout.LayoutRoot as INode).OffsetX)
                            {
                                (this.SelectedItems as SelectorViewModel).Commands = new QuickCommandCollection()
                                {
                                    new QuickCommandViewModel()
                                    {
                                        Shape = resourceDictionary["Ellipse"],
                                        OffsetX = 0,
                                        OffsetY = 0.5,
                                        Command = AddLeftCommand,
                                        Content = "M4.0000001,0 L6,0 6,4.0000033 10,4.0000033 10,6.0000033 6,6.0000033 6,10 4.0000001,10 4.0000001,6.0000033 0,6.0000033 0,4.0000033 4.0000001,4.0000033 z",
                                        HorizontalAlignment = HorizontalAlignment.Center,
                                        VerticalAlignment = VerticalAlignment.Center,
                                        Margin = new Thickness(-20,0,0,0),
                                    },
                                    
                                    new QuickCommandViewModel()
                                    {
                                        Shape = resourceDictionary["Ellipse"],
                                        OffsetX = 1,
                                        OffsetY = 0.5,
                                        Command = DeleteCommand,
                                        Content = "M1.0000023,3 L7.0000024,3 7.0000024,8.75 C7.0000024,9.4399996 6.4400025,10 5.7500024,10 L2.2500024,10 C1.5600024,10 1.0000023,9.4399996 1.0000023,8.75 z M2.0699998,0 L5.9300004,0 6.3420029,0.99999994 8.0000001,0.99999994 8.0000001,2 0,2 0,0.99999994 1.6580048,0.99999994 z",
                                        HorizontalAlignment = HorizontalAlignment.Center,
                                        VerticalAlignment = VerticalAlignment.Center,
                                        Margin = new Thickness(20,0,0,0),
                                    }
                                };
                            }
                            else
                            {
                                (this.SelectedItems as SelectorViewModel).Commands = new QuickCommandCollection()
                                {
                                    new QuickCommandViewModel()
                                    {
                                        Shape = resourceDictionary["Ellipse"],
                                        OffsetX = 1,
                                        OffsetY = 0.5,
                                        Command = AddRightCommand,
                                        Content = "M4.0000001,0 L6,0 6,4.0000033 10,4.0000033 10,6.0000033 6,6.0000033 6,10 4.0000001,10 4.0000001,6.0000033 0,6.0000033 0,4.0000033 4.0000001,4.0000033 z",
                                        HorizontalAlignment = HorizontalAlignment.Center,
                                        VerticalAlignment = VerticalAlignment.Center,
                                        Margin = new Thickness(20,0,0,0),
                                    },
                                    
                                    new QuickCommandViewModel()
                                    {
                                        Shape = resourceDictionary["Ellipse"],
                                        OffsetX = 0,
                                        OffsetY = 0.5,
                                        Command = DeleteCommand,
                                        Content = "M1.0000023,3 L7.0000024,3 7.0000024,8.75 C7.0000024,9.4399996 6.4400025,10 5.7500024,10 L2.2500024,10 C1.5600024,10 1.0000023,9.4399996 1.0000023,8.75 z M2.0699998,0 L5.9300004,0 6.3420029,0.99999994 8.0000001,0.99999994 8.0000001,2 0,2 0,0.99999994 1.6580048,0.99999994 z",
                                        HorizontalAlignment = HorizontalAlignment.Center,
                                        VerticalAlignment = VerticalAlignment.Center,
                                        Margin = new Thickness(-20,0,0,0),
                                    }
                                };
                            }
                        }
                        else
                        {
                            if (node.OffsetY < (layout.LayoutRoot as INode).OffsetY)
                            {
                                (this.SelectedItems as SelectorViewModel).Commands = new QuickCommandCollection()
                                {
                                    new QuickCommandViewModel()
                                    {
                                        Shape = resourceDictionary["Ellipse"],
                                        OffsetX = 0,
                                        OffsetY = 0.5,
                                        Command = AddLeftCommand,
                                        Content = "M4.0000001,0 L6,0 6,4.0000033 10,4.0000033 10,6.0000033 6,6.0000033 6,10 4.0000001,10 4.0000001,6.0000033 0,6.0000033 0,4.0000033 4.0000001,4.0000033 z",
                                        HorizontalAlignment = HorizontalAlignment.Center,
                                        VerticalAlignment = VerticalAlignment.Center,
                                        Margin = new Thickness(-20,0,0,0),
                                    },

                                    new QuickCommandViewModel()
                                    {
                                        Shape = resourceDictionary["Ellipse"],
                                        OffsetX = 1,
                                        OffsetY = 0.5,
                                        Command = DeleteCommand,
                                        Content = "M1.0000023,3 L7.0000024,3 7.0000024,8.75 C7.0000024,9.4399996 6.4400025,10 5.7500024,10 L2.2500024,10 C1.5600024,10 1.0000023,9.4399996 1.0000023,8.75 z M2.0699998,0 L5.9300004,0 6.3420029,0.99999994 8.0000001,0.99999994 8.0000001,2 0,2 0,0.99999994 1.6580048,0.99999994 z",
                                        HorizontalAlignment = HorizontalAlignment.Center,
                                        VerticalAlignment = VerticalAlignment.Center,
                                        Margin = new Thickness(20,0,0,0),
                                    }
                                };
                            }
                            else
                            {
                                (this.SelectedItems as SelectorViewModel).Commands = new QuickCommandCollection()
                                {
                                    new QuickCommandViewModel()
                                    {
                                        Shape = resourceDictionary["Ellipse"],
                                        OffsetX = 1,
                                        OffsetY = 0.5,
                                        Command = AddRightCommand,
                                        Content = "M4.0000001,0 L6,0 6,4.0000033 10,4.0000033 10,6.0000033 6,6.0000033 6,10 4.0000001,10 4.0000001,6.0000033 0,6.0000033 0,4.0000033 4.0000001,4.0000033 z",
                                        HorizontalAlignment = HorizontalAlignment.Center,
                                        VerticalAlignment = VerticalAlignment.Center,
                                        Margin = new Thickness(20,0,0,0),
                                    },

                                    new QuickCommandViewModel()
                                    {
                                        Shape = resourceDictionary["Ellipse"],
                                        OffsetX = 0,
                                        OffsetY = 0.5,
                                        Command = DeleteCommand,
                                        Content = "M1.0000023,3 L7.0000024,3 7.0000024,8.75 C7.0000024,9.4399996 6.4400025,10 5.7500024,10 L2.2500024,10 C1.5600024,10 1.0000023,9.4399996 1.0000023,8.75 z M2.0699998,0 L5.9300004,0 6.3420029,0.99999994 8.0000001,0.99999994 8.0000001,2 0,2 0,0.99999994 1.6580048,0.99999994 z",
                                        HorizontalAlignment = HorizontalAlignment.Center,
                                        VerticalAlignment = VerticalAlignment.Center,
                                        Margin = new Thickness(-20,0,0,0),
                                    }
                                };
                            }
                        }
                    }
                }
            }
        }

        private void OnItemAdded(object obj)
        {
            var args = obj as ItemAddedEventArgs;

            if (args.Item != null && args.Item is NodeViewModel && args.ItemSource == ItemSource.ClipBoard)
            {
                (args.Item as NodeViewModel).IsSelected = true;
                (this.Info as IGraphInfo).Commands.Delete.Execute(null);
            }
            if (args.Item != null && args.Item is NodeViewModel && args.ItemSource != ItemSource.ClipBoard)
            {
                (args.Item as NodeViewModel).Annotations = null;
            }
        }

        #endregion
    }

    public class CustomMindMapConnector : ConnectorViewModel
    {
        public CustomMindMapConnector()
        {
            Constraints = ConnectorConstraints.Default & ~ConnectorConstraints.Selectable;
            Annotations = null;
        }
    }

    public class SfMindMapTreeLayout : MindMapTreeLayout
    {
        protected override RootChildDirection GetRootChildDirection(INode node)
        {
            if (node.Content is MindmapEmployee)
            {
                return (node.Content as MindmapEmployee).Direction;
            }

            return base.GetRootChildDirection(node);
        }
    }

    public class MindMapOrientation : ObservableCollection<Orientation>
    {
        public MindMapOrientation() : base()
        {
            this.Add(Orientation.Horizontal);
            this.Add(Orientation.Vertical);
        }
    }

    public class MindMapSplitMode : ObservableCollection<MindMapTreeMode>
    {
        public MindMapSplitMode() : base()
        {
            this.Add(MindMapTreeMode.RootChildrenCount);
            this.Add(MindMapTreeMode.TreeNodesCount);
            this.Add(MindMapTreeMode.Level);
            this.Add(MindMapTreeMode.Area);
            this.Add(MindMapTreeMode.Custom);
        }
    }
}
