using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using System;
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

namespace syncfusion.bulletgraphdemos.wpf
{
    /// <summary>
    /// Interaction logic for BulletGraphMeasures.xaml
    /// </summary>
    public partial class BulletGraphMeasures : DemoControl
    {
        public BulletGraphMeasures()
        {
            InitializeComponent();
        }

        public BulletGraphMeasures(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (SfBulletGraph != null)
            {
                SfBulletGraph.Dispose();
                SfBulletGraph = null;
            }

            base.Dispose(disposing);
        }
    }
}