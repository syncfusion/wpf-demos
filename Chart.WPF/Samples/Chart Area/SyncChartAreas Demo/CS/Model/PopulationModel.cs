#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultipleAreasWithSingleXAxis
{
    public class Population
    {
        public DateTime Year { get; set; }

        public int IncreaseInPopulation { get; set; }

        public double LiteracyGrowth { get; set; }

        public int AbovePovertyLine { get; set; }

        public int BelowPovertyLine { get; set; }

        public double BirthRate { get; set; }
    }
}
