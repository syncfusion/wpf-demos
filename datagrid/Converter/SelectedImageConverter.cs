#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace syncfusion.datagriddemos.wpf
{   
    public class SelectedImageConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="info">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo info)
        {

            if (value == null)
                return null;
           
            if (value.ToString() == "1")
                return @"/syncfusion.datagriddemos.wpf;component/Assets/datagrid/Male.png";
            else if (value.ToString() == "2")
                return @"/syncfusion.datagriddemos.wpf;component/Assets/datagrid/Female.png";
            else
            {
                if (parameter is Storyboard)
                    (parameter as Storyboard).Begin();

                if (value != null && value is ProductInfo)
                {
                    var product = value as ProductInfo;
                    return @"/syncfusion.demoscommon.wpf;component/Assets/Gadgets/" + product.ProductModel + ".png";
                }
                else if (value != null && parameter.ToString() == "Availability" && (bool)value)
                    return @"/syncfusion.demoscommon.wpf;component/Assets/yes.png";
                else if (value != null && parameter.ToString() == "Availability")
                    return @"/syncfusion.demoscommon.wpf;component/Assets/no.png";                
            }

            return null;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="info">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
