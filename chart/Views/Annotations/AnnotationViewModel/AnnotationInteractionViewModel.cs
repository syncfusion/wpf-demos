#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class AnnotationInteractionViewModel : IDisposable
    {
        public ObservableCollection<AnnotationInteractionModel> Power { get; set; }
        public AnnotationInteractionViewModel()
        {
            this.Power = new ObservableCollection<AnnotationInteractionModel>();
            DateTime yr = new DateTime(2002, 5, 1);

            Power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(1), Population = 36 });
            Power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(2), Population = 32 });
            Power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(3), Population = 34 });
            Power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(4), Population = 41 });
            Power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(5), Population = 44 });
            Power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(6), Population = 48 });
            Power.Add(new AnnotationInteractionModel() { Year = yr.AddYears(7), Population = 45 });
        }


        public void Dispose()
        {
            if (Power != null)
                Power.Clear();
        }
    } 
}
