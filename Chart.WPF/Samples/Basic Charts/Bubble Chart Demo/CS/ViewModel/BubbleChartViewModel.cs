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
using Syncfusion.Windows.Chart;

namespace BubbleChart
{
    public class BubbleChartViewModel
    {
        public BubbleChartViewModel()
        {
            this.Products = new ObservableCollection<CompanyTurnOver>();

            Products.Add(new CompanyTurnOver() { ProdId = 1, Prodname = "Rice", Price = 20, Stock = 53 });
            Products.Add(new CompanyTurnOver() { ProdId = 2, Prodname = "Wheat", Price = 22, Stock = 76 });
            Products.Add(new CompanyTurnOver() { ProdId = 3, Prodname = "Oil", Price = 30, Stock = 80 });
            Products.Add(new CompanyTurnOver() { ProdId = 4, Prodname = "Corn", Price = 26, Stock = 50 });
            Products.Add(new CompanyTurnOver() { ProdId = 5, Prodname = "Gram", Price = 36, Stock = 68 });
            Products.Add(new CompanyTurnOver() { ProdId = 6, Prodname = "Milk", Price = 20, Stock = 90 });
            Products.Add(new CompanyTurnOver() { ProdId = 7, Prodname = "Butter", Price = 40, Stock = 73 });
        }

        public ObservableCollection<CompanyTurnOver> Products { get; set; }
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
