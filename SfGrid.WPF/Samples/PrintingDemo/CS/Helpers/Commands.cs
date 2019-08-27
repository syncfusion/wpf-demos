#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Windows.Input;

namespace PrintingDemo
{
    public static class Commands
    {
        static Commands()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfDataGrid), new CommandBinding(PrintPreview, OnPrintGrid));
            CommandManager.RegisterClassCommandBinding(typeof(SfDataGrid), new CommandBinding(DirectPrint, OnDirectPrintGrid));
        }

        #region Print Preview Command

        public static RoutedCommand PrintPreview = new RoutedCommand("PrintPreview", typeof (SfDataGrid));

        private static void OnPrintGrid(object sender, ExecutedRoutedEventArgs args)
        {
            var dataGrid = args.Source as SfDataGrid;
            if (dataGrid == null) return;
            try
            {
                dataGrid.ShowPrintPreview();
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Print Command

        public static RoutedCommand DirectPrint = new RoutedCommand("DirectPrint", typeof(SfDataGrid));

        private static void OnDirectPrintGrid(object sender, ExecutedRoutedEventArgs args)
        {
            var dataGrid = args.Source as SfDataGrid;
            if (dataGrid == null) return;
            try
            {
                dataGrid.Print();
            }
            catch (Exception)
            {

            }
        }

        #endregion

    }
}
