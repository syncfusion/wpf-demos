#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.PropertyGrid;
using System.Reflection;

namespace CategoryEditorDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        public MainWindow()
        {

            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HideProperties(typeof(TextBlock));
            CustomEditor doubleeditor = new CustomEditor() { Editor = new DoubleEditor() };
            doubleeditor.Properties.Add("FontSize");
            pgrid.CustomEditorCollection.Add(doubleeditor);
            pgrid.RefreshPropertygrid();
        }

        private void HideProperties(Type type)
        {
            PropertyDescriptorCollection p = (PropertyDescriptorCollection)TypeDescriptor.GetProperties(type);
            foreach (PropertyDescriptor item in p)
            {
                if (item.Category == "Action" || item.Category == "Behavior" || item.Category == "Layout"
                    || item.Category == "Touch")
                {
                    pgrid.HidePropertiesCollection.Add(item.Name);
                }
            }
        }
    }

    public class DoubleEditor : ITypeEditor
    {
        public void Attach(PropertyViewItem property, PropertyItem info)
        {
            if (info.CanWrite)
            {
                var binding = new Binding("Value")
                {
                    Mode = BindingMode.TwoWay,
                    Source = info,
                    ValidatesOnExceptions = true,
                    ValidatesOnDataErrors = true
                };
                BindingOperations.SetBinding(doubletext, UpDown.ValueProperty, binding);
            }
            else
            {
                doubletext.IsReadOnly = false;
                var binding = new Binding("Value")
                {

                    Source = info,
                    ValidatesOnExceptions = true,
                    ValidatesOnDataErrors = true
                };
                BindingOperations.SetBinding(doubletext, UpDown.ValueProperty, binding);
            }
        }

        DoubleTextBox doubletext;
        public object Create(PropertyInfo PropertyInfo)
        {
            doubletext = new DoubleTextBox()
            {
                BorderThickness = new Thickness(0),
                ApplyZeroColor = false
            };

            if (PropertyInfo.Name == "FontSize")
            {
                doubletext.MinValue = 0;
                doubletext.MaxValue = 35790;
            }

            return doubletext;
        }
        public void Detach(PropertyViewItem property)
        {
            
        }
    }
}
