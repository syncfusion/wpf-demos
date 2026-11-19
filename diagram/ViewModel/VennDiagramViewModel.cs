using syncfusion.demoscommon.wpf;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using HorizontalAlignment = System.Windows.HorizontalAlignment;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class VennDiagramViewModel : INotifyPropertyChanged
    {
        #region Properties and fields
        public ObservableCollection<NodeViewModel> Nodes { get; set; }
        public ObservableCollection<ConnectorViewModel> Connectors { get; set; }
         public DemoControl View;

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };
        private ObservableCollection<NodePortViewModel> thesisPorts;
        private ObservableCollection<NodePortViewModel> middlewarePorts;
        private ObservableCollection<NodePortViewModel> assemblyPorts;
        private ObservableCollection<NodePortViewModel> programmingPorts;
        private ObservableCollection<NodePortViewModel> trigonometryPorts;
        private ObservableCollection<NodePortViewModel> expertisePorts;


        // ── Path Data ─────────────────────────────────────────────────────
        private const string AssemblyPath = "M24.3267 27.4281H1.99727C0.894207 27.4281 0 26.551 0 25.469V2.93873C0 1.31571 1.34131 0 2.9959 0H8.10891C8.78495 0.0022957 9.44005 0.230314 9.96637 0.646519L13.9609 3.70279C14.1374 3.83974 14.3551 3.91551 14.5801 3.9183H23.0485C24.7031 3.9183 26.0444 5.23401 26.0444 6.85703V9.79575H29.0003C30.0366 9.80121 30.9975 10.3282 31.5449 11.1913C32.0923 12.0545 32.1496 13.1328 31.6966 14.0471L26.1642 26.331C25.8219 27.0166 25.1048 27.4448 24.3267 27.4281ZM2.61621 25.469H24.3265L29.819 13.2243C30.0052 12.9162 30.0052 12.5331 29.819 12.2251C29.6396 11.9284 29.3118 11.7489 28.9602 11.7549H10.2458C9.86524 11.7587 9.51861 11.9703 9.347 12.3035L2.61621 25.469ZM2.99668 1.95911C2.44515 1.95911 1.99805 2.39768 1.99805 2.93868V22.4126L7.55045 11.5198C8.05333 10.5213 9.0915 9.89056 10.2268 9.89366H23.988V6.95494C23.9773 6.41831 23.5364 5.98579 22.9893 5.97536H14.5209C13.8475 5.97709 13.1932 5.75624 12.6635 5.34844L8.66892 2.27257C8.49247 2.13563 8.27475 2.05985 8.04977 2.05706L2.99668 1.95911Z";
        private const string MiddlewarePath = "M28 12.56V32H8V26H0V0H13.44L19.44 6H21.44L28 12.56ZM8 6H16.58L12.58 2H2V24H8V6ZM26.001 14H20.001V8H10.001V30H26.001V14ZM21.999 12H24.579L21.999 9.41998V12Z";
        private const string ThesisPath = "M22.7097 24.7742L24.7742 22.7097V28.9032H0V8.25806H2.06452V26.8387H22.7097V24.7742ZM20.6452 16.5161C19.2688 16.5161 17.9194 16.6559 16.5968 16.9355C15.2849 17.2043 14.0161 17.6075 12.7903 18.1452C11.5645 18.672 10.3925 19.3226 9.27419 20.0968C8.16667 20.8602 7.13978 21.7312 6.19355 22.7097V20.6452C6.19355 19.3118 6.36559 18.0323 6.70968 16.8065C7.05376 15.5699 7.53763 14.4194 8.16129 13.3548C8.7957 12.2796 9.54839 11.3065 10.4194 10.4355C11.3011 9.55376 12.2742 8.80107 13.3387 8.17742C14.414 7.54301 15.5645 7.05376 16.7903 6.70968C18.0269 6.36559 19.3118 6.19355 20.6452 6.19355V0L32 11.3548L20.6452 22.7097V16.5161ZM22.7097 8.25806C22.0538 8.25806 21.4409 8.26344 20.871 8.27419C20.3011 8.27419 19.7419 8.30107 19.1935 8.35484C18.6559 8.4086 18.1129 8.50538 17.5645 8.64516C17.0161 8.77419 16.4355 8.96774 15.8226 9.22581C14.8871 9.6129 14.0161 10.1075 13.2097 10.7097C12.414 11.3118 11.6989 12 11.0645 12.7742C10.4409 13.5376 9.9086 14.371 9.46774 15.2742C9.03763 16.1667 8.72043 17.1075 8.51613 18.0968C10.3226 16.8925 12.2527 15.9839 14.3065 15.371C16.3602 14.7581 18.4731 14.4516 20.6452 14.4516H22.7097V17.7258L29.0806 11.3548L22.7097 4.98387V8.25806Z";
        private const string CalendarPath = "M2,12.998966L2,26.998974 30,26.998974 30,12.998966z M2,4.9989738L2,10.998966 30,10.998966 30,4.9989738 27,4.9989738 27,6C27,7.1039996 26.105,8 25,8 23.895,8 23,7.1039996 23,6L23,4.9989738 9,4.9989738 9,6C9,7.1039996 8.1049995,8 7,8 5.895,8 5,7.1039996 5,6L5,4.9989738z M7,0C8.1049995,-2.3841858E-07,9,0.89499974,9,2L9,2.9989738 23,2.9989738 23,2C23,0.89499974 23.895,-2.3841858E-07 25,0 26.105,-2.3841858E-07 27,0.89499974 27,2L27,2.9989738 32,2.9989738 32,28.998974 0,28.998974 0,2.9989738 5,2.9989738 5,2C5,0.89499974,5.895,-2.3841858E-07,7,0z";
        private const string NotesPath = "M12,8L12,30 28,30 28,14 22,14 22,8z M10,6L24,6 24,8 26,8 26,10 24,10 24,12 26,12 26,10 28,10 28,12 30,12 30,32 10,32z M0,0L10,0 10,2 12,2 12,4 8,4 8,2 2,2 2,20 8,20 8,22 0,22z";
        private const string PastePath = "M24 32H0V3.99981H8C8.01001 3.469 8.12559 2.94549 8.34 2.4598C8.55076 1.99273 8.84184 1.56626 9.2 1.19979C9.56763 0.828696 10.0019 0.530157 10.48 0.319788C11.4554 -0.106596 12.5646 -0.106596 13.54 0.319788C14.4839 0.757643 15.2421 1.51586 15.68 2.4598C15.8875 2.9469 15.9963 3.47036 16 3.99981H24V32ZM22 11.9999V5.99983H20V9.99985H4V5.99983H2V30H22M6 5.99988V7.99989H18V5.99988H14V4.25987C13.9895 3.96985 13.9493 3.68167 13.88 3.39986C13.816 3.13337 13.7005 2.88198 13.54 2.65986C13.3845 2.4358 13.1791 2.25094 12.94 2.11986C12.6391 2.01205 12.3183 1.9711 12 1.99986C11.5422 1.94796 11.084 2.09343 10.74 2.39986C10.4674 2.68388 10.2623 3.02569 10.14 3.39986C10.0201 3.829 9.97282 4.27514 10 4.71987V5.99988H6Z";

        // ── Annotation Content ────────────────────────────────────────────
        private const string TrigonometryContent = "Trigonometry is a branch \nof mathematics that studies \nthe relationship between \nthe sides and angles of triangles.";
        private const string AssemblyContent = "An assembly is a collection \nof types and resources \nbuilt to work together as \na logical and functional unit.";
        private const string MiddlewareContent = "Software that acts as \na bridge between an operating system\nor database and applications,\nespecially over a network.";
        private const string ThesisContent = "A statement or theory\nput forward as a premise \nto be maintained or proved.";
        private const string ExpertiseContent = "Expert skill or knowledge \nin a particular field.";
        private const string ProgrammingContent = "Programming is the process \nof writing code that tells \na computer application or \nsoftware program what to do.";
        #endregion

        public VennDiagramViewModel()
        {
            Nodes = new ObservableCollection<NodeViewModel>();
            Connectors = new ObservableCollection<ConnectorViewModel>();
            if (this.View != null)
            {
                InitializeDiagram();
            }
        }

        #region Helper methods
        public void InitializeDiagram()
        {
            CreateNodes();
            CreateConnectors();
        }

        // ── NODES ─────────────────────────────────────────────────────────
        private void CreateNodes()
        {
            // ── Ellipse Nodes ──────────────────────────────────────────────
            // Programming
            programmingPorts = new ObservableCollection<NodePortViewModel>
            {
                CreatePort("port1", 0.82, 0.35),
            };
            var programmingAnnotations = new AnnotationCollection
            {
                new AnnotationEditorViewModel
                {
                    Content             = "Programming",
                    Offset              = new Point(0.24, 0.30),
                    FontWeight          = FontWeights.Bold,
                    FontSize            = 16,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Foreground          = new SolidColorBrush(Color.FromRgb(18, 44, 80))
                },
                new AnnotationEditorViewModel
                {
                    Content             = ProgrammingContent,
                    Offset              = new Point(0.18, 0.44),
                    FontWeight = FontWeights.SemiBold,
                    FontSize            = 12,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    TextHorizontalAlignment = TextAlignment.Left,
                    WrapText            = TextWrapping.Wrap,
                    Foreground          = new SolidColorBrush(Color.FromRgb(50, 60, 85))
                },
                // ✅ "Data Science" label in center intersection
                
            };
            AddEllipseNode("programming", 390, 255, 350, 350,
                Color.FromArgb(102, 45, 194, 134),
                programmingAnnotations, programmingPorts);


            var trigonometryAnnotations = new AnnotationCollection
            {
                new AnnotationEditorViewModel
                {
                    Content             = "Trigonometry",
                    Offset              = new Point(0.86, 0.30),
                    FontWeight          = FontWeights.Bold,
                    FontSize            = 16,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Foreground          = new SolidColorBrush(Color.FromRgb(18, 44, 80))
                },
                new AnnotationEditorViewModel
                {
                    Content             = TrigonometryContent,
                    Offset              = new Point(0.46, 0.44),
                    FontWeight = FontWeights.SemiBold,
                    FontSize            = 12,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    TextHorizontalAlignment = TextAlignment.Left,
                    WrapText            = TextWrapping.Wrap,
                    Foreground          = new SolidColorBrush(Color.FromRgb(50, 60, 85))
                }
            };
            AddEllipseNode("trigonometry", 615, 255, 350, 350,
                Color.FromArgb(102, 69, 130, 249),
                trigonometryAnnotations, null);


            // Expertise
            var expertiseAnnotations = new AnnotationCollection
            {
                new AnnotationEditorViewModel
                {
                    Content    = "Expertise",
                    Offset     = new Point(0.50, 0.70),
                    FontWeight = FontWeights.Bold,
                    FontSize   = 16,
                    Foreground = new SolidColorBrush(Color.FromRgb(18, 44, 80))
                },
                new AnnotationEditorViewModel
                {
                    Content    = ExpertiseContent,
                    Offset     = new Point(0.50, 0.80),
                    FontWeight = FontWeights.SemiBold,
                    FontSize   = 12,
                    WrapText   = TextWrapping.Wrap,
                    Foreground = new SolidColorBrush(Color.FromRgb(50, 60, 85))
                },
                new AnnotationEditorViewModel
                {
                    Content             = "Data\nScience",
                    Offset              = new Point(0.58, 0.10),
                    FontWeight          = FontWeights.Bold,
                    FontSize            = 16,
                    HorizontalAlignment = HorizontalAlignment.Right,
                   Foreground          = new SolidColorBrush(Color.FromRgb(18, 44, 80))
                }
            };
            AddEllipseNode("expertise", 500, 465, 350, 350,
                Color.FromArgb(102, 232, 111, 109),
                expertiseAnnotations, null);

            // ── Path Nodes (Icons + Labels) ────────────────────────────────
            // Assembly  ── label right side, text left-aligned
            assemblyPorts = new ObservableCollection<NodePortViewModel>
            {
                CreatePort("port1", -0.5, 0.5)
            };
            var assemblyAnnotations = new AnnotationCollection
         {
             new AnnotationEditorViewModel
             {
                 Content             = "Assembly",
                 Offset              = new Point(1.1, 0.1),
                 FontWeight          = FontWeights.Bold,
                 FontSize            = 16,
                 HorizontalAlignment = HorizontalAlignment.Left,
                 WrapText            = TextWrapping.Wrap,
                 UnitWidth           = 150,
                 Foreground          = new SolidColorBrush(Color.FromRgb(18, 44, 80)),
                 Margin              = new Thickness(-15, 0, 0, 0),
             },
             new AnnotationEditorViewModel
             {
                 Content             = AssemblyContent,
                 Offset              = new Point(1.1, 1.4),
                 FontWeight = FontWeights.SemiBold,
                 FontSize            = 12,
                 UnitWidth           = 300,
                 UnitHeight          = 200,                   
                 HorizontalAlignment = HorizontalAlignment.Left,
                 TextHorizontalAlignment = TextAlignment.Left,
                 WrapText            = TextWrapping.WrapWithOverflow,
                 Foreground          = new SolidColorBrush(Color.FromRgb(50, 60, 85)),
                 Margin              = new Thickness(-15, 0, 0, 0),
             }
         };
            AddPathNode("assemblyNode", 716, 1, 52, 63, "#1D747A", AssemblyPath,
                assemblyAnnotations, assemblyPorts);

            // Middleware  ── label left side, text right-aligned
            middlewarePorts = new ObservableCollection<NodePortViewModel>
            {
                CreatePort("port1", 0.9, 0.5)
            };
            var middlewareAnnotations = new AnnotationCollection
         {
             new AnnotationEditorViewModel
             {
                 Content             = "Middleware",
                 Offset              = new Point(-0.3, 0.2),
                 FontWeight          = FontWeights.Bold,
                 FontSize            = 14,
                 HorizontalAlignment = HorizontalAlignment.Right,
                 WrapText            = TextWrapping.NoWrap,
                 UnitWidth           = 150,
                 Foreground          = new SolidColorBrush(Color.FromRgb(18, 44, 80)),
                 Margin              = new Thickness(0, 0, -15, 0),
             },
             new AnnotationEditorViewModel
             {
                 Content             = MiddlewareContent,
                 Offset              = new Point(-0.5, 1.5),  
                 FontWeight = FontWeights.SemiBold,
                 FontSize            = 12,
                 UnitWidth           = 350,
                 UnitHeight          = 200,                    
                 HorizontalAlignment = HorizontalAlignment.Right,
                 TextHorizontalAlignment = TextAlignment.Right,
                 WrapText            = TextWrapping.Wrap,
                 Foreground          = new SolidColorBrush(Color.FromRgb(50, 60, 85)),
                 Margin              = new Thickness(0, 0, -15, 0),
             }
         };
            AddPathNode("middlewareNode", 150, 500, 65, 52, "#1E7649", MiddlewarePath,
                middlewareAnnotations, middlewarePorts);

            // Thesis  ── label right side, text left-aligned
            thesisPorts = new ObservableCollection<NodePortViewModel>
            {
                CreatePort("port1", -0.5, 0.5)
            };
            var thesisAnnotations = new AnnotationCollection
         {
             new AnnotationEditorViewModel
             {
                 Content             = "Thesis",
                 Offset              = new Point(1.3, 0.2),
                 FontWeight          = FontWeights.Bold,
                 FontSize            = 16,
                 HorizontalAlignment = HorizontalAlignment.Left,
                 WrapText            = TextWrapping.NoWrap,
                 UnitWidth           = 150,
                 Foreground          = new SolidColorBrush(Color.FromRgb(18, 44, 80)),
                 Margin              = new Thickness(-20, 0, 0, 0),
             },
             new AnnotationEditorViewModel
             {
                 Content             = ThesisContent,
                 Offset              = new Point(1.3, 1.5),   
                 FontWeight = FontWeights.SemiBold,
                 FontSize            = 12,
                 UnitWidth           = 300,
                 UnitHeight          = 200,                   
                 HorizontalAlignment = HorizontalAlignment.Left,
                 TextHorizontalAlignment = TextAlignment.Left,
                 WrapText            = TextWrapping.Wrap,
                 Foreground          = new SolidColorBrush(Color.FromRgb(50, 60, 85)),
                 Margin              = new Thickness(-20, 0, 0, 0),
             }
         };
            AddPathNode("thesisNode", 900, 500, 52, 58, "#3A2C7D", ThesisPath,
                thesisAnnotations, thesisPorts);


            // ── Icon-only nodes ────────────────────────────────────────────
            AddPathNode("calendarNode", 495, 500, 45, 45, "#952B2A", CalendarPath);
            AddPathNode("notesNode", 338, 150, 45, 45, "#187851", NotesPath);
            AddPathNode("pasteNode", 690, 150, 45, 45, "#213895", PastePath);

            // ...existing code...
        }

        // ── CONNECTORS ────────────────────────────────────────────────────
        private void CreateConnectors()
        {
            var lineStyle = new Style(typeof(Shape));
            lineStyle.Setters.Add(new Setter(Shape.StrokeProperty,
                new SolidColorBrush(Color.FromRgb(58, 118, 138))));
            lineStyle.Setters.Add(new Setter(Shape.StrokeThicknessProperty, 2.4));

            var noDecor = new Style(typeof(Path));
            noDecor.Setters.Add(new Setter(Path.FillProperty, Brushes.Transparent));
            noDecor.Setters.Add(new Setter(Path.StrokeProperty, Brushes.Transparent));

            var assemblyConnector = new ConnectorViewModel
            {
                ID = "assemblyToProgramming",
                //  SourcePoint = new Point(aSrcX, aSrcY),
                SourcePort = programmingPorts.FirstOrDefault(),
                // TargetPoint = new Point(aTgtX, aTgtY),
                TargetPort = assemblyPorts.FirstOrDefault(),
                ConnectorGeometryStyle = lineStyle,
                TargetDecorator = resourceDictionary["Ellipse"],
                SourceDecorator = resourceDictionary["Ellipse"],
                TargetDecoratorStyle = View.Resources["DecoratorHollowStyle"] as Style,
                SourceDecoratorStyle = View.Resources["DecoratorHollowStyle"] as Style,
                Constraints = ConnectorConstraints.Default
                                        & ~ConnectorConstraints.Selectable
                                        & ~ConnectorConstraints.Draggable,


                Segments = new ObservableCollection<IConnectorSegment>
             {
                 new Syncfusion.UI.Xaml.Diagram.Serializer.CubicCurveSegment
                 {
                     Point1 = new Point(508.22,48.62),
                     Point2 = new Point(591.98,10.80),
                 }
             }
            };
            Connectors.Add(assemblyConnector);

            // ── 2. middlewareToProgramming ─────────────────────────────────
            var middlewareConnector = new ConnectorViewModel
            {
                ID = "middlewareToProgramming",
                SourcePoint = new Point(410, 380),
                TargetPort = middlewarePorts.FirstOrDefault(),
                ConnectorGeometryStyle = lineStyle,
                TargetDecorator = resourceDictionary["Ellipse"],
                SourceDecorator = resourceDictionary["Ellipse"],
                TargetDecoratorStyle = View.Resources["DecoratorHollowStyle"] as Style,
                SourceDecoratorStyle = View.Resources["DecoratorHollowStyle"] as Style,
                Constraints = ConnectorConstraints.Default
                                        & ~ConnectorConstraints.Selectable
                                        & ~ConnectorConstraints.Draggable,

                Segments = new ObservableCollection<IConnectorSegment>
             {
                 new Syncfusion.UI.Xaml.Diagram.Serializer.CubicCurveSegment
                 {
                     Point1 = new Point(360,485.6),
                     Point2 = new Point(315.4,512.8)
                 }
             }
            };
            Connectors.Add(middlewareConnector);

            // ── 3. thesisToTrigonometry ───────────────────────────────────
            var thesisConnector = new ConnectorViewModel
            {
                ID = "thesisToTrigonometry",
                SourcePoint = new Point(600, 380),
                TargetPort = thesisPorts.FirstOrDefault(),
                ConnectorGeometryStyle = lineStyle,
                TargetDecorator = resourceDictionary["Ellipse"],
                SourceDecorator = resourceDictionary["Ellipse"],
                TargetDecoratorStyle = View.Resources["DecoratorHollowStyle"] as Style,
                SourceDecoratorStyle = View.Resources["DecoratorHollowStyle"] as Style,

                Segments = new ObservableCollection<IConnectorSegment>
             {
                 new Syncfusion.UI.Xaml.Diagram.Serializer.CubicCurveSegment
                 {
                     Point1 = new Point(620.8,486.8),
                     Point2 = new Point(755,521.6)
                 }
             }
            };
            Connectors.Add(thesisConnector);
        }

        // ── Helper Methods ────────────────────────────────────────────────
        private void AddEllipseNode(string id, double x, double y,
             double width, double height, Color fillColor,
             AnnotationCollection annotations,
             ObservableCollection<NodePortViewModel> ports)
        {
            var style = new Style(typeof(Path));
            style.Setters.Add(new Setter(Path.FillProperty,
                new SolidColorBrush(fillColor)));
            style.Setters.Add(new Setter(Path.StrokeProperty, Brushes.Transparent));
            style.Setters.Add(new Setter(Path.StrokeThicknessProperty, 0.0));

            // ✅ Use EllipseGeometry instead of EllipseShape
            var ellipseGeometry = new EllipseGeometry
            {
                RadiusX = width / 2,
                RadiusY = height / 2,
                Center = new Point(width / 2, height / 2)
            };

            var node = new NodeViewModel
            {
                ID = id,
                OffsetX = x,
                OffsetY = y,
                UnitWidth = width,
                UnitHeight = height,
                Shape = ellipseGeometry,
                ShapeStyle = style,
                Annotations = annotations,
                Constraints = NodeConstraints.Default & ~NodeConstraints.Selectable
            };

            if (ports != null)
                node.Ports = ports;

            Nodes.Add(node);
        }

        private void AddPathNode(string id, double x, double y,
            double width, double height, string fillHex, string pathData,
            AnnotationCollection annotations = null,
            ObservableCollection<NodePortViewModel> ports = null)
        {
            var fill = (Color)ColorConverter.ConvertFromString(fillHex);
            var style = new Style(typeof(Path));
            style.Setters.Add(new Setter(Path.FillProperty, new SolidColorBrush(fill)));
            style.Setters.Add(new Setter(Path.StrokeProperty, Brushes.Transparent));
            style.Setters.Add(new Setter(Path.StrokeThicknessProperty, 0.0));

            var node = new NodeViewModel
            {
                ID = id,
                OffsetX = x,
                OffsetY = y,
                UnitWidth = width,
                UnitHeight = height,
                Shape = Geometry.Parse(pathData),
                ShapeStyle = style,
                Constraints = NodeConstraints.Default & ~NodeConstraints.Selectable,
            };
            if (annotations != null) node.Annotations = annotations;
            if (ports != null) node.Ports = ports;
            Nodes.Add(node);
        }

        private NodePortViewModel CreatePort(string id, double x, double y)
        {
            return new NodePortViewModel
            {
                ID = id,
                NodeOffsetX = x,
                NodeOffsetY = y,
                Constraints = PortConstraints.Default,
            };
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
