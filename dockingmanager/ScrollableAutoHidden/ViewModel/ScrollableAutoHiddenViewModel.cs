#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Controls;

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
        
        private bool enableScrollableSidePanel = true;

        public bool EnableScrollableSidePanel
        {
            get
            {
                return this.enableScrollableSidePanel;
            }
            set
            {
                this.enableScrollableSidePanel = value;
                this.RaisePropertyChanged(nameof(this.EnableScrollableSidePanel));
            }
        }
        
        private bool isAnimationEnabledOnMouseOver = true;

        public bool IsAnimationEnabledOnMouseOver
        {
            get
            {
                return this.isAnimationEnabledOnMouseOver;
            }
            set
            {
                this.isAnimationEnabledOnMouseOver = value;
                this.RaisePropertyChanged(nameof(this.IsAnimationEnabledOnMouseOver));
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

        public ScrollableAutoHiddenViewModel()
        {
        }
    }
}
