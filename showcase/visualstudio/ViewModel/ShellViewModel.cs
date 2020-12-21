#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Caliburn.Micro;
using System.ComponentModel;

namespace syncfusion.visualstudiodemo.wpf
{
    using syncfusion.visualstudiodemo.wpf;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel : PropertyChangedBase, INotifyPropertyChanged
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

        private string m_shellvisualstyle = "MaterialLight";
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

        public new event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
