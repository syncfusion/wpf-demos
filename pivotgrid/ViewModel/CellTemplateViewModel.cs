#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using Syncfusion.Windows.Shared;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Media;

    public class CellTemplateViewModel : NotificationObject
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
                productSalesData = productSalesData ?? CellTemplateModel.GetSalesData();
                return productSalesData;
            }
            set
            {
                productSalesData = value;
                RaisePropertyChanged("ProductSalesData");
            }
        }

        public string[] DisplayOption
        {
            get
            {
                string[] option = { "None", "All", "Summaries", "Calculations", "GrandTotals", "Summaries and Calculations", "Summaries and GrandTotals", "Calculations and GrandTotals" };
                return option;
            }
        }
        public List<string> BrushNames
        {
            get
            {
                List<string> colorList = new List<string>();
                Type brush = typeof(Brushes);
                foreach (MemberInfo info in brush.GetMembers())
                {
                    if (info is PropertyInfo)
                    {
                        PropertyInfo pi = info as PropertyInfo;
                        colorList.Add(pi.Name);
                    }
                }
                return colorList;
            }
        }
        public List<string> GridLayoutList
        {
            get
            {
                return new List<string> { "Normal", "Top Summary", "Excel Like Layout" };
            }
        }
    }
}