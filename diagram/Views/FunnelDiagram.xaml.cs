using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
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

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for FunnelDiagram.xaml
    /// </summary>
    public partial class FunnelDiagram : DemoControl
    {

        private FunnelNodeViewModel _lastHoveredNode;
        private Point _lastMousePosition;
        private bool loaded = false;
        public FunnelDiagram()
        {
            InitializeComponent();
        }

        public FunnelDiagram(string themename) : base(themename)
        {
            InitializeComponent();
            Diagram.ScrollSettings.ScrollLimit = ScrollLimit.Diagram;
            (this.DataContext as FunnelDiagramViewModel).View = this;
            (this.DataContext as FunnelDiagramViewModel).TemplatedInitilization();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            
        }
        #region Event methods
        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            (Diagram.Info as IGraphInfo).ViewPortChangedEvent += FunnelDiagram_ViewPortChangedEvent;
        }

        private void FunnelDiagram_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            if (Diagram != null && Diagram.Info != null && !loaded && Diagram.IsLoaded && args.NewValue.ContentBounds == args.OldValue.ContentBounds)
            {
                //(Diagram.Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
                Diagram.PageSettings.PageHeight = double.NaN;
                Diagram.PageSettings.PageWidth = double.NaN;
                (Diagram.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter
                {
                    Margin = new Thickness(30),
                    CanZoomIn = false,
                    FitToPage = FitToPage.FitToPage
                });
                loaded = true;
            }
        }

        private void Diagram_MouseMove(object sender, MouseEventArgs e)
        {
            var currentPosition = e.GetPosition(Diagram);

            // ✅ Only process if mouse actually moved
            if (Math.Abs(currentPosition.X - _lastMousePosition.X) < 1 &&
                Math.Abs(currentPosition.Y - _lastMousePosition.Y) < 1)
                return;

            _lastMousePosition = currentPosition;

            var source = e.OriginalSource as DependencyObject;
            if (source == null)
            {
                CloseTooltip();
                return;
            }

            var nodeContainer = FindVisualParent<Node>(source);

            if (nodeContainer?.DataContext is FunnelNodeViewModel funnelNode
                && funnelNode.TooltipData != null)
            {
                if (_lastHoveredNode != funnelNode)
                {
                    _lastHoveredNode = funnelNode;

                    var template = Resources["TooltipTemplate"] as DataTemplate;
                    TooltipContent.ContentTemplate = template;
                    TooltipContent.Content = funnelNode.TooltipData;
                }

                // ✅ Update popup position on every mouse move
                if (!NodeTooltipPopup.IsOpen)
                {
                    NodeTooltipPopup.PlacementTarget = Diagram;
                    NodeTooltipPopup.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
                    NodeTooltipPopup.IsOpen = true;
                }

                // ✅ Manual offset calculation for smooth tracking
                NodeTooltipPopup.HorizontalOffset = currentPosition.X + 16;
                NodeTooltipPopup.VerticalOffset = currentPosition.Y + 16;
            }
            else
            {
                CloseTooltip();
            }
        }

        private void Diagram_MouseLeave(object sender, MouseEventArgs e)
        {
            CloseTooltip();
        }
        #endregion
        private void CloseTooltip()
        {
            if (NodeTooltipPopup.IsOpen)
            {
                NodeTooltipPopup.IsOpen = false;
                _lastHoveredNode = null;
            }
        }

        private static T FindVisualParent<T>(DependencyObject child)
            where T : DependencyObject
        {
            var current = VisualTreeHelper.GetParent(child);
            while (current != null)
            {
                if (current is T target) return target;
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            var viewModel = this.DataContext as FunnelDiagramViewModel;
            if (viewModel != null)
            {
                viewModel.View = null;
            }
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
    }

    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
            => string.IsNullOrEmpty(value as string)
               ? Visibility.Collapsed
               : Visibility.Visible;

        public object ConvertBack(object v, Type t, object p, CultureInfo c)
            => throw new NotImplementedException();
    }

    public class StringToSolidBrushConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (value is string hex && !string.IsNullOrEmpty(hex))
                return new SolidColorBrush(
                    (Color)ColorConverter.ConvertFromString(hex));
            return Brushes.Transparent;
        }
        public object ConvertBack(object v, Type t, object p, CultureInfo c)
            => throw new NotImplementedException();
    }

    public class StringToGeometryConverter : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (value is string pathData && !string.IsNullOrEmpty(pathData))
            {
                try { return Geometry.Parse(pathData); }
                catch { return null; }
            }
            return null;
        }

        public object ConvertBack(object v, Type t, object p, CultureInfo c)
            => throw new NotImplementedException();
    }
}
