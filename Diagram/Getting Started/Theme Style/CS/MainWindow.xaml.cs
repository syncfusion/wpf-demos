#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Theming;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
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

namespace ThemeStyle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<object> themeRemovedItems = null;
        List<object> allowThemeRemovedItems = null;
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = sfdiagram;
            themeRemovedItems = new List<object>();
            allowThemeRemovedItems = new List<object>();
            sfdiagram.Nodes = new ObservableCollection<NodeViewModel>();
            sfdiagram.Connectors = new ObservableCollection<ConnectorViewModel>();

            AddNodes();
            //AddConnectors();
            sfdiagram.Loaded += Sfdiagram_Loaded;
            (sfdiagram.Info as IGraphInfo).ItemAdded += MainWindow_ItemAdded;
            (sfdiagram.Info as IGraphInfo).ItemSelectedEvent += MainWindow_ItemSelectedEvent;
            (sfdiagram.Info as IGraphInfo).ItemUnSelectedEvent += MainWindow_ItemUnSelectedEvent;
            this.Loaded += MainWindow_Loaded;
        }

        public bool Contains(NodeConstraints s, NodeConstraints t)
        {
            return (s & t) != 0;
        }

        public bool Contains(ConnectorConstraints s, ConnectorConstraints t)
        {
            return (s & t) != 0;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Custom1_ThemeRibbon.Theme = App.Current.Resources["Custom1_ThemeRibbon"] as DiagramTheme;
            Custom2_ThemeRibbon.Theme = App.Current.Resources["Custom2_ThemeRibbon"] as DiagramTheme;
        }

        private void MainWindow_ItemUnSelectedEvent(object sender, DiagramEventArgs args)
        {
            shapeEffectStylesGallery.IsEnabled = false;
            connectorEffectStylesGallery.IsEnabled = false;
        }
        private void MainWindow_ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
            foreach (var galleryGroup in shapeEffectStylesGallery.GalleryGroups)
            {
                foreach (var galleryItem in galleryGroup.Items)
                {
                    (galleryItem as RibbonGalleryItem).IsEnabled = true;
                }
            }
            foreach (var galleryGroup in connectorEffectStylesGallery.GalleryGroups)
            {
                foreach (var galleryItem in galleryGroup.Items)
                {
                    (galleryItem as RibbonGalleryItem).IsEnabled = true;
                }
            }
            if (themeRemovedItems.Contains(args.Item))
            {
                
                shapeRemoveThemesCheckbox.IsChecked = true;
            }
            else
            {                
                if (args.Item is INode && (args.Item as INode).Constraints.Contains(NodeConstraints.ThemeStyle))
                {
                    shapeRemoveThemesCheckbox.IsChecked = false;
                }
                
            }
            if (args.Item is INode)
            {

                connectorEffectStylesGallery.Visibility = Visibility.Collapsed;
                shapeEffectStylesGallery.Visibility = Visibility.Visible;
                connectorEffectStylesGallery.IsEnabled = false;
                shapeEffectStylesGallery.IsEnabled = true;
            }
            else if (args.Item is IConnector)
            {
                connectorEffectStylesGallery.Visibility = Visibility.Visible;
                shapeEffectStylesGallery.Visibility = Visibility.Collapsed;
                shapeEffectStylesGallery.IsEnabled = false;
                connectorEffectStylesGallery.IsEnabled = true;
            }
        }
        private void MainWindow_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            if (args.ItemSource == ItemSource.DrawingTool || args.ItemSource == ItemSource.Stencil)
            {
                if (args.Item is INode)
                {
                    (args.Item as INode).ThemeStyleId = StyleId.Variant1;
                }
                else if (args.Item is IConnector)
                {
                    (args.Item as IConnector).ThemeStyleId = StyleId.Subtly | StyleId.Accent1;
                }
            }

            if (args.Item is INode)
            {
                if ((args.Item as INode).Annotations != null && (args.Item as INode).Annotations is ObservableCollection<IAnnotation>)
                {
                    foreach (TextAnnotationViewModel annotaiton in (args.Item as INode).Annotations as ObservableCollection<IAnnotation>)
                    {
                        //annotaiton.ViewTemplate = this.Resources["viewTemplate"] as DataTemplate;
                        (annotaiton as TextAnnotationViewModel).FontFamily = new FontFamily("Calibri");
                    }
                }
            }
            if (args.Item is IConnector)
            {
                if ((args.Item as IConnector).Annotations != null && (args.Item as IConnector).Annotations is ObservableCollection<AnnotationEditorViewModel>)
                {
                    foreach (AnnotationEditorViewModel annotaiton in (args.Item as IConnector).Annotations as ObservableCollection<AnnotationEditorViewModel>)
                    {
                        annotaiton.ViewTemplate = this.Resources["viewTemplate"] as DataTemplate;
                    }
                }
            }

            if (!newItemThemeStyleDecision.IsChecked.Value)
            {
                if (args.Item is INode)
                {
                    (args.Item as INode).Constraints &= ~NodeConstraints.ThemeStyle;
                    (args.Item as INode).ShapeStyle = App.Current.Resources["shapeStyle"] as Style;
                }
                else if (args.Item is IConnector)
                {
                    (args.Item as IConnector).Constraints &= ~ConnectorConstraints.ThemeStyle;
                    (args.Item as IConnector).ConnectorGeometryStyle = App.Current.Resources["geometryStyle"] as Style;
                }
                themeRemovedItems.Add(args.Item);
            }
        }

        private void VariantRibbonGallery_SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                if ((e.NewValue as DesignVariantRibbonGalleryItem).Content != null)
                    sfdiagram.Theme.NodeStyles = (e.NewValue as DesignVariantRibbonGalleryItem).Content as Dictionary<StyleId, DiagramItemStyle>;
                if ((e.NewValue as DesignVariantRibbonGalleryItem).ConnectorVariant != null)
                    sfdiagram.Theme.ConnectorStyles = (e.NewValue as DesignVariantRibbonGalleryItem).ConnectorVariant;
            }
        }
        private void RibbonGallery_SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                foreach (var galleryGroup in shapeEffectStylesGallery.GalleryGroups)
                {
                    foreach (var galleryItem in galleryGroup.Items)
                    {
                        (galleryItem as RibbonGalleryItem).IsEnabled = true;
                    }
                }
                foreach (var galleryGroup in connectorEffectStylesGallery.GalleryGroups)
                {
                    foreach (var galleryItem in galleryGroup.Items)
                    {
                        (galleryItem as RibbonGalleryItem).IsEnabled = true;
                    }
                }
                foreach (var item in themeRemovedItems)
                {
                    if (item is INode)
                    {
                        (item as INode).Constraints |= NodeConstraints.ThemeStyle;
                    }
                    else if (item is IConnector)
                    {
                        (item as IConnector).Constraints |= ConnectorConstraints.ThemeStyle;
                    }
                }
                themeRemovedItems.Clear();
                SelectorViewModel selector = sfdiagram.SelectedItems as SelectorViewModel;
                if ((selector.Nodes as ObservableCollection<object>).Count > 0)
                {
                    foreach(INode node in selector.Nodes as ObservableCollection<object>)
                    {
                        if(node.Constraints.Contains(NodeConstraints.ThemeStyle))
                        {
                            shapeRemoveThemesCheckbox.IsChecked = false;
                        }
                    }
                }
                
                if ((e.NewValue as DesignRibbonGalleryItem).Name.Equals("Custom1_ThemeRibbon") ||
                    (e.NewValue as DesignRibbonGalleryItem).Name.Equals("Custom2_ThemeRibbon"))
                {
                    sfdiagram.Theme = VariantGallery0.Theme = (e.NewValue as DesignRibbonGalleryItem).Theme;
                    VariantGallery0.IsEnabled = false;
                    VariantGallery1.IsEnabled = false;
                    VariantGallery2.IsEnabled = false;
                    VariantGallery3.IsEnabled = false;
                    VariantRibbonGallery.SelectedItem = null;
                }
                else
                {
                    VariantGallery0.IsEnabled = true;
                    VariantGallery1.IsEnabled = true;
                    VariantGallery2.IsEnabled = true;
                    VariantGallery3.IsEnabled = true;

                    if (themeRemovedItems != null)
                    {
                        foreach (object item in themeRemovedItems)
                        {
                            if (item is INode)
                            {
                                (item as INode).Constraints |= NodeConstraints.ThemeStyle;
                            }
                            else if (item is IConnector)
                            {
                                (item as IConnector).Constraints |= ConnectorConstraints.ThemeStyle;
                            }
                        }
                    }
                    selector = sfdiagram.SelectedItems as SelectorViewModel;
                    if ((selector.Nodes as ObservableCollection<object>).Count > 0)
                    {
                        shapeEffectStylesGallery.IsEnabled = true;
                        connectorEffectStylesGallery.IsEnabled = false;
                    }
                    else if ((selector.Connectors as ObservableCollection<object>).Count > 0)
                    {
                        shapeEffectStylesGallery.IsEnabled = false;
                        connectorEffectStylesGallery.IsEnabled = true;
                    }

                    sfdiagram.Theme = VariantGallery0.Theme = VariantGallery1.Theme = VariantGallery2.Theme = VariantGallery3.Theme = (e.NewValue as DesignRibbonGalleryItem).Theme;
                    VariantRibbonGallery.SelectedItem = VariantGallery0;
                }

            }
        }

        private void Sfdiagram_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        void AddNodes()
        {
            #region Variant
            NodeViewModel var1 = AddNode(125, 125, StyleId.Variant1);
            NodeViewModel var2 = AddNode(225, 125, StyleId.Variant2);
            NodeViewModel var3 = AddNode(325, 125, StyleId.Variant3);
            NodeViewModel var4 = AddNode(425, 125, StyleId.Variant4);
            #endregion
            #region Subtly
            NodeViewModel subAcc1 = AddNode(125, 225, StyleId.Subtly | StyleId.Accent1);
            NodeViewModel subAcc2 = AddNode(225, 225, StyleId.Subtly | StyleId.Accent2);
            NodeViewModel subAcc3 = AddNode(325, 225, StyleId.Subtly | StyleId.Accent3);
            NodeViewModel subAcc4 = AddNode(425, 225, StyleId.Subtly | StyleId.Accent4);
            NodeViewModel subAcc5 = AddNode(525, 225, StyleId.Subtly | StyleId.Accent5);
            NodeViewModel subAcc6 = AddNode(625, 225, StyleId.Subtly | StyleId.Accent6);
            NodeViewModel subAcc17 = AddNode(725, 225, StyleId.Subtly | StyleId.Accent7);
            #endregion
            #region Refined
            NodeViewModel refAcc1 = AddNode(125, 325, StyleId.Refined | StyleId.Accent1);
            NodeViewModel refAcc2 = AddNode(225, 325, StyleId.Refined | StyleId.Accent2);
            NodeViewModel refAcc3 = AddNode(325, 325, StyleId.Refined | StyleId.Accent3);
            NodeViewModel refAcc4 = AddNode(425, 325, StyleId.Refined | StyleId.Accent4);
            NodeViewModel refAcc5 = AddNode(525, 325, StyleId.Refined | StyleId.Accent5);
            NodeViewModel refAcc6 = AddNode(625, 325, StyleId.Refined | StyleId.Accent6);
            NodeViewModel refAcc7 = AddNode(725, 325, StyleId.Refined | StyleId.Accent7);
            #endregion
            #region Balanced
            NodeViewModel balAcc1 = AddNode(125, 425, StyleId.Balanced | StyleId.Accent1);
            NodeViewModel balAcc2 = AddNode(225, 425, StyleId.Balanced | StyleId.Accent2);
            NodeViewModel balAcc3 = AddNode(325, 425, StyleId.Balanced | StyleId.Accent3);
            NodeViewModel balAcc4 = AddNode(425, 425, StyleId.Balanced | StyleId.Accent4);
            NodeViewModel balAcc5 = AddNode(525, 425, StyleId.Balanced | StyleId.Accent5);
            NodeViewModel balAcc6 = AddNode(625, 425, StyleId.Balanced | StyleId.Accent6);
            NodeViewModel balAcc7 = AddNode(725, 425, StyleId.Balanced | StyleId.Accent7);
            #endregion
            #region Moderate
            NodeViewModel modAcc1 = AddNode(125, 525, StyleId.Moderate | StyleId.Accent1);
            NodeViewModel modAcc2 = AddNode(225, 525, StyleId.Moderate | StyleId.Accent2);
            NodeViewModel modAcc3 = AddNode(325, 525, StyleId.Moderate | StyleId.Accent3);
            NodeViewModel modAcc4 = AddNode(425, 525, StyleId.Moderate | StyleId.Accent4);
            NodeViewModel modAcc5 = AddNode(525, 525, StyleId.Moderate | StyleId.Accent5);
            NodeViewModel modAcc6 = AddNode(625, 525, StyleId.Moderate | StyleId.Accent6);
            NodeViewModel modAcc7 = AddNode(725, 525, StyleId.Moderate | StyleId.Accent7);
            #endregion
            #region Focused
            NodeViewModel focAcc1 = AddNode(125, 625, StyleId.Focused | StyleId.Accent1);
            NodeViewModel focAcc2 = AddNode(225, 625, StyleId.Focused | StyleId.Accent2);
            NodeViewModel focAcc3 = AddNode(325, 625, StyleId.Focused | StyleId.Accent3);
            NodeViewModel focAcc4 = AddNode(425, 625, StyleId.Focused | StyleId.Accent4);
            NodeViewModel focAcc5 = AddNode(525, 625, StyleId.Focused | StyleId.Accent5);
            NodeViewModel focAcc6 = AddNode(625, 625, StyleId.Focused | StyleId.Accent6);
            NodeViewModel focAcc7 = AddNode(725, 625, StyleId.Focused | StyleId.Accent7);
            #endregion
            #region Intense
            NodeViewModel intAcc1 = AddNode(125, 725, StyleId.Intense | StyleId.Accent1);
            NodeViewModel intAcc2 = AddNode(225, 725, StyleId.Intense | StyleId.Accent2);
            NodeViewModel intAcc3 = AddNode(325, 725, StyleId.Intense | StyleId.Accent3);
            NodeViewModel intAcc4 = AddNode(425, 725, StyleId.Intense | StyleId.Accent4);
            NodeViewModel intAcc5 = AddNode(525, 725, StyleId.Intense | StyleId.Accent5);
            NodeViewModel intAcc6 = AddNode(625, 725, StyleId.Intense | StyleId.Accent6);
            NodeViewModel intAcc7 = AddNode(725, 725, StyleId.Intense | StyleId.Accent7);
            #endregion
        }
        void AddConnectors()
        {
            AddConnector(new Point(800, 50), new Point(900, 100), StyleId.Subtly | StyleId.Accent1);
            AddConnector(new Point(950, 50), new Point(1050, 100), StyleId.Subtly | StyleId.Accent2);
            AddConnector(new Point(1100, 50), new Point(1200, 100), StyleId.Subtly | StyleId.Accent3);
            AddConnector(new Point(1250, 50), new Point(1350, 100), StyleId.Subtly | StyleId.Accent4);
            AddConnector(new Point(1400, 50), new Point(1500, 100), StyleId.Subtly | StyleId.Accent5);
            AddConnector(new Point(1550, 50), new Point(1650, 100), StyleId.Subtly | StyleId.Accent6);
            AddConnector(new Point(1700, 50), new Point(1800, 100), StyleId.Subtly | StyleId.Accent7);

            AddConnector(new Point(800, 150), new Point(900, 200), StyleId.Moderate | StyleId.Accent1);
            AddConnector(new Point(950, 150), new Point(1050, 200), StyleId.Moderate | StyleId.Accent2);
            AddConnector(new Point(1100, 150), new Point(1200, 200), StyleId.Moderate | StyleId.Accent3);
            AddConnector(new Point(1250, 150), new Point(1350, 200), StyleId.Moderate | StyleId.Accent4);
            AddConnector(new Point(1400, 150), new Point(1500, 200), StyleId.Moderate | StyleId.Accent5);
            AddConnector(new Point(1550, 150), new Point(1650, 200), StyleId.Moderate | StyleId.Accent6);
            AddConnector(new Point(1700, 150), new Point(1800, 200), StyleId.Moderate | StyleId.Accent7);

            AddConnector(new Point(800, 250), new Point(900, 300), StyleId.Intense | StyleId.Accent1);
            AddConnector(new Point(950, 250), new Point(1050, 300), StyleId.Intense | StyleId.Accent2);
            AddConnector(new Point(1100, 250), new Point(1200, 300), StyleId.Intense | StyleId.Accent3);
            AddConnector(new Point(1250, 250), new Point(1350, 300), StyleId.Intense | StyleId.Accent4);
            AddConnector(new Point(1400, 250), new Point(1500, 300), StyleId.Intense | StyleId.Accent5);
            AddConnector(new Point(1550, 250), new Point(1650, 300), StyleId.Intense | StyleId.Accent6);
            AddConnector(new Point(1700, 250), new Point(1800, 300), StyleId.Intense | StyleId.Accent7);

        }
        ConnectorViewModel AddConnector(Point sp, Point ep, StyleId styleid)
        {
            ConnectorViewModel connector = new ConnectorViewModel()
            {
                SourcePoint = sp,
                TargetPoint = ep,
                ThemeStyleId = styleid,
                ConnectorGeometryStyle = App.Current.Resources["geometryStyle"] as Style
            };
            connector.Annotations = new ObservableCollection<IAnnotation>()
            {
                new TextAnnotationViewModel()
                {
                    
                    Text = styleid.ToString()
                    //Content = new TextSettings()
                    //{
                    //    Text = styleid.ToString()
                    //},
                    // ViewTemplate = this.Resources["viewTemplate"] as DataTemplate
                }
            };
            (sfdiagram.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector);
            return connector;
        }
        NodeViewModel AddNode(double offx, double offy, StyleId styleid)
        {
            NodeViewModel node = new NodeViewModel()
            {
                OffsetX = offx,
                OffsetY = offy,
                UnitWidth = 75,
                UnitHeight = 75,
                Shape = App.Current.Resources["Rectangle"],
                ShapeStyle = App.Current.Resources["shapeStyle"] as Style,
                ThemeStyleId = styleid,
            };

            node.Annotations = new ObservableCollection<IAnnotation>()
            {
                new TextAnnotationViewModel()
                {
                    //Content = new TextSettings()
                    //{
                    //    Text = styleid.ToString()
                    //},
                    // ViewTemplate = this.Resources["viewTemplate"] as DataTemplate
                    Text = styleid.ToString(),
                    TextWrapping = TextWrapping.Wrap,
                }
            };
            (sfdiagram.Nodes as ObservableCollection<NodeViewModel>).Add(node);
            return node;
        }

        private void shapeAllowThemesCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            if (sfdiagram != null)
            {
                foreach (INode selectedNode in (sfdiagram.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>)
                {
                    if (themeRemovedItems.Contains(selectedNode))
                    {
                        shapeRemoveThemesCheckbox.IsEnabled = false;
                    }
                    
                    selectedNode.Constraints |= NodeConstraints.ThemeStyle;
                }
                foreach (IConnector selectedNode in (sfdiagram.SelectedItems as SelectorViewModel).Connectors as ObservableCollection<object>)
                {
                    selectedNode.Constraints |= ConnectorConstraints.ThemeStyle;
                }
                shapeEffectStylesGallery.IsDropDownOpen = false;
                connectorEffectStylesGallery.IsDropDownOpen = false;
            }
        }

        private void shapeAllowThemesCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (INode selectedNode in (sfdiagram.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>)
            {
                if(themeRemovedItems.Contains(selectedNode))
                {
                    themeRemovedItems.Remove(selectedNode);
                }
                //allowThemeRemovedItems.Add(selectedNode);
                selectedNode.Constraints &= ~NodeConstraints.ThemeStyle;
            }
            foreach (IConnector selectedNode in (sfdiagram.SelectedItems as SelectorViewModel).Connectors as ObservableCollection<object>)
            {
                if (themeRemovedItems.Contains(selectedNode))
                {
                    themeRemovedItems.Remove(selectedNode);
                }
                //allowThemeRemovedItems.Add(selectedNode);
                selectedNode.Constraints &= ~ConnectorConstraints.ThemeStyle;
            }
            shapeEffectStylesGallery.IsDropDownOpen = false;
            connectorEffectStylesGallery.IsDropDownOpen = false;
        }

        private void shapeRemoveThemesCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (INode selectedNode in (sfdiagram.SelectedItems as SelectorViewModel).Nodes as ObservableCollection<object>)
            {
                if (selectedNode.Constraints.Contains(NodeConstraints.ThemeStyle))
                {
                    themeRemovedItems.Add(selectedNode);
                    selectedNode.Constraints &= ~NodeConstraints.ThemeStyle;
                    
                }
                selectedNode.ShapeStyle = App.Current.Resources["shapeStyle"] as Style;
            }
            foreach (IConnector selectedNode in (sfdiagram.SelectedItems as SelectorViewModel).Connectors as ObservableCollection<object>)
            {
                themeRemovedItems.Add(selectedNode);
                selectedNode.Constraints &= ~ConnectorConstraints.ThemeStyle;
                selectedNode.ConnectorGeometryStyle = App.Current.Resources["geometryStyle"] as Style;
            }
            //foreach (var galleryGroup in shapeEffectStylesGallery.GalleryGroups)
            //{
            //    foreach (var galleryItem in galleryGroup.Items)
            //    {
            //        (galleryItem as RibbonGalleryItem).IsEnabled = false;
            //    }
            //}
            //foreach (var galleryGroup in connectorEffectStylesGallery.GalleryGroups)
            //{
            //    foreach (var galleryItem in galleryGroup.Items)
            //    {
            //        (galleryItem as RibbonGalleryItem).IsEnabled = false;
            //    }
            //}
            ////shapeEffectStylesGallery.IsEnabled = false;
            ////connectorEffectStylesGallery.IsEnabled = false;
            //shapeEffectStylesGallery.IsDropDownOpen = false;
            //connectorEffectStylesGallery.IsDropDownOpen = false;
        }

        private void shapeEffectStylesGallery_SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SelectorViewModel selector = sfdiagram.SelectedItems as SelectorViewModel;
            if (e.NewValue is HomeRibbonGalleryItem)
            {
                StyleId styleId = (e.NewValue as HomeRibbonGalleryItem).ThemeStyleId;
                foreach (INode selectedNode in selector.Nodes as ObservableCollection<object>)
                {
                    bool removeThemeStyle = false;
                    if(!selectedNode.Constraints.Contains(NodeConstraints.ThemeStyle))
                    {
                        removeThemeStyle = true;
                        selectedNode.Constraints |= NodeConstraints.ThemeStyle;
                    }
                    selectedNode.ThemeStyleId = styleId;
                    if(removeThemeStyle)
                    {
                        selectedNode.Constraints &= ~NodeConstraints.ThemeStyle;
                    }
                }
            }
        }

        private void connectorEffectStylesGallery_SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SelectorViewModel selector = sfdiagram.SelectedItems as SelectorViewModel;
            if (e.NewValue is HomeRibbonGalleryItem)
            {
                StyleId styleId = (e.NewValue as HomeRibbonGalleryItem).ThemeStyleId;
                foreach (IConnector selectedConnector in selector.Connectors as ObservableCollection<object>)
                {
                    selectedConnector.ThemeStyleId = styleId;
                }
            }
        }

        private void newItemThemeStyleDecision_Checked(object sender, RoutedEventArgs e)
        {
            ribbonGallery.IsDropDownOpen = false;
        }

        private void newItemThemeStyleDecision_Unchecked(object sender, RoutedEventArgs e)
        {
            ribbonGallery.IsDropDownOpen = false;
        }
    }

    public class OppositeBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class GalleryStyle : INotifyPropertyChanged
    {
        private List<DiagramItemStyle> _mStyles;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<DiagramItemStyle> Styles
        {
            get { return _mStyles; }
            set
            {
                if (_mStyles != value)
                {
                    _mStyles = value;
                    OnPropertyChanged("Styles");
                }
            }
        }

        private DiagramItemStyle _mVariant1;

        public DiagramItemStyle Variant1
        {
            get { return _mVariant1; }
            set
            {
                if (_mVariant1 != value)
                {
                    _mVariant1 = value;
                    OnPropertyChanged("Variant1");
                }
            }
        }

        private DiagramItemStyle _mVariant2;

        public DiagramItemStyle Variant2
        {
            get { return _mVariant2; }
            set
            {
                if (_mVariant2 != value)
                {
                    _mVariant2 = value;
                    OnPropertyChanged("Variant2");
                }
            }
        }

        private DiagramItemStyle _mVariant3;

        public DiagramItemStyle Variant3
        {
            get { return _mVariant3; }
            set
            {
                if (_mVariant3 != value)
                {
                    _mVariant3 = value;
                    OnPropertyChanged("Variant3");
                }
            }
        }

        private DiagramItemStyle _mVariant4;

        public DiagramItemStyle Variant4
        {
            get { return _mVariant4; }
            set
            {
                if (_mVariant4 != value)
                {
                    _mVariant4 = value;
                    OnPropertyChanged("Variant4");
                }
            }
        }

        private DiagramItemStyle _mConnectorVariant;

        public DiagramItemStyle ConnectorVariant
        {
            get { return _mConnectorVariant; }
            set
            {
                if (_mConnectorVariant != value)
                {
                    _mConnectorVariant = value;
                    OnPropertyChanged("ConnectorVariant");
                }
            }
        }
        public GalleryStyle()
        {

        }

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
    public class HomeRibbonGalleryItem : RibbonGalleryItem
    {
        private StyleId _mThemeStyleID;
        public HomeRibbonGalleryItem()
        {
            this.Loaded += HomeRibbonGalleryItem_Loaded;
            this.IsEnabledChanged += HomeRibbonGalleryItem_IsEnabledChanged;
        }

        private void HomeRibbonGalleryItem_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                this.ContentTemplate = App.Current.Resources["effectStyleItemTemplate"] as DataTemplate;
            }
            else
            {
                this.ContentTemplate = App.Current.Resources["disabledeffectStyleItemTemplate"] as DataTemplate;
            }
        }

        private void HomeRibbonGalleryItem_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.IsEnabled)
            {
                this.ContentTemplate = App.Current.Resources["effectStyleItemTemplate"] as DataTemplate;
            }
            else
            {
                this.ContentTemplate = App.Current.Resources["disabledeffectStyleItemTemplate"] as DataTemplate;
            }
        }

        public StyleId ThemeStyleId
        {
            get { return _mThemeStyleID; }
            set
            {
                if (_mThemeStyleID != value)
                {
                    _mThemeStyleID = value;
                }
            }
        }

    }
    public class DesignRibbonGalleryItem : RibbonGalleryItem
    {
        public DesignRibbonGalleryItem()
        {
            this.Loaded += DesignRibbonGalleryItem_Loaded;
        }

        private void DesignRibbonGalleryItem_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Name.ToString().Equals("Custom1_ThemeRibbon"))
            {

            }
            Theme = App.Current.Resources[this.Name.ToString()] as DiagramTheme;
            ContentTemplate = App.Current.Resources["ribbonItemTemplate"] as DataTemplate;
        }

        internal DiagramTheme Theme
        {
            get { return (DiagramTheme)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Theme.  This enables animation, styling, binding, etc...
        internal static readonly DependencyProperty ThemeProperty =
            DependencyProperty.Register("Theme", typeof(DiagramTheme), typeof(DesignRibbonGalleryItem), new PropertyMetadata(null, OnThemeChanged));

        private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DesignRibbonGalleryItem item = d as DesignRibbonGalleryItem;
            if (item.Theme != null)
            {
                item.Content = new GalleryStyle();
                if (item.Theme.NodeStyles != null)
                {
                    (item.Content as GalleryStyle).Variant1 = item.Theme.NodeStyles[StyleId.Variant1];
                    (item.Content as GalleryStyle).Variant2 = item.Theme.NodeStyles[StyleId.Variant2];
                    (item.Content as GalleryStyle).Variant3 = item.Theme.NodeStyles[StyleId.Variant3];
                    (item.Content as GalleryStyle).Variant4 = item.Theme.NodeStyles[StyleId.Variant4];
                }
                if (item.Theme.ConnectorStyles != null)
                {
                    (item.Content as GalleryStyle).ConnectorVariant = (d as DesignRibbonGalleryItem).Theme.ConnectorStyles[StyleId.Subtly | StyleId.Accent1];
                }
            }
        }
    }
    public class DesignVariantRibbonGalleryItem : RibbonGalleryItem
    {
        public DesignVariantRibbonGalleryItem()
        {
            this.IsEnabledChanged += DesignVariantRibbonGalleryItem_IsEnabledChanged;
        }

        private void DesignVariantRibbonGalleryItem_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                this.ContentTemplate = App.Current.Resources["ribbonVariantItemTemplate"] as DataTemplate;
            }
            else
            {
                switch (this.Name)
                {
                    case "VariantGallery0":
                        this.ContentTemplate = App.Current.Resources["disabledribbonVariantItemTemplate0"] as DataTemplate;
                        break;
                    case "VariantGallery1":
                    case "VariantGallery2":
                    case "VariantGallery3":
                        this.ContentTemplate = App.Current.Resources["disabledribbonVariantItemTemplate1"] as DataTemplate;
                        break;
                }
            }
        }

        internal Dictionary<StyleId, DiagramItemStyle> ConnectorVariant
        {
            get { return (Dictionary<StyleId, DiagramItemStyle>)GetValue(ConnectorVariantProperty); }
            set { SetValue(ConnectorVariantProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConnectorVariant.  This enables animation, styling, binding, etc...
        internal static readonly DependencyProperty ConnectorVariantProperty =
            DependencyProperty.Register("ConnectorVariant", typeof(Dictionary<StyleId, DiagramItemStyle>), typeof(DesignVariantRibbonGalleryItem), new PropertyMetadata(null));

        internal DiagramTheme Theme
        {
            get { return (DiagramTheme)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Theme.  This enables animation, styling, binding, etc...
        internal static readonly DependencyProperty ThemeProperty =
            DependencyProperty.Register("Theme", typeof(DiagramTheme), typeof(DesignVariantRibbonGalleryItem), new PropertyMetadata(null));

    }
    public class DesignRibbonGallery : RibbonGallery
    {
        public DesignRibbonGallery()
        {
        }

        protected override void OnIsDropDownOpenChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnIsDropDownOpenChanged(e);
        }
        protected override void Popup_Opened(object sender, EventArgs e)
        {
            base.Popup_Opened(sender, e);
        }

        protected override void OnSelectedItemChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnSelectedItemChanged(e);
        }
    }
    public class CustomEffect : Effect
    {
        private Brush ConvertHexToBrush(string hex)
        {
            Brush brush = (SolidColorBrush)(new BrushConverter().ConvertFrom(hex));
            return brush;
        }

        HsvLinearColorPattern generateHSVPattern(Point startPoint, Point endPoint, double angle, double centerX, double centery, List<string> colors, List<double> offsets)
        {
            HsvLinearColorPattern fillpattern = new HsvLinearColorPattern()
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                Stops = new HsvSolidColorPatternCollection()
                            {
                                new HsvSolidColorPattern()
                                {
                                    BaseColor = BaseColor.Color,
                                    Color = ConvertHexToBrush(colors[0]),
                                    Offset = offsets[0]
                                },
                                new HsvSolidColorPattern()
                                {
                                    BaseColor = BaseColor.Color,
                                    Color = ConvertHexToBrush(colors[1]),
                                    Offset = offsets[1]
                                },
                                new HsvSolidColorPattern()
                                {
                                    BaseColor = BaseColor.Color,
                                    Color = ConvertHexToBrush(colors[2]),
                                    Offset = offsets[2]
                                },
                            }
            };

            fillpattern.Transform = new RotateTransform()
            {
                Angle = angle,
                CenterX = centerX,
                CenterY = centery
            };

            return fillpattern;
        }

        public override DiagramItemStyle GenerateStyle(Theme theme, string accent)
        {
            if (this.Name.Equals("Subtly"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                switch (accent)
                {
                    case "Accent1":
                        style.Stroke = ConvertHexToBrush("#e9eff7");
                        style.Foreground = ConvertHexToBrush("#5b9bd5");
                        break;
                    case "Accent2":
                        style.Stroke = ConvertHexToBrush("#ebeff5");
                        style.Foreground = ConvertHexToBrush("#759fcc");
                        break;
                    case "Accent3":
                        style.Stroke = ConvertHexToBrush("#e8ebef");
                        style.Foreground = ConvertHexToBrush("#41719c");
                        break;
                    case "Accent4":
                        style.Stroke = ConvertHexToBrush("#f3f6fa");
                        style.Foreground = ConvertHexToBrush("#bdd0e9");
                        break;
                    case "Accent5":
                        style.Stroke = ConvertHexToBrush("#fbece7");
                        style.Foreground = ConvertHexToBrush("#ed7d31");
                        break;
                    case "Accent6":
                        style.Stroke = ConvertHexToBrush("#ebf1e8");
                        style.Foreground = ConvertHexToBrush("#70ad47");
                        break;
                    case "Accent7":
                        style.Stroke = ConvertHexToBrush("#fef4e7");
                        style.Foreground = ConvertHexToBrush("#fec000");
                        break;
                }
                return style;
            }
            else if (this.Name.Equals("Refined"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                switch (accent)
                {
                    case "Accent1":
                        style.Foreground = ConvertHexToBrush("#5b9bd5");
                        break;
                    case "Accent2":
                        style.Foreground = ConvertHexToBrush("#759fcc");
                        break;
                    case "Accent3":
                        style.Foreground = ConvertHexToBrush("#41719c");
                        break;
                    case "Accent4":
                        style.Foreground = ConvertHexToBrush("#bdd0e9");
                        break;
                    case "Accent5":
                        style.Foreground = ConvertHexToBrush("#ed7d31");
                        break;
                    case "Accent6":
                        style.Foreground = ConvertHexToBrush("#70ad47");
                        break;
                    case "Accent7":
                        style.Foreground = ConvertHexToBrush("#fec000");
                        break;
                }
                return style;
            }
            else if (this.Name.Equals("Balanced"))
            {
                HsvLinearColorPattern hsvPattern = null;
                Brush foreground = null;
                Brush stroke = null;
                switch (accent)
                {
                    case "Accent1":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#e9eff7", "#f4f7fb", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#4f87bb");
                        break;
                    case "Accent2":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#ebeff5", "#f5f7fa", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#668bb3");
                        break;
                    case "Accent3":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#e8ebef", "#f4f5f7", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#386288");
                        break;
                    case "Accent4":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#f3f6fa", "#f9fafc", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#a6b6cd");
                        break;
                    case "Accent5":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#fbece7", "#fdf5f3", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#d06d29");
                        break;
                    case "Accent6":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#ebf1e8", "#f5f8f4", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#61973d");
                        break;
                    case "Accent7":
                        hsvPattern = generateHSVPattern
                            (
                            new Point(0, 0), new Point(1, 0), 60, 0.5, 0.5,
                            new List<string>() { "#fef4e7", "#fef9f3", "#feffff" },
                            new List<double>() { 0, 0.24, 0.54 }
                            );
                        foreground = stroke = ConvertHexToBrush("#dfa800");
                        break;
                }
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                if (hsvPattern != null)
                {
                    style.Fill = hsvPattern.GetBrush(theme, accent);
                }
                style.Stroke = stroke;
                style.Foreground = foreground;
                return style;
            }
            else if (this.Name.Equals("Moderate"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                style.Foreground = ConvertHexToBrush("#feffff");
                return style;
            }
            else if (this.Name.Equals("Focused"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                switch (accent)
                {
                    case "Accent1":
                        style.Stroke = ConvertHexToBrush("#40709c");
                        break;
                    case "Accent2":
                        style.Stroke = ConvertHexToBrush("#547395");
                        break;
                    case "Accent3":
                        style.Stroke = ConvertHexToBrush("#2d5171");
                        break;
                    case "Accent4":
                        style.Stroke = ConvertHexToBrush("#8a98ab");
                        break;
                    case "Accent5":
                        style.Stroke = ConvertHexToBrush("#ae5a21");
                        break;
                    case "Accent6":
                        style.Stroke = ConvertHexToBrush("#507e31");
                        break;
                    case "Accent7":
                        style.Stroke = ConvertHexToBrush("#ba8c00");
                        break;
                }
                style.Foreground = ConvertHexToBrush("#feffff");
                return style;
            }
            else if (this.Name.Equals("Intense"))
            {
                DiagramItemStyle style = base.GenerateStyle(theme, accent);
                switch (accent)
                {
                    case "Accent1":
                        style.Stroke = ConvertHexToBrush("#40709c");
                        break;
                    case "Accent2":
                        style.Stroke = ConvertHexToBrush("#547395");
                        break;
                    case "Accent3":
                        style.Stroke = ConvertHexToBrush("#2d5171");
                        break;
                    case "Accent4":
                        style.Stroke = ConvertHexToBrush("#8a98ab");
                        break;
                    case "Accent5":
                        style.Stroke = ConvertHexToBrush("#ae5a21");
                        break;
                    case "Accent6":
                        style.Stroke = ConvertHexToBrush("#507e31");
                        break;
                    case "Accent7":
                        style.Stroke = ConvertHexToBrush("#ba8c00");
                        break;
                }
                style.Foreground = ConvertHexToBrush("#feffff");
                return style;
            }
            else
                return base.GenerateStyle(theme, accent);
        }
    }
}
