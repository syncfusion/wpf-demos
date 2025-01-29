#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for DrawingTools.xaml
    /// </summary>
    public partial class DrawingTools : DemoControl
    {
        public DrawingTools()
        {
            InitializeComponent();
        }

        public DrawingTools(string themename) : base(themename)
        {
            InitializeComponent();
            this.DataContext = new DrawingToolsViewModel(this);
        }

        private void DiagramControl_Loaded(object sender, RoutedEventArgs e)
        {
            (DiagramControl.DataContext as DrawingToolsViewModel).SelectedButton = Rectangle;
        }

        private void ToogleButton_Checked(object sender, RoutedEventArgs e)
        {
            if (DiagramControl.DataContext != null)
                (DiagramControl.DataContext as DrawingToolsViewModel).SelectedButton = sender as ToggleButton;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            if (this.DiagramControl != null)
            {
                this.DiagramControl = null;
            }
            base.Dispose(disposing);
        }
    }

    public class StringToToolParameterConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool isContinousDraw;
            bool.TryParse(values[0].ToString(), out isContinousDraw);
            var selectedTool = values[1].ToString();
            var selectToolParameter = new SelectToolCommandParameter()
            {
                Tool = isContinousDraw ? Tool.ContinuesDraw : Tool.DrawOnce | Tool.MultipleSelect
            };
            switch (selectedTool)
            {
                case "Hexagon":
                case "Pentagon":
                case "Triangle":
                case "Star":
                case "User":
                case "SVG":
                    selectToolParameter.DrawingTool = DrawingTool.Node;
                    break;
                case "Rectangle":
                    selectToolParameter.DrawingTool = DrawingTool.Rectangle;
                    break;
                case "Ellipse":
                    selectToolParameter.DrawingTool = DrawingTool.Ellipse;
                    break;
                case "TextBox":
                    selectToolParameter.DrawingTool = DrawingTool.TextNode;
                    break;
                case "FreeHandConnector":
                    selectToolParameter.DrawingTool = DrawingTool.FreeHand;
                    break;
                case "StraightConnector":
                    selectToolParameter.DrawingTool = DrawingTool.Connector;
                    selectToolParameter.ConnectorType = ConnectorType.Line;
                    break;
                case "OrthogonalConnector":
                    selectToolParameter.DrawingTool = DrawingTool.Connector;
                    selectToolParameter.ConnectorType = ConnectorType.Orthogonal;
                    break;
                case "BezierConnector":
                    selectToolParameter.DrawingTool = DrawingTool.Connector;
                    selectToolParameter.ConnectorType = ConnectorType.QuadraticBezier;
                    break;
                case "PolyLineConnector":
                    selectToolParameter.DrawingTool = DrawingTool.Connector;
                    selectToolParameter.ConnectorType = ConnectorType.PolyLine;
                    break;
            }

            return selectToolParameter;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
