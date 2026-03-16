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
    /// <summary>Provides sample data for the column chart demo.</summary>
    public class ViewModelColumn : ObservableCollection<DataValuesColumn>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelColumn"/> class.
        /// </summary>
        public ViewModelColumn()
        {
            Add(new DataValuesColumn("State 1", "2009", 100, 18));
            Add(new DataValuesColumn("State 2", "2010", 100, 23));
            Add(new DataValuesColumn("State 3", "2011", 100, 26));
            Add(new DataValuesColumn("State 4", "2013", 100, 24));
        }
    }
}
