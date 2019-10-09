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
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Windows;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.SfSkinManager;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColorPickerPaletteDemo_2008
{
    public class ViewModel : NotificationObject
    {
        public ViewModel()
        {
            selectioChangedCommand = new DelegateCommand<object>(PropertyChangedHandler);
        }

        private ICommand selectioChangedCommand;

        private Color selectedColor;

        public Color SelectedColor
        {
            get { return selectedColor; }

            set 
            {
                selectedColor = value; 
                RaisePropertyChanged("SelectedColor"); 
            }
        }
        public ICommand SelectioChangedCommand
        {
            get
            {
                return selectioChangedCommand;
            }
        }
        public void PropertyChangedHandler(object param)
        {
            WindowCollection windows = Application.Current.Windows;
            if (windows.Count > 0)
            {
                Window samplewindow = windows[0];
                ComboBoxAdv combo = param as ComboBoxAdv;
                if (combo != null)
                {
                    if (combo.SelectedItem != null)
                    {
                        ComboBoxItemAdv item = combo.SelectedItem as ComboBoxItemAdv;
                        SfSkinManager.SetVisualStyle(samplewindow, (VisualStyles)Enum.Parse(typeof(VisualStyles), item.Content.ToString()));
                    }
                }
            }
        }

    }
}
