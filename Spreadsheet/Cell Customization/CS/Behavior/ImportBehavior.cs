#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CellTemplate_WPF.Class;
using Syncfusion.UI.Xaml.Grid.Utility;
using Syncfusion.UI.Xaml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.CellGrid;
using System.Windows.Interactivity;
using Syncfusion.XlsIO.Implementation;

namespace CellTemplate_WPF
{
    class ImportBehavior : Behavior<SfSpreadsheet>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.DisplayAlerts = false;
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
            this.AssociatedObject.WorkbookLoaded += AssociatedObject_WorkbookLoaded;
            this.AssociatedObject.WorkbookUnloaded += AssociatedObject_WorkbookUnloaded;
            base.OnAttached();
        }

        private void AssociatedObject_WorkbookUnloaded(object sender, Syncfusion.UI.Xaml.Spreadsheet.Helpers.WorkbookUnloadedEventArgs args)
        {
            foreach(var grid in args.GridCollection)
            {
                grid.QueryRange -= Grid_QueryRange;
            }
        }

        private void AssociatedObject_WorkbookLoaded(object sender, Syncfusion.UI.Xaml.Spreadsheet.Helpers.WorkbookLoadedEventArgs args)
        {
            foreach(var grid in args.GridCollection)
            {
                grid.CreateGridColumn = CreateSpreadsheetColumnExt;
                var renderer = new SpreadsheetTemplateCellRenderer();
                grid.CellRenderers.Add("ArrowTemplate", renderer);
                grid.QueryRange += Grid_QueryRange;
                AssociatedObject.SetRowColumnHeadersVisibility(false);
            }
            AssociatedObject.Protect(true, true, "");
            AssociatedObject.ProtectSheet(AssociatedObject.ActiveSheet, "", Syncfusion.XlsIO.ExcelSheetProtection.None);
        }

        private void Grid_QueryRange(object sender, Syncfusion.UI.Xaml.Spreadsheet.Helpers.SpreadsheetQueryRangeEventArgs e)
        {            
            if (e.CellType == "Header")
                return;

            var outlineWrappers = (AssociatedObject.ActiveSheet as WorksheetImpl).OutlineWrappers;
            foreach (var item in outlineWrappers)
            {
                if (e.Cell.RowIndex.Equals(item.FirstIndex - 1))
                {
                    e.CellType = "ArrowTemplate";
                    e.Handled = true;
                }
            }
        }

        private GridColumn CreateSpreadsheetColumnExt(SfCellGrid arg)
        {
            return new SpreadsheetColumnExt(arg as SpreadsheetGrid,this.AssociatedObject);
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
				#if NETCORE
                using (var fileStream = new FileStream(@"..\..\..\..\..\..\Common\Data\Spreadsheet\CellCustomization.xlsx", FileMode.Open))
                #else
				using (var fileStream = new FileStream(@"..\..\..\..\..\Common\Data\Spreadsheet\CellCustomization.xlsx", FileMode.Open))
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
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            this.AssociatedObject.WorkbookLoaded -= AssociatedObject_WorkbookLoaded;
            this.AssociatedObject.WorkbookUnloaded -= AssociatedObject_WorkbookUnloaded;
            base.OnDetaching();
        }
    }
}
