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
using System.Collections.ObjectModel;
using Syncfusion.Windows.Chart;

namespace StackingBarChart
{
    public class StackingBarChartViewModel
    {
        public StackingBarChartViewModel()
        {
            this.GoldInventoryDetails = new ObservableCollection<GoldInventory>();
            GoldInventoryDetails.Add(new GoldInventory() { YEAR = 2005, Inferred = 1100, Measured = 750, Reserves = 900 });
            GoldInventoryDetails.Add(new GoldInventory() { YEAR = 2006, Inferred = 1200, Measured = 500, Reserves = 1000 });
            GoldInventoryDetails.Add(new GoldInventory() { YEAR = 2007, Inferred = 900, Measured = 700, Reserves = 1200 });
            GoldInventoryDetails.Add(new GoldInventory() { YEAR = 2008, Inferred = 950, Measured = 1000, Reserves = 900 });
            GoldInventoryDetails.Add(new GoldInventory() { YEAR = 2009, Inferred = 900, Measured = 1100, Reserves = 1000 });
            GoldInventoryDetails.Add(new GoldInventory() { YEAR = 2010, Inferred = 900, Measured = 1200, Reserves = 1000 });
            GoldInventoryDetails.Add(new GoldInventory() { YEAR = 2011, Inferred = 1000, Measured = 1100, Reserves = 1050 });
        }
        public ObservableCollection<GoldInventory> GoldInventoryDetails
        {
            get;
            set;
        }
        public Array PaletteCollection
        {
            get
            {
                return new ChartColorPalette[] { ChartColorPalette.Nature, 
                                          ChartColorPalette.Metro, 
                                          ChartColorPalette.Default, 
                                          ChartColorPalette.DefaultDark,
                                          ChartColorPalette.MixedFantasy
                                        };
            }
        }
    }

}
