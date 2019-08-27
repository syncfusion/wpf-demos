#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SerializationDemo.Model;
using SerializationDemo.Views;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace SerializationDemo
{
    public class MappingNameComboboxBehavior : Behavior<ComboBox>
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
            MainWindow mainwnd = (MainWindow)Application.Current.MainWindow;
            ManipulatorView manipulatorwnd = (Window)Application.Current.Windows[1] as ManipulatorView;
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


    public class ColumTypeComboboxBehavior : Behavior<ComboBox>
    {
        /// <summary>
        ///   Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.SelectionChanged += OnComboBoxSelectionChanged;
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.SelectionChanged -= OnComboBoxSelectionChanged;
        }

        /// <summary>
        /// Event handler when the SelectionChanged in ComboBox.
        /// </summary>  
        void OnComboBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            ManipulatorView manipulatorwnd = (Window)Application.Current.Windows[1] as ManipulatorView;

            if (combobox.SelectedItem.ToString().Contains("GridUnBoundColumn"))
            {
                manipulatorwnd.Height = 285;
                manipulatorwnd.err_textblock.Visibility = Visibility.Collapsed;
                manipulatorwnd.mappingname_cmbbox.SelectedItem = null;
                manipulatorwnd.unbound_Stackpanel.Visibility = Visibility.Visible;
                manipulatorwnd.mappingname_cmbbox.Visibility = Visibility.Collapsed;
                manipulatorwnd.Mappingname_Label.Visibility = Visibility.Collapsed;
            }
            else
            {
                manipulatorwnd.Height = 230;
                manipulatorwnd.err_textblock.Visibility = Visibility.Collapsed;
                manipulatorwnd.unbound_Stackpanel.Visibility = Visibility.Collapsed;
                manipulatorwnd.mappingname_cmbbox.Visibility = Visibility.Visible;
                manipulatorwnd.Mappingname_Label.Visibility = Visibility.Visible;

            }
        }
    }
}
