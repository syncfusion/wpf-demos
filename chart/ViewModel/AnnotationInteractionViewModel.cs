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
    public class AnnotationInteractionViewModel
    {
        public AnnotationInteractionViewModel()
        {
            this.power = new ObservableCollection<AnnotationInteractionModel>();
            DateTime yr = new DateTime(2002, 5, 1);

            power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(1), Population = 36 });
            power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(2), Population = 32 });
            power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(3), Population = 34 });
            power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(4), Population = 41 });
            power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(5), Population = 44 });
            power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(6), Population = 48 });
            power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(7), Population = 45 });
        }
        public ObservableCollection<AnnotationInteractionModel> power
        {
            get;
            set;
        }
    } 
}
