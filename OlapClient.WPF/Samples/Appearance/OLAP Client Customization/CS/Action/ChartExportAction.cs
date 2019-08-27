#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace OLAPClientCustomization.Action
{
    using System;
    using Syncfusion.Windows.Client.Olap;
    using System.Windows.Interactivity;
    using System.Windows;
    using System.Windows.Controls;
    using Syncfusion.Windows.Chart.Olap.Converter;

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
                                System.IO.File.Copy(appLocation + @"..\..\TemplateDocument\Document.doc", appLocation + @"..\..\OutputDocument\Document.doc", true);
                                OlapChartWordExport chartWordExport = new OlapChartWordExport(this.Target.OlapChart);
                                chartWordExport.ExportintoNewDoc(appLocation + @"..\..\OutputDocument\Document.doc");
                                if (MessageBox.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    System.Diagnostics.Process.Start(appLocation + @"..\..\OutputDocument\Document.doc");
                                }
                                break;
                            case "Default Marker":
                                System.IO.File.Copy(appLocation + @"..\..\TemplateDocument\Document.doc", appLocation + @"..\..\OutputDocument\Document.doc", true);
                                OlapChartWordExport chartMarkerWordExport = new OlapChartWordExport(this.Target.OlapChart);
                                chartMarkerWordExport.ExportIntoTemplateDoc(appLocation + @"..\..\OutputDocument\Document.doc");
                                if (MessageBox.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    System.Diagnostics.Process.Start(appLocation + @"..\..\OutputDocument\Document.doc");
                                }
                                break;
                            case "Custom Marker":
                                System.IO.File.Copy(appLocation + @"..\..\TemplateDocument\Document.doc", appLocation + @"..\..\OutputDocument\Document.doc", true);
                                OlapChartWordExport chartCustomMarkerWordExport = new OlapChartWordExport(this.Target.OlapChart);
                                chartCustomMarkerWordExport.ExportIntoTemplateDoc(appLocation + @"..\..\OutputDocument\Document.doc", "MarkerString1");
                                if (MessageBox.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    System.Diagnostics.Process.Start(appLocation + @"..\..\OutputDocument\Document.doc");
                                }
                                break;
                            case "New Pdf Document":
                                OlapChartPdfExport chartPdfExport = new OlapChartPdfExport(this.Target.OlapChart);
                                chartPdfExport.ExportIntoNewPdf(@"..\..\TemplateDocument\PdfDocument.pdf");
                                if (MessageBox.Show("Do you want to view the PDF document?", "PDF has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    System.Diagnostics.Process.Start(@"..\..\TemplateDocument\PdfDocument.pdf");
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