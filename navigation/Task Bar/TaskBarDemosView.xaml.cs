#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for TaskBarDemosView.xaml
    /// </summary>
    public partial class TaskBarDemosView : DemoControl
    {
        public TaskBarDemosView()
        {
            InitializeComponent();
        }

        public TaskBarDemosView(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.taskBar != null)
            {
                this.taskBar = null;
            }
            base.Dispose(disposing);
        }
    }
}
