#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.Windows.Shared;
using System.Windows.Data;
using System.Windows.Controls.Primitives;
using syncfusion.organizationallayout.wpf.Views;

namespace syncfusion.organizationallayout.wpf
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

        public SfDiagram Diagram
        {
            get
            {
                return (SfDiagram)GetValue(DiagramProperty);
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
            (this.diagramControl.DataContext as organizationallayoutViewModel).MenuBar = this;
            if (this.diagramControl != null)
            {
                (this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>).CollectionChanged += MenuBar_CollectionChanged;
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

        private void MenuBar_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if((this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>).Count > 0)
            {
                organizationallayoutNode node = (this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>).First() as organizationallayoutNode;
                if (node.TemplateName == "NoImageTemplate")
                {
                    Picture.IsEnabled = false;
                }
                else
                {
                    Delete.IsEnabled = true;
                    Change.IsEnabled = true;
                    ShowHide.IsEnabled = true;
                    Insert.IsEnabled = true;
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
            Add_Assistant.IsEnabled = false;
            Picture.IsEnabled = false;
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
                    isNodeSelected = true;
                    Picture.IsEnabled = true;
                    var node = selectedItem as INode;
                    if (node.Annotations is IEnumerable<IAnnotation>)
                    {
                        annotation = (node.Annotations as IEnumerable<IAnnotation>).FirstOrDefault();
                    }

                    if ((node as organizationallayoutNode).Content != null && ((node as organizationallayoutNode).Content as CustomContent).Image == null)
                    {
                        Insert.IsEnabled = true;
                        Delete.IsEnabled = false;
                        Change.IsEnabled = false;
                        ShowHide.IsEnabled = false;
                    }                    

                    INodeInfo nodeinfo = node.Info as INodeInfo;

                    if(nodeinfo.OutNeighbors != null && nodeinfo.OutNeighbors.Count() > 0)
                    {
                        foreach (organizationallayoutNode layoutnodes in nodeinfo.OutNeighbors)
                        {
                            if(layoutnodes.Name == "AssistantNode")
                            {
                                Add_Assistant.IsEnabled = false;
                                break;
                            }
                            else
                            {
                                Add_Assistant.IsEnabled = true;
                            }
                        }
                    }
                    else
                    {
                        Add_Assistant.IsEnabled = true;
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
                // closing overview popup window, when we switch tabs
                if (OverviewWindow != null &&  OverviewWindow.IsVisible)
                {
                    OverviewWindow.Close();
                }
                // closing search popup window, when we switch tabs
                if (searchwindow != null && searchwindow.IsVisible)
                {
                    searchwindow.Close();
                }
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
                            if (annotation.Foreground.ToString() != e.NewBrush.ToString())
                            {
                                annotation.Foreground = e.NewBrush;
                            }
                        }
                    }
                }
                foreach (IConnector connector in selectedItem.Connectors as IEnumerable<object>)
                {
                    if (connector.Annotations is IEnumerable<IAnnotation>)
                    {
                        foreach (IAnnotation annotation in connector.Annotations as IEnumerable<IAnnotation>)
                        {
                            if (annotation.Foreground.ToString() != e.NewBrush.ToString())
                            {
                                annotation.Foreground = e.NewBrush;
                            }
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
                    ((node as organizationallayoutNode).Content as CustomContent).FillColor = (SolidColorBrush)new BrushConverter().ConvertFromString(e.NewColor.ToString());
                    ((node as organizationallayoutNode).Content as CustomContent).PrevFillColor = (SolidColorBrush)new BrushConverter().ConvertFromString(e.NewColor.ToString());
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
                    ((node as organizationallayoutNode).Content as CustomContent).StrokeColor = (SolidColorBrush)new BrushConverter().ConvertFromString(e.NewColor.ToString());
                }

                foreach (IConnector connector in selectedItem.Connectors as IEnumerable<object>)
                {
                    (connector as organizationallayoutConnector).StrokeColor = (SolidColorBrush)new BrushConverter().ConvertFromString(e.NewColor.ToString());
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
                if (dropDownButton != null && dropDownButton.Label != "Layout")
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
                        Part_SelectTool.IsSelected = false;
                        Part_PanTool.IsSelected = false;
                        break;
                    case "Part_TextTool":
                        Part_SelectTool.IsSelected = false;
                        Part_PanTool.IsSelected = false;
                        break;
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
                    case "Part_WallTool":
                        break;
                    case "Part_TextTool":
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

        private void Re_Layout_OnClick(object sender, RoutedEventArgs e)
        {
            this.diagramControl.LayoutManager.Layout.InvalidateLayout();
        }

        private void HorizontalSpacingIncrease(object sender, RoutedEventArgs e)
        {
            (this.diagramControl.LayoutManager.Layout as DirectedTreeLayout).HorizontalSpacing =
                (this.diagramControl.LayoutManager.Layout as DirectedTreeLayout).HorizontalSpacing + 5;
        }

        private void HorizontalSpacingDecrease(object sender, RoutedEventArgs e)
        {
            (this.diagramControl.LayoutManager.Layout as DirectedTreeLayout).HorizontalSpacing =
                (this.diagramControl.LayoutManager.Layout as DirectedTreeLayout).HorizontalSpacing - 5;
        }

        private void VerticalSpacingIncrease(object sender, RoutedEventArgs e)
        {
            (this.diagramControl.LayoutManager.Layout as DirectedTreeLayout).VerticalSpacing =
                (this.diagramControl.LayoutManager.Layout as DirectedTreeLayout).VerticalSpacing + 5;
        }

        private void VerticalSpacingDecrease(object sender, RoutedEventArgs e)
        {
            (this.diagramControl.LayoutManager.Layout as DirectedTreeLayout).VerticalSpacing =
                (this.diagramControl.LayoutManager.Layout as DirectedTreeLayout).VerticalSpacing - 5;
        }

        private void Insert_OnClick(object sender, RoutedEventArgs e)
        {
            object node = (this.diagramControl.SelectedItems as SelectorViewModel).SelectedItem;
            if (node != null && node is organizationallayoutNode)
            {
                OpenFileDialog openDialogBox = new OpenFileDialog();
                openDialogBox.Title = "File Open";
                if (openDialogBox.ShowDialog() == true)
                {
                    ((node as organizationallayoutNode).Content as CustomContent).Image = openDialogBox.FileName.ToString();
                }
            }

            Delete.IsEnabled = true;
            Change.IsEnabled = true;
            ShowHide.IsEnabled = true;
        }

        private void Change_OnClick(object sender, RoutedEventArgs e)
        {
            object node = (this.diagramControl.SelectedItems as SelectorViewModel).SelectedItem;
            if (node != null && node is organizationallayoutNode)
            {
                OpenFileDialog openDialogBox = new OpenFileDialog();
                openDialogBox.Title = "File Open";
                if (openDialogBox.ShowDialog() == true)
                {
                    ((node as organizationallayoutNode).Content as CustomContent).Image = openDialogBox.FileName.ToString();
                }
            }
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            object node = (this.diagramControl.SelectedItems as SelectorViewModel).SelectedItem;
            if (node != null && node is organizationallayoutNode)
            {
                ((node as organizationallayoutNode).Content as CustomContent).Image = null;
            }

            Delete.IsEnabled = false;
            Change.IsEnabled = false;
            ShowHide.IsEnabled = false;
        }

        private void ShowHide_OnClick(object sender, RoutedEventArgs e)
        {
            IEnumerable<object> nodes = (this.diagramControl.SelectedItems as SelectorViewModel).Nodes as IEnumerable<object>;
            if (nodes != null && nodes.Count() > 0)
            {
                foreach (organizationallayoutNode node in nodes as IEnumerable<object>)
                {
                    if (node.Content != null)
                    {
                        var nodecontent = node.CustomContent as CustomContent;

                        if (nodecontent.ImageVisibility == 0)
                        {
                            nodecontent.ImageVisibility = 100;
                        }
                        else
                        {
                            nodecontent.ImageVisibility = 0;
                        }
                    }
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RemoveSelection();

            if ((sender as ComboBox).SelectedItem != null)
            {
                if (((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString() == "Top To Bottom" && this.diagramControl != null)
                {
                    (this.diagramControl.DataContext as organizationallayoutViewModel).LayoutOrientation = "Top To Bottom";
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(0).OffsetX = 1;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(0).OffsetY = 1;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(0).Margin = new Thickness(0, 25, 0, 0);

                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(1).OffsetX = 1;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(1).OffsetY = 0;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(1).Margin = new Thickness(20, -15, 0, 0);

                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(2).OffsetX = 0.5;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(2).OffsetY = 1;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(2).Margin = new Thickness(0, 25, 0, 0);

                }
                else if (((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString() == "Bottom To Top" && this.diagramControl != null)
                {
                    (this.diagramControl.DataContext as organizationallayoutViewModel).LayoutOrientation = "Bottom To Top";
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(0).OffsetX = 1;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(0).OffsetY = 0;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(0).Margin = new Thickness(0, -20, 0, 0);

                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(1).OffsetX = 1;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(1).OffsetY = 0.2;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(1).Margin = new Thickness(20, 0, 0, 0);

                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(2).OffsetX = 0.5;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(2).OffsetY = 0;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(2).Margin = new Thickness(0, -20, 0, 0);

                }
                else if (((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString() == "Right To Left" && this.diagramControl != null)
                {
                    (this.diagramControl.DataContext as organizationallayoutViewModel).LayoutOrientation = "Right To Left";
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(2).OffsetX = 0;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(2).OffsetY = 0.5;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(2).Margin = new Thickness(-20, 0, 0, 0);

                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(1).OffsetX = 1;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(1).OffsetY = 0;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(1).Margin = new Thickness(20, -15, 0, 0);

                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(0).OffsetX = 0.1;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(0).OffsetY = 1;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(0).Margin = new Thickness(0, 20, 0, 0);

                }
                else if (((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString() == "Left To Right" && this.diagramControl != null)
                {
                    (this.diagramControl.DataContext as organizationallayoutViewModel).LayoutOrientation = "Left To Right";
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(2).OffsetX = 1;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(2).OffsetY = 0.5;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(2).Margin = new Thickness(20, 0, 0, 0);

                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(1).OffsetX = 0.95;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(1).OffsetY = 0;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(1).Margin = new Thickness(0, -25, 0, 0);

                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(0).OffsetX = 0.95;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(0).OffsetY = 1;
                    ((this.diagramControl.SelectedItems as SelectorViewModel).Commands as ObservableCollection<QuickCommandVM>).ElementAt(0).Margin = new Thickness(0, 20, 0, 0);
                }
            }
        }

        private void RemoveSelection()
        {
            if(this.diagramControl != null && this.diagramControl.Connectors != null && this.diagramControl.Nodes != null)
            {
                foreach(organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.IsSelected = false;
                }

                foreach (ConnectorViewModel con in this.diagramControl.Connectors as ObservableCollection<organizationallayoutConnector>)
                {
                    con.IsSelected = false;
                }
            }
        }

        private void IconTop_Click(object sender, RoutedEventArgs e)
        {
            Picture.IsEnabled = true;
            if ((this.diagramControl.SelectedItems as SelectorViewModel).SelectedItem is organizationallayoutNode)
            {
                Picture.IsEnabled = true;
            }
            else
            {
                Picture.IsEnabled = false;
            }
            foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
            {
                if (node.Annotations == null || (node.Annotations as AnnotationCollection).Count < 3)
                {
                    node.UnitHeight = 100;
                    node.UnitWidth = 100;
                    node.TemplateName = "ImageTopTemplate";
                    node.ContentTemplate = this.Resources["ImageTopTemplate"] as DataTemplate;
                }
                else
                {
                    node.UnitWidth = 100;
                    node.UnitHeight = 100 + (node.Annotations as AnnotationCollection).Count * 20;
                    node.TemplateName = "ImageTopTemplate";
                    node.ContentTemplate = this.Resources["ImageTopTemplate"] as DataTemplate;
                }

                foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                {
                    anno.VerticalAlignment = VerticalAlignment.Center;
                    anno.HorizontalAlignment = HorizontalAlignment.Center;
                    anno.TextHorizontalAlignment = TextAlignment.Center;
                    anno.UnitWidth = 90;
                }

                SetOffset((node.Annotations as AnnotationCollection).Count, node, node.TemplateName);
            }
        }

        private void IconLeft_Click(object sender, RoutedEventArgs e)
        {
            Picture.IsEnabled = true;
            if ((this.diagramControl.SelectedItems as SelectorViewModel).SelectedItem is organizationallayoutNode)
            {
                Picture.IsEnabled = true;
            }
            else
            {
                Picture.IsEnabled = false;
            }
            foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
            {
                if(node.Annotations == null || (node.Annotations as AnnotationCollection).Count < 3)
                {
                    node.UnitHeight = 40;
                    node.UnitWidth = 150;
                    node.TemplateName = "ImageLeftTemplate";
                    node.ContentTemplate = this.Resources["ImageLeftTemplate"] as DataTemplate;
                }
                else
                {
                    node.UnitWidth = 150;
                    node.UnitHeight = (node.Annotations as AnnotationCollection).Count * 20;
                    node.TemplateName = "ImageLeftTemplate";
                    node.ContentTemplate = this.Resources["ImageLeftTemplate"] as DataTemplate;
                }

                foreach(AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                {
                    anno.VerticalAlignment = VerticalAlignment.Center;
                    anno.HorizontalAlignment = HorizontalAlignment.Left;
                    anno.TextHorizontalAlignment = TextAlignment.Left;
                    anno.UnitWidth = 60;
                }

                SetOffset((node.Annotations as AnnotationCollection).Count, node, node.TemplateName);
            }
        }

        private void NoIcon_Click(object sender, RoutedEventArgs e)
        {
            foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
            {
                if (node.Annotations == null || (node.Annotations as AnnotationCollection).Count < 3)
                {
                    node.UnitHeight = 40;
                    node.UnitWidth = 120;
                    node.TemplateName = "NoImageTemplate";
                    node.ContentTemplate = this.Resources["NoImageTemplate"] as DataTemplate;
                }
                else
                {
                    node.UnitWidth = 120;
                    node.UnitHeight = (node.Annotations as AnnotationCollection).Count * 20;
                    node.TemplateName = "NoImageTemplate";
                    node.ContentTemplate = this.Resources["NoImageTemplate"] as DataTemplate;
                }

                foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                {
                    anno.VerticalAlignment = VerticalAlignment.Center;
                    anno.HorizontalAlignment = HorizontalAlignment.Left;
                    anno.TextHorizontalAlignment = TextAlignment.Left;
                    anno.UnitWidth = 75;
                }

                SetOffset((node.Annotations as AnnotationCollection).Count, node, node.TemplateName);
            }

            Picture.IsEnabled = false;
        }

        private void Name_Checked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.NameSelected = true;

                    bool nameanno = false;

                    foreach(AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if(anno.Content.ToString() == node.CustomContent.Name.ToString())
                        {
                            nameanno = true;
                            break;
                        }
                    }

                    if (!nameanno)
                    {
                        AnnotationEditorViewModel anno = new AnnotationEditorViewModel()
                        {
                            Content = node.CustomContent.Name,
                            WrapText = TextWrapping.NoWrap,
                            Constraints = AnnotationConstraints.Default  &~ AnnotationConstraints.InheritEditable &~ AnnotationConstraints.Editable,
                            TextHorizontalAlignment = TextAlignment.Center,
                            TextVerticalAlignment = VerticalAlignment.Center,
                            TextTrimming = TextTrimming.WordEllipsis,
                            Foreground = Part_FontColor.SelectedBrush,
                            FontFamily = new FontFamily(Part_FontFamily.SelectedValue.ToString()),
                            FontSize = Convert.ToDouble(Part_FontSize.SelectedValue.ToString()),
                        };
                        
                        (node.Annotations as AnnotationCollection).Add(anno);
                        int annocount = (node.Annotations as AnnotationCollection).Count();
                        SetOffset(annocount, node, node.TemplateName);
                    }
                }
            }
        }

        private void Name_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.NameSelected = false;
                    AnnotationEditorViewModel removeanno = null;
                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (node.CustomContent.Name == anno.Content.ToString())
                        {
                            removeanno = anno;
                        }
                    }
                    if (removeanno != null)
                    {
                        (node.Annotations as AnnotationCollection).Remove(removeanno);
                    }

                    int annocount = (node.Annotations as AnnotationCollection).Count();
                    SetOffset(annocount, node, node.TemplateName);
                }
            }
        }

        private void EMPID_Checked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.EMPIDSelected = true; 
                    bool empanno = false;

                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (anno.Content.ToString() == node.CustomContent.EmployeeID.ToString())
                        {
                            empanno = true;
                            break;
                        }
                    }

                    if (!empanno)
                    {
                        (node.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                        {
                            Content = node.CustomContent.EmployeeID,
                            WrapText = TextWrapping.NoWrap,
                            TextHorizontalAlignment = TextAlignment.Center,
                            TextVerticalAlignment = VerticalAlignment.Center,
                            TextTrimming = TextTrimming.WordEllipsis,
                            Foreground = Part_FontColor.SelectedBrush,
                            FontFamily = new FontFamily(Part_FontFamily.SelectedValue.ToString()),
                            FontSize = Convert.ToDouble(Part_FontSize.SelectedValue.ToString()),
                            Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                        });
                        int annocount = (node.Annotations as AnnotationCollection).Count();
                        SetOffset(annocount, node, node.TemplateName);
                    }
                }
            }
        }

        private void EMPID_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.EMPIDSelected = false;
                    AnnotationEditorViewModel removeanno = null;
                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (node.CustomContent.EmployeeID == anno.Content.ToString())
                        {
                            removeanno = anno;
                        }
                    }
                    if (removeanno != null)
                    {
                        (node.Annotations as AnnotationCollection).Remove(removeanno);
                    }

                    int annocount = (node.Annotations as AnnotationCollection).Count();
                    SetOffset(annocount, node, node.TemplateName);
                }
            }
        }

        private void Designation_Checked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.RoleSelected = true;
                    bool roleanno = false;

                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (anno.Content.ToString() == node.CustomContent.Role.ToString())
                        {
                            roleanno = true;
                            break;
                        }
                    }

                    if (!roleanno)
                    {
                        (node.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                        {
                            Content = node.CustomContent.Role,
                            WrapText = TextWrapping.NoWrap,
                            TextHorizontalAlignment = TextAlignment.Center,
                            TextVerticalAlignment = VerticalAlignment.Center,
                            TextTrimming = TextTrimming.WordEllipsis,
                            Foreground = Part_FontColor.SelectedBrush,
                            FontFamily = new FontFamily(Part_FontFamily.SelectedValue.ToString()),
                            FontSize = Convert.ToDouble(Part_FontSize.SelectedValue.ToString()),
                            Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                        });
                        int annocount = (node.Annotations as AnnotationCollection).Count();
                        SetOffset(annocount, node, node.TemplateName);
                    }
                }
            }
        }

        private void Designation_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.RoleSelected = false;
                    AnnotationEditorViewModel removeanno = null;
                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (node.CustomContent.Role == anno.Content.ToString())
                        {
                            removeanno = anno;
                        }
                    }
                    if (removeanno != null)
                    {
                        (node.Annotations as AnnotationCollection).Remove(removeanno);
                    }

                    int annocount = (node.Annotations as AnnotationCollection).Count();
                    SetOffset(annocount, node, node.TemplateName);
                }
            }
        }

        private void Team_Checked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.TeamSelected = true;
                    bool teamanno = false;

                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (anno.Content.ToString() == node.CustomContent.Team.ToString())
                        {
                            teamanno = true;
                            break;
                        }
                    }

                    if (!teamanno)
                    {
                        (node.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                        {
                            Content = node.CustomContent.Team,
                            WrapText = TextWrapping.NoWrap,
                            TextHorizontalAlignment = TextAlignment.Center,
                            TextVerticalAlignment = VerticalAlignment.Center,
                            TextTrimming = TextTrimming.WordEllipsis,
                            Foreground = Part_FontColor.SelectedBrush,
                            FontFamily = new FontFamily(Part_FontFamily.SelectedValue.ToString()),
                            FontSize = Convert.ToDouble(Part_FontSize.SelectedValue.ToString()),
                            Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                        });
                        int annocount = (node.Annotations as AnnotationCollection).Count();
                        SetOffset(annocount, node, node.TemplateName);
                    }
                }
            }
        }

        private void Team_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.TeamSelected = false;
                    AnnotationEditorViewModel removeanno = null;
                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (node.CustomContent.Team == anno.Content.ToString())
                        {
                            removeanno = anno;
                        }
                    }
                    if (removeanno != null)
                    {
                        (node.Annotations as AnnotationCollection).Remove(removeanno);
                    }

                    int annocount = (node.Annotations as AnnotationCollection).Count();
                    SetOffset(annocount, node, node.TemplateName);
                }
            }
        }

        private void EMail_Checked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.MailSelected = true;
                    bool mailanno = false;

                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (anno.Content.ToString() == node.CustomContent.Email.ToString())
                        {
                            mailanno = true;
                            break;
                        }
                    }

                    if (!mailanno)
                    {
                        (node.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                        {
                            Content = node.CustomContent.Email,
                            WrapText = TextWrapping.NoWrap,
                            TextHorizontalAlignment = TextAlignment.Center,
                            TextVerticalAlignment = VerticalAlignment.Center,
                            TextTrimming = TextTrimming.WordEllipsis,
                            Foreground = Part_FontColor.SelectedBrush,
                            FontFamily = new FontFamily(Part_FontFamily.SelectedValue.ToString()),
                            FontSize = Convert.ToDouble(Part_FontSize.SelectedValue.ToString()),
                            Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                        });
                        int annocount = (node.Annotations as AnnotationCollection).Count();
                        SetOffset(annocount, node, node.TemplateName);
                    }
                }
            }
        }

        private void EMail_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.MailSelected = false;
                    AnnotationEditorViewModel removeanno = null;
                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (node.CustomContent.Email == anno.Content.ToString())
                        {
                            removeanno = anno;
                        }
                    }
                    if (removeanno != null)
                    {
                        (node.Annotations as AnnotationCollection).Remove(removeanno);
                    }

                    int annocount = (node.Annotations as AnnotationCollection).Count();
                    SetOffset(annocount, node, node.TemplateName);
                }
            }
        }

        private void PhoneNumber_Checked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.PhoneSelected = true;
                    bool phoneanno = false;

                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (anno.Content.ToString() == node.CustomContent.PhoneNumber.ToString())
                        {
                            phoneanno = true;
                            break;
                        }
                    }

                    if (!phoneanno)
                    {
                        (node.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                        {
                            Content = node.CustomContent.PhoneNumber,
                            WrapText = TextWrapping.NoWrap,
                            TextHorizontalAlignment = TextAlignment.Center,
                            TextVerticalAlignment = VerticalAlignment.Center,
                            TextTrimming = TextTrimming.WordEllipsis,
                            Foreground = Part_FontColor.SelectedBrush,
                            FontFamily = new FontFamily(Part_FontFamily.SelectedValue.ToString()),
                            FontSize = Convert.ToDouble(Part_FontSize.SelectedValue.ToString()),
                            Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                        });
                        int annocount = (node.Annotations as AnnotationCollection).Count();
                        SetOffset(annocount, node, node.TemplateName);
                    }
                }
            }
        }

        private void PhoneNumber_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.PhoneSelected = false;
                    AnnotationEditorViewModel removeanno = null;
                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (node.CustomContent.PhoneNumber == anno.Content.ToString())
                        {
                            removeanno = anno;
                        }
                    }
                    if (removeanno != null)
                    {
                        (node.Annotations as AnnotationCollection).Remove(removeanno);
                    }

                    int annocount = (node.Annotations as AnnotationCollection).Count();
                    SetOffset(annocount, node, node.TemplateName);
                }
            }
        }

        private void DirectControl_Checked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.DirectControlSelected = true;
                    bool dcanno = false;

                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (anno.Content.ToString() == node.CustomContent.DirectControl.ToString())
                        {
                            dcanno = true;
                            break;
                        }
                    }

                    if (!dcanno)
                    {
                        (node.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                        {
                            Content = node.CustomContent.DirectControl,
                            WrapText = TextWrapping.NoWrap,
                            TextHorizontalAlignment = TextAlignment.Center,
                            TextVerticalAlignment = VerticalAlignment.Center,
                            TextTrimming = TextTrimming.WordEllipsis,
                            Foreground = Part_FontColor.SelectedBrush,
                            FontFamily = new FontFamily(Part_FontFamily.SelectedValue.ToString()),
                            FontSize = Convert.ToDouble(Part_FontSize.SelectedValue.ToString()),
                            Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                        });
                        int annocount = (node.Annotations as AnnotationCollection).Count();
                        SetOffset(annocount, node, node.TemplateName);
                    }
                }
            }
        }

        private void DirectControl_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.DirectControlSelected = false;
                    AnnotationEditorViewModel removeanno = null;
                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (node.CustomContent.DirectControl == anno.Content.ToString())
                        {
                            removeanno = anno;
                        }
                    }
                    if (removeanno != null)
                    {
                        (node.Annotations as AnnotationCollection).Remove(removeanno);
                    }

                    int annocount = (node.Annotations as AnnotationCollection).Count();
                    SetOffset(annocount, node, node.TemplateName);
                }
            }
        }

        private void Tier_Checked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.TierSelected = true;
                    bool tieranno = false;

                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (anno.Content.ToString() == node.CustomContent.Tier.ToString())
                        {
                            tieranno = true;
                            break;
                        }
                    }

                    if (!tieranno)
                    {
                        (node.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                        {
                            Content = node.CustomContent.Tier,
                            WrapText = TextWrapping.NoWrap,
                            TextHorizontalAlignment = TextAlignment.Center,
                            TextVerticalAlignment = VerticalAlignment.Center,
                            TextTrimming = TextTrimming.WordEllipsis,
                            Foreground = Part_FontColor.SelectedBrush,
                            FontFamily = new FontFamily(Part_FontFamily.SelectedValue.ToString()),
                            FontSize = Convert.ToDouble(Part_FontSize.SelectedValue.ToString()),
                            Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                        });
                        int annocount = (node.Annotations as AnnotationCollection).Count();
                        SetOffset(annocount, node, node.TemplateName);
                    }
                }
            }
        }

        private void Tier_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.diagramControl != null && this.diagramControl.Nodes != null)
            {
                foreach (organizationallayoutNode node in this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>)
                {
                    node.CustomContent.TierSelected = false;
                    AnnotationEditorViewModel removeanno = null;
                    foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                    {
                        if (node.CustomContent.Tier == anno.Content.ToString())
                        {
                            removeanno = anno;
                        }
                    }
                    if (removeanno != null)
                    {
                        (node.Annotations as AnnotationCollection).Remove(removeanno);
                    }

                    int annocount = (node.Annotations as AnnotationCollection).Count();
                    SetOffset(annocount, node, node.TemplateName);
                }
            }
        }

        private void SetOffset(int annocount, organizationallayoutNode node, string TemplateName)
        {
            if (TemplateName == "ImageTopTemplate")
            {
                if (node.Annotations == null || (node.Annotations as AnnotationCollection).Count < 3)
                {
                    node.UnitHeight = 100;
                    node.UnitWidth = 150;
                }
                else
                {
                    node.UnitHeight = 100 + (node.Annotations as AnnotationCollection).Count * 20;
                    node.UnitWidth = 150;
                }

                foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                {
                    anno.VerticalAlignment = VerticalAlignment.Center;
                    anno.HorizontalAlignment = HorizontalAlignment.Center;
                    anno.TextHorizontalAlignment = TextAlignment.Center;
                    anno.UnitWidth = 90;
                }

                if (annocount == 1)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.6);
                }

                if (annocount == 2)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.6);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.8);
                }

                if (annocount == 3)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.45);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.65);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.5, 0.85);
                }

                if (annocount == 4)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.40);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.55);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.5, 0.70);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.5, 0.85);
                }

                if (annocount == 5)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.35);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.48);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.5, 0.61);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.5, 0.74);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.5, 0.87);
                }

                if (annocount == 6)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.32);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.44);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.5, 0.56);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.5, 0.68);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.5, 0.80);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.5, 0.92);
                }

                if (annocount == 7)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.27);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.38);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.5, 0.49);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.5, 0.60);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.5, 0.71);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.5, 0.82);
                    (node.Annotations as AnnotationCollection).ElementAt(6).Offset = new Point(0.5, 0.93);
                }

                if (annocount == 8)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.5, 0.25);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.5, 0.35);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.5, 0.45);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.5, 0.55);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.5, 0.65);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.5, 0.75);
                    (node.Annotations as AnnotationCollection).ElementAt(6).Offset = new Point(0.5, 0.85);
                    (node.Annotations as AnnotationCollection).ElementAt(7).Offset = new Point(0.5, 0.95);
                }
            }

            else if(TemplateName == "ImageLeftTemplate")
            {
                if ((node.Annotations as AnnotationCollection).Count < 3)
                {
                    node.UnitHeight = 50;
                    node.UnitWidth = 170;
                }
                else
                {
                    node.UnitWidth = 170;
                    node.UnitHeight = (node.Annotations as AnnotationCollection).Count * 20 + 10;
                }

                foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                {
                    anno.VerticalAlignment = VerticalAlignment.Center;
                    anno.HorizontalAlignment = HorizontalAlignment.Left;
                    anno.TextHorizontalAlignment = TextAlignment.Left;
                    anno.UnitWidth = 60;
                }

                if (annocount == 1)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.5);
                }

                if (annocount == 2)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.25);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.70);
                }

                if (annocount == 3)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.20);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.50);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.35, 0.80);
                }

                if (annocount == 4)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.12);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.37);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.35, 0.62);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.35, 0.87);
                }

                if (annocount == 5)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.10);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.30);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.35, 0.50);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.35, 0.70);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.35, 0.90);
                }

                if (annocount == 6)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.10);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.26);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.35, 0.42);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.35, 0.58);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.35, 0.74);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.35, 0.90);
                }

                if (annocount == 7)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.08);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.22);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.35, 0.36);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.35, 0.50);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.35, 0.64);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.35, 0.78);
                    (node.Annotations as AnnotationCollection).ElementAt(6).Offset = new Point(0.35, 0.92);
                }

                if (annocount == 8)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.35, 0.08);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.35, 0.20);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.35, 0.32);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.35, 0.44);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.35, 0.56);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.35, 0.68);
                    (node.Annotations as AnnotationCollection).ElementAt(6).Offset = new Point(0.35, 0.80);
                    (node.Annotations as AnnotationCollection).ElementAt(7).Offset = new Point(0.35, 0.92);
                }
            }

            else 
            {
                if ((node.Annotations as AnnotationCollection).Count < 3)
                {
                    node.UnitHeight = 50;
                    node.UnitWidth = 120;
                }
                else
                {
                    node.UnitWidth = 120;
                    node.UnitHeight = (node.Annotations as AnnotationCollection).Count * 20 + 10;
                }

                foreach (AnnotationEditorViewModel anno in node.Annotations as AnnotationCollection)
                {
                    anno.VerticalAlignment = VerticalAlignment.Center;
                    anno.HorizontalAlignment = HorizontalAlignment.Left;
                    anno.TextHorizontalAlignment = TextAlignment.Left;
                    anno.UnitWidth = 75;
                }

                if (annocount == 1)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.5);
                }

                if (annocount == 2)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.25);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.70);
                }

                if (annocount == 3)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.20);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.50);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.1, 0.80);
                }

                if (annocount == 4)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.12);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.37);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.1, 0.62);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.1, 0.87);
                }

                if (annocount == 5)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.10);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.30);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.1, 0.50);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.1, 0.70);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.1, 0.90);
                }

                if (annocount == 6)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.10);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.26);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.1, 0.42);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.1, 0.58);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.1, 0.74);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.1, 0.90);
                }

                if (annocount == 7)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.08);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.22);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.1, 0.36);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.1, 0.50);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.1, 0.64);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.1, 0.78);
                    (node.Annotations as AnnotationCollection).ElementAt(6).Offset = new Point(0.1, 0.92);
                }

                if (annocount == 8)
                {
                    (node.Annotations as AnnotationCollection).ElementAt(0).Offset = new Point(0.1, 0.08);
                    (node.Annotations as AnnotationCollection).ElementAt(1).Offset = new Point(0.1, 0.20);
                    (node.Annotations as AnnotationCollection).ElementAt(2).Offset = new Point(0.1, 0.32);
                    (node.Annotations as AnnotationCollection).ElementAt(3).Offset = new Point(0.1, 0.44);
                    (node.Annotations as AnnotationCollection).ElementAt(4).Offset = new Point(0.1, 0.56);
                    (node.Annotations as AnnotationCollection).ElementAt(5).Offset = new Point(0.1, 0.68);
                    (node.Annotations as AnnotationCollection).ElementAt(6).Offset = new Point(0.1, 0.80);
                    (node.Annotations as AnnotationCollection).ElementAt(7).Offset = new Point(0.1, 0.92);
                }
            }
        }

        private ChromelessWindow OverviewWindow;

        private void Part_Overview_Click(object sender, RoutedEventArgs e)
        {
            if (OverviewWindow == null)
            {
                OverviewWindow = new ChromelessWindow()
                {
                    Title = "Overview",
                    ShowIcon = false,
                    Width = 400,
                    Height = 300,
                    WindowStartupLocation = WindowStartupLocation.Manual,
                    Content = new Grid()
                    {

                    },
                    WindowState = WindowState.Normal,
                    ResizeMode = ResizeMode.NoResize,
                    UseNativeChrome = true,
                };

                OverviewWindow.Owner = Window.GetWindow(this);

                ((OverviewWindow.Content as Grid).Children as UIElementCollection).Add
                (
                    new Syncfusion.UI.Xaml.Diagram.Controls.Overview()
                    {
                        Source = Diagram as SfDiagram,
                        ShowZoomSlider = true,
                    }
                );

                OverviewWindow.Left = OverviewWindow.Owner.Width - OverviewWindow.Width - 30;
                OverviewWindow.Top = OverviewWindow.Owner.Height - OverviewWindow.Height - 60;

                OverviewWindow.Closing += (s, ev) =>
                {
                    OverviewWindow = null;
                };
            }

            if (!(OverviewWindow.IsVisible))
            {
                try
                {
                    SfSkinManagerExtension.SetTheme(this.OverviewWindow.Owner, this.OverviewWindow);
                }

                catch { }

                OverviewWindow.Show();
            }
            else
            {
                OverviewWindow.Close();
            }
        }

        private Search_Window searchwindow;

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (searchwindow == null)
            {
                searchwindow = new Search_Window();

                searchwindow.Owner = Window.GetWindow(this);
                searchwindow.DataContext = this.diagramControl;
                searchwindow.Left = searchwindow.Owner.Width - searchwindow.Width - 20;
                if (Part_Ruler.IsChecked.Value)
                {
                    searchwindow.Top = searchwindow.Owner.Top + searchwindow.Height - 5;
                }
                else
                {
                    searchwindow.Top = searchwindow.Owner.Top + searchwindow.Height - 30;
                }

                searchwindow.Closing += (s, ev) =>
                {
                    searchwindow = null;
                };

                if (!(searchwindow.IsVisible))
                {
                    try
                    {
                        SfSkinManagerExtension.SetTheme(this.searchwindow.Owner, this.searchwindow);
                    }

                    catch { }

                    searchwindow.Show();
                }
                else
                {
                    searchwindow.Close();
                }
            }
        }

        private void Add_Assistant_Click(object sender, RoutedEventArgs e)
        {
            if ((this.diagramControl.SelectedItems as SelectorViewModel).SelectedItem is INode)
            {
                organizationallayoutNode selectednode = (this.diagramControl.SelectedItems as SelectorViewModel).SelectedItem as organizationallayoutNode;
                selectednode.IsSelected = false;

                organizationallayoutNode newnode = new organizationallayoutNode()
                {
                    TemplateName = selectednode.TemplateName,
                    ContentTemplate = selectednode.ContentTemplate,
                    Name = "AssistantNode",
                    Constraints = NodeConstraints.Default & ~NodeConstraints.Connectable | NodeConstraints.AllowDrop,
                    CustomContent = new CustomContent()
                    {
                        Image = "/syncfusion.organizationallayout.wpf;component/Asset/male.png",
                        ImageVisibility = 100,
                        FillColor = selectednode.CustomContent.FillColor,
                        StrokeColor = selectednode.CustomContent.StrokeColor,
                    },
                };

                newnode.Annotations = new AnnotationCollection();

                if (EmpName.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.Name,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        UnitWidth = newnode.UnitWidth,
                        Foreground = this.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (Designation.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.Role,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        UnitWidth = newnode.UnitWidth,
                        Foreground = this.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (EMPID.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.EmployeeID,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        UnitWidth = newnode.UnitWidth,
                        Foreground = this.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (Team.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.Team,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        UnitWidth = newnode.UnitWidth,
                        Foreground = this.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (EMail.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.Email,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        UnitWidth = newnode.UnitWidth,
                        Foreground = this.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (PhoneNumber.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.PhoneNumber,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        UnitWidth = newnode.UnitWidth,
                        Foreground = this.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (DirectControl.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.DirectControl,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        UnitWidth = newnode.UnitWidth,
                        Foreground = this.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                if (Tier.IsChecked.Value)
                {
                    (newnode.Annotations as AnnotationCollection).Add(new AnnotationEditorViewModel()
                    {
                        Content = newnode.CustomContent.Tier,
                        WrapText = TextWrapping.NoWrap,
                        TextHorizontalAlignment = TextAlignment.Center,
                        TextVerticalAlignment = VerticalAlignment.Center,
                        TextTrimming = TextTrimming.WordEllipsis,
                        UnitWidth = newnode.UnitWidth,
                        Foreground = this.Part_FontColor.SelectedBrush,
                        FontFamily = new FontFamily(this.Part_FontFamily.SelectedValue.ToString()),
                        FontSize = Convert.ToDouble(this.Part_FontSize.SelectedValue.ToString()),
                        Constraints = AnnotationConstraints.Default & ~AnnotationConstraints.InheritEditable & ~AnnotationConstraints.Editable,
                    });
                }

                int annocount = (newnode.Annotations as AnnotationCollection).Count();
                SetOffset(annocount, newnode, newnode.TemplateName);

                (this.diagramControl.Nodes as ObservableCollection<organizationallayoutNode>).Add(newnode);

                organizationallayoutConnector con = new organizationallayoutConnector()
                {
                    SourceNode = selectednode,
                    TargetNode = newnode,
                };

                (this.diagramControl.Connectors as ObservableCollection<organizationallayoutConnector>).Add(con);

                selectednode.IsSelected = true;
            }

            this.diagramControl.LayoutManager.Layout.InvalidateLayout();
        }
    }
}
