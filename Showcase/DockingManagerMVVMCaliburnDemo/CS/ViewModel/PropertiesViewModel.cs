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
