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
using System.Globalization;
using System.Windows;
using System.IO;

namespace AnnotationsSample
{
    public class DataViewModel : ObservableCollection<DataModel>
    {
        public List<DataModel> datalist { get; set; }
        public DataViewModel()
        {
            datalist = new List<DataModel>();
            datalist = this.GetPricesFromCSVFile("..\\..\\Data\\Data.csv");
        }

        public List<DataModel> GetPricesFromCSVFile(string fileName)
        {
            char[] comma = new char[] { ',' };
            char[] slashN = new char[] { '\n' };
            List<DataModel> list = new List<DataModel>();
            string s = File.ReadAllText(fileName);
            string[] lines = s.Split(slashN);
            bool firstLine = true;
            string[] values;
            int count = lines.Count() - 2;
            DataModel climateInfo;
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
                        DateTime ab = Convert.ToDateTime(values[0]);
                        double my = ab.ToOADate();
                        climateInfo = new DataModel()
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

        public Array AnnotationShapesCollection
        {
            get { return Enum.GetValues(typeof(AnnotationShapes)); }
        }



    }

    public class Multi : IMultiValueConverter
    {

        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool array1 = (bool)values[0];
            bool array2 = array1;
            return array2;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            bool array2 = (bool)value;
            object[] obj = new object[4] { array2, array2, array2, array2 };
            return obj;
        }

        #endregion
    }

    public class MulitBind : IMultiValueConverter
    {

        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var array1 = values;
            return array1;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var array2 = value;
            object[] obj = new object[3] { array2, array2, array2};
            return obj;
        }

        #endregion
    }

    public class Templatebind : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
