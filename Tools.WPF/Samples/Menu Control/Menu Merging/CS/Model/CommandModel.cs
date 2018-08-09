using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace MenuMerging
{
    public class CommandModel : NotificationObject
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public ObservableCollection<CommandModel> Commands { get; set; }

        public DelegateCommand<object> Command { get; set; }

        public bool IsCheckable { get; set; }

        private bool isChecked;

        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    RaisePropertyChanged("IsChecked");
                }
            }
        }


        public CommandModel()
        {
            Commands = new ObservableCollection<CommandModel>();
        }

    }
}
