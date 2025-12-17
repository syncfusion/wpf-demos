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

namespace syncfusion.treemapdemos.wpf
{
    /// <summary>
    /// Interaction logic for HierarchicalCollectionTreeMap.xaml
    /// </summary>
    public partial class HierarchicalCollectionTreeMap : DemoControl
    {
        public HierarchicalCollectionTreeMap()
        {
            InitializeComponent();
        }

        public HierarchicalCollectionTreeMap(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (treemap != null)
            {
                treemap.Dispose();
                treemap = null;
            }

            base.Dispose(disposing);
        }
    }
}
