#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
    public partial class CalenderEditDemo : DemoControl
    {
        public CalenderEditDemo()
        {
            InitializeComponent();
        }

        public CalenderEditDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if(calendaredit1 != null)
            {
                calendaredit1.Dispose();
                calendaredit1 = null;
            }
            if(WeekNumber != null)
            {
                WeekNumber.Dispose();
                WeekNumber = null;
            }
            if (PrevAndNextMonth != null)
            {
                PrevAndNextMonth.Dispose();
                PrevAndNextMonth = null;
            }
            if(MaxAndMinDays != null)
            {
                MaxAndMinDays.Dispose();
                MaxAndMinDays = null;
            }
            base.Dispose(disposing);
        }
    }
}
