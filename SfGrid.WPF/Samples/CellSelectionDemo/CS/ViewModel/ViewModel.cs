#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CellSelectionDemo.DataModel;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellSelectionDemo
{
    class ViewModel : NotificationObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.PopulateData();
        }

        #region Private Memebers

        private double _Average;
        private int _Count;
        private int _NumCount;
        private double _Min;
        private double _Max;
        private double _Sum;
        private ObservableCollection<ProductInfoModel> productList = new ObservableCollection<ProductInfoModel>();

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the Average value of the cells.
        /// </summary>
        /// <value>The Average Value.</value>
        public double Average
        {
            get { return _Average; }
            set { _Average = value; RaisePropertyChanged("Average"); }
        }

        /// <summary>
        /// Gets or sets the Count of the cells.
        /// </summary>
        /// <value>The Count.</value>
        public int Count
        {
            get { return _Count; }
            set { _Count = value; RaisePropertyChanged("Count"); }
        }

        /// <summary>
        /// Gets or sets the Numerical Count of the cells.
        /// </summary>
        /// <value>The Numerical Count.</value>
        public int NumCount
        {
            get { return _NumCount; }
            set { _NumCount = value; RaisePropertyChanged("NumCount"); }
        }

        /// <summary>
        /// Gets or sets the Minimum value of the cells.
        /// </summary>
        /// <value>The Minimum Value.</value>
        public double Min
        {
            get { return _Min; }
            set { _Min = value; RaisePropertyChanged("Min"); }
        }

        /// <summary>
        /// Gets or sets the Maximum value of the cells.
        /// </summary>
        /// <value>The Maximum Value.</value>
        public double Max
        {
            get { return _Max; }
            set { _Max = value; RaisePropertyChanged("Max"); }
        }

        /// <summary>
        /// Gets or sets the Sum of the cells.
        /// </summary>
        /// <value>The Sum.</value>
        public double Sum
        {
            get { return _Sum; }
            set { _Sum = value; RaisePropertyChanged("Sum"); }
        }

        /// <summary>
        /// Gets or sets the product list.
        /// </summary>
        /// <value>The product list.</value>
        public ObservableCollection<ProductInfoModel> ProductList
        {
            get { return productList; }
            set { productList = value; RaisePropertyChanged("ProductList"); }
        }

        #endregion

        /// <summary>
        /// Populates the data.
        /// </summary>
        private void PopulateData()
        {
            Northwind north = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));
            foreach (OrderDetails orderDet in north.OrderDetails.Take(70))
            {
                ProductInfoModel productInfo = new ProductInfoModel();
                productInfo.ProductName = orderDet.Products.ProductName;
                productInfo.Year2008 = GetRandomNumbers(500.00, 1000.00);
                productInfo.Year2009 = GetRandomNumbers(300.00, 500.00);
                productInfo.Year2010 = GetRandomNumbers(200.00, 1000.00);
                productInfo.Year2011 = GetRandomNumbers(800.00, 1000.00);
                productInfo.Year2012 = GetRandomNumbers(100.00, 2000.00);
                productInfo.Year2013 = GetRandomNumbers(400.00, 2300.00);
                productInfo.TotalSales = productInfo.Year2008 + productInfo.Year2009 + productInfo.Year2010 + productInfo.Year2011 + productInfo.Year2012 + productInfo.Year2013;
                this.productList.Add(productInfo);
            }
        }

        private double GetRandomNumbers(double min, double max)
        {
            Random r = new Random();
            return Math.Round(r.NextDouble(),2) * (max - min);
        }

    }
}
