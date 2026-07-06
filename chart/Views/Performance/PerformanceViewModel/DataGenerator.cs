#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Generates synthetic time-series data and tracks generation timing.</summary>
    public class DataGenerator : NotificationObject
    {
        /// <summary>Gets or sets the number of points to generate.</summary>
        public int DataCount = 500;
        private Random randomNumber;
        private string  timeTaken;

        /// <summary>Gets or sets a formatted duration string for data generation.</summary>
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

        /// <summary>Gets or sets a value indicating whether generation is in progress.</summary>
        public bool IsRunning { get; set; }

        /// <summary>Gets or sets the start time of the generation.</summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGenerator"/> class.
        /// </summary>
        public DataGenerator()
        {
            randomNumber = new Random();            
        }

        /// <summary>Creates and returns a list of generated data points.</summary>
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
