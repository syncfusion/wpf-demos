using System.Runtime.Serialization;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;

namespace Localization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        //To Represent ResourceManager
        System.Resources.ResourceManager manager;

        public MainWindow()
        {
            //Get CultureInfo 
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");//French
            
            InitializeComponent();

            //Initialize Assembly
            Assembly assembly = Application.Current.GetType().Assembly;
            manager = new System.Resources.ResourceManager("Localization.Resources.Syncfusion.SfDiagram.WPF", assembly);

            //Initialize PageSettings
            InitializeDiagram();

            //Initialize Node Collection
            ObservableCollection<Node> nodecollection = new ObservableCollection<Node>();
            diagramcontrol.Connectors = new ObservableCollection<ConnectorVm>();
            var nodes = new ObservableCollection<CustomNode>();
            diagramcontrol.Nodes = nodes;
            diagramcontrol.CommandManager.View = Application.Current.MainWindow;
            diagramcontrol.Constraints = diagramcontrol.Constraints | GraphConstraints.Undoable;

            //Collection changed Event to update the Node
            nodes.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    (e.NewItems[0] as CustomNode).Update();
                }
            };

            //Create Node and Connection
            createnodes();

            (diagramcontrol.Info as IGraphInfo).ItemAdded += MainWindow_ItemAdded;
        }

        private void MainWindow_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            if (args.Item is CustomNode)
            {
                CustomNode node = args.Item as CustomNode;
                if (node.Shape.ToString() == this.Resources["Card"].ToString())
                    node.ShapeStyle = this.Resources["nodestyle1"] as Style;
                else
                    node.ShapeStyle = this.Resources["nodestyle"] as Style;
            }
        }

        private void InitializeDiagram()
        {
            //PageSettings used to enable the Appearance of Diagram Page.
            diagramcontrol.ScrollSettings.ScrollLimit = ScrollLimit.Diagram;
            diagramcontrol.KnownTypes = GetKnownTypes;
            diagramcontrol.PageSettings.PageBackground = new SolidColorBrush(Colors.White);
            diagramcontrol.PageSettings.PageBorderBrush = new SolidColorBrush(Colors.White);
        }

        //Helps to Serialize tha Shape
        private IEnumerable<Type> GetKnownTypes()
        {
            List<Type> known = new List<Type>()
            {
                typeof(Shapes)
            };
            foreach (var item in known)
            {
                yield return item;
            }
        }

        //Create Nodes and Connections
        private void createnodes()
        {
            //Create Nodes
            CustomNode NewIdea = addNode("NewIdea", 150, 60, 295, 40,"Ellipse", "NewIdea", this.Resources["nodestyle"] as Style);
            CustomNode Meeting = addNode("Meeting", 150, 60, 295, 145, "Process", "Meeting", this.Resources["nodestyle"] as Style);
            CustomNode BoardDecision = addNode("BoardDecision", 160, 100, 295, 265, "Decision", "BoardDecision", this.Resources["nodestyle"] as Style);
            CustomNode project = addNode("project", 160, 100, 295, 420, "Decision", "project", this.Resources["nodestyle"] as Style);
            CustomNode End = addNode("End", 120, 60, 295, 550, "Process", "End", this.Resources["nodestyle"] as Style);
            CustomNode Decision = addNode("Decision", 200, 60, 550, 50, "Card", "Decision", this.Resources["nodestyle1"] as Style);
            CustomNode Reject = addNode("Reject", 150, 60, 515, 265, "Process", "Reject", this.Resources["nodestyle"] as Style);
            CustomNode Resources = addNode("Resources", 150, 60, 515, 420, "Process", "Resources", this.Resources["nodestyle"] as Style);

            //Create Connections
            Connect(Meeting, NewIdea, "");
            Connect(BoardDecision, Meeting, "");
            Connect(Reject, BoardDecision, "No");
            Connect(project, BoardDecision, "Yes");
            Connect(Resources, project, "No");
            Connect(End, project, "Yes");
        }

        //Add Connections
        private void Connect(CustomNode headnode, CustomNode tailnode, string label)
        {
            ConnectorVm conn = new ConnectorVm();
            conn.SourceNode = tailnode;
            conn.TargetNode = headnode;
            conn.ConnectorGeometryStyle = this.Resources["connectorstyle"] as Style;
            conn.TargetDecoratorStyle = this.Resources["decoratorstyle"] as Style;
            if (label == "Yes")
            {
                //To Represent Annotation Properties
                conn.Annotations = new ObservableCollection<IAnnotation>()
            {
                new AnnotationEditorViewModel()
                {
                    WrapText = TextWrapping.NoWrap,
                    Content=manager.GetString(label),                    
                    HorizontalAlignment=HorizontalAlignment.Center,
                    VerticalAlignment=VerticalAlignment.Center,
                    Alignment=ConnectorAnnotationAlignment.Center,
                    ReadOnly = true,
                    RotationReference= Syncfusion.UI.Xaml.Diagram.RotationReference.Page,
                    //Set Annotation Template to Node
                    ViewTemplate=this.Resources["viewtemplate"] as DataTemplate,
                    EditTemplate=this.Resources["edittemplate"] as DataTemplate
                }
            };
            }
            else if (label == "No")
            {
                conn.Annotations = new ObservableCollection<IAnnotation>()
            {
                new AnnotationEditorViewModel()
                {
                    Content=manager.GetString(label),                  
                    HorizontalAlignment=HorizontalAlignment.Center,
                    VerticalAlignment=VerticalAlignment.Center,
                    Alignment=ConnectorAnnotationAlignment.Center,
                    ReadOnly = true,
                    ViewTemplate=this.Resources["viewtemplate"] as DataTemplate,
                    EditTemplate=this.Resources["edittemplate"] as DataTemplate
                }
            };

            }
            (diagramcontrol.Connectors as ICollection<ConnectorVm>).Add(conn);
        }

        //Add Nodes
        private CustomNode addNode(String name, double width, double height, double offsetx, double offsety,string shape, string content, Style fill)
        {
            CustomNode node = new CustomNode();
            node.UnitWidth = width;
            node.UnitHeight = height;
            node.HorizontalContentAlignment = HorizontalAlignment.Center;
            node.VerticalContentAlignment = VerticalAlignment.Center;
            node.OffsetX = offsetx - 50;
            node.OffsetY = offsety;
            node.Text = manager.GetString(content);             
            node.Shape = this.Resources[shape];
            node.ShapeStyle = fill; 
            (diagramcontrol.Nodes as ICollection<CustomNode>).Add(node);
            return node;

        }

    }

    //To Represent Node Properties
    public class CustomNode : Node
    {
        public CustomNode()
        {
        }

        private string _mText;
        
        [DataMember]
        public string Text
        {
            get { return _mText; }
            set { _mText = value; }
        }        

        public void Update()
        {
            string content = Text;
            Shape shape = this.Shape as Shape;
            TextBlock txtblock = new TextBlock();
            if (shape == this.Resources["Decision"])
            {
                txtblock.Margin = new Thickness(25);
            }
            if (shape == this.Resources["Card"])
            {
                txtblock.Margin = new Thickness(10);
            }
            txtblock.Text = content;
            txtblock.Foreground = new SolidColorBrush(Colors.White);
            FontFamily ff = new FontFamily("Segoe UI");
            txtblock.FontFamily = ff;
            txtblock.FontSize = 13;
            txtblock.TextWrapping = TextWrapping.Wrap;
            txtblock.TextAlignment = TextAlignment.Center;
            txtblock.HorizontalAlignment = HorizontalAlignment.Center;
            txtblock.VerticalAlignment = VerticalAlignment.Center;
            Content = txtblock;
        }
    }

    #region Custom Class
   
    public class ConnectorVm : Connector
    {

    }
    public class ConnectorVmCollection : ObservableCollection<ConnectorVm>
    {

    }
    #endregion
}
