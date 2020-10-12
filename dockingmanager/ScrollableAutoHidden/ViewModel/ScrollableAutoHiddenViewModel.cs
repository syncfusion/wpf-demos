#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class ScrollableAutoHiddenViewModel : NotificationObject
    {
        private ScrollingButtonMode scrollButtonMode = ScrollingButtonMode.Normal;

        public ScrollingButtonMode ScrollButtonMode
        {
            get 
            { 
                return this.scrollButtonMode; 
            }
            set
            {
                this.scrollButtonMode = value;
                this.RaisePropertyChanged(nameof(ScrollButtonMode));
            }
        }

        private ICommand btnmode;

        public ICommand ScrollMode
        {
            get { return this.btnmode; }
            set { this.btnmode = value; }
        }

        private ICommand animationModeCmd;

        public ICommand AnimationModeChange
        {
            get { return this.animationModeCmd; }
            set { this.animationModeCmd = value; }
        }

        private ICommand tabsModeChange;

        public ICommand TabsModeChange
        {
            get { return tabsModeChange; }
            set { tabsModeChange = value; }
        }


        private bool showPin = true;

        public bool ShowPin
        {
            get
            {
                return this.showPin;
            }
            set
            {
                this.showPin = value;
                this.RaisePropertyChanged(nameof(this.ShowPin));
            }
        }

        private AutoHideAnimationMode animationMode = AutoHideAnimationMode.Slide;

        public AutoHideAnimationMode AnimationMode
        {
            get
            { 
                return animationMode; 
            }
            set
            {
                animationMode = value;
                this.RaisePropertyChanged(nameof(this.AnimationMode));
            }
        }

        private AutoHideTabsMode tabsMode;

        public AutoHideTabsMode AutoHideTabsMode
        {
            get { return tabsMode; }
            set { tabsMode = value; this.RaisePropertyChanged(nameof(this.AutoHideTabsMode)); }
        }

        public ScrollableAutoHiddenViewModel()
        {
            this.ScrollMode = new DelegateCommand<object>(MenuCommandExecuted);
            this.AnimationModeChange = new DelegateCommand<object>(MenuCommandExecuted);
            this.TabsModeChange = new DelegateCommand<object>(MenuCommandExecuted);
        }

        private void MenuCommandExecuted(object obj)
        {
            if (obj != null)
            {
                switch (obj.ToString())
                {
                    case "Normal":
                    case "Extended":
                        this.ScrollButtonMode = (ScrollingButtonMode)Enum.Parse(typeof(ScrollingButtonMode), obj.ToString());
                        break;
                    case "Slide":
                    case "Scale":
                    case "Fade":
                        this.AnimationMode = (AutoHideAnimationMode)Enum.Parse(typeof(AutoHideAnimationMode), obj.ToString());
                        break;
                    case "AutoHideGroup":
                    case "AutoHideActive":
                        this.AutoHideTabsMode = (AutoHideTabsMode)Enum.Parse(typeof(AutoHideTabsMode), obj.ToString());
                        break;
                }
            }
        }
    }
}
