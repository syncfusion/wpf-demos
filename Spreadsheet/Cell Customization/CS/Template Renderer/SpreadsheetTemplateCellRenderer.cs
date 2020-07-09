#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Spreadsheet.CellRenderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Grid.ScrollAxis;
using Syncfusion.UI.Xaml.Grid.Utility;
using Syncfusion.UI.Xaml.Spreadsheet;
using System.Windows.Controls;
using Syncfusion.UI.Xaml.CellGrid.GridCellRenderer;
using System.Windows.Media;

namespace CellTemplate_WPF.Class
{
    public class SpreadsheetTemplateCellRenderer : SpreadsheetVirtualizingCellRendererBase<ContentControl, ContentControl>
    {
        public SpreadsheetTemplateCellRenderer()
        {
            SupportDrawingOptimization = false;
        }
        protected override void OnUpdateCellStyle(RowColumnIndex cellRowColumnIndex, ContentControl uiElement, SpreadsheetColumn column)
        {
            UpdateTemplate(uiElement, column);
        }
        protected override void OnUpdateEditCellStyle(RowColumnIndex cellRowColumnIndex, ContentControl uiElement, SpreadsheetColumn column)
        {
            UpdateTemplate(uiElement, column);
        }
        protected override void OnInitializeDisplayElement(RowColumnIndex rowColumnIndex, ContentControl uiElement, SpreadsheetColumn column)
        {
            UpdateTemplate(uiElement, column);
        }

        protected override void OnInitializeEditElement(RowColumnIndex rowColumnIndex, ContentControl uiElement, SpreadsheetColumn column)
        {
            UpdateTemplate(uiElement, column);
        }

        private void UpdateTemplate(ContentControl uiElement,SpreadsheetColumn column)
        {
            var wrapper = (GridCellWrapper)uiElement.DataContext;
            var template = (column as SpreadsheetColumnExt).CellItemTemplate;
            if (template != uiElement.ContentTemplate)
                uiElement.ContentTemplate = template;
            uiElement.DataContext = null;
            if (wrapper == null)
                wrapper = new GridCellWrapper();
            uiElement.DataContext = wrapper;
            uiElement.Content = wrapper;
            wrapper.CellValue = column.ExcelRange.DisplayText;
        }
    }
}
