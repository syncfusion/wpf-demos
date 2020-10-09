#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
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
    /// Interaction logic for PointerCustomization.xaml
    /// </summary>
    public partial class PointerCustomization : DemoControl
    {
        public PointerCustomization()
        {
            InitializeComponent();
        }

        public PointerCustomization(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (circularGauge1 != null)
            {
                circularGauge1.Dispose();
                circularGauge1 = null;
            }

            if (circularGauge2 != null)
            {
                circularGauge2.Dispose();
                circularGauge2 = null;
            }

            if (circularGauge3 != null)
            {
                circularGauge3.Dispose();
                circularGauge3 = null;
            }
            
            if (circularGauge4 != null)
            {
                circularGauge4.Dispose();
                circularGauge4 = null;
            }
            
            if (circularGauge5 != null)
            {
                circularGauge5.Dispose();
                circularGauge5 = null;
            }
            
            base.Dispose(disposing);
        }
    }
}
