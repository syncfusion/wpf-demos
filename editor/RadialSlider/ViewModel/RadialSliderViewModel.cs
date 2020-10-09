#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.editordemos.wpf
{
    public class RadialSliderViewModel : NotificationObject
    {
        private double clockwiseFulCircleValue;
        private double labelCustomizationValue;
        private double customizedValue;
        private double counterclockwiseValue;
        private double radialSliderCustomizationValue;

        public double ClockwiseFulCircleValue
        {
            get 
            { 
                return clockwiseFulCircleValue; 
            }
            set 
            {
                if (clockwiseFulCircleValue != value)
                {
                    clockwiseFulCircleValue = value;
                    this.RaisePropertyChanged(nameof(this.ClockwiseFulCircleValue));
                }
            }
        }

        public double LabelCustomizationValue
        {
            get
            {
                return labelCustomizationValue;
            }
            set
            {
                if (labelCustomizationValue != value)
                {
                    labelCustomizationValue = value;
                    this.RaisePropertyChanged(nameof(this.LabelCustomizationValue));
                }
            }
        }

        public double CustomizedValue
        {
            get
            {
                return customizedValue;
            }
            set
            {
                if (customizedValue != value)
                {
                    customizedValue = value;
                    this.RaisePropertyChanged(nameof(this.CustomizedValue));
                }
            }
        }

        public double CounterclockwiseValue
        {
            get
            {
                return counterclockwiseValue;
            }
            set
            {
                if (counterclockwiseValue != value)
                {
                    counterclockwiseValue = value;
                    this.RaisePropertyChanged(nameof(this.CounterclockwiseValue));
                }
            }
        }

        public double RadialSliderCustomizationValue
        {
            get
            {
                return radialSliderCustomizationValue;
            }
            set
            {
                if (radialSliderCustomizationValue != value)
                {
                    radialSliderCustomizationValue = value;
                    this.RaisePropertyChanged(nameof(this.RadialSliderCustomizationValue));
                }
            }
        }
    }
}
