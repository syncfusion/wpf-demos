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

namespace PropertyGridAttributeDemo
{
    public class ViewModel : NotificationObject
    { 
        
        #region PropertyGrid Properties
        
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
       
        #endregion
            
        public ViewModel()
        {
           
        }
    }  
}
