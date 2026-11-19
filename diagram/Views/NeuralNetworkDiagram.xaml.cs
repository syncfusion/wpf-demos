using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for NeuralNetworkDiagram.xaml
    /// </summary>
    public partial class NeuralNetworkDiagram : DemoControl
    {
        private object _lastHoveredItem;
        private Point _lastMousePosition;
        private bool loaded = false;

        public NeuralNetworkDiagram()
        {
            InitializeComponent();
        }

        public NeuralNetworkDiagram(string themename) : base(themename)
        {
            InitializeComponent();
            Diagram.ScrollSettings.ScrollLimit = ScrollLimit.Diagram;

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

        #region Event methods
        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
           
            (Diagram.Info as IGraphInfo).ViewPortChangedEvent += NeuralNetworkDiagram_ViewPortChangedEvent;
            
        }

        private void NeuralNetworkDiagram_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            if (Diagram != null && Diagram.Info != null && !loaded && Diagram.IsLoaded && args.NewValue.ContentBounds == args.OldValue.ContentBounds)
            {
              //  (Diagram.Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
                Diagram.PageSettings.PageHeight = double.NaN;
                Diagram.PageSettings.PageWidth = double.NaN;
                (Diagram.Info as IGraphInfo)?.Commands.FitToPage.Execute(
                new FitToPageParameter
                {
                    FitToPage = FitToPage.FitToPage,
                    CanZoomIn = false,
                    Margin = new Thickness(40)
                });
                loaded = true;
            }
        }

        private void Diagram_MouseMove(object sender, MouseEventArgs e)
        {
            var currentPos = e.GetPosition(Diagram);

            // Skip if mouse barely moved
            if (Math.Abs(currentPos.X - _lastMousePosition.X) < 1 &&
                Math.Abs(currentPos.Y - _lastMousePosition.Y) < 1)
                return;

            _lastMousePosition = currentPos;

            var source = e.OriginalSource as DependencyObject;
            if (source == null) { CloseTooltip(); return; }

            // ── Check for hovered NODE ──
            var nodeContainer = FindVisualParent<Node>(source);
            if (nodeContainer?.DataContext is NeuralNodeViewModel neuralNode
                && neuralNode.TooltipData != null)
            {
                if (_lastHoveredItem != neuralNode)
                {
                    _lastHoveredItem = neuralNode;
                    // Swap template to neuron tooltip
                    TooltipContent.ContentTemplate =
                        Resources["NeuronTooltipTemplate"] as DataTemplate;
                    TooltipContent.Content = neuralNode.TooltipData;
                }

                ShowTooltip(currentPos);
                return;
            }

            // ── Check for hovered CONNECTOR ──
            var connectorContainer = FindVisualParent<Connector>(source);
            if (connectorContainer?.DataContext is NeuralConnectorViewModel neuralConn
                && neuralConn.TooltipData != null)
            {
                if (_lastHoveredItem != neuralConn)
                {
                    _lastHoveredItem = neuralConn;
                    // Swap template to connection tooltip
                    TooltipContent.ContentTemplate =
                        Resources["ConnectorTooltipTemplate"] as DataTemplate;
                    TooltipContent.Content = neuralConn.TooltipData;
                }

                ShowTooltip(currentPos);
                return;
            }

            // Nothing hovered — close tooltip
            CloseTooltip();
        }

        private void Diagram_MouseLeave(object sender, MouseEventArgs e)
            => CloseTooltip();
        #endregion

        #region Helper methods

        // ── Show popup offset 16px from cursor ──
        private void ShowTooltip(Point pos)
        {
            if (!DiagramTooltipPopup.IsOpen)
            {
                DiagramTooltipPopup.PlacementTarget = Diagram;
                DiagramTooltipPopup.Placement =
                    System.Windows.Controls.Primitives.PlacementMode.Relative;
                DiagramTooltipPopup.IsOpen = true;
            }

            DiagramTooltipPopup.HorizontalOffset = pos.X + 16;
            DiagramTooltipPopup.VerticalOffset = pos.Y + 16;
        }

        private void CloseTooltip()
        {
            if (DiagramTooltipPopup.IsOpen)
            {
                DiagramTooltipPopup.IsOpen = false;
                _lastHoveredItem = null;
            }
        }

        // ── Walk visual tree upward to find parent of type T ──
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
        #endregion
    }
}
