using Microsoft.Xaml.Behaviors;
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;

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
                Interaction.GetTriggers(groupBar)?.Clear();
                if (this.groupBar.ItemsSource == null)
                {
                    foreach (GroupBarItem item in this.groupBar.Items)
                    {
                        item.Content = null;
                            
                    }
                    this.groupBar.Items.Clear();
                }

                this.groupBar.Dispose();
                this.groupBar = null;
            }
               
            if (this.selectedControlContent != null)
            {
                this.selectedControlContent.Content = null;
                this.selectedControlContent = null;
            }

            if (this.outlookGrid != null)
            {
                this.outlookGrid.Children.Clear();
                this.outlookGrid = null;
            }
            this.DataContext = null;
            base.Dispose(disposing);
        }
    }
}
