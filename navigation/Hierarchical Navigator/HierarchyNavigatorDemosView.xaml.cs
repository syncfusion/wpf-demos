
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
                this.hierarchyNavigator = null;

            if (this.enableHistory != null)
            {
                System.Windows.Data.BindingOperations.ClearBinding(enableHistory, System.Windows.Controls.CheckBox.IsCheckedProperty);
                this.enableHistory = null;
            }

            if (this.enableEdit != null)
            {
                System.Windows.Data.BindingOperations.ClearBinding(enableEdit, System.Windows.Controls.CheckBox.IsCheckedProperty);
                this.enableEdit = null;
            }

            if (this.progressSpeedTextBlock != null)
                this.progressSpeedTextBlock = null;

            if (this.progressBarSeconds != null)
                this.progressBarSeconds = null;

            if (this.progressActionTextBlock != null)
                this.progressActionTextBlock = null;
            
            if (this.showButton != null)
            {
                showButton.Click -= ShowButton_Click;
                showButton = null;
            }
            if (this.cancelButton != null)
            {
                cancelButton.Click -= CancelButton_Click;
                cancelButton = null;
            }
            if (this.itemsListBox != null)
            {
                System.Windows.Data.BindingOperations.ClearBinding(itemsListBox, System.Windows.Controls.ListBox.ItemsSourceProperty);
                itemsListBox.ItemsSource = null;
                itemsListBox.ItemTemplate = null;
                itemsListBox.ItemsPanel = null;
                itemsListBox = null;
            }
            if (this.eventListBox != null)
            {
                System.Windows.Data.BindingOperations.ClearBinding(eventListBox, System.Windows.Controls.ListBox.ItemsSourceProperty);
                eventListBox.ItemsSource = null;
                eventListBox = null;
            }
            
            if(this.eventTextBlock!=null)
                this.eventTextBlock = null;

            if (this.DataContext is IDisposable disposableViewModel)
            {
                disposableViewModel.Dispose();
            }

            this.DataContext = null;

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
