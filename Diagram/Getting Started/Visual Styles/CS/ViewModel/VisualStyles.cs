#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using GettingStarted_VisualStyles;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GettingStarted_VisualStyles
{
    public class VisualStyles : DiagramViewModel
    {
        private object _selecteditem;

        public event PropertyChangedEventHandler PropertyChanged;

        public VisualStyles()
        {

            Nodes = new ObservableCollection<NodeVM>();

            //Collection Changed event to update the Node
            (Nodes as ObservableCollection<NodeVM>).CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    (e.NewItems[0] as NodeVM).Update();
                }
            };

            //Create Nodes
            CreateNodes();

            //Undoable Constraints used to enable/disable Undo/Redo the Action.
            Constraints = Constraints.Add(GraphConstraints.Undoable);

            //SnapConstraints used to control the Vsibility of Gridlines and enable/disable the Snapping.
            SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.All,
                SnapToObject = SnapToObject.All,
            };

            DefaultConnectorType = ConnectorType.Orthogonal;
            ScrollSettings = new ScrollSettings()
            {
                ScrollLimit = ScrollLimit.Diagram,
            };

            KnownTypes = GetKnownTypes;

            //PageSettings used to enable the Appearance of Diagram Page.
            PageSettings = new PageSettings()
            {
                PageBackground = new SolidColorBrush(Colors.Transparent),
                PageBorderBrush = new SolidColorBrush(Colors.Transparent),
                PageWidth = 793.5,
                PageHeight = 1122.5,
                ShowPageBreaks = true,
            };

            //Ruler used to Creating Scale models.
            HorizontalRuler = new Ruler();
            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };

            ItemAddedCommand = new Command(OnItemAddedCommand);
        }

        public object SelectedItem
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
                    onPropertyChanged("SelectedItem");
                    OnItemSelect(_selecteditem);
                }
            }
        }

        #region Helper Methods

        //To Represent Change Theme
        private void OnItemSelect(object selecteditem)
        {
            string name = (selecteditem as ComboBoxItem).Content.ToString();
            switch (name)
            {
                case "Default":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Default);
                    break;
                case "Metro":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Metro);
                    break;
                case "VisualStudio2013":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.VisualStudio2013);
                    break;
                case "Blend":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Blend);
                    break;
                case "Office2010Black":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Office2010Black);
                    break;
                case "Office2010Blue":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Office2010Blue);
                    break;
                case "Office2010Silver":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Office2010Silver);
                    break;
                case "Office2013DarkGray":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Office2013DarkGray);
                    break;
                case "Office2013LightGray":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Office2013LightGray);
                    break;
                case "Office2013White":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Office2013White);
                    break;
                case "Lime":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Lime);
                    break;
                case "Saffron":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Saffron);
                    break;
                case "VisualStudio2015":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.VisualStudio2015);
                    break;
                case "Office2016Colorful":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Office2016Colorful);
                    break;
                case "Office2016DarkGray":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Office2016DarkGray);
                    break;
                case "Office2016White":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Office2016White);
                    break;
                case "Office365":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.Office365);
                    break;
                case "SystemTheme":
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(App.Current.MainWindow, Syncfusion.SfSkinManager.VisualStyles.SystemTheme);
                    break;
            }
        }

        private void onPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        //For Apply Style to Added Item
        private void OnItemAddedCommand(object obj)
        {
            var args = obj as ItemAddedEventArgs;
            if (args.Item is NodeVM)
            {
                var node = args.Item as NodeVM;
                if ((args.Item as NodeVM).Annotations != null)
                {
                    var annotations = (args.Item as NodeVM).Annotations as ObservableCollection<IAnnotation>;
                    foreach (var anno in annotations)
                    {
                        if (node.Text.ToString() != null)
                        {
                            anno.Content = node.Text;
                            anno.UnitWidth = 100;
                            anno.WrapText = TextWrapping.Wrap;
                            anno.TextHorizontalAlignment = TextAlignment.Justify;
                            anno.Mode = ContentEditorMode.View;
                            anno.ViewTemplate = App.Current.Resources["viewtemplate"] as DataTemplate;
                            anno.EditTemplate = App.Current.Resources["edittemplate"] as DataTemplate;
                            anno.ReadOnly = true;
                        }
                    }

                }
            }
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

        //Create Nodes and Connections
        private void CreateNodes()
        {
            //Create Nodes
            NodeVM NewIdea = AddNode("NewIdea", 150, 60, 175, 60, "Ellipse", "New idea identified", 1, "#65c7d0");
            NodeVM Meeting = AddNode("Meeting", 150, 60, 175, 160, "Process", "Meeting with board", 2, "#65c7d0");
            NodeVM BoardDecision = AddNode("BoardDecision", 150, 100, 175, 270, "Decision", "Board decides\nwhether to proceed", 3, "#65c7d0");
            NodeVM project = AddNode("project", 150, 100, 175, 410, "Decision", "Find project\n manager,write\n specification", 3, "#65c7d0");
            NodeVM End = AddNode("End", 120, 60, 175, 530, "Process", "Implement and\n Deliver", 4, "#65c7d0");
            NodeVM Decision = AddNode("Decision", 200, 60, 480, 70, "Card", "Decision process for\n new software ideas", 5, "#858585");
            NodeVM Reject = AddNode("Reject", 150, 60, 445, 270, "Process", "Reject and write report", 4, "#65c7d0");
            Reject.IsSelected = true;
            NodeVM Resources = AddNode("Resources", 150, 60, 445, 410, "Process", "Hire new resources", 2, "#65c7d0");

            //Create Connections
            Connect(Meeting, NewIdea, "");
            Connect(BoardDecision, Meeting, "");
            Connect(Reject, BoardDecision, "No");
            Connect(project, BoardDecision, "Yes");
            Connect(Resources, project, "No");
            Connect(End, project, "Yes");
        }

        private NodeVM AddNode(String name, double width, double height, double offsetx, double offsety, string shape, String content, Int32 level, string fill)
        {
            NodeVM node = new NodeVM();
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
                    ViewTemplate= App.Current.Resources["viewtemplate1"] as DataTemplate,
                    EditTemplate= App.Current.Resources["edittemplate"] as DataTemplate,
                    ReadOnly = true,
                }
            };
            (Nodes as ObservableCollection<NodeVM>).Add(node);
            return node;
        }

        //Add Connections
        private void Connect(NodeVM headnode, NodeVM tailnode, string label)
        {
            ConnectorViewModel conn = new ConnectorViewModel();
            conn.SourceNode = tailnode;
            conn.TargetNode = headnode;
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
                     EditTemplate = App.Current.Resources["edittemplate"] as DataTemplate,
                     Margin= new Thickness(0,0,0,10),
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
                    ViewTemplate= App.Current.Resources["viewtemplate"] as DataTemplate,
                    EditTemplate = App.Current.Resources["edittemplate"] as DataTemplate,
                    Margin= new Thickness(0,10,0,0),
                }
            };

            }
            (Connectors as ObservableCollection<ConnectorViewModel>).Add(conn);
        }

        #endregion

    }
}
