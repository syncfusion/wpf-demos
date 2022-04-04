#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
using System.Windows;
using Syncfusion.Windows.PropertyGrid;
using Syncfusion.Windows.Shared;

namespace syncfusion.propertygriddemos.wpf
{
    public class ConfigureAtRuntimeViewModel : NotificationObject
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
        
        private bool enableGrouping;

        public bool EnableGrouping
        {
            get { return enableGrouping; }    
            set
            {
                enableGrouping = value;
                this.RaisePropertyChanged(nameof( this.EnableGrouping));
            }
        }
        
        private bool enableToolTip;

        public bool EnableToolTip
        {
            get { return enableToolTip; }    
            set
            {
                enableToolTip = value;
                this.RaisePropertyChanged(nameof( this.EnableToolTip));
            }
        }
        
        private Visibility buttonPanelVisibility= Visibility.Visible;

        public Visibility ButtonPanelVisibility
        {
            get { return buttonPanelVisibility; }    
            set
            {
                buttonPanelVisibility = value;
                this.RaisePropertyChanged(nameof( this.ButtonPanelVisibility));
            }
        } 
        
        private Visibility searchBoxVisibility = Visibility.Visible;

        public Visibility SearchBoxVisibility
        {
            get { return searchBoxVisibility; }    
            set
            {
                searchBoxVisibility = value;
                this.RaisePropertyChanged(nameof( this.SearchBoxVisibility));
            }
        }
        
        private Visibility descriptionPanelVisibility = Visibility.Visible;

        public Visibility DescriptionPanelVisibility
        {
            get { return descriptionPanelVisibility; }    
            set
            {
                descriptionPanelVisibility = value;
                this.RaisePropertyChanged(nameof( this.DescriptionPanelVisibility));
            }
        }
        
        private PropertyExpandModes propertyExpandMode = PropertyExpandModes.NestedMode;

        public PropertyExpandModes PropertyExpandMode
        {
            get { return propertyExpandMode; }    
            set
            {
                propertyExpandMode = value;
                this.RaisePropertyChanged(nameof( this.PropertyExpandMode));
            }
        }

        private ListSortDirection? sortDirection = null;
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

        public ConfigureAtRuntimeViewModel()
        {
            
        }
    }  
}
