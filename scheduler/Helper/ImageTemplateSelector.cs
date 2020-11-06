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
using System.Windows;
using System.Windows.Data;

namespace syncfusion.schedulerdemos.wpf
{
    public class ImageTemplateSelector : IValueConverter
    {
        static ResourceDictionary myResourceDictionary;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageTemplateSelector" /> class.
        /// </summary>
        static ImageTemplateSelector()
        {
            myResourceDictionary = new ResourceDictionary();
            myResourceDictionary.Source =
                new Uri("/syncfusion.schedulerdemos.wpf;component/Helper/SubjectImagePaths.xaml",
                        UriKind.RelativeOrAbsolute);
        }
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageName = value.ToString().Replace(" ", "").ToLower();
            DataTemplate dataTemplateImagePaths;
            dataTemplateImagePaths = myResourceDictionary[imageName] as DataTemplate;
            if (dataTemplateImagePaths != null)
                return dataTemplateImagePaths;
            else
                return myResourceDictionary["default"] as DataTemplate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
