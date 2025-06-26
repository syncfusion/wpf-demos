#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.Windows.Tools.Controls;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class TDIViewModel : NotificationObject
    {
        private bool closeTabOnMiddleClick = true;
        private bool isNewButtonEnabled = true;
        private bool showCloseMenuItem = true;
        private bool showCloseAllMenuItem = false;
        private bool showCloseAllButThisMenuItem = false;
        private bool isTDIDragDropEnabled = true;
        private bool isVS2010DraggingEnabled = false;
        private SwitchMode switchMode = SwitchMode.Immediate;
        private CloseButtonType documentCloseButtonType = CloseButtonType.Common;

        public SwitchMode SwitchMode
        {
            get { return switchMode; }
            set
            {
                switchMode = value;
                this.RaisePropertyChanged(nameof(this.SwitchMode));
            }
        }
        
        public CloseButtonType DocumentCloseButtonType
        {
            get { return documentCloseButtonType; }
            set
            {
                documentCloseButtonType = value;
                this.RaisePropertyChanged(nameof(this.DocumentCloseButtonType));
            }
        }

        public bool CloseTabOnMiddleClick
        {
            get { return closeTabOnMiddleClick; }
            set
            {
                closeTabOnMiddleClick = value;
                this.RaisePropertyChanged(nameof(this.CloseTabOnMiddleClick));
            }
        }

        public bool ShowCloseMenuItem
        {
            get { return showCloseMenuItem; }
            set
            {
                showCloseMenuItem = value;
                this.RaisePropertyChanged(nameof(this.ShowCloseMenuItem));
            }
        }

        public bool IsTDIDragDropEnabled
        {
            get { return isTDIDragDropEnabled; }
            set
            {
                isTDIDragDropEnabled = value;
                this.RaisePropertyChanged(nameof(this.IsTDIDragDropEnabled));
            }
        }

        public bool IsVS2010DraggingEnabled
        {
            get { return isVS2010DraggingEnabled; }
            set
            {
                isVS2010DraggingEnabled = value;
                this.RaisePropertyChanged(nameof(this.IsVS2010DraggingEnabled));
            }
        }

        public bool ShowCloseAllMenuItem
        {
            get { return showCloseAllMenuItem; }
            set
            {
                showCloseAllMenuItem = value;
                this.RaisePropertyChanged(nameof(this.ShowCloseAllMenuItem));
            }
        }

        public bool ShowCloseAllButThisMenuItem
        {
            get { return showCloseAllButThisMenuItem; }
            set
            {
                showCloseAllButThisMenuItem = value;
                this.RaisePropertyChanged(nameof(this.ShowCloseAllButThisMenuItem));
            }
        }

        public bool IsNewButtonEnabled
        {
            get { return isNewButtonEnabled; }
            set
            {
                isNewButtonEnabled = value;
                this.RaisePropertyChanged(nameof(this.IsNewButtonEnabled));
            }
        }
        public ICommand ShowCloseContextMenuCommand { get; set; }

        public TDIViewModel()
        {
            ShowCloseContextMenuCommand = new DelegateCommand<object>(ShowCloseContextMenuChanged);
        }

        private void ShowCloseContextMenuChanged(object obj)
        {
            object[] parameters = obj as object[];
            if (parameters != null)
            {
                if (parameters[1] is DockingManager)
                {
                    for (int i = 0; i < (parameters[1] as DockingManager).Children.Count; i++)
                    {
                        string state = DockingManager.GetState((parameters[1] as DockingManager).Children[i]).ToString();

                        if (parameters[0].ToString() == "True" && state == "Document")
                        {
                            DockingManager.SetShowCloseAllButThisMenuItem((parameters[1] as DockingManager).Children[i], true);
                            DockingManager.SetShowCloseAllMenuItem((parameters[1] as DockingManager).Children[i], true);
                            DockingManager.SetShowCloseMenuItem((parameters[1] as DockingManager).Children[i], true);
                        }
                        else if(parameters[0].ToString() == "False" && state == "Document")
                        {
                            DockingManager.SetShowCloseAllButThisMenuItem((parameters[1] as DockingManager).Children[i], false);
                            DockingManager.SetShowCloseAllMenuItem((parameters[1] as DockingManager).Children[i], false);
                            DockingManager.SetShowCloseMenuItem((parameters[1] as DockingManager).Children[i], false);
                        }
                    }
                }
            }
        }
    }
}
