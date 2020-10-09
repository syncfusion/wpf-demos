#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.HeatMap;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace syncfusion.heatmapdemos.wpf
{
    public class ItemsMappingViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProductInfoModel> _productlist;
        private ObservableCollection<ProductInfo> _productinfo;
        private ICommand _TableMappingCommand;
        private ICommand _CellMappingCommand;
        private ItemsMapping _items;

        /// <summary>
        /// Gets or sets the TableMapping command value
        /// </summary>
        public ICommand TableMappingCommand
        {
            get { return _TableMappingCommand; }
            set { _TableMappingCommand = value; }
        }

        /// <summary>
        /// Gets or sets the CellMapping command value
        /// </summary>
        public ICommand CellMappingCommand
        {
            get { return _CellMappingCommand; }
            set { _CellMappingCommand = value; }
        }

        public ItemsMappingViewModel()
        {
            TableMappingCommand = new DelegateCommand(OnTableMappingCommand);
            CellMappingCommand = new DelegateCommand(OnCellMappingCommand);
            ProductList = new ObservableCollection<ProductInfoModel>();
            ProductInfo = new ObservableCollection<ProductInfo>();
            PopulationTable();
            Items = GetTableModel();
        }

        private void OnCellMappingCommand(object obj)
        {
            if (obj != null && obj is SfHeatMap)
            {
                AddCellData();
                (obj as SfHeatMap).ItemsSource = ProductInfo;
                Items = GetCellModel();
            }
        }

        private void OnTableMappingCommand(object obj)
        {
            if (obj != null && obj is SfHeatMap)
            {
                PopulationTable();
                (obj as SfHeatMap).ItemsSource = ProductList;
                Items = GetTableModel();
            }
        }

        public ItemsMapping Items
        {
            get
            {
                return _items;
            }
            set
            {
                if(value != _items)
                {
                    _items = value;
                    onpropertychanged("Items");
                }
            }
        }

        public ObservableCollection<ProductInfoModel> ProductList
        {
            get
            {
                return _productlist;
            }
            set
            {
                if (value != _productlist)
                {
                    _productlist = value;
                    onpropertychanged("ProductList");
                }
            }
        }

        public ObservableCollection<ProductInfo> ProductInfo
        {
            get
            {
                return _productinfo;
            }
            set
            {
                if (value != _productinfo)
                {
                    _productinfo = value;
                    onpropertychanged("ProductInfo");
                }
            }
        }

        private void onpropertychanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        string[] productName = new string[]
        {
            "Vegie-spread",
            "Tofuaa",
            "Alice Mutton",
            "Konbu",
            "Fløtemysost",
            "Perth",
            "Boston",
            "Raclette",
            "Gorgonzola",
            "Chartreuse",
            "Tigers",
            "Tarte",
            "Queso",
            "Valkoinen",
            "Thüringer",
        };

        private void PopulationTable()
        {
            Random r = new Random();
            var productList = new ObservableCollection<ProductInfoModel>();

            for (int i = 0; i <= 7; i++)
            {
                ProductInfoModel productInfo = new ProductInfoModel();
                productInfo.ProductName = productName[12 - i];
                productInfo.Y2010 = r.Next(0, 100);
                productInfo.Y2011 = r.Next(0, 100);
                productInfo.Y2012 = r.Next(0, 100);
                productInfo.Y2013 = r.Next(0, 100);
                productInfo.Y2014 = r.Next(0, 100);
                productInfo.Y2015 = r.Next(0, 100);
                productList.Add(productInfo);
            }
            ProductList = productList;
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
            ProductInfo = dataFlat;
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
