#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.Windows.Chart;
using System.Text;
using System.Windows.Data;
using System.Windows.Controls;
using System.Globalization;

namespace ChartLegends
{
    /// <summary>
    /// Converter to update ChartLegend CheckboxVisibiltiy and IconVisibilty with ComboBox SelectedItem
    /// </summary>
    public class VisibilityToSelectedItem : IValueConverter
    {
        #region IValueConverter Members
        ComboBox parentItem;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ComboBoxItem cmbitem = value as ComboBoxItem;
            if (cmbitem != null)
            {
                parentItem = cmbitem.Parent as ComboBox;
                return cmbitem.Content;
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value.ToString().Equals("Visible"))
                parentItem.SelectedIndex = 0;
            else if (value.ToString().Equals("Collapsed"))
                parentItem.SelectedIndex = 2;
            else
                parentItem.SelectedIndex = 1;

            return parentItem.SelectedItem;
        }

        #endregion
    }

    public class StringValueConvertor : IValueConverter
    {
        CarMileageModel costoffruits;

        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {

            ChartPoint pt = (ChartPoint)value;
            CarMileageModel item = (CarMileageModel)pt.Tag;
            return item.CarName;
        }



        public Object ConvertBack(Object value, Type targetTypes, Object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }



}
