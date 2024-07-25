#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Theming;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace syncfusion.diagrambuilder.wpf.BPMN
{
    public class BPMNDiagramVM : DiagramViewModel
    {
        private ICommand _MenuOpenCommand;
        public ICommand MenuOpenCommand
        {
            get { return _MenuOpenCommand; }
            set { _MenuOpenCommand = value; }
        }

        public BPMNDiagramVM()
        {
            this.Nodes = new ObservableCollection<NodeViewModel>();
            this.Connectors = new ObservableCollection<BpmnFlowViewModel>();
            this.Groups = new ObservableCollection<GroupViewModel>();
            this.PageSettings = new PageSettings();
            this.HorizontalRuler = new Ruler();
            this.VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            this.PrintingService = new PrintingService();
            this.Constraints |= GraphConstraints.Undoable | GraphConstraints.AllowPan;
            this.SelectedItems = new SelectorViewModel();
            (this.SelectedItems as SelectorViewModel).SelectorConstraints &= ~SelectorConstraints.QuickCommands;
            this.PortVisibility = PortVisibility.Collapse;
            this.SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.ShowLines | SnapConstraints.SnapToLines,
                SnapToObject = SnapToObject.All,
            };
            ItemAddedCommand = new DelegateCommand(OnItemAddedCommandCommand);
            MenuOpenCommand = new DelegateCommand(OnMenuOpenCommand);
            MenuItemClickedCommand = new DelegateCommand(OnMenuItemClickedCommand);
            this.EnableConnectorSplitting = true;
        }
        /// <summary>
        /// This method is used to execute Save command
        /// </summary>
        /// <param name="obj"></param>
        private void OnMenuOpenCommand(object obj)
        {
            var bpmnnode = (obj as MenuOpeningEventArgs).Source as BpmnNode;
            var bpmngroup = (obj as MenuOpeningEventArgs).Source as BpmnGroup;
            var bpmnflow = (obj as MenuOpeningEventArgs).Source as BpmnFlow;
            if (bpmnnode != null)
            {
                var node = bpmnnode.DataContext as BpmnNodeViewModel;
                if (node != null)
                {
                    if (node.Type == BpmnShapeType.TextAnnotation)
                    {
                        AddAnnotationMenuItems(node);
                    }
                    else if (node.Type == BpmnShapeType.Activity)
                    {
                        AddActivityMenuItems(node);
                    }
                    else if (node.Type == BpmnShapeType.Gateway)
                    {
                        AddGatewayMenuItems(node);
                    }
                    else if (node.Type == BpmnShapeType.Event)
                    {
                        AddEventMenuItems(node);
                    }
                    else if (node.Type == BpmnShapeType.DataObject)
                    {
                        AddDataObjectMenuItems(node);
                    }
                }
            }
            if (bpmngroup != null)
            {
                var node = bpmngroup.DataContext as BpmnGroupViewModel;
                if (node.IsExpandedSubProcess)
                {
                    AddExpandedSubProcessMenuItems(node);
                }
            }
            if (bpmnflow != null)
            {
                var flow = bpmnflow.DataContext as BpmnFlowViewModel;
                AddBpmnFlowMenuItems(flow);
            }
        }

        private void OnMenuItemClickedCommand(object obj)
        {
            var menuitem = obj as MenuItemClickedEventArgs;
            var bpmnnode = menuitem.Source as BpmnNode;
            var bpmngroup = menuitem.Source as BpmnGroup;
            var bpmnflow = menuitem.Source as BpmnFlow;
            if (bpmnnode != null)
            {
                var node = bpmnnode.DataContext as BpmnNodeViewModel;
                if (node != null)
                {
                    if (node.Type == BpmnShapeType.TextAnnotation)
                    {
                        UpdateAnnotationShapeValue(node, menuitem);
                    }
                    else if (node.Type == BpmnShapeType.Activity)
                    {
                        UpdateActivityShapeValue(node, menuitem);
                    }
                    else if (node.Type == BpmnShapeType.Gateway)
                    {
                        UpdateGatewayShapeValue(node, menuitem);
                    }
                    else if (node.Type == BpmnShapeType.Event)
                    {
                        UpdateEventShapeValue(node, menuitem);
                    }
                    else if (node.Type == BpmnShapeType.DataObject)
                    {
                        UpdateDataObjectShapeValue(node, menuitem);
                    }
                }
            }
            if (bpmngroup != null)
            {
                var node = bpmngroup.DataContext as BpmnGroupViewModel;
                if (node.IsExpandedSubProcess)
                {
                    UpdateExpandedSubProcessShapeValue(node, menuitem);
                }
            }
            if (bpmnflow != null)
            {
                var flow = bpmnflow.DataContext as BpmnFlowViewModel;
                UpdateBpmnFlowShapeValue(flow, menuitem);
            }
        }

        #region BpmnFlow
        private void AddBpmnFlowMenuItems(BpmnFlowViewModel flow)
        {
            flow.Constraints = flow.Constraints | ConnectorConstraints.Menu;
            flow.Menu = new DiagramMenu();
            flow.Menu.MenuItems = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem mi = new DiagramMenuItem()
            {
                Content = "Flow Type",
            };
            mi.Items = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem m1 = new DiagramMenuItem()
            {
                Content = "Association",
                IsCheckable = flow.FlowType == BpmnFlowType.Association ? true : false
            };
            DiagramMenuItem m2 = new DiagramMenuItem()
            {
                Content = "Bidirected Association",
                IsCheckable = flow.FlowType == BpmnFlowType.BiDirectionalAssociation ? true : false
            };
            DiagramMenuItem m3 = new DiagramMenuItem()
            {
                Content = "Directed Association",
                IsCheckable = flow.FlowType == BpmnFlowType.DirectionalAssociation ? true : false
            };
            DiagramMenuItem m4 = new DiagramMenuItem()
            {
                Content = "Sequence Flow",
                IsCheckable = flow.FlowType == BpmnFlowType.SequenceFlow ? true : false
            };
            DiagramMenuItem m5 = new DiagramMenuItem()
            {
                Content = "Conditional Sequence Flow",
                IsCheckable = flow.FlowType == BpmnFlowType.ConditionalSequenceFlow ? true : false
            };
            DiagramMenuItem m6 = new DiagramMenuItem()
            {
                Content = "Default Sequence Flow",
                IsCheckable = flow.FlowType == BpmnFlowType.DefaultSequenceFlow ? true : false
            };
            DiagramMenuItem m7 = new DiagramMenuItem()
            {
                Content = "Message Flow",
                IsCheckable = flow.FlowType == BpmnFlowType.MessageFlow ? true : false
            };
            DiagramMenuItem m8 = new DiagramMenuItem()
            {
                Content = "Initiating Message Flow",
                IsCheckable = flow.FlowType == BpmnFlowType.InitiatingMessageFlow ? true : false
            };
            DiagramMenuItem m9 = new DiagramMenuItem()
            {
                Content = "Non-Initiating Message Flow",
                IsCheckable = flow.FlowType == BpmnFlowType.NonInitiatingMessageFlow ? true : false
            };

            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m1);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m2);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m3);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m4);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m5);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m6);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m7);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m8);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m9);
            (flow.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi);
        }
        private void UpdateBpmnFlowShapeValue(BpmnFlowViewModel flow, MenuItemClickedEventArgs menuitem)
        {
            foreach (var element in flow.Menu.MenuItems as ObservableCollection<DiagramMenuItem>)
            {
                foreach (var item in element.Items as ObservableCollection<DiagramMenuItem>)
                {
                    item.IsCheckable = false;
                }
            }
            (menuitem.Item as DiagramMenuItem).IsCheckable = true;
            if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Association")
            {
                flow.FlowType = BpmnFlowType.Association;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Default Sequence Flow")
            {
                flow.FlowType = BpmnFlowType.DefaultSequenceFlow;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Bidirected Association")
            {
                flow.FlowType = BpmnFlowType.BiDirectionalAssociation;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Conditional Sequence Flow")
            {
                flow.FlowType = BpmnFlowType.ConditionalSequenceFlow;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Directed Association")
            {
                flow.FlowType = BpmnFlowType.DirectionalAssociation;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Initiating Message Flow")
            {
                flow.FlowType = BpmnFlowType.InitiatingMessageFlow;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Message Flow")
            {
                flow.FlowType = BpmnFlowType.MessageFlow;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Non-Initiating Message Flow")
            {
                flow.FlowType = BpmnFlowType.NonInitiatingMessageFlow;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Sequence Flow")
            {
                flow.FlowType = BpmnFlowType.SequenceFlow;
            }
        }
        #endregion

        #region AnnotationShape
        private void AddAnnotationMenuItems(BpmnNodeViewModel node)
        {
            node.Constraints = node.Constraints | NodeConstraints.Menu;
            //node.Constraints = node.Constraints & ~NodeConstraints.InheritMenu;
            node.Menu = new DiagramMenu();
            node.Menu.MenuItems = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem mi = new DiagramMenuItem()
            {
                Content = "Callout Direction",
            };
            mi.Items = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem m1 = new DiagramMenuItem()
            {
                Content = "Left",
                IsCheckable = node.TextAnnotationDirection == TextAnnotationDirection.Left ? true : false
            };
            DiagramMenuItem m2 = new DiagramMenuItem()
            {
                Content = "Right",
                IsCheckable = node.TextAnnotationDirection == TextAnnotationDirection.Right ? true : false
            };
            DiagramMenuItem m3 = new DiagramMenuItem()
            {
                Content = "Top",
                IsCheckable = node.TextAnnotationDirection == TextAnnotationDirection.Top ? true : false
            };
            DiagramMenuItem m4 = new DiagramMenuItem()
            {
                Content = "Bottom",
                IsCheckable = node.TextAnnotationDirection == TextAnnotationDirection.Bottom ? true : false
            };
            DiagramMenuItem m5 = new DiagramMenuItem()
            {
                Content = "Auto",
                IsCheckable = node.TextAnnotationDirection == TextAnnotationDirection.Auto ? true : false
            };
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m1);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m2);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m3);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m4);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m5);
            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi);
        }
        private void UpdateAnnotationShapeValue(BpmnNodeViewModel node, MenuItemClickedEventArgs menuitem)
        {
            foreach (var element in node.Menu.MenuItems as ObservableCollection<DiagramMenuItem>)
            {
                foreach (var item in element.Items as ObservableCollection<DiagramMenuItem>)
                {
                    item.IsCheckable = false;
                }
            }
            (menuitem.Item as DiagramMenuItem).IsCheckable = true;
            if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Left")
            {
                node.TextAnnotationDirection = TextAnnotationDirection.Left;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Top")
            {
                node.TextAnnotationDirection = TextAnnotationDirection.Top;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Right")
            {
                node.TextAnnotationDirection = TextAnnotationDirection.Right;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Bottom")
            {
                node.TextAnnotationDirection = TextAnnotationDirection.Bottom;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Auto")
            {
                node.TextAnnotationDirection = TextAnnotationDirection.Auto;
            }
        }
        #endregion

        #region Activity

        private void AddActivityMenuItems(BpmnNodeViewModel node)
        {
            node.Constraints = node.Constraints | NodeConstraints.Menu;
            node.Menu = new DiagramMenu();
            node.Menu.MenuItems = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem mi = new DiagramMenuItem()
            {
                Content = "Loop",
            };
            mi.Items = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem l1 = new DiagramMenuItem()
            {
                Content = "None",
                CommandParameter = "Loop",
                IsCheckable = node.LoopActivity == LoopCharacteristic.None ? true : false
            };
            DiagramMenuItem l2 = new DiagramMenuItem()
            {
                Content = "Standard",
                CommandParameter = "Loop",
                IsCheckable = node.LoopActivity == LoopCharacteristic.Standard ? true : false
            };
            DiagramMenuItem l3 = new DiagramMenuItem()
            {
                Content = "Parallel Multi-Instance",
                CommandParameter = "Loop",
                IsCheckable = node.LoopActivity == LoopCharacteristic.ParallelMultiInstance ? true : false
            };
            DiagramMenuItem l4 = new DiagramMenuItem()
            {
                Content = "Sequence Multi-Instance",
                CommandParameter = "Loop",
                IsCheckable = node.LoopActivity == LoopCharacteristic.SequenceMultiInstance ? true : false
            };
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l1);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l2);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l3);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l4);


            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi);
            if (node.ActivityType == ActivityType.Task)
            {
                DiagramMenuItem tt = new DiagramMenuItem()
                {
                    Content = "Task Type",
                };
                DiagramMenuItem t1 = new DiagramMenuItem()
                {
                    Content = "None",
                    IsCheckable = node.TaskType == TaskType.None ? true : false
                };
                DiagramMenuItem t2 = new DiagramMenuItem()
                {
                    Content = "Service",
                    IsCheckable = node.TaskType == TaskType.Service ? true : false
                };
                DiagramMenuItem t3 = new DiagramMenuItem()
                {
                    Content = "Receive",
                    IsCheckable = node.TaskType == TaskType.Receive ? true : false
                };
                DiagramMenuItem t4 = new DiagramMenuItem()
                {
                    Content = "Send",
                    IsCheckable = node.TaskType == TaskType.Send ? true : false
                };
                DiagramMenuItem t5 = new DiagramMenuItem()
                {
                    Content = "Instantiating Receive",
                    IsCheckable = node.TaskType == TaskType.InstantiatingReceive ? true : false
                };
                DiagramMenuItem t6 = new DiagramMenuItem()
                {
                    Content = "Manual",
                    IsCheckable = node.TaskType == TaskType.Manual ? true : false
                };
                DiagramMenuItem t7 = new DiagramMenuItem()
                {
                    Content = "Business Rule",
                    IsCheckable = node.TaskType == TaskType.BusinessRule ? true : false
                };
                DiagramMenuItem t8 = new DiagramMenuItem()
                {
                    Content = "User",
                    IsCheckable = node.TaskType == TaskType.User ? true : false
                };
                DiagramMenuItem t9 = new DiagramMenuItem()
                {
                    Content = "Script",
                    IsCheckable = node.TaskType == TaskType.Script ? true : false
                };
                tt.Items = new ObservableCollection<DiagramMenuItem>()
            {
                t1,t2,t3,t4,t5,t6,t7,t8,t9
            };
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(tt);
            }
            else
            {
                DiagramMenuItem adhoc = new DiagramMenuItem()
                {
                    Content = "Ad-Hoc",
                    IsCheckable = node.IsAdhocActivity ? true : false
                };
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(adhoc);
            }
            DiagramMenuItem comp = new DiagramMenuItem()
            {
                Content = "Compensation",
                IsCheckable = node.IsCompensationActivity ? true : false,
            };
            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(comp);
            if (node.ActivityType == ActivityType.Task)
            {
                DiagramMenuItem call = new DiagramMenuItem()
                {
                    Content = "Call",
                    IsCheckable = node.IsCallActivity ? true : false,
                };
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(call);
            }
            else
            {
                DiagramMenuItem bound = new DiagramMenuItem()
                {
                    Content = "Boundary",

                };
                DiagramMenuItem b1 = new DiagramMenuItem()
                {
                    Content = "Call",
                    IsCheckable = node.SubProcessType == SubProcessType.Call ? true : false,
                };
                DiagramMenuItem b2 = new DiagramMenuItem()
                {
                    Content = "Default",
                    IsCheckable = node.SubProcessType == SubProcessType.Default ? true : false,
                };
                DiagramMenuItem b3 = new DiagramMenuItem()
                {
                    Content = "Event",
                    IsCheckable = node.SubProcessType == SubProcessType.Event ? true : false,
                };
                DiagramMenuItem b4 = new DiagramMenuItem()
                {
                    Content = "Transaction",
                    IsCheckable = node.SubProcessType == SubProcessType.Transaction ? true : false,
                };

                bound.Items = new ObservableCollection<DiagramMenuItem>()
                {
                    b1,b2,b3,b4
                };
                (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(bound);
            }
            DiagramMenuItem at = new DiagramMenuItem()
            {
                Content = "Activity Type",

            };
            DiagramMenuItem at1 = new DiagramMenuItem()
            {
                Content = "Task",
                IsCheckable = node.ActivityType == ActivityType.Task ? true : false,
            };
            DiagramMenuItem at2 = new DiagramMenuItem()
            {
                Content = "Collapsed Sub-Process",
                IsCheckable = node.ActivityType == ActivityType.CollapsedSubProcess ? true : false,
            };
            at.Items = new ObservableCollection<DiagramMenuItem>()
            {
              at1,at2
            };

            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(at);
        }

        private void UpdateActivityShapeValue(BpmnNodeViewModel node, MenuItemClickedEventArgs menuitem)
        {
            foreach (var element in node.Menu.MenuItems as ObservableCollection<DiagramMenuItem>)
            {
                if (element.Items != null)
                {
                    foreach (var item in element.Items as ObservableCollection<DiagramMenuItem>)
                    {
                        item.IsCheckable = false;
                    }
                }
            }
            if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Call" ||
                (menuitem.Item as DiagramMenuItem).Content.ToString() == "Ad-Hoc" ||
                (menuitem.Item as DiagramMenuItem).Content.ToString() == "Compensation")
            {
                if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Call")
                {
                    (menuitem.Item as DiagramMenuItem).IsCheckable = node.IsCallActivity ? false : true;
                    node.IsCallActivity = (menuitem.Item as DiagramMenuItem).IsCheckable;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Ad-Hoc")
                {
                    (menuitem.Item as DiagramMenuItem).IsCheckable = node.IsAdhocActivity ? false : true;
                    node.IsAdhocActivity = (menuitem.Item as DiagramMenuItem).IsCheckable;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Compensation")
                {
                    (menuitem.Item as DiagramMenuItem).IsCheckable = node.IsCompensationActivity ? false : true;
                    node.IsCompensationActivity = (menuitem.Item as DiagramMenuItem).IsCheckable;
                }
            }
            else
            {
                (menuitem.Item as DiagramMenuItem).IsCheckable = true;
            }
            if ((menuitem.Item as DiagramMenuItem).CommandParameter != null &&
                (menuitem.Item as DiagramMenuItem).CommandParameter.ToString() == "Loop")
            {
                if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "None")
                {
                    node.LoopActivity = LoopCharacteristic.None;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Parallel Multi-Instance")
                {
                    node.LoopActivity = LoopCharacteristic.ParallelMultiInstance;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Sequence Multi-Instance")
                {
                    node.LoopActivity = LoopCharacteristic.SequenceMultiInstance;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Standard")
                {
                    node.LoopActivity = LoopCharacteristic.Standard;
                }
            }
            else
            {
                if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "None")
                {
                    node.TaskType = TaskType.None;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Business Rule")
                {
                    node.TaskType = TaskType.BusinessRule;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Instantiating Receive")
                {
                    node.TaskType = TaskType.InstantiatingReceive;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Manual")
                {
                    node.TaskType = TaskType.Manual;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Receive")
                {
                    node.TaskType = TaskType.Receive;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Script")
                {
                    node.TaskType = TaskType.Script;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Send")
                {
                    node.TaskType = TaskType.Send;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Service")
                {
                    node.TaskType = TaskType.Service;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "User")
                {
                    node.TaskType = TaskType.User;
                }
            }
            if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Task")
            {
                node.ActivityType = ActivityType.Task;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Collapsed Sub-Process")
            {
                node.ActivityType = ActivityType.CollapsedSubProcess;
            }
            if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Default")
            {
                node.SubProcessType = SubProcessType.Default;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Call")
            {
                node.SubProcessType = SubProcessType.Call;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Event")
            {
                node.SubProcessType = SubProcessType.Event;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Transaction")
            {
                node.SubProcessType = SubProcessType.Transaction;
            }
        }
        #endregion

        #region Gateway
        private void AddGatewayMenuItems(BpmnNodeViewModel node)
        {
            node.Constraints = node.Constraints | NodeConstraints.Menu;
            node.Menu = new DiagramMenu();
            node.Menu.MenuItems = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem mi = new DiagramMenuItem()
            {
                Content = "Gateway Type",
            };
            mi.Items = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem l1 = new DiagramMenuItem()
            {
                Content = "None",
                IsCheckable = node.GatewayType == GatewayType.None ? true : false
            };
            DiagramMenuItem l2 = new DiagramMenuItem()
            {
                Content = "Exclusive",
                IsCheckable = node.GatewayType == GatewayType.Exclusive ? true : false
            };
            DiagramMenuItem l3 = new DiagramMenuItem()
            {
                Content = "Event Based",
                IsCheckable = node.GatewayType == GatewayType.EventBased ? true : false
            };
            DiagramMenuItem l4 = new DiagramMenuItem()
            {
                Content = "Exclusive Event (Instantiate)",
                IsCheckable = node.GatewayType == GatewayType.ExclusiveEventBased ? true : false
            };
            DiagramMenuItem l5 = new DiagramMenuItem()
            {
                Content = "Parallel Event (Instantiate)",
                IsCheckable = node.GatewayType == GatewayType.ParallelEventBased ? true : false
            };
            DiagramMenuItem l6 = new DiagramMenuItem()
            {
                Content = "Inclusive",
                IsCheckable = node.GatewayType == GatewayType.Inclusive ? true : false
            };
            DiagramMenuItem l7 = new DiagramMenuItem()
            {
                Content = "Parallel",
                IsCheckable = node.GatewayType == GatewayType.Parallel ? true : false
            };
            DiagramMenuItem l8 = new DiagramMenuItem()
            {
                Content = "Complex",
                IsCheckable = node.GatewayType == GatewayType.Complex ? true : false
            };
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l1);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l2);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l3);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l4);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l5);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l6);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l7);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l8);

            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi);
        }

        private void UpdateGatewayShapeValue(BpmnNodeViewModel node, MenuItemClickedEventArgs menuitem)
        {
            foreach (var element in node.Menu.MenuItems as ObservableCollection<DiagramMenuItem>)
            {
                if (element.Items != null)
                {
                    foreach (var item in element.Items as ObservableCollection<DiagramMenuItem>)
                    {
                        item.IsCheckable = false;
                    }
                }
            }
           (menuitem.Item as DiagramMenuItem).IsCheckable = true;
            if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "None")
            {
                node.GatewayType = GatewayType.None;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Complex")
            {
                node.GatewayType = GatewayType.Complex;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Event Based")
            {
                node.GatewayType = GatewayType.EventBased;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Exclusive")
            {
                node.GatewayType = GatewayType.Exclusive;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Exclusive Event (Instantiate)")
            {
                node.GatewayType = GatewayType.ExclusiveEventBased;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Inclusive")
            {
                node.GatewayType = GatewayType.Inclusive;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Parallel")
            {
                node.GatewayType = GatewayType.Parallel;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Parallel Event (Instantiate)")
            {
                node.GatewayType = GatewayType.ParallelEventBased;
            }
        }
        #endregion

        #region Event
        private void AddEventMenuItems(BpmnNodeViewModel node)
        {
            node.Constraints = node.Constraints | NodeConstraints.Menu;
            //node.Constraints = node.Constraints & ~NodeConstraints.InheritMenu;
            node.Menu = new DiagramMenu();
            node.Menu.MenuItems = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem mi = new DiagramMenuItem()
            {
                Content = "Event Type",
            };
            mi.Items = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem m1 = new DiagramMenuItem()
            {
                Content = "Start",
                CommandParameter = "EventType",
                IsCheckable = node.EventType == EventType.Start ? true : false
            };
            DiagramMenuItem m2 = new DiagramMenuItem()
            {
                Content = "Start (Non-Interrupting)",
                CommandParameter = "EventType",
                IsCheckable = node.EventType == EventType.NonInterruptingStart ? true : false
            };
            DiagramMenuItem m3 = new DiagramMenuItem()
            {
                Content = "Intermediate",
                CommandParameter = "EventType",
                IsCheckable = node.EventType == EventType.Intermediate ? true : false
            };
            DiagramMenuItem m4 = new DiagramMenuItem()
            {
                Content = "Intermediate (Non-Interrupting)",
                CommandParameter = "EventType",
                IsCheckable = node.EventType == EventType.NonInterruptingIntermediate ? true : false
            };
            DiagramMenuItem m5 = new DiagramMenuItem()
            {
                Content = "Intermediate (Throwing)",
                CommandParameter = "EventType",
                IsCheckable = node.EventType == EventType.ThrowingIntermediate ? true : false
            };
            DiagramMenuItem m6 = new DiagramMenuItem()
            {
                Content = "End",
                CommandParameter = "EventType",
                IsCheckable = node.EventType == EventType.End ? true : false
            };
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m1);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m2);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m3);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m4);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m5);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m6);
            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi);
            DiagramMenuItem ti = new DiagramMenuItem()
            {
                Content = "Trigger/Result",
            };
            ti.Items = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem t1 = new DiagramMenuItem()
            {
                Content = "None",
                IsCheckable = node.EventTrigger == Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.None ? true : false
            };
            DiagramMenuItem t2 = new DiagramMenuItem()
            {
                Content = "Message",
                IsCheckable = node.EventTrigger == Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Message ? true : false
            };
            DiagramMenuItem t3 = new DiagramMenuItem()
            {
                Content = "Timer",
                IsCheckable = node.EventTrigger == Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Timer ? true : false
            };
            DiagramMenuItem t4 = new DiagramMenuItem()
            {
                Content = "Error",
                IsCheckable = node.EventTrigger == Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Error ? true : false
            };
            DiagramMenuItem t5 = new DiagramMenuItem()
            {
                Content = "Cancel",
                IsCheckable = node.EventTrigger == Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Cancel ? true : false
            };
            DiagramMenuItem t6 = new DiagramMenuItem()
            {
                Content = "Compensation",
                IsCheckable = node.EventTrigger == Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Compensation ? true : false
            };
            DiagramMenuItem t7 = new DiagramMenuItem()
            {
                Content = "Conditional",
                IsCheckable = node.EventTrigger == Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Conditional ? true : false
            };
            DiagramMenuItem t8 = new DiagramMenuItem()
            {
                Content = "Link",
                IsCheckable = node.EventTrigger == Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Link ? true : false
            };
            DiagramMenuItem t9 = new DiagramMenuItem()
            {
                Content = "Signal",
                IsCheckable = node.EventTrigger == Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Signal ? true : false
            };
            DiagramMenuItem t10 = new DiagramMenuItem()
            {
                Content = "Multiple",
                IsCheckable = node.EventTrigger == Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Multiple ? true : false
            };
            DiagramMenuItem t11 = new DiagramMenuItem()
            {
                Content = "Escalation",
                IsCheckable = node.EventTrigger == Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Escalation ? true : false
            };
            DiagramMenuItem t12 = new DiagramMenuItem()
            {
                Content = "Termination",
                IsCheckable = node.EventTrigger == Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Termination ? true : false
            };
            DiagramMenuItem t13 = new DiagramMenuItem()
            {
                Content = "Parallel",
                IsCheckable = node.EventTrigger == Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Parallel ? true : false
            };
            (ti.Items as ObservableCollection<DiagramMenuItem>).Add(t1);
            (ti.Items as ObservableCollection<DiagramMenuItem>).Add(t2);
            (ti.Items as ObservableCollection<DiagramMenuItem>).Add(t3);
            (ti.Items as ObservableCollection<DiagramMenuItem>).Add(t4);
            (ti.Items as ObservableCollection<DiagramMenuItem>).Add(t5);
            (ti.Items as ObservableCollection<DiagramMenuItem>).Add(t6);
            (ti.Items as ObservableCollection<DiagramMenuItem>).Add(t7);
            (ti.Items as ObservableCollection<DiagramMenuItem>).Add(t8);
            (ti.Items as ObservableCollection<DiagramMenuItem>).Add(t9);
            (ti.Items as ObservableCollection<DiagramMenuItem>).Add(t10);
            (ti.Items as ObservableCollection<DiagramMenuItem>).Add(t11);
            (ti.Items as ObservableCollection<DiagramMenuItem>).Add(t12);
            (ti.Items as ObservableCollection<DiagramMenuItem>).Add(t13);
            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(ti);
        }
        private void UpdateEventShapeValue(BpmnNodeViewModel node, MenuItemClickedEventArgs menuitem)
        {
            foreach (var element in node.Menu.MenuItems as ObservableCollection<DiagramMenuItem>)
            {
                foreach (var item in element.Items as ObservableCollection<DiagramMenuItem>)
                {
                    item.IsCheckable = false;
                }
            }
            (menuitem.Item as DiagramMenuItem).IsCheckable = true;
            if ((menuitem.Item as DiagramMenuItem).CommandParameter != null &&
               (menuitem.Item as DiagramMenuItem).CommandParameter.ToString() == "EventType")
            {
                if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "End")
                {
                    node.EventType = EventType.End;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Intermediate")
                {
                    node.EventType = EventType.Intermediate;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Intermediate (Non-Interrupting)")
                {
                    node.EventType = EventType.NonInterruptingIntermediate;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Start (Non-Interrupting)")
                {
                    node.EventType = EventType.NonInterruptingStart;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Start")
                {
                    node.EventType = EventType.Start;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Intermediate (Throwing)")
                {
                    node.EventType = EventType.ThrowingIntermediate;
                }
            }
            else
            {
                if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Cancel")
                {
                    node.EventTrigger = Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Cancel;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Compensation")
                {
                    node.EventTrigger = Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Compensation;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Conditional")
                {
                    node.EventTrigger = Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Conditional;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Error")
                {
                    node.EventTrigger = Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Error;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Escalation")
                {
                    node.EventTrigger = Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Escalation;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Link")
                {
                    node.EventTrigger = Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Link;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Message")
                {
                    node.EventTrigger = Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Message;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Multiple")
                {
                    node.EventTrigger = Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Multiple;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "None")
                {
                    node.EventTrigger = Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.None;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Parallel")
                {
                    node.EventTrigger = Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Parallel;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Signal")
                {
                    node.EventTrigger = Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Signal;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Termination")
                {
                    node.EventTrigger = Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Termination;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Timer")
                {
                    node.EventTrigger = Syncfusion.UI.Xaml.Diagram.Controls.EventTrigger.Timer;
                }
            }
        }
        #endregion

        #region DataObject
        private void AddDataObjectMenuItems(BpmnNodeViewModel node)
        {
            node.Constraints = node.Constraints | NodeConstraints.Menu;
            //node.Constraints = node.Constraints & ~NodeConstraints.InheritMenu;
            node.Menu = new DiagramMenu();
            node.Menu.MenuItems = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem ni = new DiagramMenuItem()
            {
                Content = "Collection",
                IsCheckable = node.IsCollectiveData ? true : false
            };
            DiagramMenuItem mi = new DiagramMenuItem()
            {
                Content = "Data Object Type",
            };
            mi.Items = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem m1 = new DiagramMenuItem()
            {
                Content = "None",
                IsCheckable = node.DataObjectType == DataObjectType.None ? true : false
            };
            DiagramMenuItem m2 = new DiagramMenuItem()
            {
                Content = "Input",
                IsCheckable = node.DataObjectType == DataObjectType.Input ? true : false
            };
            DiagramMenuItem m3 = new DiagramMenuItem()
            {
                Content = "Output",
                IsCheckable = node.DataObjectType == DataObjectType.Output ? true : false
            };
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m1);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m2);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(m3);
            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(ni);
            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi);
        }
        private void UpdateDataObjectShapeValue(BpmnNodeViewModel node, MenuItemClickedEventArgs menuitem)
        {
            foreach (var element in node.Menu.MenuItems as ObservableCollection<DiagramMenuItem>)
            {
                if (element.Items != null)
                {
                    foreach (var item in element.Items as ObservableCollection<DiagramMenuItem>)
                    {
                        item.IsCheckable = false;
                    }
                }
            }
            if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Collection")
            {
                (menuitem.Item as DiagramMenuItem).IsCheckable = node.IsCollectiveData ? false : true;
                node.IsCollectiveData = (menuitem.Item as DiagramMenuItem).IsCheckable;
            }
            else
            {
                (menuitem.Item as DiagramMenuItem).IsCheckable = true;
            }
            if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "None")
            {
                node.DataObjectType = DataObjectType.None;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Input")
            {
                node.DataObjectType = DataObjectType.Input;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Output")
            {
                node.DataObjectType = DataObjectType.Output;
            }
        }
        #endregion

        #region ExpandedSubProcess

        private void AddExpandedSubProcessMenuItems(BpmnGroupViewModel node)
        {
            node.Constraints = node.Constraints | NodeConstraints.Menu;
            node.Menu = new DiagramMenu();
            node.Menu.MenuItems = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem mi = new DiagramMenuItem()
            {
                Content = "Loop",
            };
            mi.Items = new ObservableCollection<DiagramMenuItem>();
            DiagramMenuItem l1 = new DiagramMenuItem()
            {
                Content = "None",
                CommandParameter = "Loop",
                IsCheckable = node.LoopActivity == LoopCharacteristic.None ? true : false
            };
            DiagramMenuItem l2 = new DiagramMenuItem()
            {
                Content = "Standard",
                CommandParameter = "Loop",
                IsCheckable = node.LoopActivity == LoopCharacteristic.Standard ? true : false
            };
            DiagramMenuItem l3 = new DiagramMenuItem()
            {
                Content = "Parallel Multi-Instance",
                CommandParameter = "Loop",
                IsCheckable = node.LoopActivity == LoopCharacteristic.ParallelMultiInstance ? true : false
            };
            DiagramMenuItem l4 = new DiagramMenuItem()
            {
                Content = "Sequence Multi-Instance",
                CommandParameter = "Loop",
                IsCheckable = node.LoopActivity == LoopCharacteristic.SequenceMultiInstance ? true : false
            };
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l1);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l2);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l3);
            (mi.Items as ObservableCollection<DiagramMenuItem>).Add(l4);


            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(mi);
            DiagramMenuItem adhoc = new DiagramMenuItem()
            {
                Content = "Ad-Hoc",
                IsCheckable = node.IsAdhocActivity ? true : false
            };
            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(adhoc);
            DiagramMenuItem comp = new DiagramMenuItem()
            {
                Content = "Compensation",
                IsCheckable = node.IsCompensationActivity ? true : false,
            };
            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(comp);
            DiagramMenuItem bound = new DiagramMenuItem()
            {
                Content = "Boundary",

            };
            DiagramMenuItem b1 = new DiagramMenuItem()
            {
                Content = "Call",
                IsCheckable = node.SubProcessType == SubProcessType.Call ? true : false,
            };
            DiagramMenuItem b2 = new DiagramMenuItem()
            {
                Content = "Default",
                IsCheckable = node.SubProcessType == SubProcessType.Default ? true : false,
            };
            DiagramMenuItem b3 = new DiagramMenuItem()
            {
                Content = "Event",
                IsCheckable = node.SubProcessType == SubProcessType.Event ? true : false,
            };
            DiagramMenuItem b4 = new DiagramMenuItem()
            {
                Content = "Transaction",
                IsCheckable = node.SubProcessType == SubProcessType.Transaction ? true : false,
            };

            bound.Items = new ObservableCollection<DiagramMenuItem>()
                {
                    b1,b2,b3,b4
                };
            (node.Menu.MenuItems as ICollection<DiagramMenuItem>).Add(bound);
        }

        private void UpdateExpandedSubProcessShapeValue(BpmnGroupViewModel node, MenuItemClickedEventArgs menuitem)
        {
            foreach (var element in node.Menu.MenuItems as ObservableCollection<DiagramMenuItem>)
            {
                if (element.Items != null)
                {
                    foreach (var item in element.Items as ObservableCollection<DiagramMenuItem>)
                    {
                        item.IsCheckable = false;
                    }
                }
            }
            if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Ad-Hoc" ||
                (menuitem.Item as DiagramMenuItem).Content.ToString() == "Compensation")
            {
                if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Ad-Hoc")
                {
                    (menuitem.Item as DiagramMenuItem).IsCheckable = node.IsAdhocActivity ? false : true;
                    node.IsAdhocActivity = (menuitem.Item as DiagramMenuItem).IsCheckable;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Compensation")
                {
                    (menuitem.Item as DiagramMenuItem).IsCheckable = node.IsCompensationActivity ? false : true;
                    node.IsCompensationActivity = (menuitem.Item as DiagramMenuItem).IsCheckable;
                }
            }
            else
            {
                (menuitem.Item as DiagramMenuItem).IsCheckable = true;
            }
            if ((menuitem.Item as DiagramMenuItem).CommandParameter != null &&
                (menuitem.Item as DiagramMenuItem).CommandParameter.ToString() == "Loop")
            {
                if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "None")
                {
                    node.LoopActivity = LoopCharacteristic.None;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Parallel Multi-Instance")
                {
                    node.LoopActivity = LoopCharacteristic.ParallelMultiInstance;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Sequence Multi-Instance")
                {
                    node.LoopActivity = LoopCharacteristic.SequenceMultiInstance;
                }
                else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Standard")
                {
                    node.LoopActivity = LoopCharacteristic.Standard;
                }
            }
            if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Default")
            {
                node.SubProcessType = SubProcessType.Default;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Call")
            {
                node.SubProcessType = SubProcessType.Call;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Event")
            {
                node.SubProcessType = SubProcessType.Event;
            }
            else if ((menuitem.Item as DiagramMenuItem).Content.ToString() == "Transaction")
            {
                node.SubProcessType = SubProcessType.Transaction;
            }
        }
        #endregion

        public void OnItemAddedCommandCommand(object parameter)
        {
            var element = parameter as ItemAddedEventArgs;
            if (element != null)
            {
                var item = element.Item as BpmnFlowViewModel;
                if (item != null)
                {
                    var anno = (item.Annotations as ObservableCollection<IAnnotation>).FirstOrDefault() as AnnotationEditorViewModel;
                    if (anno != null)
                    {
                        anno.ViewTemplate = AnnotationTemplate.GetViewTempalte();
                    }
                }
            }
        }
    }


    public static class AnnotationTemplate
    {
        public static DataTemplate GetViewTempalte()
        {
            const string vTemplate = "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" +
                                      "<Border Background=\"White\" >" +
                                      "<TextBlock  TextAlignment=\"Center\"" +
                                                 " TextWrapping=\"{Binding Path = WrapText, Mode = OneWay}\"" +
                                                 " FontFamily=\"Arial\"" +
                                                 " FontSize=\"12\"" +
                                                 " HorizontalAlignment=\"Center\"" +
                                                 " VerticalAlignment=\"Center\"" +
                                                 " Foreground=\"Black\"" +
                                                 " Text=\"{Binding Path=Content, Mode=TwoWay}\"/>" +
                                      "</Border>" +
                                      "</DataTemplate>";

            return vTemplate.LoadXaml() as DataTemplate;
        }

        public static object LoadXaml(this string xaml)
        {
            return XamlReader.Parse(xaml);
        }

        public static DataTemplate GetEditTemplate()
        {
            const string eTemplate = "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" +
                                      "<Border Background=\"White\">" +
                                      "<TextBox TextAlignment=\"Center\"" +
                                                 " TextWrapping=\"{Binding Path = WrapText, Mode = OneWay}\"" +
                                                 " FontFamily=\"Arial\"" +
                                                 " FontSize=\"12\"" +
                                                 " HorizontalAlignment=\"Center\"" +
                                                 " VerticalAlignment=\"Center\"" +
                                                 " Foreground=\"Black\"" +
                                                 " Text=\"{Binding Path=Content, Mode=TwoWay}\"/>" +
                                      "</Border>" +
                                      "</DataTemplate>";
            return eTemplate.LoadXaml() as DataTemplate;
        }
    }

}
