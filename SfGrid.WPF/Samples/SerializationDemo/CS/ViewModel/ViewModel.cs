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
using System.ComponentModel;
using SerializationDemo.Model;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;

namespace SerializationDemo
{
    public class ViewModel
    {
        Northwind northWind;
        public ViewModel()
        {
            ProductInfo = this.GetProductInfo();
        }

        private List<ProductDetails> _productInfo;

        /// <summary>
        /// Gets or sets the product info.
        /// </summary>
        /// <value>The product info.</value>
        public List<ProductDetails> ProductInfo
        {
            get
            {
                return _productInfo;
            }
            set
            {
                _productInfo = value;
               
            }
        }

        /// <summary>
        /// Gets the product info.
        /// </summary>
        /// <returns></returns>
        public List<ProductDetails> GetProductInfo()
        {
            var productInfo = new List<ProductDetails>();
            if (!LayoutControl.IsInDesignMode)
            {
                northWind = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));
                var ords = northWind.Products.Take(500);
                foreach (var em in ords)
                {
                    var product = new ProductDetails();
                    em.SupplierID += 1000;
                    em.ProductID += 10000;

                    product.CategoryID = (int)em.CategoryID;
                    product.Discontinued = em.Discontinued;
                    product.EnglishName = em.EnglishName;
                    product.ProductID = em.ProductID;
                    product.ProductName = em.ProductName;
                    product.QuantityPerUnit = em.QuantityPerUnit;
                    product.ReorderLevel = (short)em.ReorderLevel;
                    product.SupplierID = (int)em.SupplierID;
                    product.UnitPrice = (decimal)em.UnitPrice;
                    product.UnitsInStock = (short)em.UnitsInStock;
                    product.UnitsOnOrder = (short)em.UnitsOnOrder;
                    productInfo.Add(product);
                }
            }
            return productInfo;
        }      
    }  
}
