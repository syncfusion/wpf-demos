using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;
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

namespace syncfusion.ganttdemos.wpf
{
    /// <summary>
    /// Interaction logic for CustomNodeStyle.xaml
    /// </summary>
    public partial class CustomNodeStyle : DemoControl
    {
        CustomNodeStyleViewModel customNodeStyleViewModel;
        public CustomNodeStyle()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (customNodeStyleViewModel == null)
                customNodeStyleViewModel = this.DataContext as CustomNodeStyleViewModel;
            customNodeStyleViewModel.Dispose();
            base.Dispose(disposing);
        }
    }
}
