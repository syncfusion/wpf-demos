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
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Globalization;
using System.Windows;
using Syncfusion.Windows.Shared;

namespace CalendarDemo
{
    public class LostFocusAction : TargetedTriggerAction<TextBox>
    {
        protected override void Invoke(object parameter)
        {
            CultureInfo culture = new CultureInfo("ar-SA");
            if (!((CalendarEdit)CalenderEdit).Culture.Equals(culture))
            {
                DateTime mindate;
                DateTime maxdate;
                if (DateTime.TryParse(((TextBox)IntTextMinDate).Text, out mindate))
                    ((CalendarEdit)CalenderEdit).MinDate = Convert.ToDateTime(((TextBox)IntTextMinDate).Text.ToString(), new CultureInfo("en-US"));
                if (DateTime.TryParse(((TextBox)IntTextMaxDate).Text, out maxdate))
                    ((CalendarEdit)CalenderEdit).MaxDate = Convert.ToDateTime(((TextBox)IntTextMaxDate).Text.ToString(), new CultureInfo("en-US"));
            }
        }

        public static readonly DependencyProperty IntTextMinDateProperty = DependencyProperty.Register("IntTextMinDate", typeof(object), typeof(LostFocusAction), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty IntTextMaxDateProperty = DependencyProperty.Register("IntTextMaxDate", typeof(object), typeof(LostFocusAction), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty CalenderEditProperty = DependencyProperty.Register("CalenderEdit", typeof(object), typeof(LostFocusAction), new FrameworkPropertyMetadata(null));

        public object IntTextMinDate
        {
            get
            {
                return (object)GetValue(IntTextMinDateProperty);
            }

            set
            {
                SetValue(IntTextMinDateProperty, value);
            }
        }
        public object IntTextMaxDate
        {
            get
            {
                return (object)GetValue(IntTextMaxDateProperty);
            }

            set
            {
                SetValue(IntTextMaxDateProperty, value);
            }
        }

        public object CalenderEdit
        {
            get
            {
                return (object)GetValue(CalenderEditProperty);
            }

            set
            {
                SetValue(CalenderEditProperty, value);
            }
        }
    }
}
