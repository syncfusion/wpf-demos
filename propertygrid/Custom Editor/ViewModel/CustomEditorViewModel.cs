#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
        private ICommand loadedCommand;
        private ICommand buttonClickCommand;
        public CustomEditorViewModel()
        {
            loadedCommand = new DelegateCommand<object>(InitilizeSettings);
            buttonClickCommand = new DelegateCommand<object>(OnButtonClicked);
        }

        public ICommand LoadedCommand
        {
            get
            {
                return loadedCommand;
            }
        }

        public ICommand ButtonClickCommand
        {
            get
            {
                return buttonClickCommand;
            }
        }

        public void InitilizeSettings(object param)
        {
            var pgrid = param as PropertyGrid;
            pgrid.DefaultPropertyPath = "SmallIcon";
            CustomEditor upDownEditor = new CustomEditor() { HasPropertyType = true, PropertyType = typeof(double), Editor = new UpDownEditor() };
            CustomEditor imgeditor = new CustomEditor() { HasPropertyType = true, PropertyType = typeof(ImageSource), Editor = new ImageEditor() };
            pgrid.CustomEditorCollection.Add(upDownEditor);
            pgrid.CustomEditorCollection.Add(imgeditor);
            HideProperties(pgrid, typeof(ButtonAdv));
        }

        private void HideProperties(PropertyGrid propertygrid, Type type)
        {
            var p = (PropertyDescriptorCollection)TypeDescriptor.GetProperties(type);
            foreach (PropertyDescriptor item in p)
            {
                if (item.PropertyType != typeof(Brush) && item.PropertyType != typeof(double))
                {
                    if (item.Name != "SmallIcon")
                    {
                        propertygrid.HidePropertiesCollection.Add(item.Name);
                    }
                }
            }
        }

        public void OnButtonClicked(object param)
        {
            ImageBrowser imageBrowser = param as ImageBrowser;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Small Icon (*.png, *.jpeg)|*.png*;*.jpeg";
            if (dialog.ShowDialog().Value)
            {
                BitmapImage bmp = new BitmapImage(new Uri(dialog.FileName, UriKind.RelativeOrAbsolute));
                imageBrowser.ImageSource = bmp;
            }
        }
    }
}
