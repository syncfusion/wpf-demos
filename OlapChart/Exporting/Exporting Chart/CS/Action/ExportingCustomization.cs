#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ExportingCustomization.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace ExportChart.Action
{
    using System.Windows.Controls;
    using System;
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Chart.Olap;
    using System.Windows;
    using Syncfusion.Windows.Chart.Olap.Converter;

    public class ExportingCustomization : TargetedTriggerAction<OlapChart>
    {
        #region Members

        private string appLocation = AppDomain.CurrentDomain.BaseDirectory;
        OlapChartWordExport wordCoverter;
        OlapChartPdfExport pdfConverter;

        #endregion

        #region Methods

        protected override void Invoke(object parameter)
        {
            if (((parameter as RoutedEventArgs).Source as Button).Name == "btn3")
            {
                try
                {
                    System.IO.File.Copy(appLocation + @"..\..\TemplateDocument\Document.doc", appLocation + @"..\..\OutputDocument\Document.doc", true);
                    wordCoverter = new OlapChartWordExport(this.Target);
                    wordCoverter.ExportintoNewDoc(appLocation + @"..\..\OutputDocument\Document.doc");
                    if (MessageBox.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(appLocation + @"..\..\OutputDocument\Document.doc");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (((parameter as RoutedEventArgs).Source as Button).Name == "btn4")
            {
                try
                {
                    System.IO.File.Copy(appLocation + @"..\..\TemplateDocument\Document.doc", appLocation + @"..\..\OutputDocument\Document.doc", true);
                    wordCoverter = new OlapChartWordExport(this.Target);
                    wordCoverter.ExportIntoTemplateDoc(appLocation + @"..\..\OutputDocument\Document.doc");
                    if (MessageBox.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(appLocation + @"..\..\OutputDocument\Document.doc");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (((parameter as RoutedEventArgs).Source as Button).Name == "btn5")
            {
                try
                {
                    System.IO.File.Copy(appLocation + @"..\..\TemplateDocument\Document.doc", appLocation + @"..\..\OutputDocument\Document.doc", true);
                    wordCoverter = new OlapChartWordExport(this.Target);
                    wordCoverter.ExportIntoTemplateDoc(appLocation + @"..\..\OutputDocument\Document.doc", "MarkerString1");
                    if (MessageBox.Show("Do you want to view the MS Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(appLocation + @"..\..\OutputDocument\Document.doc");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (((parameter as RoutedEventArgs).Source as Button).Name == "btn6")
            {
                try
                {
                    pdfConverter = new OlapChartPdfExport(this.Target);
                    pdfConverter.ExportIntoNewPdf(@"..\..\TemplateDocument\PdfDocument.pdf");
                    if (MessageBox.Show("Do you want to view the PDF document?", "PDF has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(@"..\..\TemplateDocument\PdfDocument.pdf");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion
    }
}