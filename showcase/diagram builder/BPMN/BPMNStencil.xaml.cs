using syncfusion.diagrambuilder.wpf.View;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.UI.Xaml.Diagram.Theming;
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

namespace syncfusion.diagrambuilder.wpf.BPMN
{
    /// <summary>
    /// Interaction logic for BPMNStencil.xaml
    /// </summary>
    public partial class BPMNStencil : UserControl, IStencilTheme
    {
        public BPMNStencil()
        {
            InitializeComponent();
            this.Loaded += BPMNStencil_Loaded;
        }

        public DiagramTheme Theme
        {
            get
            {
                return stencil.DiagramTheme;
            }
            set
            {
                if (stencil.DiagramTheme != value)
                {
                    stencil.DiagramTheme = value;
                }
            }
        }

        private void BPMNStencil_Loaded(object sender, RoutedEventArgs e)
        {
            stencil.SymbolGroups = new SymbolGroups()
            {
                new SymbolGroupViewModel()
                {
                    Name = "BPMN Shapes",
                    CategorySource = this.Resources["BPMNEditorShapes"] as IEnumerable<string>,
                },
            };
        }
    }
}
