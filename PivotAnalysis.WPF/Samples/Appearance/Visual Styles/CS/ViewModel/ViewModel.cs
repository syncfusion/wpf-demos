#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace VisualStyles.ViewModel
{
    using System.Collections.Generic;
    using VisualStyles.Model;
    public class ViewModel : Syncfusion.Windows.Shared.NotificationObject
    {
        private object productSalesData;

        /// <summary>
        /// Gets or sets the product sales data.
        /// </summary>
        /// <value>The product sales data.</value>
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

        /// <summary>
        /// Gets the theme list.
        /// </summary>
        /// <value>The theme list.</value>
        public IEnumerable<string> ThemeList
        {
            get
            {
                return new List<string>() { "Blend", "Metro", "Office2010Black", "Office2010Blue", "Office2010Silver", "Office2013LightGray", "Office2013DarkGray", "Office2013White", "VisualStudio2013", "Office365", "Office2016White", "Office2016DarkGray", "Office2016Colorful", "VisualStudio2015", "SystemTheme" };
            }
        }
    }
}