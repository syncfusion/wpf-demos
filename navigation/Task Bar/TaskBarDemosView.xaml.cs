#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
            if (this.orientationTextBlock != null)
                this.orientationTextBlock = null;
            if (this.orientationType != null)
                this.orientationType = null;
            if (this.groupWidthTextBlock != null)
                this.groupWidthTextBlock = null;
            if (this.increaseTaskBarWidth != null)
                this.increaseTaskBarWidth = null;
            if (this.eventsTextBlock != null)
                this.eventsTextBlock = null;
            if (this.eventsListBox != null)
                this.eventsListBox = null;

            if (taskBarGrid != null)
            {
                taskBarGrid.Children.Clear();
                taskBarGrid = null;
            }
            base.Dispose(disposing);
        }
    }
}
