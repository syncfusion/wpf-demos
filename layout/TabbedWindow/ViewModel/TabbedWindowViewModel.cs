#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Controls.Enum;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Principal;
using System.Windows;
using System.Windows.Input;
using static Syncfusion.Windows.Controls.SfTabControl;

namespace syncfusion.layoutdemos.wpf.ViewModel
{
    public class TabbedWindowViewModel : NotificationObject
    {
        public ObservableCollection<TabItemModel> Tabs { get; } = new ObservableCollection<TabItemModel>();

        public TabbedWindowViewModel()
        {
            Tabs.Add(new TabItemModel("Tab 1", "Content 1"));
            Tabs.Add(new TabItemModel("Tab 2", "Content 2"));
            Tabs.Add(new TabItemModel("Tab 3", "Content 3"));
            Tabs.Add(new TabItemModel("Tab 4", "Content 4"));
            Tabs.Add(new TabItemModel("Tab 5", "Content 5"));

            AddTabCommand = new DelegateCommand(AddTab);

            WindowType = WindowType.Tabbed;
            EnableTitle = false;
            AllowDragDrop = true;
            EnableNewTabButton = true;
        }

        public IReadOnlyList<WindowType> WindowTypeOptions { get; } =
                new[] { WindowType.Normal, WindowType.Tabbed };

        public IReadOnlyList<Visibility> VisibilityOptions { get; } =
                new[] { Visibility.Visible, Visibility.Collapsed, Visibility.Hidden };

        private WindowType windowType;

        public WindowType WindowType
        {
            get { return windowType; }
            set
            {
                if (windowType != value)
                {
                    windowType = value;
                    RaisePropertyChanged(nameof(windowType));
                }
            }
        }

        private bool _enableTitle;
        public bool EnableTitle
        {
            get { return _enableTitle; }
            set
            {
                if (_enableTitle != value)
                {
                    _enableTitle = value;
                    RaisePropertyChanged(nameof(EnableTitle));
                }
            }
        }

        private bool allowDragDrop = true;
        public bool AllowDragDrop
        {
            get { return allowDragDrop; }
            set { allowDragDrop = value; this.RaisePropertyChanged("AllowDragDrop"); }
        }

        private object selectedItem;
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }

            set
            {
                selectedItem = value;
                this.RaisePropertyChanged("SelectedItem");
            }
        }

        private bool enableNewTabButton = true;
        public bool EnableNewTabButton
        {
            get { return enableNewTabButton; }
            set { enableNewTabButton = value; this.RaisePropertyChanged("EnableNewTabButton"); }
        }

        public ICommand AddTabCommand { get; }
        private int _tabCounter = 1;

        private void AddTab(object args)
        {
            if (args is NewTabRequestedEventArgs e)
            {
                e.Item = new TabItemModel(
                    header: $"New Tab {_tabCounter}",
                    content: $"Content for New Tab {_tabCounter}"
                );
                _tabCounter++;
                return;
            }
        }
    }

    public class TabItemModel : NotificationObject
    {
        public string Header { get; set; }
        public string Content { get; set; }

        public string Description { get; set; }

        private Visibility _closeButtonVisibility = Visibility.Visible;
        public Visibility CloseButtonVisibility
        {
            get => _closeButtonVisibility;
            set { if (_closeButtonVisibility != value) { _closeButtonVisibility = value; RaisePropertyChanged(nameof(CloseButtonVisibility)); } }
        }

        public TabItemModel(string header, string content, string description = null)
        {
            Header = header;
            Content = content;
            Description = description ?? string.Empty;
        }
    }
}
