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
using System.Collections.ObjectModel;
using System.Windows;

namespace ZoomingAndScrolling
{
    

    public class SyncChartAreaModel
    {
        public SyncChartAreaModel()
        {
            this.Products = new ObservableCollection<Population>();
            Random rand = new Random(DateTime.Now.Millisecond);
            Products.Add(new Population() { Year = 1998, IncreaseInPopulation = 99, LiteracyGrowth = 20, AbovePovertyLine = 53, BelowPovertyLine = 21, BirthRate = 89 });
            Products.Add(new Population() { Year = 1999, IncreaseInPopulation = 34, LiteracyGrowth = 22, AbovePovertyLine = 76 , BelowPovertyLine = 49, BirthRate = 64});
            Products.Add(new Population() { Year = 2000, IncreaseInPopulation = 45, LiteracyGrowth = 30, AbovePovertyLine = 80, BelowPovertyLine= 12 , BirthRate = 77});
            Products.Add(new Population() { Year = 2001, IncreaseInPopulation = 88, LiteracyGrowth = 26, AbovePovertyLine = 50 , BelowPovertyLine=33, BirthRate = 90});
            Products.Add(new Population() { Year = 2002, IncreaseInPopulation = 21, LiteracyGrowth = 36, AbovePovertyLine = 68 , BelowPovertyLine = 39, BirthRate = 61});
            Products.Add(new Population() { Year = 2003, IncreaseInPopulation = 78, LiteracyGrowth = 20, AbovePovertyLine = 90 , BelowPovertyLine=15, BirthRate = 81});
            Products.Add(new Population() { Year = 2004, IncreaseInPopulation = 65, LiteracyGrowth = 40, AbovePovertyLine = 73, BelowPovertyLine= 9, BirthRate = 78 });
        }

        public ObservableCollection<Population> Products { get; set; }

        public Array VisibilityCollection
        {
            get { return Enum.GetValues(typeof(Visibility)); }
        }

    }
}
