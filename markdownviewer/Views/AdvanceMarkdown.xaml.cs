using syncfusion.demoscommon.wpf;
//using Syncfusion.UI.Xaml.Diagram;
//using Syncfusion.UI.Xaml.Diagram.Layout;
using System.Windows;

namespace syncfusion.markdownviewerdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for Overview.xaml
    /// </summary>
    public partial class AdvanceMarkdown : DemoControl
    {
        public AdvanceMarkdown()
        {
            InitializeComponent();
        }

        //private void mermaidDiagram_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (sender is Syncfusion.UI.Xaml.Diagram.SfDiagram diagram)
        //    {
        //        diagram.PageSettings = null;
        //        diagram.ScrollSettings.ScrollLimit = ScrollLimit.Limited;
        //        var mermaidText = diagram.DataContext as string;
        //        diagram.LayoutManager = new LayoutManager
        //        {
        //            Layout = new FlowchartLayout
        //            {
        //                Orientation = FlowchartOrientation.TopToBottom,
        //                HorizontalSpacing = 80,
        //                VerticalSpacing = 60,
        //                Margin = new Thickness(-200, 50, 0, 0),
        //            }
        //        };

        //        diagram.LoadDiagramFromMermaid(mermaidText);
        //    }
        //}
    }
}
