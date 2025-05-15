#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Diagnostics;
using System.Windows;
using Syncfusion.XlsIO;
using System.Windows.Media;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;
using syncfusion.demoscommon.wpf;
using ImportNestedCollection;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for ImportNestedCollection.xaml
    /// </summary>
    public partial class ImportNestedCollection : DemoControl
    {        
        ExcelEngine excelEngine;

        #region Constructor
        public ImportNestedCollection()
        {
            InitializeComponent();

            string[] columnNames = { "Default", "Merge", "Repeat" };

            for (int i = 0; i < columnNames.Length; i++)
            {
                cmbLayout.Items.Add(columnNames[i]);
            }
            cmbLayout.SelectedIndex = 0;
            rdbExpand.IsChecked = true;
            excelEngine = new ExcelEngine();
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Helper Methods

        private IList<Brand> GetVehicleDetails()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(BrandObjects));
            TextReader textReader = new StreamReader(@"Assets\XlsIO\ExportData.xml");
            BrandObjects brands = (BrandObjects)deserializer.Deserialize(textReader);

            List<Brand> list = new List<Brand>();
            string brandName = brands.BrandObject[0].BrandName;
            string vehicleType = brands.BrandObject[0].VahicleType;
            string modelName = brands.BrandObject[0].ModelName;
            Brand brand = new Brand(brandName);
            brand.VehicleTypes = new List<VehicleType>();

            VehicleType vehicle = new VehicleType(vehicleType);
            vehicle.Models = new List<Model>();
            Model model = new Model(modelName);

            brand.VehicleTypes.Add(vehicle);
            list.Add(brand);

            foreach (BrandObject brandObj in brands.BrandObject)
            {
                if (brandName == brandObj.BrandName)
                {
                    if (vehicleType == brandObj.VahicleType)
                    {
                        vehicle.Models.Add(new Model(brandObj.ModelName));
                        continue;
                    }
                    else
                    {
                        vehicle = new VehicleType(brandObj.VahicleType);
                        vehicle.Models = new List<Model>();
                        vehicle.Models.Add(new Model(brandObj.ModelName));
                        brand.VehicleTypes.Add(vehicle);
                        vehicleType = brandObj.VahicleType;
                    }                    
                    continue;
                }
                else
                {
                    brand = new Brand(brandObj.BrandName);
                    vehicle = new VehicleType(brandObj.VahicleType);
                    vehicle.Models = new List<Model>();
                    vehicle.Models.Add(new Model(brandObj.ModelName));
                    brand.VehicleTypes = new List<VehicleType>();
                    brand.VehicleTypes.Add(vehicle);
                    vehicleType = brandObj.VahicleType;
                    list.Add(brand);
                    brandName = brandObj.BrandName;
                }                
            }
            textReader.Close();
            return list;
        }
        #endregion

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            excelEngine.Dispose();
        }

        #region Events
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExcelEngine excelEngine = new ExcelEngine();
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;
                IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];

                string fileName = string.Empty;
                IList<Brand> list = GetVehicleDetails();

                ExcelImportDataOptions importDataOptions = new ExcelImportDataOptions();
                importDataOptions.FirstRow = 4;

                if (cmbLayout.SelectedIndex == 0)
                    importDataOptions.NestedDataLayoutOptions = ExcelNestedDataLayoutOptions.Default;
                else if (cmbLayout.SelectedIndex == 1)
                    importDataOptions.NestedDataLayoutOptions = ExcelNestedDataLayoutOptions.Merge;
                else if (cmbLayout.SelectedIndex == 2)
                    importDataOptions.NestedDataLayoutOptions = ExcelNestedDataLayoutOptions.Repeat;

                if (checkBox.IsChecked.Value)
                {
                    if (rdbExpand.IsChecked.Value)
                    {
                        importDataOptions.NestedDataGroupOptions = ExcelNestedDataGroupOptions.Expand;
                    }
                    else if (rdbCollapse.IsChecked.Value)
                    {
                        importDataOptions.NestedDataGroupOptions = ExcelNestedDataGroupOptions.Collapse;
                        if (tbLevel.Text != string.Empty)
                        {
                            importDataOptions.CollapseLevel = int.Parse(tbLevel.Text);
                        }
                    }
                }

                worksheet.ImportData(list, importDataOptions);
                fileName = @"ImportData.xlsx";

                #region Define Styles
                IStyle pageHeader = workbook.Styles.Add("PageHeaderStyle");
                IStyle tableHeader = workbook.Styles.Add("TableHeaderStyle");

                pageHeader.Font.FontName = "Calibri";
                pageHeader.Font.Size = 16;
                pageHeader.Font.Bold = true;
                pageHeader.Color = System.Drawing.Color.FromArgb(0, 146, 208, 80);
                pageHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                pageHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;

                tableHeader.Font.Bold = true;
                tableHeader.Font.FontName = "Calibri";
                tableHeader.Color = System.Drawing.Color.FromArgb(0, 146, 208, 80);

                #endregion

                #region Apply Styles
                // Apply style for header
                worksheet["A1:C2"].Merge();
                worksheet["A1"].Text = "Automobile Brands in the US";
                worksheet["A1"].CellStyle = pageHeader;

                worksheet["A4:C4"].CellStyle = tableHeader;

                worksheet["A1:C1"].CellStyle.Font.Bold = true;
                worksheet.UsedRange.AutofitColumns();

                #endregion

                workbook.SaveAs(fileName);
                workbook.Close();
                excelEngine.Dispose();

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                        {
                            UseShellExecute = true
                        };
                        process.Start();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("Excel 2007 is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }

        private void checkBox_Changed(object sender, RoutedEventArgs e)
        {
            this.groupBox2.IsEnabled = this.checkBox.IsChecked.Value;
        }

        private void expandCollapse_Checked(object sender, RoutedEventArgs e)
        {
            this.tbLevel.IsEnabled = this.rdbCollapse.IsChecked.Value;
        }

        private void numberValidation_TextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            int level = 0;
            if (int.TryParse(e.Text, out level) && level > 0 && level < 9)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Please enter the level from 1 to 8");
            }
        }
        #endregion
    }
}
