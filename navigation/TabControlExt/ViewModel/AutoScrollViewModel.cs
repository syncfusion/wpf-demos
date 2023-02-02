#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Syncfusion.Windows.Shared;

namespace syncfusion.navigationdemos.wpf
{
    public class AutoScrollViewModel : NotificationObject
    {
        private bool allowDragDrop = true;

        /// <summary>
        /// Gets or sets a value indicating whether to allow drag and drop operation in TabControlExt .
        /// </summary>

        public bool AllowDragDrop
        {
            get
            {
                return allowDragDrop;
            }

            set
            {
                allowDragDrop = value;
                this.RaisePropertyChanged("AllowDragDrop");
            }
        }

        private bool enableAutoScroll = true;

        /// <summary>
        /// Gets or sets a value indicating whether to enable AutoScroll while performing drag drop opeartion in TabControlExt.
        /// </summary>
        public bool EnableAutoScroll
        {
            get
            {
                return enableAutoScroll;
            }
            set
            {
                enableAutoScroll = value;
                this.RaisePropertyChanged("EnableAutoScroll");
            }
        }

        public ICommand NewButtonCommand { get; set; }

        public AutoScrollViewModel()
        {
            NewButtonCommand = new DelegateCommand(Execute);
        }

        public void Execute(object parameter)
        {
            if(parameter != null && parameter is TabControlExt)
            {
                TabItemExt tabItemExt1 = new TabItemExt()
                {
                    Header = "TabItem" + ((parameter as TabControlExt).Items.Count + 1),
                    Content = new TextBlock() { Text = "This is the content of TabItem" + ((parameter as TabControl).Items.Count + 1) }
                };

                (parameter as TabControlExt).Items.Add(tabItemExt1);
            }
        }
    }
}
