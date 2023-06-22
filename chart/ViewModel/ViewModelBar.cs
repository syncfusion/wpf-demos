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
    public class ViewModelBar : ObservableCollection<DataValuesBar>
    {
        public ViewModelBar()
        {
            Add(new DataValuesBar("Convertible", 150, 350));
            Add(new DataValuesBar("Sedan", 220, 450));
            Add(new DataValuesBar("Hatchback", 100, 550));
            Add(new DataValuesBar("SUV", 240, 400));
            Add(new DataValuesBar("Truck", 180, 14));
        }
    }
}
