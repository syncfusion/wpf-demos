#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    public class StackedChart3DModel : NotificationObject
    {
        public string Year { get; set; }
        public double Others { get; set; }

       public double Machine {  get; set; }
       public double Storage {  get; set; }
       public double Management {  get; set; }
       public double Communication {  get; set; }
       public double Charging {  get; set; }

        public double Quarter1 { get; set; }
        public double Quarter2 { get; set; }
        public double Quarter3 { get; set; }
        public double Quarter4 { get; set; }

        public string Name {  get; set; }
        public double Size { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Value { get; set; }

        public double Asia { get; set; }
        public double Europe { get; set; }
        public double CIS { get; set; }
        public double North { get; set; }
        public double Latin { get; set; }
        public double Pacific { get; set; }
        public double Africa { get; set; }
        public double Middle { get; set; }
    }
}
