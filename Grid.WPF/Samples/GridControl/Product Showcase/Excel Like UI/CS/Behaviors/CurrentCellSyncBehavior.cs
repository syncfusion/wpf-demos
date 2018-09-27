using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using EXCEL.ViewModel;
using Syncfusion.Windows.ComponentModel;

namespace EXCEL.Behaviors
{
    public class CurrentCellSyncBehavior : Behavior<GridControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.CurrentCellActivated += new GridRoutedEventHandler(AssociatedObject_CurrentCellActivated);
        }

        void AssociatedObject_CurrentCellActivated(object sender, SyncfusionRoutedEventArgs args)
        {
            var rowIndex = AssociatedObject.CurrentCell.RowIndex;
            var colIndex = AssociatedObject.CurrentCell.ColumnIndex;
            var style = AssociatedObject.Model[rowIndex, colIndex];
            var dataContext = AssociatedObject.DataContext as MainViewModel;
            if (dataContext != null && style.CellValue != string.Empty)
            {
                dataContext.FontFamily = style.Font.FontFamily;
                dataContext.FontSize = style.Font.FontSize;
                dataContext.FontStyle = style.Font.FontStyle;
                dataContext.FontWeight = style.Font.FontWeight;
                dataContext.HorizontalAlignment = style.HorizontalAlignment;
                dataContext.TextDecorations = style.Font.TextDecorations;
                dataContext.VerticalAlignment = style.VerticalAlignment;
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.CurrentCellActivated -= new GridRoutedEventHandler(AssociatedObject_CurrentCellActivated);
        }
    }
}