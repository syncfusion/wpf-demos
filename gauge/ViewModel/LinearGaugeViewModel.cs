#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Gauges;

namespace syncfusion.gaugedemos.wpf
{
    public class LinearGaugeViewModel : NotificationObject
    {

        private LinearRangesPosition linearRangesPosition;
        private LinearLabelsPosition linearLabelsPosition;
        private LinearTicksPosition linearTicksPosition;
        private LinearPointerType linearPointerType;

        public LinearRangesPosition LinearRangesPosition
        {
            get 
            { 
                return linearRangesPosition; 
            }
            set 
            { 
                linearRangesPosition = value;
                RaisePropertyChanged("LinearRangesPosition");
            }
        }

        public LinearLabelsPosition LinearLabelsPosition
        {
            get 
            {
                return linearLabelsPosition; 
            }
            set 
            { 
                linearLabelsPosition = value;
                RaisePropertyChanged("LinearLabelsPosition");
            }
        }

        public LinearTicksPosition LinearTicksPosition
        {
            get 
            { 
                return linearTicksPosition; 
            }
            set 
            { 
                linearTicksPosition = value;
                RaisePropertyChanged("LinearTicksPosition");
            }
        }

        public LinearPointerType LinearPointerType
        {
            get 
            { 
                return linearPointerType; 
            }
            set 
            { 
                linearPointerType = value;
                RaisePropertyChanged("LinearPointerType");
            }
        }

        public LinearGaugeViewModel()
        {
            LinearRangesPosition = LinearRangesPosition.Above;
            LinearLabelsPosition = LinearLabelsPosition.Above;
            LinearTicksPosition = LinearTicksPosition.Above;
            LinearPointerType = LinearPointerType.BarPointer;
        }
    }
}
