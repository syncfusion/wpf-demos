#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel.DataAnnotations;

namespace syncfusion.weatheranalysis.wpf
{
    public enum MoonPhase
    {
        [Display(Name = "New Moon")]
        NewMoon,
        [Display(Name = "First Quarter")]
        FirstQuarter,
        [Display(Name = "Full Moon")]
        FullMoon,
        [Display(Name = "Last Quarter")]
        LastQuarter,
        [Display(Name = "Waxing Crescent")]
        WaxingCrescent,
        [Display(Name = "Waxing Gibbous")]
        WaxingGibbous,
        [Display(Name = "Waning Gibbous")]
        WaningGibbous,
        [Display(Name = "Waning Crescent")]
        WaningCrescent
    }
}
