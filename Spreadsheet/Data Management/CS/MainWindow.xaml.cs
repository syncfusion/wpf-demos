#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
