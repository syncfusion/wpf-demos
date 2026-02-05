#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class AreaSeriesChart3DViewModel : IDisposable
    {
        public ObservableCollection<AreaSeriesChart3DModel> AreaData { get; set; }

        public AreaSeriesChart3DViewModel()
        {
            this.AreaData = new ObservableCollection<AreaSeriesChart3DModel>();
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2000", Others = 0.87, Sandwiches = 0.72, Burger = 0.48, Pizza = 0.33 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2001", Others = 0.91, Sandwiches = 0.64, Burger = 0.43, Pizza = 0.27 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2002", Others = 1.01, Sandwiches = 0.71, Burger = 0.47, Pizza = 0.17 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2003", Others = 0.95, Sandwiches = 0.63, Burger = 0.41, Pizza = 0.30 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2004", Others = 0.89, Sandwiches = 0.65, Burger = 0.43, Pizza = 0.23 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2005", Others = 1.09, Sandwiches = 0.76, Burger = 0.54, Pizza = 0.36 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2006", Others = 1.14, Sandwiches = 0.89, Burger = 0.66, Pizza = 0.43 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2007", Others = 1.44, Sandwiches = 1.18, Burger = 0.83, Pizza = 0.52 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2008", Others = 1.66, Sandwiches = 1.34, Burger = 1.09, Pizza = 0.72 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2009", Others = 1.91, Sandwiches = 1.59, Burger = 1.37, Pizza = 1.09 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2010", Others = 2.14, Sandwiches = 1.82, Burger = 1.62, Pizza = 1.38 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2011", Others = 2.73, Sandwiches = 2.35, Burger = 2.13, Pizza = 1.82 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2012", Others = 3.126, Sandwiches = 2.69, Burger = 2.44, Pizza = 2.16 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2013", Others = 3.34, Sandwiches = 3.01, Burger = 2.77, Pizza = 2.51 });
            AreaData.Add(new AreaSeriesChart3DModel() { Year = "2014", Others = 3.58, Sandwiches = 3.22, Burger = 2.91, Pizza = 2.61 });
        }

        public void Dispose()
        {
           if(AreaData != null)
                AreaData.Clear();
        }
    }
}
