#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for AIViewFilterDemo.xaml
    /// </summary>
    public partial class AIViewFilterDemo : DemoControl
    {
        public AIViewFilterDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Releases the resources used by the <see cref="AIViewFilterDemo"/> class, including both managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.dataGrid != null)
            {
                this.dataGrid.Dispose();
                this.dataGrid = null;
            }

            if (this.DataContext != null)
            {
                var dataContext = this.DataContext as EmployeeInfoViewModel;
                dataContext.Dispose();
                this.DataContext = null;
            }

            if (this.busyIndicator != null)
            {
                this.busyIndicator.Dispose();
                this.busyIndicator = null;
            }

            if (this.executePromptButton != null)
                this.executePromptButton = null;

            if (this.resetButton != null)
                this.resetButton = null;

            if (this.queryTextBox != null)
                this.queryTextBox = null;

            base.Dispose(disposing);
        }
    }
}