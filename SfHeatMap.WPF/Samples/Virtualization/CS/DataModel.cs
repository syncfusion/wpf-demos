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
using System.Threading.Tasks;

namespace Virtulization
{
    public class DataModel
    {
        public string Data { get; set; }
        public double value { get; set; }
        public double value1 { get; set; }
        public double value2 { get; set; }
        public double value3 { get; set; }
        public double value4 { get; set; }

        public DataModel(string data, double value, double value1, double value2, double value3, double value4)
        {
            this.Data = data;
            this.value = value;
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
            this.value4 = value4;
        }
    }
}
