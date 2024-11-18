#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfviewerdemos.wpf
{
    /// <summary>
    /// Interaction logic for SmartFill.xaml
    /// </summary>
    public partial class SmartFill : DemoControl
    {
        public SmartFill()
        {
            InitializeComponent();
        }
        public SmartFill(string themename) : base(themename)
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            pdfviewer1.Unload(true);
            pdfviewer1 = null;
            if (this.DataContext is SmartFillViewModel)
            {
                (this.DataContext as SmartFillViewModel).DocumentStream.Dispose();
                this.DataContext = null;
            }
            base.Dispose(disposing);
        }
    }
}
