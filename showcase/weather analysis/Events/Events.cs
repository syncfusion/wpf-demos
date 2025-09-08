#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace syncfusion.weatheranalysis.wpf
{
    #region City Changed

    public delegate void CityChangedEvent(CityChangedEventArgs args);

    public class CityChangedEventArgs : SelectionChangedEventArgs<string>
    {
    }

    #endregion

    #region Data Changed

    public delegate void DataChangedEvent(EventArgs args);

    #endregion

    #region Temp Format Changed

    public delegate void TempFormatChangedEvent(TempFormatChangedEventArgs args);

    public class TempFormatChangedEventArgs : SelectionChangedEventArgs<string>
    {
    }

    #endregion

    #region Forecast Changed

    public delegate void ForecastChangedEvent(ForecastChangedEventArgs args);

    public class ForecastChangedEventArgs : SelectionChangedEventArgs<ForecastModel>
    {
    }
    #endregion
}
