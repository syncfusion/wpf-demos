#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellSelectionDemo
{
    class ProductInfoModel : NotificationObject
    {
        #region Private Members

        private string _productName;
        private double _year2008;
        private double _year2009;
        private double _year2010;
        private double _year2011;
        private double _year2012;
        private double _year2013;
        private double _totalSale;

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the prodcut name.
        /// </summary>
        /// <value>The Product Name.</value>
        public string ProductName 
        { 
            get
            {
                return _productName;
            }
            set 
            {
                _productName = value;
                RaisePropertyChanged("ProductName");
            }
        }

        /// <summary>
        /// Gets or sets the sales amount in 2008.
        /// </summary>
        /// <value>The Sales Amount.</value>
        public double Year2008
        {
            get
            {
                return _year2008;
            }
            set
            {
                _year2008 = value;
                RaisePropertyChanged("Year2008");
            }
        }

        /// <summary>
        /// Gets or sets the sales amount in 2009.
        /// </summary>
        /// <value>The Sales Amount.</value>
        public double Year2009
        {
            get
            {
                return _year2009;
            }
            set
            {
                _year2009 = value;
                RaisePropertyChanged("Year2009");
            }
        }

        /// <summary>
        /// Gets or sets the sales amount in 2010.
        /// </summary>
        /// <value>The Sales Amount.</value>
        public double Year2010
        {
            get
            {
                return _year2010;
            }
            set
            {
                _year2010 = value;
                RaisePropertyChanged("Year2010");
            }
        }

        /// <summary>
        /// Gets or sets the sales amount in 2011.
        /// </summary>
        /// <value>The Sales Amount.</value>
        public double Year2011
        {
            get
            {
                return _year2011;
            }
            set
            {
                _year2011 = value;
                RaisePropertyChanged("Year2011");
            }
        }

        /// <summary>
        /// Gets or sets the sales amount in 2012.
        /// </summary>
        /// <value>The Sales Amount.</value>
        public double Year2012
        {
            get
            {
                return _year2012;
            }
            set
            {
                _year2012 = value;
                RaisePropertyChanged("Year2012");
            }
        }

        /// <summary>
        /// Gets or sets the sales amount in 2013.
        /// </summary>
        /// <value>The Sales Amount.</value>
        public double Year2013
        {
            get
            {
                return _year2013;
            }
            set
            {
                _year2013 = value;
                RaisePropertyChanged("Year2013");
            }
        }

        /// <summary>
        /// Gets or sets the total sales amount.
        /// </summary>
        /// <value>The Total Sales Amount.</value>
        public double TotalSales
        {
            get
            {
                return _totalSale;
            }
            set
            {
                _totalSale = value;
                RaisePropertyChanged("TotalSales");
            }
        }

        #endregion
    }
}
