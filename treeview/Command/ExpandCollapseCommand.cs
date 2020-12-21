#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using System.Windows.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using Microsoft.Win32;
using Syncfusion.UI.Xaml.TreeView;

namespace syncfusion.treeviewdemos.wpf
{
    public static class ExpandCollapseCommand
    {
        static ExpandCollapseCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfTreeView), new CommandBinding(ExpandAllNodes, OnExecuteExpandAllNodes, OnCanExecuteExpandAllNodes));
            CommandManager.RegisterClassCommandBinding(typeof(SfTreeView), new CommandBinding(CollapseAllNodes, OnExecuteCollapseAllNodes, OnCanExecuteCollapseAllNodes));
        }

        #region ExpandAll Command

        public static RoutedCommand ExpandAllNodes = new RoutedCommand("ExpandAll", typeof(SfTreeView));

        private static void OnExecuteExpandAllNodes(object sender, ExecutedRoutedEventArgs args)
        {
            var treeView = sender as SfTreeView;
            treeView.ExpandAll();
        }

        private static void OnCanExecuteExpandAllNodes(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        #endregion

        #region CollapseAll Command

        public static RoutedCommand CollapseAllNodes = new RoutedCommand("CollapseAll", typeof(SfTreeView));

        private static void OnExecuteCollapseAllNodes(object sender, ExecutedRoutedEventArgs args)
        {
            var treeView = sender as SfTreeView;
            treeView.CollapseAll();
        }

        private static void OnCanExecuteCollapseAllNodes(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        #endregion
    }
}
