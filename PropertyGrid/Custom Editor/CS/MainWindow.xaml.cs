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
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.PropertyGrid;
using Syncfusion.Windows.Shared;

namespace CustomEditorDemo
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
            SkinStorage.SetVisualStyle(this, "Metro");
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HideProperties(typeof(ButtonAdv));
            pgrid.DefaultPropertyPath = "SmallIcon";
            CustomEditor upDownEditor = new CustomEditor() { HasPropertyType = true, PropertyType = typeof(double), Editor = new UpDownEditor() };
            CustomEditor brusheditor = new CustomEditor() { HasPropertyType = true, PropertyType = typeof(Brush), Editor = new BrushEditor() };
            pgrid.CustomEditorCollection.Add(brusheditor);            
            CustomEditor imgeditor = new CustomEditor() { HasPropertyType = true, PropertyType = typeof(ImageSource), Editor = new ImageEditor() };
            pgrid.CustomEditorCollection.Add(upDownEditor);
            pgrid.CustomEditorCollection.Add(imgeditor);
            pgrid.RefreshPropertygrid();
        }

        private void HideProperties(Type type)
        {
            PropertyDescriptorCollection p = (PropertyDescriptorCollection)TypeDescriptor.GetProperties(type);
            foreach (PropertyDescriptor item in p)
            {
                if (item.PropertyType != typeof(Brush) && item.PropertyType != typeof(double))
                {
                    if (item.Name != "SmallIcon")
                    {
                        pgrid.HidePropertiesCollection.Add(item.Name);
                    }
                }
                else if(item.Name=="Foreground")
                {
                    pgrid.HidePropertiesCollection.Add(item.Name);
                }
            }

        }
    }
}
