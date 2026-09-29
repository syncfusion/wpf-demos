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
    /// Interaction logic for TreeMapCustomization.xaml
    /// </summary>
    public partial class TreeMapCustomization : DemoControl
    {
        public TreeMapCustomization()
        {
            InitializeComponent();
        }

        public TreeMapCustomization(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (treeMap != null)
            {
                treeMap.Dispose();
                treeMap = null;
            }

            base.Dispose(disposing);
        }
    }
}
