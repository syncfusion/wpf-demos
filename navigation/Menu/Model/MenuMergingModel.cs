#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Class represents the command model.
    /// </summary>
    public class MenuMergingModel : NotificationObject
    {
        /// <summary>
        /// Maintains the name of the menu item.
        /// </summary>
        private string name;

        /// <summary>
        /// Maintains the icon of the menu item.
        /// </summary>
        private object icon;

        /// <summary>
        /// Maintains the value indicating whether the menu item is checked.
        /// </summary>
        private bool isChecked;

        /// <summary>
        /// Maintains the value indicating whether the menu item is checkable.
        /// </summary>
        private bool isCheckable;

        /// <summary>
        /// Maintains the collection of <see cref="MenuMergingModel"/> class.
        /// </summary>
        private ObservableCollection<MenuMergingModel> commands;

        /// <summary>
        /// Maintains the command for menu items.
        /// </summary>
        private ICommand command;

        /// <summary>
        /// Holds the ImageTemplate for the ButtonAdv in <see cref="MenuMergingModel"/> class.
        /// </summary>
        private DataTemplate imageTemplate;

        /// <summary>
        /// Gets or sets the ImageTemplate for the ButtonAdv in <see cref="MenuMergingModel"/> class.
        /// </summary>
        public DataTemplate ImageTemplate
        {
            get { return  imageTemplate; }
            set {  imageTemplate = value; RaisePropertyChanged("ImageTemplate"); }
        }

        /// <summary>
        /// Initializes the instance of <see cref="MenuMergingModel"/> class.
        /// </summary>
        public MenuMergingModel()
        {
            MenuMergingCollection = new ObservableCollection<MenuMergingModel>();
        }

        /// <summary>
        /// Gets or sets the name of the menu item <see cref="MenuMergingModel"/> class.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the icon of the menu item <see cref="MenuMergingModel"/> class.
        /// </summary>
        public object Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                RaisePropertyChanged("Icon");
            }
        }

        /// <summary>
        /// Gets or sets the collection of <see cref="MenuMergingModel"/> class.
        /// </summary>
        public ObservableCollection<MenuMergingModel> MenuMergingCollection
        {
            get
            {
                return commands;
            }
            set
            {
                commands = value;
                RaisePropertyChanged("MenuMergingCollection");
            }
        }

        /// <summary>
        /// Gets or sets the command for menu item <see cref="MenuMergingModel"/> class.
        /// </summary>
        public ICommand Command
        {
            get
            {
                return command;
            }
            set
            {
                command = value;
            }
        }

        /// <summary>
        /// Indicates whether the menu item is checkable <see cref="MenuMergingModel"/> class.
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
        /// Indicates whether the menu item is checked <see cref="MenuMergingModel"/> class.
        /// </summary>
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    RaisePropertyChanged("IsChecked");
                }
            }
        }
    }
}
