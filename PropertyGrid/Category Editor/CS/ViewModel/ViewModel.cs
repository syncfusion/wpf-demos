#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Syncfusion.Windows.PropertyGrid;
using Syncfusion.Windows.Shared;

namespace CategoryEditorDemo
{
    public class ViewModel : INotifyPropertyChanged
    {
        PropertyGrid propertyGrid;
        public ViewModel()
        {
            loadedCommand = new DelegateCommand<object>(WindowLoaded);
        }
        
        private ICommand loadedCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoadedCommand
        {
            get
            {
                return loadedCommand;
            }
        }

        public void WindowLoaded(object param)
        {
            propertyGrid = param as PropertyGrid;
            HideProperties(typeof(TextBlock));
            CustomEditor doubleeditor = new CustomEditor() { Editor = new DoubleEditor() };
            doubleeditor.Properties.Add("FontSize");
            propertyGrid.CustomEditorCollection.Add(doubleeditor);
            propertyGrid.RefreshPropertygrid();
        }

        private void HideProperties(Type type)
        {
            PropertyDescriptorCollection p = (PropertyDescriptorCollection)TypeDescriptor.GetProperties(type);
            foreach (PropertyDescriptor item in p)
            {
                if (item.Category == "Action" || item.Category == "Behavior" || item.Category == "Layout"
                    || item.Category == "Touch")
                {
                    propertyGrid.HidePropertiesCollection.Add(item.Name);
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
