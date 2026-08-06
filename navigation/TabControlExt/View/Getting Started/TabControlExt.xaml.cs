using syncfusion.demoscommon.wpf;
using System.Windows.Data;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for TabControlExt.xaml
    /// </summary>
    public partial class TabControlExtDemosView : DemoControl
    {
        public TabControlExtDemosView()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.TabItemExtGrid.Children.Clear();
            if (this.Tab != null)
            {                         
                BindingOperations.ClearAllBindings(Tab);
                this.Tab.Dispose();
                this.Tab = null;
               
            }
            base.Dispose(disposing);
        }
    }
}