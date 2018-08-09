using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelLikeSelection
{
    public enum MovingDirection
    {
        None,
        Left,
        Down,
        Right,
        Up
    }

    public enum SeriesType
    {
        CopySeries = 4,
        FillSeries = 6,
        FillFormatOnly = 8,
        FillWithoutFormat = 10
    }

    public enum CellValuetype
    {
        None,
        Date,
        String,
        Numbers,
        AlphaNumeric,
    }

    public static class FillSeriesExtensions
    {
        public static int GetDateFormat(this string value)
        {
            int format = 0;
            string[] str = DateTime.Parse(value).GetDateTimeFormats();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == value)
                {
                    return i;
                }
            }
            return format;
        }
    }
}
