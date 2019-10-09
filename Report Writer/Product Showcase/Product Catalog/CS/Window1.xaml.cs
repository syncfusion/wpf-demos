#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.ReportWriter;
using Syncfusion.Windows.Reports;
using System.Collections;

namespace ProductCatalog
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string file = @"..\..\..\..\..\..\Common\Images\XlsIO\reportwriter_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
            string file2 = @"..\..\..\..\..\..\Common\Images\XlsIO\xlsio_button.png";
            this.image2.Source = (ImageSource)img.ConvertFromString(file2);
            this.Icon = this.image2.Source;
        }
        # endregion

        # region Events
        /// <summary>
        /// Creates spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string reportPath = @"../../../../../../Common/Data/ReportTemplate/RDLC/Product Catalog.rdlc";

                string fileName = null;
                WriterFormat format;

                ReportDataSourceCollection dataSources = new ReportDataSourceCollection();
                dataSources.Add(new ReportDataSource { Name = "ProductCatalog", Value = ProductCatalogSource.GetData() });

                //Step 1 : Instantiate the report writer with the parameter "ReportPath".
                ReportWriter reportWriter = new ReportWriter(reportPath, dataSources);
                //Step 2 : Save the report as Pdf or Word or Excel
                if (pdf.IsChecked == true)
                {
                    fileName = "ProductCatalog.pdf";
                    format = WriterFormat.PDF;
                }
                else if (word.IsChecked == true)
                {
                    fileName = "ProductCatalog.doc";
                    format = WriterFormat.Word;
                }
                else if (excel.IsChecked == true)
                {
                    fileName = "ProductCatalog.xls";
                    format = WriterFormat.Excel;
                }
                else
                {
                    fileName = "ProductCatalog.html";
                    format = WriterFormat.HTML;
                }

                reportWriter.Save(fileName, format);
                //Message box confirmation to view the created report document.
                if (MessageBox.Show("Do you want to view the " + format + " file?", "" + format + " report Created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the PDF file using the default Application.[Acrobat Reader]
                    System.Diagnostics.Process.Start(fileName);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        # endregion
    }

	 #region ProductCatalog Details
    public class ProductCatalogSource
    {
        public string ProdSubCat { get; set; }
        public string ProdModel { get; set; }
        public string ProdCat { get; set; }
        public string Description { get; set; }
        public string ProdName { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public double? Weight { get; set; }
        public double? StandardCost { get; set; }
        public string Style { get; set; }
        public string Class { get; set; }
        public double? ListPrice { get; set; }
        public static IList GetData()
        {
            List<ProductCatalogSource> datas = new List<ProductCatalogSource>();
            ProductCatalogSource data = null;
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "HL Road Frame",
                ProdCat = "Components",
                Description = "Our lightest and best quality aluminum frame made from the newest alloy; it is welded and heat-treated for strength. Our innovative design results in maximum comfort and performance.",
                ProdName = "HL Road Frame - Black, 58",
                ProductNumber = "FR-R92B-58",
                Color = "Black",
                Size = "58",
                Weight = 2.24,
                StandardCost = 1059.3100,
                Style = "U ",
                Class = "H ",
                ListPrice = 1431.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "HL Road Frame",
                ProdCat = "Components",
                Description = "Our lightest and best quality aluminum frame made from the newest alloy; it is welded and heat-treated for strength. Our innovative design results in maximum comfort and performance.",
                ProdName = "HL Road Frame - Red, 58",
                ProductNumber = "FR-R92R-58",
                Color = "Red",
                Size = "58",
                Weight = 2.24,
                StandardCost = 1059.3100,
                Style = "U ",
                Class = "H ",
                ListPrice = 1431.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Helmets",
                ProdModel = "Sport-100",
                ProdCat = "Accessories",
                Description = "Universal fit, well-vented, lightweight , snap-on visor.",
                ProdName = "Sport-100 Helmet, Red",
                ProductNumber = "HL-U509-R",
                Color = "Red",
                Size = "",
                Weight = null,
                StandardCost = 13.0863,
                Style = "",
                Class = "",
                ListPrice = 34.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Helmets",
                ProdModel = "Sport-100",
                ProdCat = "Accessories",
                Description = "Universal fit, well-vented, lightweight , snap-on visor.",
                ProdName = "Sport-100 Helmet, Black",
                ProductNumber = "HL-U509",
                Color = "Black",
                Size = "",
                Weight = null,
                StandardCost = 13.0863,
                Style = "",
                Class = "",
                ListPrice = 34.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Socks",
                ProdModel = "Mountain Bike Socks",
                ProdCat = "Clothing",
                Description = "Combination of natural and synthetic fibers stays dry and provides just the right cushioning.",
                ProdName = "Mountain Bike Socks, M",
                ProductNumber = "SO-B909-M",
                Color = "White",
                Size = "M",
                Weight = null,
                StandardCost = 3.3963,
                Style = "U ",
                Class = "",
                ListPrice = 9.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Socks",
                ProdModel = "Mountain Bike Socks",
                ProdCat = "Clothing",
                Description = "Combination of natural and synthetic fibers stays dry and provides just the right cushioning.",
                ProdName = "Mountain Bike Socks, L",
                ProductNumber = "SO-B909-L",
                Color = "White",
                Size = "L",
                Weight = null,
                StandardCost = 3.3963,
                Style = "U ",
                Class = "",
                ListPrice = 9.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Helmets",
                ProdModel = "Sport-100",
                ProdCat = "Accessories",
                Description = "Universal fit, well-vented, lightweight , snap-on visor.",
                ProdName = "Sport-100 Helmet, Blue",
                ProductNumber = "HL-U509-B",
                Color = "Blue",
                Size = "",
                Weight = null,
                StandardCost = 13.0863,
                Style = "",
                Class = "",
                ListPrice = 34.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Caps",
                ProdModel = "Cycling Cap",
                ProdCat = "Clothing",
                Description = "Traditional style with a flip-up brim; one-size fits all.",
                ProdName = "AWC Logo Cap",
                ProductNumber = "CA-1098",
                Color = "Multi",
                Size = "",
                Weight = null,
                StandardCost = 6.9223,
                Style = "U ",
                Class = "",
                ListPrice = 8.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Jerseys",
                ProdModel = "Long-Sleeve Logo Jersey",
                ProdCat = "Clothing",
                Description = "Unisex long-sleeve AWC logo microfiber cycling jersey",
                ProdName = "Long-Sleeve Logo Jersey, S",
                ProductNumber = "LJ-0192-S",
                Color = "Multi",
                Size = "S",
                Weight = null,
                StandardCost = 38.4923,
                Style = "U ",
                Class = "",
                ListPrice = 49.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Jerseys",
                ProdModel = "Long-Sleeve Logo Jersey",
                ProdCat = "Clothing",
                Description = "Unisex long-sleeve AWC logo microfiber cycling jersey",
                ProdName = "Long-Sleeve Logo Jersey, M",
                ProductNumber = "LJ-0192-M",
                Color = "Multi",
                Size = "M",
                Weight = null,
                StandardCost = 38.4923,
                Style = "U ",
                Class = "",
                ListPrice = 49.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Jerseys",
                ProdModel = "Long-Sleeve Logo Jersey",
                ProdCat = "Clothing",
                Description = "Unisex long-sleeve AWC logo microfiber cycling jersey",
                ProdName = "Long-Sleeve Logo Jersey, L",
                ProductNumber = "LJ-0192-L",
                Color = "Multi",
                Size = "L",
                Weight = null,
                StandardCost = 38.4923,
                Style = "U ",
                Class = "",
                ListPrice = 49.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Jerseys",
                ProdModel = "Long-Sleeve Logo Jersey",
                ProdCat = "Clothing",
                Description = "Unisex long-sleeve AWC logo microfiber cycling jersey",
                ProdName = "Long-Sleeve Logo Jersey, XL",
                ProductNumber = "LJ-0192-X",
                Color = "Multi",
                Size = "XL",
                Weight = null,
                StandardCost = 38.4923,
                Style = "U ",
                Class = "",
                ListPrice = 49.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "HL Road Frame",
                ProdCat = "Components",
                Description = "Our lightest and best quality aluminum frame made from the newest alloy; it is welded and heat-treated for strength. Our innovative design results in maximum comfort and performance.",
                ProdName = "HL Road Frame - Red, 62",
                ProductNumber = "FR-R92R-62",
                Color = "Red",
                Size = "62",
                Weight = 2.30,
                StandardCost = 868.6342,
                Style = "U ",
                Class = "H ",
                ListPrice = 1431.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "HL Road Frame",
                ProdCat = "Components",
                Description = "Our lightest and best quality aluminum frame made from the newest alloy; it is welded and heat-treated for strength. Our innovative design results in maximum comfort and performance.",
                ProdName = "HL Road Frame - Red, 44",
                ProductNumber = "FR-R92R-44",
                Color = "Red",
                Size = "44",
                Weight = 2.12,
                StandardCost = 868.6342,
                Style = "U ",
                Class = "H ",
                ListPrice = 1431.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "HL Road Frame",
                ProdCat = "Components",
                Description = "Our lightest and best quality aluminum frame made from the newest alloy; it is welded and heat-treated for strength. Our innovative design results in maximum comfort and performance.",
                ProdName = "HL Road Frame - Red, 48",
                ProductNumber = "FR-R92R-48",
                Color = "Red",
                Size = "48",
                Weight = 2.16,
                StandardCost = 868.6342,
                Style = "U ",
                Class = "H ",
                ListPrice = 1431.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "HL Road Frame",
                ProdCat = "Components",
                Description = "Our lightest and best quality aluminum frame made from the newest alloy; it is welded and heat-treated for strength. Our innovative design results in maximum comfort and performance.",
                ProdName = "HL Road Frame - Red, 52",
                ProductNumber = "FR-R92R-52",
                Color = "Red",
                Size = "52",
                Weight = 2.20,
                StandardCost = 868.6342,
                Style = "U ",
                Class = "H ",
                ListPrice = 1431.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "HL Road Frame",
                ProdCat = "Components",
                Description = "Our lightest and best quality aluminum frame made from the newest alloy; it is welded and heat-treated for strength. Our innovative design results in maximum comfort and performance.",
                ProdName = "HL Road Frame - Red, 56",
                ProductNumber = "FR-R92R-56",
                Color = "Red",
                Size = "56",
                Weight = 2.24,
                StandardCost = 868.6342,
                Style = "U ",
                Class = "H ",
                ListPrice = 1431.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "LL Road Frame",
                ProdCat = "Components",
                Description = "The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.",
                ProdName = "LL Road Frame - Black, 58",
                ProductNumber = "FR-R38B-58",
                Color = "Black",
                Size = "58",
                Weight = 2.46,
                StandardCost = 204.6251,
                Style = "U ",
                Class = "L ",
                ListPrice = 337.2200
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "LL Road Frame",
                ProdCat = "Components",
                Description = "The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.",
                ProdName = "LL Road Frame - Black, 60",
                ProductNumber = "FR-R38B-60",
                Color = "Black",
                Size = "60",
                Weight = 2.48,
                StandardCost = 204.6251,
                Style = "U ",
                Class = "L ",
                ListPrice = 337.2200
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "LL Road Frame",
                ProdCat = "Components",
                Description = "The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.",
                ProdName = "LL Road Frame - Black, 62",
                ProductNumber = "FR-R38B-62",
                Color = "Black",
                Size = "62",
                Weight = 2.50,
                StandardCost = 204.6251,
                Style = "U ",
                Class = "L ",
                ListPrice = 337.2200
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "LL Road Frame",
                ProdCat = "Components",
                Description = "The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.",
                ProdName = "LL Road Frame - Red, 44",
                ProductNumber = "FR-R38R-44",
                Color = "Red",
                Size = "44",
                Weight = 2.32,
                StandardCost = 187.1571,
                Style = "U ",
                Class = "L ",
                ListPrice = 337.2200
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "LL Road Frame",
                ProdCat = "Components",
                Description = "The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.",
                ProdName = "LL Road Frame - Red, 48",
                ProductNumber = "FR-R38R-48",
                Color = "Red",
                Size = "48",
                Weight = 2.36,
                StandardCost = 187.1571,
                Style = "U ",
                Class = "L ",
                ListPrice = 337.2200
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "LL Road Frame",
                ProdCat = "Components",
                Description = "The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.",
                ProdName = "LL Road Frame - Red, 52",
                ProductNumber = "FR-R38R-52",
                Color = "Red",
                Size = "52",
                Weight = 2.40,
                StandardCost = 187.1571,
                Style = "U ",
                Class = "L ",
                ListPrice = 337.2200
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "LL Road Frame",
                ProdCat = "Components",
                Description = "The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.",
                ProdName = "LL Road Frame - Red, 58",
                ProductNumber = "FR-R38R-58",
                Color = "Red",
                Size = "58",
                Weight = 2.46,
                StandardCost = 187.1571,
                Style = "U ",
                Class = "L ",
                ListPrice = 337.2200
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "LL Road Frame",
                ProdCat = "Components",
                Description = "The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.",
                ProdName = "LL Road Frame - Red, 60",
                ProductNumber = "FR-R38R-60",
                Color = "Red",
                Size = "60",
                Weight = 2.48,
                StandardCost = 187.1571,
                Style = "U ",
                Class = "L ",
                ListPrice = 337.2200
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "LL Road Frame",
                ProdCat = "Components",
                Description = "The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.",
                ProdName = "LL Road Frame - Red, 62",
                ProductNumber = "FR-R38R-62",
                Color = "Red",
                Size = "62",
                Weight = 2.50,
                StandardCost = 187.1571,
                Style = "U ",
                Class = "L ",
                ListPrice = 337.2200
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "ML Road Frame",
                ProdCat = "Components",
                Description = "Made from the same aluminum alloy as our top-of-the line HL frame, the ML features a lightweight down-tube milled to the perfect diameter for optimal strength. Men's version.",
                ProdName = "ML Road Frame - Red, 44",
                ProductNumber = "FR-R72R-44",
                Color = "Red",
                Size = "44",
                Weight = 2.22,
                StandardCost = 352.1394,
                Style = "U ",
                Class = "M ",
                ListPrice = 594.8300
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "ML Road Frame",
                ProdCat = "Components",
                Description = "Made from the same aluminum alloy as our top-of-the line HL frame, the ML features a lightweight down-tube milled to the perfect diameter for optimal strength. Men's version.",
                ProdName = "ML Road Frame - Red, 48",
                ProductNumber = "FR-R72R-48",
                Color = "Red",
                Size = "48",
                Weight = 2.26,
                StandardCost = 352.1394,
                Style = "U ",
                Class = "M ",
                ListPrice = 594.8300
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "ML Road Frame",
                ProdCat = "Components",
                Description = "Made from the same aluminum alloy as our top-of-the line HL frame, the ML features a lightweight down-tube milled to the perfect diameter for optimal strength. Men's version.",
                ProdName = "ML Road Frame - Red, 52",
                ProductNumber = "FR-R72R-52",
                Color = "Red",
                Size = "52",
                Weight = 2.30,
                StandardCost = 352.1394,
                Style = "U ",
                Class = "M ",
                ListPrice = 594.8300
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "ML Road Frame",
                ProdCat = "Components",
                Description = "Made from the same aluminum alloy as our top-of-the line HL frame, the ML features a lightweight down-tube milled to the perfect diameter for optimal strength. Men's version.",
                ProdName = "ML Road Frame - Red, 58",
                ProductNumber = "FR-R72R-58",
                Color = "Red",
                Size = "58",
                Weight = 2.36,
                StandardCost = 352.1394,
                Style = "U ",
                Class = "M ",
                ListPrice = 594.8300
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "ML Road Frame",
                ProdCat = "Components",
                Description = "Made from the same aluminum alloy as our top-of-the line HL frame, the ML features a lightweight down-tube milled to the perfect diameter for optimal strength. Men's version.",
                ProdName = "ML Road Frame - Red, 60",
                ProductNumber = "FR-R72R-60",
                Color = "Red",
                Size = "60",
                Weight = 2.38,
                StandardCost = 352.1394,
                Style = "U ",
                Class = "M ",
                ListPrice = 594.8300
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "LL Road Frame",
                ProdCat = "Components",
                Description = "The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.",
                ProdName = "LL Road Frame - Black, 44",
                ProductNumber = "FR-R38B-44",
                Color = "Black",
                Size = "44",
                Weight = 2.32,
                StandardCost = 204.6251,
                Style = "U ",
                Class = "L ",
                ListPrice = 337.2200
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "LL Road Frame",
                ProdCat = "Components",
                Description = "The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.",
                ProdName = "LL Road Frame - Black, 48",
                ProductNumber = "FR-R38B-48",
                Color = "Black",
                Size = "48",
                Weight = 2.36,
                StandardCost = 204.6251,
                Style = "U ",
                Class = "L ",
                ListPrice = 337.2200
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Frames",
                ProdModel = "LL Road Frame",
                ProdCat = "Components",
                Description = "The LL Frame provides a safe comfortable ride, while offering superior bump absorption in a value-priced aluminum frame.",
                ProdName = "LL Road Frame - Black, 52",
                ProductNumber = "FR-R38B-52",
                Color = "Black",
                Size = "52",
                Weight = 2.40,
                StandardCost = 204.6251,
                Style = "U ",
                Class = "L ",
                ListPrice = 337.2200
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Frames",
                ProdModel = "HL Mountain Frame",
                ProdCat = "Components",
                Description = "Each frame is hand-crafted in our Bothell facility to the optimum diameter and wall-thickness required of a premium mountain frame. The heat-treated welded aluminum frame has a larger diameter tube that absorbs the bumps.",
                ProdName = "HL Mountain Frame - Silver, 42",
                ProductNumber = "FR-M94S-42",
                Color = "Silver",
                Size = "42",
                Weight = 2.72,
                StandardCost = 747.2002,
                Style = "U ",
                Class = "H ",
                ListPrice = 1364.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Frames",
                ProdModel = "HL Mountain Frame",
                ProdCat = "Components",
                Description = "Each frame is hand-crafted in our Bothell facility to the optimum diameter and wall-thickness required of a premium mountain frame. The heat-treated welded aluminum frame has a larger diameter tube that absorbs the bumps.",
                ProdName = "HL Mountain Frame - Silver, 44",
                ProductNumber = "FR-M94S-44",
                Color = "Silver",
                Size = "44",
                Weight = 2.76,
                StandardCost = 706.8110,
                Style = "U ",
                Class = "H ",
                ListPrice = 1364.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Frames",
                ProdModel = "HL Mountain Frame",
                ProdCat = "Components",
                Description = "Each frame is hand-crafted in our Bothell facility to the optimum diameter and wall-thickness required of a premium mountain frame. The heat-treated welded aluminum frame has a larger diameter tube that absorbs the bumps.",
                ProdName = "HL Mountain Frame - Silver, 48",
                ProductNumber = "FR-M94S-52",
                Color = "Silver",
                Size = "48",
                Weight = 2.80,
                StandardCost = 706.8110,
                Style = "U ",
                Class = "H ",
                ListPrice = 1364.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Frames",
                ProdModel = "HL Mountain Frame",
                ProdCat = "Components",
                Description = "Each frame is hand-crafted in our Bothell facility to the optimum diameter and wall-thickness required of a premium mountain frame. The heat-treated welded aluminum frame has a larger diameter tube that absorbs the bumps.",
                ProdName = "HL Mountain Frame - Silver, 46",
                ProductNumber = "FR-M94S-46",
                Color = "Silver",
                Size = "46",
                Weight = 2.84,
                StandardCost = 747.2002,
                Style = "U ",
                Class = "H ",
                ListPrice = 1364.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Frames",
                ProdModel = "HL Mountain Frame",
                ProdCat = "Components",
                Description = "Each frame is hand-crafted in our Bothell facility to the optimum diameter and wall-thickness required of a premium mountain frame. The heat-treated welded aluminum frame has a larger diameter tube that absorbs the bumps.",
                ProdName = "HL Mountain Frame - Black, 42",
                ProductNumber = "FR-M94B-42",
                Color = "Black",
                Size = "42",
                Weight = 2.72,
                StandardCost = 739.0410,
                Style = "U ",
                Class = "H ",
                ListPrice = 1349.6000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Frames",
                ProdModel = "HL Mountain Frame",
                ProdCat = "Components",
                Description = "Each frame is hand-crafted in our Bothell facility to the optimum diameter and wall-thickness required of a premium mountain frame. The heat-treated welded aluminum frame has a larger diameter tube that absorbs the bumps.",
                ProdName = "HL Mountain Frame - Black, 44",
                ProductNumber = "FR-M94B-44",
                Color = "Black",
                Size = "44",
                Weight = 2.76,
                StandardCost = 699.0928,
                Style = "U ",
                Class = "H ",
                ListPrice = 1349.6000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Frames",
                ProdModel = "HL Mountain Frame",
                ProdCat = "Components",
                Description = "Each frame is hand-crafted in our Bothell facility to the optimum diameter and wall-thickness required of a premium mountain frame. The heat-treated welded aluminum frame has a larger diameter tube that absorbs the bumps.",
                ProdName = "HL Mountain Frame - Black, 48",
                ProductNumber = "FR-M94B-48",
                Color = "Black",
                Size = "48",
                Weight = 2.80,
                StandardCost = 699.0928,
                Style = "U ",
                Class = "H ",
                ListPrice = 1349.6000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Frames",
                ProdModel = "HL Mountain Frame",
                ProdCat = "Components",
                Description = "Each frame is hand-crafted in our Bothell facility to the optimum diameter and wall-thickness required of a premium mountain frame. The heat-treated welded aluminum frame has a larger diameter tube that absorbs the bumps.",
                ProdName = "HL Mountain Frame - Black, 46",
                ProductNumber = "FR-M94B-46",
                Color = "Black",
                Size = "46",
                Weight = 2.84,
                StandardCost = 739.0410,
                Style = "U ",
                Class = "H ",
                ListPrice = 1349.6000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Frames",
                ProdModel = "HL Mountain Frame",
                ProdCat = "Components",
                Description = "Each frame is hand-crafted in our Bothell facility to the optimum diameter and wall-thickness required of a premium mountain frame. The heat-treated welded aluminum frame has a larger diameter tube that absorbs the bumps.",
                ProdName = "HL Mountain Frame - Black, 38",
                ProductNumber = "FR-M94B-38",
                Color = "Black",
                Size = "38",
                Weight = 2.68,
                StandardCost = 739.0410,
                Style = "U ",
                Class = "H ",
                ListPrice = 1349.6000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Frames",
                ProdModel = "HL Mountain Frame",
                ProdCat = "Components",
                Description = "Each frame is hand-crafted in our Bothell facility to the optimum diameter and wall-thickness required of a premium mountain frame. The heat-treated welded aluminum frame has a larger diameter tube that absorbs the bumps.",
                ProdName = "HL Mountain Frame - Silver, 38",
                ProductNumber = "FR-M94S-38",
                Color = "Silver",
                Size = "38",
                Weight = 2.68,
                StandardCost = 747.2002,
                Style = "U ",
                Class = "H ",
                ListPrice = 1364.5000
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-150",
                ProdCat = "Bikes",
                Description = "This bike is ridden by race winners. Developed with the Adventure Works Cycles professional race team, it has a extremely light heat-treated aluminum frame, and steering that allows precision control.",
                ProdName = "Road-150 Red, 62",
                ProductNumber = "BK-R93R-62",
                Color = "Red",
                Size = "62",
                Weight = 15.00,
                StandardCost = 2171.2942,
                Style = "U ",
                Class = "H ",
                ListPrice = 3578.2700
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-150",
                ProdCat = "Bikes",
                Description = "This bike is ridden by race winners. Developed with the Adventure Works Cycles professional race team, it has a extremely light heat-treated aluminum frame, and steering that allows precision control.",
                ProdName = "Road-150 Red, 44",
                ProductNumber = "BK-R93R-44",
                Color = "Red",
                Size = "44",
                Weight = 13.77,
                StandardCost = 2171.2942,
                Style = "U ",
                Class = "H ",
                ListPrice = 3578.2700
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-150",
                ProdCat = "Bikes",
                Description = "This bike is ridden by race winners. Developed with the Adventure Works Cycles professional race team, it has a extremely light heat-treated aluminum frame, and steering that allows precision control.",
                ProdName = "Road-150 Red, 48",
                ProductNumber = "BK-R93R-48",
                Color = "Red",
                Size = "48",
                Weight = 14.13,
                StandardCost = 2171.2942,
                Style = "U ",
                Class = "H ",
                ListPrice = 3578.2700
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-150",
                ProdCat = "Bikes",
                Description = "This bike is ridden by race winners. Developed with the Adventure Works Cycles professional race team, it has a extremely light heat-treated aluminum frame, and steering that allows precision control.",
                ProdName = "Road-150 Red, 52",
                ProductNumber = "BK-R93R-52",
                Color = "Red",
                Size = "52",
                Weight = 14.42,
                StandardCost = 2171.2942,
                Style = "U ",
                Class = "H ",
                ListPrice = 3578.2700
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-150",
                ProdCat = "Bikes",
                Description = "This bike is ridden by race winners. Developed with the Adventure Works Cycles professional race team, it has a extremely light heat-treated aluminum frame, and steering that allows precision control.",
                ProdName = "Road-150 Red, 56",
                ProductNumber = "BK-R93R-56",
                Color = "Red",
                Size = "56",
                Weight = 14.68,
                StandardCost = 2171.2942,
                Style = "U ",
                Class = "H ",
                ListPrice = 3578.2700
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-450",
                ProdCat = "Bikes",
                Description = "A true multi-sport bike that offers streamlined riding and a revolutionary design. Aerodynamic design lets you ride with the pros, and the gearing will conquer hilly roads.",
                ProdName = "Road-450 Red, 58",
                ProductNumber = "BK-R68R-58",
                Color = "Red",
                Size = "58",
                Weight = 17.79,
                StandardCost = 884.7083,
                Style = "U ",
                Class = "M ",
                ListPrice = 1457.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-450",
                ProdCat = "Bikes",
                Description = "A true multi-sport bike that offers streamlined riding and a revolutionary design. Aerodynamic design lets you ride with the pros, and the gearing will conquer hilly roads.",
                ProdName = "Road-450 Red, 60",
                ProductNumber = "BK-R68R-60",
                Color = "Red",
                Size = "60",
                Weight = 17.90,
                StandardCost = 884.7083,
                Style = "U ",
                Class = "M ",
                ListPrice = 1457.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-450",
                ProdCat = "Bikes",
                Description = "A true multi-sport bike that offers streamlined riding and a revolutionary design. Aerodynamic design lets you ride with the pros, and the gearing will conquer hilly roads.",
                ProdName = "Road-450 Red, 44",
                ProductNumber = "BK-R68R-44",
                Color = "Red",
                Size = "44",
                Weight = 16.77,
                StandardCost = 884.7083,
                Style = "U ",
                Class = "M ",
                ListPrice = 1457.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-450",
                ProdCat = "Bikes",
                Description = "A true multi-sport bike that offers streamlined riding and a revolutionary design. Aerodynamic design lets you ride with the pros, and the gearing will conquer hilly roads.",
                ProdName = "Road-450 Red, 48",
                ProductNumber = "BK-R68R-48",
                Color = "Red",
                Size = "48",
                Weight = 17.13,
                StandardCost = 884.7083,
                Style = "U ",
                Class = "M ",
                ListPrice = 1457.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-450",
                ProdCat = "Bikes",
                Description = "A true multi-sport bike that offers streamlined riding and a revolutionary design. Aerodynamic design lets you ride with the pros, and the gearing will conquer hilly roads.",
                ProdName = "Road-450 Red, 52",
                ProductNumber = "BK-R68R-52",
                Color = "Red",
                Size = "52",
                Weight = 17.42,
                StandardCost = 884.7083,
                Style = "U ",
                Class = "M ",
                ListPrice = 1457.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-650",
                ProdCat = "Bikes",
                Description = "Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we're famous for.",
                ProdName = "Road-650 Red, 58",
                ProductNumber = "BK-R50R-58",
                Color = "Red",
                Size = "58",
                Weight = 19.79,
                StandardCost = 486.7066,
                Style = "U ",
                Class = "L ",
                ListPrice = 782.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-650",
                ProdCat = "Bikes",
                Description = "Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we're famous for.",
                ProdName = "Road-650 Red, 60",
                ProductNumber = "BK-R50R-60",
                Color = "Red",
                Size = "60",
                Weight = 19.90,
                StandardCost = 486.7066,
                Style = "U ",
                Class = "L ",
                ListPrice = 782.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-650",
                ProdCat = "Bikes",
                Description = "Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we're famous for.",
                ProdName = "Road-650 Red, 62",
                ProductNumber = "BK-R50R-62",
                Color = "Red",
                Size = "62",
                Weight = 20.00,
                StandardCost = 486.7066,
                Style = "U ",
                Class = "L ",
                ListPrice = 782.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-650",
                ProdCat = "Bikes",
                Description = "Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we're famous for.",
                ProdName = "Road-650 Red, 44",
                ProductNumber = "BK-R50R-44",
                Color = "Red",
                Size = "44",
                Weight = 18.77,
                StandardCost = 486.7066,
                Style = "U ",
                Class = "L ",
                ListPrice = 782.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-650",
                ProdCat = "Bikes",
                Description = "Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we're famous for.",
                ProdName = "Road-650 Red, 48",
                ProductNumber = "BK-R50R-48",
                Color = "Red",
                Size = "48",
                Weight = 19.13,
                StandardCost = 486.7066,
                Style = "U ",
                Class = "L ",
                ListPrice = 782.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-650",
                ProdCat = "Bikes",
                Description = "Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we're famous for.",
                ProdName = "Road-650 Red, 52",
                ProductNumber = "BK-R50R-52",
                Color = "Red",
                Size = "52",
                Weight = 19.42,
                StandardCost = 486.7066,
                Style = "U ",
                Class = "L ",
                ListPrice = 782.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-650",
                ProdCat = "Bikes",
                Description = "Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we're famous for.",
                ProdName = "Road-650 Black, 58",
                ProductNumber = "BK-R50B-58",
                Color = "Black",
                Size = "58",
                Weight = 19.79,
                StandardCost = 486.7066,
                Style = "U ",
                Class = "L ",
                ListPrice = 782.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-650",
                ProdCat = "Bikes",
                Description = "Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we're famous for.",
                ProdName = "Road-650 Black, 60",
                ProductNumber = "BK-R50B-60",
                Color = "Black",
                Size = "60",
                Weight = 19.90,
                StandardCost = 486.7066,
                Style = "U ",
                Class = "L ",
                ListPrice = 782.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-650",
                ProdCat = "Bikes",
                Description = "Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we're famous for.",
                ProdName = "Road-650 Black, 62",
                ProductNumber = "BK-R50B-62",
                Color = "Black",
                Size = "62",
                Weight = 20.00,
                StandardCost = 486.7066,
                Style = "U ",
                Class = "L ",
                ListPrice = 782.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-650",
                ProdCat = "Bikes",
                Description = "Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we're famous for.",
                ProdName = "Road-650 Black, 44",
                ProductNumber = "BK-R50B-44",
                Color = "Black",
                Size = "44",
                Weight = 18.77,
                StandardCost = 486.7066,
                Style = "U ",
                Class = "L ",
                ListPrice = 782.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-650",
                ProdCat = "Bikes",
                Description = "Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we're famous for.",
                ProdName = "Road-650 Black, 48",
                ProductNumber = "BK-R50B-48",
                Color = "Black",
                Size = "48",
                Weight = 19.13,
                StandardCost = 486.7066,
                Style = "U ",
                Class = "L ",
                ListPrice = 782.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-650",
                ProdCat = "Bikes",
                Description = "Value-priced bike with many features of our top-of-the-line models. Has the same light, stiff frame, and the quick acceleration we're famous for.",
                ProdName = "Road-650 Black, 52",
                ProductNumber = "BK-R50B-52",
                Color = "Black",
                Size = "52",
                Weight = 19.42,
                StandardCost = 486.7066,
                Style = "U ",
                Class = "L ",
                ListPrice = 782.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-100",
                ProdCat = "Bikes",
                Description = "Top-of-the-line competition mountain bike. Performance-enhancing options include the innovative HL Frame, super-smooth front suspension, and traction for all terrain.",
                ProdName = "Mountain-100 Silver, 38",
                ProductNumber = "BK-M82S-38",
                Color = "Silver",
                Size = "38",
                Weight = 20.35,
                StandardCost = 1912.1544,
                Style = "U ",
                Class = "H ",
                ListPrice = 3399.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-100",
                ProdCat = "Bikes",
                Description = "Top-of-the-line competition mountain bike. Performance-enhancing options include the innovative HL Frame, super-smooth front suspension, and traction for all terrain.",
                ProdName = "Mountain-100 Silver, 42",
                ProductNumber = "BK-M82S-42",
                Color = "Silver",
                Size = "42",
                Weight = 20.77,
                StandardCost = 1912.1544,
                Style = "U ",
                Class = "H ",
                ListPrice = 3399.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-100",
                ProdCat = "Bikes",
                Description = "Top-of-the-line competition mountain bike. Performance-enhancing options include the innovative HL Frame, super-smooth front suspension, and traction for all terrain.",
                ProdName = "Mountain-100 Silver, 44",
                ProductNumber = "BK-M82S-44",
                Color = "Silver",
                Size = "44",
                Weight = 21.13,
                StandardCost = 1912.1544,
                Style = "U ",
                Class = "H ",
                ListPrice = 3399.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-100",
                ProdCat = "Bikes",
                Description = "Top-of-the-line competition mountain bike. Performance-enhancing options include the innovative HL Frame, super-smooth front suspension, and traction for all terrain.",
                ProdName = "Mountain-100 Silver, 48",
                ProductNumber = "BK-M82S-48",
                Color = "Silver",
                Size = "48",
                Weight = 21.42,
                StandardCost = 1912.1544,
                Style = "U ",
                Class = "H ",
                ListPrice = 3399.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-100",
                ProdCat = "Bikes",
                Description = "Top-of-the-line competition mountain bike. Performance-enhancing options include the innovative HL Frame, super-smooth front suspension, and traction for all terrain.",
                ProdName = "Mountain-100 Black, 38",
                ProductNumber = "BK-M82B-38",
                Color = "Black",
                Size = "38",
                Weight = 20.35,
                StandardCost = 1898.0944,
                Style = "U ",
                Class = "H ",
                ListPrice = 3374.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-100",
                ProdCat = "Bikes",
                Description = "Top-of-the-line competition mountain bike. Performance-enhancing options include the innovative HL Frame, super-smooth front suspension, and traction for all terrain.",
                ProdName = "Mountain-100 Black, 42",
                ProductNumber = "BK-M82B-42",
                Color = "Black",
                Size = "42",
                Weight = 20.77,
                StandardCost = 1898.0944,
                Style = "U ",
                Class = "H ",
                ListPrice = 3374.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-100",
                ProdCat = "Bikes",
                Description = "Top-of-the-line competition mountain bike. Performance-enhancing options include the innovative HL Frame, super-smooth front suspension, and traction for all terrain.",
                ProdName = "Mountain-100 Black, 44",
                ProductNumber = "BK-M82B-44",
                Color = "Black",
                Size = "44",
                Weight = 21.13,
                StandardCost = 1898.0944,
                Style = "U ",
                Class = "H ",
                ListPrice = 3374.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-100",
                ProdCat = "Bikes",
                Description = "Top-of-the-line competition mountain bike. Performance-enhancing options include the innovative HL Frame, super-smooth front suspension, and traction for all terrain.",
                ProdName = "Mountain-100 Black, 48",
                ProductNumber = "BK-M82B-48",
                Color = "Black",
                Size = "48",
                Weight = 21.42,
                StandardCost = 1898.0944,
                Style = "U ",
                Class = "H ",
                ListPrice = 3374.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-200",
                ProdCat = "Bikes",
                Description = "Serious back-country riding. Perfect for all levels of competition. Uses the same HL Frame as the Mountain-100.",
                ProdName = "Mountain-200 Silver, 38",
                ProductNumber = "BK-M68S-38",
                Color = "Silver",
                Size = "38",
                Weight = 23.35,
                StandardCost = 1265.6195,
                Style = "U ",
                Class = "H ",
                ListPrice = 2319.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-200",
                ProdCat = "Bikes",
                Description = "Serious back-country riding. Perfect for all levels of competition. Uses the same HL Frame as the Mountain-100.",
                ProdName = "Mountain-200 Silver, 42",
                ProductNumber = "BK-M68S-42",
                Color = "Silver",
                Size = "42",
                Weight = 23.77,
                StandardCost = 1265.6195,
                Style = "U ",
                Class = "H ",
                ListPrice = 2319.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-200",
                ProdCat = "Bikes",
                Description = "Serious back-country riding. Perfect for all levels of competition. Uses the same HL Frame as the Mountain-100.",
                ProdName = "Mountain-200 Silver, 46",
                ProductNumber = "BK-M68S-46",
                Color = "Silver",
                Size = "46",
                Weight = 24.13,
                StandardCost = 1265.6195,
                Style = "U ",
                Class = "H ",
                ListPrice = 2319.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-200",
                ProdCat = "Bikes",
                Description = "Serious back-country riding. Perfect for all levels of competition. Uses the same HL Frame as the Mountain-100.",
                ProdName = "Mountain-200 Black, 38",
                ProductNumber = "BK-M68B-38",
                Color = "Black",
                Size = "38",
                Weight = 23.35,
                StandardCost = 1251.9813,
                Style = "U ",
                Class = "H ",
                ListPrice = 2294.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-200",
                ProdCat = "Bikes",
                Description = "Serious back-country riding. Perfect for all levels of competition. Uses the same HL Frame as the Mountain-100.",
                ProdName = "Mountain-200 Black, 42",
                ProductNumber = "BK-M68B-42",
                Color = "Black",
                Size = "42",
                Weight = 23.77,
                StandardCost = 1251.9813,
                Style = "U ",
                Class = "H ",
                ListPrice = 2294.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-200",
                ProdCat = "Bikes",
                Description = "Serious back-country riding. Perfect for all levels of competition. Uses the same HL Frame as the Mountain-100.",
                ProdName = "Mountain-200 Black, 46",
                ProductNumber = "BK-M68B-46",
                Color = "Black",
                Size = "46",
                Weight = 24.13,
                StandardCost = 1251.9813,
                Style = "U ",
                Class = "H ",
                ListPrice = 2294.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-300",
                ProdCat = "Bikes",
                Description = "For true trail addicts.  An extremely durable bike that will go anywhere and keep you in control on challenging terrain - without breaking your budget.",
                ProdName = "Mountain-300 Black, 38",
                ProductNumber = "BK-M47B-38",
                Color = "Black",
                Size = "38",
                Weight = 25.35,
                StandardCost = 598.4354,
                Style = "U ",
                Class = "M ",
                ListPrice = 1079.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-300",
                ProdCat = "Bikes",
                Description = "For true trail addicts.  An extremely durable bike that will go anywhere and keep you in control on challenging terrain - without breaking your budget.",
                ProdName = "Mountain-300 Black, 40",
                ProductNumber = "BK-M47B-40",
                Color = "Black",
                Size = "40",
                Weight = 25.77,
                StandardCost = 598.4354,
                Style = "U ",
                Class = "M ",
                ListPrice = 1079.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-300",
                ProdCat = "Bikes",
                Description = "For true trail addicts.  An extremely durable bike that will go anywhere and keep you in control on challenging terrain - without breaking your budget.",
                ProdName = "Mountain-300 Black, 44",
                ProductNumber = "BK-M47B-44",
                Color = "Black",
                Size = "44",
                Weight = 26.13,
                StandardCost = 598.4354,
                Style = "U ",
                Class = "M ",
                ListPrice = 1079.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Mountain Bikes",
                ProdModel = "Mountain-300",
                ProdCat = "Bikes",
                Description = "For true trail addicts.  An extremely durable bike that will go anywhere and keep you in control on challenging terrain - without breaking your budget.",
                ProdName = "Mountain-300 Black, 48",
                ProductNumber = "BK-M47B-48",
                Color = "Black",
                Size = "48",
                Weight = 26.42,
                StandardCost = 598.4354,
                Style = "U ",
                Class = "M ",
                ListPrice = 1079.9900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-250",
                ProdCat = "Bikes",
                Description = "Alluminum-alloy frame provides a light, stiff ride, whether you are racing in the velodrome or on a demanding club ride on country roads.",
                ProdName = "Road-250 Red, 44",
                ProductNumber = "BK-R89R-44",
                Color = "Red",
                Size = "44",
                Weight = 14.77,
                StandardCost = 1518.7864,
                Style = "U ",
                Class = "H ",
                ListPrice = 2443.3500
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-250",
                ProdCat = "Bikes",
                Description = "Alluminum-alloy frame provides a light, stiff ride, whether you are racing in the velodrome or on a demanding club ride on country roads.",
                ProdName = "Road-250 Red, 48",
                ProductNumber = "BK-R89R-48",
                Color = "Red",
                Size = "48",
                Weight = 15.13,
                StandardCost = 1518.7864,
                Style = "U ",
                Class = "H ",
                ListPrice = 2443.3500
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-250",
                ProdCat = "Bikes",
                Description = "Alluminum-alloy frame provides a light, stiff ride, whether you are racing in the velodrome or on a demanding club ride on country roads.",
                ProdName = "Road-250 Red, 52",
                ProductNumber = "BK-R89R-52",
                Color = "Red",
                Size = "52",
                Weight = 15.42,
                StandardCost = 1518.7864,
                Style = "U ",
                Class = "H ",
                ListPrice = 2443.3500
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-250",
                ProdCat = "Bikes",
                Description = "Alluminum-alloy frame provides a light, stiff ride, whether you are racing in the velodrome or on a demanding club ride on country roads.",
                ProdName = "Road-250 Red, 58",
                ProductNumber = "BK-R89R-58",
                Color = "Red",
                Size = "58",
                Weight = 15.79,
                StandardCost = 1554.9479,
                Style = "U ",
                Class = "H ",
                ListPrice = 2443.3500
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-250",
                ProdCat = "Bikes",
                Description = "Alluminum-alloy frame provides a light, stiff ride, whether you are racing in the velodrome or on a demanding club ride on country roads.",
                ProdName = "Road-250 Black, 44",
                ProductNumber = "BK-R89B-44",
                Color = "Black",
                Size = "44",
                Weight = 14.77,
                StandardCost = 1554.9479,
                Style = "U ",
                Class = "H ",
                ListPrice = 2443.3500
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-250",
                ProdCat = "Bikes",
                Description = "Alluminum-alloy frame provides a light, stiff ride, whether you are racing in the velodrome or on a demanding club ride on country roads.",
                ProdName = "Road-250 Black, 48",
                ProductNumber = "BK-R89B-48",
                Color = "Black",
                Size = "48",
                Weight = 15.13,
                StandardCost = 1554.9479,
                Style = "U ",
                Class = "H ",
                ListPrice = 2443.3500
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-250",
                ProdCat = "Bikes",
                Description = "Alluminum-alloy frame provides a light, stiff ride, whether you are racing in the velodrome or on a demanding club ride on country roads.",
                ProdName = "Road-250 Black, 52",
                ProductNumber = "BK-R89B-52",
                Color = "Black",
                Size = "52",
                Weight = 15.42,
                StandardCost = 1554.9479,
                Style = "U ",
                Class = "H ",
                ListPrice = 2443.3500
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-250",
                ProdCat = "Bikes",
                Description = "Alluminum-alloy frame provides a light, stiff ride, whether you are racing in the velodrome or on a demanding club ride on country roads.",
                ProdName = "Road-250 Black, 58",
                ProductNumber = "BK-R89B-58",
                Color = "Black",
                Size = "58",
                Weight = 15.68,
                StandardCost = 1554.9479,
                Style = "U ",
                Class = "H ",
                ListPrice = 2443.3500
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-550-W",
                ProdCat = "Bikes",
                Description = "Same technology as all of our Road series bikes, but the frame is sized for a woman.  Perfect all-around bike for road or racing.",
                ProdName = "Road-550-W Yellow, 38",
                ProductNumber = "BK-R64Y-38",
                Color = "Yellow",
                Size = "38",
                Weight = 17.35,
                StandardCost = 713.0798,
                Style = "W ",
                Class = "M ",
                ListPrice = 1120.4900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-550-W",
                ProdCat = "Bikes",
                Description = "Same technology as all of our Road series bikes, but the frame is sized for a woman.  Perfect all-around bike for road or racing.",
                ProdName = "Road-550-W Yellow, 40",
                ProductNumber = "BK-R64Y-40",
                Color = "Yellow",
                Size = "40",
                Weight = 17.77,
                StandardCost = 713.0798,
                Style = "W ",
                Class = "M ",
                ListPrice = 1120.4900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-550-W",
                ProdCat = "Bikes",
                Description = "Same technology as all of our Road series bikes, but the frame is sized for a woman.  Perfect all-around bike for road or racing.",
                ProdName = "Road-550-W Yellow, 42",
                ProductNumber = "BK-R64Y-42",
                Color = "Yellow",
                Size = "42",
                Weight = 18.13,
                StandardCost = 713.0798,
                Style = "W ",
                Class = "M ",
                ListPrice = 1120.4900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-550-W",
                ProdCat = "Bikes",
                Description = "Same technology as all of our Road series bikes, but the frame is sized for a woman.  Perfect all-around bike for road or racing.",
                ProdName = "Road-550-W Yellow, 44",
                ProductNumber = "BK-R64Y-44",
                Color = "Yellow",
                Size = "44",
                Weight = 18.42,
                StandardCost = 713.0798,
                Style = "W ",
                Class = "M ",
                ListPrice = 1120.4900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Road Bikes",
                ProdModel = "Road-550-W",
                ProdCat = "Bikes",
                Description = "Same technology as all of our Road series bikes, but the frame is sized for a woman.  Perfect all-around bike for road or racing.",
                ProdName = "Road-550-W Yellow, 48",
                ProductNumber = "BK-R64Y-48",
                Color = "Yellow",
                Size = "48",
                Weight = 18.68,
                StandardCost = 713.0798,
                Style = "W ",
                Class = "M ",
                ListPrice = 1120.4900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Forks",
                ProdModel = "LL Fork",
                ProdCat = "Components",
                Description = "Stout design absorbs shock and offers more precise steering.",
                ProdName = "LL Fork",
                ProductNumber = "FK-1639",
                Color = "",
                Size = "",
                Weight = null,
                StandardCost = 65.8097,
                Style = "",
                Class = "L ",
                ListPrice = 148.2200
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Forks",
                ProdModel = "ML Fork",
                ProdCat = "Components",
                Description = "Composite road fork with an aluminum steerer tube.",
                ProdName = "ML Fork",
                ProductNumber = "FK-5136",
                Color = "",
                Size = "",
                Weight = null,
                StandardCost = 77.9176,
                Style = "",
                Class = "M ",
                ListPrice = 175.4900
            };
            datas.Add(data);
            data = new ProductCatalogSource()
            {
                ProdSubCat = "Forks",
                ProdModel = "HL Fork",
                ProdCat = "Components",
                Description = "High-performance carbon road fork with curved legs.",
                ProdName = "HL Fork",
                ProductNumber = "FK-9939",
                Color = "",
                Size = "",
                Weight = null,
                StandardCost = 101.8936,
                Style = "",
                Class = "H ",
                ListPrice = 229.4900
            };
            datas.Add(data);
            return datas;
        }
    }

	#endregion
}
