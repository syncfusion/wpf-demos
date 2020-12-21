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
using Syncfusion.UI.Xaml.Diagram.Theming;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    /// <summary>
    /// Represents the DiagramViewModel
    /// </summary>
    public class ThemeStyleViewModel : DiagramViewModel
    {

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };

        public RibbonWindow View;

        /// <summary>
        /// Initializes a new instance of the DiagramVM class.
        /// </summary>
        public ThemeStyleViewModel(RibbonWindow demo)
        {
            View = demo;
            //Initialize the Nodes collection.
            this.Nodes = new ObservableCollection<NodeViewModel>();
            //Initialize the Connectors collection
            this.Connectors = new ObservableCollection<ConnectorViewModel>();
            AddNodes();
            AddConnectors();
        }
        /// <summary>
        /// Method to add the node.
        /// </summary>
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
        /// <summary>
        /// Create and add the Node to the Nodes collection.
        /// </summary>
        /// <param name="offsetx">specifies the offsetx of the Node</param>
        /// <param name="offsety">specifies the offsety of the Node</param>
        /// <param name="styleid">ThemestyleId</param>
        /// <returns></returns>
        NodeViewModel AddNode(double offsetx, double offsety, StyleId styleid)
        {
            NodeViewModel node = new NodeViewModel()
            {
                OffsetX = offsetx,
                OffsetY = offsety,
                UnitWidth = 75,
                UnitHeight = 75,
                Shape = resourceDictionary["Rectangle"],
                ShapeStyle = View.Resources["shapeStyle"] as Style,
                ThemeStyleId = styleid,
            };

            node.Annotations = new ObservableCollection<IAnnotation>()
            {
                new TextAnnotationViewModel()
                {
                    Text = styleid.ToString(),
                    TextWrapping = TextWrapping.Wrap,
                }
            };
            (this.Nodes as ObservableCollection<NodeViewModel>).Add(node);
            return node;
        }
        /// <summary>
        /// Method to add the connetor.
        /// </summary>
        void AddConnectors()
        {
            AddConnector(new Point(800, 100), new Point(900, 150), StyleId.Subtly | StyleId.Accent1);
            AddConnector(new Point(950, 100), new Point(1050, 150), StyleId.Subtly | StyleId.Accent2);
            AddConnector(new Point(1100, 100), new Point(1200, 150), StyleId.Subtly | StyleId.Accent3);
            AddConnector(new Point(1250, 100), new Point(1350, 150), StyleId.Subtly | StyleId.Accent4);
            AddConnector(new Point(1400, 100), new Point(1500, 150), StyleId.Subtly | StyleId.Accent5);
            AddConnector(new Point(1550, 100), new Point(1650, 150), StyleId.Subtly | StyleId.Accent6);
            AddConnector(new Point(1700, 100), new Point(1800, 150), StyleId.Subtly | StyleId.Accent7);

            AddConnector(new Point(800, 200), new Point(900, 250), StyleId.Moderate | StyleId.Accent1);
            AddConnector(new Point(950, 200), new Point(1050, 250), StyleId.Moderate | StyleId.Accent2);
            AddConnector(new Point(1100, 200), new Point(1200, 250), StyleId.Moderate | StyleId.Accent3);
            AddConnector(new Point(1250, 200), new Point(1350, 250), StyleId.Moderate | StyleId.Accent4);
            AddConnector(new Point(1400, 200), new Point(1500, 250), StyleId.Moderate | StyleId.Accent5);
            AddConnector(new Point(1550, 200), new Point(1650, 250), StyleId.Moderate | StyleId.Accent6);
            AddConnector(new Point(1700, 200), new Point(1800, 250), StyleId.Moderate | StyleId.Accent7);

            AddConnector(new Point(800, 300), new Point(900, 350), StyleId.Intense | StyleId.Accent1);
            AddConnector(new Point(950, 300), new Point(1050, 350), StyleId.Intense | StyleId.Accent2);
            AddConnector(new Point(1100, 300), new Point(1200, 350), StyleId.Intense | StyleId.Accent3);
            AddConnector(new Point(1250, 300), new Point(1350, 350), StyleId.Intense | StyleId.Accent4);
            AddConnector(new Point(1400, 300), new Point(1500, 350), StyleId.Intense | StyleId.Accent5);
            AddConnector(new Point(1550, 300), new Point(1650, 350), StyleId.Intense | StyleId.Accent6);
            AddConnector(new Point(1700, 300), new Point(1800, 350), StyleId.Intense | StyleId.Accent7);

        }

        /// <summary>
        /// Create and add the connector to the connector collection.
        /// </summary>
        /// <param name="spoint">Sourcepoint of the connector</param>
        /// <param name="tpoint">Targetpoint of the connector</param>
        /// <param name="styleid">ThemestyleId</param>
        /// <returns></returns>
        ConnectorViewModel AddConnector(Point spoint, Point tpoint, StyleId styleid)
        {
            ConnectorViewModel connector = new ConnectorViewModel()
            {
                SourcePoint = spoint,
                TargetPoint = tpoint,
                ThemeStyleId = styleid,
                ConnectorGeometryStyle = View.Resources["geometryStyle"] as Style
            };
            connector.Annotations = new ObservableCollection<IAnnotation>()
            {
                new TextAnnotationViewModel()
                {

                    Text = styleid.ToString()
                }
            };
            (this.Connectors as ObservableCollection<ConnectorViewModel>).Add(connector);
            return connector;
        }
    }

    /// <summary>
    /// OppositeBooleanConverter
    /// </summary>
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
}
