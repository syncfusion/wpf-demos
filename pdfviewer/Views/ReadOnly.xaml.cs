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
    /// Interaction logic for Shapes.xaml
    /// </summary>
    public partial class ReadOnly : DemoControl
    {
        public ReadOnly()
        {
            InitializeComponent();
        }
        public ReadOnly(string themename) : base(themename)
        {
            InitializeComponent();
            ToggleVisibilityVerticalToolbar(false);
        }

        private void ToggleVisibilityVerticalToolbar(bool visibleStatus)
        {
            // Hides the layer icon. 
            pdfviewer1.EnableLayers = visibleStatus;
            // Hides the organize page icon. 
            pdfviewer1.PageOrganizerSettings.IsIconVisible = visibleStatus;
            // Hides the redaction icon. 
            pdfviewer1.EnableRedactionTool = visibleStatus;
            // Hides the form icon. 
            pdfviewer1.FormSettings.IsIconVisible = visibleStatus;
        }
        protected override void Dispose(bool disposing)
        {
            ToggleVisibilityVerticalToolbar(true);
            pdfviewer1.Unload(true);
            pdfviewer1 = null;
            if (this.DataContext is ReadOnlyViewModel)
            {
                (this.DataContext as ReadOnlyViewModel).DocumentStream.Dispose();
                this.DataContext = null;
            }
            base.Dispose(disposing);
        }
    }
}
