using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
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

namespace syncfusion.imageeditordemos.wpf
{
    /// <summary>
    /// Interaction logic for BannerCreator.xaml
    /// </summary>
    public partial class BannerCreator : DemoControl
    {
        public BannerCreator()
        {
            InitializeComponent();
        }

        public BannerCreator(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (imageEditor != null)
            {
                imageEditor.Dispose();
                imageEditor = null;
            }

            base.Dispose(disposing);
        }
    }
}
