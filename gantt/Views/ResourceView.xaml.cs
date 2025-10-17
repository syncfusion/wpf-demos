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
using System.Windows.Shapes;

namespace syncfusion.ganttdemos.wpf
{
    /// <summary>
    /// Interaction logic for ResourceView.xaml
    /// </summary>
    public partial class ResourceView : DemoControl
    {
        ResourceViewModel resourceViewModel;
        public ResourceView()
        {
            InitializeComponent();
        }

        public ResourceView(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (resourceViewModel == null)
                resourceViewModel = this.DataContext as ResourceViewModel;
         
            resourceViewModel.Dispose();
            base.Dispose(disposing);
        }
    }
}
