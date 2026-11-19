using System;
using System.Windows.Controls;
using syncfusion.demoscommon.wpf;

namespace syncfusion.schedulerdemos.wpf
{
    /// <summary>
    /// Interaction logic for LoadOnDemand.xaml
    /// </summary>
    public partial class LoadOnDemandDemo : DemoControl
    {
        public LoadOnDemandDemo()
        {
            InitializeComponent();
        }

        public LoadOnDemandDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            if (this.Schedule != null)
            {
                this.Schedule.Dispose();
                this.Schedule = null;
            }
            base.Dispose(disposing);
        }
    }
}
