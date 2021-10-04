#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Data;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    public class OffsetCalculator : IValueConverter
    {
        private int mode;
        public OffsetCalculator(int mode)
        {
            if (mode < 0 || mode > 2)
                throw new Exception("Valid values for OffsetCalculator are 0 or 1. 0 for X Offset, 1 for Y Offset");

            this.mode = mode;
        }

        #region IValueConverter Members

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// Offset calculator that calculate X.
    /// </summary>
    public class OffsetXCalculator : OffsetCalculator
    {
        public OffsetXCalculator() : base(0) { }
    }

    /// <summary>
    /// Offset calculator that calculate Y.
    /// </summary>
    public class OffsetYCalculator : OffsetCalculator
    {
        public OffsetYCalculator() : base(1) { }
    }
}
