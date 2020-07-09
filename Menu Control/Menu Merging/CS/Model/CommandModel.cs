#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.Windows.Shared;

namespace MenuMerging
{

    /// <summary>
    /// Class represents the chart model.
    /// </summary>
    public class ChartModel : NotificationObject
    {
        /// <summary>
        /// MAintains the value for product id
        /// </summary>
        private double productId;

        /// <summary>
        /// Maintians  the value for product name
        /// </summary>
        private string productName;

        /// <summary>
        /// Maintains the value for Price 2000
        /// </summary>
        private double price2000;

        /// <summary>
        /// Maintains the value for Price 2010
        /// </summary>
        private double price2010;

        /// <summary>
        /// Gets or sets the product ID
        /// </summary>
        public double ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
                RaisePropertyChanged("ProductId");
            }
        }

        /// <summary>
        /// Gets or sets the product name
        /// </summary>
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
                RaisePropertyChanged("ProductName");
            }
        }

        /// <summary>
        /// Gets or sets the price 2000
        /// </summary>
        public double Price2000
        {
            get
            {
                return price2000;
            }
            set
            {
                price2000 = value;
                RaisePropertyChanged("Price2000");
            }
        }

        /// <summary>
        /// Gets or sets the price2010
        /// </summary>
        public double Price2010
        {
            get
            {
                return price2010;
            }
            set
            {
                price2010 = value;
                RaisePropertyChanged("Price2010");
            }
        }
    }
}
