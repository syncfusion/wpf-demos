using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.SfToastNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Interaction logic for GroupingDemo.xaml
    /// </summary>
    public partial class GroupingDemo : DemoControl
    {
        public GroupingDemo()
        {
            InitializeComponent();
        }

        private void ApplyGroupSettings()
        {
            // Enable or disable GroupView
            bool enableGroupView = EnableGroupViewCheck.IsChecked ?? false;
            SfToastNotification.EnableGroupView = enableGroupView;

            // Set GroupContainerHeader if provided
            if (!string.IsNullOrEmpty(GroupContainerHeaderBox.Text))
            {
                SfToastNotification.GroupContainerHeader = GroupContainerHeaderBox.Text;
            }
        }

        private void InitializeNotifications_Click(object sender, RoutedEventArgs e)
        {
            ApplyGroupSettings();

            SfToastNotification.Show(this, new ToastOptions()
            {
                Title = "Microsoft Teams",
                Header = "John",
                Message = "Can we discuss the sprint backlog?",
                Severity = ToastSeverity.Info,
                GroupName = "Teams",
                Mode = ToastMode.Screen
            });

            SfToastNotification.Show(this, new ToastOptions()
            {
                Title = "Outlook",
                Header = "Alex",
                Message = "New email received.",
                Severity = ToastSeverity.Warning,
                GroupName = "Outlook",
                Mode = ToastMode.Screen
            });

            SfToastNotification.Show(this, new ToastOptions()
            {
                Title = "GitHub",
                Header = "Build Pipeline",
                Message = "Build completed successfully.",
                Severity = ToastSeverity.Success,
                GroupName = "GitHub",
                Mode = ToastMode.Screen
            });
        }
        private int teamsCount = 1;

        private void AddTeamsNotification_Click(object sender, RoutedEventArgs e)
        {
            ApplyGroupSettings();

            teamsCount++;

            SfToastNotification.Show(this, new ToastOptions()
            {
                Title = "Microsoft Teams",
                Header = $"Team Member {teamsCount}",
                Message = $"New message #{teamsCount}",
                Severity = ToastSeverity.Info,
                GroupName = "Teams",
                Mode = ToastMode.Screen
            });
        }

        private int outlookCount = 1;

        private void AddOutlookNotification_Click(object sender, RoutedEventArgs e)
        {
            ApplyGroupSettings();

            outlookCount++;

            SfToastNotification.Show(this, new ToastOptions()
            {
                Title = "Outlook",
                Header = $"Email {outlookCount}",
                Message = "A new email has arrived.",
                Severity = ToastSeverity.Warning,
                GroupName = "Outlook",
                Mode = ToastMode.Screen
            });
        }

        private int githubCount = 100;

        private void AddGitHubNotification_Click(object sender, RoutedEventArgs e)
        {
            ApplyGroupSettings();

            githubCount++;

            SfToastNotification.Show(this, new ToastOptions()
            {
                Title = "GitHub",
                Header = $"PR #{githubCount}",
                Message = "Pull request status updated.",
                Severity = ToastSeverity.Success,
                GroupName = "GitHub",
                Mode = ToastMode.Screen
            });
        }
    }
}
