using syncfusion.demoscommon.wpf;
using System;

namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Interaction logic for TileViewVirtualization.xaml
    /// </summary>
    public partial class TileViewVirtualizationDemo : DemoControl
    {
        public TileViewVirtualizationDemo()
        {
            InitializeComponent();
           
        }
        public TileViewVirtualizationDemo(string themename): base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();
            
            if (this.tileViewControl != null)
            {
                this.tileViewControl.Dispose();
                this.tileViewControl = null;
            }

            var viewmodel = this.DataContext as TileViewVirtualizationViewModel;
            if (viewmodel != null)
            {
                viewmodel.EmployeeDetails = null;
                viewmodel.LoadTileViewItems = null;
                viewmodel = null;
            }

            if (this.virtualizationGrid != null)
            {
                this.virtualizationGrid.Children.Clear();
                this.virtualizationGrid = null;
            }

            this.DataContext = null;
            base.Dispose(disposing);
        }
    }
}
