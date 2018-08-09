using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Syncfusion.Windows.Shared;

namespace CalendarDemo
{
    class EventViewModel : NotificationObject
    {
        private ICommand dateChangedCommand;
        public ICommand
           DateChangedCommand
        {
            get
            {
                return dateChangedCommand;
            }
            set
            {
                dateChangedCommand = value;
            }
        }
        private DateTime selecteddate= DateTime.Today;
        public DateTime SelectedDate
        {
            get 
            {
                return selecteddate;
            }
            set
            {
                selecteddate = value;
                RaisePropertyChanged("SelectedDate");
            }
        }

        public void DateChanged(object param)
        {
            
                EventLogs.Add("DateTimeChanged:" + SelectedDate.ToString());
        }
        public bool CanChange(object param)
        {
            return true;
        }
       
        private ObservableCollection<string> eventLogs;

        public ObservableCollection<string> EventLogs
        {
            get { return eventLogs; }
            set
            {
                eventLogs = value;
                this.RaisePropertyChanged(() => this.EventLogs);
            }
        }
        public EventViewModel()
        {
            eventLogs = new ObservableCollection<string>();
            DateChangedCommand = new DelegateCommand<object>(DateChanged,CanChange);
        }
    }
}
