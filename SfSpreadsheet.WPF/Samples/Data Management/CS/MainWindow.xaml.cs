using Syncfusion.Windows.Shared;

namespace ImportDataTable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Spreadsheet.Loaded += Spreadsheet_Loaded;
        }

        private void Spreadsheet_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            for (int i = 1; i <= Spreadsheet.ActiveSheet.UsedRange.LastColumn; i++)
            {
                Spreadsheet.ActiveSheet.AutofitColumn(i);
                Spreadsheet.ActiveGrid.SetColumnWidth(i, i, Spreadsheet.ActiveSheet.GetColumnWidthInPixels(i));
            }
        }
    }
}
