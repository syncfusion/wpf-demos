#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
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
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.UI.Xaml.TreeGrid;

namespace NestedCollection
{
    public static class CollapseCommand
    {
        static CollapseCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfTreeGrid), new CommandBinding(CollapseAll, OnExecuteCollapseAll));
        }

        public static RoutedCommand CollapseAll = new RoutedCommand("CollapseAll", typeof(SfTreeGrid));

        /// <summary>
        /// Called when [execute collapse all].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteCollapseAll(object sender, ExecutedRoutedEventArgs args)
        {
            SfTreeGrid treeGrid = args.Source as SfTreeGrid;
            treeGrid.CollapseAllNodes();
        }
    }
}
