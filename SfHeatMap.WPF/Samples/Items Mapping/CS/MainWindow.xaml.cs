#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Getting_Started;
using Syncfusion.UI.Xaml.HeatMap;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Items_Mapping
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //PopulationTable();
            //AddCellData();            
        }

        private void PopulationTable()
        {
            Random r = new Random();
            var productList = new ObservableCollection<ProductInfoModel>();

            for (int i = 0; i <= 7; i++)
            {
                ProductInfoModel productInfo = new ProductInfoModel();
                productInfo.ProductName = productName[12-i];
                productInfo.Y2010 = r.Next(0, 100);
                productInfo.Y2011 = r.Next(0, 100);
                productInfo.Y2012 = r.Next(0, 100);
                productInfo.Y2013 = r.Next(0, 100);
                productInfo.Y2014 = r.Next(0, 100);
                productInfo.Y2015 = r.Next(0, 100);
                productList.Add(productInfo);
            }
            DataContext = productList;
        }

        private void AddCellData()
        {
            Random r = new Random();
            var dataFlat = new ObservableCollection<ProductInfo>();
            for (int j = 0; j <= 5; j++)
            {
                dataFlat.Add(new ProductInfo(productName[j], 2011, r.Next(0, 100)));
                dataFlat.Add(new ProductInfo(productName[j], 2012, r.Next(0, 100)));
                dataFlat.Add(new ProductInfo(productName[j], 2013, r.Next(0, 100)));
                dataFlat.Add(new ProductInfo(productName[j], 2014, r.Next(0, 100)));
                dataFlat.Add(new ProductInfo(productName[j], 2015, r.Next(0, 100)));
                dataFlat.Add(new ProductInfo(productName[j], 2016, r.Next(0, 100)));
            }
            DataContext = dataFlat;
        }

        string[] productName = new string[]
        {
            "Vegie-spread",
            "Tofuaa",
            "Alice Mutton",
            "Konbu",
            "Fløtemysost",
            "Perth Pasties",
            "Boston Crab Meat",
            "Raclette Courdavault",
            "Gorgonzola Telino",
            "Chartreuse verte",            
            "Carnarvon Tigers",
            "Tarte au sucre",   
            "Queso Manchego",
            "Valkoinen suklaa",
            "Thüringer Rostbratwurst",            
        };     

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (Table.IsChecked == true)
            {
                PopulationTable();
                heatmap.ItemsSource = DataContext;
                heatmap.ItemsMapping = GetTableModel();
                //heatmap.ItemsMapping = this.Resources["TableModel"] as ItemsMapping;
            }
            else if (Cell.IsChecked == true)
            {
                AddCellData();
                heatmap.ItemsSource = DataContext;
                heatmap.ItemsMapping = GetCellModel();
                //heatmap.ItemsMapping = this.Resources["CellModel"] as ItemsMapping;                
            }
        }

        private ItemsMapping GetCellModel()
        {
            CellMapping cell = new CellMapping();
            cell.Column = new ColumnMapping() { PropertyName = "ProductName", DisplayName = "Product Name" };
            cell.Row = new ColumnMapping() { PropertyName = "Year", DisplayName = "Year", };
            cell.Value = new ColumnMapping() { PropertyName = "Value" };
            return cell;
        }

        private ItemsMapping GetTableModel()
        {
            TableMapping table = new TableMapping();
            table.HeaderMapping = new ColumnMapping() { PropertyName = "ProductName", DisplayName = "Product Name" };
            table.ColumnMapping = new List<ColumnMapping>();
            ColumnMapping column = new ColumnMapping();
            column.PropertyName = "Y2010";
            column.DisplayName = "Y2010";
            ColumnMapping column1 = new ColumnMapping();
            column1.PropertyName = "Y2011";
            column1.DisplayName = "Y2011";
            ColumnMapping column2 = new ColumnMapping();
            column2.PropertyName = "Y2012";
            column2.DisplayName = "Y2012";
            ColumnMapping column3 = new ColumnMapping();
            column3.PropertyName = "Y2013";
            column3.DisplayName = "Y2013";
            ColumnMapping column4 = new ColumnMapping();
            column4.PropertyName = "Y2014";
            column4.DisplayName = "Y2014";
            ColumnMapping column5 = new ColumnMapping();
            column5.PropertyName = "Y2015";
            column5.DisplayName = "Y2015";
            table.ColumnMapping.Add(column);
            table.ColumnMapping.Add(column1);
            table.ColumnMapping.Add(column2);
            table.ColumnMapping.Add(column3);
            table.ColumnMapping.Add(column4);
            table.ColumnMapping.Add(column5);
            return table;
        }
    }
}
