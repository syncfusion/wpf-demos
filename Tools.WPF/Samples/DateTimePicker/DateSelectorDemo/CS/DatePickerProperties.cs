using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSelectorDemo
{
    public class DatePickerProperties : NotificationObject
    {
        private String formatString = "d";

        public String Format
        {
            get { return formatString; }
            set { formatString = value; RaisePropertyChanged("Format"); }
        }
    }
    public class NotificationObject : INotifyPropertyChanged
    {
        public void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
