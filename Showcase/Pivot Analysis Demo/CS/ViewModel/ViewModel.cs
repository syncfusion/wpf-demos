using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PivotGridDemo.Model;

namespace PivotGridDemo.ViewModel
{
    public class ViewModel
    {
        private object _productSalesData;

        public object ProductSalesData
        {
            get
            {
                _productSalesData = _productSalesData ?? ProductSales.GetSalesData();
                return _productSalesData;
            }
            set { _productSalesData = value; }
        }

    }
}
