#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
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

namespace syncfusion.floorplanner.wpf
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
            if (this.diagramControl != null)
            {
                (this.diagramControl.Info as IGraphInfo).ItemSelectedEvent += Diagram_ItemSelectedEvent;
                (this.diagramControl.Info as IGraphInfo).ItemUnSelectedEvent += Diagram_ItemUnSelectedEvent;
                (this.diagramControl.Info as IGraphInfo).ObjectDrawn += Diagram_ObjectDrawn;

                if(this.diagramControl.PageSettings != null)
                {
                    if(this.diagramControl.PageSettings.PageOrientation == PageOrientation.Landscape)
                    {
                        Part_Landscape.IsSelected = true;                        
                    }
                    else
                    {
                        Part_Portrait.IsSelected = true;
                    }
                }
            }
        }

        private void Diagram_ObjectDrawn(object sender, ObjectDrawnEventArgs args)
        {
            if (args.State == DragState.Completed)
            {
                Part_SelectTool.IsSelected = true;
                this.diagramControl.Tool = Tool.MultipleSelect;
            }
        }

        private void Diagram_ItemUnSelectedEvent(object sender, DiagramEventArgs args)
        {
            Part_FillColor.IsEnabled = false;
            Part_StrokeColor.IsEnabled = false;
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
                bool isConnectorSelected = false;
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
                                Part_FillColor.SelectedBrush = setter.Value as SolidColorBrush;
                            }
                            else if (setter.Property.Name == "Stroke")
                            {
                                Part_StrokeColor.SelectedBrush = setter.Value as SolidColorBrush;
                            }
                        }
                    }

                    if (node.Annotations is IEnumerable<IAnnotation>)
                    {
                        annotation = (node.Annotations as IEnumerable<IAnnotation>).FirstOrDefault();
                    }
                }
                else if (selectedItem is IConnector)
                {
                    isConnectorSelected = true;
                    var connector = selectedItem as IConnector;
                    if (connector.ConnectorGeometryStyle != null)
                    {
                        foreach (Setter setter in connector.ConnectorGeometryStyle.Setters)
                        {
                            if (setter.Property.Name == "Stroke")
                            {
                                Part_StrokeColor.SelectedBrush = setter.Value as SolidColorBrush;
                            }
                        }
                    }
                }

                Part_FillColor.IsEnabled = isNodeSelected;
                Part_StrokeColor.IsEnabled = isNodeSelected || isConnectorSelected;

                if (annotation != null)
                {
                    Part_ToggleBold.IsSelected = annotation.FontWeight == FontWeights.Bold;
                    Part_ToggleItalic.IsSelected = annotation.FontStyle == FontStyles.Italic;
                    Part_ToggleUnderline.IsSelected = annotation.TextDecorations != null && annotation.TextDecorations.Any() &&
                        annotation.TextDecorations.First().Location == TextDecorationLocation.Underline;
                    Part_FontColor.SelectedBrush = annotation.Foreground;
                    Part_FontFamily.SelectedItem = annotation.FontFamily;
                    Part_FontSize.SelectedItem = Math.Round(annotation.FontSize, 0);
                }
                else
                {
                    Part_ToggleBold.IsSelected = false;
                    Part_ToggleItalic.IsSelected = false;
                    Part_ToggleUnderline.IsSelected = false;
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
                    if (node.Annotations is IEnumerable<IAnnotation>)
                    {
                        foreach (IAnnotation annotation in node.Annotations as IEnumerable<IAnnotation>)
                        {
                            annotation.FontFamily = new FontFamily(newValue);
                        }
                    }
                }
                foreach (IConnector connector in selectedItem.Connectors as IEnumerable<object>)
                {
                    if (connector.Annotations is IEnumerable<IAnnotation>)
                    {
                        foreach (IAnnotation annotation in connector.Annotations as IEnumerable<IAnnotation>)
                        {
                            annotation.FontFamily = new FontFamily(newValue);
                        }
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
                    if (node.Annotations is IEnumerable<IAnnotation>)
                    {
                        foreach (IAnnotation annotation in node.Annotations as IEnumerable<IAnnotation>)
                        {
                            annotation.FontSize = newValue;
                        }
                    }
                }
                foreach (IConnector connector in selectedItem.Connectors as IEnumerable<object>)
                {
                    if (connector.Annotations is IEnumerable<IAnnotation>)
                    {
                        foreach (IAnnotation annotation in connector.Annotations as IEnumerable<IAnnotation>)
                        {
                            annotation.FontSize = newValue;
                        }
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
                    if (node.Annotations is IEnumerable<IAnnotation>)
                    {
                        foreach (IAnnotation annotation in node.Annotations as IEnumerable<IAnnotation>)
                        {
                            annotation.Foreground = e.NewBrush;
                        }
                    }
                }
                foreach (IConnector connector in selectedItem.Connectors as IEnumerable<object>)
                {
                    if (connector.Annotations is IEnumerable<IAnnotation>)
                    {
                        foreach (IAnnotation annotation in connector.Annotations as IEnumerable<IAnnotation>)
                        {
                            annotation.Foreground = e.NewBrush;
                        }
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
                    (node as FloorPlanNode).FillColor = (SolidColorBrush)new BrushConverter().ConvertFromString(e.NewColor.ToString());
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
                    (node as FloorPlanNode).StrokeColor = (SolidColorBrush)new BrushConverter().ConvertFromString(e.NewColor.ToString());
                }

                foreach (IConnector connector in selectedItem.Connectors as IEnumerable<object>)
                {
                    (connector as FloorPlanConnector).StrokeColor = (SolidColorBrush)new BrushConverter().ConvertFromString(e.NewColor.ToString());
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

                dropDownButton.IsDropDownOpen = false;
            }

            if (dropDownButton != null)
            {
                var textAlignment = TextAlignment.Left;
                switch (dropDownButton.Label)
                {
                    case "HorizontalLeft":
                        textAlignment = TextAlignment.Left;
                        break;
                    case "HorizontalCenter":
                        textAlignment = TextAlignment.Center;
                        break;
                    case "HorizontalRight":
                        textAlignment = TextAlignment.Right;
                        break;
                    case "HorizontalJustify":
                        textAlignment = TextAlignment.Justify;
                        break;
                }

                if (this.diagramControl != null)
                {
                    var selectedItem = this.diagramControl.SelectedItems as SelectorViewModel;
                    foreach (INode node in selectedItem.Nodes as IEnumerable<object>)
                    {
                        if (node.Annotations is IEnumerable<IAnnotation>)
                        {
                            foreach (IAnnotation annotation in node.Annotations as IEnumerable<IAnnotation>)
                            {
                                annotation.TextHorizontalAlignment = textAlignment;
                            }
                        }
                    }
                    foreach (IConnector connector in selectedItem.Connectors as IEnumerable<object>)
                    {
                        if (connector.Annotations is IEnumerable<IAnnotation>)
                        {
                            foreach (IAnnotation annotation in connector.Annotations as IEnumerable<IAnnotation>)
                            {
                                annotation.TextHorizontalAlignment = textAlignment;
                            }
                        }
                    }
                }
            }
        }

        private RibbonButton lastselecteditem;

        private void Part_DropDownMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RibbonButton)
            {
                var item = sender as RibbonButton;
                var itemHeader = item.Label.ToString();
                var dropDownButton = item.Parent as DropDownButton;
                if (dropDownButton != null)
                {
                    dropDownButton.IsDropDownOpen = false;

                    if (this.diagramControl != null)
                    {
                        if (this.diagramControl.PageSettings != null)
                        {
                            if (itemHeader == "Landscape")
                            {
                                this.diagramControl.PageSettings.PageOrientation = PageOrientation.Landscape;
                                Part_Landscape.IsSelected = true;
                                Part_Portrait.IsSelected = false;
                            }
                            else if (itemHeader == "Portrait")
                            {
                                this.diagramControl.PageSettings.PageOrientation = PageOrientation.Portrait;
                                Part_Landscape.IsSelected = false;
                                Part_Portrait.IsSelected = true;
                            }
                            else
                            {
                                if (lastselecteditem == null)
                                {
                                    lastselecteditem = Part_A4;
                                }
                                lastselecteditem.IsSelected = false;
                                var orientation = this.diagramControl.PageSettings.PageOrientation;
                                var width = double.NaN;
                                var height = double.NaN;
                                switch (itemHeader)
                                {
                                    case "Letter":
                                        width = 1054;
                                        height = 816;
                                        lastselecteditem = Part_Letter;
                                        lastselecteditem.IsSelected = true;
                                        break;
                                    case "Tabloid":
                                        width = 1633;
                                        height = 1054;
                                        lastselecteditem = Part_Tabloid;
                                        lastselecteditem.IsSelected = true;
                                        break;
                                    case "Legal":
                                        width = 1346;
                                        height = 816;
                                        lastselecteditem = Part_Legal;
                                        lastselecteditem.IsSelected = true;
                                        break;
                                    case "Statement":
                                        width = 816;
                                        height = 529;
                                        lastselecteditem = Part_Statement;
                                        lastselecteditem.IsSelected = true;
                                        break;
                                    case "Executive":
                                        width = 1008;
                                        height = 696;
                                        lastselecteditem = Part_Executive;
                                        lastselecteditem.IsSelected = true;
                                        break;
                                    case "A3":
                                        width = 1587;
                                        height = 1123;
                                        lastselecteditem = Part_A3;
                                        lastselecteditem.IsSelected = true;
                                        break;
                                    case "A4":
                                        width = 1123;
                                        height = 794;
                                        lastselecteditem = Part_A4;
                                        lastselecteditem.IsSelected = true;
                                        break;
                                    case "A5":
                                        width = 794;
                                        height = 559;
                                        lastselecteditem = Part_A5;
                                        lastselecteditem.IsSelected = true;
                                        break;
                                }

                                this.diagramControl.PageSettings.PageWidth = orientation == PageOrientation.Landscape ? width : height;
                                this.diagramControl.PageSettings.PageHeight = orientation == PageOrientation.Landscape ? height : width;
                            }
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
                    case "Part_WallTool":
                        Part_TextTool.IsSelected = false;
                        Part_SelectTool.IsSelected = false;
                        Part_PanTool.IsSelected = false;
                        break;
                    case "Part_TextTool":
                        Part_WallTool.IsSelected = false;
                        Part_SelectTool.IsSelected = false;
                        Part_PanTool.IsSelected = false;
                        break;
                    case "Part_SelectTool":
                        Part_WallTool.IsSelected = false;
                        Part_TextTool.IsSelected = false;
                        Part_PanTool.IsSelected = false;
                        break;
                    case "Part_PanTool":
                        Part_WallTool.IsSelected = false;
                        Part_SelectTool.IsSelected = false;
                        Part_TextTool.IsSelected = false;
                        break;
                }
                freezeToolChange = false;
            }
            else if (!freezeToolChange)
            {
                switch ((d as RibbonButton).Name)
                {
                    case "Part_WallTool":
                        Part_WallTool.IsSelected = true;
                        break;
                    case "Part_TextTool":
                        Part_TextTool.IsSelected = true;
                        break;
                    case "Part_SelectTool":
                        Part_SelectTool.IsSelected = true;
                        break;
                    case "Part_PanTool":
                        Part_PanTool.IsSelected = true;
                        break;
                }
            }
        }

        private void Part_InsertPicture_Click(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl == null) return;

            var dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (dialog.ShowDialog() == true)
            {
                using (var myStream = dialog.OpenFile())
                {
                    var node = new FloorPlanNode()
                    {
                        Content = new Image()
                        {
                            Source = new BitmapImage(new Uri(dialog.FileName)),
                            Stretch = Stretch.Fill,
                        },
                        Annotations = new ObservableCollection<IAnnotation>()
                        {
                            new AnnotationEditorViewModel()
                            {
                                Offset = new Point(0.5,1),
                                Margin = new Thickness(0,20,0,0),
                            },
                        }
                    };

                    if (this.diagramControl.Nodes != null)
                    {
                        (this.diagramControl.Nodes as ObservableCollection<FloorPlanNode>).Add(node);
                    }
                };
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

        private void Part_SnapToGrid_Checked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.SnapSettings != null &&
                !this.diagramControl.SnapSettings.SnapConstraints.Contains(SnapConstraints.SnapToLines))
            {
                this.diagramControl.SnapSettings.SnapConstraints |= SnapConstraints.SnapToLines;
            }
        }

        private void Part_SnapToGrid_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.SnapSettings != null &&
                this.diagramControl.SnapSettings.SnapConstraints.Contains(SnapConstraints.SnapToLines))
            {
                this.diagramControl.SnapSettings.SnapConstraints &= ~SnapConstraints.SnapToLines;
            }
        }

        private void Part_SnapToObject_Checked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.SnapSettings != null)
            {
                this.diagramControl.SnapSettings.SnapToObject = SnapToObject.All;
            }
        }

        private void Part_SnapToObject_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.SnapSettings != null)
            {
                this.diagramControl.SnapSettings.SnapToObject = SnapToObject.None;
            }
        }

        private void Part_PageBreak_Checked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.PageSettings != null)
            {
                this.diagramControl.PageSettings.ShowPageBreaks = true;
            }
        }

        private void Part_PageBreak_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.PageSettings != null)
            {
                this.diagramControl.PageSettings.ShowPageBreaks = false;
            }
        }        
    }
}
