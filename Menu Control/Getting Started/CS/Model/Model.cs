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
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;

namespace MenuAdvConfigurationDemo
{
    public class Model : NotificationObject
    {
        public ObservableCollection<Model> MenuItems
        {
            get;
            set;
        }

        public string MenuName { get; set; }

        public Model()
        {
            this.MenuItems = new ObservableCollection<Model>();
           
        }

       

        private string menuItemName;
        private Image imagePath;
        private string gestureText;
        public string MenuItemName
        {
            get
            {
                return menuItemName;
                
            }
            set
            {
                menuItemName = value;
                RaisePropertyChanged("MenuItemName");
            }
        }

        public Image ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
                RaisePropertyChanged("ImagePath");
            }
        }

        public string GestureText
        {
            get
            {
                return gestureText;
            }
            set
            {
                gestureText = value;
                RaisePropertyChanged("GestureText");
            }
        }

        private ICommand EventLogCommand;

        public ICommand MenuItemClicked
        {
            get
            {
                return EventLogCommand;
            }
            set
            {
                EventLogCommand = value;
            }
        }

        private bool isCheckable;
        public bool IsCheckable 
        { 
            get
            {
                return isCheckable;
            }
            set
            {
                isCheckable = value;
                RaisePropertyChanged("IsCheckable");
            }
        }
      

        private CheckIconType checkIconType;
        public CheckIconType CheckIconType 
        {
            get
            {
                return checkIconType;
            }
            set
            {
                checkIconType = value;
                RaisePropertyChanged("CheckIconType");

            }
        }       
    }
   
}
