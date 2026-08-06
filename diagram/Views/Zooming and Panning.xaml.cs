using syncfusion.demoscommon.wpf;
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
    /// Interaction logic for Zooming_and_Panning.xaml
    /// </summary>
    public partial class Zooming_and_Panning : DemoControl
    {
        public Zooming_and_Panning()
        {
            InitializeComponent();
        }

        public Zooming_and_Panning(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            if (this.SfDiagram != null)
            {
                if (this.SfDiagram.ScrollSettings != null)
                {
                    this.SfDiagram.ScrollSettings = null;
                }
                this.SfDiagram = null;
            }
            base.Dispose(disposing);
        }
    }
}
