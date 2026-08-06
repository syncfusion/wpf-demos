using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for Snapping.xaml
    /// </summary>
    public partial class Snapping : DemoControl
    {
        public Snapping()
        {
            InitializeComponent();
        }

        public Snapping(string themename) : base(themename)
        {
            InitializeComponent();
            this.DataContext = new SnappingViewModel(this);
            Diagram.SnapSettings = (this.DataContext as SnappingViewModel).SnapSettings;
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
}
