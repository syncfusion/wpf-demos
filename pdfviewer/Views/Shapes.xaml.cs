#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfviewerdemos.wpf
{
    /// <summary>
    /// Interaction logic for Shapes.xaml
    /// </summary>
    public partial class Shapes : DemoControl
    {
        public Shapes()
        {
            InitializeComponent();
        }
        public Shapes(string themename) : base(themename)
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            if(this.DataContext is AnnotationsViewModel)
            {
                (this.DataContext as AnnotationsViewModel).DocumentStream.Dispose();
                this.DataContext = null;
            }
            pdfviewer1.Unload(true);
            pdfviewer1 = null;
            base.Dispose(disposing);
        }
    }
}
