#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Class represents the command model
    /// </summary>
    public class CommandModel : NotificationObject
    {
        /// <summary>
        /// Maintains the checkable
        /// </summary>
        private bool isChecked;

        /// <summary>
        /// Initializes the new instance of <see cref="CommandModel"/> class.
        /// </summary>
        public CommandModel()
        {
            Commands = new ObservableCollection<CommandModel>();
        }

        /// <summary>
        /// Gets or sets the name 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the commands
        /// </summary>
        public ObservableCollection<CommandModel> Commands { get; set; }

        /// <summary>
        /// Gets or sets the delegate command
        /// </summary>
        public DelegateCommand<object> Command { get; set; }

        /// <summary>
        /// Indicsted whether is checkable or not
        /// </summary>
        public bool IsCheckable { get; set; }

        /// <summary>
        /// Indicsted whether is checked or not
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
