#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Shared;

namespace CheckBoxSelectorColumnDemo
{
    public class SelectionViewModel : NotificationObject
    {
        public SelectionViewModel()
        {
            ProductInfoRespository products = new ProductInfoRespository();
            ProductDetails = products.GetProductDetails(50);
        }
        private List<ProductInfo> _ProductDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public List<ProductInfo> ProductDetails
        {
            get { return _ProductDetails; }
            set { _ProductDetails = value; RaisePropertyChanged("ProductDetails"); }
        }
    }
}
