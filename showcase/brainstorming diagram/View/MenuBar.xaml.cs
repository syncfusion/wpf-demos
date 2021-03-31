#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace syncfusion.brainstormingdiagram.wpf.View
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        SfDiagram diagramControl;

        public MenuBar()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty BackStageOpeningCommandProperty = DependencyProperty.Register("BackStageOpeningCommand", typeof(ICommand), typeof(MenuBar), new UIPropertyMetadata(null));
        public static readonly DependencyProperty DiagramProperty = DependencyProperty.Register("Diagram", typeof(SfDiagram), typeof(MenuBar), new UIPropertyMetadata(null, OnDiagramChanged));

        public ICommand BackStageOpeningCommand
        {
            get
            {
                return (ICommand)GetValue(BackStageOpeningCommandProperty);
            }
            set
            {
                SetValue(BackStageOpeningCommandProperty, value);
            }
        }

        public ICommand Diagram
        {
            get
            {
                return (ICommand)GetValue(DiagramProperty);
            }
            set
            {
                SetValue(DiagramProperty, value);
            }
        }

        private static void OnDiagramChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            (sender as MenuBar).SetDiagramControl(args.NewValue as SfDiagram);
        }

        private void SetDiagramControl(SfDiagram diagram)
        {
            this.diagramControl = diagram;
            //this.DataContext = this.diagramControl;
            if (this.diagramControl != null)
            {
                (this.diagramControl.Info as IGraphInfo).ItemSelectedEvent += Diagram_ItemSelectedEvent;
            }
        }

        private void Diagram_ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
            if (this.diagramControl != null && this.diagramControl.SelectedItems is SelectorViewModel)
            {
                var selector = this.diagramControl.SelectedItems as SelectorViewModel;
                var selectedItem = selector.SelectedItem;
                if (selectedItem == null)
                {
                    selectedItem = (selector.Nodes as IEnumerable<object>).FirstOrDefault();
                }
                if (selectedItem == null)
                {
                    selectedItem = (selector.Connectors as IEnumerable<object>).FirstOrDefault();
                }

                IAnnotation annotation = null;
                bool isNodeSelected = false;
                if (selectedItem is INode)
                {
                    var node = selectedItem as INode;
                    if (node.Shape != null && node.ShapeStyle != null)
                    {
                        isNodeSelected = true;
                        foreach (Setter setter in node.ShapeStyle.Setters)
                        {
                            if (setter.Property.Name == "Fill")
                            {
                                if (setter.Value is SolidColorBrush)
                                {
                                    Part_FillColor.SelectedBrush = setter.Value as SolidColorBrush;
                                }
                            }
                            else if (setter.Property.Name == "Stroke")
                            {
                                if (setter.Value is SolidColorBrush)
                                {
                                    Part_StrokeColor.SelectedBrush = setter.Value as SolidColorBrush;
                                }
                            }
                        }
                    }

                    annotation = (node.Annotations as IEnumerable<IAnnotation>).FirstOrDefault();
                }
                else if (selectedItem is IConnector)
                {
                    annotation = ((selectedItem as IConnector).Annotations as IEnumerable<IAnnotation>).FirstOrDefault();
                }

                Part_FillColor.IsEnabled = isNodeSelected;
                Part_StrokeColor.IsEnabled = isNodeSelected;

                if (annotation != null)
                {
                    Part_ToggleBold.IsSelected = annotation.FontWeight == FontWeights.Bold;
                    Part_ToggleItalic.IsSelected = annotation.FontStyle == FontStyles.Italic;
                    Part_ToggleUnderline.IsSelected = annotation.TextDecorations != null && annotation.TextDecorations.Any() &&
                        annotation.TextDecorations.First().Location == TextDecorationLocation.Underline;
                    Part_FontColor.SelectedBrush = annotation.Foreground;
                    Part_FontFamily.SelectedItem = annotation.FontFamily;
                    Part_FontSize.SelectedItem = Math.Round(annotation.FontSize, 0);
                    if (annotation is TextAnnotationViewModel)
                    {
                        var textAlignment = "HorizontalLeft";
                        switch ((annotation as TextAnnotationViewModel).HorizontalAlignment)
                        {
                            case HorizontalAlignment.Left:
                                textAlignment = "HorizontalLeft";
                                break;
                            case HorizontalAlignment.Center:
                                textAlignment = "HorizontalCenter";
                                break;
                            case HorizontalAlignment.Right:
                                textAlignment = "HorizontalRight";
                                break;
                        }
                        Part_HorizontalAlign.Label = textAlignment;
                        var verticalAlignment = "VerticalTop";
                        switch ((annotation as TextAnnotationViewModel).VerticalAlignment)
                        {
                            case VerticalAlignment.Top:
                                verticalAlignment = "VerticalTop";
                                break;
                            case VerticalAlignment.Center:
                                verticalAlignment = "VerticalCenter";
                                break;
                            case VerticalAlignment.Bottom:
                                verticalAlignment = "VerticalBottom";
                                break;
                        }
                        Part_VerticalAlign.Label = verticalAlignment;                        
                    }
                }
            }
        }

        private void TabControlExt_SelectedIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue.ToString() == "0" && this.BackStageOpeningCommand != null)
            {
                (d as TabControlExt).SelectedIndex = 1;
                this.BackStageOpeningCommand.Execute(null);
            } 
        }

        private void Part_FontFamily_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.SelectedItems is SelectorViewModel)
            {
                var newValue = e.AddedItems[0].ToString();
                var selectedItem = this.diagramControl.SelectedItems as SelectorViewModel;
                foreach (INode node in selectedItem.Nodes as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in node.Annotations as IEnumerable<IAnnotation>)
                    {
                        annotation.FontFamily = new FontFamily(newValue);
                    }
                }
                foreach (IConnector connector in selectedItem.Connectors as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in connector.Annotations as IEnumerable<IAnnotation>)
                    {
                        annotation.FontFamily = new FontFamily(newValue);
                    }
                }
            }
        }

        private void Part_FontSize_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.diagramControl != null)
            {
                var newValue = Convert.ToDouble(e.AddedItems[0].ToString());
                var selectedItem = this.diagramControl.SelectedItems as SelectorViewModel;
                foreach (INode node in selectedItem.Nodes as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in node.Annotations as IEnumerable<IAnnotation>)
                    {
                        annotation.FontSize = newValue;
                    }
                }
                foreach (IConnector connector in selectedItem.Connectors as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in connector.Annotations as IEnumerable<IAnnotation>)
                    {
                        annotation.FontSize = newValue;
                    }
                }
            }
        }

        private void Part_FontColor_SelectedBrushChanged(object sender, SelectedBrushChangedEventArgs e)
        {
            if (this.diagramControl != null)
            {
                var selectedItem = this.diagramControl.SelectedItems as SelectorViewModel;
                foreach (INode node in selectedItem.Nodes as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in node.Annotations as IEnumerable<IAnnotation>)
                    {
                        annotation.Foreground = e.NewBrush;
                    }
                }
                foreach (IConnector connector in selectedItem.Connectors as IEnumerable<object>)
                {
                    foreach (IAnnotation annotation in connector.Annotations as IEnumerable<IAnnotation>)
                    {
                        annotation.Foreground = e.NewBrush;
                    }
                }
            }
        }

        private void Part_FillColor_SelectedBrushChanged(object sender, SelectedBrushChangedEventArgs e)
        {
            if (this.diagramControl != null)
            {
                var selectedItem = this.diagramControl.SelectedItems as SelectorViewModel;
                foreach (INode node in selectedItem.Nodes as IEnumerable<object>)
                {
                    var newStyle = new Style() { TargetType = typeof(System.Windows.Shapes.Path) };
                    foreach (Setter setter in node.ShapeStyle.Setters)
                    {
                        if (setter.Property.Name == "Fill")
                        {
                            newStyle.Setters.Add(new Setter() { Property = Path.FillProperty, Value = (SolidColorBrush)new BrushConverter().ConvertFromString(e.NewColor.ToString()) });
                        }
                        else
                        {
                            newStyle.Setters.Add(setter);
                        }
                    }

                    node.ShapeStyle = newStyle;
                }
            }
        }

        private void Part_StrokeColor_SelectedBrushChanged(object sender, SelectedBrushChangedEventArgs e)
        {
            if (this.diagramControl != null)
            {
                var selectedItem = this.diagramControl.SelectedItems as SelectorViewModel;
                foreach (INode node in selectedItem.Nodes as IEnumerable<object>)
                {
                    var newStyle = new Style() { TargetType = typeof(System.Windows.Shapes.Path) };
                    foreach (Setter setter in node.ShapeStyle.Setters)
                    {
                        if (setter.Property.Name == "Stroke")
                        {
                            newStyle.Setters.Add(new Setter() { Property=Path.StrokeProperty,Value= (SolidColorBrush)new BrushConverter().ConvertFromString(e.NewColor.ToString()) });
                        }
                        else
                        {
                            newStyle.Setters.Add(setter);
                        }
                    }

                    node.ShapeStyle = newStyle;
                }
            }
        }

        private void Part_HorizontalAlign_Click(object sender, RoutedEventArgs e)
        {
            var dropDownButton = sender as DropDownButton;
            if (dropDownButton == null)
            {
                var item = sender as DropDownMenuItem;
                dropDownButton = item.Parent as DropDownButton;
                if (dropDownButton != null)
                {
                    dropDownButton.Label = "Horizontal" + item.Header.ToString();
                }
            }

            HorizontalAlignment textAlignment = HorizontalAlignment.Center;
            double offset = 0.5;
            if (dropDownButton != null)
            {
                switch (dropDownButton.Label)
                {
                    case "HorizontalLeft":
                        textAlignment = HorizontalAlignment.Left;
                        offset = 0;
                        break;
                    case "HorizontalCenter":
                        textAlignment = HorizontalAlignment.Center;
                        offset =0.5;
                        break;
                    case "HorizontalRight":
                        textAlignment = HorizontalAlignment.Right;
                        offset = 1;
                        break;
                    //case "HorizontalJustify":
                    //    textAlignment = HorizontalAlignment.Justify;
                    //    offset = 0;
                    //    break;
                }
            }
            if (this.diagramControl != null)
            {
                var selectedItem = this.diagramControl.SelectedItems as SelectorViewModel;
                foreach (INode node in selectedItem.Nodes as IEnumerable<object>)
                {
                    foreach (TextAnnotationViewModel annotation in node.Annotations as IEnumerable<IAnnotation>)
                    {
                        annotation.HorizontalAlignment = textAlignment;
                        annotation.Offset = new Point(offset, annotation.Offset.Y);
                    }
                }
                foreach (IConnector connector in selectedItem.Connectors as IEnumerable<object>)
                {
                    foreach (TextAnnotationViewModel annotation in connector.Annotations as IEnumerable<IAnnotation>)
                    {
                        annotation.HorizontalAlignment = textAlignment;
                        annotation.Length = offset;
                    }
                }
            }
        }

        private void Part_VerticalAlign_Click(object sender, RoutedEventArgs e)
        {
            var dropDownButton = sender as DropDownButton;
            if (dropDownButton == null)
            {
                var item = sender as DropDownMenuItem;
                dropDownButton = item.Parent as DropDownButton;
                if (dropDownButton != null)
                {
                    dropDownButton.Label = "Vertical" + item.Header.ToString();
                }
            }

            VerticalAlignment textAlignment = VerticalAlignment.Center;
            double offset = 0.5;
            if (dropDownButton != null)
            {
                switch (dropDownButton.Label)
                {
                    case "VerticalTop":
                        textAlignment = VerticalAlignment.Top;
                        offset = 0;
                        break;
                    case "VerticalCenter":
                        textAlignment = VerticalAlignment.Center;
                        offset = 0.5;
                        break;
                    case "VerticalBottom":
                        textAlignment = VerticalAlignment.Bottom;
                        offset = 1;
                        break;
                }
            }
            if (this.diagramControl != null)
            {
                var selectedItem = this.diagramControl.SelectedItems as SelectorViewModel;
                foreach (INode node in selectedItem.Nodes as IEnumerable<object>)
                {
                    foreach (TextAnnotationViewModel annotation in node.Annotations as IEnumerable<IAnnotation>)
                    {
                        annotation.VerticalAlignment = textAlignment;
                        annotation.Offset = new Point(annotation.Offset.X, offset);
                    }
                }
                foreach (IConnector connector in selectedItem.Connectors as IEnumerable<object>)
                {
                    foreach (TextAnnotationViewModel annotation in connector.Annotations as IEnumerable<IAnnotation>)
                    {
                        annotation.VerticalAlignment = textAlignment;
                        annotation.Length = offset;
                    }
                }
            }
        }

        private void Part_DropDownMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as DropDownMenuItem;
            var itemHeader = item.Header.ToString();
            var dropdownbutton = item.Parent as DropDownButton;
            if (dropdownbutton != null)
            {
                if (this.diagramControl != null)
                {
                    dropdownbutton.IsDropDownOpen = false;
                    if (this.diagramControl.PageSettings != null)
                    {
                        if (itemHeader == "Landscape")
                        {
                            this.diagramControl.PageSettings.PageOrientation = PageOrientation.Landscape;
                        }
                        else if (itemHeader == "Portrait")
                        {
                            this.diagramControl.PageSettings.PageOrientation = PageOrientation.Portrait;
                        }
                        else
                        {
                            var orientation = this.diagramControl.PageSettings.PageOrientation;
                            var width = double.NaN;
                            var height = double.NaN;
                            switch (itemHeader)
                            {
                                case "Letter":
                                    width = 1056;
                                    height = 816;
                                    break;
                                case "Tabloid":
                                    width = 1632;
                                    height = 1056;
                                    break;
                                case "Legal":
                                    width = 1344;
                                    height = 816;
                                    break;
                                case "Statement":
                                    width = 1632;
                                    height = 1056;
                                    break;
                                case "Executive":
                                    width = 1056;
                                    height = 816;
                                    break;
                                case "A3":
                                    width = 1587;
                                    height = 1123;
                                    break;
                                case "A4":
                                    width = 1123;
                                    height = 794;
                                    break;
                                case "A5":
                                    width = 794;
                                    height = 559;
                                    break;
                            }
                            this.diagramControl.PageSettings.PageWidth = orientation == PageOrientation.Landscape ? width : height;
                            this.diagramControl.PageSettings.PageHeight = orientation == PageOrientation.Landscape ? height : width;
                        }
                    }
                }
            }
        }

        private bool freezeToolChange = false;
        private void Part_Tool_IsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (this.diagramControl == null) return;

            if ((bool)e.NewValue)
            {
                freezeToolChange = true;
                switch ((d as RibbonButton).Name)
                {
                    case "Part_SelectTool":
                        Part_PanTool.IsSelected = false;
                        break;
                    case "Part_PanTool":
                        Part_SelectTool.IsSelected = false;
                        break;
                }
                freezeToolChange = false;
            }
            else if (!freezeToolChange)
            {
                switch ((d as RibbonButton).Name)
                {
                    case "Part_SelectTool":
                        Part_SelectTool.IsSelected = true;
                        break;
                    case "Part_PanTool":
                        Part_PanTool.IsSelected = true;
                        break;
                }
            }
        }


        private void BackgroundColorPickerPalatte_SelectedBrushChanged(object sender, SelectedBrushChangedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.PageSettings != null)
            {
                this.diagramControl.PageSettings.PageBackground = e.NewBrush;
            }
        }


        private void Part_Ruler_Checked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null)
            {
                this.diagramControl.HorizontalRuler = new Ruler() { Orientation = Orientation.Horizontal };
                this.diagramControl.VerticalRuler = new Ruler() { Orientation = Orientation.Vertical };
            }
        }

        private void Part_Ruler_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null)
            {
                this.diagramControl.HorizontalRuler = null;
                this.diagramControl.VerticalRuler = null;
            }
        }

        private void Part_Gridlines_Checked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.SnapSettings != null &&
                !this.diagramControl.SnapSettings.SnapConstraints.Contains(SnapConstraints.ShowLines))
            {
                this.diagramControl.SnapSettings.SnapConstraints |= SnapConstraints.ShowLines;
            }
        }

        private void Part_Gridlines_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.SnapSettings != null &&
                this.diagramControl.SnapSettings.SnapConstraints.Contains(SnapConstraints.ShowLines))
            {
                this.diagramControl.SnapSettings.SnapConstraints &= ~SnapConstraints.ShowLines;
            }
        }

    }
    public class PathCollection : ObservableCollection<Path>
    {
    }
    public class MindMapOrientation : ObservableCollection<Orientation>
    {
        public MindMapOrientation() : base()
        {
            this.Add(Orientation.Horizontal);
            this.Add(Orientation.Vertical);
        }
    }

    public class MindMapSplitMode : ObservableCollection<MindMapTreeMode>
    {
        public MindMapSplitMode() : base()
        {
            this.Add(MindMapTreeMode.RootChildrenCount);
            this.Add(MindMapTreeMode.TreeNodesCount);
            this.Add(MindMapTreeMode.Level);
            this.Add(MindMapTreeMode.Area);
            this.Add(MindMapTreeMode.Custom);
        }
    }
}
