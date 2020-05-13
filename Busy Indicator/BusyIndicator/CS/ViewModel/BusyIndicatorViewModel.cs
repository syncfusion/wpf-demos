#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Notification;
using System.Collections.ObjectModel;

namespace SfBusyIndicator
{
    public class BusyIndicatorViewModel
    {
        public BusyIndicatorViewModel()
        {
            BusyIndicatorItems = new ObservableCollection<BusyIndicatorModel>();
            foreach (var item in Enum.GetValues(typeof(AnimationTypes)).Cast<AnimationTypes>())
            {
                if(item != AnimationTypes.Globe && item != AnimationTypes.Print && item != AnimationTypes.Rectangle && item != AnimationTypes.Flight && item != AnimationTypes.Snow && item != AnimationTypes.Sunny)
                BusyIndicatorItems.Add(new BusyIndicatorModel() { Animation = item });
            }
        }

        public ObservableCollection<BusyIndicatorModel> BusyIndicatorItems { get; set; }

    }
}
