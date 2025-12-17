using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.heatmapdemos.wpf
{
    public class ProductInfo
    {
        public string ProductName { get; set; }
        public int Year { get; set; }
        public double Value { get; set; }

        public ProductInfo(string productname, int year, double value)
        {
            this.ProductName = productname;
            this.Year = year;
            this.Value = value;
        }
    }

}

