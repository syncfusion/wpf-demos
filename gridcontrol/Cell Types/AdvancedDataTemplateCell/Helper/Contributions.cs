using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace syncfusion.gridcontroldemos.wpf
{
    public class Contributions
    {
        public Contributions() { }
        public Contributions(string name, double value) { ExchangeName = name; Value = value; }
        public string ExchangeName { get; set; }
        public double Value { get; set; }
    }
}
