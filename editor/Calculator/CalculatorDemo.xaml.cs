#region Copyright Syncfusion Inc. 2001-2021
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.editordemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CalculatorDemo : DemoControl
    {
        /// <summary>
        /// Constructor for window1.
        /// </summary>

        public CalculatorDemo()
        {
            InitializeComponent();
        }

        public CalculatorDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.Calculator != null)
            {
                this.Calculator = null;
            }

            base.Dispose(disposing);
        }
    }
}

