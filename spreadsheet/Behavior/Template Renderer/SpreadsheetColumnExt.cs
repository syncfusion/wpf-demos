#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.Windows.Shared;
using Syncfusion.XlsIO.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace syncfusion.spreadsheetdemos.wpf
{
    public class SpreadsheetColumnExt : SpreadsheetColumn
    {
        SpreadsheetGrid grid;
        SfSpreadsheet spreadsheet;
        public SpreadsheetColumnExt(SpreadsheetGrid grid, SfSpreadsheet spreadsheet) : base(grid)
        {
            this.grid = grid;
            this.spreadsheet = spreadsheet;
        }
        public DataTemplate CellItemTemplate
        {
            get;
            set;
        }
        public DataTemplate CellEditTemplate
        {
            get;
            set;
        }

        protected override void OnUpdateColumn(out FrameworkElement oldElement)
        {
            var outlineWrappers = (spreadsheet.ActiveSheet as WorksheetImpl).OutlineWrappers;
            foreach (var item in outlineWrappers)
            {
                if (RowIndex.Equals(item.FirstIndex - 1))
                {
                    foreach(var window in System.Windows.Application.Current.Windows)
                    {
                        if (window != null && window is ChromelessWindow)
                        {
                            this.CellItemTemplate = (window as ChromelessWindow).Resources["CellTemplateKey"] as DataTemplate;
                        }
                    }
                }
            }
            base.OnUpdateColumn(out oldElement);
        }
    }
}
