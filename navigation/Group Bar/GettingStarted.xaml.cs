
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for GettingStarted.xaml
    /// </summary>
    public partial class GroupBarGettingStarted : DemoControl
    {
        public GroupBarGettingStarted()
        {
            InitializeComponent();
        }

        public GroupBarGettingStarted(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.groupBar != null)
            {
                if (this.groupBar.ItemsSource == null && this.groupBar.Items.Count > 0)
                {
                    foreach (GroupBarItem item in this.groupBar.Items)
                    {
                        item?.Dispose();
                    }
                    this.groupBar.Items.Clear();
                }

                this.groupBar.Dispose();
                this.groupBar = null;
            }
            if (this.visualModeTextBlock != null)
                this.visualModeTextBlock = null;
            if (this.visualModeComboBox != null)
                this.visualModeComboBox = null;
            if (this.collapsedWidthTextBlock != null)
                this.collapsedWidthTextBlock = null;
            if (this.changeCollapseWidth != null)
                this.changeCollapseWidth = null;
            if (this.contextAction != null)
                this.contextAction = null;
            if (this.showToolTip != null)
                this.showToolTip = null;
            if (this.checkBoxAllowCollapse != null)
                this.checkBoxAllowCollapse = null;
            if (this.gettingStartedGrid != null)
            {
                this.gettingStartedGrid.Children.Clear();
                this.gettingStartedGrid = null;
            }

            var viewModel = this.DataContext as GroupBarGettingStartedViewModel;
            if (viewModel != null)
            {
                viewModel = null;
            }
            this.DataContext = null;
            if (this.Resources != null)
                this.Resources.Clear();
            base.Dispose(disposing);
        }
    }
}
