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
using Syncfusion.XlsIO;
using Syncfusion.Windows.Controls.Grid;

namespace ImportingDemo.ViewModel
{
    public interface IMainView
    {
        void LoadWorkbook(IWorkbook Workbook);
        void GidCellRequestNavigate(string SheetName, int RowIndex, int ColumnIndex);
        void ExecuteCopyCommand(int ActiveTabIndex);
        void ExecuteCutCommand(int ActiveTabIndex);
        void ExecutePasteCommand(int ActiveTabIndex);
        void ExecuteFontSizeCommand(int ActiveTabIndex, bool IsIncrement);
        void CurrentCellStyleChanged(int ActiveTabIndex, string propertyName, object value);
        void ExecuteUndoCommand(int ActiveTabIndex);
        void ExecuteRedoCommand(int ActiveTabIndex);
        void ExecutePrintCommand(int ActiveTabIndex);
    }
}
