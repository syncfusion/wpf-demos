#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace ConditionalFormatting.ViewModel
{
    using Model;
    using Syncfusion.Windows.Shared;

    public class ViewModel : NotificationObject
    {
        private object prodctSalesData;

        public object ProductSalesData
        {
            get
            {
                prodctSalesData = prodctSalesData ?? ProductSales.GetSalesData();
                return prodctSalesData;
            }
            set
            {
                prodctSalesData = value;
                RaisePropertyChanged("ProductSalesData");
            }
        }
    }
}