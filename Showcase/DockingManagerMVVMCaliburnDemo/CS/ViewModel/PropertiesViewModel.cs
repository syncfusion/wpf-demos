#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Caliburn.Micro;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DockingManagerMVVMCaliburnMicro
{
    public class PropertiesViewModel : Workspace, INotifyPropertyChanged
    {
        private string visualstyle = "Metro";

        public string VisualStyle
        {
            get
            {
                return visualstyle;
            }
            set
            {
                visualstyle = value;
                OnPropertyChanged("VisualStyle");
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

        public void PropertyGridLoaded(PropertiesViewModel model)
        {
            DockingManager dockingmanager = (((App.Current.MainWindow as ShellView).Docking.Content as DockingAdapterView).DockingAdapter.Content as Grid).Children[0] as Syncfusion.Windows.Tools.Controls.DockingManager;
            VisualStyle = (dockingmanager != null) ? SkinStorage.GetVisualStyle(dockingmanager) : "Default";
        }
    }
}
