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
using System.Windows.Data;
using System.Reflection;
using System.Windows;

namespace AdornmentConfiguration
{
    public class SeriesConfigViewModel
    {
        public SeriesConfigViewModel()
        {
            this.Crashes = new ObservableCollection<Crashes>();
            DateTime yr = new DateTime(1984, 5, 1);
            Crashes.Add(new Crashes() { year = yr.AddYears(0), count = 15 });
            Crashes.Add(new Crashes() { year = yr.AddYears(1), count = 13 });
            Crashes.Add(new Crashes() { year = yr.AddYears(2), count = 9 });
            Crashes.Add(new Crashes() { year = yr.AddYears(3), count = 12 });
            Crashes.Add(new Crashes() { year = yr.AddYears(4), count = 16 });
            Crashes.Add(new Crashes() { year = yr.AddYears(5), count = 7 });
            Crashes.Add(new Crashes() { year = yr.AddYears(6), count = 3 });
            Crashes.Add(new Crashes() { year = yr.AddYears(7), count = 5 });
            Crashes.Add(new Crashes() { year = yr.AddYears(8), count = 3 });
            Crashes.Add(new Crashes() { year = yr.AddYears(9), count = 2 });
           
        }

        public ObservableCollection<Crashes> Crashes
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
        public ObservableCollection<object> FontWeightsCollection
        {
            get
            {
                return EnumHelper.GetValues(typeof(FontWeights));
            }
        }
        public Array LabelContentCollection
        {
            get { return Enum.GetValues(typeof(LabelContent)); }
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
