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
using System.Threading.Tasks;
using Syncfusion.Data;
using System.Globalization;
using Syncfusion.UI.Xaml.Grid.Cells;
using System.Windows;
using System.Windows.Data;
using IntervalGroupingDemo;


namespace IntervalGroupingDemo
{
    /// <summary>
    /// GroupingMode provide the options for the Grouping of Date-Time column.
    /// </summary>
    public enum DateGroupingMode
    {
        Range,
        Month,
        Year
    }

    /// <summary>
    /// Date-Range Enum provides the Option for the Date-Time Column Grouping When the GroupMode is Range.
    /// </summary>
    public enum DateRange
    {
        BeyondNextMonth = 0,
        NextMonth = 1,
        LaterofThisMonth = 2,
        ThreeWeeksAway = 3,
        TwoWeeksAway = 4,
        NextWeek = 5,
        Sunday = 6,
        Monday = 7,
        TuesDay = 8,
        WednesDay = 9,
        Thursday = 10,
        Friday = 11,
        Saturday = 12,
        Tomorrow = 13,
        Today = 14,
        Yesterday = 15,        
        LastWeek = 23,
        TwoWeeksAgo = 24,
        ThreeWeeksAgo = 25,
        EarlierofthisMonth = 26,
        LastMonth = 27,
        Older = 28
    }
    
    /// <summary>
    /// GridDateTimeConverter class helps to Group the Date-Time Column with the help of IGroupConverter.    
    /// </summary>
    public class GridDateTimeRangeConverter : IColumnAccessProvider, IValueConverter
    {
        #region Fields

        private DateGroupingMode groupingMode;
        private string columnName;
        private IPropertyAccessProvider propertyReflector;

        #endregion

        #region Public Member

        /// <summary>
        /// GroupMode property helps to provide the option to the Date-Time column for the IntervalGrouping.
        /// </summary>
        public DateGroupingMode GroupMode
        {
            get { return groupingMode; }
            set { groupingMode = value; }
        }

        /// <summary>
        /// ColumnName property helps to identify which column is getting into the Group.
        /// </summary>
        public string ColumnName
        {
            get
            {

                return this.columnName;
            }
            set
            {
                columnName = value;
            }
        }

        /// <summary>
        /// This PropertyReflector property helps to the value.
        /// </summary>
        public IPropertyAccessProvider PropertyReflector
        {
            get
            {
                return this.propertyReflector;
            }
            set
            {
                propertyReflector = value;
            }
        }
        #endregion

        #region Methods

        public DateRange GetValue(string day)
        {
            if (day == "Sunday")
                return DateRange.Sunday;
            else if (day == "Monday")
                return DateRange.Monday;
            else if (day == "Tuesday")
                return DateRange.TuesDay;
            else if (day == "Wednesday")
                return DateRange.WednesDay;
            else if (day == "Thursday")
                return DateRange.Thursday;
            else if (day == "Friday")
                return DateRange.Friday;
            else
                return DateRange.Saturday;

        }

        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {            
            var dateGroupValue = PropertyReflector.GetValue(value, columnName);
            if (dateGroupValue != null)
            {
                if (this.GroupMode == DateGroupingMode.Year)
                {
                    DateTime year = (DateTime)dateGroupValue;
                    return year.Year;
                }
                else if (this.GroupMode == DateGroupingMode.Month)
                {
                    DateTime month = (DateTime)dateGroupValue;
                    //return month.Month;
                    return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month.Month);
                }
                else
                {
                    DateTime date = (DateTime)dateGroupValue;
                    var dt = DateTime.Now;
                    var days = (int)Math.Floor((dt - date).TotalDays);
                    var dayofweek = (int)dt.DayOfWeek;
                    if (days > 0)
                    {
                        var diff = days - dayofweek;
                        if (days <= dayofweek)
                        {
                            if (days == 0)
                                return DateRange.Today;
                            if (days == 1)
                                return DateRange.Yesterday;
                            return GetValue(date.DayOfWeek.ToString());
                        }
                        if (diff > 0 && diff <= 7)
                            return DateRange.LastWeek;
                        if (diff > 7 && diff <= 14)
                            return DateRange.TwoWeeksAgo;
                        if (diff > 14 && diff <= 21)
                            return DateRange.ThreeWeeksAgo;
                        if (dt.Year == date.Year && dt.Month == date.Month)
                            return DateRange.EarlierofthisMonth;
                        if (DateTime.Now.AddMonths(-1).Month == date.Month && dt.Year == date.Year)
                            return DateRange.LastMonth;
                        return DateRange.Older;
                    }
                    else
                    {
                        var different = dayofweek - days;
                        if ((-days) <= dayofweek)
                        {
                            if (days == 0)
                                return DateRange.Today;
                            if (days == -1)
                                return DateRange.Tomorrow;
                            return GetValue(date.DayOfWeek.ToString());
                        }
                        if (different > 0 && different <= 7)
                            return DateRange.NextWeek;
                        if (different > 7 && different <= 14)
                            return DateRange.TwoWeeksAway;
                        if (different > 14 && different <= 21)
                            return DateRange.ThreeWeeksAway;
                        if (dt.Year == date.Year && dt.Month == date.Month)
                            return DateRange.LaterofThisMonth;
                        if (DateTime.Now.AddMonths(+1).Month == date.Month && dt.Year == date.Year)
                            return DateRange.NextMonth;
                        return DateRange.BeyondNextMonth;
                    }
                }
            }
            return null;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }    

