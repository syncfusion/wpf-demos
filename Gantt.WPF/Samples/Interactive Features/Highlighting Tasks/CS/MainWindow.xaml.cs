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
