#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace FlatPerformanceCheck
{
    public class Product : NotificationObject
    {
        #region Private members

        private int _productId;
        private string _productName;
        private DateTime _manufacturSartDate;
        private DateTime _manufacturEndDate;
        private TimeSpan _manufacturDuration;
        private double _progress;

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Product()
        {
        }

        /// <summary>
        /// Gets or sets the manufacturing end.
        /// </summary>
        /// <value>
        /// The manufacturing end.
        /// </value>
        public DateTime ManufacturingEnd
        {
            get 
            { 
                return _manufacturEndDate; 
            }
            set
            {
                _manufacturEndDate = value;
                RaisePropertyChanged("ManufacturingEnd");
            }
        }

        /// <summary>
        /// Gets or sets the manufacturing start.
        /// </summary>
        /// <value>
        /// The manufacturing start.
        /// </value>
        public DateTime ManufacturingStart
        {
            get 
            { 
                return _manufacturSartDate;
            }
            set
            {
                _manufacturSartDate = value;
                RaisePropertyChanged("ManufacturingStart");
            }
        }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
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
        /// Gets or sets the product id.
        /// </summary>
        /// <value>
        /// The product id.
        /// </value>
        public int ProductId
        {
            get
            { 
                return _productId;
            }
            set
            {
                _productId = value;
                RaisePropertyChanged("ProductId");
            }
        }

        /// <summary>
        /// Gets or sets the progress.
        /// </summary>
        /// <value>
        /// The progress.
        /// </value>
        public double Progress
        {
            get
            { 
                return Math.Round(_progress, 2); 
            }
            set
            {
                _progress = value;
                RaisePropertyChanged("Progress");
            }
        }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        public TimeSpan Duration
        {
            get
            {
                _manufacturDuration = _manufacturEndDate.Subtract(_manufacturSartDate);
                return _manufacturDuration;
            }
            set
            {
                // Since we implemented Full Time Schedule support duration can be calculated as Direct.
                ManufacturingEnd = _manufacturEndDate.AddDays(Double.Parse((_manufacturDuration.TotalDays).ToString()));
            }
        }
    }
}
