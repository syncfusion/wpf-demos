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
    /// Interaction logic for GanttStyleProperties.xaml
    /// </summary>
    public partial class GanttStyleProperties : DemoControl
    {
        GanttStylePropertiesViewModel ganttStylePropertiesViewModel;
        public GanttStyleProperties()
        {
            InitializeComponent();
        }

        public GanttStyleProperties(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (ganttStylePropertiesViewModel == null)
                ganttStylePropertiesViewModel = this.DataContext as GanttStylePropertiesViewModel;

            ganttStylePropertiesViewModel.Dispose();
            base.Dispose(disposing);
        }
    }
}
