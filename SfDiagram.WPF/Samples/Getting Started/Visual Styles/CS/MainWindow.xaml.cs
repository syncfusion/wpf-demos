using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using System.Windows.Markup;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.Windows.Shared;
namespace SfDiagramWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //Initialize Nodes and Connectors
            var nodes = new ObservableCollection<CustomNode>();
            Diagram.Connectors = new ObservableCollection<ConnectorViewModel>();
            Diagram.Nodes = nodes;

            //Collection Changed event to update the Node
            nodes.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    (e.NewItems[0] as CustomNode).Update();
                }
            };

            //Create Nodes
            CreateNodes();

            //Initialize PageSettings,Snapping,Ruler and Constraints
            InitializeDiagram();
            IGraphInfo info = Diagram.Info as IGraphInfo;
            info.ItemAdded += Info_ItemAdded;
        }

        private void Info_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            if (args.Item is CustomNode)
            {
                var node = args.Item as CustomNode;
                if ((args.Item as CustomNode).Annotations != null)
                {
                    var annotations = (args.Item as CustomNode).Annotations as ObservableCollection<IAnnotation>;
                    foreach (var anno in annotations)
                    {
                        if (node.Text.ToString() != null)
                        {
                            anno.Content = node.Text;
                            anno.UnitWidth=100;
                            anno.WrapText = TextWrapping.Wrap;
                            anno.TextHorizontalAlignment = TextAlignment.Justify;
                            HorizontalAlignment = HorizontalAlignment.Center;
                            VerticalAlignment = VerticalAlignment.Center;
                            anno.Mode = ContentEditorMode.View;
                            anno.ViewTemplate = this.Resources["viewtemplate"] as DataTemplate;
                            anno.EditTemplate = this.Resources["edittemplate"] as DataTemplate;
                            anno.ReadOnly = true;
                        }
                    }

                }
            }
        }
        private void InitializeDiagram()
        {
            //Undoable Constraints used to enable/disable Undo/Redo the Action.
            Diagram.Constraints = Diagram.Constraints | GraphConstraints.Undoable;

            //SnapConstraints used to control the Vsibility of Gridlines and enable/disable the Snapping.
            Diagram.SnapSettings.SnapConstraints = SnapConstraints.All;
            Diagram.DefaultConnectorType = ConnectorType.Orthogonal;
            Diagram.SnapSettings.SnapToObject = SnapToObject.All;
            Diagram.SnapSettings.SnapConstraints = SnapConstraints.All;

            //PageSettings used to enable the Appearance of Diagram Page.
            Diagram.ScrollSettings.ScrollLimit = ScrollLimit.Diagram;
            Diagram.KnownTypes = GetKnownTypes;
            Diagram.PageSettings.PageBackground = new SolidColorBrush(Colors.White);
            Diagram.PageSettings.PageBorderBrush = new SolidColorBrush(Colors.White);
            Diagram.PageSettings = null;

            //Ruler used to Creating Scale models.
            Diagram.HorizontalRuler = new Ruler();
            Diagram.VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };

            //Filter Constraints used to enable/disable the filter.
            symbolstencil.Constraints = symbolstencil.Constraints & ~StencilConstraints.Filters;
            symbolstencil.SelectedFilter = new SymbolFilterProvider() { SymbolFilter = Filter };
        }

        private bool Filter(SymbolFilterProvider sender, object symbol)
        {
            return true;
        }

        //Create Nodes and Connections
        private void CreateNodes()
        {
            //Create Nodes
            CustomNode NewIdea = AddNode("NewIdea", 150, 60, 175, 60, "Ellipse", "New idea identified", 1, "#65c7d0");
            CustomNode Meeting = AddNode("Meeting", 150, 60, 175, 160, "Process", "Meeting with board", 2, "#65c7d0");
            CustomNode BoardDecision = AddNode("BoardDecision", 150, 100, 175, 270, "Decision", "Board decides\nwhether to proceed", 3, "#65c7d0");
            CustomNode project = AddNode("project", 150, 100, 175, 410, "Decision", "Find project\n manager,write\n specification", 3, "#65c7d0");
            CustomNode End = AddNode("End", 120, 60, 175, 530, "Process", "Implement and\n Deliver", 4, "#65c7d0");
            CustomNode Decision = AddNode("Decision", 200, 60, 480, 70, "Card", "Decision process for\n new software ideas", 5, "#858585");
            CustomNode Reject = AddNode("Reject", 150, 60, 445, 270, "Process", "Reject and write report", 4, "#65c7d0");
            Reject.IsSelected = true;
            CustomNode Resources = AddNode("Resources", 150, 60, 445, 410, "Process", "Hire new resources", 2, "#65c7d0");

            //Create Connections
            Connect(Meeting, NewIdea, "");
            Connect(BoardDecision, Meeting, "");
            Connect(Reject, BoardDecision, "No");
            Connect(project, BoardDecision, "Yes");
            Connect(Resources, project, "No");
            Connect(End, project, "Yes");
        }

        //Helps to serialize the Shape
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

        private CustomNode AddNode(String name, double width, double height, double offsetx, double offsety, string shape, String content, Int32 level, string fill)
        {
            CustomNode node = new CustomNode();
            node.HorizontalContentAlignment = HorizontalAlignment.Center;
            node.UnitWidth = width;
            node.UnitHeight = height;
            node.OffsetX = offsetx;
            node.OffsetY = offsety;
            node.Shape = App.Current.Resources[shape];
            node.Fill = fill;
            node.Text = content;

            //To Represent Annotation Properties
            node.Annotations = new ObservableCollection<IAnnotation>()
            {
                new AnnotationEditorViewModel()
                {

                    Content=content,
                    Mode=ContentEditorMode.View,
                 ViewTemplate=this.Resources["viewtemplate1"] as DataTemplate,
                EditTemplate=this.Resources["edittemplate"] as DataTemplate,
                ReadOnly = true,
                }
            };
            (Diagram.Nodes as ICollection<CustomNode>).Add(node);
            return node;
        }

        //Add Connections
        private void Connect(CustomNode headnode, CustomNode tailnode, string label)
        {
            ConnectorViewModel conn = new ConnectorViewModel();
            conn.SourceNode = tailnode;
            conn.TargetNode = headnode;
            conn.TargetDecoratorStyle = this.Resources["connectorstyle"] as Style;
            if (label == "Yes")
            {
                //To Represent Annotation Properties
                conn.Annotations = new ObservableCollection<IAnnotation>()
            {
                new AnnotationEditorViewModel()
                {
                    Content=label,                    
                    HorizontalAlignment=HorizontalAlignment.Center,
                    VerticalAlignment=VerticalAlignment.Center,
                    WrapText = TextWrapping.NoWrap,
                    ReadOnly = true,
                     ViewTemplate=App.Current.Resources["viewtemplate"] as DataTemplate,
                     EditTemplate = App.Current.Resources["edittemplate"] as DataTemplate
                }
            };
            }
            else if (label == "No")
            {
                //To Represent Annotation Properties
                conn.Annotations = new ObservableCollection<IAnnotation>()
            {
                new AnnotationEditorViewModel()
                {
                    Content=label,                    
                    HorizontalAlignment=HorizontalAlignment.Center,
                    VerticalAlignment=VerticalAlignment.Center,
                    ReadOnly = true,
                    WrapText = TextWrapping.NoWrap,
                    ViewTemplate=App.Current.Resources["viewtemplate"] as DataTemplate,
                    EditTemplate = App.Current.Resources["edittemplate"] as DataTemplate
                }
            };

            }
            (Diagram.Connectors as ICollection<ConnectorViewModel>).Add(conn);
        }
        public Style GetQuickCommanddefaultStyle()
        {
            const string cTemplate = "<Style TargetType=\"Path\"" +
                      " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" >" +
                      " <Setter  Property=\"Fill\" Value=\"#4D4D4D\">" +
                       " </Setter>" +
                       " <Setter  Property=\"StrokeThickness\" Value=\"1\">" +
                       " </Setter>" +
                       " </Style>";

            return   XamlReader.Parse(cTemplate) as Style;
        }
        //To Represent Theme Change
        private void ThemeChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = (sender as ComboBox);
            ComboBoxItem cb = (c.SelectedItem as ComboBoxItem);
            Style theamingstyle = null;
            switch (cb.Content.ToString())
            {
                case "Default":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Default);
                    theamingstyle = GetQuickCommanddefaultStyle();
                    break;
                case "Metro":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Metro);
                    theamingstyle = GetStyle("Metro_BackgroundBrush", "#FFC8C8C8");
                    break;
                case "VisualStudio2013":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.VisualStudio2013);
                    theamingstyle = GetStyle("Visualstudio2013_BackgroundBrush", "#FFCCCEDB");
                    break;
                case "Blend":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Blend);
                    theamingstyle = GetStyle("Blend_BackgroundBrush", "#FF474747");
                    break;
                case "Office2010Black":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Office2010Black);
                    theamingstyle = GetStyle("Office2010black_BackgroundBrush", "#FF7D7E7E");
                    break;
                case "Office2010Blue":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Office2010Blue);
                    theamingstyle = GetStyle("Office2010blue_BackgroundBrush", "#FFB0C2DB");
                    break;
                case "Office2010Silver":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Office2010Silver);
                    theamingstyle = GetStyle("Office2010silver_BackgroundBrush", "#FFCED4DD");
                    break;
                case "Office2013DarkGray":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Office2013DarkGray);
                    theamingstyle = GetStyle("Office2013darkgray_BackgroundBrush", "#FFACACAC");
                    break;
                case "Office2013LightGray":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Office2013LightGray);
                    theamingstyle = GetStyle("Office2013lightgray_BackgroundBrush", "#FFACACAC");
                    break;
                case "Office2013White":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Office2013White);
                    theamingstyle = GetStyle("Office2013white_BackgroundBrush", "#FFACACAC");
                    break;
                case "Lime":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Lime);
                    theamingstyle = GetStyle("Lime_BackgroundBrush", "#FFBBBCBB");
                    break;
                case "Saffron":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Saffron);
                    theamingstyle = GetStyle("Saffron_BackgroundBrush", "#FFBBBCBB");
                    break;
                case "VisualStudio2015":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.VisualStudio2015);
                    theamingstyle = GetStyle("Visualstudio2015_BackgroundBrush", "#FFCCCEDB");
                    break;
                case "Office2016Colorful":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Office2016Colorful);
                    theamingstyle = GetStyle("Office2016colorfull_BackgroundBrush", "#FFABABAB");
                    break;
                case "Office2016DarkGray":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Office2016DarkGray);
                    theamingstyle = GetStyle("Office2016drakgray_BackgroundBrush", "#FFD4D4D4");
                    break;
                case "Office2016White":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Office2016White);
                    theamingstyle = GetStyle("Office2016white_BackgroundBrush", "#FFACACAC");
                    break;
                case "Office365":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, Syncfusion.SfSkinManager.VisualStyles.Office365);
                    theamingstyle = GetStyle("Office365_BackgroundBrush", "#FFC8C8C8");
                    break;

            }
            ApplyQuickCommandShapeStyle(theamingstyle);
        }

        private void ApplyQuickCommandShapeStyle(Style style)
        {
            if ((Diagram.SelectedItems as SelectorViewModel).Commands != null)
            {
                foreach (QuickCommandViewModel quick in (Diagram.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection)
                {
                    quick.ShapeStyle = style;
                }
            } 
        }

        private Style GetStyle(string fill,string stroke)
        {
            SolidColorBrush myBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(stroke));
            Style style = new Style();
            style.TargetType = typeof(Path);
            style.Setters.Add(new Setter() { Property = Path.FillProperty, Value = this.Resources[fill] });
            style.Setters.Add(new Setter() { Property = Path.StrokeProperty, Value = myBrush });
            style.Setters.Add(new Setter() { Property = Path.StretchProperty, Value = Stretch.Fill });
            return style;
        }
        //private void ChangeTheme(string p)
        //{
        //    ResourceDictionary dict = new ResourceDictionary();
        //    ResourceDictionary dict1 = new ResourceDictionary();
        //    Application.Current.Resources.MergedDictionaries.Clear();
        //    if (p.Equals("Default"))
        //    {
        //        dict.Source = new Uri("/Syncfusion.SfDiagram.WPF;Component/Themes/Generic.xaml", UriKind.Relative);
        //        dict1.Source = new Uri("/Syncfusion.SfDiagram.WPF;Component/Themes/WpfSlResource.xaml", UriKind.Relative);
        //        Application.Current.Resources.MergedDictionaries.Add(dict);
        //        Application.Current.Resources.MergedDictionaries.Add(dict1);
        //    }
        //    else
        //    {
        //        string x = "/Syncfusion.Themes." + p + ".WPF;component/SfDiagram/SfDiagram.xaml";               
        //        dict.Source = new Uri(x, UriKind.Relative);
        //        Application.Current.Resources.MergedDictionaries.Clear();
        //        Application.Current.Resources.MergedDictionaries.Add(dict);
        //    }
        //}
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
        private string _mFill;

        [DataMember]
        public string Fill
        {
            get { return _mFill; }
            set { _mFill = value; }
        }
        private string _mcheck;

        [DataMember]
        public string ShapeType
        {
            get { return _mcheck; }
            set { _mcheck = value; }
        }
    

    public void Update()
        {
            string content = Text;
            Shape shape = this.Shape as Shape;
            TextBlock txtblock = new TextBlock();
            string fill = Fill;
            if (fill != null)
            {
                ShapeStyle = GetStyle(fill);
            }

            if (ShapeType == "Diamond")
            {
                txtblock.Margin = new Thickness(25);
            }
            if (ShapeType == "Card")
            {
                txtblock.Margin = new Thickness(10);
            }           
        }
        //Style for Node
        private Style GetStyle(string fill)
        {
            Node node = this;
            string hex = fill;
            hex = hex.Replace("#", string.Empty);
            byte r = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(255, r, g, b));
            Style sty = new Style();
            sty.BasedOn = node.ShapeStyle;
            sty.TargetType = typeof(Path);
            sty.Setters.Add(new Setter(Path.FillProperty, myBrush));
            sty.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));
            return sty;
        }
    }

    //To Represent SfDiagram Commands
    public class CustomDiagram : SfDiagram
    {
        public CustomDiagram()
        {
            CustomSelector selector = new CustomSelector();
            selector.Graph = (this.Info as IGraphInfo);
            selector.Graph.Commands.Delete.Execute(null);
            selector.Graph.Commands.BringToFront.Execute(null);
            selector.Graph.Commands.SendToBack.Execute(null);
            selector.Graph.Commands.Draw.Execute(null);
            SelectedItems = selector;
            selector.ZIndex = 10000;
            selector.Nodes = new ObservableCollection<object>();
            selector.Connectors = new ObservableCollection<object>();
            selector.Groups = new ObservableCollection<object>();
        }

        //Initialize Selector
        public Selector SFSelector = new Selector();

        protected override Selector GetSelectorForItemOverride(object item)
        {
            return SFSelector;
        }
        protected override Node GetNodeForItemOverride(object item)
        {
            CNode n = new CNode();
            return n;
        }
    }

    //To Represent Selector
    public class CustomSelector : SelectorViewModel
    {
        public IGraphInfo Graph { get; set; }
    }

    //To Represent SfDiagram Node
    public class CNode : Node
    {
        public CNode()
        {
            Loaded += CNode_Loaded;
            ManipulationStarted += CNode_ManipulationStarted;


        }

        void CNode_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {

        }

        void CNode_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }

    //To Represent Symbol
    public class Animal : ISymbol
    {
        public Animal()
        {

        }

        public object Symbol
        {
            get;
            set;
        }

        public object Key
        {
            get;
            set;
        }
        public DataTemplate SymbolTemplate
        {
            get;
            set;
        }

        public string GroupName { get; set; }

        //Get ISymbol
        public ISymbol Clone()
        {
            return new Animal()
            {
                Symbol = this.Symbol,
                SymbolTemplate = this.SymbolTemplate,
                Key = this.Key
            };
        }

    }

    //To Represent Symbol Collection
    public class SymbolCollection : ObservableCollection<ISymbol>
    {

    }
}
