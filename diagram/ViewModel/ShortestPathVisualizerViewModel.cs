using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.Views;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using CommandManager = System.Windows.Input.CommandManager;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    
    public class ShortestPathVisualizerViewModel : INotifyPropertyChanged
    {
        #region Properties

        private readonly GraphService _graphService;
        private readonly ShortestPathService _pathService;

        public DemoControl View;
        private bool _isPermanentPathSet = false;
        private List<string> _permanentPath = new List<string>();

        public NodeCollection NodesCollection { get; } = new NodeCollection();
        public ConnectorCollection ConnectorsCollection { get; } = new ConnectorCollection();

        ResourceDictionary resourceDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
        };
        public List<string> NodeIds { get; private set; }

        private string _sourceNodeId = "A";
        public string SourceNodeId
        {
            get => _sourceNodeId;
            set { _sourceNodeId = value; OnPropertyChanged(); }
        }

        private string _targetNodeId = "J";
        public string TargetNodeId
        {
            get => _targetNodeId;
            set { _targetNodeId = value; OnPropertyChanged(); }
        }

        private bool _isDirected = true;
        public bool IsDirected
        {
            get => _isDirected;
            set
            {
                _isDirected = value;
                OnPropertyChanged();
                UpdateConnectorVisualStyle();
                ResetHighlights();
            }
        }

        private string _statusMessage = "Hover over a node to preview the shortest path.";
        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        public ICommand FindPathCommand { get; }
        public ICommand ResetCommand { get; }

        #endregion

        public ShortestPathVisualizerViewModel()
        {
            _graphService = new GraphService();
            _pathService = new ShortestPathService(_graphService.Adjacency);
            NodeIds = _graphService.NodePositions.Keys.OrderBy(x => x).ToList();

            if (View != null)
            {
                BuildNodes();
                BuildConnectors();
            }

            FindPathCommand = new RelayCommand(_ => ExecuteFindPath());
            ResetCommand = new RelayCommand(_ => ResetHighlights());
        }


        #region Helper methods

        public void InitializeNodeConnectors()
        {
            BuildNodes();
            BuildConnectors();
        }
        private void BuildNodes()
        {
            foreach (var kvp in _graphService.NodePositions)
            {
                var node = new ShortestPathNodeViewModel
                {
                    ID = kvp.Key,
                    UnitWidth = 44,
                    UnitHeight = 44,
                    OffsetX = kvp.Value.X,
                    OffsetY = kvp.Value.Y,
                    Shape = resourceDictionary["Ellipse"],


                    // ← DISABLE all interactions
                    Constraints = NodeConstraints.Default &
                                  ~NodeConstraints.Draggable &
                                 ~NodeConstraints.InheritDraggable &
                                  ~NodeConstraints.Resizable &
                                  ~NodeConstraints.Rotatable &
                                  ~NodeConstraints.Delete,


                    Annotations = new AnnotationCollection
                    {
                        new AnnotationEditorViewModel
                        {
                            Content = kvp.Key,
                            FontSize = 13,
                            Foreground = new SolidColorBrush(Colors.Black)
                        }
                    }
                };
                NodesCollection.Add(node);
            }

            GetNode(SourceNodeId).State = ShortestPathNodeViewModel.NodeState.Source;
        }

        private void BuildConnectors()
        {
           
            int i = 0;
            foreach (var edge in _graphService.Edges)
            {

                var conn = new ShortestPathConnectorViewModel
                {
                    View = this.View,
                    ID = $"C{i++}",
                    SourceNodeID = edge.From,
                    TargetNodeID = edge.To,
                    FromNodeId = edge.From,
                    ToNodeId = edge.To,
                    IsDirectedGraph = _isDirected,

                    // ← DISABLE all interactions
                    Constraints = ConnectorConstraints.Default &
                                  ~ConnectorConstraints.Draggable &
                                  ~ConnectorConstraints.Selectable &

                                  ~ConnectorConstraints.Delete,

                    Annotations = new AnnotationCollection()
                };
                ConnectorsCollection.Add(conn);
                conn.ApplyDefaultStyle();
            }
        }

        private void UpdateConnectorVisualStyle()
        {
            foreach (ShortestPathConnectorViewModel conn in ConnectorsCollection)
            {
                conn.IsDirectedGraph = _isDirected;
            }
        }

        // ← NEW: Update node tooltip with path
        public void HighlightPathOnHover(string hoveredNodeId)
        {
            if (_isPermanentPathSet) return;
            if (hoveredNodeId == SourceNodeId) return;

            ClearAllHighlights();

            var directedEdges = _graphService.Edges.Select(e => (e.From, e.To));
            var path = _pathService.FindPath(
                SourceNodeId, hoveredNodeId, IsDirected, directedEdges);

            var hoveredNode = GetNode(hoveredNodeId);
            GetNode(SourceNodeId).State = ShortestPathNodeViewModel.NodeState.Source;

            if (path.Count == 0)
            {
                // ← RED: Both source and target when no path
                GetNode(SourceNodeId).State = ShortestPathNodeViewModel.NodeState.NoPath;
                hoveredNode.State = ShortestPathNodeViewModel.NodeState.NoPath;
                hoveredNode.TooltipText = "No path found";
                StatusMessage = $"No path from {SourceNodeId} to {hoveredNodeId}.";
                return;
            }

            // ← Show path in tooltip
            hoveredNode.State = ShortestPathNodeViewModel.NodeState.Target;
            hoveredNode.TooltipText = string.Join(" → ", path);

            foreach (var nodeId in path.Skip(1).Take(path.Count - 2))
                GetNode(nodeId).State = ShortestPathNodeViewModel.NodeState.OnPath;

            for (int i = 0; i < path.Count - 1; i++)
            {
                var conn = GetConnector(path[i], path[i + 1]);
                if (conn != null)
                    conn.IsOnPath = true;
            }

            AnimatePathTraversal(path);
            StatusMessage = $"Path preview: {string.Join(" → ", path)}  ({path.Count - 1} hops)";
        }

        public void ClearHoverHighlight()
        {
            if (_isPermanentPathSet) return;

            ClearAllHighlights();

            // ← Clear all tooltips
            foreach (ShortestPathNodeViewModel node in NodesCollection)
            {
                node.TooltipText = null;
            }

            if (NodesCollection.OfType<ShortestPathNodeViewModel>()
                               .Any(n => n.ID?.ToString() == SourceNodeId))
                GetNode(SourceNodeId).State = ShortestPathNodeViewModel.NodeState.Source;

            StatusMessage = "Hover over a node to preview the shortest path.";
        }

        private async void ExecuteFindPath()
        {
            ClearAllHighlights();
            _isPermanentPathSet = false;

            var directedEdges = _graphService.Edges.Select(e => (e.From, e.To));
            var path = _pathService.FindPath(
                SourceNodeId, TargetNodeId, IsDirected, directedEdges);

            var sourceNode = GetNode(SourceNodeId);
            var targetNode = GetNode(TargetNodeId);

            if (path.Count == 0)
            {
                // ← RED: Both nodes when no path
                sourceNode.State = ShortestPathNodeViewModel.NodeState.NoPath;
                targetNode.State = ShortestPathNodeViewModel.NodeState.NoPath;
                targetNode.TooltipText = "No path found";
                StatusMessage = $"No path found from {SourceNodeId} to {TargetNodeId}.";
                return;
            }

            sourceNode.State = ShortestPathNodeViewModel.NodeState.Source;
            targetNode.State = ShortestPathNodeViewModel.NodeState.Target;
            targetNode.TooltipText = string.Join(" → ", path);

            foreach (var nodeId in path.Skip(1).Take(path.Count - 2))
                GetNode(nodeId).State = ShortestPathNodeViewModel.NodeState.OnPath;

            await AnimatePathTraversal(path);

            _permanentPath = path;
            _isPermanentPathSet = true;

            StatusMessage = $"Shortest path ({path.Count - 1} hops): {string.Join(" → ", path)}";
        }

        private async Task AnimatePathTraversal(List<string> path)
        {
            int step = 1;
            for (int i = 0; i < path.Count - 1; i++)
            {
                var conn = GetConnector(path[i], path[i + 1]);
                if (conn != null)
                {
                    conn.IsOnPath = true;
                    conn.StepNumber = step++;
                }
            }
        }

        public void ResetHighlights()
        {
            _isPermanentPathSet = false;
            _permanentPath.Clear();

            ClearAllHighlights();

            // ← Clear all tooltips
            foreach (ShortestPathNodeViewModel node in NodesCollection)
            {
                node.TooltipText = null;
            }

            if (NodesCollection.OfType<ShortestPathNodeViewModel>()
                               .Any(n => n.ID?.ToString() == SourceNodeId))
                GetNode(SourceNodeId).State = ShortestPathNodeViewModel.NodeState.Source;

            StatusMessage = "Hover over a node to preview the shortest path.";
        }

        private void ClearAllHighlights()
        {
            foreach (ShortestPathNodeViewModel n in NodesCollection)
                n.State = ShortestPathNodeViewModel.NodeState.Normal;

            foreach (ShortestPathConnectorViewModel c in ConnectorsCollection)
            {
                c.IsOnPath = false;
                c.StepNumber = null;
                c.IsHovered = false;
            }
        }

        private ShortestPathNodeViewModel GetNode(string id)
            => NodesCollection
               .OfType<ShortestPathNodeViewModel>()
               .First(n => n.ID?.ToString() == id);

        private ShortestPathConnectorViewModel GetConnector(string from, string to)
            => ConnectorsCollection
               .OfType<ShortestPathConnectorViewModel>()
               .FirstOrDefault(c =>
                   (c.FromNodeId == from && c.ToNodeId == to) ||
                   (!IsDirected && c.FromNodeId == to && c.ToNodeId == from));

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }

   

    // ══════════════════════════════════════════════════════════════════
    // CONNECTOR VIEW MODEL
    // ══════════════════════════════════════════════════════════════════
    public class ShortestPathConnectorViewModel : ConnectorViewModel
    {
        #region Properties
        public string FromNodeId { get; set; }
        public string ToNodeId { get; set; }


        public DemoControl View;

        private bool _isDirectedGraph;
        public bool IsDirectedGraph
        {
            get => _isDirectedGraph;
            set
            {
                if (_isDirectedGraph == value) return;
                _isDirectedGraph = value;
                OnPropertyChanged(nameof(IsDirectedGraph));
                ApplyConnectorStyle();
            }
        }

        private bool _isAnimating;
        public bool IsAnimating
        {
            get => _isAnimating;
            set
            {
                if (_isAnimating == value) return;
                _isAnimating = value;
                OnPropertyChanged(nameof(IsAnimating));
            }
        }

        private bool _isOnPath;
        public bool IsOnPath
        {
            get => _isOnPath;
            set
            {
                if (_isOnPath == value) return;
                _isOnPath = value;
                ApplyConnectorStyle();
            }
        }

        private bool _isHovered;
        public bool IsHovered
        {
            get => _isHovered;
            set
            {
                if (_isHovered == value) return;
                _isHovered = value;
                ApplyConnectorStyle();
            }
        }

        private int? _stepNumber;
        public int? StepNumber
        {
            get => _stepNumber;
            set
            {
                _stepNumber = value;
                UpdateAnnotation();
            }
        }
        #endregion
        public ShortestPathConnectorViewModel()
        {
            Annotations = new AnnotationCollection();
        }

        #region Helper methods
        public void ApplyDefaultStyle() => ApplyConnectorStyle();

        private void ApplyConnectorStyle()
        {
            string stylePrefix = _isDirectedGraph ? "" : "Solid";
            string arrowStyleKey;

            if (_isOnPath)
            {
                IsAnimating = true;
                ConnectorGeometryStyle = this.View.FindResource(
                    $"AnimatedPathConnector{stylePrefix}Style") as Style;
                arrowStyleKey = "PathArrowStyle";
            }
            else if (_isHovered)
            {
                IsAnimating = false;
                ConnectorGeometryStyle = View.FindResource(
                    $"HoverConnector{stylePrefix}Style") as Style;
                arrowStyleKey = "HoverArrowStyle";
            }
            else
            {
                IsAnimating = false;
                ConnectorGeometryStyle = View.FindResource(
                    $"DefaultConnector{stylePrefix}Style") as Style;
                arrowStyleKey = "DefaultArrowStyle";
            }

            if (_isDirectedGraph)
            {
                TargetDecoratorStyle = View.FindResource(arrowStyleKey) as Style;
            }
            else
            {
                TargetDecoratorStyle = null;
            }
        }

        private void UpdateAnnotation()
        {
            var annotations = Annotations as AnnotationCollection;
            if (annotations == null) return;

            annotations.Clear();

            if (_stepNumber.HasValue)
            {
                var annotation = new AnnotationEditorViewModel
                {
                    Content = _stepNumber.Value.ToString(),
                    Length = 0.5,
                    Offset = new Point(0, 0),
                    ViewTemplate = View.Resources["viewTemplate"] as DataTemplate
                };
                annotations.Add(annotation);
            }
        }

        #endregion
    }

    // ══════════════════════════════════════════════════════════════════
    // NODE VIEW MODEL (WITH TOOLTIP)
    // ══════════════════════════════════════════════════════════════════
    public class ShortestPathNodeViewModel : NodeViewModel
    {

        #region Properties
        public enum NodeState { Normal, Source, Target, OnPath, NoPath }

        private NodeState _state = NodeState.Normal;
        public NodeState State
        {
            get => _state;
            set
            {
                if (_state == value) return;
                _state = value;
                OnPropertyChanged(nameof(State));
                ApplyNodeStyle();
            }
        }

        private bool _isHover;
        public bool IsHover
        {
            get => _isHover;
            set
            {
                _isHover = value;
                OnPropertyChanged(nameof(IsHover));
            }
        }

        // ← NEW: Tooltip property
        private string _tooltipText;
        public string TooltipText
        {
            get => _tooltipText;
            set
            {
                _tooltipText = value;
                OnPropertyChanged(nameof(TooltipText));
                OnPropertyChanged(nameof(HasTooltip));
            }
        }

        public bool HasTooltip => !string.IsNullOrEmpty(TooltipText);
        #endregion

        public ShortestPathNodeViewModel()
        {
            ApplyNodeStyle();
        }

        #region Helper methods
        private void ApplyNodeStyle()
        {
            SolidColorBrush fill;
            SolidColorBrush stroke;
            double strokeThickness;

            switch (_state)
            {
                case NodeState.Source:
                    fill = new SolidColorBrush(Color.FromRgb(66, 133, 244)); // Blue
                    stroke = new SolidColorBrush(Color.FromRgb(26, 115, 232));
                    strokeThickness = 2.5;
                    break;

                case NodeState.Target:
                    fill = new SolidColorBrush(Color.FromRgb(66, 133, 244)); // Blue
                    stroke = new SolidColorBrush(Color.FromRgb(26, 115, 232));
                    strokeThickness = 2.5;
                    break;

                case NodeState.OnPath:
                    fill = new SolidColorBrush(Color.FromRgb(66, 133, 244)); // Blue
                    stroke = new SolidColorBrush(Color.FromRgb(26, 115, 232));
                    strokeThickness = 2;
                    break;

                case NodeState.NoPath:
                    fill = new SolidColorBrush(Color.FromRgb(234, 67, 53)); // Red
                    stroke = new SolidColorBrush(Color.FromRgb(197, 34, 31));
                    strokeThickness = 2.5;
                    break;

                default:
                    fill = Brushes.White;
                    stroke = Brushes.Black;
                    strokeThickness = 1.5;
                    break;
            }

            var style = new Style(typeof(Path));
            style.Setters.Add(new Setter(Path.FillProperty, fill));
            style.Setters.Add(new Setter(Path.StrokeProperty, stroke));
            style.Setters.Add(new Setter(Path.StrokeThicknessProperty, strokeThickness));
            style.Setters.Add(new Setter(Path.StretchProperty, Stretch.Fill));

            ShapeStyle = style;
        }
        #endregion
    }


    // ══════════════════════════════════════════════════════════════════
    // GRAPH EDGE
    // ══════════════════════════════════════════════════════════════════
    public class GraphEdge
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    // ══════════════════════════════════════════════════════════════════
    // GRAPH SERVICE
    // ══════════════════════════════════════════════════════════════════
    public class GraphService
    {
        private readonly Dictionary<string, List<string>> _adj =
            new Dictionary<string, List<string>>();

        public IReadOnlyDictionary<string, List<string>> Adjacency => _adj;
        public IReadOnlyList<GraphEdge> Edges { get; }
        public IReadOnlyDictionary<string, (double X, double Y)> NodePositions { get; }

        public GraphService()
        {
            NodePositions = new Dictionary<string, (double, double)>
            {
                ["A"] = (200, 150),
                ["X"] = (490, 155),
                ["E"] = (700, 105),
                ["B"] = (430, 255),
                ["C"] = (570, 210),
                ["D"] = (205, 255),
                ["L"] = (760, 220),
                ["F"] = (210, 340),
                ["H"] = (350, 395),
                ["I"] = (615, 305),
                ["K"] = (620, 380),
                ["J"] = (795, 365),
                ["G"] = (460, 460),
                ["Y"] = (700, 460)
            };

            foreach (var id in NodePositions.Keys)
                _adj[id] = new List<string>();

            var rawEdges = new[]
            {
                ("A","B"), ("A","D"), ("A","X"),
                ("B","D"), ("B","H"), ("B","X"), ("B","C"), ("B","K"),
                ("C","L"), ("C","X"),
                ("D","F"), ("E","X"),
                ("F","H"), ("G","H"), ("G","Y"), ("G","K"),
                ("H","I"),
                ("I","J"), ("I","K"), ("I","L"),
                ("J","L"),
                ("K","Y")
            };

            var edgeList = new List<GraphEdge>();
            foreach (var (from, to) in rawEdges)
            {
                _adj[from].Add(to);
                _adj[to].Add(from);
                edgeList.Add(new GraphEdge { From = from, To = to });
            }
            Edges = edgeList;
        }
    }

    // ══════════════════════════════════════════════════════════════════
    // SHORTEST PATH SERVICE
    // ══════════════════════════════════════════════════════════════════
    public class ShortestPathService
    {
        private readonly IReadOnlyDictionary<string, List<string>> _adj;

        public ShortestPathService(IReadOnlyDictionary<string, List<string>> adj)
            => _adj = adj;

        #region Helper methods
        public List<string> FindPath(
            string start, string end, bool directed,
            IEnumerable<(string From, string To)> directedEdges = null)
        {
            if (start == end) return new List<string> { start };
            if (!_adj.ContainsKey(start) || !_adj.ContainsKey(end))
                return new List<string>();

            var queue = new Queue<string>();
            var visited = new HashSet<string>();
            var previous = new Dictionary<string, string>();

            queue.Enqueue(start);
            visited.Add(start);

            Dictionary<string, List<string>> dirAdj = null;
            if (directed && directedEdges != null)
            {
                dirAdj = new Dictionary<string, List<string>>();
                foreach (var (f, t) in directedEdges)
                {
                    if (!dirAdj.ContainsKey(f)) dirAdj[f] = new List<string>();
                    dirAdj[f].Add(t);
                }
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                var neighbours = directed && dirAdj != null
                    ? (dirAdj.TryGetValue(current, out var dn) ? dn : new List<string>())
                    : _adj[current];

                foreach (var nb in neighbours)
                {
                    if (visited.Contains(nb)) continue;
                    visited.Add(nb);
                    previous[nb] = current;
                    if (nb == end) return ReconstructPath(previous, start, end);
                    queue.Enqueue(nb);
                }
            }

            return new List<string>();
        }

        private static List<string> ReconstructPath(
            Dictionary<string, string> previous, string start, string end)
        {
            var path = new List<string>();
            var node = end;
            while (node != null)
            {
                path.Insert(0, node);
                previous.TryGetValue(node, out node);
            }
            return path.Count > 0 && path[0] == start ? path : new List<string>();
        }

        #endregion
    }
}
