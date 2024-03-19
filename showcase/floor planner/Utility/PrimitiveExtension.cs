#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;

namespace syncfusion.floorplanner.wpf
{
    internal static class PrimitiveExtension
    {
        public static double FindLength(this Point s, Point e)
        {
            double length = Math.Sqrt(Math.Pow((s.X - e.X), 2) + Math.Pow((s.Y - e.Y), 2));
            return Math.Round(length, 4);
        }

        public static double FindAngle(this Point s, Point e)
        {
            if (s.Equals(e))
            {
                return 0d;
            }

            Point r = new Point(e.X, s.Y);
            double sr = s.FindLength(r);
            double re = r.FindLength(e);
            double es = e.FindLength(s);
            double ang = Math.Asin(re / es);
            if (double.IsNaN(ang))
            {
                ang = 0;
            }

            ang = ang * 180 / Math.PI;
            if (s.X < e.X)
            {
                if (s.Y < e.Y)
                {

                }
                else
                {
                    ang = 360 - ang;
                }
            }
            else
            {
                if (s.Y < e.Y)
                {
                    ang = 180 - ang;
                }
                else
                {
                    ang = 180 + ang;
                }
            }

            return ang;
        }

        public static Point Transform(this Point s, double length, double angle)
        {
            return new Point()
            {
                X = s.X + length * Math.Cos(angle * Math.PI / 180),
                Y = s.Y + length * Math.Sin(angle * Math.PI / 180)
            };
        }
    }

    public static class StringExtensions
    {
        public static string Feetwithinches(this double display)
        {
            int defaultvalue = 50;
            var value = display / defaultvalue;
            var feet = Math.Floor(value);
            var inches = Math.Round((value - feet) * 12);
            return feet + "'" + inches + "''";
        }
    }
}
