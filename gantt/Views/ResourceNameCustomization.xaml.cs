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
    /// Interaction logic for ResourceNameCustomization.xaml
    /// </summary>
    public partial class ResourceNameCustomization : DemoControl
    {
        ResourceNameCustomizationViewModel resourceNameCustomizationViewModel;
        public ResourceNameCustomization()
        {
            InitializeComponent();
        }

        public ResourceNameCustomization(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (resourceNameCustomizationViewModel == null)
                resourceNameCustomizationViewModel = this.DataContext as ResourceNameCustomizationViewModel;
            resourceNameCustomizationViewModel.Dispose();
            base.Dispose(disposing);
        }
    }
}
