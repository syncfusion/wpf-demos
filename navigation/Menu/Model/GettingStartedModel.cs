#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents the model class for MenuAdvControl.
    /// </summary>
    public class GettingStartedModel : demoscommon.wpf.NotificationObject
    {
        /// <summary>
        /// Maintains a collection for the menu items.
        /// </summary>
        private ObservableCollection<GettingStartedModel> menuItems;

        /// <summary>
        /// Maintains the value for menu item check icon type.
        /// </summary>
        private CheckIconType checkIconType;

        /// <summary>
        /// Maintains the name of the menu item.
        /// </summary>
        private string menuItemName;

        /// <summary>
        /// Maintains the icon of the menu item.
        /// </summary>
        private object imagePath;

        /// <summary>
        /// Maintains the gesture text of the menu  item.
        /// </summary>
        private string gestureText;

        /// <summary>
        /// Maintains the command for menu item click.
        /// </summary>
        private ICommand menuItemCommand;

        /// <summary>
        /// Maintains a value indicating the menu item is whether checkable.
        /// </summary>
        private bool isCheckable;

        /// <summary>
        /// Initializes the instance of the <see cref="GettingStartedModel"/>class.
        /// </summary>
        public GettingStartedModel()
        {
            MenuItems = new ObservableCollection<GettingStartedModel>();
        }

        /// <summary>
        /// Gets or sets the collection for menu items <see cref="GettingStartedModel"/>class.
        /// </summary>
        public ObservableCollection<GettingStartedModel> MenuItems
        {
            get
            {
                return menuItems;
            }
            set
            {
                menuItems = value;
                RaisePropertyChanged("MenuItems");
            }
        }

        /// <summary>
        /// Gets or sets the name of the menu item <see cref="GettingStartedModel"/>class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the icon of the menu item <see cref="GettingStartedModel"/>class.
        /// </summary>
        public object ImagePath
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

        /// <summary>
        /// Gets or sets the value gesture text <see cref="GettingStartedModel"/>class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the command for menu item click <see cref="GettingStartedModel"/>class.
        /// </summary>
        public ICommand MenuItemClicked
        {
            get
            {
                return menuItemCommand;
            }
            set
            {
                menuItemCommand = value;
            }
        }

        /// <summary>
        /// Indicates whether the menu item is checkable <see cref="GettingStartedModel"/>class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the value for menu item check icon type <see cref="GettingStartedModel"/>class.
        /// </summary>
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
