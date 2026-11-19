#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.sparklinedemos.wpf
{
    /// <summary>
    /// Represents the GettingStartedViewModel.
    /// </summary>
    public class GettingStartedViewModel
    {
        Random rand = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public GettingStartedViewModel()
        {
            Data = new List<DataModel>();
            Data.Add(new DataModel() { Day = rand.Next(-20, 100), ShareHolders = rand.Next(-20, 100), YearPerformance = (double)rand.Next(-20, 100) });
            Data.Add(new DataModel() { Day = rand.Next(-20, 60), ShareHolders = rand.Next(-20, 60), YearPerformance = (double)rand.Next(-20, 60) });
            Data.Add(new DataModel() { Day = rand.Next(-30, 150), ShareHolders = rand.Next(-30, 150), YearPerformance = (double)rand.Next(-30, 150) });
            Data.Add(new DataModel() { Day = rand.Next(-20, 100), ShareHolders = rand.Next(-20, 100), YearPerformance = (double)rand.Next(-20, 100) });
            Data.Add(new DataModel() { Day = rand.Next(-20, 100), ShareHolders = rand.Next(-20, 100), YearPerformance = (double)rand.Next(-20, 100) });
            Data.Add(new DataModel() { Day = rand.Next(-20, 100), ShareHolders = rand.Next(-20, 100), YearPerformance = (double)rand.Next(-20, 100) });
            Data.Add(new DataModel() { Day = rand.Next(0, 200), ShareHolders = rand.Next(0, 200), YearPerformance = (double)rand.Next(0, 200) });
            Data.Add(new DataModel() { Day = rand.Next(-20, 300), ShareHolders = rand.Next(-20, 300), YearPerformance = (double)rand.Next(-20, 300) });
            Data.Add(new DataModel() { Day = rand.Next(-20, 100), ShareHolders = rand.Next(-20, 100), YearPerformance = (double)rand.Next(-20, 100) });
            Data.Add(new DataModel() { Day = rand.Next(-30, 150), ShareHolders = rand.Next(-30, 150), YearPerformance = (double)rand.Next(-30, 150) });
            Data.Add(new DataModel() { Day = rand.Next(-20, 300), ShareHolders = rand.Next(-20, 300), YearPerformance = (double)rand.Next(-20, 300) });
        }

        /// <summary>
        /// Gets or sets the collection of DataModel.
        /// </summary>
        public List<DataModel> Data
        {
            get;
            set;
        }
    }
}