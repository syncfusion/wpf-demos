#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Class for representing the trigger for add and remove the columns in ManipulatorView.
    /// </summary>
    public class MappingNameComboBoxTrigger : TargetedTriggerAction<ComboBox>
    {
        protected override void Invoke(object parameter)
        {
            List<String> mappingNameCol = new List<string>();
            SerializationDemo mainwnd = SerializationDemo.demoControl;
            ManipulatorView manipulatorwnd = ManipulatorView.manipulatorView; 

            if (manipulatorwnd.addcolarea.Visibility == Visibility.Collapsed)
            {
                foreach (var col in mainwnd.dataGrid.Columns)
                {
                    if (!(col is GridUnBoundColumn) && col is GridTemplateColumn)
                        mappingNameCol.Add(col.HeaderText + " (TemplateColumn)");
                    else if (col is GridUnBoundColumn)
                        mappingNameCol.Add(col.HeaderText + " (UnBoundColumn)");
                    else
                        mappingNameCol.Add(col.HeaderText);

                }
            }
            else
            {
                PropertyInfo[] properties;
                OrderInfo product = new OrderInfo();
                MappingNameDictionary dic = new MappingNameDictionary();
                properties = product.GetType().GetProperties();
                foreach (var property in properties)
                {
                    string headerText;
                    dic.TryGetValue(property.Name, out headerText);
                    if (!string.IsNullOrEmpty(headerText))
                        mappingNameCol.Add(headerText);
                }
                foreach (var col in mainwnd.dataGrid.Columns)
                {
                    if (mappingNameCol.Contains(col.HeaderText))
                        mappingNameCol.Remove(col.HeaderText);
                }
            }
            this.Target.ItemsSource = mappingNameCol;
        }
    }
}
