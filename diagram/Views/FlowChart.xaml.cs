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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for FlowChart.xaml
    /// </summary>
    public partial class FlowChart : DemoControl
    {
        public FlowChart()
        {
            InitializeComponent();
        }

        public FlowChart(string themename) : base(themename)
        {
            InitializeComponent();
            this.DataContext = new FlowChartViewModel(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            if (this.sfdiagram != null)
            {
                this.sfdiagram = null;
            }
            base.Dispose(disposing);
        }
    }
}
