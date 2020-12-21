#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Notification;
using System.Windows;

namespace syncfusion.notificationdemos.wpf
{
    public class GettingStartedViewModel : NotificationObject
    {
        private HorizontalAlignment horizontalAlignment= HorizontalAlignment.Right;
        private VerticalAlignment verticalAlignment= VerticalAlignment.Top;
        private int content = 20;
        private double controlSize = 100;
        private BadgeAnimationType animationType = BadgeAnimationType.None;
        private BadgeShape shape = BadgeShape.Ellipse;
        private BadgeFill fill = BadgeFill.Accent;
        private Visibility visibility = Visibility.Visible;
        private BadgeAnchor horizontalAnchor= BadgeAnchor.Center;
        private BadgeAnchor verticalAnchor=BadgeAnchor.Center;
        private double horizontalPosition= 0.9;
        private double verticalPosition= 0.8;
        private double horizontalAnchorPosition= 0.8;
        private double verticalAnchorPosition= 0.3;
        private int customContent = 20;

        public BadgeAnimationType BadgeAnimationType
        {
            get
            {
                return animationType;
            }
            set
            {
                animationType = value;
                this.RaisePropertyChanged(nameof(this.BadgeAnimationType));
            }
        }

        public BadgeAnchor HorizontalAnchor
        {
            get
            {
                return horizontalAnchor;
            }
            set
            {
                horizontalAnchor = value;
                this.RaisePropertyChanged(nameof(this.HorizontalAnchor));
            }
        }
        public BadgeAnchor VerticalAnchor
        {
            get
            {
                return verticalAnchor;
            }
            set
            {
                verticalAnchor = value;
                this.RaisePropertyChanged(nameof(this.VerticalAnchor));
            }
        }      

        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                this.RaisePropertyChanged(nameof(this.Visibility));
            }
        }
        public BadgeFill Fill
        {
            get
            {
                return fill;
            }
            set
            {
                fill = value;
                this.RaisePropertyChanged(nameof(this.Fill));
            }
        }

        public BadgeShape Shape
        {
            get
            {
                return shape;
            }
            set
            {
                shape = value;
                this.RaisePropertyChanged(nameof(this.Shape));
            }
        }

        public int Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                this.RaisePropertyChanged(nameof(this.Content));
            }
        }
        
        public int CustomContent
        {
            get
            {
                return customContent;
            }
            set
            {
                customContent = value;
                this.RaisePropertyChanged(nameof(this.CustomContent));
            }
        } 
        
        public double ControlSize
        {
            get
            {
                return controlSize;
            }
            set
            {
                controlSize = value;
                this.RaisePropertyChanged(nameof(this.ControlSize));
            }
        }

        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                return horizontalAlignment;
            }
            set
            {
                horizontalAlignment = value;
                this.RaisePropertyChanged(nameof(this.HorizontalAlignment));
            }
        }
        public VerticalAlignment VerticalAlignment
        {
            get
            {
                return verticalAlignment;
            }
            set
            {
                verticalAlignment = value;
                this.RaisePropertyChanged(nameof(this.VerticalAlignment));
            }
        }

        public double HorizontalPosition
        {
            get
            {
                return horizontalPosition;
            }
            set
            {
                horizontalPosition= value;
                this.RaisePropertyChanged(nameof(this.HorizontalPosition));
            }
        }

        public double VerticalPosition
        {
            get
            {
                return verticalPosition;
            }
            set
            {
                verticalPosition = value;
                this.RaisePropertyChanged(nameof(this.VerticalPosition));
            }
        }

        public double HorizontalAnchorPosition
        {
            get
            {
                return horizontalAnchorPosition;
            }
            set
            {
                horizontalAnchorPosition = value;
                this.RaisePropertyChanged(nameof(this.HorizontalAnchorPosition));
            }
        }

        public double VerticalAnchorPosition
        {
            get
            {
                return verticalAnchorPosition;
            }
            set
            {
                verticalAnchorPosition = value;
                this.RaisePropertyChanged(nameof(this.VerticalAnchorPosition));
            }
        }
        public GettingStartedViewModel()
        {
        }
    }
}
