#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Syncfusion.Windows.PropertyGrid;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace PropertyGridConfigurationDemo
{
    public class ViewModel : NotificationObject
    { 


        #region PropertyGrid Properties
        /// <summary>
        /// Property which stores SearchBoxVisibility 
        /// </summary>        
        private Visibility searchBoxVisibility = Visibility.Visible;
        public Visibility SearchBoxVisibility
        {
            get
            {
                return searchBoxVisibility;
            }

            set
            {
                searchBoxVisibility = value;
                this.RaisePropertyChanged(() => this.SearchBoxVisibility);
            }
        }

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
        public ICommand
           Logs
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

        /// <summary>
        /// Property which stores DescriptionPanelVisibility 
        /// </summary>
        private Visibility descriptionPanelVisibility = Visibility.Visible;
        public Visibility DescriptionPanelVisibility
        {
            get
            {
                return descriptionPanelVisibility;
            }

            set
            {
                descriptionPanelVisibility = value;
                this.RaisePropertyChanged(() => this.DescriptionPanelVisibility);
            }
        }

        
        private bool enableGrouping;

        /// <summary>
        /// Gets or sets a value indicating whether to allow grouping the properties.
        /// </summary>
      
        public bool EnableGrouping
        {
            get
            {
                return enableGrouping;
            }

            set
            {
                enableGrouping = value;
                this.RaisePropertyChanged(() => this.EnableGrouping);
            }
        }

        private bool enableToolTip=true;
        /// <summary>
        /// Gets or sets a value indicating whether to allow grouping the properties.
        /// </summary>
        public bool EnableToolTip
        {
            get
            {
                return enableToolTip;
            }

            set
            {
                enableToolTip = value;
                this.RaisePropertyChanged(() => this.EnableToolTip);
            }
        }

        private Visibility buttonPanelVisibility = Visibility.Visible;
        /// <summary>
        /// Gets or sets a value indicating the visibility of the PropertyGrid's button panel.
        /// </summary>
        public Visibility ButtonPanelVisibility
        {
            get
            {
                return buttonPanelVisibility;
            }

            set
            {
                buttonPanelVisibility = value;
                this.RaisePropertyChanged(() => this.ButtonPanelVisibility);
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

        private ObservableCollection<string> eventLogsCollection;

        public ObservableCollection<string> EventLogsCollection
        {
            get { return eventLogsCollection; }
            set { eventLogsCollection = value;
            this.RaisePropertyChanged(() => this.EventLogsCollection);
            }
        }                

        #endregion
            
        public ViewModel()
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
