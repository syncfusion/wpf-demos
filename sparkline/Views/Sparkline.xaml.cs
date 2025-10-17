using syncfusion.demoscommon.wpf;
using System;
using Syncfusion.SfSkinManager;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace syncfusion.sparklinedemos.wpf
{
    /// <summary>
    /// Interaction logic for sparklineMeasures.xaml
    /// </summary>
    public partial class Sparkline : DemoControl
    {
        public Sparkline()
        {
            InitializeComponent();
        }

        public Sparkline(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (dataGrid != null)
            {
                dataGrid.Dispose();
                dataGrid = null;
            }

            base.Dispose(disposing);
        }
    }
}