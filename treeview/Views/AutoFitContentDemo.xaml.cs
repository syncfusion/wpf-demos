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

namespace syncfusion.treeviewdemos.wpf
{
    /// <summary>
    /// Interaction logic for AutoFitContent.xaml
    /// </summary>
    public partial class AutoFitContentDemo : DemoControl
    {
        public AutoFitContentDemo()
        {
            InitializeComponent();
        }

		public AutoFitContentDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }
		
        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.treeView != null)
            {
                this.treeView.Dispose();
                this.treeView = null;
            }

            if (this.DataContext != null)
                this.DataContext = null;
            
            base.Dispose(disposing);
        }
    }
}
