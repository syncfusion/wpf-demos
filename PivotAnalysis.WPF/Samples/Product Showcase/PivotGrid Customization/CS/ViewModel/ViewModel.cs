#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace PivotGridCustomization.ViewModel
{
    using System;
    using System.Collections.Generic;
    using Model;
    using System.Windows.Media;
    using System.Reflection;

    public class ViewModel
    {
        private object productSalesData;

        public object ProductSalesData
        {
            get
            {
                this.productSalesData = this.productSalesData ?? ProductSales.GetSalesData();
                return this.productSalesData;
            }
            set { this.productSalesData = value; }
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