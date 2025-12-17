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
using System.Windows.Shapes;

namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Interaction logic for SplitterCustomizationDemo.xaml
    /// </summary>
    public partial class SplitterCustomizationDemo : DemoControl
    {
        public SplitterCustomizationDemo()
        {
            InitializeComponent();
        }
        public SplitterCustomizationDemo(string themename):base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if(this.CalendarEdit!=null)
            {
               this.CalendarEdit.Dispose();
                this.CalendarEdit = null;
            }

            GridSplitter.Children.Clear();
            base.Dispose(disposing);           
        }
    }
}
