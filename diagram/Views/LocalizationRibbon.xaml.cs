#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.DiagramRibbon;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for LocalizationRibbon.xaml
    /// </summary>
    public partial class LocalizationRibbon : RibbonWindow
    {
        //To Represent ResourceManager
        System.Resources.ResourceManager manager;
        CultureInfo currentCulture;
        private bool first = true;
        public LocalizationRibbon()
        {
            currentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture;

            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");

            DiagramLocalizationResourceAccessor.Instance.SetResources(this.GetType().Assembly, "syncfusion.diagramdemos.wpf");

            DiagramRibbonLocalizationResourceAccessor.Instance.SetResources(this.GetType().Assembly, "syncfusion.diagramdemos.wpf");
            
            SharedLocalizationResourceAccessor.Instance.SetResources(this.GetType().Assembly, "syncfusion.diagramdemos.wpf");
            
            ToolsLocalizationResourceAccessor.Instance.SetResources(this.GetType().Assembly, "syncfusion.diagramdemos.wpf");

            InitializeComponent();

            // This code is used to set the menu drop down in the left side for both right handed and left handed settings.
            //Whether the acquisition system is Left-handed (true) or Right-handed (false)            

            var ifLeft = SystemParameters.MenuDropAlignment;
            if (ifLeft)
            {
                var t = typeof(SystemParameters);
                var field = t.GetField("_menuDropAlignment", BindingFlags.NonPublic | BindingFlags.Static);
                field.SetValue(null, false);
                ifLeft = SystemParameters.MenuDropAlignment;
            }

            this.Unloaded += LocalizationRibbon_Unloaded;
            (diagramcontrol.Info as IGraphInfo).ViewPortChangedEvent += LocalizationRibbon_ViewPortChangedEvent;

            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "Windows11Light" });

            ////Initialize Assembly
            Assembly assembly = this.GetType().Assembly;
            manager = new System.Resources.ResourceManager("syncfusion.diagramdemos.wpf.Resources.Syncfusion.SfDiagram.Wpf", assembly);

            //Create Nodes and Connections
            CreateNodesAndConnectors();
        }

        private void LocalizationRibbon_Unloaded(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = currentCulture;
            this.Unloaded -= LocalizationRibbon_Unloaded;
        }

        private void LocalizationRibbon_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            if (diagramcontrol.Info != null && (args.Item as SfDiagram).IsLoaded == true && first && args.NewValue.ContentBounds != args.OldValue.ContentBounds)
            {
                (diagramcontrol.Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
                first = false;
            }
        }

        //Create Nodes and Connections
        private void CreateNodesAndConnectors()
        {
            ///Add and Creating Nodes
            //Create and Add NewIdea Node  
            NodeViewModel NewIdea = AddNode(150, 60, 300, 60, "Ellipse", "NewIdea");

            //Create and Add Meeting Node 
            NodeViewModel Meeting = AddNode(150, 60, 300, 160, "Process", "Meeting");

            //Create and Add BoardDecision Node  
            NodeViewModel BoardDecision = AddNode(180, 100, 300, 270, "Decision", "BoardDecision");

            //Create and Add project Node 
            NodeViewModel Project = AddNode(180, 100, 300, 410, "Decision", "Decision");

            //Create and Add End Node 
            NodeViewModel End = AddNode(120, 60, 300, 530, "Process", "End");          

            //Create and Add Decision Node 
            NodeViewModel Decision = AddNode(200, 60, 540, 70, "Card", "Decision");

            //Create and Add Reject Node 
            NodeViewModel Reject = AddNode(200, 60, 540, 270, "Process", "Reject");

            //Create and Add NewResources Node 
            NodeViewModel NewResources = AddNode(200, 60, 540, 410, "Process", "Resources");

            ///Add and Creating Connectors
            //Create Connections between NewIdea Node and Meeting Node
            AddConnector(NewIdea, Meeting, "");

            //Create Connections between BoardDecision Node and Meeting Node
            AddConnector(Meeting, BoardDecision, "");

            //Create Connections between BoardDecision Node and Reject Node
            AddConnector(BoardDecision, Reject, "No");

            //Create Connections between BoardDecision Node and Project Node
            AddConnector(BoardDecision, Project, "Yes");

            //Create Connections between Project Node and End Node
            AddConnector(Project, NewResources, "No");

            //Create Connections between Project Node and End Node
            AddConnector(Project, End, "Yes");
        }

        //Create and Add Nodes
        private NodeViewModel AddNode(double width, double height, double offsetx, double offsety, string shape, string text)
        {
            NodeViewModel node = new NodeViewModel();
            node.UnitWidth = width;
            node.UnitHeight = height;
            node.OffsetX = offsetx;
            node.OffsetY = offsety;
            node.Annotations = new ObservableCollection<IAnnotation>()
            {
                new TextAnnotationViewModel()
                {
                    //Passing the resource to the text
                    Text = manager.GetString(text),
                    //Make the text as non editable
                    ReadOnly = true,
                    RotationReference= Syncfusion.UI.Xaml.Diagram.RotationReference.Page,
                    TextWrapping=TextWrapping.Wrap,
                    //Aligning the text
                    TextHorizontalAlignment=TextAlignment.Center,
                    TextVerticalAlignment=VerticalAlignment.Center,
                    //Setting the width to the text
                    UnitWidth=75,
                    //Setting the font family to the text
                    FontFamily = new FontFamily("Arial"),
                }
            };
            node.Shape = this.Resources[shape];            
            (diagramcontrol.Nodes as ObservableCollection<NodeViewModel>).Add(node);
            return node;
        }

        //Create and Add Connectors
        private void AddConnector(NodeViewModel sourceNode, NodeViewModel targetNode, string text)
        {
            TextAnnotationViewModel textannotation = new TextAnnotationViewModel();
            textannotation.Text = manager.GetString(text);
            textannotation.ReadOnly = true;
            textannotation.RotationReference = Syncfusion.UI.Xaml.Diagram.RotationReference.Page;
            if (text == "Yes")
            {
                //Setting the margin to the text
                textannotation.Margin = new Thickness(10, 0, 0, 0);
            }
            else
            {
                textannotation.Margin = new Thickness(0, 10, 0, 0);
            }

            ConnectorViewModel connector = new ConnectorViewModel();
            connector.SourceNode = sourceNode;
            connector.TargetNode = targetNode;
            connector.Annotations = new ObservableCollection<IAnnotation>()
            {
                textannotation
            };
            (diagramcontrol.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.stencil != null)
            {
                this.stencil.SymbolGroups = null;
                (this.stencil.SymbolSource as SymbolCollection).Clear();
                this.stencil.DataContext = null;
                this.stencil = null;
            }

            if (this.diagramRibbon != null)
            {
                this.diagramRibbon.Tabs = null;
                this.diagramRibbon.DataContext = null;
                this.diagramRibbon = null;
            }

            if (this.diagramcontrol != null)
            {
                if (diagramcontrol.Info is IGraphInfo)
                {
                    (diagramcontrol.Info as IGraphInfo).ViewPortChangedEvent -= LocalizationRibbon_ViewPortChangedEvent;
                }

                this.diagramcontrol = null;
            }

            GC.SuppressFinalize(this);

            this.DataContext = null;
            base.OnClosing(e);
        }
    }
}
