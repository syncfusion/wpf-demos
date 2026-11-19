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
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;

namespace syncfusion.datagriddemos.wpf 
{
    /// <summary>
    /// Interaction logic for FilterRowDemo.xaml
    /// </summary>
    public partial class FilterRowDemo : DemoControl
    {
        public FilterRowDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.sfgrid != null)
            {
                this.sfgrid.Dispose();
                this.sfgrid = null;
            }

            base.Dispose(disposing);
        }
    }
}
