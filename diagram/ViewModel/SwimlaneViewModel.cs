#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class SwimlaneVM : DiagramViewModel
    {
        #region Fields

        private ICommand _NewCommand;
        private ICommand _SaveCommand;
        private ICommand _LoadCommand;

        #endregion

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };

        public SwimlaneVM()
        {
            this.Nodes = new ObservableCollection<NodeViewModel>();
            this.Connectors = new ObservableCollection<ConnectorViewModel>();
            this.Swimlanes = new ObservableCollection<SwimlaneViewModel>();
            
            SelectedItems = new SelectorViewModel();

            HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };
            VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            InitializeDiagram();
            NewCommand = new DelegateCommand(OnNew);
            LoadCommand = new DelegateCommand(OnLoad);
            SaveCommand = new DelegateCommand(OnSave);

        }

        #region Commands

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

        #endregion
        #region Helper Methods

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
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                using (Stream myStream = dialog.OpenFile())
                {
                    (Info as IGraphInfo).Load(myStream);
                }
            }
        }

        /// <summary>
        /// This method is used to execute new command
        /// </summary>
        /// <param name="obj"></param>
        private void OnNew(object obj)
        {
            this.Nodes = new ObservableCollection<NodeViewModel>();
            this.Connectors = new ObservableCollection<ConnectorViewModel>();
            this.Swimlanes = new ObservableCollection<SwimlaneViewModel>();
        }



        #endregion
        private void InitializeDiagram()
        {
            SwimlaneViewModel swimLane = new SwimlaneViewModel();
            swimLane.Orientation = Orientation.Horizontal;
            swimLane.OffsetX = 400;
            swimLane.OffsetY = 300;
            swimLane.UnitWidth = 650;
            swimLane.UnitHeight = 500;

            swimLane.Header = new SwimlaneHeaderViewModel()
            {
                UnitHeight = 50,
                Annotation = new AnnotationEditorViewModel()
                {
                    Content = "SALES PROCESS FLOW CHART"
                },
            };
            PhaseViewModel nn1 = CreatePhaseViewModel(true, "Phase1", 0);
            nn1.UnitWidth = 760;

            swimLane.Phases = new ObservableCollection<PhaseViewModel>() { nn1 };

            LaneViewModel ll1 = CreateLaneViewModel(true, "Consumer", 270);
            NodeViewModel n1 = ChildElement(ll1, "Rectangle", "Consumer learns of product", 130, 55);
            NodeViewModel n2 = ChildElement(ll1, "Decision", "Does Consumer \n want the product", 320, 55);
            NodeViewModel n3 = ChildElement(ll1, "Flow", "No sales lead", 520, 55);
            NodeViewModel n4 = ChildElement(ll1, "Rectangle", "Sell to consumer", 680, 55);


            LaneViewModel ll2 = CreateLaneViewModel(true, "Marketing", 270);
            NodeViewModel n5 = ChildElement(ll2, "Rectangle", "Create marketing campaigns", 130, 55);
            NodeViewModel n6 = ChildElement(ll2, "Rectangle", "Marketing finds sales leads", 320, 55);


            LaneViewModel ll3 = CreateLaneViewModel(true, "Sales", 270);
            NodeViewModel n7 = ChildElement(ll3, "Rectangle", "Sales receives lead", 320, 60);

            LaneViewModel ll4 = CreateLaneViewModel(true, "Success", 270);
            NodeViewModel n8 = ChildElement(ll4, "Rectangle", "Success helps retain consumer as a customer", 680, 55);

            ll1.UnitHeight = 115;
            ll2.UnitHeight = 115;
            ll3.UnitHeight = 115;
            ll4.UnitHeight = 115;
            swimLane.Lanes = new ObservableCollection<LaneViewModel>() { ll1, ll2, ll3, ll4 };

            (this.Swimlanes as ObservableCollection<SwimlaneViewModel>).Add(swimLane);




            CreateConnection(n1, n2);
            ConnectorViewModel noconnector = CreateConnection(n2, n3);
            noconnector.Annotations = new ObservableCollection<IAnnotation>()
            {
                new AnnotationEditorViewModel()
                {
                    Content="No"
                }
            };
            CreateConnection(n4, n8);
            ConnectorViewModel yesconnector = CreateConnection(n2, n6);
            yesconnector.Annotations = new ObservableCollection<IAnnotation>()
            {
                new AnnotationEditorViewModel()
                {
                    Content="Yes",RotationReference=RotationReference.Page, Length=0.4
                }
            };
            CreateConnection(n5, n1);
            CreateConnection(n6, n7);
            ConnectorViewModel con = CreateConnection(n4, n7);
            NodePortViewModel port = CreatePort(n4, 0, 0.5);
            NodePortViewModel port1 = CreatePort(n7, 1, 0.5);
            con.SourcePort = port;
            con.TargetPort = port1;
        }

        public PhaseViewModel CreatePhaseViewModel(bool ishorizontal, string content, double angle)
        {
            PhaseViewModel nn1 = new PhaseViewModel()
            {
                Header = new SwimlaneHeaderViewModel()
                {
                    Annotation = new AnnotationEditorViewModel() { RotateAngle = angle, Content = content, Offset = new Point(0.5, 0.5) }
                },
            };
            if (ishorizontal)
            {
                (nn1.Header as SwimlaneHeaderViewModel).UnitHeight = 30;
            }
            else
            {
                (nn1.Header as SwimlaneHeaderViewModel).UnitWidth = 50;
            }
            return nn1;
        }
        public LaneViewModel CreateLaneViewModel(bool ishorizontal, string content, double angle)
        {
            AnnotationEditorViewModel annotation = new AnnotationEditorViewModel() { RotateAngle = angle, Content = content, Offset = new Point(0.5, 0.5) };
            annotation.Constraints |= AnnotationConstraints.Rotatable & ~AnnotationConstraints.InheritRotatable;
            LaneViewModel l1 = new LaneViewModel()
            {
                Header = new SwimlaneHeaderViewModel()
                {
                    Annotation = annotation,
                },
            };
            if (ishorizontal)
            {
                (l1.Header as SwimlaneHeaderViewModel).UnitWidth = 50;
            }
            else
            {
                (l1.Header as SwimlaneHeaderViewModel).UnitHeight = 50;
            }
            return l1;
        }

        private NodePortViewModel CreatePort(NodeViewModel node, double offx, double offy)
        {
            NodePortViewModel port = new NodePortViewModel()
            {
                Node = node,
                NodeOffsetX = offx,
                NodeOffsetY = offy,
            };
            (node.Ports as PortCollection).Add(port);

            return port;
        }
        private ConnectorViewModel CreateConnection(NodeViewModel node, NodeViewModel node1)
        {
            ConnectorViewModel con = new ConnectorViewModel()
            {
                SourceNode = node,
                TargetNode = node1,
            };
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(con);
            return con;
        }

        private NodeViewModel ChildElement(LaneViewModel lane, string shape, string content, double offsetx, double offsety)
        {
            NodeViewModel node = new NodeViewModel()
            {
                UnitWidth = 130,
                UnitHeight = 60,
                LaneOffsetX = offsetx,
                LaneOffsetY = offsety,
                Shape = resourceDictionary[shape],
            };

            if (shape == "Decision")
            {
                node.UnitWidth = 160;
                node.UnitHeight = 90;
            }

            if (shape == "Flow")
            {
                node.Shape = " M100,20 C100,31.05,91.37,40,80.72,40 L19.28,40 C8.63,40,0,31.05,0,20 L0,20 C0,8.95,8.63,0,19.28,0 L80.72,0 C91.37,0,100,8.95,100,20 Z";
            }
            node.Annotations = new AnnotationCollection()
            {
                new AnnotationEditorViewModel()
                {
                    Content=content,
                }
            };
            (lane.Children as LaneChildren).Add(node);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(node);
            return node;
        }
    }
}
