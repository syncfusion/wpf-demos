#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using System;
    using System.Windows.Controls;
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.Windows.Controls.PivotGrid;
    using System.Windows;
    using Microsoft.Win32;
    using Syncfusion.Windows.Controls.PivotGrid.Converter;

    public class ExportTriggerAction : TargetedTriggerAction<PivotGridControl>
    {
        static bool ExportAsPivotTable;
        protected override void Invoke(object parameter)
        {
            if (parameter is SelectionChangedEventArgs)
            {
                SelectionChangedEventArgs eventArgs = parameter as SelectionChangedEventArgs;
                ComboBox comboBox = eventArgs.OriginalSource as ComboBox;
                ExportAsPivotTable = comboBox.SelectedIndex == 1;
            }
            else if (parameter is RoutedEventArgs)
            {
                try
                {
                    RoutedEventArgs eventArgs = parameter as RoutedEventArgs;
                    Button exportButton = eventArgs.OriginalSource as Button;
                    SaveFileDialog savedialog = new SaveFileDialog();
                    savedialog.AddExtension = true;
                    savedialog.FileName = "Sample";
                    switch (exportButton.Content.ToString())
                    {

                        case "Export To Excel":
                            savedialog.DefaultExt = "xlsx";
                            savedialog.Filter = "Excel file (.xlsx)|*.xlsx";

                            if (savedialog.ShowDialog() == true)
                            {
                                GridExcelExport excelExport = new GridExcelExport(this.Target, Syncfusion.XlsIO.ExcelVersion.Excel2007);
                                excelExport.ExportMode = ExportAsPivotTable ? ExportModes.PivotTable : ExportModes.Cell;
                                excelExport.Export(savedialog.FileName);
                                MessageBox.Show("Excel sheet exported successfully!");
                            }
                            break;
                        case "Export To PDF":
                            savedialog.DefaultExt = "pdf";
                            savedialog.Filter = "Pdf file (.pdf)|*.pdf";

                            if (savedialog.ShowDialog() == true)
                            {
                                GridPdfExport pdfExport = new GridPdfExport(this.Target);
                                pdfExport.Export(savedialog.FileName);
                                MessageBox.Show("PDF document exported successfully!");
                            }
                            break;
                        case "Export To Word":
                            savedialog.DefaultExt = "Doc";
                            savedialog.Filter = "Word file (.Doc)|*.Doc";
                            if (savedialog.ShowDialog() == true)
                            {
                                GridWordExport wordExport = new GridWordExport(this.Target);
                                wordExport.Export(savedialog.FileName);
                                MessageBox.Show("Word document exported successfully!");
                            }
                            break;
                        case "Export To CSV":
                            savedialog.DefaultExt = "CSV";
                            savedialog.Filter = "Csv file (.csv)|*.csv";
                            if (savedialog.ShowDialog() == true)
                            {
                                GridCsvExport csvExport = new GridCsvExport(this.Target);
                                csvExport.Delimiter = ",";
                                csvExport.Export(savedialog.FileName);
                                MessageBox.Show("CSV document exported successfully!");
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while exporting." + Environment.NewLine + "Exception Message: " + ex.Message, "Error on export", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}