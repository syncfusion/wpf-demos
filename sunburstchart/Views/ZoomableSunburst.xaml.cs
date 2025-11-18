using syncfusion.demoscommon.wpf;
using System;
using Syncfusion.SfSkinManager;
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

namespace syncfusion.sunburstchartdemos.wpf
{
    /// <summary>
    /// Interaction logic for ZoomableSunburst.xaml
    /// </summary>
    public partial class ZoomableSunburst : DemoControl
    {
        public ZoomableSunburst()
        {
            InitializeComponent();
        }

        public ZoomableSunburst(string themename) : base(themename)
        {
            InitializeComponent();
        }
    }
}
