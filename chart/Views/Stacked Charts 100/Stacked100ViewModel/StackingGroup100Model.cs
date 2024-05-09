#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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

namespace syncfusion.chartdemos.wpf
{
    public class StackedGroup100Model
    {

        public string Year { get; set; }

        public double FossilFuels { get; set; }

        public double Nuclear { get; set; }

        public double Renewables { get; set; }

        public StackedGroup100Model(string year,double fossilfuels, double nuclear, double renewables)
        {
            Year = year;
            FossilFuels = fossilfuels;
            Nuclear = nuclear;
            Renewables = renewables;

        }

    }
}
