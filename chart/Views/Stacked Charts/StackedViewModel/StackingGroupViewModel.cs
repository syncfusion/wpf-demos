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
    /// <summary>Provides grouped stacking data across quarters.</summary>
    public class StackingGroupViewModel : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StackingGroupViewModel"/> class.
        /// </summary>
        public StackingGroupViewModel()
        {
            this.AnnualDetails = new ObservableCollection<StackingGroupModel>();
            AnnualDetails.Add(new StackingGroupModel() { Year = "2009", Quarter1 = 34, Quarter2 = 31, Quarter3 = 29, Quarter4 = 30 });
            AnnualDetails.Add(new StackingGroupModel() { Year = "2010", Quarter1 = 24, Quarter2 = 28, Quarter3 = 32, Quarter4 = 33 });
            AnnualDetails.Add(new StackingGroupModel() { Year = "2011", Quarter1 = 20, Quarter2 = 25, Quarter3 = 25, Quarter4 = 26 });
            AnnualDetails.Add(new StackingGroupModel() { Year = "2012", Quarter1 = 19, Quarter2 = 21, Quarter3 = 23, Quarter4 = 26 });
            AnnualDetails.Add(new StackingGroupModel() { Year = "2013", Quarter1 = 19, Quarter2 = 15, Quarter3 = 17, Quarter4 = 21 });
        }

        /// <summary>Gets or sets the annual quarterly values.</summary>
        public ObservableCollection<StackingGroupModel> AnnualDetails { get; set; }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
           if(AnnualDetails != null)
                AnnualDetails.Clear();
        }
    } 
}
