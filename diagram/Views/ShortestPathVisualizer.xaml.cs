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
using Node = Syncfusion.UI.Xaml.Diagram.Node;
using ToolTip = System.Windows.Controls.ToolTip;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for ShortestPathVisualizer.xaml
    /// </summary>
    public partial class ShortestPathVisualizer : DemoControl
    {

        private string _currentHoveredNodeId = null;
        private ToolTip _activeTooltip = null;
        private Node _activeTooltipNode = null;
        private bool loaded = false;
        public ShortestPathVisualizer()
        {
            InitializeComponent();  
        }

        public ShortestPathVisualizer(string themename) : base(themename)
        {
            InitializeComponent();
            Diagram.ScrollSettings.ScrollLimit = ScrollLimit.Diagram;
            Diagram.Constraints = Diagram.Constraints.Remove(GraphConstraints.ContextMenu);
  
            Diagram.MouseMove += Diagram_MouseMove;
            Diagram.MouseLeave += Diagram_MouseLeave;
            Diagram.SFSelector.Style = this.Resources["CustomSelectorStyle"] as Style;
            (Diagram.Info as IGraphInfo).ItemSelectedEvent += MainWindow_ItemSelectedEvent; 
           
            (this.DataContext as ShortestPathVisualizerViewModel).View = this;
            
         
            (this.DataContext as ShortestPathVisualizerViewModel).InitializeNodeConnectors();
            SfSkinManager.SetTheme(this, new Syncfusion.SfSkinManager.Theme() { ThemeName = themename });

        }

        #region Event methods
        private void Diagram_Loaded_1(object sender, RoutedEventArgs e)
        {
            
            (Diagram.Info as IGraphInfo).ViewPortChangedEvent += ShortestPathVisualizer_ViewPortChangedEvent;
        }

        private void ShortestPathVisualizer_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            if (Diagram != null && Diagram.Info != null && !loaded && Diagram.IsLoaded && args.NewValue.ContentBounds == args.OldValue.ContentBounds)
            {
               // (Diagram.Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
                Diagram.PageSettings.PageHeight = double.NaN;
                Diagram.PageSettings.PageWidth = double.NaN;
                (Diagram.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter
                {
                    Margin = new Thickness(25),

                    FitToPage = FitToPage.FitToPage
                });
                loaded = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            var viewModel = this.DataContext as ShortestPathVisualizerViewModel;
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
        private void Diagram_MouseLeave(object sender, MouseEventArgs e)
        {
            var vm = DataContext as ShortestPathVisualizerViewModel;
            if (vm != null && _currentHoveredNodeId != null)
            {
                CloseActiveTooltip();
                vm.ClearHoverHighlight();
                _currentHoveredNodeId = null;
                Diagram.UpdateLayout();
            }
        }

        private void Diagram_MouseMove(object sender, MouseEventArgs e)
        {
            DependencyObject source = e.OriginalSource as DependencyObject;
            var vm = DataContext as ShortestPathVisualizerViewModel;
            if (vm == null) return;

            var node = source.FindVisualParent<Node>();

            if (node != null && node.DataContext is ShortestPathNodeViewModel hoveredNode)
            {
                var nodeId = hoveredNode.ID?.ToString();
                if (string.IsNullOrEmpty(nodeId)) return;

                if (nodeId != _currentHoveredNodeId)
                {
                    // ← Step 1: Close and clear previous tooltip FIRST
                    CloseActiveTooltip();

                    // ← Step 2: Clear all node IsHover flags
                    ClearHoveredNode();

                    // ← Step 3: Update highlights
                    vm.ClearHoverHighlight();
                    vm.HighlightPathOnHover(nodeId);
                    _currentHoveredNodeId = nodeId;

                    // ← Step 4: Set hover flag
                    hoveredNode.IsHover = true;

                    // ← Step 5: Show tooltip only if text exists
                    if (!string.IsNullOrEmpty(hoveredNode.TooltipText))
                    {
                        ShowTooltip(node, hoveredNode.TooltipText);
                    }

                    Diagram.UpdateLayout();
                }
            }
            else
            {
                if (_currentHoveredNodeId != null)
                {
                    CloseActiveTooltip();
                    ClearHoveredNode();
                    vm.ClearHoverHighlight();
                    _currentHoveredNodeId = null;
                    Diagram.UpdateLayout();
                }
            }
        }

        private void MainWindow_ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
            var vm = DataContext as ShortestPathVisualizerViewModel;
            if (vm == null) return;

            if (args.Item is ShortestPathNodeViewModel selectedNode)
            {
                vm.SourceNodeId = selectedNode.ID.ToString();
                vm.ClearHoverHighlight();
                _currentHoveredNodeId = null;
                CloseActiveTooltip();
                ClearHoveredNode();
                Diagram.UpdateLayout();
            }

            SelectorViewModel svm = Diagram.SelectedItems as SelectorViewModel;
            svm.SelectorConstraints = svm.SelectorConstraints & ~SelectorConstraints.QuickCommands;
        }

        #endregion

        #region Helper methods
        // ← Show tooltip on specific node
        private void ShowTooltip(Node node, string text)
        {
            // ← Always close previous before showing new
            CloseActiveTooltip();

            var newTooltip = new ToolTip
            {
                Content = text,
                Style = FindResource("NodeTooltipStyle") as Style,
                Placement = System.Windows.Controls.Primitives.PlacementMode.Top,
                PlacementTarget = node,
                IsOpen = false  // ← Set false first, then true
            };

            ToolTipService.SetInitialShowDelay(node, 0);
            ToolTipService.SetShowDuration(node, 60000);

            node.ToolTip = newTooltip;

            _activeTooltip = newTooltip;
            _activeTooltipNode = node;

            // ← Open AFTER assigning references
            _activeTooltip.IsOpen = true;
        }

        // ← Fully close and detach active tooltip
        private void CloseActiveTooltip()
        {
            // ← Close previous tooltip
            if (_activeTooltip != null)
            {
                _activeTooltip.IsOpen = false;
                _activeTooltip = null;
            }

            // ← Remove tooltip from previous node
            if (_activeTooltipNode != null)
            {
                _activeTooltipNode.ToolTip = null;
                _activeTooltipNode = null;
            }

            // ← Safety: clear ALL node tooltips to avoid ghost tooltips
            foreach (var item in (Diagram.Nodes as IEnumerable<object>))
            {
                if (item is Node n && n.ToolTip is ToolTip tt)
                {
                    tt.IsOpen = false;
                    n.ToolTip = null;
                }
            }
        }

        // ← Clear IsHover on all nodes
        private void ClearHoveredNode()
        {
            foreach (var item in (Diagram.Nodes as IEnumerable<object>))
            {
                if (item is Node n && n.DataContext is ShortestPathNodeViewModel nodeVm)
                {
                    nodeVm.IsHover = false;
                }
            }
        }
        #endregion

      
    }

    public class NullOrEmptyToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrEmpty(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }




    public class Diagram : SfDiagram
    {
        public Diagram()
        {
          
        }

        public Syncfusion.UI.Xaml.Diagram.Selector SFSelector = new Syncfusion.UI.Xaml.Diagram.Selector();
        protected override Syncfusion.UI.Xaml.Diagram.Selector GetSelectorForItemOverride(object item)
        {
            return SFSelector;
        }
    }
}
