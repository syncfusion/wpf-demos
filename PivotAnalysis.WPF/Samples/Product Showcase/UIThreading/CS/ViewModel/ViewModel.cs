#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace UIThreading.ViewModel
{
    using System.Collections.ObjectModel;
    using Syncfusion.Windows.Shared;

    class ViewModel : NotificationObject
    {
        #region Private Variable
        private ObservableCollection<ProductModel> salesCollection;
        #endregion

        #region Method

        /// <summary>
        /// Initializes the ViewModel class
        /// </summary>
        public ViewModel()
        {
            SalesCollection = Model.ProductSales.GetSalesData();
        }

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or Sets the Sales Collection
        /// </summary>
        public ObservableCollection<ProductModel> SalesCollection
        {
            get { return salesCollection; }
            set
            {
                salesCollection = value;
                RaisePropertyChanged(() => SalesCollection);
            }
        }

        #endregion
    }
}