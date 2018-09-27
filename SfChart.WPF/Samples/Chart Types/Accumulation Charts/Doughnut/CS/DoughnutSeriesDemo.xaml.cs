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

namespace DoughnutChart
{
    /// <summary>
    /// Interaction logic for DoughnutSeriesDemo.xaml
    /// </summary>
    public partial class DoughnutSeriesDemo : UserControl
    {
        public DoughnutSeriesDemo()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Syncfusion.Licensing.DemoCommon.FindLicenseKey());

            InitializeComponent();
        }
    }
}
