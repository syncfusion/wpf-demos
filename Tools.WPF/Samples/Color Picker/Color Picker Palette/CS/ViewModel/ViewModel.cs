using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace ColorPickerPaletteDemo_2008
{
    public class ViewModel : NotificationObject
    {
        public ViewModel()
        {
            colorChangedLogCommand = new DelegateCommand<object>(PropertyChangedHandler);
        }

        private ICommand colorChangedLogCommand;

        private ObservableCollection<string> eventlog = new ObservableCollection<string>();

        public ObservableCollection<string> EventLog
        {
            get { return eventlog; }
            set { eventlog = value; }
        }
        public ICommand ColorChanged
        {
            get
            {
                return colorChangedLogCommand;
            }
        }
        public void PropertyChangedHandler(object param)
        {
            EventLog.Add("Color Changed:" + param.ToString());
        }

    }
}
