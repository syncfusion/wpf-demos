using System;
using System.Windows;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Scroll;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.GridCommon;
using System.Windows.Media;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for NestedGrid.xaml
    /// </summary>

    public partial class NestedGrid : DemoControl
    {

        public NestedGrid()
        {
            InitializeComponent();
            // An Optimization. Allow live controls inside cell to be reused when scrolled out of view.
        }

        public NestedGrid(string themename) : base(themename)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.grid.MouseControllerDispatcher.TrackMouse = this.grid.GetClipRect(ScrollAxisRegion.Body, ScrollAxisRegion.Body);
        }

        protected override void Dispose(bool disposing)
        {
            if (this.grid.Model != null)
            {
                this.grid.Model.Dispose();
                this.grid.Model = null;
            }
            if (this.grid != null)
            {
                this.grid.Dispose();
                this.grid = null;
            }
            base.Dispose(disposing);
        }

    }
}