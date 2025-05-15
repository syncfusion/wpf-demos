#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Controls.PivotGrid;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace syncfusion.pivotgriddemos.wpf
{
    public class ProductSalesViewModel : NotificationObject
    {
        private object productSalesData;

        public object ProductSalesData
        {
            get
            {
                this.productSalesData = this.productSalesData ?? ProductSales.GetSalesData();
                return this.productSalesData;
            }
            set
            {
                this.productSalesData = value;
                RaisePropertyChanged("ProductSalesData");
            }
        }    

        private DataView dataTableViewSource;

        public DataView BusinessObjectAsDataView
        {
            get
            {
                this.dataTableViewSource = this.dataTableViewSource ?? BusinessObjectsDataView.GetDataTable(200);
                return this.dataTableViewSource;
            }
            set { this.dataTableViewSource = value; }
        }

        private DelegateCommand<object> updateItemsSourceCommand;

        public DelegateCommand<object> UpdateProductSalesDataCommand
        {
            get
            {
                this.updateItemsSourceCommand = this.updateItemsSourceCommand ?? new DelegateCommand<object>(UpdateItemsSource);
                return this.updateItemsSourceCommand;
            }
            set { this.updateItemsSourceCommand = value; }
        }

        public List<string> ProductList
        {
            get
            {
                return new List<string> { "Bike", "Car" };
            }
        }

        public List<string> CountryList
        {
            get
            {
                return new List<string> { "Canada", "France" };
            }
        }

        private void UpdateItemsSource(object parm)
        {
            this.ProductSalesData = ProductSales.UpdateSalesData(this.ProductSalesData as ProductSales.ProductSalesCollection);
        }

    }
}