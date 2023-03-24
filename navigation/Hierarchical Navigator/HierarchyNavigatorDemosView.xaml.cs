#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;
using System;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for HierarchyNavigatorDemosView.xaml
    /// </summary>
    public partial class HierarchyNavigatorDemosView : DemoControl
    {
        public HierarchyNavigatorDemosView()
        {
            InitializeComponent();
        }

        public HierarchyNavigatorDemosView(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.Resources != null)
                this.Resources.Clear();
            if (this.hierarchyNavigator != null)
            {
                this.hierarchyNavigator = null;
            }
            if (this.enableHistory != null)
                this.enableHistory = null;
            if (this.enableEdit != null)
                this.enableEdit = null;
            if (this.progressSpeedTextBlock != null)
                this.progressSpeedTextBlock = null;
            if (this.progressBarSeconds != null)
                this.progressBarSeconds = null;
            if (this.progressActionTextBlock != null)
                this.progressActionTextBlock = null;
            if (this.showButton != null)
                this.showButton = null;
            if (this.cancelButton != null)
                this.cancelButton = null;
            base.Dispose(disposing);
        }

        private void ShowButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            hierarchyNavigator.ShowProgressBar(new TimeSpan(0, 0, 0, 0, (int)progressBarSeconds.Value));
        }

        private void CancelButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            hierarchyNavigator.CancelProgressBar(new TimeSpan(0, 0, 0, 0, (int)progressBarSeconds.Value));
        }
    }
}
