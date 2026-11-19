using Microsoft.Xaml.Behaviors;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.schedulerdemos.wpf
{
    public class ICSExportImportBehavior : Behavior<ICSExportImport>
    {
        private SfScheduler scheduler;
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            scheduler = AssociatedObject.Schedule;
            this.AssociatedObject.ImportButton.Click += OnImportClicked;
            this.AssociatedObject.ExportButton.Click += OnExportClicked;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.ImportButton.Click -= OnImportClicked;
            this.AssociatedObject.ExportButton.Click -= OnExportClicked;
            this.AssociatedObject.ImportButton = null;
            this.AssociatedObject.ExportButton = null;
            scheduler = null;
        }

        /// <summary>
        /// Exports the scheduler appointments to a local .ics file.
        /// </summary>
        private async void OnExportClicked(object sender, RoutedEventArgs e)
        {
            if (this.scheduler == null)
            {
                return;
            }

            bool exported = await this.scheduler.ExportToICalendar("CalendarICS");
            if (exported)
            {
                MessageBox.Show("Appointments exported successfully to the Downloads folder.", "Success", MessageBoxButton.OK);
            }
        }
        

        /// <summary>
        /// Imports scheduled appointments from a user-picked .ics file.
        /// </summary>
        private async void OnImportClicked(object sender, RoutedEventArgs e)
        {
            if (this.scheduler == null)
            {
                return;
            }

            bool imported = await this.scheduler.ImportICalendar();
            if (imported)
            {
                MessageBox.Show("Appointments imported successfully.", "Success", MessageBoxButton.OK);
            }
        }
    }
}
