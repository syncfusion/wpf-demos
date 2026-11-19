using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    /// Interaction logic for History_Timeline.xaml
    /// </summary>
    public partial class History_Timeline : DemoControl
    {
        public History_Timeline()
        {
            InitializeComponent();

        }
        public History_Timeline(string themename) : base(themename)
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });

            Diagram.Loaded += Diagram_Loaded;
            Diagram.Constraints = Diagram.Constraints.Remove(GraphConstraints.Draggable);
            Diagram.ScrollSettings.ScrollLimit = ScrollLimit.Diagram;
            Diagram.Constraints = Diagram.Constraints.Remove(GraphConstraints.ContextMenu);
            Diagram.SFSelector.Style = this.Resources["CustomSelectorStyle"] as Style;
            (Diagram.Info as IGraphInfo).ItemSelectedEvent += MainWindow_ItemSelectedEvent;
            if (DataContext is HistoryTimelineViewModel vm)
            {
                vm.DiagramNodes.CollectionChanged += OnDiagramNodesChanged;
            }
        }

        #region Event methods
        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
         AssignNodeTemplates();

         (Diagram.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter()
         {
             Margin = new Thickness(-700, 20, -700, 20),
             FitToPage = FitToPage.FitToPage

         });
        }

        private void MainWindow_ItemSelectedEvent(object sender, DiagramEventArgs args)
        {
            var vm = DataContext as HistoryTimelineViewModel;
            if (vm == null) return;

            var selector = Diagram.SelectedItems as SelectorViewModel;
            if (selector == null) return;

            var commands = selector.Commands as QuickCommandCollection;
            if (commands == null || commands.Count < 2) return;

            var addCmd = commands[0] as QuickCommandViewModel;
            var editCmd = commands[1] as QuickCommandViewModel;

            var selectedNodes = (selector.Nodes as IEnumerable<object>)?
                                .OfType<TimelineNodeViewModel>().ToList();

            if (selectedNodes == null || selectedNodes.Count != 1
                || !selectedNodes.First().IsYearMarker)
                return;

            var node = selectedNodes.First();

            // Set index FIRST so CanShowAddHandle evaluates correctly
            vm.SelectedEventIndex = node.EventIndex;

            if (addCmd != null)
            {
                addCmd.Command = vm.OpenAddDialogCommand;
                addCmd.CommandParameter = node.EventIndex;
                addCmd.VisibilityMode = vm.CanShowAddHandle
                    ? Syncfusion.UI.Xaml.Diagram.Controls.VisibilityMode.Node
                    : Syncfusion.UI.Xaml.Diagram.Controls.VisibilityMode.Connector;
            }

            if (editCmd != null)
            {
                editCmd.Command = vm.OpenEditDialogCommand;
                editCmd.CommandParameter = node.EventIndex;
                editCmd.VisibilityMode =
                    Syncfusion.UI.Xaml.Diagram.Controls.VisibilityMode.Node;
            }
        }

        /// <summary>
        /// Re-assign templates when collection is rebuilt.
        /// Mirrors JS diagram.dataBind() refreshing node content.
        /// </summary>
        private void OnDiagramNodesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Use Dispatcher so SfDiagram has processed the new nodes first
            Dispatcher.BeginInvoke(new System.Action(AssignNodeTemplates),
                System.Windows.Threading.DispatcherPriority.Loaded);
        }
        #endregion

        /// <summary>
        /// Sets ContentTemplate on each TimelineNodeViewModel.
        /// Per UG: NodeViewModel.ContentTemplate is the correct property —
        /// SfDiagram has NO NodeTemplate property at diagram level.
        /// https://help.syncfusion.com/wpf/diagram/node
        /// </summary>
        private void AssignNodeTemplates()
        {
            if (!(DataContext is HistoryTimelineViewModel vm)) return;

            // Retrieve templates defined in Window.Resources
            var lineTemplate = Resources["TimelineLineTemplate"] as DataTemplate;
            var eventTemplate = Resources["EventNodeTemplate"] as DataTemplate;
            var markerTemplate = Resources["YearMarkerTemplate"] as DataTemplate;

            foreach (var node in vm.DiagramNodes)
            {
                if (node.IsTimelineLine)
                    node.ContentTemplate = lineTemplate;
                else if (node.IsYearMarker)
                    node.ContentTemplate = markerTemplate;
                else
                    node.ContentTemplate = eventTemplate;
            }
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
    }

    public class HistoryDiagram : SfDiagram
    {
        public Syncfusion.UI.Xaml.Diagram.Selector SFSelector = new Syncfusion.UI.Xaml.Diagram.Selector();
        protected override Syncfusion.UI.Xaml.Diagram.Selector GetSelectorForItemOverride(object item)
        {
            return SFSelector;
        }
    }
}
