#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
using System.Windows;
using Syncfusion.Windows.PropertyGrid;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace syncfusion.propertygriddemos.wpf
{
    public class GettingStartedViewModel : NotificationObject
    {
        private PropertyItem selectedPropertyItem;

        public PropertyItem SelectedPropertyItem
        {
            get { return selectedPropertyItem; }    
            set
            {
                selectedPropertyItem = value;
                this.RaisePropertyChanged(() => this.SelectedPropertyItem);
            }
        }
        
        private ICommand logs;
        public ICommand Logs
        {
            get
            {
                return logs;
            }
            set
            {
                logs = value;
            }
        }

        private ListSortDirection? sortDirection = ListSortDirection.Ascending;
        /// <summary>
        /// Gets or sets a value indicating the sort direction (Ascending/Desceding) of the properties.
        /// </summary>
        public ListSortDirection? SortDirection
        {
            get
            {
                return sortDirection;
            }

            set
            {
                sortDirection = value;
                this.RaisePropertyChanged(() => this.SortDirection);
            }
        }

        /// <summary>
        /// Property which stores PropertyNameColumnDefinition 
        /// </summary>
        private GridLength propertyNameColumnDefinition = new GridLength(250);
        public GridLength PropertyNameColumnDefinition
        {
            get
            {
                return propertyNameColumnDefinition;
            }
            set
            {
                propertyNameColumnDefinition = value;
                this.RaisePropertyChanged(() => this.PropertyNameColumnDefinition);
            }
        }

        private ObservableCollection<string> eventLogsCollection;

        public ObservableCollection<string> EventLogsCollection
        {
            get { return eventLogsCollection; }
            set { eventLogsCollection = value;
            this.RaisePropertyChanged(() => this.EventLogsCollection);
            }
        }                

        public GettingStartedViewModel()
        {
            logs = new DelegateCommand<object>(LogsCollection);
        }

        ObservableCollection<string> coll = new ObservableCollection<string>();

        public void LogsCollection(object param)
        {
            if (SelectedPropertyItem != null)
            {                              
                    coll.Add("SelectedProperty Changed: " + SelectedPropertyItem.Name.ToString());
                    EventLogsCollection = coll;              
            }
        }
    }  
}
