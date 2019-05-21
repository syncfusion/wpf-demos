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
using System.Windows.Controls;
using System.Reflection;
using Syncfusion.Windows.Chart;

namespace ChartAreaConfiguration_2010
{
    public class AreaViewModel
    {
        public AreaViewModel()
        {
            this.Sales = new ObservableCollection<StockAnalysisModel>();

            this.Sales.Add(new StockAnalysisModel() { ProductName = "Jeans", SalesOthers = 33, SalesUS = 56 });
            this.Sales.Add(new StockAnalysisModel() { ProductName = "Shirts", SalesOthers = 46, SalesUS = 97 });
            this.Sales.Add(new StockAnalysisModel() { ProductName = "T-Shirts", SalesOthers = 70, SalesUS = 88 });
            this.Sales.Add(new StockAnalysisModel() { ProductName = "Trousers", SalesOthers = 57, SalesUS = 65 });
            this.Sales.Add(new StockAnalysisModel() { ProductName = "Jacket", SalesOthers = 68, SalesUS = 90 });
        }

        public ObservableCollection<StockAnalysisModel> Sales { get; set; }

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

        

        public ObservableCollection<object> FontWeightsCollection
        {
            get
            {
                return EnumHelper.GetValues(typeof(FontWeights));
            }
        }

        public ObservableCollection<object> FontFamilyCollection
        {
            get
            {
                return EnumHelper.GetValues(typeof(FontStyles));
            }
        }

        public Array FillDirectionCollection
        {
            get
            {
                return Enum.GetValues(typeof(Orientation));
            }
        }


        public Array AlternateFillCollection
        {
            get
            {
                return Enum.GetValues(typeof(Syncfusion.Windows.Chart.AlternatingFillMode));
            }
        }

        public static class EnumHelper
        {

            public static ObservableCollection<object> GetValues(Type enumtype)
            {
                ObservableCollection<object> ItemSourceValues = new ObservableCollection<object>();

                PropertyInfo[] properties = enumtype.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
                foreach (PropertyInfo property in properties)
                {
                    ItemSourceValues.Add(property.Name);
                }

                return ItemSourceValues;
            }

        }
    }
}
