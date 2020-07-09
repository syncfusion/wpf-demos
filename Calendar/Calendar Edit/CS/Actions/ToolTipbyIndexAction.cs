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
using Syncfusion.Windows.Shared;
using System.Windows;

namespace CalendarDemo
{
    public class ToolTipByIndexAction : TargetedTriggerAction<Button>
    {
        protected override void Invoke(object parameter)
        {
            int rowindex, colindex;
            rowindex = colindex = 0;
            ToolTip toolTip = new ToolTip();
            toolTip.Content = ((TextBox)IndexTextDay).Text;
            if (!((IntegerTextBox)IntTextRow).Value.ToString().Trim().Equals(""))
                rowindex = int.Parse(((IntegerTextBox)IntTextRow).Value.ToString());
            else
                rowindex = 0;

            if (!((IntegerTextBox)IntTextColumn).Value.ToString().Trim().Equals(""))
                colindex = int.Parse(((IntegerTextBox)IntTextColumn).Value.ToString());
            else
                colindex = 0;

            ((CalendarEdit)IndexCalenderEdit).SetToolTip(rowindex, colindex, toolTip);
        }

        public static readonly DependencyProperty IntTextRowProperty = DependencyProperty.Register("IntTextRow", typeof(object), typeof(ToolTipByIndexAction), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty IntTextColumnProperty = DependencyProperty.Register("IntTextColumn", typeof(object), typeof(ToolTipByIndexAction), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty IndexTextDayProperty = DependencyProperty.Register("IndexTextDay", typeof(object), typeof(ToolTipByIndexAction), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty IndexCalenderEditProperty = DependencyProperty.Register("IndexCalenderEdit", typeof(object), typeof(ToolTipByIndexAction), new FrameworkPropertyMetadata(null));


        public object IntTextRow
        {
            get
            {
                return (object)GetValue(IntTextRowProperty);
            }

            set
            {
                SetValue(IntTextRowProperty, value);
            }
        }
        public object IntTextColumn
        {
            get
            {
                return (object)GetValue(IntTextColumnProperty);
            }

            set
            {
                SetValue(IntTextColumnProperty, value);
            }
        }

        public object IndexTextDay
        {
            get
            {
                return (object)GetValue(IndexTextDayProperty);
            }

            set
            {
                SetValue(IndexTextDayProperty, value);
            }
        }
        public object IndexCalenderEdit
        {
            get
            {
                return (object)GetValue(IndexCalenderEditProperty);
            }

            set
            {
                SetValue(IndexCalenderEditProperty, value);
            }
        }
    }
}
