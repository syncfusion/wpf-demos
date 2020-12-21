#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using syncfusion.demoscommon.wpf;
using System.Windows;

namespace syncfusion.treegriddemos.wpf
{    
    public class CellStyleConverter : IValueConverter
    {
        private CellStyleDemo cellStyleDemo;
         
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(cellStyleDemo == null)
                cellStyleDemo = (CellStyleDemo)Activator.CreateInstance(typeof(CellStyleDemo));

            if (value is EmployeeInfo)
            {
                var employeeInfo = value as EmployeeInfo;
                if (parameter!= null && parameter.ToString() == "Salary")
                {
                    if (employeeInfo.Salary < 10000)
                        return new SolidColorBrush(Colors.Transparent);
                    else if (employeeInfo.Salary > 10000 && employeeInfo.Salary < 50000)
                        return cellStyleDemo.Resources["Brush2"];
                    else if (employeeInfo.Salary > 50000 && employeeInfo.Salary < 100000)
                        return cellStyleDemo.Resources["Brush1"];
                }
                else if(parameter != null && parameter.ToString() == "ConditionalFormattingDemo")
                {
                    if (employeeInfo.Salary < 10000)
                        return new SolidColorBrush(Colors.Transparent);
                    else if (employeeInfo.Salary > 10000 && employeeInfo.Salary < 50000)
                        return new SolidColorBrush(Color.FromArgb(255, 255, 211, 86));
                    else if (employeeInfo.Salary > 50000 && employeeInfo.Salary < 100000)
                        return new SolidColorBrush(Color.FromArgb(255, 112, 252, 160));
                    return new SolidColorBrush();
                }
                else
                {
                    if (employeeInfo.Hike < 6)
                        return new SolidColorBrush(Colors.Transparent);
                    else if (employeeInfo.Hike > 6 && employeeInfo.Hike < 10)
                        return cellStyleDemo.Resources["Brush3"];
                    else
                        return cellStyleDemo.Resources["Brush4"];
                }
            }

            if (value is TreeNode)
            {
                var treeNode = value as TreeNode;
                if (treeNode.Level == 0)
                    return new SolidColorBrush(Colors.SkyBlue);
                else if (treeNode.Level == 1)
                    return new SolidColorBrush(Color.FromArgb(255, 255, 211, 86));
                else if (treeNode.Level == 2)
                    return new SolidColorBrush(Colors.LightGreen);
                else if (treeNode.Level == 3)
                    return new SolidColorBrush(Colors.Bisque);
                else if (treeNode.Level == 4)
                    return new SolidColorBrush(Colors.Pink);
            }

            return new SolidColorBrush();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    } 
}
