using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;

namespace TaskBarDemo
{
    public class ViewModel : NotificationObject
    {
        private ICommand EventLogCommand;
      
        private ObservableCollection<string> eventlog = new ObservableCollection<string>();

        public ObservableCollection<string> EventLog
        {
            get { return eventlog; }
            set { eventlog = value; }
        }
        public ICommand  SelectionChanged
        {
            get
            {
                return EventLogCommand;
            }
        }
      

        private object selectedValue;
        public object SelectedValue 
        { 
            get
            {
                return selectedValue;
            }
            set
            {
                selectedValue = value;
                RaisePropertyChanged("SelectedValue");

            }
        }


        public void PropertyChangedHandler(object param)
        {
            if (SelectedValue != null)
            {
                EventLog.Add("Selection Changed : "+(SelectedValue as TaskBarItem).Name  );
            }
        }

      

        public ViewModel()
        {
            EventLogCommand = new DelegateCommand<object>(PropertyChangedHandler);           
        }
    }
}
