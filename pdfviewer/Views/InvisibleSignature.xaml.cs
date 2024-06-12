#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfviewerdemos.wpf
{
    /// <summary>
    /// Interaction logic for InvisibleSignature.xaml
    /// </summary>
    public partial class InvisibleSignature : DemoControl
    {
        public InvisibleSignature()
        {
            InitializeComponent();
        }
        public InvisibleSignature(string themename) : base(themename)
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            pdfviewer1.ShowToolbar = true;
            pdfviewer1.IsBookmarkEnabled = true;
            pdfviewer1.ThumbnailSettings.IsVisible = true;
            pdfviewer1.EnableLayers = true;
            pdfviewer1.PageOrganizerSettings.IsIconVisible = true;
            pdfviewer1.EnableRedactionTool = true;
            pdfviewer1.FormSettings.IsIconVisible = true;
            pdfviewer1.Unload(true);
            pdfviewer1 = null;
            if (this.DataContext is InvisibleSignatureViewModel)
            {
                (this.DataContext as InvisibleSignatureViewModel).DocumentStream.Dispose();
                if ((this.DataContext as InvisibleSignatureViewModel).SignatureStream != null)
                    (this.DataContext as InvisibleSignatureViewModel).SignatureStream.Dispose();
                this.DataContext = null;
            }
            base.Dispose(disposing);
        }
    }
}
