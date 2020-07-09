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
using Syncfusion.Windows.Shared;
using System.Windows;

namespace CalendarDemo
{
    public class ToolTipByDayAction : TargetedTriggerAction<Button>
    {
        protected override void Invoke(object parameter)
        {
            try
            {
                Date a = new Date();

                ToolTip toolTip = new ToolTip();

                toolTip.Content = ((TextBox)TextDay).Text;
                if (((IntegerTextBox)IntTextDay).Value.ToString().Trim().Equals(""))
                {
                    a.Day = DateTime.Now.Day;
                }
                else
                    a.Day = int.Parse(((IntegerTextBox)IntTextDay).Value.ToString());

                if (((IntegerTextBox)IntTextMonth).Value.ToString().Trim().Equals(""))
                {
                    a.Month = DateTime.Now.Month;
                }
                else
                    a.Month = int.Parse(((IntegerTextBox)IntTextMonth).Value.ToString());

                if (!((IntegerTextBox)IntTextYear).Value.ToString().Trim().Equals(""))
                    a.Year = int.Parse(((IntegerTextBox)IntTextYear).Value.ToString());
                else
                    a.Year = DateTime.Now.Year;

                ((CalendarEdit)CalenderEdit).SetToolTip(a, toolTip);
            }
            catch
            {
            }
        }

        public static readonly DependencyProperty IntTextDayProperty = DependencyProperty.Register("IntTextDay", typeof(object), typeof(ToolTipByDayAction), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty IntTextMonthProperty = DependencyProperty.Register("IntTextMonth", typeof(object), typeof(ToolTipByDayAction), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty IntTextYearProperty = DependencyProperty.Register("IntTextYear", typeof(object), typeof(ToolTipByDayAction), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty TextDayProperty = DependencyProperty.Register("TextDay", typeof(object), typeof(ToolTipByDayAction), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty CalenderEditProperty = DependencyProperty.Register("CalenderEdit", typeof(object), typeof(ToolTipByDayAction), new FrameworkPropertyMetadata(null));


        public object IntTextDay
        {
            get
            {
                return (object)GetValue(IntTextDayProperty);
            }

            set
            {
                SetValue(IntTextDayProperty, value);
            }
        }
        public object IntTextMonth
        {
            get
            {
                return (object)GetValue(IntTextMonthProperty);
            }

            set
            {
                SetValue(IntTextMonthProperty, value);
            }
        }
        public object IntTextYear
        {
            get
            {
                return (object)GetValue(IntTextYearProperty);
            }

            set
            {
                SetValue(IntTextYearProperty, value);
            }
        }
        public object TextDay
        {
            get
            {
                return (object)GetValue(TextDayProperty);
            }

            set
            {
                SetValue(TextDayProperty, value);
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
