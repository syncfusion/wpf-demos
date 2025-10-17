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
