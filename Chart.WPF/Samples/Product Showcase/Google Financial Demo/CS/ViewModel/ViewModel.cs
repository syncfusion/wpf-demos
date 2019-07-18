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
using System.Globalization;
using System.IO;
using System.ComponentModel;

namespace GoogleFinanceDemo
{
    public class ViewModel
    {
        ViewModelData _googleData = new ViewModelData();
        public ViewModelData GoogleData
        {
            get
            {
                return _googleData;
            }
            set
            {
                _googleData = value;
                OnPropertyChanged("GoogleData");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(object Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Property.ToString()));
            }
        }

        public ViewModel()
        {
            _googleData = this.GetPricesFromCSVFile(@"..//..//Data//GOOG.csv");
        }
        public ViewModelData GetPricesFromCSVFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                char[] comma = new char[] { ',' };
                char[] slashN = new char[] { '\n' };
                ViewModelData list = new ViewModelData();

                string s = File.ReadAllText(fileName);
                string[] lines = s.Split(slashN);
                bool firstLine = true;
                string[] values;
                int count = lines.Count() - 2;
                GoogleData priceInfo;
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
                            priceInfo = new GoogleData()
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
            else
            {
                return null;
            }
        }
    }
    public class ViewModelData : System.Collections.ObjectModel.ObservableCollection<GoogleData>
    {
        public ViewModelData()
        {

        }
    }
}
