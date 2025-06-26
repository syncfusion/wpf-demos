#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using Syncfusion.Windows.Shared;

#region file Directives
using Syncfusion.ExcelToPdfConverter;
using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using Syncfusion.ExcelChartToImageConverter;
using Syncfusion.XlsIO.Implementation;
using System.Windows.Controls;
using syncfusion.demoscommon.wpf;
#endregion

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Print : DemoControl
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public Print()
        {
            InitializeComponent();
            this.textBox1.Text = "ExcelTopdfwithChart.xlsx";
            this.textBox1.Tag = @"Assets\XlsIO\ExcelTopdfwithChart.xlsx";
            this.convertSettings.IsEnabled = false;
            defaultPrintBtn.Checked += option_SelectedIndexChanged;
            printWithConverterBtn.Checked += option_SelectedIndexChanged;
            printWithPrinterBtn.Checked += option_SelectedIndexChanged;
            printWithConverterAndPrinterBtn.Checked += option_SelectedIndexChanged;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text != String.Empty && (string)this.textBox1.Tag != string.Empty)
            {
                if (File.Exists((string)this.textBox1.Tag))
                {
                    ExcelEngine engine = new ExcelEngine();
                    IApplication application = engine.Excel;
                    IWorkbook book = application.Workbooks.Open((string)textBox1.Tag);
                    // Initialize the chart to image converter.
                    application.ChartToImageConverter = new ChartToImageConverter();
                    //Set the Quality of chart Image
                    application.ChartToImageConverter.ScalingMode = ScalingMode.Best;
                    //Open the Excel Document to Convert
                    ExcelToPdfConverter converter = new ExcelToPdfConverter(book);

                    if (printWithPrinterBtn.IsChecked == true || printWithConverterAndPrinterBtn.IsChecked == true)
                    {
                        //Create new printdialog instance.
                        System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
                        printDialog.AllowSomePages = true;
                        if (printDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            if (printWithConverterAndPrinterBtn.IsChecked == true)
                            {
                                //Print excel document with specified printer settings and converter settings.
                                converter.Print(printDialog.PrinterSettings, GetConverterSettings());
                            }
                            else
                            {
                                //Print excel document with specified printer settings.
                                converter.Print(printDialog.PrinterSettings);
                            }
                        }
                    }
                    else if (printWithConverterBtn.IsChecked == true)
                    {
                        //Print excel document with specified and converter settings.
                        converter.Print(GetConverterSettings());
                    }
                    else if (defaultPrintBtn.IsChecked == true)
                    {
                        //print excel document with default printer settings.
                        converter.Print();
                    }
                }

                else
                {
                    MessageBox.Show("File doesn’t exist");
                }
            }

            else
                MessageBox.Show("Browse an Excel document to convert to Pdf", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        private void browseBtnClick(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel|*.xls;*.xlsx";
            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                this.textBox1.Tag = openFileDialog1.FileName;
            }
        }

        private ExcelToPdfConverterSettings GetConverterSettings()
        {
            //Intialize the ExcelToPdfconverterSettings
            ExcelToPdfConverterSettings converterSettings = new ExcelToPdfConverterSettings();

            if (noScaleRadioBtn.IsChecked == true)
                converterSettings.LayoutOptions = LayoutOptions.NoScaling;
            else if (allRowsRadioBtn.IsChecked == true)
                converterSettings.LayoutOptions = LayoutOptions.FitAllRowsOnOnePage;
            else if (allColumnRadioBtn.IsChecked == true)
                converterSettings.LayoutOptions = LayoutOptions.FitAllColumnsOnOnePage;
            else
                converterSettings.LayoutOptions = LayoutOptions.FitSheetOnOnePage;

            return converterSettings;
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (File.Exists((string)textBox1.Tag))
            {
                //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo((string)textBox1.Tag)
                {
                    UseShellExecute = true
                };
                process.Start();
            }
        }

        private void option_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (this.printWithConverterBtn.IsChecked == true || this.printWithConverterAndPrinterBtn.IsChecked == true)
            {
                this.convertSettings.IsEnabled = true;
            }
            else
                this.convertSettings.IsEnabled = false;
        }
    }
}
