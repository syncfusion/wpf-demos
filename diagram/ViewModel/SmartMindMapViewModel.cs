#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.diagramdemo.wpf.Model;
using syncfusion.diagramdemo.wpf.Views;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using syncfusion.demoscommon.wpf;
using System.Windows.Media;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using Syncfusion.Pdf;
using Syncfusion.XPS;
using System.IO;
using Microsoft.Win32;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class SmartMindMapViewModel : DiagramViewModel
    {
        #region fields, properties and command

        System.Windows.ResourceDictionary resourceDictionary = new System.Windows.ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };

        private ICommand _NewCommand;
        private ICommand _SaveCommand;
        private ICommand _LoadCommand;
        private ICommand _PanCommand;
        private bool _PanEnabled = true;
        private ICommand _SelectCommand;
        private bool _SelectEnabled = false;
        private ICommand _ZoomInCommand;
        private ICommand _ZoomOutCommand;
        private ICommand _ExportCommand;

        public ICommand _AddLeftCommand;

        public ICommand AddLeftCommand
        {
            get { return _AddLeftCommand; }
            set { _AddLeftCommand = value; }
        }

        public bool PanEnabled
        {
            get
            {
                return _PanEnabled;
            }
            set
            {
                if (value != _PanEnabled)
                {
                    _PanEnabled = value;
                    OnPropertyChanged("PanEnabled");
                }
            }
        }

        public bool SelectEnabled
        {
            get
            {
                return _SelectEnabled;
            }
            set
            {
                if (value != _SelectEnabled)
                {
                    _SelectEnabled = value;
                    OnPropertyChanged("SelectEnabled");
                }
            }
        }

        public ICommand ZoomInCommand
        {
            get { return _ZoomInCommand; }
            set { _ZoomInCommand = value; }
        }

        public ICommand ZoomOutCommand
        {
            get { return _ZoomOutCommand; }
            set { _ZoomOutCommand = value; }
        }

        public ICommand PanCommand
        {
            get { return _PanCommand; }
            set { _PanCommand = value; }
        }
        public ICommand SelectCommand
        {
            get { return _SelectCommand; }
            set { _SelectCommand = value; }
        }

        public ICommand NewCommand
        {
            get { return _NewCommand; }
            set { _NewCommand = value; }
        }

        public ICommand LoadCommand
        {
            get { return _LoadCommand; }
            set { _LoadCommand = value; }
        }

        public ICommand SaveCommand
        {
            get { return _SaveCommand; }
            set { _SaveCommand = value; }
        }

        public ICommand ExportCommand
        {
            get { return _ExportCommand; }
            set { _ExportCommand = value; }
        }

        #endregion

        #region constructor

        public SmartMindMapViewModel()
        {
            this.Tool = Tool.SingleSelect;
            this.Nodes = new NodeCollection();
            this.Connectors = new ObservableCollection<CustomSmartMindMapConnector>();
            this.DefaultConnectorType = ConnectorType.CubicBezier;
            this.DataSourceSettings = new DataSourceSettings()
            {
                DataSource = this.GetEmployeeCollection(),
                ParentId = "ParentId",
                Id = "EmpId"
            };
            this.LayoutManager = new LayoutManager()
            {
                Layout = new SfSmartMindMapTreeLayout()
                {
                    HorizontalSpacing = 50,
                    VerticalSpacing = 50,
                    Orientation = Orientation.Horizontal,
                    SplitMode = MindMapTreeMode.RootChildrenCount,
                },
                RefreshFrequency = RefreshFrequency.ArrangeParsing
            };

            SelectedItems = new SelectorViewModel()
            {
                Commands = null,
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.Rotator & ~SelectorConstraints.Resizer & ~SelectorConstraints.Pivot,
            };

            ItemAddedCommand = new DelegateCommand(OnItemAdded);
            ItemSelectedCommand = new DelegateCommand(OnItemSelected);
            ItemDeletingCommand = new DelegateCommand(OnItemDeleting);
            NodeChangedCommand = new DelegateCommand(OnNodeChanged);
            AddLeftCommand = new DelegateCommand(OnAddLeftChild);

            NewCommand = new DelegateCommand(OnNew);
            LoadCommand = new DelegateCommand(OnLoad);
            SaveCommand = new DelegateCommand(OnSave);
            ZoomInCommand = new DelegateCommand(ZoomInExecution);
            ZoomOutCommand = new DelegateCommand(ZoomOutExecution);
            PanCommand = new DelegateCommand(PanExecution);
            SelectCommand = new DelegateCommand(SelectExecution);
            ExportCommand = new DelegateCommand(ExportExecution);
            this.PanEnabled = false;
            this.SelectEnabled = true;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// This method is used to execute Select command
        /// </summary>
        /// <param name="obj"></param>
        private void SelectExecution(object obj)
        {
            this.Tool = Tool.MultipleSelect;
            this.SelectEnabled = true;
            this.PanEnabled = false;
        }

        /// <summary>
        /// This method is used to execute Pan command
        /// </summary>
        /// <param name="obj"></param>
        private void PanExecution(object obj)
        {
            this.Tool = Tool.ZoomPan;
            this.PanEnabled = true;
            this.SelectEnabled = false;
        }

        /// <summary>
        /// This method is used to execute Save command
        /// </summary>
        /// <param name="obj"></param>
        private void OnSave(object obj)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save XML";
            dialog.Filter = "XML File (*.xml)|*.xml";
            if (dialog.ShowDialog() == true)
            {
                using (Stream s = File.Open(dialog.FileName, FileMode.OpenOrCreate))
                {
                    s.SetLength(0);
                    (Info as IGraphInfo).Save(s);
                }
            }
        }

        /// <summary>
        /// This method is used to execute load command
        /// </summary>
        /// <param name="obj"></param>
        private void OnLoad(object obj)
        {
            if (this.HasChanges)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(
                            "Do you want to save the Diagram?",
                            "SfDiagram",
                            MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    this.OnSave(null);
                }
            }

            Nodes = new NodeCollection();
            Connectors = new ConnectorCollection();
            DataSourceSettings = null;

            HasChanges = false;

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                using (Stream myStream = dialog.OpenFile())
                {
                    (Info as IGraphInfo).Load(myStream);
                }

                if (Nodes != null && Nodes is NodeCollection && (Nodes as NodeCollection).Any())
                {
                    (this.LayoutManager.Layout as MindMapTreeLayout).LayoutRoot = (Nodes as NodeCollection).First() as NodeViewModel;
                }
            }

            this.LayoutManager.Layout.InvalidateLayout();

            Tool = Tool.MultipleSelect;
            PanEnabled = false;
            SelectEnabled = true;
        }

        /// <summary>
        /// This method is used to execute new command
        /// </summary>
        /// <param name="obj"></param>
        private void OnNew(object obj)
        {
            if (this.HasChanges)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(
                            "Do you want to save the Diagram?",
                            "SfDiagram",
                            MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    this.OnSave(null);
                }
            }

            Nodes = new NodeCollection();
            Connectors = new ConnectorCollection();
            HasChanges = false;
        }

        /// <summary>
        /// This method is used to execute ZoomOut command
        /// </summary>
        /// <param name="obj"></param>
        private void ZoomOutExecution(object obj)
        {
            (Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter() { ZoomCommand = ZoomCommand.ZoomOut, ZoomFactor = 0.2 });
        }

        /// <summary>
        /// This method is used to execute ZoomIn command
        /// </summary>
        /// <param name="obj"></param>
        private void ZoomInExecution(object obj)
        {
            (Info as IGraphInfo).Commands.Zoom.Execute(new ZoomPositionParameter() { ZoomCommand = ZoomCommand.ZoomIn, ZoomFactor = 0.2 });
        }

        /// <summary>
        /// This method is used to execute Export command
        /// </summary>
        /// <param name="obj"></param>
        private void ExportExecution(object obj)
        {
            String Extension = "JPG File(*.jpg)|*.jpg|PNG File(*.png)|*.png|BMP File (*.bmp)|*.bmp|WDP File (*.wdp)|*.wdp|TIF File(*.tif)|*.tif|GIF File(*.gif)|*.gif|XPS File(*.xps)|*.xps|PDF File(*.pdf)|*.pdf";
            //("WDP File(*.wdp)|*.wdp") + ("BMP File(*.bmp)|*.bmp");

            //To Represent SaveFile Dialog Box
            SaveFileDialog m_SaveFileDialog = new SaveFileDialog();

            //Assign the selected extension to the SavefileDialog filter
            m_SaveFileDialog.Filter = Extension;

            //To display savefiledialog       
            bool? istrue = m_SaveFileDialog.ShowDialog();
            string filenamechanged;

            if (istrue == true)
            {
                //assign the filename to a local variable
                string extension = System.IO.Path.GetExtension(m_SaveFileDialog.FileName).TrimStart('.');
                string fileName = System.IO.Path.ChangeExtension(m_SaveFileDialog.FileName, null);
                this.ExportSettings = new ExportSettings() { ExportMode = ExportMode.Content };
                if (extension != "")
                {
                    if (extension.ToLower() != this.ExportSettings.ExportType.ToString().ToLower())
                    {
                        switch (extension.ToLower())
                        {
                            case "png":
                                this.ExportSettings.ExportType = ExportType.PNG;
                                break;
                            case "jpg":
                                this.ExportSettings.ExportType = ExportType.JPEG;
                                break;
                            case "bmp":
                                this.ExportSettings.ExportType = ExportType.BMP;
                                break;
                            case "wdp":
                                this.ExportSettings.ExportType = ExportType.WDP;
                                break;
                            case "gif":
                                this.ExportSettings.ExportType = ExportType.GIF;
                                break;
                            case "tif":
                                this.ExportSettings.ExportType = ExportType.TIF;
                                break;
                        }
                    }

                    if (extension.ToLower() == "pdf")
                    {
                        filenamechanged = fileName + ".xps";

                        ExportSettings.IsSaveToXps = true;

                        //Assigning exportstream from the saved file
                        this.ExportSettings.FileName = filenamechanged;
                        // Method to Export the SfDiagram
                        (this.Info as IGraphInfo).Export();

                        var converter = new XPSToPdfConverter { };

                        var document = new PdfDocument();

                        document = converter.Convert(filenamechanged);
                        fileName = fileName + ".pdf";
                        document.Save(fileName);
                        document.Close(true);
                    }
                    else
                    {
                        if (extension.ToLower() == "xps")
                        {
                            ExportSettings.IsSaveToXps = true;
                        }

                        //Assigning exportstream from the saved file
                        this.ExportSettings.FileName = fileName;
                        // Method to Export the SfDiagram
                        (this.Info as IGraphInfo).Export();
                    }
                }
            }
        }
        private void OnNodeChanged(object obj)
        {
            var args = obj as ChangeEventArgs<object, NodeChangedEventArgs>;
            if (args.NewValue.InteractionState == NodeChangedInteractionState.Dragged)
            {
                this.LayoutManager.Layout.InvalidateLayout();
            }

        }

        private void OnItemDeleting(object obj)
        {
            var args = obj as ItemDeletingEventArgs;
            var item = args.Item as NodeViewModel;
            if (item != null)
            {

                args.DeleteDependentConnector = true;
                args.DeleteSuccessors = true;
                this.LayoutManager.Layout.InvalidateLayout();
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

        private void OnAddLeftChild(object obj)
        {
            if (this.SelectedItems is SelectorViewModel sv)
            {
                if (sv.Nodes is ObservableCollection<object> nodes && nodes.Any() && (nodes.First() as NodeViewModel).Content != null && (nodes.First() as NodeViewModel).Content is MindmapEmployee)
                {
                    var employee = new MindmapEmployee()
                    {
                        EmpId = Guid.NewGuid().ToString(),
                        Name = "New Child",
                        ParentId = ((nodes.First() as NodeViewModel).Content as MindmapEmployee).EmpId,
                        Direction = RootChildDirection.Left
                    };
                    var layout = this.LayoutManager.Layout as SfSmartMindMapTreeLayout;
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
                    this.LayoutManager.Layout.UpdateLayout();
                    ((layout.LayoutRoot as INode).Info as INodeInfo).BringIntoCenter();
                }
                else
                {
                    NodeViewModel selectedNode = (sv.Nodes as ObservableCollection<object>).First() as NodeViewModel;

                    NodeViewModel newNode = new NodeViewModel()
                    {
                        UnitHeight = 50,
                        UnitWidth = 150,
                        Shape = new EllipseGeometry(new Rect(0, 0, 120, 60)),
                        Annotations = new ObservableCollection<IAnnotation>()
                        {
                            new AnnotationEditorViewModel()
                            {
                                Content = "New Child",
                            }
                        },
                    };

                    ConnectorViewModel con = new ConnectorViewModel()
                    {
                        SourceNode = selectedNode,
                        TargetNode = newNode,
                    };

                    (this.Nodes as NodeCollection).Add(newNode);
                    (this.Connectors as ConnectorCollection).Add(con);

                    SetNodeColors((this.LayoutManager.Layout as MindMapTreeLayout).LayoutRoot as NodeViewModel);

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
                    (this.SelectedItems as SelectorViewModel).Commands = new QuickCommandCollection()
                    {
                        new QuickCommandViewModel()
                        {
                            Shape = resourceDictionary["Ellipse"],
                            OffsetX = 0.5,
                            OffsetY = 0.5,
                            Command = AddLeftCommand,
                            Content = "M4.0000001,0 L6,0 6,4.0000033 10,4.0000033 10,6.0000033 6,6.0000033 6,10 4.0000001,10 4.0000001,6.0000033 0,6.0000033 0,4.0000033 4.0000001,4.0000033 z",
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Thickness(0,37,0,0),
                        },
                    };
                }
            }
        }

        private void OnItemAdded(object obj)
        {
            var args = obj as ItemAddedEventArgs;

            if(args.Item is ConnectorViewModel)
            {
                ConnectorViewModel connector = args.Item as ConnectorViewModel;
                connector.Constraints = ConnectorConstraints.Default & ~ConnectorConstraints.Selectable;
                connector.Annotations = null;
            }

            if (args.Item != null && args.Item is NodeViewModel && args.ItemSource == ItemSource.ClipBoard)
            {
                (args.Item as NodeViewModel).IsSelected = true;
                (this.Info as IGraphInfo).Commands.Delete.Execute(null);
            }
            if (args.Item != null && args.Item is NodeViewModel && args.ItemSource != ItemSource.ClipBoard)
            {
                (args.Item as NodeViewModel).Shape = new EllipseGeometry(new Rect(0, 0, 120, 60));

                Style shapeStyle = new Style(typeof(System.Windows.Shapes.Path));
                shapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StretchProperty, Stretch.Fill));

                string colorString = string.Empty;

                if ((args.Item as NodeViewModel).Content is MindmapEmployee)
                {
                    colorString = ((args.Item as NodeViewModel).Content as MindmapEmployee).Color.ToString();

                    (args.Item as NodeViewModel).Annotations = new ObservableCollection<IAnnotation>()
                    {
                        new AnnotationEditorViewModel()
                        {
                            Content = ((args.Item as NodeViewModel).Content as MindmapEmployee).Name
                        }
                    };
                }

                if (!string.IsNullOrEmpty(colorString))
                {
                    Color color = (Color)ColorConverter.ConvertFromString(colorString);
                    System.Windows.Media.SolidColorBrush brush = new System.Windows.Media.SolidColorBrush(color);
                    shapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, brush));
                    (args.Item as NodeViewModel).ShapeStyle = shapeStyle;
                }
            }
        }

        public void SetNodeColors(NodeViewModel rootNode)
        {
            if (rootNode == null) return;

            (LayoutManager.Layout as MindMapTreeLayout).LayoutRoot = rootNode;
            Style shapeStyle = new Style(typeof(System.Windows.Shapes.Path));
            shapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StretchProperty, Stretch.Fill));
            shapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, new System.Windows.Media.SolidColorBrush(Color.FromRgb(42, 87, 141)))); // Deep Teal (#2A578D) - Root Node
            rootNode.ShapeStyle = shapeStyle;

            SetChildColors(rootNode, 0);
        }

        public void SetChildColors(NodeViewModel node, int level)
        {
            System.Windows.Media.Brush[] levelColors = new System.Windows.Media.Brush[]
            {
                new System.Windows.Media.SolidColorBrush(Color.FromRgb(30, 164, 154)),   // Turquoise (#1EA49A)
                new System.Windows.Media.SolidColorBrush(Color.FromRgb(255, 87, 34)),    // Coral Orange (#FF5722)
                new System.Windows.Media.SolidColorBrush(Color.FromRgb(244, 143, 20)),   // Vibrant Yellow (#F48B14)
                new System.Windows.Media.SolidColorBrush(Color.FromRgb(76, 175, 80)),    // Fresh Green (#4CAF50)
            };



            List<NodeViewModel> targetNodes = null;

            if (node is NodeViewModel)
            {
                targetNodes = (node.Info as INodeInfo)?.OutConnectors
                    .OfType<ConnectorViewModel>()
                    .Select(connector => connector.TargetNode as NodeViewModel)
                    .Where(targetNode => targetNode != null)
                    .ToList();
            }

            if (targetNodes != null)
            {
                foreach (NodeViewModel child in targetNodes as List<NodeViewModel>)
                {

                    Style shapeStyle = new Style(typeof(System.Windows.Shapes.Path));

                    shapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.StretchProperty, Stretch.Fill));
                    shapeStyle.Setters.Add(new Setter(System.Windows.Shapes.Path.FillProperty, levelColors[level % levelColors.Length]));
                    child.ShapeStyle = shapeStyle;

                    SetChildColors(child, level + 1);
                }
            }
        }

        #endregion
    }

    public class CustomSmartMindMapConnector : ConnectorViewModel
    {
        public CustomSmartMindMapConnector()
        {
            Constraints = ConnectorConstraints.Default & ~ConnectorConstraints.Selectable;
            Annotations = null;
        }
    }

    public class SfSmartMindMapTreeLayout : MindMapTreeLayout
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
}
