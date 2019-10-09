#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.Windows.Controls.Gantt;
using System.Windows.Media;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;

namespace HighlightingTasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();     
        }

        private void Gantt_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (this.Gantt != null)
            {
                ViewModel viewModel = this.Gantt.DataContext as ViewModel;
                if (viewModel != null)
                {
                    viewModel.StartTime = this.Gantt.ActualStartTime;
                    viewModel.EndTime = this.Gantt.ActualEndTime;
                }
            }
        }
    }
}
