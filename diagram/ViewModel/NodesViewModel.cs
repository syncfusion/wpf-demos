#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class NodesViewModel : DiagramViewModel
    {
        #region Fields

        private bool first = true;

        //To hold the selected theme value
        private string selectedTheme = "None";

        //To hold the selected shape names
        public string ShapeName = "Rectangle";

        //To hold the selected button value
        public Button prevbutton = null;

        //Command to change the aspect ration property value.
        public ICommand AspectRatioCommand { get; set; }

        //Command to change the selected shape button
        public ICommand SelectShapeCommand { get; set; }

        //Command to change the nodes constraint.
        public ICommand LockCommand { get; set; }

        //To hold the list of themes
        private List<string> themes = new List<string> {"None", "OfficeTheme", "LinearTheme", "ZephyrTheme", "IntegralTheme", "SimpleTheme",
                                                        "WhispTheme", "DaybreakTheme", "ParallelTheme", "SequenceTheme", "SliceTheme",
                                                        "IonTheme", "RetrospectTheme", "BubbleTheme", "CloudsTheme", "GemstoneTheme",
                                                        "FacetTheme", "ProminenceTheme", "SmokeTheme", "RadianceTheme"};

        /// <summary>
        /// Gets the list of themes of the diagram.
        /// </summary>
        public List<string> Themes
        {
            get
            {
                return themes;
            }
        }

        /// <summary>
        /// Gets or sets the theme to the diagram.
        /// </summary>
        public string SelectedTheme
        {
            get
            {
                return selectedTheme;
            }
            set
            {
                if (selectedTheme != value)
                {
                    selectedTheme = value;
                    OnPropertyChanged("SelectedTheme");
                    ThemeValueChanged(selectedTheme);
                }
            }
        }

        #endregion

        public DemoControl View;

        #region Constructor
        public NodesViewModel()
        {
            //Initialize the nodes and connectors collection
            this.Nodes = new ObservableCollection<CustomNodeViewModel>();
            this.Connectors = new ObservableCollection<CustomConnectorViewModel>();

            //Intialize the default connector type
            this.DefaultConnectorType = ConnectorType.Line;

            //Initialize the command to change the aspect ration to the nodes.
            AspectRatioCommand = new DelegateCommand(OnAspectRatioCommandExecute);

            //Initialize the command to change the node constraints.
            LockCommand = new DelegateCommand(OnLockCommandExecute);

            //Initialize the command to change the nodes appearance.
            SelectShapeCommand = new DelegateCommand(OnSelectShapeCommandExecute);

            //Initialize the command to bring the elements to the center of the page.
            ViewPortChangedCommand = new DelegateCommand(OnViewPortChangedCommandExecute);

            //Initialize the selector view model and disbale the quick coammnds.
            this.SelectedItems = new SelectorViewModel();
            (this.SelectedItems as SelectorViewModel).SelectorConstraints &= ~(SelectorConstraints.QuickCommands);

            //Create and add nodes
            CreateNodes("sdlc", 450, 320, "SDLC");
            CreateNodes("support", 351, 452, "Support");
            CreateNodes("anaysis", 272, 250, "Analysis");
            CreateNodes("design", 450, 150, "Design");
            CreateNodes("implement", 634, 252, "Implement");
            CreateNodes("depoly", 564, 452, "Depoly");

            //Create connectors
            CreateConnectors("support", "anaysis");
            CreateConnectors("anaysis", "design");
            CreateConnectors("design", "implement");
            CreateConnectors("implement", "depoly");
            CreateConnectors("depoly", "support");
        }
        #endregion

        #region Helper methods

        /// <summary>
        /// Command to bring the diagram elemnts to center of the view port
        /// </summary>
        /// <param name="parameter">ViewPortChangedEventArgs</param>
        private void OnViewPortChangedCommandExecute(object parameter)
        {
            var args = parameter as ChangeEventArgs<object, ScrollChanged>;
            if (Info != null && (args.Item as SfDiagram).IsLoaded == true && first && args.NewValue.ContentBounds != args.OldValue.ContentBounds)
            {
                (Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
                first = false;
            }
        }

        /// <summary>
        /// To change the nodes appearance as selected buttons.
        /// </summary>
        /// <param name="parameter"></param>
        private void OnSelectShapeCommandExecute(object parameter)
        {
            Button button = parameter as Button;
            this.ShapeName = button.Name.ToString();

            if (prevbutton != null)
            {
                prevbutton.Style = View.Resources["NodesButtonStyle"] as Style;
            }

            button.Style = View.Resources["NodesSelectedButtonStyle"] as Style;
            foreach (CustomNodeViewModel node in this.Nodes as IEnumerable<object>)
            {
                foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                {
                    (annotation as TextAnnotationViewModel).FontSize = 15;
                    (annotation as TextAnnotationViewModel).Foreground = new SolidColorBrush(Colors.White);
                }
            }

            foreach (CustomConnectorViewModel connector in this.Connectors as IEnumerable<object>)
            {
                connector.Fill = new SolidColorBrush(Colors.Black);
            }

            if (ShapeName.Equals("fill"))
            {
                foreach (INode node in this.Nodes as ObservableCollection<CustomNodeViewModel>)
                {
                    node.ContentTemplate = null;
                    (node as CustomNodeViewModel).Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#37909A"));
                    (node as CustomNodeViewModel).StrokeColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#37909A"));
                    (node as CustomNodeViewModel).StrokeThickess = 1;
                    (node as CustomNodeViewModel).StrokeDash = double.MaxValue;
                }
            }
            else if (ShapeName.Equals("stroke"))
            {
                foreach (INode node in this.Nodes as ObservableCollection<CustomNodeViewModel>)
                {
                    node.ContentTemplate = null;
                    (node as CustomNodeViewModel).Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#37909A"));
                    (node as CustomNodeViewModel).StrokeColor = new SolidColorBrush(Colors.Black);
                    (node as CustomNodeViewModel).StrokeThickess = 2;
                    (node as CustomNodeViewModel).StrokeDash = double.MaxValue;
                }
            }
            else if (ShapeName.Equals("strokeDash"))
            {
                foreach (INode node in this.Nodes as ObservableCollection<CustomNodeViewModel>)
                {
                    node.ContentTemplate = null;
                    (node as CustomNodeViewModel).Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#37909A"));
                    (node as CustomNodeViewModel).StrokeColor = new SolidColorBrush(Colors.Black);
                    (node as CustomNodeViewModel).StrokeThickess = 2;
                    (node as CustomNodeViewModel).StrokeDash = 2;
                }
            }
            else if (ShapeName.Equals("gradiant"))
            {
                foreach (INode node in this.Nodes as ObservableCollection<CustomNodeViewModel>)
                {
                    node.ContentTemplate = null;
                    (node as CustomNodeViewModel).Fill = LinearGradientBrush();
                    (node as CustomNodeViewModel).StrokeColor = new SolidColorBrush(Colors.Black);
                    (node as CustomNodeViewModel).StrokeThickess = 2;
                    (node as CustomNodeViewModel).StrokeDash = 2;
                }
            }
            else if (ShapeName.Equals("shadow"))
            {
                foreach (INode node in this.Nodes as ObservableCollection<CustomNodeViewModel>)
                {
                    node.ContentTemplate = View.Resources["ShadowNode"] as DataTemplate;
                    (node as CustomNodeViewModel).StrokeColor = new SolidColorBrush(Colors.Black);
                    (node as CustomNodeViewModel).StrokeThickess = 2;
                    (node as CustomNodeViewModel).StrokeDash = 2;
                }
            }

            prevbutton = parameter as Button;
            SelectedTheme = "None";
        }

        /// <summary>
        /// Create and add the nodes.
        /// </summary>
        /// <param name="id">ID of the Node</param>
        /// <param name="offsetx">Offset-x value of the node.</param>
        /// <param name="offsety">Offset-y value of the node.</param>
        /// <param name="text">Text to the node.</param>
        private void CreateNodes(string id, double offsetx, double offsety, string text)
        {
            CustomNodeViewModel node = new CustomNodeViewModel()
            {
                ID = id,
                UnitHeight = 100,
                UnitWidth = 100,
                OffsetX = offsetx,
                OffsetY = offsety,
                Shape = new EllipseGeometry() { RadiusX = 10, RadiusY = 10 },
                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#37909A")),
                Annotations = new ObservableCollection<IAnnotation>()
                {
                    new TextAnnotationViewModel()
                    {
                        Text = text,
                        FontSize = 15,
                        Foreground = new SolidColorBrush(Colors.White),
                    }
                },
            };
            //Add Node to Nodes property of the Diagram
            (this.Nodes as ObservableCollection<CustomNodeViewModel>).Add(node);
        }

        /// <summary>
        /// To create the linear gradient brush color to the nodes.
        /// </summary>
        /// <returns></returns>
        private RadialGradientBrush LinearGradientBrush()
        {
            RadialGradientBrush linearBrush = new RadialGradientBrush();
            linearBrush.GradientOrigin = new Point(0.5, 0.5);
            linearBrush.Center = new Point(0.5, 0.5);

            GradientStop green = new GradientStop();
            green.Color = (Color)ColorConverter.ConvertFromString("#00555b");
            green.Offset = 0.0;
            linearBrush.GradientStops.Add(green);

            GradientStop darkGreen = new GradientStop();
            darkGreen.Color = (Color)ColorConverter.ConvertFromString("#37909A");
            darkGreen.Offset = 0.75;
            linearBrush.GradientStops.Add(darkGreen);

            return linearBrush;
        }

        /// <summary>
        /// To enable or disable the aspect ratio value of the nodes.
        /// </summary>
        /// <param name="parameter"></param>
        private void OnAspectRatioCommandExecute(object parameter)
        {
            if (this != null)
            {
                if ((bool)parameter)
                {
                    foreach (INode node in this.Nodes as ObservableCollection<CustomNodeViewModel>)
                    {
                        node.Constraints |= NodeConstraints.AspectRatio;
                    }
                }
                else
                {
                    foreach (INode node in this.Nodes as ObservableCollection<CustomNodeViewModel>)
                    {
                        node.Constraints &= ~NodeConstraints.AspectRatio;
                    }
                }
            }
        }

        /// <summary>
        /// To enable or disable the node constraints value.
        /// </summary>
        /// <param name="parameter"></param>
        private void OnLockCommandExecute(object parameter)
        {
            if (this != null)
            {
                if ((bool)parameter)
                {
                    foreach (INode node in this.Nodes as ObservableCollection<CustomNodeViewModel>)
                    {
                        node.Constraints &= ~(NodeConstraints.InheritResizable | NodeConstraints.Resizable |
                            NodeConstraints.InheritRotatable | NodeConstraints.Rotatable |
                            NodeConstraints.InheritDraggable | NodeConstraints.Draggable);
                    }
                }
                else
                {
                    foreach (INode node in this.Nodes as ObservableCollection<CustomNodeViewModel>)
                    {
                        node.Constraints |= ~(NodeConstraints.InheritResizable | NodeConstraints.InheritRotatable | NodeConstraints.InheritDraggable);
                    }
                }
            }
        }

        /// <summary>
        /// Create and add connectors.
        /// </summary>
        /// <param name="sourceid">Source port ID</param>
        /// <param name="targetid">Target port ID</param>
        private void CreateConnectors(string sourceid, string targetid)
        {
            CustomConnectorViewModel connector = new CustomConnectorViewModel()
            {
                SourceNodeID = sourceid,
                TargetNodeID = targetid,
                Fill = new SolidColorBrush(Colors.Black),
            };
            var resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
            };
            connector.TargetDecorator = resourceDictionary["ClosedSharp"];

            //Add Node to Nodes property of the Diagram
            (this.Connectors as ObservableCollection<CustomConnectorViewModel>).Add(connector);
        }

        /// <summary>
        /// Updates the themes value to the diagram.
        /// </summary>
        /// <param name="theme"></param>
        private void ThemeValueChanged(string theme)
        {
            prevbutton.Style = View.Resources["NodesButtonStyle"] as Style;
            foreach (INode node in this.Nodes as ObservableCollection<CustomNodeViewModel>)
            {
                node.ContentTemplate = null;
            }

            switch (theme)
            {
                case "None":
                    break;
                case "OfficeTheme":
                    this.Theme = new OfficeTheme();
                    break;
                case "LinearTheme":
                    this.Theme = new LinearTheme();
                    break;
                case "ZephyrTheme":
                    this.Theme = new ZephyrTheme();
                    break;
                case "IntegralTheme":
                    this.Theme = new IntegralTheme();
                    break;
                case "SimpleTheme":
                    this.Theme = new SimpleTheme();
                    break;
                case "WhispTheme":
                    this.Theme = new WhispTheme();
                    break;
                case "DaybreakTheme":
                    this.Theme = new DaybreakTheme();
                    break;
                case "SequenceTheme":
                    this.Theme = new SequenceTheme();
                    break;
                case "ParallelTheme":
                    this.Theme = new ParallelTheme();
                    break;
                case "SliceTheme":
                    this.Theme = new SliceTheme();
                    break;
                case "IonTheme":
                    this.Theme = new IonTheme();
                    break;
                case "GemstoneTheme":
                    this.Theme = new GemstoneTheme();
                    break;
                case "CloudsTheme":
                    this.Theme = new CloudsTheme();
                    break;
                case "BubbleTheme":
                    this.Theme = new BubbleTheme();
                    break;
                case "RetrospectTheme":
                    this.Theme = new RetrospectTheme();
                    break;
                case "FacetTheme":
                    this.Theme = new FacetTheme();
                    break;
                case "ProminenceTheme":
                    this.Theme = new ProminenceTheme();
                    break;
                case "SmokeTheme":
                    this.Theme = new SmokeTheme();
                    break;
                case "RadianceTheme":
                    this.Theme = new RadianceTheme();
                    break;
            }
        }
        #endregion
    }

    /// <summary>
    /// Create the custom node view model class of the <see cref="NodeViewModel"/> class.
    /// </summary>
    public class CustomNodeViewModel : NodeViewModel
    {

        #region Fields

        //To hold the fill color of the nodes.
        private Brush fill = new SolidColorBrush(Colors.Black);

        //To hold the stroke color of the nodes.
        private Brush strokeColor = new SolidColorBrush(Colors.CornflowerBlue);

        //To hold the stroke thickness value to the nodes.
        private double strokeThickess = 1;

        //To hold the stroke dash value to the nodes.
        private double strokeDash = double.MaxValue;

        /// <summary>
        /// Gets or sets the fill color to the nodes.
        /// </summary>
        public Brush Fill
        {
            get
            {
                return fill;
            }
            set
            {
                if (fill != value)
                {
                    fill = value;
                    OnPropertyChanged("fill");
                    OnFillChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the stroke color to the nodes.
        /// </summary>
        public Brush StrokeColor
        {
            get
            {
                return strokeColor;
            }
            set
            {
                if (strokeColor != value)
                {
                    strokeColor = value;
                    OnPropertyChanged("Fill");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Stroke thickness value to the nodes.
        /// </summary>
        public double StrokeThickess
        {
            get
            {
                return strokeThickess;
            }
            set
            {
                if (strokeThickess != value)
                {
                    strokeThickess = value;
                    OnPropertyChanged("Fill");
                }
            }
        }

        /// <summary>
        /// Gets re sets the stroke dash value to the nodes.
        /// </summary>
        public double StrokeDash
        {
            get
            {
                return strokeDash;
            }
            set
            {
                if (strokeDash != value)
                {
                    strokeDash = value;
                    OnPropertyChanged("Fill");
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the fill color, stroke color, stroke thickness, stroke dash values to the nodes.
        /// </summary>
        private void OnFillChanged()
        {
            Style s = new Style(typeof(Path));
            if (Fill != null)
            {
                s.Setters.Add(new Setter(Path.FillProperty, Fill));
                s.Setters.Add(new Setter(Path.StrokeThicknessProperty, StrokeThickess));
                s.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
                s.Setters.Add(new Setter(Path.StrokeProperty, StrokeColor));
                s.Setters.Add(new Setter(Path.StrokeDashArrayProperty, new DoubleCollection() { StrokeDash }));
            }
            ShapeStyle = s;
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);

            switch (name)
            {
                case "Fill":
                    OnFillChanged();
                    break;
            }
        }
        #endregion
    }

    /// <summary>
    /// Creates the custom connector view model to the <see cref="ConnectorViewModel"/> class.
    /// </summary>
    public class CustomConnectorViewModel : ConnectorViewModel
    {
        #region Fields

        //To hold the fill color of the connector.
        private Brush fill = new SolidColorBrush(Colors.Black);

        /// <summary>
        /// Gets or sets the fill color of the connectors.
        /// </summary>
        public Brush Fill
        {
            get
            {
                return fill;
            }
            set
            {

                if (fill != value)
                {
                    fill = value;
                    OnPropertyChanged("Fill");
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Updates the fill color, stroke color to the source decorators, target decorators.
        /// </summary>
        private void OnFillChanged()
        {
            Style connectorGeometryStyle = new Style(typeof(Path));
            Style targetDecoratorStyle = new Style(typeof(Path));
            double stroke = 1;

            if (Fill != null)
            {
                connectorGeometryStyle.Setters.Add(new Setter(Path.StrokeProperty, Fill));
                connectorGeometryStyle.Setters.Add(new Setter(Path.StrokeThicknessProperty, stroke));

                targetDecoratorStyle.Setters.Add(new Setter(Path.StrokeProperty, Fill));
                targetDecoratorStyle.Setters.Add(new Setter(Path.FillProperty, Fill));
                targetDecoratorStyle.Setters.Add(new Setter(Path.StrokeThicknessProperty, stroke));
                targetDecoratorStyle.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
                targetDecoratorStyle.Setters.Add(new Setter(Path.StrokeLineJoinProperty, PenLineJoin.Round));
                targetDecoratorStyle.Setters.Add(new Setter(Path.StrokeStartLineCapProperty, PenLineCap.Round));
                targetDecoratorStyle.Setters.Add(new Setter(Path.StrokeEndLineCapProperty, PenLineCap.Round));
                targetDecoratorStyle.Setters.Add(new Setter(Path.StrokeDashCapProperty, PenLineCap.Round));
            }

            ConnectorGeometryStyle = connectorGeometryStyle;
            TargetDecoratorStyle = targetDecoratorStyle;
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);

            switch (name)
            {
                case "Fill":
                    OnFillChanged();
                    break;
            }
        }
        #endregion
    }
}
