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
using System.Globalization;
using System.Collections;

namespace ChartAnimations
{
    public class ChartAnimationsViewModel
    {
        public ChartAnimationsViewModel()
        {
            this.Values1 = new List<MonthlyNet>();
            this.Values2 = new List<MonthlyNet>();

            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = 1; i <= 12; i++)
            {
                this.Values1.Add(new MonthlyNet(i, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0, 3), rand.Next(15, 90)));
                this.Values2.Add(new MonthlyNet(i, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i).Substring(0, 3), rand.Next(15, 90)));
            }
        }

        public IList Values1 { get; set; }

        public IList Values2 { get; set; }
    }
}
