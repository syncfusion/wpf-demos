#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;

namespace syncfusion.navigationdemos.wpf
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
        /// Maintains the value for old price.
        /// </summary>
        private double oldPrice;

        /// <summary>
        /// Maintains the value for new price.
        /// </summary>
        private double newPrice;

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
        /// Gets or sets the old price.
        /// </summary>
        public double OldPrice
        {
            get
            {
                return oldPrice;
            }
            set
            {
                oldPrice = value;
                RaisePropertyChanged("OldPrice");
            }
        }

        /// <summary>
        /// Gets or sets the new price
        /// </summary>
        public double NewPrice
        {
            get
            {
                return newPrice;
            }
            set
            {
                newPrice = value;
                RaisePropertyChanged("NewPrice");
            }
        }
    } 
}
