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
using System.IO;
using System.Globalization;

namespace TimeLineControlSample
{
    public class TimeLineData
    {
        public DateTime TimeStamp
        {
            get;
            set;
        }
        public double High
        {
            get;
            set;
        }
        public double Low
        {
            get;
            set;
        }
        public double Last
        {
            get;
            set;
        }
        public double Open
        {
            get;
            set;
        }
        public double Volume
        {
            get;
            set;
        }
    }

    public class DataCollection : ObservableCollection<TimeLineData>
    {
        public List<TimeLineData> datalist = new List<TimeLineData>();
        public DataCollection()
        {
            datalist = this.GetPricesFromCSVFile("..\\..\\Data\\GOOG.csv");
        }

        public List<TimeLineData> GetPricesFromCSVFile(string fileName)
        {
            char[] comma = new char[] { ',' };
            char[] slashN = new char[] { '\n' };
            List<TimeLineData> list = new List<TimeLineData>();
            string s = File.ReadAllText(fileName);
            string[] lines = s.Split(slashN);
            bool firstLine = true;
            string[] values;
            int count = lines.Count() - 2;
            TimeLineData priceInfo;
            int index = 0;
            foreach (string line in lines)
            {
                if (index == 750)
                {
                }
                if (count != -1 && index >= 1250)
                    break;
                if (!firstLine)
                {
                    values = line.Split(comma);
                    if (values.GetLength(0) > 5)
                    {
                        priceInfo = new TimeLineData()
                        {
                            TimeStamp = DateTime.Parse(values[0], CultureInfo.InvariantCulture),
                            Open = double.Parse(values[1]),
                            High = double.Parse(values[2]),
                            Low = double.Parse(values[3]),
                            Last = double.Parse(values[4]),
                            Volume = double.Parse(values[5])
                        };
                        list.Insert(index, priceInfo);
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
    }

}
