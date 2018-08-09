using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioManager1.Helpers
{
    public class Performance
    {
        public Performance() { }
        public Performance(DateTime date, double value) { Date = date; AssetValue = value; }
        public DateTime Date { get; set; }
        public double AssetValue { get; set; }
    }
}
