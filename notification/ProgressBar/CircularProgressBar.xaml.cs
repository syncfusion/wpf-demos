#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.ProgressBar;
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

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CircularProgressBar : DemoControl
    {
        public CircularProgressBar()
        {
            InitializeComponent();
        }

        public CircularProgressBar(string themename) : base(themename)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dispose the data context objects.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (DataContext is IDisposable disposable)
            {
                disposable.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Method represent when pause button clicked. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseButton_Clicked(object sender, RoutedEventArgs e)
        {
            PlayButton.Visibility = Visibility.Visible;
            PauseButton.Visibility = Visibility.Hidden;
            (this.DataContext as CircularProgressBarViewModel).PlayPauseTimer.Stop();
        }

        /// <summary>
        /// Method represent when play button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayButton_Clicked(object sender, RoutedEventArgs e)
        {
            PlayButton.Visibility = Visibility.Hidden;
            PauseButton.Visibility = Visibility.Visible;
            (this.DataContext as CircularProgressBarViewModel).PlayPauseTimer.Start();
        }
    }
}
