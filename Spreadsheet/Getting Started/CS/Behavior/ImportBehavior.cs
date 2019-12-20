#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;

using System.IO;
using Syncfusion.UI.Xaml.CellGrid;
using Syncfusion.UI.Xaml.Grid.Utility;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.UI.Xaml.Spreadsheet.Helpers;
using Syncfusion.UI.Xaml.CellGrid.Helpers;

namespace SpreadsheetDemo.Behavior
{
    class ImportBehavior : Behavior<SfSpreadsheet>
    {
        private MainWindow window;
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
            this.AssociatedObject.WorkbookLoaded += AssociatedObject_WorkbookLoaded;
            this.AssociatedObject.WorksheetAdded += AssociatedObject_WorksheetAdded;
            this.AssociatedObject.WorksheetRemoving += AssociatedObject_WorksheetRemoving;
            this.AssociatedObject.WorkbookUnloaded += AssociatedObject_WorkbookUnloaded;
            this.AssociatedObject.ZoomFactorChanged += AssociatedObject_ZoomFactorChanged;
        }

        void AssociatedObject_ZoomFactorChanged(object sender, ZoomFactorChangedEventArgs args)
        {
            if (window != null)
                window.ZoomSlider.Value = args.ZoomFactor;
        }

        void AssociatedObject_WorkbookUnloaded(object sender, WorkbookUnloadedEventArgs args)
        {
            foreach (var grid in args.GridCollection)
            {
                grid.CurrentCellBeginEdit -= grid_CurrentCellBeginEdit;
                grid.CurrentCellEndEdit -= grid_CurrentCellEndEdit;
            }
        }

        void AssociatedObject_WorksheetRemoving(object sender, WorksheetRemovingEventArgs args)
        {
            var grid = this.AssociatedObject.GridCollection[args.SheetName];
            if (grid != null)
            {
                grid.CurrentCellBeginEdit -= grid_CurrentCellBeginEdit;
                grid.CurrentCellEndEdit -= grid_CurrentCellEndEdit;
            }
        }

        void AssociatedObject_WorksheetAdded(object sender, WorksheetAddedEventArgs args)
        {
            var grid = this.AssociatedObject.GridCollection[args.SheetName];
            if (grid != null)
            {
                grid.CurrentCellBeginEdit += grid_CurrentCellBeginEdit;
                grid.CurrentCellEndEdit += grid_CurrentCellEndEdit;
            }
        }

        void AssociatedObject_WorkbookLoaded(object sender, WorkbookLoadedEventArgs args)
        {
            foreach (var grid in args.GridCollection)
            {
                grid.CurrentCellBeginEdit += grid_CurrentCellBeginEdit;
                grid.CurrentCellEndEdit += grid_CurrentCellEndEdit;
            }
        }

        void grid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs args)
        {
            if (window == null) return;
            window.ZoomSlider.IsEnabled = true;
            window.ZoomIncreaseButton.IsEnabled = true;
            window.ZoomDecreaseButton.IsEnabled = true;
            window.ZoomTextBlock.IsEnabled = true;
            window.ModeTextBlock.Text = "READY";
        }

        void grid_CurrentCellBeginEdit(object sender, CurrentCellBeginEditEventArgs args)
        {
            if (window == null) return;
            window.ZoomSlider.IsEnabled = false;
            window.ZoomIncreaseButton.IsEnabled = false;
            window.ZoomDecreaseButton.IsEnabled = false;
            window.ZoomTextBlock.IsEnabled = false;
            window.ModeTextBlock.Text = "ENTER";
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            window = AssociatedObject.FindDescendant<MainWindow>() as MainWindow;
            try
            {
				#if NETCORE
                using (var fileStream = new FileStream(@"..\..\..\..\..\..\Common\Data\Spreadsheet\GettingStarted.xlsx", FileMode.Open))
                #else
				using (var fileStream = new FileStream(@"..\..\..\..\..\Common\Data\Spreadsheet\GettingStarted.xlsx", FileMode.Open))
			    #endif
                {
                    this.AssociatedObject.Open(fileStream);
                }
            }
            catch (Exception)
            { }
        }

        protected override void OnDetaching()
        {
            window = null;
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            this.AssociatedObject.WorkbookLoaded -= AssociatedObject_WorkbookLoaded;
            this.AssociatedObject.WorksheetAdded -= AssociatedObject_WorksheetAdded;
            this.AssociatedObject.WorksheetRemoving -= AssociatedObject_WorksheetRemoving;
            this.AssociatedObject.WorkbookUnloaded -= AssociatedObject_WorkbookUnloaded;
            this.AssociatedObject.ZoomFactorChanged -= AssociatedObject_ZoomFactorChanged;
        }
    }
}
