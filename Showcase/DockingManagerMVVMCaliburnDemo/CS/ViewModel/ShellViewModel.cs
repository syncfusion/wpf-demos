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
using Caliburn.Micro;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;
using System.Windows;
using System.IO;
using Microsoft.Win32;

namespace DockingManagerMVVMCaliburnMicro
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel :PropertyChangedBase,INotifyPropertyChanged
    {
        [ImportingConstructor]
        public ShellViewModel(DockingAdapterViewModel docking, MenuViewModel menu)
        {
            Docking = docking;
            Menu = menu;
            Menu.VisualStyle = ShellVisualStyle;
            Menu.ShellViewModel = this;
            Menu.DockingAdapterViewModel = docking;
            
        }

        public DockingAdapterViewModel Docking { get; private set; }
        public MenuViewModel Menu { get; private set; }

        private string m_shellvisualstyle="Metro";
        public string ShellVisualStyle 
        {
            get
            {
                return m_shellvisualstyle;
            }
            set
            {
                m_shellvisualstyle = value;
                OnPropertyChanged("ShellVisualStyle");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
