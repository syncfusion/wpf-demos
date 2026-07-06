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
    /// <summary>Represents a categorical data item with a numeric value for axis configuration.</summary>
    public class AxisConfigurationModel : NotificationObject
    {
        private string category; private double value;

        /// <summary>Initializes a new instance of the <see cref="AxisConfigurationModel"/> class with the specified category and value.</summary>
        public AxisConfigurationModel(string category, double value)
        {
            Category = category; Value = value;
        }

        /// <summary>Gets or sets the category label.</summary>
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

        /// <summary>Gets or sets the numeric value for the category.</summary>
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
