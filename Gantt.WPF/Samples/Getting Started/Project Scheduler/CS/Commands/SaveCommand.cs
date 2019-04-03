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
    /// Code for saving the changes in XML file.
    /// </summary>
    public class SaveCommand
    {
        static SaveCommand()
        {
            //Registering the SaveXML Command
            CommandManager.RegisterClassCommandBinding(typeof(GanttControl),new CommandBinding(SaveXML,OnExecuteSaveXML,OnCanExecuteSaveXML));
        }

        public static RoutedCommand SaveXML = new RoutedCommand("SaveXML", typeof(GanttControl));

        /// <summary>
        /// Called when [execute save XML].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteSaveXML(object sender, ExecutedRoutedEventArgs args)
        {
            GanttControl gantt = args.Source as GanttControl;
            gantt.ExportToXML("../../Data/ProjectData.xml");
        }

        /// <summary>
        /// Called when [can execute save XML].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteSaveXML(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
