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
using System.Windows.Controls;
using System.Windows;

namespace ResourceNameCustomization
{
    public class CustomTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// When overridden in a derived class, returns a <see cref="T:System.Windows.DataTemplate"/> based on custom logic.
        /// </summary>
        /// <param name="item">The data object for which to select the template.</param>
        /// <param name="container">The data-bound object.</param>
        /// <returns>
        /// Returns a <see cref="T:System.Windows.DataTemplate"/> or null. The default value is null.
        /// </returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            ContentControl res = item as ContentControl;
            DataTemplate template = null;
            DataTemplate temp = Application.Current.Resources["temp"] as DataTemplate;
            DataTemplate temp1 = Application.Current.Resources["temp1"] as DataTemplate;
            DataTemplate temp2 = Application.Current.Resources["temp2"] as DataTemplate;
            DataTemplate temp3 = Application.Current.Resources["temp3"] as DataTemplate;
            DataTemplate temp4 = Application.Current.Resources["temp4"] as DataTemplate;
            DataTemplate temp5 = Application.Current.Resources["temp5"] as DataTemplate;
            DataTemplate temp6 = Application.Current.Resources["temp6"] as DataTemplate;
            DataTemplate temp7 = Application.Current.Resources["temp7"] as DataTemplate;
            if (res != null)
            {
                switch (res.Content.ToString())
                {
                    case "Peter":
                        template = temp;
                        return template;
                    case "John":
                        template = temp1;
                        return template;
                    case "Leslie":
                        template = temp2;
                        return template;
                    case "Neil":
                        template = temp3;
                        return template;
                    case "David":
                        template = temp4;
                        return template;
                    case "Thomas":
                        template = temp5;
                        return template;
                    case "Johnson":
                        template = temp6;
                        return template;
                    case "Peterson":
                        template = temp7;
                        return template;
                }
            }
            return base.SelectTemplate(item, container);
        }
    }
}
