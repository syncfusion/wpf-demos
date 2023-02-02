#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.propertygriddemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CategoryEditorDemo : DemoControl 
    {
        public CategoryEditorDemo()
        {
            InitializeComponent();
        }
        public CategoryEditorDemo(string themename):base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.Resources != null)
            {
                this.Resources.Clear();
            }

            if (this.propertygrid != null)
            {
                this.propertygrid.Dispose();
                this.propertygrid = null;
            }

            if (this.tabControlExt != null)
            {
                this.tabControlExt.Dispose();
                this.tabControlExt = null;
            }

            base.Dispose(disposing);
        }
    }
}
