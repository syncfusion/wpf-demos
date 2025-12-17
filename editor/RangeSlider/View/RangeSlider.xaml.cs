using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Controls.Input;
using Syncfusion.Windows.Shared;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RangeSliderDemo : DemoControl
    {
        public RangeSliderDemo()
        {
            InitializeComponent();
        }

        public RangeSliderDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.range != null)
            {
                this.range.Dispose();
                this.range = null;
            }

            if (this.rangeslider != null)
            {
                this.rangeslider.Dispose();
                this.rangeslider = null;
            }

            base.Dispose(disposing);
        }
    }
}
