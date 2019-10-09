#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace RowPivotsOnly
{
    public class BO
    {
         //Location	Vendor	MarkStyle	Region	Class	PID	Color	ColorDesc	Size	Units	Retail	Cost
        public int Location { get; set; }
        public int Vendor { get; set; }
        public int MarkStyle { get; set; }
        public string Region { get; set; }
        public int Class { get; set; }
        public int PID { get; set; }
        public int Color { get; set; }
        public string ColorDesc { get; set; }
        public string Size { get; set; }
        public int Units { get; set; }
        public double Retail { get; set; }
        public double Cost { get; set; }
        public string TestStr { get; set; }
        public int TestInt { get; set; }
        public double TestDouble { get; set; }
    }
}