#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.Linq;

namespace VisualStylesDemo
{
    public class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            OrderInfoRepository order = new OrderInfoRepository();
            OrdersDetails = order.GetOrdersDetails(300);
            _comboBoxItemsSource = styleName.ToList();
        }

        public List<OrderInfo> _ordersDetails;
        private List<string> _comboBoxItemsSource;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public List<OrderInfo> OrdersDetails
        {
            get{ return _ordersDetails; }
            set{ _ordersDetails = value;}
        }

        public List<string> ComboBoxItemsSource
        {
            get { return _comboBoxItemsSource; }
            set { _comboBoxItemsSource = value; }
        }

        string[] styleName = new string[]
        {
            "Default",
        "Metro",
        "Blend",
        "Office2010Black",
        "Office2010Blue",
        "Office2010Silver",
        "Office2013DarkGray",
        "Office2013LightGray",
        "Office2013White",
        "VisualStudio2013",
        "Lime",
        "Saffron",
        "Office365",
        "Office2016Colorful",
        "Office2016DarkGray",
        "Office2016White",
        "VisualStudio2015",
        "SystemTheme"
        };
    }
}
