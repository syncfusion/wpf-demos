#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.PropertyGrid;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.propertygriddemos.wpf
{
    public class CustomEditorViewModel : NotificationObject
    {
        private CustomEditorCollection customEditorCollection; 
        public CustomEditorCollection CustomEditorCollection
        {
            get { return customEditorCollection; }
            set { customEditorCollection = value; }
        }

        public PrivateEmployee PrivateEmployee { get; set; }
        public CustomEditorViewModel()
        {
            PrivateEmployee = new PrivateEmployee();
            PrivateEmployee.Name = "Johnson";
            PrivateEmployee.Age = 25;
            PrivateEmployee.EmailID = "johnabc@gt";
            PrivateEmployee.Experience = 5;
            PrivateEmployee.Height = 260;
            PrivateEmployee.Image = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle31.png", UriKind.RelativeOrAbsolute));
            PrivateEmployee.Salary = "500";
            PrivateEmployee.Weight = 100;

            //Initialize the custom editor collection
            CustomEditorCollection = new CustomEditorCollection();

            // CurrenyEditor added to the collection and will applied to the "Salary" property
            CustomEditor customEditor = new CustomEditor();
            customEditor.Editor = new CurrencyEditor();
            customEditor.Properties.Add("Salary");

            CustomEditorCollection.Add(customEditor);

            //DoubleUpdownEditor added to the collection and it will applied to the "Double" type properties
            CustomEditor customEditor1 = new CustomEditor();
            customEditor1.Editor = new DoubleUpDownEditor();
            customEditor1.HasPropertyType = true;
            customEditor1.PropertyType = typeof(double);

            CustomEditorCollection.Add(customEditor1);
        }
    }
}
