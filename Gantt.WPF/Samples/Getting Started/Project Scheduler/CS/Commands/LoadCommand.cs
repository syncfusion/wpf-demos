using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Gantt;

namespace ProjectScheduler
{
    /// <summary>
    /// Code for importing the Data from XML to Gantt Control
    /// </summary>
    public class LoadCommand
    {
        static LoadCommand()
        {
            //Registering the LoadXML Command
            CommandManager.RegisterClassCommandBinding(typeof(GanttControl),new CommandBinding(LoadXML,OnExecuteLoadXML,OnCanExecuteLoadXML));
        }

        public static RoutedCommand LoadXML = new RoutedCommand("LoadXML", typeof(GanttControl));

        /// <summary>
        /// Called when [execute load XML].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteLoadXML(object sender, ExecutedRoutedEventArgs args)
        {
            GanttControl gantt = args.Source as GanttControl;
            gantt.ImportFromXML();
        }

        /// <summary>
        /// Called when [can execute load XML].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteLoadXML(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
