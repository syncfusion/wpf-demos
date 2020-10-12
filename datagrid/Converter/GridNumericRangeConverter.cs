#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.datagriddemos.wpf
{
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
}
