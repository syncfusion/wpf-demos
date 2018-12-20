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
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;
using System.IO;
using System.Windows.Input;
using Syncfusion.Windows.Chart;
using System.Windows;
using System.Windows.Media;

namespace InteractiveCursorDemo
{
    public class DataViewModel : ObservableCollection<InteractiveDataModel>
    {
        public List<InteractiveDataModel> datalist { get; set; }
        public DataViewModel()
        {
            datalist = new List<InteractiveDataModel>();
            datalist = this.GetPricesFromCSVFile("..\\..\\Data\\GOOG.csv");
        }

        public List<InteractiveDataModel> GetPricesFromCSVFile(string fileName)
        {
            char[] comma = new char[] { ',' };
            char[] slashN = new char[] { '\n' };
            List<InteractiveDataModel> list = new List<InteractiveDataModel>();
            string s = File.ReadAllText(fileName);
            string[] lines = s.Split(slashN);
            bool firstLine = true;
            string[] values;
            int count = lines.Count() - 2;
            InteractiveDataModel climateInfo;
            int index = 0;
            foreach (string line in lines)
            {
                if (index == 750)
                {
                }
                if (count != -1 && index >= 250)
                    break;
                if (!firstLine)
                {
                    values = line.Split(comma);
                    if (values.GetLength(0) > 5)
                    {
                        climateInfo = new InteractiveDataModel()
                        {
                            TimeStamp = DateTime.Parse(values[0], CultureInfo.InvariantCulture),
                            RainFall = double.Parse(values[2]),

                        };
                        list.Insert(index, climateInfo);
                        index++;
                    }
                }
                else
                {
                    firstLine = false;
                }
            }
            return list;
        }


        public Array VisibilityCollection
        {
            get { return Enum.GetValues(typeof(Visibility)); }
        }


        public ObservableCollection<object> CursorCollection
        {
            get { return EnumHelper.GetValues(typeof(Cursors)); }
        }
    }

    public static class EnumHelper
    {

        public static ObservableCollection<object> GetValues(Type enumtype)
        {
            var itemSourceValues = new ObservableCollection<object>();
            var properties = enumtype.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            foreach (var property in properties)
                itemSourceValues.Add(property.GetValue(enumtype, null));
            return itemSourceValues;
        }

    }

    public class ValueConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (value is InteractiveCursorLabelContent)
                {
                    InteractiveCursorLabelContent v1 = (InteractiveCursorLabelContent)value;
                    if(v1.DataPoint!=null)
                    {
                        DateTime ab = DateTime.FromOADate(v1.DataPoint.X);

                        return String.Format("{0:dd/MM/yyyy}", ab);           //(v1.ToString("#0.00"));
                    }
                    else 
                    return v1;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }

    public class YValueConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (value is InteractiveCursorLabelContent)
                {

                    InteractiveCursorLabelContent v1 = (InteractiveCursorLabelContent)value;
                    if (v1.DataPoint != null)
                    {
                        double ab = (double)v1.DataPoint.Y;
                        string mystring = ab.ToString().Substring(0, 3);
                        return mystring;
                    }
                    //else
                    //{
                    //    return v1.Y.ToString().Substring(0, 5);
                    //}
                   
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }

    public class InterConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double myvalue = (double)value;
            return Math.Round(myvalue, 3);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }

    public class ColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Brush)
                return value;
            else
                return new SolidColorBrush((Color) value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Brush)
                return value;
            else
                return new SolidColorBrush((Color)value);
        }
    }
}
