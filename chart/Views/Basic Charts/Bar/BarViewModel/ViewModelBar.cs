#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class ViewModelBar : ObservableCollection<DataValuesBar>
    {
        public ViewModelBar()
        {
            Add(new DataValuesBar("Convertible", 150));
            Add(new DataValuesBar("Sedan", 220));
            Add(new DataValuesBar("Hatchback", 100));
            Add(new DataValuesBar("SUV", 240));
            Add(new DataValuesBar("Truck", 180));
        }
    }
}
