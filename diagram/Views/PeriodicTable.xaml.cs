using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for PeriodicTable.xaml
    /// </summary>
    public partial class PeriodicTable : DemoControl
    {
        private ElementNodeViewModel _lastHoveredNode = null;
        private PeriodicTableViewModel _vm;
        private bool _isNodeClicked = false;
        private string _defaultFill;
        private string _defaultStroke;
        private GroupPeriodNodeViewModel _lastSelectedGpVm;
        private bool loaded = false;
        public PeriodicTable()
        {
            InitializeComponent();
            
        }

        public PeriodicTable(string themename) : base(themename)
        {
            InitializeComponent();
            Diagram.ScrollSettings.ScrollLimit = ScrollLimit.Diagram;
            _vm = new PeriodicTableViewModel();
            DataContext = _vm;

            var nodeTemplate = (DataTemplate)Resources["UnifiedNodeTemplate"];
            foreach (var item in _vm.Nodes)
            {
                if (item is ElementNodeViewModel elementNode)
                {
                    elementNode.ContentTemplate = nodeTemplate;
                    elementNode.Content = elementNode;
                }
            }

            Diagram.MouseMove += Diagram_MouseMove;
            Loaded += OnWindowLoaded;
            Diagram.SFSelector.Style = this.Resources["CustomSelectorStyle"] as Style;
            SfSkinManager.SetTheme(this, new Syncfusion.SfSkinManager.Theme() { ThemeName = themename });

        }

        

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            if (this.Diagram != null)
            {
                this.Diagram = null;
            }
            base.Dispose(disposing);
        }
        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            var graphInfo = Diagram.Info as IGraphInfo;
            if (graphInfo != null)
            {
                graphInfo.MouseDown += MainWindow_MouseDown;
                SelectorViewModel svm = Diagram.SelectedItems as SelectorViewModel;
                svm.SelectorConstraints = svm.SelectorConstraints & ~SelectorConstraints.QuickCommands;
                Diagram.Constraints = Diagram.Constraints.Remove(GraphConstraints.Draggable);
                (Diagram.Info as IGraphInfo).NodeChangedEvent += MainWindow_ItemSelectedEvent;

            }

            graphInfo.ViewPortChangedEvent += GraphInfo_ViewPortChangedEvent;
            
        }

        private void GraphInfo_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            if (Diagram != null && Diagram.Info != null && !loaded && Diagram.IsLoaded && args.NewValue.ContentBounds == args.OldValue.ContentBounds)
            {
                (Diagram.Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
                Diagram.PageSettings.PageHeight = double.NaN;
                Diagram.PageSettings.PageWidth = double.NaN;
                (Diagram.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter
                {
                    Margin = new Thickness(15),
                    FitToPage = FitToPage.FitToPage
                });
                loaded = true;
            }
        }

        private void MainWindow_ItemSelectedEvent(object sender, DiagramEventArgs args)
        {

        }

        private string GetDefaultFill(int number)
        {
            return number % 2 == 0 ? "#eef3fb" : "#c5d8f0";
        }

        private string GetDefaultStroke(int number)
        {
            return number % 2 == 0 ? "#b8cde8" : "#92b4d8";
        }
        private static System.Windows.Style BuildGpStyle(string fill, string stroke, double thickness, double[] dashArray = null)
        {
            var style = new System.Windows.Style(typeof(System.Windows.Shapes.Path));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.FillProperty,
                new SolidColorBrush((Color)ColorConverter.ConvertFromString(fill))));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeProperty,
                new SolidColorBrush((Color)ColorConverter.ConvertFromString(stroke))));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeThicknessProperty, thickness));
            style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StretchProperty, Stretch.Fill));

            if (dashArray != null && dashArray.Length > 0)
            {
                var collection = new DoubleCollection(dashArray);
                style.Setters.Add(new Setter(System.Windows.Shapes.Shape.StrokeDashArrayProperty, collection));
            }

            return style;
        }

        private void RestoreGpNodeStyle(GroupPeriodNodeViewModel gpVm)
        {
            gpVm.ShapeStyle = BuildGpStyle(
                GetDefaultFill(gpVm.Number),
                GetDefaultStroke(gpVm.Number),
                1d);
        }

        private void MainWindow_MouseDown(object sender, MouseDownEventArgs args)
        {
            var gpVm = args.Item as GroupPeriodNodeViewModel;

            if (gpVm != null)
            {
                _isNodeClicked = true;

                if (_lastSelectedGpVm != null && _lastSelectedGpVm != gpVm)
                    RestoreGpNodeStyle(_lastSelectedGpVm);

                if (_lastSelectedGpVm == gpVm)
                {
                    // ✅ Toggle off — restore solid stroke, no dash
                    RestoreGpNodeStyle(gpVm);
                    _lastSelectedGpVm = null;

                    if (gpVm.IsGroup) _vm.SelectedGroup = null;
                    else _vm.SelectedPeriod = null;
                }
                else
                {
                    // ✅ Selected — dashed stroke { 4, 2 } = 4px dash, 2px gap
                    gpVm.ShapeStyle = BuildGpStyle(
                        GetDefaultFill(gpVm.Number),
                        "#1a3f88",
                        1d,
                        new double[] { 4, 2 }); // ✅ dash array only on selection
                    _lastSelectedGpVm = gpVm;

                    if (gpVm.IsGroup) _vm.SelectedGroup = (_vm.SelectedGroup == gpVm.Number) ? (int?)null : gpVm.Number;
                    else _vm.SelectedPeriod = (_vm.SelectedPeriod == gpVm.Number) ? (int?)null : gpVm.Number;
                }

                args.MouseEventArgs.Handled = true;
            }
            else if (args.Item == null)
            {
                if (_isNodeClicked)
                {
                    _isNodeClicked = false;
                    return;
                }

                if (_lastSelectedGpVm != null)
                {
                    RestoreGpNodeStyle(_lastSelectedGpVm);
                    _lastSelectedGpVm = null;
                }

                _vm.SelectedGroup = null;
                _vm.SelectedPeriod = null;
            }
            else
            {
                if (_lastSelectedGpVm != null)
                {
                    RestoreGpNodeStyle(_lastSelectedGpVm);
                    _lastSelectedGpVm = null;
                }

                _isNodeClicked = false;
                _vm.SelectedGroup = null;
                _vm.SelectedPeriod = null;
            }
        }

        private void Diagram_MouseMove(object sender, MouseEventArgs e)
        {
            DependencyObject source = e.OriginalSource as DependencyObject;
            var node = source?.FindVisualParent<Node>();

            ElementNodeViewModel currentVm = null;
            if (node != null)
                currentVm = node.DataContext as ElementNodeViewModel;

            if (currentVm != null && !currentVm.IsElementNode)
                currentVm = null;

            if (currentVm != _lastHoveredNode)
            {
                if (_lastHoveredNode != null)
                {
                    _lastHoveredNode.IsHovered = false;
                    _lastHoveredNode = null;
                }
                if (currentVm != null)
                {
                    currentVm.IsHovered = true;
                    _lastHoveredNode = currentVm;
                }
            }
        }
    }

    public class BoolToOpacityConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            bool isBlurred = (value is bool b) && b;
            return isBlurred ? 0.2 : 1.0;
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }

    public class CategoryToColorConverter : System.Windows.Data.IValueConverter
    {
        private static readonly Dictionary<string, System.Windows.Media.SolidColorBrush> Map
            = new Dictionary<string, System.Windows.Media.SolidColorBrush>
            {
                ["alkali-metals"] = Brush("#006AC7"),
                ["alkaline-earth-metals"] = Brush("#08970E"),
                ["transition-metals"] = Brush("#F08000"),
                ["other-metals"] = Brush("#B75A09"),
                ["metalloids"] = Brush("#95B506"),
                ["non-metals"] = Brush("#DE2362"),
                ["halogens"] = Brush("#DE2723"),
                ["noble-gases"] = Brush("#0B98A9"),
                ["lanthanides"] = Brush("#5C1FA8"),
                ["actinides"] = Brush("#8C04A1"),
            };

        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            if (value is string cat && Map.TryGetValue(cat, out var brush))
                return brush;
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
            => throw new NotImplementedException();

        private static System.Windows.Media.SolidColorBrush Brush(string hex)
        {
            var b = new System.Windows.Media.SolidColorBrush(
                (Color)ColorConverter.ConvertFromString(hex));
            b.Freeze();
            return b;
        }
    }

    public class BoolToVisibilityConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
            => (value is bool b && b)
               ? Visibility.Visible
               : Visibility.Collapsed;

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }

    public class CustomDiagram : SfDiagram
    {
        public Syncfusion.UI.Xaml.Diagram.Selector SFSelector = new Syncfusion.UI.Xaml.Diagram.Selector();
        protected override Syncfusion.UI.Xaml.Diagram.Selector GetSelectorForItemOverride(object item)
        {
            return SFSelector;
        }
    }
}