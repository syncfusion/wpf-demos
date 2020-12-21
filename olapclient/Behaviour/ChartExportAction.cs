#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using System;
    using Syncfusion.Windows.Client.Olap;
    using System.Windows;
    using System.Windows.Controls;
    using Syncfusion.Windows.Chart.Olap.Converter;
    using Microsoft.Xaml.Behaviors;

    class ChartExportAction :  TargetedTriggerAction<OlapClient>
    {
        #region Members

        private string appLocation = AppDomain.CurrentDomain.BaseDirectory;

        #endregion

        #region Methods

        protected override void Invoke(object parameter)
        {
            try
            {
                RoutedEventArgs eventArgs = parameter as RoutedEventArgs;
                if (eventArgs != null)
                {
                    Button exportBtn = eventArgs.OriginalSource as Button;
                    if (exportBtn != null)
                    {
                        switch (exportBtn.Content.ToString())
                        {
                            case "New Document":
                                System.IO.File.Copy(appLocation + @"..\..\Data\OutputDocument.doc", appLocation + @"..\..\Data\OutputDocument.doc", true);
                                OlapChartWordExport chartWordExport = new OlapChartWordExport(this.Target.OlapChart);
                                chartWordExport.ExportintoNewDoc(appLocation + @"..\..\Data\OutputDocument.doc");
                                if (MessageBox.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    System.Diagnostics.Process.Start(appLocation + @"..\..\Data\OutputDocument.doc");
                                }
                                break;
                            case "Default Marker":
                                System.IO.File.Copy(appLocation + @"..\..\Data\TemplateDocument.doc", appLocation + @"..\..\Data\OutputDocument.doc", true);
                                OlapChartWordExport chartMarkerWordExport = new OlapChartWordExport(this.Target.OlapChart);
                                chartMarkerWordExport.ExportIntoTemplateDoc(appLocation + @"..\..\Data\OutputDocument.doc");
                                if (MessageBox.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    System.Diagnostics.Process.Start(appLocation + @"..\..\Data\OutputDocument.doc");
                                }
                                break;
                            case "Custom Marker":
                                System.IO.File.Copy(appLocation + @"..\..\Data\TemplateDocument.doc", appLocation + @"..\..\Data\OutputDocument.doc", true);
                                OlapChartWordExport chartCustomMarkerWordExport = new OlapChartWordExport(this.Target.OlapChart);
                                chartCustomMarkerWordExport.ExportIntoTemplateDoc(appLocation + @"..\..\Data\OutputDocument.doc", "MarkerString1");
                                if (MessageBox.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    System.Diagnostics.Process.Start(appLocation + @"..\..\Data\OutputDocument.doc");
                                }
                                break;
                            case "New Pdf Document":
                                OlapChartPdfExport chartPdfExport = new OlapChartPdfExport(this.Target.OlapChart);
                                chartPdfExport.ExportIntoNewPdf(@"..\..\Data\PdfDocument.pdf");
                                if (MessageBox.Show("Do you want to view the PDF document?", "PDF has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    System.Diagnostics.Process.Start(@"..\..\Data\PdfDocument.pdf");
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while exporting", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}