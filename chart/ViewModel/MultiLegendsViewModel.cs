#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace syncfusion.chartdemos.wpf
{
    public class MultiLegendsViewModel : ObservableCollection<MultiLegendsModel>
    {
        public MultiLegendsViewModel()
        {
            Random rand = new Random();
            DateTime dt = DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                this.Add(new MultiLegendsModel { Rate = rand.Next(110, 240), Speed = i + 1 });
                dt = dt.AddMinutes(i);
            }
        }
    }
}