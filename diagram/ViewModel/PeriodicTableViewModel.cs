using syncfusion.diagramdemo.wpf.Views;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class PeriodicTableViewModel
    {
        public NodeCollection Nodes { get; } = new NodeCollection();
        public ConnectorCollection Connectors { get; } = new ConnectorCollection();
        private int? _selectedGroup;
        private int? _selectedPeriod;

        public int? SelectedGroup
        {
            get { return _selectedGroup; }
            set { _selectedGroup = value; _selectedPeriod = null; ApplyHighlight(); }
        }

        public int? SelectedPeriod
        {
            get { return _selectedPeriod; }
            set { _selectedPeriod = value; _selectedGroup = null; ApplyHighlight(); }
        }
        private void ApplyHighlight()
        {
            foreach (var item in Nodes)
            {
                var evm = item as ElementNodeViewModel;
                if (evm == null || !evm.IsElementNode) continue;

                if (_selectedGroup.HasValue)
                {
                    if (evm.Element.IsFBlock)
                    {
                        evm.IsBlurred = true;
                    }
                    else
                    {
                        evm.IsBlurred = evm.Element.Group != _selectedGroup.Value;
                    }
                }
                else if (_selectedPeriod.HasValue)
                {
                    evm.IsBlurred = evm.Element.Period != _selectedPeriod.Value;
                }
                else
                {
                    evm.IsBlurred = false;
                }
            }
        }

        private static readonly Dictionary<string, string> CategoryColors
            = new Dictionary<string, string>()
            {
                ["alkali-metals"] = "#006AC7",
                ["alkaline-earth-metals"] = "#08970E",
                ["transition-metals"] = "#F08000",
                ["other-metals"] = "#B75A09",
                ["metalloids"] = "#95B506",
                ["non-metals"] = "#DE2362",
                ["halogens"] = "#DE2723",
                ["noble-gases"] = "#0B98A9",
                ["lanthanides"] = "#5C1FA8",
                ["actinides"] = "#8C04A1",
            };

        public PeriodicTableViewModel()
        {
            BuildPeriodicTable();
        }

        private void BuildPeriodicTable()
        {
            foreach (var element in GetPeriodicTableData())
            {
                var color = CategoryColors.TryGetValue(element.Category, out var c) ? c : "#888888";
                Nodes.Add(new ElementNodeViewModel(element, color));
            }

            AddLabelNodes();
            AddLegendNodes();
            AddBlockLabelsAndConnectors();
        }

        private void AddLabelNodes()
        {
            double cw = ElementNodeViewModel.CellWidth;
            double ch = ElementNodeViewModel.CellHeight;
            double cs = ElementNodeViewModel.CellSpacing;
            double sx = ElementNodeViewModel.StartX;
            double sy = ElementNodeViewModel.StartY;

            // GROUP header text
            Nodes.Add(new NodeViewModel
            {
                UnitWidth = 60,
                UnitHeight = 18,
                OffsetX = sx - (cw + cs) * 0.1 + 15,
                OffsetY = sy - (ch + cs) * 1.55 + 40,
                Annotations = new AnnotationCollection
                {
                    new AnnotationEditorViewModel
                    {
                        Content      = "GROUP",
                        ViewTemplate = MakeTextTemplate("#212121", 14, bold: true),
                        ReadOnly     = true
                    }
                },
                ShapeStyle = MakeLabelStyle("Transparent", "Transparent"),

            });

            // PERIOD header text
            Nodes.Add(new NodeViewModel
            {
                UnitWidth = 60,
                UnitHeight = 18,
                OffsetX = sx - (cw + cs) * 1.35 + 35,
                OffsetY = sy + 3 * (ch + cs) - 200,
                RotateAngle = 270,
                Annotations = new AnnotationCollection
                {
                    new AnnotationEditorViewModel
                    {
                        Content      = "PERIOD",
                        ViewTemplate = MakeTextTemplate("#212121", 14, bold: true),
                        ReadOnly     = true
                    }
                },
                ShapeStyle = MakeLabelStyle("Transparent", "Transparent"),

            });

            // ✅ Period number boxes (1-7) — now GroupPeriodNodeViewModel for click detection
            for (int p = 0; p < 7; p++)
            {
                string fill = p % 2 == 0 ? "#c5d8f0" : "#eef3fb";
                string stroke = "#92b4d8";

                Nodes.Add(new GroupPeriodNodeViewModel
                {
                    Number = p + 1,
                    IsGroup = false,
                    UnitWidth = 25,
                    UnitHeight = 58,
                    OffsetX = sx - (cw + cs) * 0.55 + 10,
                    OffsetY = sy + p * (ch + cs) + ch / 2,
                    Shape = new System.Windows.Media.RectangleGeometry(
                                     new Rect(0, 0, 1, 1), 0.15, 0.15),
                    Annotations = new AnnotationCollection
                    {
                        new AnnotationEditorViewModel
                        {
                            Content      = (p + 1).ToString(),
                            ViewTemplate = MakeTextTemplate("#3a5fa8", 11, bold: true),
                            ReadOnly     = true
                        }
                    },
                    ShapeStyle = MakeLabelStyle(fill, stroke),

                    Constraints = NodeConstraints.Default
                                  & ~NodeConstraints.Resizable
                                  & ~NodeConstraints.Rotatable
                                  & ~NodeConstraints.Delete
                                  & ~NodeConstraints.InConnect
                                  & ~NodeConstraints.OutConnect
                });
            }

            // Group number boxes (1-18)
            for (int g = 0; g < 18; g++)
            {
                string fill = g % 2 == 0 ? "#c5d8f0" : "#eef3fb";
                string stroke = "#92b4d8";

                Nodes.Add(new GroupPeriodNodeViewModel
                {
                    Number = g + 1,
                    IsGroup = true,
                    UnitWidth = 58,
                    UnitHeight = 22,
                    OffsetX = sx + g * (cw + cs) + cw / 2,
                    OffsetY = sy - (ch + cs) * 0.48 - 10,
                    Shape = new System.Windows.Media.RectangleGeometry(
                                     new Rect(0, 0, 1, 1), 0.15, 0.15),
                    Annotations = new AnnotationCollection
                    {
                        new AnnotationEditorViewModel
                        {
                            Content      = (g + 1).ToString(),
                            ViewTemplate = MakeTextTemplate("#3a5fa8", 10, bold: true),
                            ReadOnly     = true
                        }
                    },
                    ShapeStyle = MakeLabelStyle(fill, stroke),

                    Constraints = NodeConstraints.Default
                                  & ~NodeConstraints.Selectable
                                  & ~NodeConstraints.Resizable
                                  & ~NodeConstraints.Rotatable
                                  & ~NodeConstraints.Delete
                                  & ~NodeConstraints.InConnect
                                  & ~NodeConstraints.OutConnect
                });
            }

            // Title
            Nodes.Add(new NodeViewModel
            {
                UnitWidth = 500,
                UnitHeight = 35,
                OffsetX = sx + 9 * (cw + cs),
                OffsetY = sy - 110,
                Annotations = new AnnotationCollection
                {
                    new AnnotationEditorViewModel
                    {
                        Content      = "Periodic Table of Elements",
                        ViewTemplate = MakeTextTemplate("#212121", 24, bold: true),
                        ReadOnly     = true
                    }
                },
                ShapeStyle = MakeLabelStyle("Transparent", "Transparent"),
                Constraints = NodeConstraints.None
            });
        }

        private void AddLegendNodes()
        {
            double cw = ElementNodeViewModel.CellWidth;
            double ch = ElementNodeViewModel.CellHeight;
            double cs = ElementNodeViewModel.CellSpacing;
            double sx = ElementNodeViewModel.StartX;
            double sy = ElementNodeViewModel.StartY;

            var legendData = new[]
            {
                ("alkali-metals",         "Alkali metals"),
                ("alkaline-earth-metals", "Alkaline earth metals"),
                ("transition-metals",     "Transition metals"),
                ("other-metals",          "Other metals"),
                ("metalloids",            "Metalloids"),
                ("non-metals",            "Non-metals"),
                ("halogens",              "Halogens"),
                ("noble-gases",           "Noble gases"),
                ("lanthanides",           "Lanthanides"),
                ("actinides",             "Actinides")
            };

            double legendStartY = sy + 10 * (ch + cs) + 70 + ElementNodeViewModel.FBlockExtraY - (ch + cs);
            double legendItemW = 170, legendItemH = 20, legendSp = 10;
            int rowItems = 5;
            double totalW = rowItems * legendItemW + (rowItems - 1) * legendSp;
            double tableCenterX = sx + 9 * (cw + cs);
            double legendStartX = tableCenterX - totalW / 2;

            for (int i = 0; i < legendData.Length; i++)
            {
                var (cat, label) = legendData[i];
                int row = i / 5, col = i % 5;
                double lx = legendStartX + col * (legendItemW + legendSp);
                double ly = legendStartY + row * (legendItemH + legendSp) - 130;
                string color = CategoryColors[cat];
                if (i > 4) ly += 10;

                // Color dot
                Nodes.Add(new NodeViewModel
                {
                    UnitWidth = 28,
                    UnitHeight = 28,
                    OffsetX = lx + 10,
                    OffsetY = ly + legendItemH / 2 + 10,
                    Shape = new System.Windows.Media.EllipseGeometry(
                                     new Point(0.5, 0.5), 0.5, 0.5),
                    ShapeStyle = MakeStyle(color, color, 0),
                    Constraints = NodeConstraints.None
                });

                // Label text
                Nodes.Add(new NodeViewModel
                {
                    UnitWidth = 140,
                    UnitHeight = legendItemH,
                    OffsetX = lx + 90,
                    OffsetY = ly + legendItemH / 2 + 10,
                    Annotations = new AnnotationCollection
                    {
                        new AnnotationEditorViewModel
                        {
                            Content      = label,
                            ViewTemplate = MakeTextTemplate("#212121", 13),
                            ReadOnly     = true
                        }
                    },
                    ShapeStyle = MakeStyle("Transparent", "#212121", 13),
                    Constraints = NodeConstraints.None
                });
            }
        }

        private void AddBlockLabelsAndConnectors()
        {
            double cw = ElementNodeViewModel.CellWidth;
            double ch = ElementNodeViewModel.CellHeight;
            double cs = ElementNodeViewModel.CellSpacing;
            double sx = ElementNodeViewModel.StartX;
            double sy = ElementNodeViewModel.StartY;
            double fExtra = ElementNodeViewModel.FBlockExtraY;

            AddBlockLabel("s_block", "S Block",
                sx + (cw + cs) - 5, sy - 20, "port_s1", "port_s2");

            AddBlockLabel("p_block", "P Block",
                sx + 15 * (cw + cs) - 5, sy - 20, "port_p1", "port_p2");

            AddBlockLabel("d_block", "D Block",
                sx + 7 * (cw + cs) - 5, sy + 3 * (ch + cs) - 20, "port_d1", "port_d2");

            double fLabelX = sx + 2 * (cw + cs) - 95;
            double fLabelY = sy + 5 * (ch + cs) + fExtra + ch / 2 + (ch + cs) / 2;

            Nodes.Add(new NodeViewModel
            {
                ID = "f_block",
                UnitWidth = 70,
                UnitHeight = 15,
                OffsetX = fLabelX + 60,
                OffsetY = fLabelY,
                RotateAngle = 270,
                Annotations = new AnnotationCollection
                {
                    new AnnotationEditorViewModel
                    {
                        Content      = "F Block",
                        ViewTemplate = MakeTextTemplate("#555555", 14, bold: true),
                        ReadOnly     = true
                    }
                },
                ShapeStyle = MakeStyle("Transparent", "#555555", 14, bold: true),
                Constraints = NodeConstraints.None,
                PortVisibility = PortVisibility.Collapse,
                Ports = new PortCollection
                {
                    new NodePortViewModel { ID = "port_f1", NodeOffsetX = 1, NodeOffsetY = 0.5 },
                    new NodePortViewModel { ID = "port_f2", NodeOffsetX = 0, NodeOffsetY = 0.5 }
                }
            });

            AddBracketConnectors(sx, sy, cw, ch, cs, fExtra, fLabelX, fLabelY);
        }

        private void AddBracketConnectors(double sx, double sy,
            double cw, double ch, double cs, double fExtra,
            double fLabelX, double fLabelY)
        {
            AddOrthConnector("s_block", "port_s1",
                new Point(sx, sy - 10));
            AddOrthConnector("s_block", "port_s2",
                new Point(sx + (cw + cs) * 2, sy - 10));

            AddOrthConnector("p_block", "port_p1",
                new Point(sx + 12 * (cw + cs), sy - 10));
            AddOrthConnector("p_block", "port_p2",
                new Point(sx + 18 * (cw + cs) - 10, sy - 10));

            AddOrthConnector("d_block", "port_d1",
                new Point(sx + 2 * (cw + cs), sy + 3 * (ch + cs) - 10));
            AddOrthConnector("d_block", "port_d2",
                new Point(sx + 12 * (cw + cs) - 10, sy + 3 * (ch + cs) - 10));

            double lanthanideY = sy + 5 * (ch + cs) + fExtra + ch / 2;
            double actinideY = sy + 6 * (ch + cs) + fExtra + ch / 2;
            double fBracketX = fLabelX + 30;

            BottomAddOrthConnector("f_block", "port_f1",
                new Point(fBracketX + 45, lanthanideY - ch / 2 + 5));
            TopAddOrthConnector("f_block", "port_f2",
                new Point(fBracketX + 45, actinideY + ch / 2 - 5));
        }

        private void AddBlockLabel(string id, string text, double x, double y,
                                    string p1Id, string p2Id)
        {
            Nodes.Add(new NodeViewModel
            {
                ID = id,
                UnitWidth = 70,
                UnitHeight = 15,
                OffsetX = x,
                OffsetY = y,
                Annotations = new AnnotationCollection
                {
                    new AnnotationEditorViewModel
                    {
                        Content      = text,
                        ViewTemplate = MakeTextTemplate("#555555", 14, bold: true),
                        ReadOnly     = true
                    }
                },
                ShapeStyle = MakeStyle("Transparent", "#555555", 14, bold: true),
                Constraints = NodeConstraints.None,
                PortVisibility = PortVisibility.Collapse,
                Ports = new PortCollection
                {
                    new NodePortViewModel { ID = p1Id, NodeOffsetX = 0, NodeOffsetY = 0.5 },
                    new NodePortViewModel { ID = p2Id, NodeOffsetX = 1, NodeOffsetY = 0.5 }
                }
            });
        }

        private void AddOrthConnector(string srcId, string portId, Point target)
        {
            Connectors.Add(new ConnectorViewModel
            {
                SourceNodeID = srcId,
                SourcePortID = portId,
                TargetPoint = target,
                Segments = new ObservableCollection<IConnectorSegment>
                {
                    new OrthogonalSegment { Direction = OrthogonalDirection.Right, Length = 100 }
                },
                Constraints = ConnectorConstraints.None,
                ConnectorGeometryStyle = MakeConnectorStyle("#555555")
            });
        }

        private void BottomAddOrthConnector(string srcId, string portId, Point target)
        {
            Connectors.Add(new ConnectorViewModel
            {
                SourceNodeID = srcId,
                SourcePortID = portId,
                TargetPoint = target,
                Segments = new ObservableCollection<IConnectorSegment>
                {
                    new OrthogonalSegment { Direction = OrthogonalDirection.Bottom, Length = 100 }
                },
                Constraints = ConnectorConstraints.None,
                ConnectorGeometryStyle = MakeConnectorStyle("#555555")
            });
        }

        private void TopAddOrthConnector(string srcId, string portId, Point target)
        {
            Connectors.Add(new ConnectorViewModel
            {
                SourceNodeID = srcId,
                SourcePortID = portId,
                TargetPoint = target,
                Segments = new ObservableCollection<IConnectorSegment>
                {
                    new OrthogonalSegment { Direction = OrthogonalDirection.Top, Length = 100 }
                },
                Constraints = ConnectorConstraints.None,
                ConnectorGeometryStyle = MakeConnectorStyle("#555555")
            });
        }

        private static System.Windows.Style MakeConnectorStyle(string hex)
        {
            var style = new System.Windows.Style(typeof(System.Windows.Shapes.Path));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeProperty,
                new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex))));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeThicknessProperty, 2.0));
            return style;
        }

        private static DataTemplate MakeTextTemplate(string color, double fontSize, bool bold = false)
        {
            var template = new DataTemplate();
            var factory = new FrameworkElementFactory(typeof(TextBlock));
            factory.SetValue(TextBlock.ForegroundProperty,
                new SolidColorBrush((Color)ColorConverter.ConvertFromString(color)));
            factory.SetValue(TextBlock.FontSizeProperty, fontSize);
            factory.SetValue(TextBlock.FontFamilyProperty, new FontFamily("Segoe UI"));
            factory.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            factory.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            factory.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Center);
            if (bold)
                factory.SetValue(TextBlock.FontWeightProperty, FontWeights.Light);
            factory.SetBinding(TextBlock.TextProperty, new Binding("Content"));
            template.VisualTree = factory;
            template.Seal();
            return template;
        }

        private static System.Windows.Style MakeLabelStyle(string fill, string stroke)
        {
            var style = new System.Windows.Style(typeof(System.Windows.Shapes.Path));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.FillProperty,
                fill == "Transparent"
                    ? (Brush)Brushes.Transparent
                    : new SolidColorBrush((Color)ColorConverter.ConvertFromString(fill))));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeProperty,
                stroke == "Transparent"
                    ? (Brush)Brushes.Transparent
                    : new SolidColorBrush((Color)ColorConverter.ConvertFromString(stroke))));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeThicknessProperty, 1.0));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StretchProperty, Stretch.Fill));
            return style;
        }

        private static System.Windows.Style MakeStyle(string fill, string foreground,
            double fontSize, bool bold = false)
        {
            var style = new System.Windows.Style(typeof(System.Windows.Shapes.Path));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.FillProperty,
                fill == "Transparent"
                    ? (Brush)Brushes.Transparent
                    : new SolidColorBrush((Color)ColorConverter.ConvertFromString(fill))));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeProperty, Brushes.Transparent));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeThicknessProperty, 0.0));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StretchProperty, Stretch.Fill));
            return style;
        }

        private static IEnumerable<ElementModel> GetPeriodicTableData() => new[]
        {
            // Period 1
            new ElementModel { AtomicNumber=1,  Symbol="H",  Name="Hydrogen",     Period=1, Group=1,  Category="non-metals",           AtomicMass=1.008 },
            new ElementModel { AtomicNumber=2,  Symbol="He", Name="Helium",       Period=1, Group=18, Category="noble-gases",          AtomicMass=4.0026 },
            // Period 2
            new ElementModel { AtomicNumber=3,  Symbol="Li", Name="Lithium",      Period=2, Group=1,  Category="alkali-metals",        AtomicMass=6.94 },
            new ElementModel { AtomicNumber=4,  Symbol="Be", Name="Beryllium",    Period=2, Group=2,  Category="alkaline-earth-metals",AtomicMass=9.0122 },
            new ElementModel { AtomicNumber=5,  Symbol="B",  Name="Boron",        Period=2, Group=13, Category="metalloids",           AtomicMass=10.81 },
            new ElementModel { AtomicNumber=6,  Symbol="C",  Name="Carbon",       Period=2, Group=14, Category="non-metals",           AtomicMass=12.011 },
            new ElementModel { AtomicNumber=7,  Symbol="N",  Name="Nitrogen",     Period=2, Group=15, Category="non-metals",           AtomicMass=14.007 },
            new ElementModel { AtomicNumber=8,  Symbol="O",  Name="Oxygen",       Period=2, Group=16, Category="non-metals",           AtomicMass=15.999 },
            new ElementModel { AtomicNumber=9,  Symbol="F",  Name="Fluorine",     Period=2, Group=17, Category="halogens",             AtomicMass=18.998 },
            new ElementModel { AtomicNumber=10, Symbol="Ne", Name="Neon",         Period=2, Group=18, Category="noble-gases",          AtomicMass=20.18 },
            // Period 3
            new ElementModel { AtomicNumber=11, Symbol="Na", Name="Sodium",       Period=3, Group=1,  Category="alkali-metals",        AtomicMass=22.99 },
            new ElementModel { AtomicNumber=12, Symbol="Mg", Name="Magnesium",    Period=3, Group=2,  Category="alkaline-earth-metals",AtomicMass=24.305 },
            new ElementModel { AtomicNumber=13, Symbol="Al", Name="Aluminum",     Period=3, Group=13, Category="other-metals",         AtomicMass=26.982 },
            new ElementModel { AtomicNumber=14, Symbol="Si", Name="Silicon",      Period=3, Group=14, Category="metalloids",           AtomicMass=28.085 },
            new ElementModel { AtomicNumber=15, Symbol="P",  Name="Phosphorus",   Period=3, Group=15, Category="non-metals",           AtomicMass=30.974 },
            new ElementModel { AtomicNumber=16, Symbol="S",  Name="Sulfur",       Period=3, Group=16, Category="non-metals",           AtomicMass=32.06 },
            new ElementModel { AtomicNumber=17, Symbol="Cl", Name="Chlorine",     Period=3, Group=17, Category="halogens",             AtomicMass=35.45 },
            new ElementModel { AtomicNumber=18, Symbol="Ar", Name="Argon",        Period=3, Group=18, Category="noble-gases",          AtomicMass=39.948 },
            // Period 4
            new ElementModel { AtomicNumber=19, Symbol="K",  Name="Potassium",    Period=4, Group=1,  Category="alkali-metals",        AtomicMass=39.098 },
            new ElementModel { AtomicNumber=20, Symbol="Ca", Name="Calcium",      Period=4, Group=2,  Category="alkaline-earth-metals",AtomicMass=40.078 },
            new ElementModel { AtomicNumber=21, Symbol="Sc", Name="Scandium",     Period=4, Group=3,  Category="transition-metals",    AtomicMass=44.956 },
            new ElementModel { AtomicNumber=22, Symbol="Ti", Name="Titanium",     Period=4, Group=4,  Category="transition-metals",    AtomicMass=47.867 },
            new ElementModel { AtomicNumber=23, Symbol="V",  Name="Vanadium",     Period=4, Group=5,  Category="transition-metals",    AtomicMass=50.942 },
            new ElementModel { AtomicNumber=24, Symbol="Cr", Name="Chromium",     Period=4, Group=6,  Category="transition-metals",    AtomicMass=51.996 },
            new ElementModel { AtomicNumber=25, Symbol="Mn", Name="Manganese",    Period=4, Group=7,  Category="transition-metals",    AtomicMass=54.938 },
            new ElementModel { AtomicNumber=26, Symbol="Fe", Name="Iron",         Period=4, Group=8,  Category="transition-metals",    AtomicMass=55.845 },
            new ElementModel { AtomicNumber=27, Symbol="Co", Name="Cobalt",       Period=4, Group=9,  Category="transition-metals",    AtomicMass=58.933 },
            new ElementModel { AtomicNumber=28, Symbol="Ni", Name="Nickel",       Period=4, Group=10, Category="transition-metals",    AtomicMass=58.693 },
            new ElementModel { AtomicNumber=29, Symbol="Cu", Name="Copper",       Period=4, Group=11, Category="transition-metals",    AtomicMass=63.546 },
            new ElementModel { AtomicNumber=30, Symbol="Zn", Name="Zinc",         Period=4, Group=12, Category="transition-metals",    AtomicMass=65.38 },
            new ElementModel { AtomicNumber=31, Symbol="Ga", Name="Gallium",      Period=4, Group=13, Category="other-metals",         AtomicMass=69.723 },
            new ElementModel { AtomicNumber=32, Symbol="Ge", Name="Germanium",    Period=4, Group=14, Category="metalloids",           AtomicMass=72.63 },
            new ElementModel { AtomicNumber=33, Symbol="As", Name="Arsenic",      Period=4, Group=15, Category="metalloids",           AtomicMass=74.922 },
            new ElementModel { AtomicNumber=34, Symbol="Se", Name="Selenium",     Period=4, Group=16, Category="non-metals",           AtomicMass=78.971 },
            new ElementModel { AtomicNumber=35, Symbol="Br", Name="Bromine",      Period=4, Group=17, Category="halogens",             AtomicMass=79.904 },
            new ElementModel { AtomicNumber=36, Symbol="Kr", Name="Krypton",      Period=4, Group=18, Category="noble-gases",          AtomicMass=83.798 },
            // Period 5
            new ElementModel { AtomicNumber=37, Symbol="Rb", Name="Rubidium",     Period=5, Group=1,  Category="alkali-metals",        AtomicMass=85.468 },
            new ElementModel { AtomicNumber=38, Symbol="Sr", Name="Strontium",    Period=5, Group=2,  Category="alkaline-earth-metals",AtomicMass=87.62 },
            new ElementModel { AtomicNumber=39, Symbol="Y",  Name="Yttrium",      Period=5, Group=3,  Category="transition-metals",    AtomicMass=88.906 },
            new ElementModel { AtomicNumber=40, Symbol="Zr", Name="Zirconium",    Period=5, Group=4,  Category="transition-metals",    AtomicMass=91.224 },
            new ElementModel { AtomicNumber=41, Symbol="Nb", Name="Niobium",      Period=5, Group=5,  Category="transition-metals",    AtomicMass=92.906 },
            new ElementModel { AtomicNumber=42, Symbol="Mo", Name="Molybdenum",   Period=5, Group=6,  Category="transition-metals",    AtomicMass=95.95 },
            new ElementModel { AtomicNumber=43, Symbol="Tc", Name="Technetium",   Period=5, Group=7,  Category="transition-metals",    AtomicMass=98.0 },
            new ElementModel { AtomicNumber=44, Symbol="Ru", Name="Ruthenium",    Period=5, Group=8,  Category="transition-metals",    AtomicMass=101.07 },
            new ElementModel { AtomicNumber=45, Symbol="Rh", Name="Rhodium",      Period=5, Group=9,  Category="transition-metals",    AtomicMass=102.91 },
            new ElementModel { AtomicNumber=46, Symbol="Pd", Name="Palladium",    Period=5, Group=10, Category="transition-metals",    AtomicMass=106.42 },
            new ElementModel { AtomicNumber=47, Symbol="Ag", Name="Silver",       Period=5, Group=11, Category="transition-metals",    AtomicMass=107.87 },
            new ElementModel { AtomicNumber=48, Symbol="Cd", Name="Cadmium",      Period=5, Group=12, Category="transition-metals",    AtomicMass=112.41 },
            new ElementModel { AtomicNumber=49, Symbol="In", Name="Indium",       Period=5, Group=13, Category="other-metals",         AtomicMass=114.82 },
            new ElementModel { AtomicNumber=50, Symbol="Sn", Name="Tin",          Period=5, Group=14, Category="other-metals",         AtomicMass=118.71 },
            new ElementModel { AtomicNumber=51, Symbol="Sb", Name="Antimony",     Period=5, Group=15, Category="metalloids",           AtomicMass=121.76 },
            new ElementModel { AtomicNumber=52, Symbol="Te", Name="Tellurium",    Period=5, Group=16, Category="metalloids",           AtomicMass=127.6 },
            new ElementModel { AtomicNumber=53, Symbol="I",  Name="Iodine",       Period=5, Group=17, Category="halogens",             AtomicMass=126.9 },
            new ElementModel { AtomicNumber=54, Symbol="Xe", Name="Xenon",        Period=5, Group=18, Category="noble-gases",          AtomicMass=131.29 },
            // Period 6
            new ElementModel { AtomicNumber=55, Symbol="Cs", Name="Cesium",       Period=6, Group=1,  Category="alkali-metals",        AtomicMass=132.91 },
            new ElementModel { AtomicNumber=56, Symbol="Ba", Name="Barium",       Period=6, Group=2,  Category="alkaline-earth-metals",AtomicMass=137.33 },
            new ElementModel { AtomicNumber=0,  Symbol="57-71", Name="Lanthanides",Period=6, Group=3, Category="lanthanides" },
            new ElementModel { AtomicNumber=72, Symbol="Hf", Name="Hafnium",      Period=6, Group=4,  Category="transition-metals",    AtomicMass=178.49 },
            new ElementModel { AtomicNumber=73, Symbol="Ta", Name="Tantalum",     Period=6, Group=5,  Category="transition-metals",    AtomicMass=180.95 },
            new ElementModel { AtomicNumber=74, Symbol="W",  Name="Tungsten",     Period=6, Group=6,  Category="transition-metals",    AtomicMass=183.84 },
            new ElementModel { AtomicNumber=75, Symbol="Re", Name="Rhenium",      Period=6, Group=7,  Category="transition-metals",    AtomicMass=186.21 },
            new ElementModel { AtomicNumber=76, Symbol="Os", Name="Osmium",       Period=6, Group=8,  Category="transition-metals",    AtomicMass=190.23 },
            new ElementModel { AtomicNumber=77, Symbol="Ir", Name="Iridium",      Period=6, Group=9,  Category="transition-metals",    AtomicMass=192.22 },
            new ElementModel { AtomicNumber=78, Symbol="Pt", Name="Platinum",     Period=6, Group=10, Category="transition-metals",    AtomicMass=195.08 },
            new ElementModel { AtomicNumber=79, Symbol="Au", Name="Gold",         Period=6, Group=11, Category="transition-metals",    AtomicMass=196.97 },
            new ElementModel { AtomicNumber=80, Symbol="Hg", Name="Mercury",      Period=6, Group=12, Category="transition-metals",    AtomicMass=200.59 },
            new ElementModel { AtomicNumber=81, Symbol="Tl", Name="Thallium",     Period=6, Group=13, Category="other-metals",         AtomicMass=204.38 },
            new ElementModel { AtomicNumber=82, Symbol="Pb", Name="Lead",         Period=6, Group=14, Category="other-metals",         AtomicMass=207.2 },
            new ElementModel { AtomicNumber=83, Symbol="Bi", Name="Bismuth",      Period=6, Group=15, Category="other-metals",         AtomicMass=208.98 },
            new ElementModel { AtomicNumber=84, Symbol="Po", Name="Polonium",     Period=6, Group=16, Category="metalloids",           AtomicMass=209.0 },
            new ElementModel { AtomicNumber=85, Symbol="At", Name="Astatine",     Period=6, Group=17, Category="halogens",             AtomicMass=210.0 },
            new ElementModel { AtomicNumber=86, Symbol="Rn", Name="Radon",        Period=6, Group=18, Category="noble-gases",          AtomicMass=222.0 },
            // Period 7
            new ElementModel { AtomicNumber=87,  Symbol="Fr",  Name="Francium",     Period=7, Group=1,  Category="alkali-metals",        AtomicMass=223.0 },
            new ElementModel { AtomicNumber=88,  Symbol="Ra",  Name="Radium",       Period=7, Group=2,  Category="alkaline-earth-metals",AtomicMass=226.0 },
            new ElementModel { AtomicNumber=0,   Symbol="89-103",Name="Actinides",   Period=7, Group=3,  Category="actinides" },
            new ElementModel { AtomicNumber=104, Symbol="Rf",  Name="Rutherfordium",Period=7, Group=4,  Category="transition-metals",    AtomicMass=267.0 },
            new ElementModel { AtomicNumber=105, Symbol="Db",  Name="Dubnium",      Period=7, Group=5,  Category="transition-metals",    AtomicMass=270.0 },
            new ElementModel { AtomicNumber=106, Symbol="Sg",  Name="Seaborgium",   Period=7, Group=6,  Category="transition-metals",    AtomicMass=271.0 },
            new ElementModel { AtomicNumber=107, Symbol="Bh",  Name="Bohrium",      Period=7, Group=7,  Category="transition-metals",    AtomicMass=270.0 },
            new ElementModel { AtomicNumber=108, Symbol="Hs",  Name="Hassium",      Period=7, Group=8,  Category="transition-metals",    AtomicMass=277.0 },
            new ElementModel { AtomicNumber=109, Symbol="Mt",  Name="Meitnerium",   Period=7, Group=9,  Category="transition-metals",    AtomicMass=276.0 },
            new ElementModel { AtomicNumber=110, Symbol="Ds",  Name="Darmstadtium", Period=7, Group=10, Category="transition-metals",    AtomicMass=281.0 },
            new ElementModel { AtomicNumber=111, Symbol="Rg",  Name="Roentgenium",  Period=7, Group=11, Category="transition-metals",    AtomicMass=282.0 },
            new ElementModel { AtomicNumber=112, Symbol="Cn",  Name="Copernicium",  Period=7, Group=12, Category="transition-metals",    AtomicMass=285.0 },
            new ElementModel { AtomicNumber=113, Symbol="Nh",  Name="Nihonium",     Period=7, Group=13, Category="other-metals",         AtomicMass=286.0 },
            new ElementModel { AtomicNumber=114, Symbol="Fl",  Name="Flerovium",    Period=7, Group=14, Category="other-metals",         AtomicMass=289.0 },
            new ElementModel { AtomicNumber=115, Symbol="Mc",  Name="Moscovium",    Period=7, Group=15, Category="other-metals",         AtomicMass=290.0 },
            new ElementModel { AtomicNumber=116, Symbol="Lv",  Name="Livermorium",  Period=7, Group=16, Category="other-metals",         AtomicMass=293.0 },
            new ElementModel { AtomicNumber=117, Symbol="Ts",  Name="Tennessine",   Period=7, Group=17, Category="halogens",             AtomicMass=294.0 },
            new ElementModel { AtomicNumber=118, Symbol="Og",  Name="Oganesson",    Period=7, Group=18, Category="noble-gases",          AtomicMass=294.0 },
            // Lanthanides
            new ElementModel { AtomicNumber=57,  Symbol="La",  Name="Lanthanum",    Period=6, Group=3,  Category="lanthanides", AtomicMass=138.91,  Block="f" },
            new ElementModel { AtomicNumber=58,  Symbol="Ce",  Name="Cerium",       Period=6, Group=4,  Category="lanthanides", AtomicMass=140.12,  Block="f" },
            new ElementModel { AtomicNumber=59,  Symbol="Pr",  Name="Praseodymium", Period=6, Group=5,  Category="lanthanides", AtomicMass=140.91,  Block="f" },
            new ElementModel { AtomicNumber=60,  Symbol="Nd",  Name="Neodymium",    Period=6, Group=6,  Category="lanthanides", AtomicMass=144.24,  Block="f" },
            new ElementModel { AtomicNumber=61,  Symbol="Pm",  Name="Promethium",   Period=6, Group=7,  Category="lanthanides", AtomicMass=145.0,   Block="f" },
            new ElementModel { AtomicNumber=62,  Symbol="Sm",  Name="Samarium",     Period=6, Group=8,  Category="lanthanides", AtomicMass=150.36,  Block="f" },
            new ElementModel { AtomicNumber=63,  Symbol="Eu",  Name="Europium",     Period=6, Group=9,  Category="lanthanides", AtomicMass=151.96,  Block="f" },
            new ElementModel { AtomicNumber=64,  Symbol="Gd",  Name="Gadolinium",   Period=6, Group=10, Category="lanthanides", AtomicMass=157.25,  Block="f" },
            new ElementModel { AtomicNumber=65,  Symbol="Tb",  Name="Terbium",      Period=6, Group=11, Category="lanthanides", AtomicMass=158.93,  Block="f" },
            new ElementModel { AtomicNumber=66,  Symbol="Dy",  Name="Dysprosium",   Period=6, Group=12, Category="lanthanides", AtomicMass=162.5,   Block="f" },
            new ElementModel { AtomicNumber=67,  Symbol="Ho",  Name="Holmium",      Period=6, Group=13, Category="lanthanides", AtomicMass=164.93,  Block="f" },
            new ElementModel { AtomicNumber=68,  Symbol="Er",  Name="Erbium",       Period=6, Group=14, Category="lanthanides", AtomicMass=167.26,  Block="f" },
            new ElementModel { AtomicNumber=69,  Symbol="Tm",  Name="Thulium",      Period=6, Group=15, Category="lanthanides", AtomicMass=168.93,  Block="f" },
            new ElementModel { AtomicNumber=70,  Symbol="Yb",  Name="Ytterbium",    Period=6, Group=16, Category="lanthanides", AtomicMass=173.05,  Block="f" },
            new ElementModel { AtomicNumber=71,  Symbol="Lu",  Name="Lutetium",     Period=6, Group=17, Category="lanthanides", AtomicMass=174.97,  Block="f" },
            // Actinides
            new ElementModel { AtomicNumber=89,  Symbol="Ac",  Name="Actinium",     Period=7, Group=3,  Category="actinides",   AtomicMass=227.0,   Block="f" },
            new ElementModel { AtomicNumber=90,  Symbol="Th",  Name="Thorium",      Period=7, Group=4,  Category="actinides",   AtomicMass=232.04,  Block="f" },
            new ElementModel { AtomicNumber=91,  Symbol="Pa",  Name="Protactinium", Period=7, Group=5,  Category="actinides",   AtomicMass=231.04,  Block="f" },
            new ElementModel { AtomicNumber=92,  Symbol="U",   Name="Uranium",      Period=7, Group=6,  Category="actinides",   AtomicMass=238.03,  Block="f" },
            new ElementModel { AtomicNumber=93,  Symbol="Np",  Name="Neptunium",    Period=7, Group=7,  Category="actinides",   AtomicMass=237.0,   Block="f" },
            new ElementModel { AtomicNumber=94,  Symbol="Pu",  Name="Plutonium",    Period=7, Group=8,  Category="actinides",   AtomicMass=244.0,   Block="f" },
            new ElementModel { AtomicNumber=95,  Symbol="Am",  Name="Americium",    Period=7, Group=9,  Category="actinides",   AtomicMass=243.0,   Block="f" },
            new ElementModel { AtomicNumber=96,  Symbol="Cm",  Name="Curium",       Period=7, Group=10, Category="actinides",   AtomicMass=247.0,   Block="f" },
            new ElementModel { AtomicNumber=97,  Symbol="Bk",  Name="Berkelium",    Period=7, Group=11, Category="actinides",   AtomicMass=247.0,   Block="f" },
            new ElementModel { AtomicNumber=98,  Symbol="Cf",  Name="Californium",  Period=7, Group=12, Category="actinides",   AtomicMass=251.0,   Block="f" },
            new ElementModel { AtomicNumber=99,  Symbol="Es",  Name="Einsteinium",  Period=7, Group=13, Category="actinides",   AtomicMass=252.0,   Block="f" },
            new ElementModel { AtomicNumber=100, Symbol="Fm",  Name="Fermium",      Period=7, Group=14, Category="actinides",   AtomicMass=257.0,   Block="f" },
            new ElementModel { AtomicNumber=101, Symbol="Md",  Name="Mendelevium",  Period=7, Group=15, Category="actinides",   AtomicMass=258.0,   Block="f" },
            new ElementModel { AtomicNumber=102, Symbol="No",  Name="Nobelium",     Period=7, Group=16, Category="actinides",   AtomicMass=259.0,   Block="f" },
            new ElementModel { AtomicNumber=103, Symbol="Lr",  Name="Lawrencium",   Period=7, Group=17, Category="actinides",   AtomicMass=262.0,   Block="f" },
        };
    }

    public class ElementModel
    {
        public int? AtomicNumber { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int Period { get; set; }
        public int Group { get; set; }
        public string Category { get; set; }
        public double? AtomicMass { get; set; }
        public string Block { get; set; }
        public bool IsFBlock => Block == "f";
        public bool IsPlaceholder => AtomicNumber == null;
    }
    public class GroupPeriodNodeViewModel : NodeViewModel
    {
        public int Number { get; set; }
        public bool IsGroup { get; set; }
    }

    public class ElementNodeViewModel : NodeViewModel, INotifyPropertyChanged
    {
        public const double CellWidth = 60;
        public const double CellHeight = 60;
        public const double CellSpacing = 10;
        public const double StartX = 70;
        public const double StartY = 100;
        public const double FBlockExtraY = 2 * (CellHeight + CellSpacing) + CellHeight / 2 + 30;

        private bool _isHovered;
        private bool _isBlurred;
        private double _normalWidth;
        private double _normalHeight;
        private string _fillColor;

        public ElementModel Element { get; }
        public string AtomicNumberText => Element.AtomicNumber?.ToString() ?? string.Empty;
        public string SymbolText => Element.Symbol;
        public string NameText => Element.Name;
        public string AtomicMassText => Element.AtomicMass?.ToString("G4") ?? string.Empty;
        public string CategoryText => Element.Category;
        public bool IsElementNode { get; }

        public string FillColor
        {
            get => _fillColor;
            set { _fillColor = value; OnPropertyChanged(); }
        }

        public bool IsHovered
        {
            get => _isHovered;
            set
            {
                if (_isHovered == value) return;
                _isHovered = value;
                OnPropertyChanged();
                ApplyHoverScale(value);
            }
        }
        public bool IsBlurred
        {
            get => _isBlurred;
            set
            {
                if (_isBlurred == value) return;
                _isBlurred = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ElementNodeViewModel(ElementModel element, string color) : base()
        {
            Element = element;
            FillColor = color;
            IsElementNode = !element.IsPlaceholder;

            var (x, y) = CalculatePosition(element);

            _normalWidth = CellWidth;
            _normalHeight = CellHeight;

            UnitWidth = _normalWidth;
            UnitHeight = _normalHeight;
            OffsetX = x + CellWidth / 2;
            OffsetY = y + CellHeight / 2;

            ShapeStyle = MakeTransparentStyle();
            Constraints = NodeConstraints.Default
                          & ~NodeConstraints.Selectable
                          & ~NodeConstraints.Resizable
                          & ~NodeConstraints.Rotatable
                          & ~NodeConstraints.Delete;
        }

        public ElementNodeViewModel() { }

        private static System.Windows.Style MakeTransparentStyle()
        {
            var style = new System.Windows.Style(typeof(System.Windows.Shapes.Path));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.FillProperty, System.Windows.Media.Brushes.Transparent));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeProperty, System.Windows.Media.Brushes.Transparent));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeThicknessProperty, 0.0));
            return style;
        }

        private static (double x, double y) CalculatePosition(ElementModel element)
        {
            double x = StartX + (element.Group - 1) * (CellWidth + CellSpacing);
            double y = StartY + (element.Period - 1) * (CellHeight + CellSpacing);
            if (element.IsFBlock) y += FBlockExtraY;
            return (x, y);
        }

        private void ApplyHoverScale(bool hovered)
        {
            const double scaleFactor = 1.3;
            UnitWidth = hovered ? _normalWidth * scaleFactor : _normalWidth;
            UnitHeight = hovered ? _normalHeight * scaleFactor : _normalHeight;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
