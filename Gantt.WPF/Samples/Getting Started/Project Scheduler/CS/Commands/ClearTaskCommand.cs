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

namespace ProjectScheduler
{
    /// <summary>
    /// Code for Delete all task in Gantt Control
    /// </summary>
    public class ClearTaskCommand
    {
        static ClearTaskCommand()
        {
            //Registering the ClearAllTask command
            CommandManager.RegisterClassCommandBinding(typeof(GanttControl), new CommandBinding(ClearAllTask, OnExecuteClearAllTask, OnCanExecuteClearAllTask));
        }

        public static RoutedCommand ClearAllTask = new RoutedCommand("ClearAllTask", typeof(GanttControl));

        /// <summary>
        /// Called when [execute clear all task].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteClearAllTask(object sender, ExecutedRoutedEventArgs args)
        {
            GanttControl gantt = args.Source as GanttControl;
            gantt.Model.InbuiltTaskCollection.Clear();
        }

        /// <summary>
        /// Called when [can execute clear all task].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteClearAllTask(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
