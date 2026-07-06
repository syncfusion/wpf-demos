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

namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Interaction logic for CarouselCusomPath.xaml
    /// </summary>
    public partial class CarouselNavigationDemo : DemoControl
    {
        public CarouselNavigationDemo()
        {
            InitializeComponent();
        }
        public CarouselNavigationDemo(string themename):base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources

            if (ScrollBarVisibilityTypes != null)
            {
                ScrollBarVisibilityTypes.Dispose();
                ScrollBarVisibilityTypes = null;
            }
            if (this.carousel != null)
            {
                this.carousel.Dispose();
                this.carousel = null;
            }
            base.Dispose(disposing);
        }
    }
}
