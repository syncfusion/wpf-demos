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
    /// Interaction logic for Customization.xaml
    /// </summary>
    public partial class Customization : DemoControl
    {
        public Customization()
        {
            InitializeComponent();
        }

        public Customization(string themename) : base(themename)
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

            base.Dispose(disposing);
        }
    }
}
