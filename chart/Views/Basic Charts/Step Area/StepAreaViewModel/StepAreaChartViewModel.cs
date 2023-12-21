#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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

namespace syncfusion.chartdemos.wpf
{
    class StepAreaChartViewModel
    {
        public ObservableCollection<StepAreaChartModel> CanadaData { get; set; }
        public ObservableCollection<StepAreaChartModel> MexicoData { get; set; }
        public StepAreaChartViewModel()
        {
            this.CanadaData = new ObservableCollection<StepAreaChartModel>();
            CanadaData.Add(new StepAreaChartModel() { Year = "2005", Value = 21 });
            CanadaData.Add(new StepAreaChartModel() { Year = "2006", Value = 21 });
            CanadaData.Add(new StepAreaChartModel() { Year = "2007", Value = 22 });
            CanadaData.Add(new StepAreaChartModel() { Year = "2008", Value = 29 });
            CanadaData.Add(new StepAreaChartModel() { Year = "2009", Value = 24 });
            CanadaData.Add(new StepAreaChartModel() { Year = "2010", Value = 25 });
            CanadaData.Add(new StepAreaChartModel() { Year = "2011", Value = 27 });
            CanadaData.Add(new StepAreaChartModel() { Year = "2012", Value = 26 });
            CanadaData.Add(new StepAreaChartModel() { Year = "2013", Value = 26 });
            CanadaData.Add(new StepAreaChartModel() { Year = "2014", Value = 29 });
            CanadaData.Add(new StepAreaChartModel() { Year = "2015", Value = 21 });

            this.MexicoData = new ObservableCollection<StepAreaChartModel>();
            MexicoData.Add(new StepAreaChartModel() { Year = "2005", Value = 15 });
            MexicoData.Add(new StepAreaChartModel() { Year = "2006", Value = 15 });
            MexicoData.Add(new StepAreaChartModel() { Year = "2007", Value = 16 });
            MexicoData.Add(new StepAreaChartModel() { Year = "2008", Value = 17 });
            MexicoData.Add(new StepAreaChartModel() { Year = "2009", Value = 13 });
            MexicoData.Add(new StepAreaChartModel() { Year = "2010", Value = 14 });
            MexicoData.Add(new StepAreaChartModel() { Year = "2011", Value = 16 });
            MexicoData.Add(new StepAreaChartModel() { Year = "2012", Value = 14 });
            MexicoData.Add(new StepAreaChartModel() { Year = "2013", Value = 13 });
            MexicoData.Add(new StepAreaChartModel() { Year = "2014", Value = 10 });
            MexicoData.Add(new StepAreaChartModel() { Year = "2015", Value = 6 });
        }
    }
}
