#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DataBinding
{
    public class Event : INotifyPropertyChanged
    {

        private string mappedSubject;
        private DateTime mappedStartTime;
        private DateTime mappedEndTime;
        private string recurrenceRule;
        private bool isRecursive;
        private Brush appointmentBackground;
        private string resourceName;
        private string typeName;
        private string displayName;
        private ObservableCollection<object> resCollection;

        public Brush Color
        {
            get { return appointmentBackground; }
            set
            {
                appointmentBackground = value;
                OnPropertyChanged("Color");
            }
        }

        public string EventName
        {
            get
            {
                return mappedSubject;
            }
            set
            {
                mappedSubject = value;
                OnPropertyChanged("EventName");
            }
        }

        public DateTime From
        {
            get { return mappedStartTime; }
            set
            {
                mappedStartTime = value;
                OnPropertyChanged("From");
            }
        }
        
        public DateTime To
        {
            get
            { return mappedEndTime; }
            set
            {
                mappedEndTime = value;
                OnPropertyChanged("To");
            }
        }

        public string RecurrenceRule
        {
            get
            {
                return recurrenceRule;
            }
            set
            {
                recurrenceRule = value;
                OnPropertyChanged("RecurrenceRule");
            }
        }

        public bool IsRecursive
        {
            get { return isRecursive; }
            set
            {
                isRecursive = value;
                OnPropertyChanged("IsRecursive");
            }
        }

        public string ResourceName
        {
            get
            { return resourceName; }
            set
            {
                resourceName = value;
                OnPropertyChanged("ResourceName");
            }
        }
        public string TypeName
        {
            get { return typeName; }
            set
            {
                typeName = value;
                OnPropertyChanged("TypeName");
            }
        }
        public string DisplayName
        {
            get
            { return displayName; }
            set
            {
                displayName = value;
                OnPropertyChanged("DisplayName");
            }
        }

        public ObservableCollection<object> ResourceCollection
        {
            get
            {
                if (resCollection == null)
                    resCollection = new ObservableCollection<object>();
                return resCollection;
            }
            set
            {
                resCollection = value;
                OnPropertyChanged("ResourceCollection");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
