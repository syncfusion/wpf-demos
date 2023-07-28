#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Data;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// Label converter for Chart.
    /// </summary>
    public class Labelconvertor : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (parameter.ToString() == "SectorValue")
            {
                SectorAndValue info = value as SectorAndValue;

                return String.Format("{0}\n({1}$)", info.SectorName, info.Value);
            }
            else if (parameter.ToString() == "ExchangeValue")
            {
                ExchangeAndValue info = value as ExchangeAndValue;

                return String.Format("{0}\n({1}$)", info.ExchangeName, info.Value);
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
