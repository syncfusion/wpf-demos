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
using System.Windows.Data;

namespace PieChart
{
    public class PieChartViewModel
    {
        public PieChartViewModel()
        {
            this.Expenditure = new List<CompanyExpense>();
            Expenditure.Add(new CompanyExpense() { Expense = "Seeds", Amount = 20d });
            Expenditure.Add(new CompanyExpense() { Expense = "Fertilizers ", Amount = 23d });
            Expenditure.Add(new CompanyExpense() { Expense = "Insurance", Amount = 12d });
            Expenditure.Add(new CompanyExpense() { Expense = "Labor", Amount = 25d });
            Expenditure.Add(new CompanyExpense() { Expense = "Warehousing", Amount = 10d });
            Expenditure.Add(new CompanyExpense() { Expense = "Taxes", Amount = 10d });
            Expenditure.Add(new CompanyExpense() { Expense = "Truck", Amount = 10d });

        }

        public IList<CompanyExpense> Expenditure
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
    #region Converter
    public class Labelconvertor : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // This is possible during design time load
            if (!(value is CompanyExpense))
                return String.Empty;

            CompanyExpense info = value as CompanyExpense;

            return String.Format("{0} %",info.Amount);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
 public class TooltipConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return String.Empty;

            ChartSegment seg = value as ChartSegment;
            return seg.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    public class InteriorConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return String.Empty;

            ChartSegment seg = value as ChartSegment;
            return seg.Interior;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

}
