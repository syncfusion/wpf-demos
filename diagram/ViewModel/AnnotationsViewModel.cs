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
using Syncfusion.Windows.Tools.Controls;
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

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class AnnotationsViewModel : DiagramViewModel
    {
        #region fields

        private bool first = true;

        //To hold the text color of the annotation.
        private Brush textColor = new SolidColorBrush(Colors.Black);

        //To hold the font family of the annotation.
        private FontFamily fontFamily = new FontFamily("Calibri");

        //To hold the font size of the annotation.
        private double textSize = 13;

        //To hold the text wrap value of the annotation.
        private TextWrapping textWrapValue = TextWrapping.NoWrap;

        //To hold the text trimming value of the annotation.
        private TextTrimming textTrimmingValue = TextTrimming.None;

        //To hold the name of the button in the propery panel.
        string ShapeName = "Center";

        //To hold the instance of the button.
        public Button prevbutton = null;

        //To hold the command for selecting font style
        public ICommand SelectFontStyleCommand { get; set; }

        //To hold the command for changing the selected shape 
        public ICommand SelectShapeCommand { get; set; }

        //To hold the command for changing view mode.
        public ICommand ViewModeCommand { get; set; }

        //To hold the command for enabling annotation
        public ICommand LabelInteractionCommand { get; set; }

        //To hold the text decoration value of the annotation
        public TextDecorationCollection Decoration;

        //To hold the stroke through value of the text
        public bool strikeFlag = false;

        //To hold the under line value of the text
        public bool underLineFlag = false;

        /// <summary>
        /// Gets or sets the text color of the annotation.
        /// </summary>
        public Brush Textcolor
        {
            get
            {
                return textColor;
            }

            set
            {
                if (textColor != value)
                {
                    textColor = value;
                    OnPropertyChanged("Textcolor");
                    OnTextColorChanged(textColor);
                }
            }
        }

        /// <summary>
        /// Gets or sets the font family value.
        /// </summary>
        public FontFamily FontFamilyValue
        {
            get
            {
                return fontFamily;
            }

            set
            {
                if (fontFamily != value)
                {
                    fontFamily = value;
                    OnPropertyChanged("FontFamilyValue");
                    OnFontFamilyChanged(fontFamily);
                }
            }
        }

        /// <summary>
        /// Gets or sets the text size of he annotation.
        /// </summary>
        public double TextSize
        {
            get
            {
                return textSize;
            }
            set
            {
                if (textSize != value)
                {
                    textSize = value;
                    OnPropertyChanged("TextSize");
                    OnFontSizeChanged(textSize);
                }
            }
        }

        /// <summary>
        /// Gets or sets the text wrap value of the annotation
        /// </summary>
        public TextWrapping TextWrapValue
        {
            get
            {
                return textWrapValue;
            }
            set
            {
                if (textWrapValue != value)
                {
                    textWrapValue = value;
                    OnPropertyChanged("TextWrapValue");
                    OnTextWrappingChanged(textWrapValue);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Text TrimmingValue of the annotation.
        /// </summary>
        public TextTrimming TextTrimmingValue
        {
            get
            {
                return textTrimmingValue;
            }
            set
            {
                if (textTrimmingValue != value)
                {
                    textTrimmingValue = value;
                    OnPropertyChanged("TextTrimmingValue");
                    OnTextTrimmingChanged(textTrimmingValue);
                }
            }
        }

        #endregion

        public DemoControl View;

        #region Constructor
        public AnnotationsViewModel()
        {
            this.Nodes = new ObservableCollection<NodeViewModel>();
            this.Connectors = new ObservableCollection<ConnectorViewModel>();           

            this.PortVisibility = PortVisibility.Collapse;

            //Create Node
            NodeViewModel newProject = CreateNode(130, 40, 450, 80, "Terminator", "New Project");
            NodeViewModel design = CreateNode(130, 40, 450, 160, "Rectangle", "Project planning and designing");
            NodeViewModel coding = CreateNode(130, 40, 450, 250, "Rectangle", "Coding");
            NodeViewModel testing = CreateNode(130, 40, 450, 360, "Rectangle", "Testing");
            NodeViewModel errors = CreateNode(200, 50, 450, 470, "Decision", "Is Errors?");
            NodeViewModel completed = CreateNode(130, 40, 450, 570, "Terminator", "Project Completed");
            newProject.IsSelected = true;

            //Create the node ports
            CreateNodePort(design, "designPort", 0, 0.5);
            CreateNodePort(coding, "codingPort", 1, 0.5);
            CreateNodePort(errors, "errorsPort2", 1, 0.5);
            CreateNodePort(errors, "errorsPort1", 0, 0.5);

            //Add nodes into collection
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(newProject);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(design);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(coding);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(testing);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(errors);
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(completed);

            //Create the connectors
            ConnectorViewModel connector1 = CreateConnector(newProject, design, "", null, null);
            ConnectorViewModel connector2 = CreateConnector(design, coding, "", null, null);
            ConnectorViewModel connector3 = CreateConnector(coding, testing, "Coding completed", null, null);
            ConnectorViewModel connector4 = CreateConnector(testing, errors, "Testing completed", null, null);
            ConnectorViewModel connector5 = CreateConnector(errors, completed, "No Errors", null, null);
            ConnectorViewModel connector6 = CreateConnector(errors, coding, "Coding errors", "errorsPort2", "codingPort");
            ConnectorViewModel connector7 = CreateConnector(errors, design, "Design errors", "errorsPort1", "designPort");

            //Add the connectors into connectors collection
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector1);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector2);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector3);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector4);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector5);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector6);
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector7);

            this.SelectedItems = new SelectorViewModel();
            (this.SelectedItems as SelectorViewModel).SelectorConstraints &= ~(SelectorConstraints.QuickCommands);
            SelectShapeCommand = new DelegateCommand(OnSelectShapeCommandExecute);
            ViewModeCommand = new DelegateCommand(OnViewModeCommandExecute);
            LabelInteractionCommand = new DelegateCommand(OnLabelInteractionCommandExecute);
            SelectFontStyleCommand = new DelegateCommand(OnSelectFontStyleCommandExecute);
            this.ItemSelectedCommand = new DelegateCommand(OnItemSelectedCommandExecute);
            this.ViewPortChangedCommand = new DelegateCommand(OnViewPortChangedCommandExecute);
        }
        #endregion

        #region helper methods

        /// <summary>
        /// Method to change the font size of the annotation
        /// </summary>
        /// <param name="value"></param>
        private void OnFontSizeChanged(double value)
        {
            double val = value;
            foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
            {
                foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                {
                    (annotation as TextAnnotationViewModel).FontSize = val;
                }
            }
            foreach (ConnectorViewModel conn in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
            {
                foreach (IAnnotation annotation in conn.Annotations as ObservableCollection<IAnnotation>)
                {
                    (annotation as TextAnnotationViewModel).FontSize = val;
                }
            }
        }

        /// <summary>
        /// Creates the node ports.
        /// </summary>
        /// <param name="node1">node</param>
        /// <param name="id">ID of the port</param>
        /// <param name="nodeoffsetx">offset x value of port</param>
        /// <param name="nodeoffsety">offset y value of port</param>
        private void CreateNodePort(NodeViewModel node1, string id, double nodeoffsetx, double nodeoffsety)
        {
            NodePortViewModel nodePort = new NodePortViewModel()
            {
                ID = id,
                NodeOffsetX = nodeoffsetx,
                NodeOffsetY = nodeoffsety,
                PortVisibility = PortVisibility.Visible,
            };

            (node1.Ports as PortCollection).Add(nodePort);
        }

        /// <summary>
        /// Method to change the text trimming value of the annotation.
        /// </summary>
        /// <param name="value"></param>
        private void OnTextTrimmingChanged(TextTrimming value)
        {
            foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
            {
                foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                {
                    (annotation as TextAnnotationViewModel).TextTrimming = value;

                    if (value != TextTrimming.None && (annotation as TextAnnotationViewModel).TextWrapping == TextWrapping.NoWrap)
                    {
                        annotation.UnitWidth = 100;
                    }
                    else
                    {
                        annotation.UnitWidth = double.NaN;
                    }
                }
            }
            foreach (ConnectorViewModel conn in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
            {
                foreach (IAnnotation annotation in conn.Annotations as ObservableCollection<IAnnotation>)
                {
                    (annotation as TextAnnotationViewModel).TextTrimming = value;
                    if (value != TextTrimming.None && (annotation as TextAnnotationViewModel).TextWrapping == TextWrapping.NoWrap)
                    {
                        annotation.UnitWidth = 100;
                    }
                    else
                    {
                        annotation.UnitWidth = double.NaN;
                    }
                }
            }
        }

        /// <summary>
        /// Method to change the text wrapping value of the annotation
        /// </summary>
        /// <param name="value">Text wrapping value</param>
        private void OnTextWrappingChanged(TextWrapping value)
        {
            foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
            {
                foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                {
                    (annotation as TextAnnotationViewModel).TextWrapping = value;

                    if ((annotation as TextAnnotationViewModel).TextTrimming != TextTrimming.None && value == TextWrapping.NoWrap)
                    {
                        annotation.UnitWidth = 100;
                    }
                    else
                    {
                        annotation.UnitWidth = double.NaN;
                    }
                }
            }
            foreach (ConnectorViewModel conn in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
            {
                foreach (IAnnotation annotation in conn.Annotations as ObservableCollection<IAnnotation>)
                {
                    (annotation as TextAnnotationViewModel).TextWrapping = value;

                    if ((annotation as TextAnnotationViewModel).TextTrimming != TextTrimming.None && value == TextWrapping.NoWrap)
                    {
                        annotation.UnitWidth = 100;
                    }
                    else
                    {
                        annotation.UnitWidth = double.NaN;
                    }
                }
            }
        }

        /// <summary>
        /// To change the font family of the annotation
        /// </summary>
        /// <param name="val">Font family value.</param>
        private void OnFontFamilyChanged(FontFamily val)
        {
            string value = val.ToString();
            foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
            {
                foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                {
                    (annotation as TextAnnotationViewModel).FontFamily = new FontFamily(value);
                }
            }
            foreach (ConnectorViewModel conn in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
            {
                foreach (IAnnotation annotation in conn.Annotations as ObservableCollection<IAnnotation>)
                {
                    (annotation as TextAnnotationViewModel).FontFamily = new FontFamily(value);
                }
            }
        }


        /// <summary>
        /// To change the font style value of the annotation
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        private void OnSelectFontStyleCommandExecute(object parameter)
        {
            RibbonButton button = parameter as RibbonButton;

            string fontStyleName = button.Name.ToString();

            if (fontStyleName.Equals("bold"))
            {
                foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                    {
                        if ((annotation as TextAnnotationViewModel).FontWeight == FontWeights.Bold)
                        {
                            (annotation as TextAnnotationViewModel).FontWeight = FontWeights.Normal;
                            button.Background = new SolidColorBrush(Colors.Transparent);
                        }
                        else
                        {
                            (annotation as TextAnnotationViewModel).FontWeight = FontWeights.Bold;
                            button.Background = new SolidColorBrush(Colors.LightBlue);
                        }
                    }
                }
                foreach (ConnectorViewModel conn in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in conn.Annotations as ObservableCollection<IAnnotation>)
                    {
                        if ((annotation as TextAnnotationViewModel).FontWeight == FontWeights.Bold)
                        {
                            (annotation as TextAnnotationViewModel).FontWeight = FontWeights.Normal;
                            button.Background = new SolidColorBrush(Colors.Transparent);
                        }
                        else
                        {
                            (annotation as TextAnnotationViewModel).FontWeight = FontWeights.Bold;
                            button.Background = new SolidColorBrush(Colors.LightBlue);
                        }
                    }
                }
            }
            else if (fontStyleName.Equals("italic"))
            {
                foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                    {
                        if ((annotation as TextAnnotationViewModel).FontStyle == FontStyles.Italic)
                        {
                            (annotation as TextAnnotationViewModel).FontStyle = FontStyles.Normal;
                            button.Background = new SolidColorBrush(Colors.Transparent);
                        }
                        else
                        {
                            (annotation as TextAnnotationViewModel).FontStyle = FontStyles.Italic;
                            button.Background = new SolidColorBrush(Colors.LightBlue);
                        }
                    }
                }
                foreach (ConnectorViewModel conn in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in conn.Annotations as ObservableCollection<IAnnotation>)
                    {
                        if ((annotation as TextAnnotationViewModel).FontStyle == FontStyles.Italic)
                        {
                            (annotation as TextAnnotationViewModel).FontStyle = FontStyles.Normal;
                            button.Background = new SolidColorBrush(Colors.Transparent);
                        }
                        else
                        {
                            (annotation as TextAnnotationViewModel).FontStyle = FontStyles.Italic;
                            button.Background = new SolidColorBrush(Colors.LightBlue);
                        }
                    }
                }
            }
            else if (fontStyleName.Equals("underline"))
            {
                if (underLineFlag)
                {
                    button.Background = new SolidColorBrush(Colors.Transparent);
                    underLineFlag = false;
                }
                else
                {
                    button.Background = new SolidColorBrush(Colors.LightBlue);
                    underLineFlag = true;
                }

                this.OnUnderLineChanged(underLineFlag);
            }
            else if (fontStyleName.Equals("Strike"))
            {
                if (strikeFlag)
                {
                    button.Background = new SolidColorBrush(Colors.Transparent);
                    strikeFlag = false;
                }
                else
                {
                    button.Background = new SolidColorBrush(Colors.LightBlue);
                    strikeFlag = true;
                }

                this.OnStrikeChanged(strikeFlag);
            }
        }

        /// <summary>
        /// To change the under line value of the annotation
        /// </summary>
        /// <param name="UnderLine">Boolean value</param>
        private void OnUnderLineChanged(bool UnderLine)
        {
            if (UnderLine)
            {
                if (Decoration == null)
                {
                    Decoration = new TextDecorationCollection();
                    Decoration.Add(TextDecorations.Underline);
                }
                else
                {
                    Decoration = new TextDecorationCollection();
                    Decoration.Add(TextDecorations.Strikethrough);
                    Decoration.Add(TextDecorations.Underline);
                }
            }
            else
            {
                if (Decoration != null && Decoration.Contains(TextDecorations.Strikethrough[0]))
                {
                    Decoration = new TextDecorationCollection();
                    Decoration.Add(TextDecorations.Strikethrough);
                }
                else
                    Decoration = null;
            }

            this.SetTextDecorations();
        }

        /// <summary>
        /// To change the under line value of the annotation
        /// </summary>
        /// <param name="Strike">Boolean value</param>
        private void OnStrikeChanged(bool Strike)
        {
            if (Strike)
            {
                if (Decoration == null)
                {
                    Decoration = new TextDecorationCollection();
                    Decoration.Add(TextDecorations.Strikethrough);
                }
                else
                {
                    Decoration = new TextDecorationCollection();
                    Decoration.Add(TextDecorations.Strikethrough);
                    Decoration.Add(TextDecorations.Underline);
                }
            }
            else
            {
                if (Decoration != null && Decoration.Contains(TextDecorations.Underline[0]))
                {
                    Decoration = new TextDecorationCollection();
                    Decoration.Add(TextDecorations.Underline);
                }
                else
                    Decoration = null;
            }
            this.SetTextDecorations();
        }

        /// <summary>
        /// To update the text decoration value to the annotation.
        /// </summary>
        private void SetTextDecorations()
        {
            foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
            {
                foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                {
                    (annotation as TextAnnotationViewModel).TextDecorations = Decoration;
                }
            }
            foreach (ConnectorViewModel conn in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
            {
                foreach (IAnnotation annotation in conn.Annotations as ObservableCollection<IAnnotation>)
                {
                    (annotation as TextAnnotationViewModel).TextDecorations = Decoration;
                }
            }
        }

        /// <summary>
        /// To enable or disable the annotation selection
        /// </summary>
        /// <param name="parameter">Command parameter value.</param>
        private void OnLabelInteractionCommandExecute(object parameter)
        {
            if (this != null)
            {
                if ((bool)parameter)
                {
                    foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                    {
                        foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                        {
                            annotation.Constraints &= ~(AnnotationConstraints.InheritResizable | AnnotationConstraints.InheritRotatable | AnnotationConstraints.InheritDraggable | AnnotationConstraints.InheritSelectable);
                            annotation.Constraints |= AnnotationConstraints.Resizable | AnnotationConstraints.Rotatable | AnnotationConstraints.Draggable | AnnotationConstraints.Selectable;
                        }
                    }
                    foreach (ConnectorViewModel conn in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                    {
                        foreach (IAnnotation annotation in conn.Annotations as ObservableCollection<IAnnotation>)
                        {
                            annotation.Constraints &= ~(AnnotationConstraints.InheritResizable | AnnotationConstraints.InheritRotatable | AnnotationConstraints.InheritDraggable | AnnotationConstraints.InheritSelectable);
                            annotation.Constraints |= AnnotationConstraints.Resizable | AnnotationConstraints.Rotatable | AnnotationConstraints.Draggable | AnnotationConstraints.Selectable;
                        }
                    }
                }
                else
                {
                    foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                    {
                        foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                        {
                            annotation.Constraints = AnnotationConstraints.Default;
                        }
                    }
                    foreach (ConnectorViewModel conn in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                    {
                        foreach (IAnnotation annotation in conn.Annotations as ObservableCollection<IAnnotation>)
                        {
                            annotation.Constraints = AnnotationConstraints.Default;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// To update the view mode and edit mode value to the annotation.
        /// </summary>
        /// <param name="parameter">Command parameter value</param>
        private void OnViewModeCommandExecute(object parameter)
        {
            if (this != null)
            {
                if ((bool)parameter)
                {
                    foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                    {
                        foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                        {
                            annotation.ReadOnly = true;
                        }
                    }
                    foreach (ConnectorViewModel conn in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                    {
                        foreach (IAnnotation annotation in conn.Annotations as ObservableCollection<IAnnotation>)
                        {
                            annotation.ReadOnly = true;
                        }
                    }
                }
                else
                {
                    foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                    {
                        foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                        {
                            annotation.ReadOnly = false;
                        }
                    }
                    foreach (ConnectorViewModel conn in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                    {
                        foreach (IAnnotation annotation in conn.Annotations as ObservableCollection<IAnnotation>)
                        {
                            annotation.ReadOnly = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// To update the annotation position.
        /// </summary>
        /// <param name="parameter">Command parameter value.</param>
        private void OnSelectShapeCommandExecute(object parameter)
        {
            Button button = parameter as Button;

            this.ShapeName = button.Name.ToString();

            if (prevbutton != null)
            {
                prevbutton.Style = View.Resources["AnnotationsButtonStyle"] as Style;
            }
            button.Style = View.Resources["AnnotationsSelectedButtonStyle"] as Style;

            if (ShapeName.Equals("Center"))
            {
                foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                {
                    foreach (TextAnnotationViewModel annotation in node.Annotations as ObservableCollection<IAnnotation>)
                    {
                        annotation.Offset = new Point(0.5, 0.5);
                        annotation.Margin = new Thickness(0);
                        annotation.VerticalAlignment = VerticalAlignment.Center;
                        annotation.HorizontalAlignment = HorizontalAlignment.Center;
                    }
                }
            }
            else if (ShapeName.Equals("TopLeft"))
            {
                foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                {
                    foreach (TextAnnotationViewModel annotation in node.Annotations as ObservableCollection<IAnnotation>)
                    {
                        annotation.Offset = new Point(0, 0);
                        annotation.VerticalAlignment = VerticalAlignment.Top;
                        annotation.HorizontalAlignment = HorizontalAlignment.Left;
                    }
                }
            }
            else if (ShapeName.Equals("TopRight"))
            {
                foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                {
                    foreach (TextAnnotationViewModel annotation in node.Annotations as ObservableCollection<IAnnotation>)
                    {
                        annotation.Offset = new Point(1, 0);
                        annotation.VerticalAlignment = VerticalAlignment.Top;
                        annotation.HorizontalAlignment = HorizontalAlignment.Right;
                    }
                }
            }
            else if (ShapeName.Equals("BottomLeft"))
            {
                foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                {
                    foreach (TextAnnotationViewModel annotation in node.Annotations as ObservableCollection<IAnnotation>)
                    {
                        annotation.Offset = new Point(0, 1);
                        annotation.VerticalAlignment = VerticalAlignment.Bottom;
                        annotation.HorizontalAlignment = HorizontalAlignment.Left;
                    }
                }
            }
            else if (ShapeName.Equals("BottomRight"))
            {
                foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                {
                    foreach (TextAnnotationViewModel annotation in node.Annotations as ObservableCollection<IAnnotation>)
                    {
                        annotation.Offset = new Point(1, 1);
                        annotation.VerticalAlignment = VerticalAlignment.Bottom;
                        annotation.HorizontalAlignment = HorizontalAlignment.Right;
                    }
                }
            }
            else if (ShapeName.Equals("MarginText"))
            {
                foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
                {
                    foreach (TextAnnotationViewModel annotation in node.Annotations as ObservableCollection<IAnnotation>)
                    {
                        annotation.Offset = new Point(0.5, 1);
                        annotation.Margin = new Thickness(0, 10, 0, 0);
                        annotation.VerticalAlignment = VerticalAlignment.Center;
                        annotation.HorizontalAlignment = HorizontalAlignment.Center;
                    }
                }
            }
            else if (ShapeName.Equals("SourceText"))
            {
                foreach (ConnectorViewModel node in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                    {
                        annotation.Length = 0;
                        annotation.Margin = new Thickness(0, 0, 0, 0);
                    }
                }
            }
            else if (ShapeName.Equals("TargetText"))
            {
                foreach (ConnectorViewModel node in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                    {
                        annotation.Length = 1;
                        annotation.Margin = new Thickness(0, 0, 0, 0);
                    }
                }
            }
            else if (ShapeName.Equals("AboveCenter"))
            {
                foreach (ConnectorViewModel node in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                    {
                        annotation.Length = 0.5;
                        annotation.Margin = new Thickness(0, -10, 0, 0);
                    }
                }
            }
            else if (ShapeName.Equals("BelowCenter"))
            {
                foreach (ConnectorViewModel node in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                    {
                        annotation.Length = 0.5;
                        annotation.Margin = new Thickness(0, 10, 0, 0);
                    }
                }
            }
            else if (ShapeName.Equals("CenterText"))
            {
                foreach (ConnectorViewModel node in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                    {
                        annotation.Length = 0.5;
                        annotation.Margin = new Thickness(0, 0, 0, 0);
                    }
                }
            }

            prevbutton = parameter as Button;
        }

        /// <summary>
        /// Method to change the text color of the annotation
        /// </summary>
        /// <param name="fillcolor">text color</param>
        private void OnTextColorChanged(Brush fillcolor)
        {
            Brush value = fillcolor;
            foreach (NodeViewModel node in (this.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>)
            {
                foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                {
                    (annotation as TextAnnotationViewModel).Foreground = value;
                }
            }
            foreach (ConnectorViewModel conn in (this.SelectedItems as SelectorViewModel).Connectors as IEnumerable<object>)
            {
                foreach (IAnnotation annotation in conn.Annotations as ObservableCollection<IAnnotation>)
                {
                    (annotation as TextAnnotationViewModel).Foreground = value;
                }
            }
        }

        /// <summary>
        /// To create the nodes.
        /// </summary>
        /// <param name="unitWidth">Width of the node</param>
        /// <param name="unitHeight">height of the node</param>
        /// <param name="offsetx">Offset x value</param>
        /// <param name="offsety">offset y value</param>
        /// <param name="shape">shape of the node</param>
        /// <param name="text">Text of the annotation</param>
        /// <returns>Returns the node</returns>
        private NodeViewModel CreateNode(double unitWidth, double unitHeight, double offsetx, double offsety, string shape, string text)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
            };

            NodeViewModel node = new NodeViewModel()
            {
                UnitWidth = unitWidth,
                UnitHeight = unitHeight,
                OffsetX = offsetx,
                OffsetY = offsety,
                Shape = resourceDictionary[shape],
                Annotations = new ObservableCollection<IAnnotation>()
                {
                   new TextAnnotationViewModel()
                   {
                       Text = text,
                       FontSize = 13,
                       TextWrapping = TextWrapping.Wrap,
                       FontWeight = FontWeights.Bold,
                   },
                }
            };

            return node;
        }

        /// <summary>
        /// To create the connector.
        /// </summary>
        /// <param name="sourceNode">Source node of the connector</param>
        /// <param name="targetNode">Target node of the connector.</param>
        /// <param name="text">Text to the connector.</param>
        /// <param name="sourcePort">Source port of the connector</param>
        /// <param name="targetPort">Target port of the connector</param>
        /// <returns></returns>
        private ConnectorViewModel CreateConnector(NodeViewModel sourceNode, NodeViewModel targetNode, string text,
            string sourcePort, string targetPort)
        {
            ConnectorViewModel connector = new ConnectorViewModel()
            {
                SourceNode = sourceNode,
                TargetNode = targetNode,
                SourcePortID = sourcePort,
                TargetPortID = targetPort,
                Annotations = new ObservableCollection<IAnnotation>()
                {
                   new TextAnnotationViewModel()
                   {
                       Text = text,
                       FontSize = 13,
                       Length = 0.5,
                       RotationReference = RotationReference.Page,
                       WrapText = TextWrapping.Wrap,
                       FontWeight = FontWeights.Bold,
                   },
                }
            };

            return connector;

        }

        /// <summary>
        /// Command to bring the objects into center of the viewport.
        /// </summary>
        /// <param name="parameter">Command parameter value</param>
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
        /// To update the annotation values into property panel properties.
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        private void OnItemSelectedCommandExecute(object parameter)
        {
            if ((parameter as ItemSelectedEventArgs).Item is INode)
            {
                NodeViewModel node = (parameter as ItemSelectedEventArgs).Item as NodeViewModel;
                foreach (IAnnotation annotation in node.Annotations as ObservableCollection<IAnnotation>)
                {
                    this.FontFamilyValue = (annotation as TextAnnotationViewModel).FontFamily;
                    this.Textcolor = (annotation as TextAnnotationViewModel).Foreground;
                    this.TextSize = (annotation as TextAnnotationViewModel).FontSize;
                    this.TextWrapValue = (annotation as TextAnnotationViewModel).WrapText;
                    this.TextTrimmingValue = (annotation as TextAnnotationViewModel).TextTrimming;

                }
            }
            else if ((parameter as ItemSelectedEventArgs).Item is IConnector)
            {
                ConnectorViewModel connector = (parameter as ItemSelectedEventArgs).Item as ConnectorViewModel;
                foreach (IAnnotation annotation in connector.Annotations as ObservableCollection<IAnnotation>)
                {
                    this.FontFamilyValue = (annotation as TextAnnotationViewModel).FontFamily;
                    this.Textcolor = (annotation as TextAnnotationViewModel).Foreground;
                    this.TextSize = (annotation as TextAnnotationViewModel).FontSize;
                    this.TextWrapValue = (annotation as TextAnnotationViewModel).WrapText;
                    this.TextTrimmingValue = (annotation as TextAnnotationViewModel).TextTrimming;

                }
            }
        }

        #endregion
    }
}
