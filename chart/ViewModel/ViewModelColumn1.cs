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
    public class ViewModelColumn1 : ObservableCollection<DataValuesColumn1>
    {
        public ViewModelColumn1()
        {
            Add(new DataValuesColumn1("Quarter 1", "2009", 100, 18));
            Add(new DataValuesColumn1("Quarter 2", "2010", 100, 23));
            Add(new DataValuesColumn1("Quarter 3", "2011", 100, 26));
            Add(new DataValuesColumn1("Quarter 4", "2012", 100, 24));
        }
    }    
}
