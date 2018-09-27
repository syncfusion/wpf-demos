using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Windows;

namespace Stencil
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        IGraphInfo info = diagram.Info as IGraphInfo;
        info.ItemAdded += info_ItemAdded;
        }

        void info_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            if (args.ItemSource == ItemSource.ClipBoard)
            {
                if (args.Item is INode)
                {
                    NodeViewModel node = args.Item as NodeViewModel;

                    node.ShapeStyle = this.Resources["shapeStyle"] as Style;
                }
            }
        }

      //Filter event
        private bool SymbolFilter(SymbolFilterProvider sender, object symbol)
        {
            return true;
        }
    }


    //Collection of Symbols
    public class SymbolCollection : ObservableCollection<NodeVm>
    {

    }

    //Collection of Ports
    public class PortCollection : ObservableCollection<INodePort>
    {

    }
    
    public class NodeVm : NodeViewModel
    {

    }
}
