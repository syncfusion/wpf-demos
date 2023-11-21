#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for Outlook.xaml
    /// </summary>
    public partial class GroupBarOutlook : DemoControl
    {
        public GroupBarOutlook()
        {
            InitializeComponent();
        }

        public GroupBarOutlook(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.Resources != null)
                this.Resources.Clear();
            if (this.groupBar != null)
            {
                this.groupBar.Dispose();
                this.groupBar = null;
            }

            if (this.selectedControlContent != null)
            {
                this.selectedControlContent = null;
            }

            if(this.outlookGrid != null)
            {
                this.outlookGrid.Children.Clear();
                this.outlookGrid = null;
            }       
            base.Dispose(disposing);
        }
    }
}