    /// <summary>
    /// GridNumericConverter class helps to Group the Integer column with the help of IGroupConverter
    /// </summary>    
    public class GridNumericRangeConverter : IColumnAccessProvider, IValueConverter
    {
        #region Fields

        private int groupInterval;
        private string columnName;
        private IPropertyAccessProvider _propertyReflector;

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the Group Interval for grouping
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public int GroupInterval
        {
            get { return this.groupInterval; }
            set { groupInterval = value; }
        }

        /// <summary>
        /// ColumnName property helps to identify which column is getting into the Group.
        /// </summary>
        public string ColumnName
        {
            get
            {
                return this.columnName;
            }
            set
            {
                columnName = value;
            }
        }

        /// <summary>
        /// This PropertyReflector property helps to the value.
        /// </summary>
        public IPropertyAccessProvider PropertyReflector
        {
            get
            {
                return this._propertyReflector;
            }
            set
            {
                _propertyReflector = value;
            }
        }

        #endregion

        #region Methods

        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (this.GroupInterval == 0)
                return null;

            var numericGroupValue = PropertyReflector.GetValue(value, columnName);
            if (numericGroupValue != null)
            {
                var columnvalue = System.Convert.ToInt32(numericGroupValue);
                var i = (int)columnvalue / this.GroupInterval;
                int GroupingIntervalFrom = (int)i * this.GroupInterval;
                int GroupingIntervalTo = ((int)i + 1) * this.GroupInterval;
                return GroupingIntervalFrom.ToString(CultureInfo.InvariantCulture) + " to " + GroupingIntervalTo.ToString(CultureInfo.InvariantCulture);
            }
            return null;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// GridTextConverter class helps to Group the Text column with the help of IGroupConverter
    /// </summary>
    public class GridTextRangeConverter : IColumnAccessProvider, IValueConverter
    {
        #region Fields

        private string columnName;
        private IPropertyAccessProvider propertyReflector;

        #endregion

        #region Public Members
        /// <summary>
        /// ColumnName property helps to identify which column is getting into the Group.
        /// </summary>
        public string ColumnName
        {
            get
            {
                return this.columnName;
            }
            set
            {
                columnName = value;
            }
        }


        /// <summary>
        /// This PropertyReflector property helps to the value.
        /// </summary>
        public IPropertyAccessProvider PropertyReflector
        {
            get
            {
                return this.propertyReflector;
            }
            set
            {
                propertyReflector = value;
            }
        }

        #endregion

        #region Methods
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var textGroupValue = PropertyReflector.GetValue(value, columnName);
            if (textGroupValue != null)
            {
                char start = textGroupValue.ToString().First();
                return start;
            }
            return null;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }        
}
