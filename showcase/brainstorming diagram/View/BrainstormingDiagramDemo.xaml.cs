using syncfusion.brainstormingdiagram.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.brainstormingdiagram.wpf
{
    /// <summary>
    /// Interaction logic for FloorPlannerDemo.xaml
    /// </summary>
    public partial class BrainstormingDiagramDemo : ChromelessWindow
    {
        public BrainstormingDiagramDemo()
        {
            InitializeComponent();
            this.DataContext = mindmapDiagram.ViewModel;
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "FluentLight" });
            if (this.DataContext != null)
            {
                (this.DataContext as MindMapViewModel).View = this;
            }
            if (this.DataContext != null)
            {
                (this.DataContext as MindMapViewModel).RecentFilePanel = RecentArea;
            }

            this.SizeChanged += FloorPlannerDemo_SizeChanged;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.SizeChanged -= FloorPlannerDemo_SizeChanged;

            menuBar.Dispose();
            if (menuBar.Parent is Grid)
            {
                (menuBar.Parent as Grid).Children.Remove(menuBar);
            }

            mindmapDiagram.DataContext = null;
            if (this.DataContext != null && this.DataContext is MindMapViewModel)
            {
                (this.DataContext as MindMapViewModel).View = null;
                (this.DataContext as MindMapViewModel).RecentFilePanel = null;
            }

            GC.SuppressFinalize(this);

            this.DataContext = null;
            base.OnClosing(e);
        }

        private void FloorPlannerDemo_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            var count = Math.Round(e.NewSize.Width / 196);
            double marginLeft = (e.NewSize.Width - (((count > 3 ? count - 2 : count - 1) * 196) + 30)) * 0.5;
            this.BackStageArea.Margin = new Thickness(marginLeft, 48, marginLeft, 48);
        }
    }

    public class SymbolCollection : ObservableCollection<NodeViewModel>
    {

    }
}
