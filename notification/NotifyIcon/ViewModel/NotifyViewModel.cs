#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace syncfusion.notificationdemos.wpf
{
    public class NotifyViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the event log collection
        /// </summary>
        private ObservableCollection<string> eventlog = new ObservableCollection<string>();

        /// <summary>
        /// Maintains the command for NotifyIcon opening.
        /// </summary>
        private ICommand notifyIconOpening;

        /// <summary>
        /// Maintains the command for NotifyIcon hiding.
        /// </summary>
        private ICommand notifyIconHiding;

        /// <summary>
        /// Maintains the command for NotifyIcon closed.
        /// </summary>
        private ICommand notifyIconClosed;

        /// <summary>
        /// Maintains the command for NotifyIcon size change.
        /// </summary>
        private ICommand notifyIconSizeChanged;

        /// <summary>
        /// Maintains the command to display NotifyIcon.
        /// </summary>
        private ICommand showNotifyIcon;

        /// <summary>
        /// Maintains the value to update the button enabled state.
        /// </summary>
        private bool isButtonEnabled;

        /// <summary>
        /// Initializes the new instance of <see cref="NotifyViewModel"/> class.
        /// </summary>
        public NotifyViewModel()
        {
            notifyIconOpening = new demoscommon.wpf.DelegateCommand<object>(ExecuteNotifyIconOpening);
            notifyIconHiding = new demoscommon.wpf.DelegateCommand<object>(ExecuteNotifyIconHiding);
            notifyIconClosed = new demoscommon.wpf.DelegateCommand<object>(ExecuteNotifyIconClosed);
            notifyIconSizeChanged = new demoscommon.wpf.DelegateCommand<object>(ExecuteNotifyIconSizeChanged);
            showNotifyIcon = new demoscommon.wpf.DelegateCommand<object>(ExecuteShowNotifyIcon);
            IsButtonEnabled = true;
        }

        /// <summary>
        /// Gets or sets the event log <see cref="NotifyViewModel"/> class.
        /// </summary>
        public ObservableCollection<string> EventLog
        {
            get
            {
                return eventlog;
            }
            set
            {
                eventlog = value;
                RaisePropertyChanged("EventLog");
            }
        }

        /// <summary>
        /// Gets or sets the eventlog when NotifyIcon is opening <see cref="NotifyViewModel"/> class.
        /// </summary>
        public ICommand NotifyIconOpening
        {
            get
            {
                return notifyIconOpening;
            }
        }

        /// <summary>
        /// Gets or sets the eventlog when NotifyIcon is hiding <see cref="NotifyViewModel"/> class.
        /// </summary>
        public ICommand NotifyIconHiding
        {
            get
            {
                return notifyIconHiding;
            }
        }

        /// <summary>
        /// Gets or sets the eventlog when NotifyIcon is closed <see cref="NotifyViewModel"/> class.
        /// </summary>
        public ICommand NotifyIconClosed
        {
            get
            {
                return notifyIconClosed;
            }
        }

        /// <summary>
        /// Gets or sets the eventlog when NotifyIcon size changes <see cref="NotifyViewModel"/> class.
        /// </summary>
        public ICommand NotifyIconSizeChanged
        {
            get
            {
                return notifyIconSizeChanged;
            }
        }

        /// <summary>
        /// Gets or sets the command to show NotifyIcon <see cref="NotifyViewModel"/> class.
        /// </summary>
        public ICommand ShowNotifyIcon
        {
            get
            {
                return showNotifyIcon;
            }
        }

        /// <summary>
        /// Gets or sets the value to update the enabled state of show notify icon button <see cref="NotifyViewModel"/> class.
        /// </summary>
        public bool IsButtonEnabled
        {
            get
            {
                return isButtonEnabled;
            }
            set
            {
                isButtonEnabled = value;
                RaisePropertyChanged("IsButtonEnabled");
            }
        }

        /// <summary>
        /// Method used to display NotifyIcon.
        /// </summary>
        /// <param name="param">Specifies the object parameter.</param>
        public void ExecuteShowNotifyIcon(object param)
        {
            (param as NotifyIcon).ShowBalloonTip(50000);
            IsButtonEnabled = false;
        }

        /// <summary>
        /// Method used to add NotifyIcon opening event log.
        /// </summary>
        /// <param name="param">Specifies the object parameter.</param>
        public void ExecuteNotifyIconOpening(object param)
        {
            EventLog.Add("NotifyIcon opening event is fired");
            IsButtonEnabled = false;
        }

        /// <summary>
        /// Method used to add NotifyIcon hiding event log.
        /// </summary>
        /// <param name="param">Specifies the object parameter.</param>
        public void ExecuteNotifyIconHiding(object param)
        {
            EventLog.Add("NotifyIcon hiding event is fired");
            IsButtonEnabled = true;
        }

        /// <summary>
        /// Method used to add NotifyIcon closed event log.
        /// </summary>
        /// <param name="param">Specifies the object parameter.</param>
        public void ExecuteNotifyIconClosed(object param)
        {
            EventLog.Add("NotifyIcon close button event is fired");
            IsButtonEnabled = true;
        }

        /// <summary>
        /// Method used to add NotifyIcon size change event log.
        /// </summary>
        /// <param name="param">Specifies the object parameter.</param>
        public void ExecuteNotifyIconSizeChanged(object param)
        {
            EventLog.Add("NotifyIcon size changed event is fired");
        }
    }
}
