#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace MenuMerging
{
    public class Model : NotificationObject
    {
        /// <summary>
        /// Maintains the name of the menu item.
        /// </summary>
        private string name;

        /// <summary>
        /// Maintains the icon of the menu item.
        /// </summary>
        private string icon;

        /// <summary>
        /// Maintains the value indicating whether the menu item is checked.
        /// </summary>
        private bool isChecked;

        /// <summary>
        /// Maintains the value indicating whether the menu item is checkable.
        /// </summary>
        private bool isCheckable;

        /// <summary>
        /// Maintains the collection of <see cref="Model"/> class.
        /// </summary>
        private ObservableCollection<Model> commands;

        /// <summary>
        /// Maintains the command for menu items.
        /// </summary>
        private ICommand command;

        /// <summary>
        /// Initializes the instance of <see cref="Model"/> class.
        /// </summary>
        public Model()
        {
            MenuMergingCollection = new ObservableCollection<Model>();
        }

        /// <summary>
        /// Gets or sets the name of the menu item <see cref="Model"/> class.
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
        /// Gets or sets the icon of the menu item <see cref="Model"/> class.
        /// </summary>
        public string Icon
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
        /// Gets or sets the collection of <see cref="Model"/> class.
        /// </summary>
        public ObservableCollection<Model> MenuMergingCollection
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
        /// Gets or sets the command for menu item <see cref="Model"/> class.
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
        /// Indicates whether the menu item is checkable <see cref="Model"/> class.
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
        /// Indicates whether the menu item is checked <see cref="Model"/> class.
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
