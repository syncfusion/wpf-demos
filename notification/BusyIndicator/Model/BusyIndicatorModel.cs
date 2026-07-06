#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Notification;

namespace syncfusion.notificationdemos.wpf
{
    public class BusyIndicatorModel
    {
        private AnimationTypes animation;

        public AnimationTypes Animation
        {
            get { return animation; }
            set { animation = value; }
        }

        public double ProductId { get; set; }

        public string ProductName { get; set; }

        public double Price2000 { get; set; }

        public double Price2010 { get; set; }
    }
}
