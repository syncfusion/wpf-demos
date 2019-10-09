#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools;
using System.ComponentModel;

namespace ColorEditDemo_2010
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            isCheckedCommand = new DelegateCommand<object>(PropertyChangedHandler);
        }

        private ICommand colorChangedLogCommand;

        private ICommand isCheckedCommand;

        private ObservableCollection<string> eventlog = new ObservableCollection<string>();

        private ColorSelectionMode visualizationStyle;
        public ColorSelectionMode VisualizationStyle
        {
            get { return visualizationStyle; }
            set
            {
                visualizationStyle = value;
                OnPropertyChanged("visualizationStyle");
            }
        }

        public ObservableCollection<string> EventLog
        {
            get { return eventlog; }
            set { eventlog = value; }
        }
        public ICommand IsCheckedCommand
        {
            get
            {
                return isCheckedCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public void PropertyChangedHandler(object param)
        {
            if (param.ToString() == "RGB")
            {
                VisualizationStyle = ColorSelectionMode.RGB;
            }
            else
            {
                VisualizationStyle = ColorSelectionMode.HSV;
            }
        }
    }
}
