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

namespace BaselineTableView
{
    public class BaselineCommands
    {
        static BaselineCommands()
        {
            //Registering the LoadVarianceView Command
            CommandManager.RegisterClassCommandBinding(typeof(GanttControl), new CommandBinding(LoadVarianceView, OnExecuteLoadVarianceView, OnCanExecuteLoadVarianceView));

            //Registering the LoadDefaultView Command
            CommandManager.RegisterClassCommandBinding(typeof(GanttControl), new CommandBinding(LoadDefaultView, OnExecuteLoadDefaultView, OnCanExecuteLoadDefaultView));
        }

        public static RoutedCommand LoadVarianceView = new RoutedCommand("LoadVarianceView", typeof(GanttControl));
        
        public static RoutedCommand LoadDefaultView = new RoutedCommand("LoadDefaultView", typeof(GanttControl));

        /// <summary>
        /// Called when [execute load variance view].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteLoadVarianceView(object sender, ExecutedRoutedEventArgs args)
        {
            GanttControl gantt = args.Source as GanttControl;
            gantt.LoadVarianceTableView();
        }

        /// <summary>
        /// Called when [execute load default view].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteLoadDefaultView(object sender, ExecutedRoutedEventArgs args)
        {
            GanttControl gantt = args.Source as GanttControl;
            gantt.LoadDefaultTableView();
        }

        /// <summary>
        /// Called when [can execute load variance view].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteLoadVarianceView(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        /// <summary>
        /// Called when [can execute load default view].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteLoadDefaultView(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
