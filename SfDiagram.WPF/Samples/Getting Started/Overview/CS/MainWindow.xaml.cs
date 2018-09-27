using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Shared;

namespace Overview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //To disable ContextMenu
            diagramControl.Menu = null;
            diagramControl.Tool = Tool.ZoomPan;
        }       
    }
}
