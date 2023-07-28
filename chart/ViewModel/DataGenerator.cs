#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class DataGenerator : NotificationObject
    {
        public int DataCount = 500;
        private Random randomNumber;
        private string  timeTaken;
               
        public string TimeTaken
        {
            get 
            {
                return timeTaken; 
            }

            set
            { 
                timeTaken = value;
                RaisePropertyChanged(nameof(this.TimeTaken));
            }
        }

        public bool IsRunning { get; set; }

        public DateTime StartTime { get; set; }
        
        public DataGenerator()
        {
            randomNumber = new Random();            
        }

        public IList<Data> GenerateData()
        {
            List<Data> datas = new List<Data>();

            DateTime date = new DateTime(2009, 1, 1);
            double value = 1000;

            for (int i = 0; i < this.DataCount; i++)
            {
                datas.Add(new Data(date, value));
                date = date.Add(TimeSpan.FromSeconds(5));

                if (randomNumber.NextDouble() > .5)
                {
                    value += randomNumber.NextDouble();
                }
                else
                {
                    value -= randomNumber.NextDouble();
                }
            }

            return datas;
        }
    }
}
