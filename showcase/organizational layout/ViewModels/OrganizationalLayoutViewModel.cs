#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using Syncfusion.Pdf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.Windows.Shared;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Diagram.Layout;
using INodeInfo = Syncfusion.UI.Xaml.Diagram.INodeInfo;
using IOPath = System.IO.Path;
using System.Windows.Data;
using System.Globalization;
using syncfusion.organizationallayout.wpf.Views;

namespace syncfusion.organizationallayout.wpf
{
    public class organizationallayoutViewModel : DiagramViewModel
    {
        private bool showBackStage = true;
        private bool showMainView = false;
        private string selectedFileName;
        private string selectedFolderPath;
        private string _LayoutOrientation = "Top To Bottom";
        private bool zoomInEnabled = true;
        private bool zoomOutEnabled = true;
        private double currentZoom = 1;
        private string zoomPercentageValue = "100%";
        private Rect contentBounds = Rect.Empty;
        private organizationallayoutdemo view;
        /// <summary>
        ///     The _ zoom parameter.
        /// </summary>
        private ZoomParameter _ZoomParameter;
        private string[] predefinedDiagram = new string[] { "ORG Chart Demo" };
        private string orglayouttype;
        private MenuBar menubar = null;

        public organizationallayoutViewModel() : base()
        {
            this.SelectedItems = new SelectorViewModel() { Commands = new ObservableCollection<QuickCommandVM>(), SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.Rotator & ~SelectorConstraints.Resizer };
            this.KnownTypes = () => new List<Type>() { typeof(CustomContent) };
            this.Nodes = new ObservableCollection<organizationallayoutNode>();
            this.Connectors = new ObservableCollection<organizationallayoutConnector>();
            this.Groups = new GroupCollection();
            this.Constraints = this.Constraints.Add(GraphConstraints.Undoable);
            this.DefaultConnectorType = ConnectorType.Orthogonal;
            this.HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };
            this.VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            this.Theme = null;
            this.LayoutManager = new LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    AvoidSegmentOverlapping = false,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    VerticalSpacing = 50,
                    HorizontalSpacing = 50,
                    Orientation = TreeOrientation.TopToBottom,
                    Type = LayoutType.Organization,
                },
                RefreshFrequency = RefreshFrequency.ArrangeParsing,
            };
            this.PrintingService = new PrintingService();
            this.ConnectorDropIndicatorStyle = null;
            this.PageSettings = new PageSettings()
            {
                PageOrientation = PageOrientation.Landscape,
                PageWidth = 1123,
                PageHeight = 794,
                MultiplePage = true,
                ShowPageBreaks = false,
                PageBackground = new System.Windows.Media.SolidColorBrush(Colors.Transparent)
            };
            this.SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.Rotation,
                SnapToObject = SnapToObject.All,
                SnapAngle = 90
            };
            this.ScrollSettings = new ScrollSettings() { MinZoom = 0.3, MaxZoom = 3 };
            this.ExportSettings = new ExportSettings();
            this.CommandManager = new Syncfusion.UI.Xaml.Diagram.CommandManager() { Commands = new CommandCollection() };
            this.BackStageOpeningCommand = new DelegateCommand(OnBackStageOpening);
            this.AddNewItemCommand = new DelegateCommand(OnNewItemAdded);
            this.EditCommand = new DelegateCommand(OnEditCommand);
            this.CreateCommand = new DelegateCommand(OnCreate);
            this.OpenCommand = new DelegateCommand(OnOpen);
            this.ExternalOpenCommand = new DelegateCommand(OnExternalOpen);
            this.LoadTemplateCommand = new DelegateCommand(OnTemplateLoad);
            this.SaveCommand = new DelegateCommand(OnSave);
            this.PrintCommand = new DelegateCommand(OnPrint);
            this.ExportCommand = new DelegateCommand(OnExport);
            this.LayoutUpdatedCommand = new DelegateCommand(OnLayoutUpdated);
            this.ItemAddedCommand = new DelegateCommand(OnItemAdded);
            this.GetLayoutInfoCommand = new DelegateCommand(OnGetLayoutInfo);
            this.DropCommand = new DelegateCommand(OnItemDrop);
            this.ItemDeletingCommand = new DelegateCommand(OnItemDeleting);
            this.ItemSelectedCommand = new DelegateCommand(OnItemSelected);
            this.ItemUnSelectedCommand = new DelegateCommand(OnItemUnselected);
            this.ViewPortChangedCommand = new DelegateCommand(OnViewPortChanged);
            this.ZoomInCommand = new DelegateCommand(OnZoomInCommand);
            this.ExpandCollapseCommand = new DelegateCommand(OnExpandCollapse);
            this.ZoomOutCommand = new DelegateCommand(OnZoomOutCommand);
            this.OrgChartCommand = new DelegateCommand(OnOrgChartChanged);
            this.ZoomParameter = new ZoomParameter();
            this.UpdateCommandGesture();
        }

        private void OnItemUnselected(object obj)
        {
            var args = obj as DiagramEventArgs;
            if ((obj as DiagramEventArgs).Item is organizationallayoutNode)
            {
                ((obj as DiagramEventArgs).Item as organizationallayoutNode).CustomContent.FillColor = ((obj as DiagramEventArgs).Item as organizationallayoutNode).CustomContent.PrevFillColor;
            }
        }

        private void OnItemDeleting(object obj)
        { 
            var args = obj as Syncfusion.UI.Xaml.Diagram.ItemDeletingEventArgs;
            if(args.Item is organizationallayoutNode && (args.Item as organizationallayoutNode).Name == "ParentNode")
            {
                args.Cancel = true;
            }

            args.DeleteSuccessors = true;
            this.LayoutManager.Layout.InvalidateLayout();
            UpdateDirectControl();
        }

        private void OnLayoutUpdated(object obj)
        {
            UpdateDirectControl();
        }

        private void OnItemSelected(object obj)
        {
            var args = obj as ItemSelectedEventArgs;

            if (((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Count > 0)
            {

                if (args.Item is organizationallayoutNode && (args.Item as organizationallayoutNode).Name == "AssistantNode")
                {
                    (((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Last() as QuickCommandVM).VisibilityMode = VisibilityMode.Connector;
                    (((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).First() as QuickCommandVM).VisibilityMode = VisibilityMode.Connector;
                }
                else
                {
                    (((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Last() as QuickCommandVM).VisibilityMode = VisibilityMode.Node;
                    (((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).First() as QuickCommandVM).VisibilityMode = VisibilityMode.Node;
                }

                if (((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() > 1 || (((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() >= 1 && ((this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>).Count() >= 1))
                {
                    foreach (QuickCommandVM quick in ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>))
                    {
                        quick.VisibilityMode = VisibilityMode.Connector;
                    }
                }
                else if (((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() == 0 || ((this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>).Count() >= 1)
                {
                    foreach (QuickCommandVM quick in ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>))
                    {
                        quick.VisibilityMode = VisibilityMode.Node;
                    }
                }
                else
                {
                    if (args.Item is organizationallayoutNode && (args.Item as organizationallayoutNode).Name == "AssistantNode")
                    {
                        (((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Last() as QuickCommandVM).VisibilityMode = VisibilityMode.Connector;
                        (((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).First() as QuickCommandVM).VisibilityMode = VisibilityMode.Connector;
                    }
                    else
                    {
                        foreach (QuickCommandVM quick in ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>))
                        {
                            quick.VisibilityMode = VisibilityMode.Node;
                        }
                    }

                    organizationallayoutNode node = ((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).First() as organizationallayoutNode;
                    ExpandCollapseArrowDirection(node);
                }

                if (((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).Count() == 1 && ((this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>).Count() == 0)
                {
                    organizationallayoutNode node = ((this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>).First() as organizationallayoutNode;
                    if ((node.Info as INodeInfo).OutNeighbors != null && (node.Info as INodeInfo).OutNeighbors.Count() >= 1 && (this.SelectedItems as SelectorViewModel).Commands != null && ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Count() > 0)
                    {
                        (((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Last() as QuickCommandVM).VisibilityMode = VisibilityMode.Node;
                    }
                    else
                    {
                        if ((this.SelectedItems as SelectorViewModel).Commands != null && ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Count() > 0)
                        {
                            (((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Last() as QuickCommandVM).VisibilityMode = VisibilityMode.Connector;
                        }
                    }
                }
            }
            
            if (args.Item is organizationallayoutNode && (args.Item as organizationallayoutNode).CustomContent != null)
            {
                organizationallayoutNode node = args.Item as organizationallayoutNode;
                node.CustomContent.PrevFillColor = node.CustomContent.FillColor;
                node.CustomContent.FillColor = node.CustomContent.SelectionColor;
            }
        }

        private void ExpandCollapseArrowDirection(organizationallayoutNode node)
        {
            if (((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Count > 0)
            {
                if ((this.LayoutManager.Layout as DirectedTreeLayout).Orientation == TreeOrientation.BottomToTop)
                {
                    if (node.IsExpanded)
                    {
                        ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Last().Content = "M0.085998535,0L16.112,11.464981 32,0.118011 32,8.3990061 16.115005,19.745 0,8.2079966 0,0.072997569z";
                    }
                    else
                    {
                        ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Last().Content = "M16.261993,0L16.359985,0.065002445 16.454987,0 16.48999,0.15399169 32,11.294986 32,19.745 16.359985,8.5149861 0,19.745 0,11.294986 16.22699,0.15399169z";
                    }
                }

                else if ((this.LayoutManager.Layout as DirectedTreeLayout).Orientation == TreeOrientation.TopToBottom)
                {
                    if (node.IsExpanded)
                    {
                        ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Last().Content = "M16.261993,0L16.359985,0.065002445 16.454987,0 16.48999,0.15399169 32,11.294986 32,19.745 16.359985,8.5149861 0,19.745 0,11.294986 16.22699,0.15399169z";
                    }
                    else
                    {
                        ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Last().Content = "M0.085998535,0L16.112,11.464981 32,0.118011 32,8.3990061 16.115005,19.745 0,8.2079966 0,0.072997569z";
                    }
                }

                else if ((this.LayoutManager.Layout as DirectedTreeLayout).Orientation == TreeOrientation.LeftToRight)
                {
                    if (node.IsExpanded)
                    {
                        ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Last().Content = "M12.970992,0L21.524992,0 11.658996,12.152008 8.5930022,15.931 8.6660002,16.020996 11.772003,19.846008 21.636,32 13.082,32 4.3889922,21.290009 4.3150023,21.200989 4.2769927,21.247009 0,15.977997 4.2769927,10.708008z";
                    }
                    else
                    {
                        ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Last().Content = "M0,0L8.5539884,0 17.246985,10.709991 17.32099,10.799011 17.359992,10.752991 21.637002,16.022003 17.359992,21.291992 8.6659879,32 0.11099243,32 9.9780006,19.847992 13.043004,16.069 12.970006,15.977997 9.8639869,12.153992z";
                    }
                }

                else if ((this.LayoutManager.Layout as DirectedTreeLayout).Orientation == TreeOrientation.RightToLeft)
                {
                    if (node.IsExpanded)
                    {
                        ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Last().Content = "M0,0L8.5539884,0 17.246985,10.709991 17.32099,10.799011 17.359992,10.752991 21.637002,16.022003 17.359992,21.291992 8.6659879,32 0.11099243,32 9.9780006,19.847992 13.043004,16.069 12.970006,15.977997 9.8639869,12.153992z";
                    }
                    else
                    {
                        ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Last().Content = "M12.970992,0L21.524992,0 11.658996,12.152008 8.5930022,15.931 8.6660002,16.020996 11.772003,19.846008 21.636,32 13.082,32 4.3889922,21.290009 4.3150023,21.200989 4.2769927,21.247009 0,15.977997 4.2769927,10.708008z";
                    }
                }
            }
        }

        private void OnExpandCollapse(object obj)
        {
            organizationallayoutNode node = (this.SelectedItems as SelectorViewModel).SelectedItem as organizationallayoutNode;
            (this.Info as IGraphInfo).Commands.ExpandCollapse.Execute(new ExpandCollapseParameter() { Node = node });
            ExpandCollapseArrowDirection(node);
            this.LayoutManager.Layout.InvalidateLayout();
        }

        private void OnEditCommand(object obj)
        {
            Properties propertieswindow = new Properties();
            propertieswindow.Owner = this.View;
            propertieswindow.DataContext = (this.SelectedItems as SelectorViewModel).SelectedItem as organizationallayoutNode;
            propertieswindow.ShowDialog();
        }

        private void OnNewItemAdded(object obj)
        {
            if ((this.SelectedItems as SelectorViewModel).SelectedItem is INode)
            {
                organizationallayoutNode selectednode = (this.SelectedItems as SelectorViewModel).SelectedItem as organizationallayoutNode;
                if(!(selectednode.IsExpanded))
                {
                    OnExpandCollapse(selectednode);
                }
                ExpandCollapseArrowDirection(selectednode);
                selectednode.IsSelected = false;

                organizationallayoutNode newnode = new organizationallayoutNode()
                {
                    TemplateName = selectednode.TemplateName,
                    ContentTemplate = selectednode.ContentTemplate,
                    Name = "ChildNode",
                    Constraints = NodeConstraints.Default & ~NodeConstraints.Connectable | NodeConstraints.AllowDrop,
                    CustomContent = new CustomContent()
                    {
                        Image = "/syncfusion.organizationallayout.wpf;component/Asset/male.png",
                        ImageVisibility = 100,
                        FillColor = selectednode.CustomContent.FillColor,
                        StrokeColor = selectednode.CustomContent.StrokeColor,
                    },
                };

                newnode.Annotations = new AnnotationCollection();

                if (MenuBar.EmpName.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.Name,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        Foreground = this.MenuBar.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.MenuBar.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.MenuBar.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (MenuBar.Designation.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.Role,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        Foreground = this.MenuBar.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.MenuBar.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.MenuBar.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (MenuBar.EMPID.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.EmployeeID,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        Foreground = this.MenuBar.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.MenuBar.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.MenuBar.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (MenuBar.Team.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.Team,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        Foreground = this.MenuBar.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.MenuBar.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.MenuBar.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (MenuBar.EMail.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.Email,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        Foreground = this.MenuBar.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.MenuBar.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.MenuBar.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (MenuBar.PhoneNumber.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.PhoneNumber,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        Foreground = this.MenuBar.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.MenuBar.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.MenuBar.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (MenuBar.DirectControl.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.DirectControl,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        Foreground = this.MenuBar.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.MenuBar.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.MenuBar.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (MenuBar.Tier.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.Tier,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        Foreground = this.MenuBar.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.MenuBar.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.MenuBar.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                int annocount = (newnode.Annotations as AnnotationCollection).Count();
                SetOffset(annocount, newnode, newnode.TemplateName);
                (this.Nodes as ObservableCollection<organizationallayoutNode>).Add(newnode);
                UpdateDirectControl();

                organizationallayoutConnector con = new organizationallayoutConnector()
                {
                    SourceNode = selectednode,
                    TargetNode = newnode,
                };

                (this.Connectors as ObservableCollection<organizationallayoutConnector>).Add(con);

                selectednode.IsSelected = true;
            }

            this.LayoutManager.Layout.InvalidateLayout();
        }

        private void UpdateDirectControl()
        {
            foreach(organizationallayoutNode node in Nodes as ObservableCollection<organizationallayoutNode>)
            {
                if(node.Name == "ParentNode")
                {
                    if ((node.Info as INodeInfo).OutNeighbors != null)
                    {
                        node.CustomContent.DirectControl = (node.Info as INodeInfo).OutNeighbors.Count().ToString();
                    }
                    else
                    {
                        node.CustomContent.DirectControl = "0";
                    }
                }
                else
                {
                    if((node.Info as INodeInfo).InNeighbors != null && (node.Info as INodeInfo).InNeighbors.Count() > 0)
                    {                       
                        if((node.Info as INodeInfo).InNeighbors.First() is organizationallayoutNode)
                        {
                            organizationallayoutNode parentnode = (node.Info as INodeInfo).InNeighbors.First() as organizationallayoutNode;
                            if(parentnode.Name == "ParentNode")
                            {
                                if ((node.Info as INodeInfo).OutNeighbors != null)
                                {
                                    node.CustomContent.DirectControl = (node.Info as INodeInfo).OutNeighbors.Count().ToString();
                                }
                                else
                                {
                                    node.CustomContent.DirectControl = "0";
                                }
                            }
                            else
                            {
                                if ((node.Info as INodeInfo).OutNeighbors != null)
                                {
                                    node.CustomContent.DirectControl = (node.Info as INodeInfo).OutNeighbors.Count().ToString();
                                }
                                else
                                {
                                    node.CustomContent.DirectControl = "0";
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SetOffset(int annocount, organizationallayoutNode node, string TemplateName)
        {
            if (TemplateName == "ImageTopTemplate")
            {
                if (node.Annotations == null || (node.Annotations as AnnotationCollection).Count < 3)
                {
                    node.UnitHeight = 100;
                    node.UnitWidth = 150;
                }
                else
                {
                    node.UnitHeight = 100 + (node.Annotations as AnnotationCollection).Count * 20;
                    node.UnitWidth = 150;
                }

                foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                {
                    anno.VerticalAlignment = VerticalAlignment.Center;
                    anno.HorizontalAlignment = HorizontalAlignment.Center;
                    anno.TextHorizontalAlignment = TextAlignment.Center;
                    anno.UnitWidth = 90;
                }

                if (annocount == 1)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.6);
                }

                if (annocount == 2)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.6);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.8);
                }

                if (annocount == 3)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.45);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.65);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.5, 0.85);
                }

                if (annocount == 4)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.40);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.55);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.5, 0.70);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.5, 0.85);
                }

                if (annocount == 5)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.35);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.48);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.5, 0.61);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.5, 0.74);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.5, 0.87);
                }

                if (annocount == 6)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.32);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.44);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.5, 0.56);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.5, 0.68);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.5, 0.80);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.5, 0.92);
                }

                if (annocount == 7)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.27);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.38);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.5, 0.49);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.5, 0.60);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.5, 0.71);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.5, 0.82);
                    (node.Annotations as AnnotationCollection).ElementAt(6).Offset = new Point(0.5, 0.93);
                }

                if (annocount == 8)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.25);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.35);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.5, 0.45);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.5, 0.55);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.5, 0.65);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.5, 0.75);
                    (node.Annotations as AnnotationCollection).ElementAt(6).Offset = new Point(0.5, 0.85);
                    (node.Annotations as AnnotationCollection).ElementAt(7).Offset = new Point(0.5, 0.95);
                }
            }

            else if (TemplateName == "ImageLeftTemplate")
            {
                if ((node.Annotations as AnnotationCollection).Count < 3)
                {
                    node.UnitHeight = 50;
                    node.UnitWidth = 150;
                }
                else
                {
                    node.UnitWidth = 150;
                    node.UnitHeight = (node.Annotations as AnnotationCollection).Count * 20 + 10;
                }

                foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                {
                    anno.VerticalAlignment = VerticalAlignment.Center;
                    anno.HorizontalAlignment = HorizontalAlignment.Left;
                    anno.TextHorizontalAlignment = TextAlignment.Left;
                    anno.UnitWidth = 60;
                }

                if (annocount == 1)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.5);
                }

                if (annocount == 2)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.25);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.70);
                }

                if (annocount == 3)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.20);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.50);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.35, 0.80);
                }

                if (annocount == 4)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.12);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.37);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.35, 0.62);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.35, 0.87);
                }

                if (annocount == 5)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.10);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.30);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.35, 0.50);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.35, 0.70);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.35, 0.90);
                }

                if (annocount == 6)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.10);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.26);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.35, 0.42);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.35, 0.58);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.35, 0.74);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.35, 0.90);
                }

                if (annocount == 7)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.08);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.22);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.35, 0.36);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.35, 0.50);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.35, 0.64);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.35, 0.78);
                    (node.Annotations as AnnotationCollection).ElementAt(6).Offset = new Point(0.35, 0.92);
                }

                if (annocount == 8)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.08);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.20);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.35, 0.32);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.35, 0.44);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.35, 0.56);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.35, 0.68);
                    (node.Annotations as AnnotationCollection).ElementAt(6).Offset = new Point(0.35, 0.80);
                    (node.Annotations as AnnotationCollection).ElementAt(7).Offset = new Point(0.35, 0.92);
                }
            }

            else
            {
                if ((node.Annotations as AnnotationCollection).Count < 3)
                {
                    node.UnitHeight = 50;
                    node.UnitWidth = 120;
                }
                else
                {
                    node.UnitWidth = 120;
                    node.UnitHeight = (node.Annotations as AnnotationCollection).Count * 20 + 10;
                }

                foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                {
                    anno.VerticalAlignment = VerticalAlignment.Center;
                    anno.HorizontalAlignment = HorizontalAlignment.Left;
                    anno.TextHorizontalAlignment = TextAlignment.Left;
                    anno.UnitWidth = 75;
                }

                if (annocount == 1)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.5);
                }

                if (annocount == 2)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.25);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.70);
                }

                if (annocount == 3)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.20);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.50);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.1, 0.80);
                }

                if (annocount == 4)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.12);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.37);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.1, 0.62);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.1, 0.87);
                }

                if (annocount == 5)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.10);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.30);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.1, 0.50);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.1, 0.70);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.1, 0.90);
                }

                if (annocount == 6)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.10);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.26);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.1, 0.42);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.1, 0.58);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.1, 0.74);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.1, 0.90);
                }

                if (annocount == 7)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.08);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.22);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.1, 0.36);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.1, 0.50);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.1, 0.64);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.1, 0.78);
                    (node.Annotations as AnnotationCollection).ElementAt(6).Offset = new Point(0.1, 0.92);
                }

                if (annocount == 8)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.08);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.20);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.1, 0.32);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.1, 0.44);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.1, 0.56);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.1, 0.68);
                    (node.Annotations as AnnotationCollection).ElementAt(6).Offset = new Point(0.1, 0.80);
                    (node.Annotations as AnnotationCollection).ElementAt(7).Offset = new Point(0.1, 0.92);
                }
            }
        }

        private void AddQuickCommands()
        {
            if (((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Count == 0)
            {
                QuickCommandVM AddQuickCommand = new QuickCommandVM()
                {
                    Shape = View.Resources["Ellipse"],
                    OffsetX = 1,
                    OffsetY = 1,
                    Command = AddNewItemCommand,
                    Content = "M13.55896,0L18.461914,0 18.461914,13.557983 32,13.557983 32,18.481018 18.5,18.481018 18.5,32 13.55896,32 13.55896,18.481018 0,18.481018 0,13.557983 13.55896,13.557983z",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 25, 0, 0),
                    ToolTip = "Add New Child",
                };
                ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Add(AddQuickCommand);

                QuickCommandVM EditQuickCommand = new QuickCommandVM()
                {
                    Shape = View.Resources["Ellipse"],
                    OffsetX = 1,
                    OffsetY = 0,
                    Command = EditCommand,
                    Content = "M19.312381,27.48482L18.503085,29.661004 20.944314,29.115917z M24.540007,21.633355L20.390685,25.734296 22.789237,28.131621 26.97936,24.028763z M27.175001,19.029084L25.962399,20.227547 28.408086,22.629793 29.616994,21.446061z M10.602995,15C5.8599977,15 1.999999,18.829 1.999999,23.536 1.999999,24.895 3.1159983,26 4.4899979,26L17.731456,26 17.992104,25.299033 18.172095,25.116051 18.171058,25.116051 23.266144,20.080393 23.156942,19.84575C22.697614,18.897562 22.06124,18.03375 21.28199,17.31 19.682991,15.82 17.592992,15 15.397993,15L12.999995,15z M12.999995,2C9.9420033,2 7.45401,4.467 7.45401,7.5 7.45401,9.947 9.1090055,12.123 11.478999,12.791 12.461997,13.068 13.535994,13.069 14.521991,12.791 16.891984,12.122 18.54598,9.9459996 18.54598,7.5 18.54598,4.467 16.057987,2 12.999995,2z M12.999995,0C17.160984,0 20.545975,3.3639994 20.545975,7.5 20.545975,9.6899061 19.575261,11.720467 17.995872,13.115179L17.808254,13.274325 17.879796,13.290484C19.650854,13.712344 21.290927,14.584437 22.645989,15.846 23.445364,16.590375 24.124036,17.454672 24.656125,18.399828L24.764509,18.599506 26.399983,16.983108C26.614001,16.772111 26.895004,16.666856 27.175756,16.666978 27.456508,16.6671 27.737007,16.772599 27.950018,16.983108L31.969938,20.961079 31.999967,21.450059C31.999967,21.74208,31.88095,22.027051,31.672944,22.233074L23.04003,30.684984 22.706048,30.770982 17.325118,31.973977C17.245102,31.991006 17.165085,31.999978 17.085069,31.999978 16.769093,31.999978 16.464103,31.863993 16.252069,31.619976 15.987118,31.314985 15.91113,30.89 16.054073,30.511035L16.987776,28 4.4899979,28C2.013999,28 0,25.997 0,23.536 0,18.633812 3.3858614,14.50334 7.9561033,13.332249L8.1918802,13.274945 8.0051279,13.116582C6.4251604,11.721779 5.4540157,9.6905622 5.4540157,7.5 5.4540157,3.3639994 8.8390064,0 12.999995,0z",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(20, -15, 0, 0),
                    ToolTip = "Edit Fields",
                };
                ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Add(EditQuickCommand);

                QuickCommandVM ExpandCollapseQuickCommand = new QuickCommandVM()
                {
                    Shape = View.Resources["Ellipse"],
                    OffsetX = 0.5,
                    OffsetY = 1,
                    Command = ExpandCollapseCommand,
                    Content = "M16.261993,0L16.359985,0.065002445 16.454987,0 16.48999,0.15399169 32,11.294986 32,19.745 16.359985,8.5149861 0,19.745 0,11.294986 16.22699,0.15399169z",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 25, 0, 0),
                    ToolTip = "Expand/Collapse Child",
                };
                ((this.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).Add(ExpandCollapseQuickCommand);
            }
        }

        private void OnOrgChartChanged(object obj)
        {
            orglayouttype = obj.ToString();
            this.LayoutManager.Layout.UpdateLayout();
        }

        private void OnGetLayoutInfo(object obj)
        {
            var args = obj as LayoutInfoArgs;
            if (LayoutManager.Layout is DirectedTreeLayout)
            {
                if ((LayoutManager.Layout as DirectedTreeLayout).Type == LayoutType.Organization)
                {
                    if (args.Children.Count > 1)
                    {
                        organizationallayoutNode assistantnode = null;
                        foreach (organizationallayoutNode node in args.Children)
                        {
                            if (node.Name.ToString() == "AssistantNode")
                            {
                                assistantnode = node;
                            }
                        }

                        if (assistantnode != null)
                        {
                            args.Assistants.Add(assistantnode);
                            args.Children.Remove(assistantnode);
                        }
                    }

                    switch (orglayouttype)
                    {
                        case "VerticalLeft":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Left;
                                args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "VerticalRight":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Right;
                                args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "VerticalCentre":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Center;
                                args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "HorizontalCenter":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Center;
                                args.Orientation = Orientation.Horizontal;
                            }
                            break;
                        case "HorizontalRight":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Right;
                                args.Orientation = Orientation.Horizontal;
                            }
                            break;
                        case "HorizontalLeft":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Left;
                                args.Orientation = Orientation.Horizontal;
                            }
                            break;
                        case "VerticalAlternate":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Alternate;
                                args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "HorizontalAlternate":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Alternate;
                                args.Orientation = Orientation.Horizontal;
                            }
                            break;
                    }
                }
            }
        }

        private void OnItemDrop(object obj)
        {
            var args = obj as ItemDropEventArgs;
            if (!(args.Target is SfDiagram) && args.Source is organizationallayoutNode)
            {
                if (args.Target is IEnumerable<object>)
                {
                    if ((args.Target as IEnumerable<object>).First() is organizationallayoutNode)
                    {
                        organizationallayoutNode targetnode = (args.Target as IEnumerable<object>).First() as organizationallayoutNode;
                        organizationallayoutNode sourcenode = args.Source as organizationallayoutNode;
                        if ((sourcenode.Info as INodeInfo).InConnectors != null
                            && ((sourcenode.Info as INodeInfo).InConnectors as IEnumerable<object>).Count() > 0)
                        {
                            organizationallayoutConnector con = ((sourcenode.Info as INodeInfo).InConnectors as IEnumerable<object>).First() as organizationallayoutConnector;
                            con.SourceNode = targetnode;
                            con.TargetNode = sourcenode;
                        }
                        else
                        {
                            organizationallayoutConnector con = new organizationallayoutConnector();
                            con.SourceNode = targetnode;
                            con.TargetNode = sourcenode;
                            (this.Connectors as ObservableCollection<organizationallayoutConnector>).Add(con);
                        }

                    }
                }
            }
            this.LayoutManager.Layout.InvalidateLayout();
            UpdateDirectControl();
        }

        public string LayoutOrientation
        {
            get
            {
                return this._LayoutOrientation;
            }
            set
            {
                if (_LayoutOrientation != value)
                {
                    _LayoutOrientation = value;
                    this.OnPropertyChanged("LayoutOrientation");
                    OnLayoutOrientationChanged(_LayoutOrientation);
                }
            }
        }

        private void OnLayoutOrientationChanged(string layoutorientation)
        {
            if (LayoutManager != null && LayoutManager.Layout != null)
            {
                if (layoutorientation == "Top To Bottom")
                {
                    (LayoutManager.Layout as DirectedTreeLayout).Orientation = TreeOrientation.TopToBottom;
                }
                else if (layoutorientation == "Bottom To Top")
                {
                    (LayoutManager.Layout as DirectedTreeLayout).Orientation = TreeOrientation.BottomToTop;
                }
                else if (layoutorientation == "Right To Left")
                {
                    (LayoutManager.Layout as DirectedTreeLayout).Orientation = TreeOrientation.RightToLeft;
                }
                else if (layoutorientation == "Left To Right")
                {
                    (LayoutManager.Layout as DirectedTreeLayout).Orientation = TreeOrientation.LeftToRight;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the zoom parameter.
        /// </summary>
        public ZoomParameter ZoomParameter
        {
            get
            {
                return this._ZoomParameter;
            }

            set
            {
                if (this._ZoomParameter != value)
                {
                    this._ZoomParameter = value;
                    this.OnPropertyChanged("ZoomParameter");
                }
            }
        }

        public organizationallayoutdemo View
        {
            get
            {
                return this.view;
            }
            set
            {
                if (this.view != value)
                {
                    this.view = value;
                    this.PopulateRecentFiles();
                    this.PopulateTemplateFiles();
                    this.OnPropertyChanged("View");
                }
            }
        }

        public ICommand OrgChartCommand { get; set; }

        public ICommand BackStageOpeningCommand { get; set; }

        public ICommand AddNewItemCommand { get; set; }

        public ICommand ExpandCollapseCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand CreateCommand { get; set; }

        public ICommand OpenCommand { get; set; }

        public ICommand ExternalOpenCommand { get; set; }

        public ICommand LoadTemplateCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand PrintCommand { get; set; }

        public ICommand ExportCommand { get; set; }

        public ICommand ZoomInCommand { get; set; }

        public ICommand ZoomOutCommand { get; set; }

        public bool ShowBackStage
        {
            get
            {
                return showBackStage;
            }
            set
            {
                if (showBackStage != value)
                {
                    showBackStage = value;
                    this.OnPropertyChanged("ShowBackStage");
                }
            }
        }

        public bool ShowMainView
        {
            get
            {
                return showMainView;
            }
            set
            {
                if (showMainView != value)
                {
                    showMainView = value;
                    this.OnPropertyChanged("ShowMainView");
                }
            }
        }

        public string SelectedFileName
        {
            get
            {
                return selectedFileName;
            }
            set
            {
                if (selectedFileName != value)
                {
                    selectedFileName = value;
                    this.OnPropertyChanged("SelectedFileName");
                }
            }
        }

        public MenuBar MenuBar
        {
            get
            {
                return menubar;
            }
            set
            {
                if (menubar != value)
                {
                    menubar = value;
                    this.OnPropertyChanged("MenuBar");
                }
            }
        }

        public string SelectedFolderPath
        {
            get
            {
                return selectedFolderPath;
            }
            set
            {
                if (selectedFolderPath != value)
                {
                    selectedFolderPath = value;
                    this.OnPropertyChanged("SelectedFolderName");
                }
            }
        }

        public bool ZoomInEnabled
        {
            get
            {
                return zoomInEnabled;
            }
            set
            {
                if (zoomInEnabled != value)
                {
                    zoomInEnabled = value;
                    OnPropertyChanged("ZoomInEnabled");
                }
            }
        }

        public bool ZoomOutEnabled
        {
            get
            {
                return zoomOutEnabled;
            }
            set
            {
                if (zoomOutEnabled != value)
                {
                    zoomOutEnabled = value;
                    OnPropertyChanged("ZoomOutEnabled");
                }
            }
        }

        public double CurrentZoom
        {
            get
            {
                return currentZoom;
            }
            set
            {
                if (currentZoom != value)
                {
                    currentZoom = value;
                    OnPropertyChanged("CurrentZoom");
                }
            }
        }

        public string ZoomPercentageValue
        {
            get
            {
                return zoomPercentageValue;
            }
            set
            {
                if (zoomPercentageValue != value)
                {
                    zoomPercentageValue = value;
                    OnPropertyChanged("ZoomPercentageValue");
                }
            }
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);

            if (name == "CurrentZoom")
            {
                (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter()
                {
                    ZoomCommand = ZoomCommand.Zoom,
                    ZoomTo = currentZoom,
                });
            }
            else if (name == "ZoomPercentageValue")
            {
                var zoomValue = Convert.ToDouble(zoomPercentageValue.Split('%')[0]) / 100;
                (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter()
                {
                    ZoomCommand = ZoomCommand.Zoom,
                    ZoomTo = zoomValue,
                });
            }
        }

        private void OnBackStageOpening(object obj)
        {
            if (!string.IsNullOrEmpty(this.selectedFileName))
            {
                this.SaveSelectedFile();

                RecentFileButton currentFileButton = null;
                foreach (var element in this.View.RecentArea.Children)
                {
                    if ((element as RecentFileButton).FileName == this.selectedFileName)
                    {
                        currentFileButton = element as RecentFileButton;
                        break;
                    }
                }

                if (currentFileButton != null)
                {
                    this.View.RecentArea.Children.Remove(currentFileButton);
                    this.View.RecentArea.Children.Insert(0, currentFileButton);
                }

                this.SelectedFileName = String.Empty;
                this.ShowMainView = false;
                this.ShowBackStage = true;
            }
        }

        private void OnCreate(object fileName)
        {
            this.CreateFile(fileName.ToString(), true);
            FocusManager.SetFocusedElement(this.View, this.View.Diagram);
            this.ShowMainView = true;
            this.ShowBackStage = false;
            SetPictureAndFields();
        }

        private void SetPictureAndFields()
        {
            if ((this.Nodes as ObservableCollection<organizationallayoutNode>).Count > 0)
            {
                organizationallayoutNode node = (this.Nodes as ObservableCollection<organizationallayoutNode>).First() as organizationallayoutNode;
                if (node.TemplateName == "NoImageTemplate")
                {
                    this.MenuBar.Picture.IsEnabled = false;
                }
                else
                {
                    if ((this.SelectedItems as SelectorViewModel).SelectedItem is organizationallayoutNode)
                    {
                        this.MenuBar.Picture.IsEnabled = true;
                    }
                    else
                    {
                        this.MenuBar.Picture.IsEnabled = false;
                    }
                }

                if (node.CustomContent != null)
                {
                    this.MenuBar.EmpName.IsChecked = node.CustomContent.NameSelected;
                    this.MenuBar.Designation.IsChecked = node.CustomContent.RoleSelected;
                    this.MenuBar.EMail.IsChecked = node.CustomContent.MailSelected;
                    this.MenuBar.PhoneNumber.IsChecked = node.CustomContent.PhoneSelected;
                    this.MenuBar.DirectControl.IsChecked = node.CustomContent.DirectControlSelected;
                    this.MenuBar.Tier.IsChecked = node.CustomContent.TierSelected;
                    this.MenuBar.EMPID.IsChecked = node.CustomContent.EMPIDSelected;
                    this.MenuBar.Team.IsChecked = node.CustomContent.TeamSelected;
                }
            }
        }

        private void CreateFile(string fileName, bool resetDiagram = false)
        {
            this.SelectedFileName = IOPath.GetFileNameWithoutExtension(fileName.ToString());
            this.SelectedFolderPath = IOPath.GetDirectoryName(fileName.ToString());
            if (File.Exists(IOPath.Combine(this.selectedFolderPath, this.selectedFileName + ".xml")))
            {
                int i = 1;
                do
                {
                    i++;
                }
                while (File.Exists(IOPath.Combine(this.selectedFolderPath, this.selectedFileName + "(" + i + ")" + ".xml")));
                this.SelectedFileName = string.Format("{0}({1})", this.selectedFileName, i);
            }

            using (Stream stream = File.Create(this.selectedFolderPath + @"\" + this.selectedFileName + ".xml"))
            {
                stream.SetLength(0);
                if (resetDiagram)
                {
                    this.Nodes = new ObservableCollection<organizationallayoutNode>();
                    this.Connectors = new ObservableCollection<organizationallayoutConnector>();
                    this.Groups = new GroupCollection();
                    this.PageSettings.PageBackground = new System.Windows.Media.SolidColorBrush(Colors.Transparent);
                    if (this.ScrollSettings.ScrollInfo != null)
                    {
                        (this.Info as IGraphInfo).Commands.Reset.Execute(null);
                    }

                    //(this.Info as IGraphInfo).Save(stream);
                    this.AddParentNode();
                    this.AddQuickCommands();
                    (this.Info as IGraphInfo).ClearHistory();
                }
            }

            this.PopulateRecentFiles(true);
        }

        private void OnTemplateLoad(object fileName)
        {
            this.SelectedFileName = IOPath.GetFileNameWithoutExtension(fileName.ToString());
            this.SelectedFolderPath = IOPath.GetDirectoryName(fileName.ToString());
            this.PopulateRecentFiles(true);
            this.OnOpenSelectedFile();
        }

        private void OnExternalOpen(object obj)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                this.SelectedFileName = IOPath.GetFileNameWithoutExtension(dialog.FileName);
                this.SelectedFolderPath = IOPath.GetDirectoryName(dialog.FileName);
                this.PopulateRecentFiles(true);
                this.OnOpenSelectedFile();
            }
        }

        private void OnOpen(object fileName)
        {
            this.SelectedFileName = IOPath.GetFileNameWithoutExtension(fileName.ToString());
            this.SelectedFolderPath = IOPath.GetDirectoryName(fileName.ToString());
            this.OnOpenSelectedFile();
        }

        private void OnOpenSelectedFile()
        {
            var fileName = IOPath.Combine(this.selectedFolderPath, this.selectedFileName + ".xml");
            if (File.Exists(fileName))
            {
                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    (this.Info as IGraphInfo).Load(stream);
                }

                (this.Info as IGraphInfo).ClearHistory();
                FocusManager.SetFocusedElement(this.View, this.View.Diagram);
                this.ShowMainView = true;
                this.ShowBackStage = false;
                this.AddQuickCommands();
                SetPictureAndFields();
                this.LayoutManager.Layout.InvalidateLayout();
                UpdateDirectControl();
            }
        }

        private void AddParentNode()
        {
            organizationallayoutNode parentnode = new organizationallayoutNode()
            {
                UnitHeight = 100,
                UnitWidth = 100,
                Name = "ParentNode",
                TemplateName = "ImageTopTemplate",
                ContentTemplate = View.Resources["ImageTopTemplate"] as DataTemplate,
                Constraints = NodeConstraints.Default & ~NodeConstraints.Connectable | NodeConstraints.AllowDrop,
                CustomContent = new CustomContent()
                {
                    Image = "/syncfusion.organizationallayout.wpf;component/Asset/male.png",
                    ImageVisibility = 100,
                },
            };

            parentnode.Annotations = new AnnotationCollection();

            (parentnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
            {
                Content = parentnode.CustomContent.Name,
                FontSize = 10,
                WrapText = TextWrapping.NoWrap,
                TextHorizontalAlignment = TextAlignment.Center,
                TextVerticalAlignment = VerticalAlignment.Center,
                TextTrimming = TextTrimming.WordEllipsis,
                Offset = new Point(0.5, 0.5),
                Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
            });

            (parentnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
            {
                Content = parentnode.CustomContent.Role,
                FontSize = 10,
                WrapText = TextWrapping.NoWrap,
                TextHorizontalAlignment = TextAlignment.Center,
                TextVerticalAlignment = VerticalAlignment.Center,
                TextTrimming = TextTrimming.WordEllipsis,
                Offset = new Point(0.5, 0.8),
                Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
            });

            (this.Nodes as ObservableCollection<organizationallayoutNode>).Add(parentnode);

            this.LayoutManager.Layout.InvalidateLayout();
        }

        private void OnSave(object parameter)
        {
            if (parameter != null && parameter.ToString() == "Save As")
            {
                var dialog = new SaveFileDialog()
                {
                    Title = "Save Plan",
                    Filter = "XML File (*.xml)|*.xml",
                    InitialDirectory = IOPath.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Organizational Layout")
                };
                if (dialog.ShowDialog() == true)
                {
                    this.CreateFile(dialog.FileName);
                    this.SaveSelectedFile();
                }
            }
            else if (!(string.IsNullOrEmpty(this.selectedFolderPath) || string.IsNullOrEmpty(this.selectedFileName)))
            {
                this.SaveSelectedFile();
            }
        }

        private void SaveSelectedFile()
        {
            var fullFileName = IOPath.Combine(this.selectedFolderPath, selectedFileName + ".xml");
            if (File.Exists(fullFileName))
            {
                using (Stream stream = File.Open(fullFileName, FileMode.OpenOrCreate))
                {
                    stream.SetLength(0);
                    (this.Info as IGraphInfo).Save(stream);
                }
            }
        }

        private void OnPrint(object parameter)
        {
            if (!string.IsNullOrEmpty(this.selectedFileName))
            {
                this.PrintingService.ShowDialog = true;
                this.PrintingService.Print();
            }
        }

        private void OnExport(object parameter)
        {
            var Extension = "BMP File (*.bmp)|*.bmp|WDP File (*.wdp)|*.wdp|JPG File(*.jpg)|*.jpg|PNG File(*.png)|*.png|TIF File(*.tif)|*.tif|GIF File(*.gif)|*.gif|XPS File(*.xps)|*.xps|PDF File(*.pdf)|*.pdf";
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = Extension;
            ExportSettings.ExportBackground = new System.Windows.Media.SolidColorBrush(Colors.White);


            if (saveFileDialog.ShowDialog() == true)
            {
                string filenamechanged;
                var extension = IOPath.GetExtension(saveFileDialog.FileName).TrimStart('.');
                var fileName = saveFileDialog.FileName;
                if (extension != "")
                {
                    if (extension.ToLower() == "pdf")
                    {
                        filenamechanged = fileName + ".xps";
                        ExportSettings.IsSaveToXps = true;
                        this.ExportSettings.FileName = filenamechanged;

                        // Method to Export the SfDiagram
                        (this.Info as IGraphInfo).Export();

                        var converter = new XPSToPdfConverter { };
                        var document = new PdfDocument();
                        document = converter.Convert(filenamechanged);
                        document.Save(fileName);
                        document.Close(true);
                    }
                    else
                    {
                        if (extension.ToLower() == "xps")
                        {
                            ExportSettings.IsSaveToXps = true;
                        }

                        ExportType exportType;
                        Enum.TryParse(extension.ToUpper(), out exportType);
                        this.ExportSettings.ExportType = exportType;

                        this.ExportSettings.FileName = fileName;
                        (this.Info as IGraphInfo).Export();
                    }
                }
            }
        }

        private void OnItemAdded(object parameter)
        {
            var args = parameter as ItemAddedEventArgs;

            if(args.ItemSource == ItemSource.ClipBoard)
            {
                (this.Info as IGraphInfo).Commands.Delete.Execute(null);
            }

            if(args.Item is organizationallayoutNode)
            {
                if((args.Item as organizationallayoutNode).Name == "ParentNode")
                {
                    (args.Item as organizationallayoutNode).CustomContent.SelectionColor = new System.Windows.Media.SolidColorBrush(Colors.OrangeRed);
                }
                else if((args.Item as organizationallayoutNode).Name == "ChildNode")
                {
                    (args.Item as organizationallayoutNode).CustomContent.SelectionColor = new System.Windows.Media.SolidColorBrush(Colors.DeepSkyBlue);
                }
                else
                {
                    (args.Item as organizationallayoutNode).CustomContent.SelectionColor = new System.Windows.Media.SolidColorBrush(Colors.SpringGreen);
                }
                UpdateDirectControl();
            }

            if (args.ItemSource == ItemSource.Load)
            {
                if (args.Item is INode)
                {
                    var node = args.Item as INode;
                    node.Constraints = NodeConstraints.Default | NodeConstraints.AllowDrop;
                    node.ContentTemplate = View.Resources[(node as organizationallayoutNode).TemplateName] as DataTemplate;
                }
                UpdateDirectControl();
            }

            if(args.Item is organizationallayoutConnector)
            {
                organizationallayoutConnector con = args.Item as organizationallayoutConnector;
                con.Constraints = con.Constraints.Remove(ConnectorConstraints.Selectable);
            }
        }

        private void OnViewPortChanged(object parameter)
        {
            var args = parameter as ChangeEventArgs<object, ScrollChanged>;
            ZoomInEnabled = !(args.NewValue.CurrentZoom >= this.ScrollSettings.MaxZoom);
            ZoomOutEnabled = !(args.NewValue.CurrentZoom <= this.ScrollSettings.MinZoom);
            CurrentZoom = args.NewValue.CurrentZoom;
            ZoomPercentageValue = Math.Round(currentZoom * 100, 2).ToString() + "%";
            contentBounds = args.NewValue.ContentBounds;
            if (this.ZoomParameter != null)
            {
                var text = this.ZoomParameter.PercentageText;
                this.ZoomParameter.IsFiftyPercentZoom = this.ZoomParameter.IsHundredPercentZoom = this.ZoomParameter.IsOneFiftyPercentZoom = this.ZoomParameter.IsPageWidthZoom = this.ZoomParameter.IsPercentageZoom =
                    this.ZoomParameter.IsSeventyFivePercentZoom = this.ZoomParameter.IsTwoHundredPercentZoom = this.ZoomParameter.IsWholePageZoom = false;
                if (text != "Width" && text != "Page")
                {
                    this.ZoomParameter.PercentageText = Math.Floor(this.CurrentZoom * 100).ToString();

                    if (text == "200")
                    {
                        this.ZoomParameter.IsTwoHundredPercentZoom = true;
                    }
                    else if (text == "150")
                    {
                        this.ZoomParameter.IsOneFiftyPercentZoom = true;
                    }
                    else if (text == "100")
                    {
                        this.ZoomParameter.IsHundredPercentZoom = true;
                    }
                    else if (text == "75")
                    {
                        this.ZoomParameter.IsSeventyFivePercentZoom = true;
                    }
                    else if (text == "50")
                    {
                        this.ZoomParameter.IsFiftyPercentZoom = true;
                    }
                    else
                    {
                        this.ZoomParameter.IsPercentageZoom = true;
                    }
                }
                else if (text == "Width")
                {
                    this.ZoomParameter.IsPageWidthZoom = true;
                }
                else if (text == "Page")
                {
                    this.ZoomParameter.IsWholePageZoom = true;
                }
                else
                {
                    this.ZoomParameter.IsPercentageZoom = true;
                }
            }

        }

        private void PopulateTemplateFiles()
        {
            foreach (var name in predefinedDiagram)
            {
                var templateFileButton = new TemplateFileButton() { FileName = name, Command = LoadTemplateCommand, ImagePath = "/syncfusion.organizationallayout.wpf;component/Asset/organization.png" };
                this.View.TemplateArea.Children.Add(templateFileButton);
            }
        }

        private void PopulateRecentFiles(bool singleFile = false)
        {
            if (!singleFile)
            {
                var folderPath = IOPath.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Organizational Layout");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                DirectoryInfo info = new DirectoryInfo(folderPath);
                FileInfo[] files = info.GetFiles().OrderByDescending(p => p.LastWriteTime).ToArray();
                foreach (var file in files)
                {
                    string extension = IOPath.GetExtension(file.Name);
                    string recentFileName = file.Name.Substring(0, file.Name.Length - extension.Length);
                    var recentFileButton = new RecentFileButton() { FileName = recentFileName, FolderPath = folderPath, Command = OpenCommand };
                    this.View.RecentArea.Children.Add(recentFileButton);
                }
            }
            else
            {
                var recentFileButton = new RecentFileButton() { FileName = this.selectedFileName, FolderPath = this.selectedFolderPath, Command = OpenCommand };
                this.View.RecentArea.Children.Insert(0, recentFileButton);
            }
        }
        /// <summary>
        /// Represents the zoom command execution.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void OnZoomCommand(object value)
        {
            if (value != null)
            {
                if (this.IsDigitsOnly(value.ToString()) && value.ToString() != string.Empty)
                {
                    double _mZoomValue = Convert.ToDouble(value) / 100;
                    (this.Info as IGraphInfo).Commands.Zoom.Execute(
                        new ZoomPositionParameter { ZoomTo = _mZoomValue, ZoomCommand = ZoomCommand.Zoom });
                }
                else if (value.ToString() == "Whole Page")
                {
                    (this.Info as IGraphInfo).Commands.FitToPage.Execute(
                        new FitToPageParameter { FitToPage = FitToPage.FitToPage, Region = Region.PageSettings });
                }
                else if (value.ToString() == "Page Width")
                {
                    (this.Info as IGraphInfo).Commands.FitToPage.Execute(
                        new FitToPageParameter { FitToPage = FitToPage.FitToWidth, Region = Region.PageSettings });
                }
            }
        }
        /// <summary>
        /// The is digits only.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsDigitsOnly(string value)
        {
            foreach (char c in value)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        private void OnZoomInCommand(object parameter)
        {
            double zoomValue = (this.ScrollSettings.ScrollInfo.CurrentZoom * 0.2d) + this.ScrollSettings.ScrollInfo.CurrentZoom;
            if (zoomValue > 3)
            {
                (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter()
                {
                    ZoomCommand = ZoomCommand.Zoom,
                    ZoomTo = 3,
                });
            }
            else
            {
                (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter()
                {
                    ZoomCommand = ZoomCommand.ZoomIn,
                    ZoomFactor = 0.2,
                });
            }
        }

        private void OnZoomOutCommand(object parameter)
        {
            (this.Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter()
            {
                ZoomCommand = ZoomCommand.ZoomOut,
                ZoomFactor = 0.2,
            });
        }

        private void UpdateCommandGesture()
        {
            var saveGesture = new GestureCommand()
            {
                Command = SaveCommand,
                Gesture = new Gesture
                {
                    KeyModifiers = ModifierKeys.Control,
                    KeyState = KeyStates.Down,
                    Key = System.Windows.Input.Key.S
                }
            };

            var printGesture = new GestureCommand()
            {
                Command = PrintCommand,
                Gesture = new Gesture
                {
                    KeyModifiers = ModifierKeys.Control,
                    KeyState = KeyStates.Down,
                    Key = System.Windows.Input.Key.P
                }
            };

            this.CommandManager.Commands.Add(saveGesture);
            this.CommandManager.Commands.Add(printGesture);
        }
    }

    public class QuickCommandVM : QuickCommandViewModel
    {
        private string _ToolTip;

        public string ToolTip
        {
            get
            {
                return _ToolTip;
            }
            set
            {
                _ToolTip = value;
                OnPropertyChanged("ToolTip");
            }
        }
    }
}
