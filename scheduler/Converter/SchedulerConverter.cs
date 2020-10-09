#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace syncfusion.schedulerdemos.wpf
{
    public class DisplayDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DateTime.Now.Date.AddHours(9);
            return (value as DateTime?).Value.Date.AddHours(9);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class SubjectToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString().Equals("Conference"))
                return new BitmapImage(new Uri(@"/syncfusion.schedulerdemos.wpf;component/Assets/Scheduler/Conference_schedule.png", UriKind.Relative));
            else if (value.ToString().Equals("System Troubleshoot"))
                return new BitmapImage(new Uri(@"/syncfusion.schedulerdemos.wpf;component/Assets/Scheduler/Troubleshoot.png", UriKind.Relative));
            else if (value.ToString().Equals("Checkup"))
                return new BitmapImage(new Uri(@"/syncfusion.schedulerdemos.wpf;component/Assets/Scheduler/Stethoscope.png", UriKind.Relative));
            else if (value.ToString().Equals("Birthday"))
                return new BitmapImage(new Uri(@"/syncfusion.schedulerdemos.wpf;component/Assets/Scheduler/cake_schedule.png", UriKind.Relative));
            else
                return new BitmapImage(new Uri(@"/syncfusion.schedulerdemos.wpf;component/Assets/Scheduler/calendar.png", UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
