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
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.TreeGrid;

namespace OnDemandLoading
{
    public static class ExpandCommand
    {
        /// <summary>
        /// Initializes the <see cref="ExpandCommand"/> class.
        /// </summary>
        static ExpandCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfTreeGrid), new CommandBinding(ExpandAll, OnExecuteExpandAll));
        }

        public static RoutedCommand ExpandAll = new RoutedCommand("ExpandAll", typeof(SfTreeGrid));

        /// <summary>
        /// Called when [execute expand all].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private static void OnExecuteExpandAll(object sender, ExecutedRoutedEventArgs args)
        {
            SfTreeGrid treeGrid = args.Source as SfTreeGrid;
            treeGrid.ExpandAllNodes();
        }    
    }
}