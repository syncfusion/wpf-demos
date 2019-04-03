#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows;

namespace DataBindingDemo
{
    public class NewsLoadedAction : TargetedTriggerAction<UserControl>
    {

        protected override void Invoke(object parameter)
        {           
        }

        public string TimeNow
        {
            get { return (string)GetValue(TimeNowProperty); }
            set { SetValue(TimeNowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TimeNow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeNowProperty =
            DependencyProperty.Register("TimeNow", typeof(string), typeof(TileLoadedAction), new UIPropertyMetadata(DateTime.Now.ToString()));

        
    }
}
