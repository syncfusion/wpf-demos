#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class ConstraintsViewModel : DiagramViewModel
    {
        #region Fields

        private bool first = false;
        private bool _zoom = true;
        private bool _undoredo = false;
        private bool _edit = true;
        private bool _menus = true;
        private bool _select = true;
        private bool _drag = true;

        #endregion

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };

        public DemoControl View;

        #region Constructors
        public ConstraintsViewModel(DemoControl demo)
        {

            View = demo;

            // Initializing Properties for DiagramViewModel

            SelectedItems = new SelectorViewModel()
            {
                SelectorConstraints = SelectorConstraints.Default | SelectorConstraints.HideDisabledResizer,
            };
            
            ItemSelectedCommand = new DelegateCommand(OnItemSelected);
            first = true;

            #region Nodes and Connectors 

            Nodes = new NodeCollection();
            Connectors = new ConnectorCollection();

            CreateNode(90, "Rectangle", "Selection = False", "Selection");
            CreateNode(290, "Ellipse", "Dragging = False", "Drag");
            CreateNode(490, "Heptagon", "Delete = False", "Delete");
            CreateNode(690, "Cylinder", "Rotate = False", "Rotate");
            CreateNode(890, "Plus", "TextEdit = False", "Edit");
            CreateNode(1090, "Diamond", "Resizing = False", "Resize");
            CreateNodeforLabel("Rectangle", "Node");
            CreateNodeforLabel("Rectangle", "Connector");

            CreateConnector(new Point(40, 500), new Point(190, 600), "Selection = False", "Selection");
            CreateConnector(new Point(240, 500), new Point(390, 600), "Dragging = True", "Drag");
            CreateConnector(new Point(440, 500), new Point(590, 600), "Delete = False", "Delete");
            CreateConnector(new Point(640, 500), new Point(790, 600), "EndThumb = False", "EndThumb");
            CreateConnector(new Point(840, 500), new Point(990, 600), "EndDraggable = False", "EndDraggable");
            CreateConnector(new Point(1040, 500), new Point(1190, 600), "SegmentThumb = False", "SegmentThumb");

            #endregion
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value for Zoom
        /// </summary>
        public bool Zoom
        {
            get
            {
                return _zoom;
            }
            set
            {
                if (value != _zoom)
                {
                    _zoom = value;
                    OnPropertyChanged("Zoom");
                    OnZoomChanged(_zoom);
                }
            }
        }

        /// <summary>
        /// Gets or sets the value for UndoRedo
        /// </summary>
        public bool UndoRedo
        {
            get
            {
                return _undoredo;
            }
            set
            {
                if (value != _undoredo)
                {
                    _undoredo = value;
                    OnPropertyChanged("UndoRedo");
                    OnUndoRedoChanged(_undoredo);
                }
            }
        }

        /// <summary>
        /// Gets or sets the value for Edit
        /// </summary>
        public bool Edit
        {
            get
            {
                return _edit;
            }
            set
            {
                if (value != _edit)
                {
                    _edit = value;
                    OnPropertyChanged("Edit");
                    OnEditChanged(_edit);
                }
            }
        }

        /// <summary>
        /// Gets or sets the value for Menus
        /// </summary>
        public bool Menus
        {
            get
            {
                return _menus;
            }
            set
            {
                if (value != _menus)
                {
                    _menus = value;
                    OnPropertyChanged("Menus");
                    OnMenusChanged(_menus);
                }
            }
        }

        /// <summary>
        /// Gets or sets the value for Select
        /// </summary>
        public bool Select
        {
            get
            {
                return _select;
            }
            set
            {
                if (value != _select)
                {
                    _select = value;
                    OnPropertyChanged("Select");
                    OnSelectChanged(_select);
                }
            }
        }

        /// <summary>
        /// Gets or sets the value for Drag
        /// </summary>
        public bool Drag
        {
            get
            {
                return _drag;
            }
            set
            {
                if (value != _drag)
                {
                    _drag = value;
                    OnPropertyChanged("Drag");
                    OnDragChanged(_drag);
                }
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Method to create Connectors
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="annotation"></param>
        /// <param name="constraints"></param>
        private void CreateConnector(Point point1, Point point2, string annotation, string constraints)
        {
            TextAnnotationViewModel anno = new TextAnnotationViewModel()
            {
                Text = annotation,
                Margin = new Thickness(0, 10, 30, 0),
            };

            ConnectorViewModel con = new ConnectorViewModel()
            {
                SourcePoint = point1,
                TargetPoint = point2,
                Annotations = new AnnotationCollection()
                {
                    anno,
                },
            };

            if (constraints.Equals("Selection"))
            {
                con.Constraints = con.Constraints.Remove(ConnectorConstraints.Selectable);
            }
            else if (constraints.Equals("Drag"))
            {
                con.Constraints = con.Constraints.Add(ConnectorConstraints.Draggable);
            }
            else if (constraints.Equals("Delete"))
            {
                con.Constraints = con.Constraints.Remove(ConnectorConstraints.Delete);
            }
            else if (constraints.Equals("EndThumb"))
            {
                con.Constraints = con.Constraints.Remove(ConnectorConstraints.EndThumbs);
            }
            else if (constraints.Equals("EndDraggable"))
            {
                con.Constraints = con.Constraints.Remove(ConnectorConstraints.EndDraggable);
            }
            else if (constraints.Equals("SegmentThumb"))
            {
                con.Constraints = con.Constraints.Remove(ConnectorConstraints.SegmentThumbs);
            }

            (Connectors as ConnectorCollection).Add(con);
        }

        /// <summary>
        /// Method to change the value of Edit
        /// </summary>
        /// <param name="edit"></param>
        private void OnEditChanged(bool edit)
        {
            if (edit)
            {
                Constraints = Constraints.Add(GraphConstraints.PageEditing);
            }
            else
            {
                Constraints = Constraints.Remove(GraphConstraints.PageEditing);
            }
        }

        /// <summary>
        /// Method to change the value of Menus
        /// </summary>
        /// <param name="menu"></param>
        private void OnMenusChanged(bool menu)
        {
            if (menu)
            {
                Constraints = Constraints.Add(GraphConstraints.ContextMenu);
            }
            else
            {
                Constraints = Constraints.Remove(GraphConstraints.ContextMenu);
            }
        }

        /// <summary>
        /// Method to change the value of Zoom
        /// </summary>
        /// <param name="zoom"></param>
        private void OnZoomChanged(bool zoom)
        {
            if (zoom)
            {
                Constraints = Constraints.Add(GraphConstraints.Zoomable);
            }
            else
            {
                Constraints = Constraints.Remove(GraphConstraints.Zoomable);
            }
        }

        /// <summary>
        /// Method to change the value of Select
        /// </summary>
        /// <param name="select"></param>
        private void OnSelectChanged(bool select)
        {
            if (select)
            {
                Constraints = Constraints.Add(GraphConstraints.Selectable);
            }
            else
            {
                Constraints = Constraints.Remove(GraphConstraints.Selectable);
            }
        }

        /// <summary>
        /// Method to change the value of UndoRedo
        /// </summary>
        /// <param name="undoredo"></param>
        private void OnUndoRedoChanged(bool undoredo)
        {
            if (undoredo)
            {
                Constraints = Constraints.Add(GraphConstraints.Undoable);
            }
            else
            {
                Constraints = Constraints.Remove(GraphConstraints.Undoable);
            }
        }

        /// <summary>
        /// Method to change the value of Drag
        /// </summary>
        /// <param name="drag"></param>
        private void OnDragChanged(bool drag)
        {
            if (drag)
            {
                Constraints = Constraints.Add(GraphConstraints.Draggable);
            }
            else
            {
                Constraints = Constraints.Remove(GraphConstraints.Draggable);
            }
        }

        /// <summary>
        /// Method for ItemSelected command
        /// </summary>
        /// <param name="obj"></param>
        private void OnItemSelected(object obj)
        {
            if (first)
            {
                ((this.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection).RemoveAt(2);
                ((this.SelectedItems as SelectorViewModel).Commands as QuickCommandCollection).RemoveAt(1);
                first = false;
            }

            var args = obj as ItemSelectedEventArgs;
            if (args.Item is INode && (args.Item as INode).ID != null && (args.Item as INode).ID.Equals("Rotate"))
            {
                (this.SelectedItems as SelectorViewModel).SelectorConstraints &= ~SelectorConstraints.Rotator;
            }
            else
            {
                (this.SelectedItems as SelectorViewModel).SelectorConstraints |= SelectorConstraints.Rotator;
            }
        }

        /// <summary>
        /// Method to create Node
        /// </summary>
        /// <param name="offsetx"></param>
        /// <param name="shape"></param>
        /// <param name="annotation"></param>
        /// <param name="constraints"></param>
        private void CreateNode(double offsetx, string shape, string annotation, string constraints)
        {
            TextAnnotationViewModel anno = new TextAnnotationViewModel()
            {
                Text = annotation,
            };

            NodeViewModel node = new NodeViewModel()
            {
                OffsetX = offsetx,
                OffsetY = 250,
                UnitHeight = 100,
                UnitWidth = 100,
                Shape = resourceDictionary[shape],
                Annotations = new AnnotationCollection()
                {
                    anno,
                },
                ShapeStyle = View.Resources["DefaultStyle"] as Style,
            };
            if (constraints.Equals("Selection"))
            {
                node.Constraints = node.Constraints.Remove(NodeConstraints.Selectable);
            }
            else if (constraints.Equals("Drag"))
            {
                node.Constraints = node.Constraints.Remove(NodeConstraints.InheritDraggable);
            }
            else if (constraints.Equals("Resize"))
            {
                node.Constraints = node.Constraints.Remove(NodeConstraints.InheritResizable);
            }
            else if (constraints.Equals("Rotate"))
            {
                node.ID = "Rotate";
                node.RotateAngle = 45;
                node.Constraints = node.Constraints.Remove(NodeConstraints.InheritRotatable);
            }
            else if (constraints.Equals("Edit"))
            {
                anno.Constraints = anno.Constraints.Remove(AnnotationConstraints.InheritEditable | AnnotationConstraints.Editable);
            }
            else if (constraints.Equals("Delete"))
            {
                node.Constraints = node.Constraints.Remove(NodeConstraints.Delete);
            }

            (Nodes as NodeCollection).Add(node);
        }

        private void CreateNodeforLabel(string shape, string label)
        {
            NodeViewModel node = new NodeViewModel()
            {
                UnitHeight = 60,
                UnitWidth = 1100,
                ContentTemplate = View.Resources[label] as DataTemplate,
                Constraints = NodeConstraints.Default & ~NodeConstraints.Selectable & ~NodeConstraints.ThemeStyle,
                Shape = resourceDictionary[shape],
                OffsetX = 650,
                ShapeStyle = View.Resources["ConstraintsNodeStyle"] as Style,
            };
            if (label == "Node")
            {
                node.OffsetY = 150;
            }
            else
            {
                node.OffsetY = 450;
            }

            (Nodes as NodeCollection).Add(node);
        }

        #endregion
    }
}
