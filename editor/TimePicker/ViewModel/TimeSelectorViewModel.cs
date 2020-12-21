#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;

namespace syncfusion.editordemos.wpf
{
    public class TimeSelectorViewModel : NotificationObject
    {
        private DateTime? selectedTime = DateTime.Now;

        public DateTime? SelectedTime 
        {
            get
            {
                return selectedTime;
            }
            set
            {
                if (selectedTime != value)
                {
                    selectedTime = value;
                    this.RaisePropertyChanged(nameof(this.SelectedTime));
                }
            }
        }
    }
}
