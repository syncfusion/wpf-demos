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
using System.Windows;

namespace ImportExportDemo
{
    public class ImportExportCommand
    {
        static ImportExportCommand()
        {
            //Registering the ImportFromXML command
            CommandManager.RegisterClassCommandBinding(typeof(GanttControl), new CommandBinding(ImportFromXML, OnExecuteImportFromXML, OnCanExecuteImportFromXML));

            //Registering the ExportToXML command
            CommandManager.RegisterClassCommandBinding(typeof(GanttControl), new CommandBinding(ExportToXML, OnExecuteExportToXML, OnCanExecuteExportToXML));
        }

        public static RoutedCommand ImportFromXML = new RoutedCommand("ImportFromXML", typeof(GanttControl));

        public static RoutedCommand ExportToXML = new RoutedCommand("ExportToXML", typeof(GanttControl));

        /// <summary>
        /// Called when [execute import from XML].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteImportFromXML(object sender, ExecutedRoutedEventArgs args)
        {
            GanttControl gantt = args.Source as GanttControl;
            if (gantt.ImportFromXML())
            {
                MessageBox.Show("Tasks imported successfully.", "XML Import/Export", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Called when [execute export to XML].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteExportToXML(object sender, ExecutedRoutedEventArgs args)
        {
            GanttControl gantt = args.Source as GanttControl;
            if (gantt.ExportToXML())
            {
                MessageBox.Show("Tasks exported successfully.", "XML Import/Export", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Called when [can execute import from XML].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteImportFromXML(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        /// <summary>
        /// Called when [can execute export to XML].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnCanExecuteExportToXML(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
    }
}
