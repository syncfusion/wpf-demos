#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class AxisConfigurationModel : NotificationObject
    {
        private string category; private double value;

        public AxisConfigurationModel(string category, double value)
        {
            Category = category; Value = value;
        }

        public string Category
        {
            get
            { 
                return category;
            }
            set
            {
                if (category != value)
                {
                    category = value;
                    RaisePropertyChanged(nameof(this.Category));
                }
            }
        }

        public double Value
        {
            get
            { 
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    RaisePropertyChanged(nameof(this.Value));
                }
            }
        }
    } 
}
