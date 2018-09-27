using System;
using System.Windows.Interactivity;
using System.Data;
using ImportDataTable.Model;
using Syncfusion.UI.Xaml.Spreadsheet;

namespace ImportDataTable.Behavior
{
    class ImportBehavior : Behavior<SfSpreadsheet>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
             try
            {
                DataTable datatable = Data.GetDataTable("Customers");
                this.AssociatedObject.ActiveSheet.ImportDataTable(datatable, true, 1, 1);
                this.AssociatedObject.ActiveGrid.InvalidateCells();
            }
            catch (Exception)
            { }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }
    }
}
