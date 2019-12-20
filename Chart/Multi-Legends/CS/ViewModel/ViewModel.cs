#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace MultipleLegendsDemo
{
    public class ProductDetails : ObservableCollection<Product>
    {
        public Array LegendPosition
        {
            get { return Enum.GetValues(typeof(LegendPosition)); }
        }

        public Array ChartDock
        {
            get { return Enum.GetValues(typeof(ChartDock)); }
        }

        public Array VerticalAlignment
        {
            get { return Enum.GetValues(typeof(VerticalAlignment)); }
        }

        public Array HorizontalAlignment
        {
            get { return Enum.GetValues(typeof(HorizontalAlignment)); }
        }

        public ProductDetails()
        {
            Random rand = new Random();
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                this.Add(new Product { Rate = rand.Next(110, 240), Speed = i + 1 });
                dt = dt.AddMinutes(i);
            }
        }
    }
   
}
