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
