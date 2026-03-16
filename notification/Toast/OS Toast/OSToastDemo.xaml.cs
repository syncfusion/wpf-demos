#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Interaction logic for OSToastDemo.xaml
    /// </summary>
    public partial class OSToastDemo : DemoControl
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private int _progress = 0;
        private readonly string _outputFile = "Sales_Report_2026_01.xlsx";

        public OSToastDemo()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromMilliseconds(120);
            _timer.Tick += OnTick;
        }

        private void OnStartDownload(object sender, RoutedEventArgs e)
        {
            if (_timer.IsEnabled)
                return;

            // Start fresh for every download
            ResetUI();

            StatusText.Text = "Preparing…";
            DownloadButton.IsEnabled = false;

            _timer.Start();
        }

        private void OnTick(object sender, EventArgs e)
        {
            _progress += 5;
            DownloadBar.Value = _progress;

            if (_progress < 20) StatusText.Text = "Connecting…";
            else if (_progress < 60) StatusText.Text = "Downloading…";
            else if (_progress < 100) StatusText.Text = "Finalizing…";

            if (_progress >= 100)
            {
                _timer.Stop();
                StatusText.Text = "Completed";
                // --- Display Toast ---
                SfToastNotification.Show(this, new ToastOptions
                {
                    Mode = ToastMode.Default,
                    Title = "Download completed",
                    Message = $"{_outputFile} has been saved.",
                });

                // Reset UI for the next download
                ResetUI();
            }
        }

        private void ResetUI()
        {
            _progress = 0;
            DownloadBar.Value = 0;
            StatusText.Text = string.Empty;
            DownloadButton.IsEnabled = true;
        }
    }

}
