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
