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
using System.Windows.Data;
using System.Windows.Media;

namespace PortfolioAnalyzer.StockListModule
{
    public class PriceDownImageConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((value as string) != null)
            {
                if ((value as string).EndsWith("%"))
                {
                    var val = (value as string).Remove((value as string).Length - 1);
                    value = double.Parse(val);
                }
            }
             return ((double?)value)<=0;                 
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class PriceUpImageConverter : IValueConverter
   {
       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
           if ((value as string) != null)
           {
               if ((value as string).EndsWith("%"))
               {
                   var val = (value as string).Remove((value as string).Length - 1);
                   value = double.Parse(val);
                   return ((double)value)>= 0;
               }
           }
           return ((double?)value) >= 0;
       }

       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
           throw new NotImplementedException();
       }
   }
   public class ForegroundColorConverter : IValueConverter
   {
       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
           if ((value as string) != null)
           {
               if ((value as string).EndsWith("%"))
               {
                   var val = (value as string).Remove((value as string).Length - 1);
                   value = double.Parse(val);
                   if (((double)value) >= 0)
                   {
                       return new SolidColorBrush(Colors.Green);
                   }
                   else if (((double)value) <= 0)
                   {
                       return new SolidColorBrush(Colors.Red);
                   }
               }
           }
           else
           {
               if (value as double? >= 0)
               {
                   return new SolidColorBrush(Colors.Green);
               }

               else if (value as double? <= 0)
               {
                   return new SolidColorBrush(Colors.Red);
               }
           }
           return value;
       }

       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
           throw new NotImplementedException();
       }
   }
   public class BoolToDoubleConverter : IValueConverter
   {
       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
           if ((bool)value)
               return 0.3d;
           else
               return 1d;
       }

       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
           throw new NotImplementedException();
       }
   }


}
