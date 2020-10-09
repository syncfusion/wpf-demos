#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Gauges;
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

namespace syncfusion.gaugedemos.wpf
{
    /// <summary>
    /// Interaction logic for DirectionCompass.xaml
    /// </summary>
    public partial class DirectionCompass : DemoControl
    {
        DirectionCompassBehavior directionCompassBehavior;
        public DirectionCompass()
        {
            InitializeComponent();
        }

        public DirectionCompass(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (directionCompassBehavior == null)
                directionCompassBehavior = this.Behavior as DirectionCompassBehavior;
            directionCompassBehavior.Dispose();

            if (circularGauge != null)
            {
                circularGauge.Dispose();
                circularGauge = null;
            }

            base.Dispose(disposing);
        }
    }
}
