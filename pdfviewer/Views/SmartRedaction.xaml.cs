#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfviewerdemos.wpf
{
    /// <summary>
    /// Interaction logic for SmartRedaction.xaml
    /// </summary>
    public partial class SmartRedaction : DemoControl
    {
        #region Constructor
        public SmartRedaction()
        {
            InitializeComponent();
        }
        #endregion
        public SmartRedaction(string themename) : base(themename)
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            pdfviewer1.Unload(true);
            pdfviewer1 = null;
            if (this.DataContext is SmartRedactionViewModel)
            {
                (this.DataContext as SmartRedactionViewModel).DocumentStream.Dispose();
                this.DataContext = null;
            }
            base.Dispose(disposing);
        }
    }
}