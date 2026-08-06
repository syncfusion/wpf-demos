using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class NeuralNetworkDiagramViewModel
    {
        #region Properties and fields
        private static readonly int[] LayerSizes = { 3, 5, 4, 2 };

        private static readonly string[] LayerNames =
        {
            "Input Layer", "Hidden Layer 1", "Hidden Layer 2", "Output Layer"
        };

        private static readonly string[] LayerHexColors =
        {
            "#0087EA", "#FE871F", "#7925E5", "#04AE45"
        };

        private static readonly string[][] NodeLabels =
        {
            new[] { "Feature 1", "Feature 2", "Feature 3" },
            new[] { "H1-1", "H1-2", "H1-3", "H1-4", "H1-5" },
            new[] { "H2-1", "H2-2", "H2-3", "H2-4" },
            new[] { "Output 1", "Output 2" }
        };

        public ObservableCollection<NodeViewModel> Nodes { get; }
            = new ObservableCollection<NodeViewModel>();
        public ObservableCollection<ConnectorViewModel> Connectors { get; }
            = new ObservableCollection<ConnectorViewModel>();

        private double _seed = 42;
        #endregion
        private double NextRandom()
        {
            _seed = Math.Sin(_seed) * 10000;
            return _seed - Math.Floor(_seed);
        }
        private double GetWeight() => Math.Round((NextRandom() * 2 - 1) * 100) / 100;

        public NeuralNetworkDiagramViewModel()
        {
            BuildLegendNodes(); // ── must be first so they render behind neurons
            BuildNeurons();
            BuildConnectors();
        }

        #region Helper methods
        // ── Mirrors JS makeLayerLabelNode() exactly ──
        // Placed inside SfDiagram at offsetY=50 above each layer column
        // so FitToPage keeps them aligned automatically
        private void BuildLegendNodes()
        {
            for (int i = 0; i < LayerNames.Length; i++)
            {
                var color = (Color)ColorConverter.ConvertFromString(LayerHexColors[i]);

                var labelNode = new NodeViewModel
                {
                    ID = $"label_{i}",
                    UnitWidth = 160,
                    UnitHeight = 36,
                    // JS: offsetX = 200 + i*250, offsetY = 50
                    OffsetX = 200 + i * 250,
                    OffsetY = 50,
                    // Transparent background — label only
                    ShapeStyle = BuildTransparentStyle(),
                    ContentTemplate = BuildLegendTemplate(LayerNames[i], color),
                    // Non-selectable, non-draggable — mirrors JS ~Select constraint
                    Constraints = NodeConstraints.Default
                                & ~NodeConstraints.Selectable
                                & ~NodeConstraints.Draggable
                                & ~NodeConstraints.Resizable
                                & ~NodeConstraints.Rotatable

                };

                Nodes.Add(labelNode);
            }
        }

        private void BuildNeurons()
        {
            for (int l = 0; l < LayerSizes.Length; l++)
            {
                for (int n = 0; n < LayerSizes[l]; n++)
                {
                    string id = $"neuron_{l}_{n}";
                    string label = NodeLabels[l][n];
                    string layerName = LayerNames[l];
                    string hex = LayerHexColors[l];
                    var fill = (Color)ColorConverter.ConvertFromString(hex);

                    // JS: offsetX = 200 + l*250
                    //     offsetY = 120 + ((5 - size)*100/2) + n*100
                    double offsetX = 200 + l * 250;
                    double offsetY = 120 + ((5 - LayerSizes[l]) * 100.0 / 2) + n * 100;

                    var node = new NeuralNodeViewModel
                    {
                        ID = id,
                        UnitWidth = 70,
                        UnitHeight = 70,
                        OffsetX = offsetX,
                        OffsetY = offsetY,
                        ShapeStyle = BuildTransparentStyle(),
                        ContentTemplate = BuildNodeContentTemplate(label, fill),
                        TooltipData = new NeuronTooltipInfo
                        {
                            LayerName = layerName,
                            NeuronName = label
                        },
                        Constraints = NodeConstraints.Default
                                    & ~NodeConstraints.Draggable
                                    & ~NodeConstraints.Resizable
                                    & ~NodeConstraints.Rotatable
                    };

                    Nodes.Add(node);
                }
            }
        }

       

        private void BuildConnectors()
        {
            for (int l = 0; l < LayerSizes.Length - 1; l++)
            {
                for (int n = 0; n < LayerSizes[l]; n++)
                {
                    for (int m = 0; m < LayerSizes[l + 1]; m++)
                    {
                        double weight = GetWeight();
                        bool positive = weight >= 0;
                        string strokeHex = positive ? "#2196f3" : "#f44336";
                        double strokeWidth = Math.Max(1, Math.Min(3, Math.Abs(weight) * 3));

                        string src = $"neuron_{l}_{n}";
                        string tgt = $"neuron_{l + 1}_{m}";
                        string weightText = weight.ToString("G");

                        // ── Vary label position along connector to avoid overlap ──
                        // Source node index drives the offset: 
                        // n=0 → 0.35, n=1 → 0.45, n=2 → 0.55, n=3 → 0.65, n=4 → 0.75
                        double labelLength = 0.35 + (n * 0.1);

                        var conn = new NeuralConnectorViewModel
                        {
                            ID = $"conn_{l}_{n}_{m}",
                            SourceNodeID = src,
                            TargetNodeID = tgt,
                            ConnectorGeometryStyle = BuildConnectorStyle(strokeHex, strokeWidth),
                            TargetDecoratorStyle = BuildDecoratorStyle(strokeHex),
                            Segments = new ObservableCollection<IConnectorSegment>
                            {
                                new StraightSegment()
                            },
                            Annotations = new ObservableCollection<IAnnotation>
                            {
                                new AnnotationEditorViewModel
                                {
                                    Content = weightText,
                                 
                                    ViewTemplate = BuildWeightLabelTemplate(weightText),
                                    FontFamily = new FontFamily("Segoe UI"),
                                    Background = Brushes.White,
                                    Constraints = AnnotationConstraints.Default
                                                & ~AnnotationConstraints.Draggable
                                                & ~AnnotationConstraints.Resizable
                                                & ~AnnotationConstraints.Selectable
                                }
                            },
                            TooltipData = new ConnectionTooltipInfo
                            {
                                Weight = weightText,
                                FromNode = src,
                                ToNode = tgt,
                                IsPositive = positive
                            },
                            Constraints = ConnectorConstraints.Default
                                        & ~ConnectorConstraints.Draggable
                        };

                        Connectors.Add(conn);
                    }
                }
            }
        }

        // ── Legend label: colored dot + bold layer name ──
        // Mirrors JS makeLayerLabelNode() HTML template
        private DataTemplate BuildLegendTemplate(string layerName, Color dotColor)
        {
            // Root StackPanel — horizontal, centered
            var stack = new FrameworkElementFactory(
                typeof(System.Windows.Controls.StackPanel));
            stack.SetValue(System.Windows.Controls.StackPanel.OrientationProperty,
                System.Windows.Controls.Orientation.Horizontal);
            stack.SetValue(FrameworkElement.HorizontalAlignmentProperty,
                HorizontalAlignment.Center);
            stack.SetValue(FrameworkElement.VerticalAlignmentProperty,
                VerticalAlignment.Center);

            // Colored dot (12x12 ellipse)
            var dot = new FrameworkElementFactory(typeof(Ellipse));
            dot.SetValue(Ellipse.WidthProperty, 12.0);
            dot.SetValue(Ellipse.HeightProperty, 12.0);
            dot.SetValue(Ellipse.FillProperty, new SolidColorBrush(dotColor));
            dot.SetValue(FrameworkElement.MarginProperty, new Thickness(0, 0, 8, 0));
            dot.SetValue(FrameworkElement.VerticalAlignmentProperty,
                VerticalAlignment.Center);

            // Bold layer name text
            var text = new FrameworkElementFactory(
                typeof(System.Windows.Controls.TextBlock));
            text.SetValue(System.Windows.Controls.TextBlock.TextProperty, layerName);
            text.SetValue(System.Windows.Controls.TextBlock.FontWeightProperty,
                FontWeights.Bold);
            text.SetValue(System.Windows.Controls.TextBlock.FontSizeProperty, 14.0);
            text.SetValue(System.Windows.Controls.TextBlock.ForegroundProperty,
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#495057")));
            text.SetValue(System.Windows.Controls.TextBlock.FontFamilyProperty,
                new FontFamily("Segoe UI"));
            text.SetValue(FrameworkElement.VerticalAlignmentProperty,
                VerticalAlignment.Center);

            stack.AppendChild(dot);
            stack.AppendChild(text);

            var template = new DataTemplate { VisualTree = stack };
            template.Seal();
            return template;
        }

        // ── Colored ellipse + white bold label for neuron nodes ──
        private DataTemplate BuildNodeContentTemplate(string label, Color fillColor)
        {
            var brush = new SolidColorBrush(fillColor);

            var grid = new FrameworkElementFactory(
                typeof(System.Windows.Controls.Grid));

            var ellipse = new FrameworkElementFactory(typeof(Ellipse));
            ellipse.SetValue(Ellipse.FillProperty, brush);
            ellipse.SetValue(Ellipse.StrokeProperty, brush);
            ellipse.SetValue(Ellipse.StrokeThicknessProperty, 2.0);
            ellipse.SetValue(FrameworkElement.HorizontalAlignmentProperty,
                HorizontalAlignment.Stretch);
            ellipse.SetValue(FrameworkElement.VerticalAlignmentProperty,
                VerticalAlignment.Stretch);

            var text = new FrameworkElementFactory(
                typeof(System.Windows.Controls.TextBlock));
            text.SetValue(System.Windows.Controls.TextBlock.TextProperty, label);
            text.SetValue(System.Windows.Controls.TextBlock.ForegroundProperty,
                Brushes.White);
            text.SetValue(System.Windows.Controls.TextBlock.FontWeightProperty,
                FontWeights.Bold);
            text.SetValue(System.Windows.Controls.TextBlock.FontSizeProperty, 12.0);
            text.SetValue(System.Windows.Controls.TextBlock.FontFamilyProperty,
                new FontFamily("Segoe UI"));
            text.SetValue(System.Windows.Controls.TextBlock.TextWrappingProperty,
                TextWrapping.Wrap);
            text.SetValue(System.Windows.Controls.TextBlock.TextAlignmentProperty,
                TextAlignment.Center);
            text.SetValue(FrameworkElement.HorizontalAlignmentProperty,
                HorizontalAlignment.Center);
            text.SetValue(FrameworkElement.VerticalAlignmentProperty,
                VerticalAlignment.Center);
            text.SetValue(System.Windows.Controls.TextBlock.PaddingProperty,
                new Thickness(4));

            grid.AppendChild(ellipse);
            grid.AppendChild(text);

            var template = new DataTemplate { VisualTree = grid };
            template.Seal();
            return template;
        }

        private Style BuildTransparentStyle()
        {
            var style = new Style(typeof(System.Windows.Shapes.Path));
            style.Setters.Add(new Setter(
                System.Windows.Shapes.Shape.FillProperty, Brushes.Transparent));
            style.Setters.Add(new Setter(
                System.Windows.Shapes.Shape.StrokeProperty, Brushes.Transparent));
            style.Seal();
            return style;
        }

        private Style BuildConnectorStyle(string strokeHex, double width)
        {
            var brush = new SolidColorBrush(
                (Color)ColorConverter.ConvertFromString(strokeHex));
            var style = new Style(typeof(System.Windows.Shapes.Path));
            style.Setters.Add(new Setter(
                System.Windows.Shapes.Shape.StrokeProperty, brush));
            style.Setters.Add(new Setter(
                System.Windows.Shapes.Shape.StrokeThicknessProperty, width));
            style.Setters.Add(new Setter(
                System.Windows.Shapes.Shape.OpacityProperty, 0.7));
            style.Seal();
            return style;
        }

        private Style BuildDecoratorStyle(string strokeHex)
        {
            var brush = new SolidColorBrush(
                (Color)ColorConverter.ConvertFromString(strokeHex));
            var style = new Style(typeof(System.Windows.Shapes.Path));
            style.Setters.Add(new Setter(
                System.Windows.Shapes.Shape.FillProperty, brush));
            style.Setters.Add(new Setter(
                System.Windows.Shapes.Shape.StrokeProperty, brush));
            style.Seal();
            return style;
        }

        private DataTemplate BuildWeightLabelTemplate(string text)
        {
            var border = new FrameworkElementFactory(
                typeof(System.Windows.Controls.Border));
            border.SetValue(System.Windows.Controls.Border.BackgroundProperty,
                Brushes.White);
            border.SetValue(System.Windows.Controls.Border.PaddingProperty,
                new Thickness(2, 1, 2, 1));

            var tb = new FrameworkElementFactory(
                typeof(System.Windows.Controls.TextBlock));
            tb.SetValue(System.Windows.Controls.TextBlock.TextProperty, text);
            tb.SetValue(System.Windows.Controls.TextBlock.ForegroundProperty,
                new SolidColorBrush(
                    (Color)ColorConverter.ConvertFromString("#495057")));
            tb.SetValue(System.Windows.Controls.TextBlock.FontSizeProperty, 11.0);
            tb.SetValue(System.Windows.Controls.TextBlock.FontFamilyProperty,
                new FontFamily("Segoe UI"));
            border.AppendChild(tb);

            var template = new DataTemplate { VisualTree = border };
            template.Seal();
            return template;
        }

        #endregion
    }

    public class NeuralNodeViewModel : NodeViewModel
    {
        public NeuronTooltipInfo TooltipData { get; set; }
    }

    public class NeuronTooltipInfo
    {
        #region Properties
        public string LayerName { get; set; }
        public string NeuronName { get; set; }
        #endregion
    }

    public class NeuralConnectorViewModel : ConnectorViewModel
    {
        public ConnectionTooltipInfo TooltipData { get; set; }
    }

    public class ConnectionTooltipInfo
    {
        #region Properties
        public string Weight { get; set; }
        public string FromNode { get; set; }
        public string ToNode { get; set; }
        public bool IsPositive { get; set; }
        #endregion
    }
}
