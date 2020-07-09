#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserInteraction_DrawingTools
{
    public class DrawingTools : DiagramViewModel
    {
        #region fields

        string ShapeName = "Rectangle";

        public ICommand SelectShapeCommand { get; set; }

        public ICommand ContiniousDrawCommand { get; set; }

        public Button prevbutton = null;

        #endregion

        #region Constructor

        public DrawingTools()
        {
            this.Nodes = new NodeCollection();
            this.Connectors = new ConnectorCollection();
            this.DrawingTool = DrawingTool.Node;
            this.Tool = Tool.ContinuesDraw;
            this.SelectedItems = new SelectorViewModel()
            {
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.QuickCommands,
            };
            this.GetDrawTypeCommand = new Command(OnGetDrawTypeCommandExecute);
            this.ItemUnSelectedCommand = new Command(OnItemUnSelectedCommandExecute);
            this.HorizontalRuler = new Ruler();
            this.VerticalRuler = new Ruler()
            {
                Orientation = Orientation.Vertical
            };
            this.SnapSettings = new SnapSettings()
            {
                SnapConstraints = SnapConstraints.All,
            };

            SelectShapeCommand = new Command(OnSelectShapeCommandExecute);

            ContiniousDrawCommand = new Command(OnContiniousDrawCommandExecute);
        }

        #endregion

        #region Helper Methods
        private void OnItemUnSelectedCommandExecute(object parameter)
        {
           if ((parameter as DiagramEventArgs).Item is INode)
            {
                foreach (IAnnotation annotation in ((parameter as DiagramEventArgs).Item as INode).Annotations as IEnumerable<object>)
                {
                    if (annotation.Content != null)
                    {
                        if (string.IsNullOrEmpty(annotation.Content.ToString()))
                        {
                            (this.Nodes as ObservableCollection<NodeViewModel>).Remove((parameter as DiagramEventArgs).Item as NodeViewModel);
                            break;
                        }
                    }
                }
            }
        }

        private void OnGetDrawTypeCommandExecute(object parameter)
        {
            if (ShapeName.Equals("Rectangle"))
            {
                (parameter as DrawTypeEventArgs).DrawItem = new System.Windows.Shapes.Rectangle() { StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White), Stretch = Stretch.Fill };
            }
            else if (ShapeName.Equals("Circle"))
            {
                (parameter as DrawTypeEventArgs).DrawItem = new System.Windows.Shapes.Ellipse() { StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White) };
            }
            else if (ShapeName.Equals("Pentagon"))
            {
                (parameter as DrawTypeEventArgs).DrawItem = new Path() {Stretch= Stretch.Fill, Data = Geometry.Parse("M370.9702,194.9961L359.5112,159.7291L389.5112,137.9341L419.5112,159.7291L408.0522,194.9961L370.9702,194.9961z"), StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White) };
            }
            else if (ShapeName.Equals("Hexagon"))
            {
                (parameter as DrawTypeEventArgs).DrawItem = new Path() { Stretch = Stretch.Fill, Data = Geometry.Parse("M165.5,-1.50000000000001L-2.5,213 167,444 444.5,442.5 621.5,214.5 438.5,-1.50000000000002z"), StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White) };
            }
            else if (ShapeName.Equals("Triangle"))
            {
                (parameter as DrawTypeEventArgs).DrawItem = new Path() { Stretch = Stretch.Fill, Data = Geometry.Parse("M81.1582,85.8677L111.1582,33.9067L141.1582,85.8677L81.1582,85.8677z"), StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White) };
            }
            else if (ShapeName.Equals("Star"))
            {
                (parameter as DrawTypeEventArgs).DrawItem = new Path() { Stretch = Stretch.Fill, Data = Geometry.Parse("M230,712.7559L233.314,723.9179L244.46,723.7749L235.362,730.5289L238.937,741.6029L230,734.6149L221.063,741.6029L224.638,730.5289L215.54,723.7749L226.686,723.9179L230,712.7559z"), StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White) };
            }
            else if (ShapeName.Equals("TextBox"))
            {
                NodeViewModel node = new NodeViewModel();
                node.UnitWidth = 10;
                node.UnitHeight = 10;
                node.Annotations = new AnnotationCollection()
                {
                    new AnnotationEditorViewModel()
                    {
                        Mode = ContentEditorMode.Edit,
                        UnitHeight = 100,
                        UnitWidth = 100,
                        Content = "",
                    }
                };
                (parameter as DrawTypeEventArgs).DrawItem = node;
            }
            else if (ShapeName.Equals("User"))
            {
                Image image = new Image();
                image.Stretch = Stretch.Fill;
                image.StretchDirection = StretchDirection.Both;
                image.Source = App.Current.Resources["UserImage"] as BitmapImage;
                (parameter as DrawTypeEventArgs).DrawItem = image;
            }
            else if (ShapeName.Equals("SVG"))
            {
                NodeViewModel node = new NodeViewModel();
                node.ContentTemplate = App.Current.Resources["ContentTemplateforNodeContent"] as DataTemplate;
                (parameter as DrawTypeEventArgs).DrawItem = node;
            }
        }

        private void OnSelectShapeCommandExecute(object obj)
        {
            Button button = obj as Button;

            this.ShapeName = button.Name.ToString();

            if (prevbutton != null)
            {
                prevbutton.Style = Application.Current.Resources["ButtonStyle"] as Style;
            }
            button.Style = Application.Current.Resources["SelectedButtonStyle"] as Style;

            if (this.Tool == Tool.MultipleSelect)
            {
                this.Tool |= Tool.DrawOnce;
            }

            if (ShapeName.Equals("StraightConnector"))
            {
                this.DefaultConnectorType = ConnectorType.Line;
                this.DrawingTool = DrawingTool.Connector;
            }
            else if (ShapeName.Equals("OrthogonalConnector"))
            {
                this.DefaultConnectorType = ConnectorType.Orthogonal;
                this.DrawingTool = DrawingTool.Connector;
            }
            else if (ShapeName.Equals("BezierConnector"))
            {
                this.DefaultConnectorType = ConnectorType.CubicBezier;
                this.DrawingTool = DrawingTool.Connector;
            }
            else if (ShapeName.Equals("polyLine"))
            {
                this.DefaultConnectorType = ConnectorType.PolyLine;
                this.DrawingTool = DrawingTool.Connector;
            }
            else if (ShapeName.Equals("freeHand"))
            {
                this.DrawingTool = DrawingTool.FreeHand;
                this.DefaultConnectorType = ConnectorType.Orthogonal;
            }
            else
            {
                this.DrawingTool = DrawingTool.Node;
                this.DefaultConnectorType = ConnectorType.Orthogonal;
            }

            prevbutton = obj as Button;
        }

        private void OnContiniousDrawCommandExecute(object parameter)
        {
            if (this != null)
            {
                if ((bool)parameter)
                {
                    this.Tool = Tool.ContinuesDraw;
                }
                else
                {
                    this.Tool = Tool.MultipleSelect | Tool.DrawOnce;
                }
            }
        }

        #endregion
    }
}
