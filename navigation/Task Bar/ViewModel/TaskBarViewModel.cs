#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Tools.Controls;
using syncfusion.demoscommon.wpf;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Class represents the behaviour or business logic for Window1.xaml.
    /// </summary>
    public class TaskBarViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the command for task bar item change.
        /// </summary>
        private ICommand taskBarItemChanged;     

        /// <summary>
        /// Maintains the selected value.
        /// </summary>
        private object taskBarSelectedItem;

        /// <summary>
        /// Maintains the collection of event logs.
        /// </summary>
        private ObservableCollection<string> eventLog = new ObservableCollection<string>();

        /// <summary>
        /// Initializes the new instance of <see cref="TaskBarViewModel"/> class.
        /// </summary>
        public TaskBarViewModel()
        {
            taskBarItemChanged = new demoscommon.wpf.DelegateCommand<object>(ExecuteEventLog);
        }

        /// <summary>
        /// Gets or sets the eventLog <see cref="TaskBarViewModel"/> class.
        /// </summary>
        public ObservableCollection<string> EventLog
        {
            get
            {
                return eventLog;
            }
            set
            {
                eventLog = value;
                RaisePropertyChanged("EventLog");
            }
        }

        /// <summary>
        /// Gets or sets the eventlog when selection changes in task bar <see cref="TaskBarViewModel"/> class.
        /// </summary>
        public ICommand TaskBarItemChanged
        {
            get
            {
                return taskBarItemChanged;
            }
        }
      

        /// <summary>
        /// Gets or sets the selected value <see cref="TaskBarViewModel"/> class.
        /// </summary>
        public object TaskBarSelectedItem 
        { 
            get
            {
                return taskBarSelectedItem;
            }
            set
            {
                taskBarSelectedItem = value;
                RaisePropertyChanged("TaskBarSelectedItem");
            }
        }

        /// <summary>
        /// Method used to add the event logs.
        /// </summary>
        /// <param name="param">Specifies the object parameter.</param>
        public void ExecuteEventLog(object param)
        {
            if (TaskBarSelectedItem != null)
            {
                EventLog.Add("Selection Changed : "+(TaskBarSelectedItem as TaskBarItem).Name  );
            }
        }
    }
}
