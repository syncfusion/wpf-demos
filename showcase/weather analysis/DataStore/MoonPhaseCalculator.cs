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
    public static class MoonPhaseCalculator
    {
        public static MoonPhase CalculateMoonPhase(DateTime date, double longitude, double latitude)
        {
            DateTime now = date;

            // Calculate the number of days since the approximate new moon
            double daysSinceNewMoon = (now - new DateTime(2000, 1, 6, 18, 14, 0)).TotalDays;

            // Calculate the number of synodic months since the approximate new moon
            double synodicMonths = daysSinceNewMoon / 29.53058867;

            // Calculate the current moon phase in degrees (0 to 360)
            double moonPhaseDegrees = synodicMonths * 360;

            // Adjust the moon phase based on the observer's longitude
            double adjustedMoonPhaseDegrees = moonPhaseDegrees + (longitude / 360 * 360);

            // Normalize the moon phase to the range 0 to 360
            double normalizedMoonPhaseDegrees = adjustedMoonPhaseDegrees % 360;
            if (normalizedMoonPhaseDegrees < 0)
            {
                normalizedMoonPhaseDegrees += 360;
            }

            normalizedMoonPhaseDegrees = normalizedMoonPhaseDegrees % 360;
            if (normalizedMoonPhaseDegrees < 0)
            {
                normalizedMoonPhaseDegrees += 360;
            }

            // Determine the moon phase description based on the moon phase value
            if (normalizedMoonPhaseDegrees >= 0 && normalizedMoonPhaseDegrees < 45)
                return MoonPhase.FullMoon;
            else if (normalizedMoonPhaseDegrees >= 45 && normalizedMoonPhaseDegrees < 90)
                return MoonPhase.WaxingCrescent;
            else if (normalizedMoonPhaseDegrees >= 90 && normalizedMoonPhaseDegrees < 135)
                return MoonPhase.FirstQuarter;
            else if (normalizedMoonPhaseDegrees >= 135 && normalizedMoonPhaseDegrees < 180)
                return MoonPhase.WaxingGibbous;
            else if (normalizedMoonPhaseDegrees >= 180 && normalizedMoonPhaseDegrees < 225)
                return MoonPhase.FullMoon;
            else if (normalizedMoonPhaseDegrees >= 225 && normalizedMoonPhaseDegrees < 270)
                return MoonPhase.WaningGibbous;
            else if (normalizedMoonPhaseDegrees >= 270 && normalizedMoonPhaseDegrees < 315)
                return MoonPhase.LastQuarter;
            else
                return MoonPhase.WaningCrescent;
        }
    }
}
