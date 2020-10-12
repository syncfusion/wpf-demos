#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using OrganizationChart.Layout;
using DiagramBuilder.ViewModel;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Syncfusion.Windows.Shared;
using OrganizationChart.View;
using Microsoft.Win32;
using DiagramBuilder;

namespace OrganizationChart.ViewModel
{
    public class OrganizationChartDiagramVM : DiagramVM
    {
        List<string> RoleAnnotation = new List<string>() {"Role" };

        NodeVMCollection OrgNodeCollection = new NodeVMCollection();
        int id = 0;
        public new NodeVMCollection NodeCollection
        {
            get { return this.Nodes as NodeVMCollection; }
        }
        public new ConnectorVMCollection ConnectorCollection
        {
            get { return this.Connectors as ConnectorVMCollection; }
        }

        public QuickCommandViewModel Quickcommands_Delete;
        public QuickCommandViewModel Quickcommands_Add;


        private DelegateCommand<object> addChildCommand;
        private DelegateCommand<object> editCommand;
        private DelegateCommand<object> deleteCommand;
        private DelegateCommand<object> updatelayout;

        private string compact;

        public DelegateCommand<object> AddChildCommand
        {
            get
            {
                return addChildCommand ??
                    (addChildCommand = new DelegateCommand<object>(AddChildCommandExecute));
            }
        }
        public DelegateCommand<object> EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new DelegateCommand<object>(EditCommandExecute));
            }
        }
        public DelegateCommand<object> DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new DelegateCommand<object>(DeleteCommandExecute));
            }
        }

        private void OrgchartcommandExecute(object obj)
        {
            if (obj.Equals("VerticalCentre"))
            {
                compact = "centre";
            }
            else if (obj.Equals("VerticalRight"))
            {
                compact = "right";
            }
            else if (obj.Equals("VerticalLeft"))
            {
                compact = "left";
            }
            else if (obj.Equals("HorizontalCentre"))
            {
                compact = "horizontal_center";
            }
            else if (obj.Equals("HorizontalRight"))
            {
                compact = "horizontal_right";
            }
            else if (obj.Equals("HorizontalLeft"))
            {
                compact = "horizontal_left";
            }
            else if(obj.Equals("VerticalAlternate"))
            {
                compact = "alternate";
            }
            else if(obj.Equals("HorizontalAlternate"))
            {
                compact = "horizontal_alternate";
            }

            (LayoutManager.Layout as DirectedTreeLayout).UpdateLayout();
        }

        public DelegateCommand<object> UpdateLayoutCommand
        {
            get
            {
                return updatelayout ??
                    (updatelayout = new DelegateCommand<object>(UpdateLayoutCommandExecute));
            }
        }

        public DelegateCommand<object> Orgchartcommand { get; set; }
        public DelegateCommand<object> IncreaseSpacing { get; set; }
        public DelegateCommand<object> DecreaseSpacing { get; set; }
        public DelegateCommand<object> ExpandCollapse { get; set; }
        public DelegateCommand<object> InsertPicture { get; set; }
        public DelegateCommand<object> DeletePicture { get; set; }
        public DelegateCommand<object> ShowhidePicture { get; set; }
        public DelegateCommand<object> QuickShape { get; set; }

        public OrganizationChartDiagramVM()
        {

        }

        public OrganizationChartDiagramVM(string file, bool isValidXml) : base(file, isValidXml)
        {
            Theme = new OfficeTheme();
            this.DefaultConnectorType = ConnectorType.Orthogonal;
            DiagramType = DiagramType.OrganizationChart;
            this.Constraints |= GraphConstraints.Undoable;
            this.Connectors = new ConnectorVMCollection();
            this.Nodes = new NodeVMCollection();
            this.GetLayoutInfoCommand = new DelegateCommand<object>(OnGetLayoutInfoChanged);
            this.Orgchartcommand = new DelegateCommand<object>(OrgchartcommandExecute);
            this.IncreaseSpacing = new DelegateCommand<object>(IncreaseSpacingExecute);
            this.DecreaseSpacing = new DelegateCommand<object>(DecreaseSpacingExecute);
            this.ExpandCollapse = new DelegateCommand<object>(ExpandCollapseExecute);
            this.InsertPicture = new DelegateCommand<object>(InsertPictureExecute);
            this.DeletePicture = new DelegateCommand<object>(DeletePictureExecute);
            this.ShowhidePicture = new DelegateCommand<object>(ShowhidePictureExecute);
            this.QuickShape = new DelegateCommand<object>(OnQuickShapeExecute);

            if (file == null)
            {
                AddRootNode();                
            }
            this.LayoutManager = new LayoutManager()
            {
                Layout = new OrganizationChartLayout()
                {
                    Type = LayoutType.Organization,
                    Orientation = TreeOrientation.TopToBottom,
                    HorizontalSpacing = 50,
                    VerticalSpacing = 50,
                }
            };

            this.DataSourceSettings = new DataSourceSettings()
            {
                DataSource = OrgNodeCollection,
                Id = "ID",
                ParentId = "ParentID",
            };
            this.ItemSelectedCommand = new DelegateCommand<object>(ItemSelectedCommandExecute);
            this.HorizontalRuler = new Ruler()
            {
                Orientation = Orientation.Horizontal,
                BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D4D4D4")),
                BorderThickness = new Thickness(0, 0, 0, 1)
            };
            this.VerticalRuler = new Ruler()
            {
                Orientation = Orientation.Vertical,
                BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D4D4D4")),
                BorderThickness = new Thickness(0, 0, 1, 0)
            };
            if (this.SelectedItems is ISelectorVM)
                (this.SelectedItems as ISelectorVM).SelectorConstraints |= SelectorConstraints.Resizer;

            CommandManager = new Syncfusion.UI.Xaml.Diagram.CommandManager();
            CommandManager.Commands = new CommandCollection();
            PageSettings = new PageVM() ;
            (PageSettings as PageVM).InitDiagram(this);
        }

        private void OnQuickShapeExecute(object obj)
        {
            foreach (OrganizationChartNodeVM node in this.Nodes as ObservableCollection<OrganizationChartNodeVM>)
            {
                string template = null;
                if (obj.ToString().Contains("Belt"))
                {
                    template = "Belt";
                    node.UnitHeight = 120;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (i == 0)
                        {
                            LabelVM anno1 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno1.Offset = new Point(0.5, 0.8);
                            anno1.LabelWidth = 180;
                            anno1.TextHorizontalAlignment = TextAlignment.Center;
                        }
                        if (i == 1)
                        {
                            LabelVM anno2 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno2.Offset = new Point(0.5, 0.65);
                            anno2.HorizontalAlignment = HorizontalAlignment.Left;
                            anno2.VerticalAlignment = VerticalAlignment.Bottom;
                            anno2.LabelWidth = 85;
                            anno2.TextHorizontalAlignment = TextAlignment.Left;
                        }
                    }
                }
                else if (obj.ToString().Contains("Notch"))
                {
                    template = "Notch";
                    node.UnitHeight = 120;
                    for(int i = 0; i<=1; i++)
                    {
                        if(i == 0)
                        {
                            LabelVM anno1 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno1.Offset = new Point(0.65, 0.30);
                            anno1.TextHorizontalAlignment = TextAlignment.Left;
                            anno1.LabelWidth = 120;
                        }
                        if (i == 1)
                        {
                            LabelVM anno2 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno2.Offset = new Point(0.65, 0.40);
                            anno2.TextHorizontalAlignment = TextAlignment.Left;
                            anno2.HorizontalAlignment = HorizontalAlignment.Center;
                            anno2.VerticalAlignment = VerticalAlignment.Top;
                            anno2.LabelWidth = 120;
                        }
                    }
                }
                else if (obj.ToString().Contains("Pip"))
                {
                    template = "Pip";
                    node.UnitHeight = 140;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (i == 0)
                        {
                            LabelVM anno1 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno1.Offset = new Point(0.65, 0.35);
                            anno1.TextHorizontalAlignment = TextAlignment.Left;
                            anno1.LabelWidth = 120;
                        }
                        if (i == 1)
                        {
                            LabelVM anno2 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno2.Offset = new Point(0.65, 0.43);
                            anno2.TextHorizontalAlignment = TextAlignment.Left;
                            anno2.HorizontalAlignment = HorizontalAlignment.Center;
                            anno2.VerticalAlignment = VerticalAlignment.Top;
                            anno2.LabelWidth = 120;
                        }
                    }
                }
                else if (obj.ToString().Contains("Shapetacular"))
                {
                    template = "Shapetacular";
                    node.UnitHeight = 120;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (i == 0)
                        {
                            LabelVM anno1 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno1.Offset = new Point(0.65, 0.30);
                            anno1.TextHorizontalAlignment = TextAlignment.Right;
                            anno1.LabelWidth = 130;
                        }
                        if (i == 1)
                        {
                            LabelVM anno2 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno2.Offset = new Point(0.65, 0.40);
                            anno2.TextHorizontalAlignment = TextAlignment.Right;
                            anno2.HorizontalAlignment = HorizontalAlignment.Center;
                            anno2.VerticalAlignment = VerticalAlignment.Top;
                            anno2.LabelWidth = 130;
                        }
                    }
                }
                else if (obj.ToString().Contains("Bound"))
                {
                    template = "Bound";
                    node.UnitHeight = 120;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (i == 0)
                        {
                            LabelVM anno1 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno1.Offset = new Point(0.72, 0.30);
                            anno1.TextHorizontalAlignment = TextAlignment.Left;
                            anno1.LabelWidth = 100;
                        }
                        if (i == 1)
                        {
                            LabelVM anno2 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno2.Offset = new Point(0.72, 0.38);
                            anno2.TextHorizontalAlignment = TextAlignment.Left;
                            anno2.HorizontalAlignment = HorizontalAlignment.Center;
                            anno2.VerticalAlignment = VerticalAlignment.Top;
                            anno2.LabelWidth = 100;
                        }
                    }
                }
                else if (obj.ToString().Contains("Coin"))
                {
                    template = "Coin";
                    node.UnitHeight = 200;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (i == 0)
                        {
                            LabelVM anno1 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno1.Offset = new Point(0.5, 0.70);
                            anno1.TextHorizontalAlignment = TextAlignment.Center;
                            anno1.LabelWidth = 140;
                        }
                        if (i == 1)
                        {
                            LabelVM anno2 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno2.Offset = new Point(0.5, 0.78);
                            anno2.TextHorizontalAlignment = TextAlignment.Center;
                            anno2.HorizontalAlignment = HorizontalAlignment.Center;
                            anno2.VerticalAlignment = VerticalAlignment.Top;
                            anno2.LabelWidth = 125;
                        }
                    }
                }
                else if (obj.ToString().Contains("Panel"))
                {
                    template = "Panel";
                    node.UnitHeight = 220;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (i == 0)
                        {
                            LabelVM anno1 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno1.Offset = new Point(0.60, 0.62);
                            anno1.TextHorizontalAlignment = TextAlignment.Right;
                            anno1.LabelWidth = 130;
                        }
                        if (i == 1)
                        {
                            LabelVM anno2 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno2.Offset = new Point(0.60, 0.66);
                            anno2.TextHorizontalAlignment = TextAlignment.Right;
                            anno2.HorizontalAlignment = HorizontalAlignment.Center;
                            anno2.VerticalAlignment = VerticalAlignment.Top;
                            anno2.LabelWidth = 130;
                        }
                    }
                }
                else if (obj.ToString().Contains("Petals"))
                {
                    template = "Petals";
                    node.UnitHeight = 160;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (i == 0)
                        {
                            LabelVM anno1 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno1.Offset = new Point(0.50, 0.70);
                            anno1.TextHorizontalAlignment = TextAlignment.Left;
                            anno1.LabelWidth = 80;
                        }
                        if (i == 1)
                        {
                            LabelVM anno2 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno2.Offset = new Point(0.75, 0.12);
                            anno2.TextHorizontalAlignment = TextAlignment.Right;
                            anno2.HorizontalAlignment = HorizontalAlignment.Center;
                            anno2.VerticalAlignment = VerticalAlignment.Top;
                            anno2.LabelWidth = 80;
                        }
                    }
                }
                else if (obj.ToString().Contains("Stone"))
                {
                    template = "Stone";
                    node.UnitHeight = 140;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (i == 0)
                        {
                            LabelVM anno1 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno1.Offset = new Point(0.40, 0.35);
                            anno1.TextHorizontalAlignment = TextAlignment.Right;
                            anno1.LabelWidth = 100;
                        }
                        if (i == 1)
                        {
                            LabelVM anno2 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno2.Offset = new Point(0.40, 0.43);
                            anno2.TextHorizontalAlignment = TextAlignment.Right;
                            anno2.HorizontalAlignment = HorizontalAlignment.Center;
                            anno2.VerticalAlignment = VerticalAlignment.Top;
                            anno2.LabelWidth = 100;
                        }
                    }
                }
                else if (obj.ToString().Contains("Perspective"))
                {
                    template = "Perspective";
                    node.UnitHeight = 120;
                    for (int i = 0; i <= 1; i++)
                    {
                        if (i == 0)
                        {
                            LabelVM anno1 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno1.Offset = new Point(0.45, 0.25);
                            anno1.TextHorizontalAlignment = TextAlignment.Left;
                            anno1.LabelWidth = 80;
                        }
                        if (i == 1)
                        {
                            LabelVM anno2 = (node.Annotations as List<IAnnotation>)[i] as LabelVM;
                            anno2.Offset = new Point(0.45, 0.33);
                            anno2.TextHorizontalAlignment = TextAlignment.Left;
                            anno2.HorizontalAlignment = HorizontalAlignment.Center;
                            anno2.VerticalAlignment = VerticalAlignment.Top;
                            anno2.LabelWidth = 80;
                        }
                    }
                }
                if (template != null)
                {
                    ResourceDictionary resourceDictionary = new ResourceDictionary()
                    {
                        Source = new Uri(@"/syncfusion.diagrambuilder.Wpf;component/OrganizationChart/Theme/OrganizationChartUI.xaml", UriKind.RelativeOrAbsolute)
                    };

                    node.ContentTemplate = resourceDictionary[template.ToString()] as DataTemplate;
                    node.CustomContentTemplate = template.ToString();
                }
            }
            this.LayoutManager.Layout.UpdateLayout();
        }

        private void ShowhidePictureExecute(object obj)
        {
            IEnumerable<object> nodes = (this.SelectedItems as SelectorVM).Nodes as IEnumerable<object>;
            if(nodes != null && nodes.Count() > 0)
            {
                foreach(OrganizationChartNodeVM node in nodes as IEnumerable<object>)
                {
                    if (node.CustomContent != null)
                    {
                        var nodecontent = node.CustomContent as CustomContent;

                        if (nodecontent.ImageVisibility == 0)
                        {
                            nodecontent.ImageVisibility = 100;
                        }
                        else
                        {
                            nodecontent.ImageVisibility = 0;
                        }
                    }
                }
            }            
        }

        private void DeletePictureExecute(object obj)
        {
            IEnumerable<object> nodes = (this.SelectedItems as SelectorVM).Nodes as IEnumerable<object>;
            if (nodes != null && nodes.Count() > 0)
            {
                foreach (OrganizationChartNodeVM node in nodes as IEnumerable<object>)
                {
                    if (node.CustomContent != null)
                    {
                        (node.CustomContent as CustomContent).Image = null;
                    }
                }
            }
        }

        private void InsertPictureExecute(object obj)
        {
            OrganizationChartNodeVM node = ((this.SelectedItems as SelectorVM).Nodes as IEnumerable<object>).FirstOrDefault() as OrganizationChartNodeVM;
            if(node != null)
            {
                OpenFileDialog openDialogBox = new OpenFileDialog();
                openDialogBox.Title = "File Open";
                if (openDialogBox.ShowDialog() == true)
                {
                    (node.CustomContent as CustomContent).Image = openDialogBox.FileName.ToString();                    
                }
            }
        }

        private void ExpandCollapseExecute(object obj)
        {
            OrganizationChartNodeVM node = ((this.SelectedItems as SelectorVM).Nodes as IEnumerable<object>).FirstOrDefault() as OrganizationChartNodeVM;            
            if(node != null && (node.Info as INodeInfo) != null && (node.Info as INodeInfo).OutConnectors != null 
                && (node.Info as INodeInfo).OutConnectors.Count() > 0)
            {
                ExpandCollapseParameter parameter = new ExpandCollapseParameter()
                {
                    Node = node,
                };
                (this.Info as IGraphInfo).Commands.ExpandCollapse.Execute(parameter);
            }
            
        }

        private void DecreaseSpacingExecute(object obj)
        {
            if (obj.Equals("HorizontalDecreaseSpace") && (this.LayoutManager.Layout as DirectedTreeLayout).HorizontalSpacing > 50)
            {
                (this.LayoutManager.Layout as DirectedTreeLayout).HorizontalSpacing -= 5;
            }
            else if (obj.Equals("VerticalDecreaseSpace") && (this.LayoutManager.Layout as DirectedTreeLayout).VerticalSpacing > 50)
            {
                (this.LayoutManager.Layout as DirectedTreeLayout).VerticalSpacing -= 5;
            }

            this.LayoutManager.Layout.UpdateLayout();
        }

        private void IncreaseSpacingExecute(object obj)
        {
            if(obj.Equals("HorizontalIncreaseSpace"))
            {
                (this.LayoutManager.Layout as DirectedTreeLayout).HorizontalSpacing += 5;
            }
            else if(obj.Equals("VerticalIncreaseSpace"))
            {
                (this.LayoutManager.Layout as DirectedTreeLayout).VerticalSpacing += 5;
            }

            this.LayoutManager.Layout.UpdateLayout();
        }

        private void OnGetLayoutInfoChanged(object obj)
        {
            var args = obj as LayoutInfoArgs;
            if (LayoutManager.Layout is DirectedTreeLayout)
            {
                if ((LayoutManager.Layout as DirectedTreeLayout).Type == LayoutType.Organization)
                {
                    switch (compact)
                    {
                        case "left":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Left;
                                args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "right":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Right;
                                args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "centre":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Center;
                                args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "horizontal_center":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Center;
                                args.Orientation = Orientation.Horizontal;
                            }
                            break;
                        case "horizontal_right":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Right;
                                args.Orientation = Orientation.Horizontal;
                            }
                            break;
                        case "horizontal_left":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Left;
                                args.Orientation = Orientation.Horizontal;
                            }
                            break;
                        case "alternate":
                            if (!args.HasSubTree)
                            {
                                args.Type = ChartType.Alternate;
                                args.Orientation = Orientation.Vertical;
                            }
                            break;
                        case "horizontal_alternate":
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

        private void ItemSelectedCommandExecute(object param)
        {
            DiagramEventArgs args = param as DiagramEventArgs;
            if (args.Item is OrganizationChartNodeVM)
            {
                OrganizationChartNodeVM node = args.Item as OrganizationChartNodeVM;
                UpdateQuickCommandsVisibility();
            }

            if(args.Item is OrganizationChartNodeVM && (args.Item as OrganizationChartNodeVM).Type == "root")
            {
                this.Quickcommands_Delete.VisibilityMode = VisibilityMode.Connector;
            }
        }

        private void UpdateQuickCommandsVisibility()
        {
            if (Quickcommands_Add != null)
            {
                Quickcommands_Add.VisibilityMode = VisibilityMode.Node;
            }

            if (Quickcommands_Delete != null)
            {
                Quickcommands_Delete.VisibilityMode = VisibilityMode.Node;
            }
        }

        private void AddChildCommandExecute(object param)
        {
            var selectednode = ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>)[0] as OrganizationChartNodeVM;

            OrganizationChartNodeVM node = new OrganizationChartNodeVM()
            {
                ContentTemplate = selectednode.ContentTemplate as DataTemplate,
                CustomContent = new CustomContent() { Image = "/syncfusion.diagrambuilder.wpf;component/Resources/male.png", ImageVisibility = 100 },
                ID = id.ToString(),
                ParentID = selectednode.ID.ToString(),
                UnitWidth = 200,
                UnitHeight = 120,
                Annotations = new List<IAnnotation>()
                {
                    new LabelVM()
                    {
                        Content = "Name",
                        FontSize = 12,
                        WrapText = TextWrapping.Wrap,
                        TextHorizontalAlignment = ((selectednode.Annotations as List<IAnnotation>)[0] as LabelVM).TextHorizontalAlignment,
                        TextVerticalAlignment = ((selectednode.Annotations as List<IAnnotation>)[0] as LabelVM).TextVerticalAlignment,
                        Offset = ((selectednode.Annotations as List<IAnnotation>)[0] as LabelVM).Offset,
                        LabelWidth = ((selectednode.Annotations as List<IAnnotation>)[0] as LabelVM).LabelWidth,
                    },
                    new LabelVM()
                    {
                        FontSize = 12,
                        WrapText = TextWrapping.Wrap,
                        TextHorizontalAlignment = ((selectednode.Annotations as List<IAnnotation>)[1] as LabelVM).TextHorizontalAlignment,
                        TextVerticalAlignment = ((selectednode.Annotations as List<IAnnotation>)[1] as LabelVM).TextVerticalAlignment,
                        HorizontalAlignment = ((selectednode.Annotations as List<IAnnotation>)[1] as LabelVM).HorizontalAlignment,
                        VerticalAlignment = ((selectednode.Annotations as List<IAnnotation>)[1] as LabelVM).VerticalAlignment,
                        Offset = ((selectednode.Annotations as List<IAnnotation>)[1] as LabelVM).Offset,
                        LabelWidth = ((selectednode.Annotations as List<IAnnotation>)[1] as LabelVM).LabelWidth,
                    },
                }
            };
            foreach (string labels in RoleAnnotation as List<string>)
            {
                LabelVM anno = (node.Annotations as List<IAnnotation>)[1] as LabelVM;
                if (anno.Content != null)
                {
                    anno.Content = anno.Content.ToString() + "\n" + labels;
                }
                else
                {
                    anno.Content = labels;
                }
            }
            id++;            
            (OrgNodeCollection as NodeVMCollection).Add(node);
            ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Clear();
            node.IsSelected = true;
            this.LayoutManager.Layout.UpdateLayout();
        }

        private void EditCommandExecute(object param)
        {
            List<string> contents = new List<string>();
            OrganizationChartNodeVM firstnode = (NodeCollection as ObservableCollection<OrganizationChartNodeVM>).First();

            LabelVM firstlabel = (firstnode.Annotations as List<IAnnotation>)[0] as LabelVM;

            foreach(string labels in RoleAnnotation as List<string>)
            {
                contents.Add(labels);
            }

            AdditionalInformationWindow window = new AdditionalInformationWindow();
            window.Annotations = contents;
            window.Annotation = firstlabel.Content.ToString();
            window.ShowDialog();            
            List<String> Annotations = window.Annotations;
            string Annotation = window.Annotation;
            foreach (OrganizationChartNodeVM node in NodeCollection as ObservableCollection<OrganizationChartNodeVM>)
            {
                LabelVM label = (node.Annotations as List<IAnnotation>).ElementAt(0) as LabelVM;
                label.Content = Annotation.ToString();
            }
            
            if(Annotations.Count > 0)
            {
                RoleAnnotation = Annotations;
                foreach (OrganizationChartNodeVM node in NodeCollection as ObservableCollection<OrganizationChartNodeVM>)
                {
                    LabelVM label = (node.Annotations as List<IAnnotation>).ElementAt(1) as LabelVM;
                    label.Content = null;
                    foreach(string labels in Annotations as List<string>)
                    {
                        if (label.Content != null)
                        {
                            label.Content = label.Content.ToString() + "\n" + labels;
                        }
                        else
                        {
                            label.Content = labels;
                        }
                    }
                }
            }
            else
            {
                foreach (OrganizationChartNodeVM node in NodeCollection as ObservableCollection<OrganizationChartNodeVM>)
                {
                    LabelVM label = (node.Annotations as List<IAnnotation>).ElementAt(1) as LabelVM;
                    label.Content = null;
                    label.ReadOnly = false;
                }
            }
            
            this.LayoutManager.Layout.UpdateLayout();
        }


        private void UpdateLayoutCommandExecute(object obj)
        {
            this.LayoutManager.Layout.UpdateLayout();
        }

        private void DeleteCommandExecute(object param)
        {
            for (int i = 0; i < ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>).Count();)
            {
                OrganizationChartNodeVM selectedNode = ((this.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>)[i] as OrganizationChartNodeVM;
                if (selectedNode.Type != "root")
                {
                    DeleteNode(selectedNode);                    
                }
            }
            this.LayoutManager.Layout.UpdateLayout();

        }

        private void DeleteNode(OrganizationChartNodeVM SelectedNode)
        {
            if ((SelectedNode.Info as INodeInfo).OutNeighbors != null && (SelectedNode.Info as INodeInfo).OutNeighbors.Count() > 0)
            {
                for (int i = (SelectedNode.Info as INodeInfo).OutNeighbors.Count() - 1; (SelectedNode.Info as INodeInfo).OutNeighbors.Count() - 1 >= i && i >= 0; i--)
                {
                    OrganizationChartNodeVM c = (SelectedNode.Info as INodeInfo).OutNeighbors.ElementAt(i) as OrganizationChartNodeVM;
                    DeleteNode(c);
                }
            }
            if ((SelectedNode.Info as INodeInfo).InOutConnectors != null && (SelectedNode.Info as INodeInfo).OutNeighbors.Count() > 0)
            {
                for (int i = (SelectedNode.Info as INodeInfo).InOutConnectors.Count() - 1; (SelectedNode.Info as INodeInfo).InOutConnectors.Count() - 1 >= i && i >= 0; i--)
                {
                    OrganizationChartNodeVM con = (SelectedNode.Info as INodeInfo).InOutConnectors.ElementAt(i) as OrganizationChartNodeVM;
                    (this.Connectors as ObservableCollection<OrganizationChartNodeVM>).Remove(con);
                }
            }
           (OrgNodeCollection as NodeVMCollection).Remove(SelectedNode);

        }

        private OrganizationChartNodeVM AddRootNode()
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(@"/syncfusion.diagrambuilder.Wpf;component/OrganizationChart/Theme/OrganizationChartUI.xaml", UriKind.RelativeOrAbsolute)
            };

            OrganizationChartNodeVM n = new OrganizationChartNodeVM();            
            n.ContentTemplate = resourceDictionary["Belt"] as DataTemplate;
            n.CustomContentTemplate = "Belt";
            n.CustomContent = new CustomContent()
            {
                Image = "/syncfusion.diagrambuilder.wpf;component/Resources/male.png",
            };
            n.ID = id.ToString();
            n.ParentID = "";
            n.UnitWidth = 200;
            n.UnitHeight = 120;
            n.Type = "root";
            id++;
            n.Annotations = new List<IAnnotation>()
            {
                new LabelVM()
                {
                    Content = "Name",
                    FontSize = 12,
                    WrapText = TextWrapping.Wrap,
                    TextHorizontalAlignment = TextAlignment.Center,
                    TextVerticalAlignment = VerticalAlignment.Center,
                    Offset = new Point(0.5,0.8),
                    LabelWidth = 180,
                    
                },
                new LabelVM()
                {
                    Content = "Role",
                    FontSize = 12,
                    WrapText = TextWrapping.Wrap,
                    TextHorizontalAlignment = TextAlignment.Left,
                    TextVerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Offset = new Point(0.5,0.65),
                    LabelWidth = 85,
                },
            };
                
            (OrgNodeCollection as NodeVMCollection).Add(n);
            return n;            
        }
    }

    public class NodeVMCollection : ObservableCollection<OrganizationChartNodeVM>
    {

    }
    public class ConnectorVMCollection : ObservableCollection<OrganizationChartConnectorVM>
    {

    }
}
