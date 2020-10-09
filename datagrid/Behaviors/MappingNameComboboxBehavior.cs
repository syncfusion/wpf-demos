#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
    public class MappingNameComboBoxBehavior : Behavior<ComboBox>
    {
        /// <summary>
        ///   Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.DropDownOpened += OnComboBoxDropDownOpened;
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject       
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.DropDownOpened -= OnComboBoxDropDownOpened;
        }

        /// <summary>
        /// Event handler when the DropDown is opened in ComboBox.
        /// </summary>        
        void OnComboBoxDropDownOpened(object sender, EventArgs e)
        {
            List<String> mappingNameCol = new List<string>();
             SerializationDemo mainwnd = (SerializationDemo)Activator.CreateInstance(typeof(SerializationDemo));
            ManipulatorView manipulatorwnd = (ManipulatorView)Activator.CreateInstance(typeof(ManipulatorView));

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
                ProductDetails product = new ProductDetails();
                MappingNameDictionary dic = new MappingNameDictionary();
                properties = product.GetType().GetProperties();
                foreach (var property in properties)
                {
                    string headerText;
                    dic.TryGetValue(property.Name, out headerText);
                    mappingNameCol.Add(headerText);

                }
                foreach (var col in mainwnd.dataGrid.Columns)
                {
                    if (mappingNameCol.Contains(col.HeaderText))
                        mappingNameCol.Remove(col.HeaderText);
                }
            }
            this.AssociatedObject.ItemsSource = mappingNameCol;
        }

    }
}
