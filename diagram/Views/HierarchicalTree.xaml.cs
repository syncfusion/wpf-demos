using syncfusion.demoscommon.wpf;
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
    /// Interaction logic for HierarchicalTree.xaml
    /// </summary>
    public partial class HierarchicalTree : DemoControl
    {
        public HierarchicalTree()
        {
            InitializeComponent();
        }


        public HierarchicalTree(string themename) : base(themename)
        {
            InitializeComponent();
        }

        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var node in Diagram.Nodes as NodeCollection)
            {
                node.Constraints = NodeConstraints.AllowPan;
            }
            foreach (var connector in Diagram.Connectors as ConnectorCollection)
            {
                connector.Constraints = ConnectorConstraints.AllowPan;
            }

            Diagram.Loaded -= Diagram_Loaded;
        }

        protected override void Dispose(bool disposing)
        {
            BindingOperations.ClearBinding(Part_HorizontalSpacing, Syncfusion.Windows.Shared.UpDown.ValueProperty);
            BindingOperations.ClearBinding(Part_VerticalSpacing, Syncfusion.Windows.Shared.UpDown.ValueProperty);

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
}
