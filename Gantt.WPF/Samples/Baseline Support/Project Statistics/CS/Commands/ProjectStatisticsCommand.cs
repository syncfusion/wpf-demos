#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Gantt;
using System.Windows.Media;
using System.Threading;
using System.Windows;

namespace ProjectStatistics
{
    public class ProjectStatisticsCommand
    {
        static ProjectStatisticsCommand()
        {
            //Registering the GetStatistics Command
            CommandManager.RegisterClassCommandBinding(typeof(GanttControl), new CommandBinding(GetStatistics, OnExecuteGetStatistics, OnCanExecuteGetStatistics));
        }

        public static RoutedCommand GetStatistics = new RoutedCommand("GetStatistics", typeof(GanttControl));

        /// <summary>
        /// Called when [execute get statistics].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteGetStatistics(object sender, ExecutedRoutedEventArgs args)
        {
            GanttControl gantt = args.Source as GanttControl;
            ProjectInfo Info = new ProjectInfo();
            Info = gantt.GetProjectStatistics();
            StatisticsViewModel view = new StatisticsViewModel(Info);
            StatisticsWindow statisticsView = new StatisticsWindow(view);
            statisticsView.ShowDialog();   
        }

        /// <summary>
        /// Called when [can execute get statistics].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteGetStatistics(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
