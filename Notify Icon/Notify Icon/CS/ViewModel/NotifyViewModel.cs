#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace NotifyIcon_2008
{
    public class NotifyViewModel : INotifyPropertyChanged
    {
        public NotifyViewModel()
        {
            comboBoxItemsSource = styleName.ToList();
        }

        private List<string> comboBoxItemsSource = new List<string>();

        public List<string> ComboBoxItemsSource
        {
            get
            {
                return comboBoxItemsSource;
            }
            set
            {
                comboBoxItemsSource = value;
                OnPropertyChanged("ComboBoxItemsSource");
            }
        }

        private ObservableCollection<string> eventlog = new ObservableCollection<string>();

        public ObservableCollection<string> EventLog
        {
            get
            {
                return eventlog;
            }
            set
            {
                eventlog = value;
                OnPropertyChanged("EventLog");
            }
        }

        private static string[] styleName = new string[] {
                "Default",
                "Office2016Colorful",
                "Office2016DarkGray",
                "Office2016White",
                "Office365",
                "Office2013DarkGray",
                "Office2013LightGray",
                "Office2013White",
                "Office2010Black",
                "Office2010Blue",
                "Office2010Silver",
                "VisualStudio2015",
                "VisualStudio2013",
                "SystemTheme",
                "Metro",
                "Blend",
                "Lime",
                "Saffron",
        };

        private object selecteditem;

        public object SelectedItem
        {
            get
            {
                return selecteditem;
            }
            set
            {
                selecteditem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

    }
}
