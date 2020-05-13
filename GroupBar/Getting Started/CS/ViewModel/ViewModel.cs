#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.Windows.Tools.Controls;

namespace GroupBarDemo
{
    /// <summary>
    /// Represents a viewmodel for groupbar control. 
    /// </summary>
    public class ViewModel : NotificationObject
    {
        /// <summary>
        ///  Maintains the selected object.
        /// </summary>
        private object selectedObject;

        /// <summary>
        /// Maintains the command for selected object change.
        /// </summary>
        private ICommand command;

        /// <summary>
        ///  Maintains the collection of event logs.
        /// </summary>
        private ObservableCollection<string> eventLogsCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>   
        public ViewModel()
        {
            command = new DelegateCommand<object>(GroupbarSelectedObjectChanged);
        }

        /// <summary>
        /// Gets or sets the properties for selected object changed command <see cref="ViewModel" /> class.
        /// </summary>
        public ICommand Command
        {
            get
            {
                return command;
            }
        }

        /// <summary>
        /// Gets or sets the group bar selected object property <see cref="ViewModel" /> class.
        /// </summary>
        public object GroupBarSelectedObject
        {
            get { return selectedObject; }
            set
            {
                selectedObject = value;
                RaisePropertyChanged("GroupBarSelectedObject");
            }
        }

        /// <summary>
        /// Gets or sets the event log properties <see cref="ViewModel" /> class.
        /// </summary>
        public ObservableCollection<string> EventLogsCollection
        {
            get { return eventLogsCollection; }
            set
            {
                eventLogsCollection = value;
                RaisePropertyChanged("EventLogsCollection");
            }
        }
        ObservableCollection<string> collection = new ObservableCollection<string>();

        /// <summary>
        /// Changes occur when groupbar item changed.
        /// </summary>
        /// <param name="param">Invokes when groupbar item selection changed</param>
        private void GroupbarSelectedObjectChanged(object param)
        {
            if (GroupBarSelectedObject != null)
            {
                if (GroupBarSelectedObject is GroupBarItem)
                    collection.Add("Selected Object changed : " + ((GroupBarItem)GroupBarSelectedObject).HeaderText + " (GroupBarItem)");
                if (GroupBarSelectedObject is GroupViewItem)
                    collection.Add("Selected Object changed : " + ((GroupViewItem)GroupBarSelectedObject).Text + " (GroupViewItem)");
                EventLogsCollection = collection;
            }
        }
    }
}
