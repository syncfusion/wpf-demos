#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class CustomToolTipViewModel : IDisposable
    {
        public ObservableCollection<CustomToolTipModel> LabourForceData { get; set; }
        public CustomToolTipViewModel()
        {
            this.LabourForceData = new ObservableCollection<CustomToolTipModel>();

            LabourForceData.Add(new CustomToolTipModel() { Year = "2004", Germany = 42.63, Mexico = 34.73 });
            LabourForceData.Add(new CustomToolTipModel() { Year = "2005", Germany = 43.32, Mexico = 43.4 });
            LabourForceData.Add(new CustomToolTipModel() { Year = "2006", Germany = 43.66, Mexico = 38.09 });
            LabourForceData.Add(new CustomToolTipModel() { Year = "2007", Germany = 43.54, Mexico = 44.71 });
            LabourForceData.Add(new CustomToolTipModel() { Year = "2008", Germany = 43.60, Mexico = 45.32 });
            LabourForceData.Add(new CustomToolTipModel() { Year = "2009", Germany = 43.50, Mexico = 46.20 });
            LabourForceData.Add(new CustomToolTipModel() { Year = "2010", Germany = 43.35, Mexico = 46.99 });
            LabourForceData.Add(new CustomToolTipModel() { Year = "2011", Germany = 43.62, Mexico = 49.17 });
            LabourForceData.Add(new CustomToolTipModel() { Year = "2012", Germany = 43.93, Mexico = 50.64 });
        }

        public void Dispose()
        {
            if (LabourForceData != null)
                LabourForceData.Clear();
        }
    }
}
