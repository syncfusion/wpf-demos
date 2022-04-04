#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class DrawingToolsViewModel : DiagramViewModel
    {
        #region fields

        bool isContinousDrawEnabled = true;
        string selectedShape = "Rectangle";
        ToggleButton selectedButton = null;

        #endregion

        public DemoControl View;

        public bool IsContinousDrawEnabled
        {
            get { return isContinousDrawEnabled; }
            set
            {
                if (isContinousDrawEnabled != value)
                {
                    isContinousDrawEnabled = value;
                    this.OnPropertyChanged("IsContinousDrawEnabled");
                }
            }
        }

        public string SelectedShape
        {
            get { return selectedShape; }
            set
            {
                if (selectedShape != value)
                {
                    selectedShape = value;
                    this.OnPropertyChanged("SelectedShape");
                }
            }
        }

        public ToggleButton SelectedButton
        {
            get
            {
                return selectedButton;
            }
            set
            {
                if (value != null)
                {
                    if (selectedButton != null)
                    {
                        selectedButton.IsChecked = false;
                    }

                    selectedButton = value;
                    SelectedShape = selectedButton.Name;
                }
            }
        }


        #region Constructor

        public DrawingToolsViewModel(DemoControl demo)
        {
            View = demo;
            this.Nodes = new NodeCollection();
            this.Connectors = new ConnectorCollection();
            this.DrawingTool = DrawingTool.Rectangle;
            this.Tool = Tool.ContinuesDraw;
            this.SelectedItems = new SelectorViewModel()
            {
                SelectorConstraints = SelectorConstraints.Default & ~SelectorConstraints.QuickCommands,
            };

            this.GetDrawTypeCommand = new DelegateCommand(OnGetDrawTypeCommandExecute);
            this.ItemAddedCommand = new DelegateCommand(OnItemAddedCommandExecute);
        }

        #endregion

        #region Helper Methods

        private void OnItemAddedCommandExecute(object parameter)
        {
            if ((parameter as ItemAddedEventArgs).ItemSource == ItemSource.ClipBoard)
            {
                if ((parameter as ItemAddedEventArgs).Item is INode)
                {
                    if (((parameter as ItemAddedEventArgs).Item as INode).Name.Equals("Pentagon"))
                    {
                        ((parameter as ItemAddedEventArgs).Item as INode).Shape = View.Resources["Pentagon"];
                    }
                    else if (((parameter as ItemAddedEventArgs).Item as INode).Name.Equals("Hexagon"))
                    {
                        ((parameter as ItemAddedEventArgs).Item as INode).Shape = View.Resources["Hexagon"];
                    }
                    else if (((parameter as ItemAddedEventArgs).Item as INode).Name.Equals("Triangle"))
                    {
                        ((parameter as ItemAddedEventArgs).Item as INode).Shape = View.Resources["Triangle"];
                    }
                    else if (((parameter as ItemAddedEventArgs).Item as INode).Name.Equals("Star"))
                    {
                        ((parameter as ItemAddedEventArgs).Item as INode).Shape = View.Resources["FivePointStar"];
                    }
                    else if (((parameter as ItemAddedEventArgs).Item as INode).Name.Equals("User"))
                    {
                        ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = View.Resources["ImageNode"] as DataTemplate; 
                    }
                    else if (((parameter as ItemAddedEventArgs).Item as INode).Name.Equals("SVG"))
                    {
                        ((parameter as ItemAddedEventArgs).Item as INode).ContentTemplate = View.Resources["ContentTemplateforNodeContent"] as DataTemplate;
                    }
                }
            }
            else
            {
                if (selectedShape.Equals("Pentagon"))
                {
                    ((parameter as ItemAddedEventArgs).Item as INode).Name = "Pentagon";
                }
                else if (selectedShape.Equals("Triangle"))
                {
                    ((parameter as ItemAddedEventArgs).Item as INode).Name = "Triangle";
                }
                else if (selectedShape.Equals("Hexagon"))
                {
                    ((parameter as ItemAddedEventArgs).Item as INode).Name = "Hexagon";
                }
                else if (selectedShape.Equals("Star"))
                {
                    ((parameter as ItemAddedEventArgs).Item as INode).Name = "Star";
                }
                else if (selectedShape.Equals("User"))
                {
                    ((parameter as ItemAddedEventArgs).Item as INode).Name = "User";
                }
                else if (selectedShape.Equals("SVG"))
                {
                    ((parameter as ItemAddedEventArgs).Item as INode).Name = "SVG";
                }
            }
        }

        private void OnGetDrawTypeCommandExecute(object parameter)
        {
            if (selectedShape.Equals("Pentagon"))
            {
                (parameter as DrawTypeEventArgs).DrawItem = new Path() { Stretch = Stretch.Fill, Data = Geometry.Parse("M370.9702,194.9961L359.5112,159.7291L389.5112,137.9341L419.5112,159.7291L408.0522,194.9961L370.9702,194.9961z"), StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White) };
            }
            else if (selectedShape.Equals("Hexagon"))
            {
                (parameter as DrawTypeEventArgs).DrawItem = new Path() { Stretch = Stretch.Fill, Data = Geometry.Parse("M165.5,-1.50000000000001L-2.5,213 167,444 444.5,442.5 621.5,214.5 438.5,-1.50000000000002z"), StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White) };
            }
            else if (selectedShape.Equals("Triangle"))
            {
                (parameter as DrawTypeEventArgs).DrawItem = new Path() { Stretch = Stretch.Fill, Data = Geometry.Parse("M81.1582,85.8677L111.1582,33.9067L141.1582,85.8677L81.1582,85.8677z"), StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White) };
            }
            else if (selectedShape.Equals("Star"))
            {
                (parameter as DrawTypeEventArgs).DrawItem = new Path() { Stretch = Stretch.Fill, Data = Geometry.Parse("M230,712.7559L233.314,723.9179L244.46,723.7749L235.362,730.5289L238.937,741.6029L230,734.6149L221.063,741.6029L224.638,730.5289L215.54,723.7749L226.686,723.9179L230,712.7559z"), StrokeThickness = 1.0, Stroke = new SolidColorBrush(Colors.Black), Fill = new SolidColorBrush(Colors.White) };
            }
            else if (selectedShape.Equals("User"))
            {
                Image image = new Image();
                image.Stretch = Stretch.Fill;
                image.StretchDirection = StretchDirection.Both;
                image.Source = View.Resources["UserImage"] as BitmapImage;
                (parameter as DrawTypeEventArgs).DrawItem = image;
            }
            else if (selectedShape.Equals("SVG"))
            {
                NodeViewModel node = new NodeViewModel();
                node.ContentTemplate = View.Resources["ContentTemplateforNodeContent"] as DataTemplate;
                (parameter as DrawTypeEventArgs).DrawItem = node;
            }
        }

        #endregion
    }
}
