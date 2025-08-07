#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.Windows.Tools.Controls;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class MDIViewModel: NotificationObject
    {
        private SwitchMode switchMode= SwitchMode.Immediate;       

        public SwitchMode SwitchMode
        {
            get { return switchMode; }
            set
            {
                switchMode = value;
                this.RaisePropertyChanged(nameof(this.SwitchMode));
            }
        }

        public ICommand MDILayoutChangedCommand { get; set; }

        public MDIViewModel()
        {
            MDILayoutChangedCommand = new DelegateCommand<object>(MDILayoutChanged);
        }

        private void MDILayoutChanged(object obj)
        {
            object[] parameters = obj as object[];
            if (parameters[0] != null && parameters[1] != null && parameters[1] is DockingManager)
            {
                if ((parameters[1] as DockingManager).DocContainer == null)
                {
                    return;
                }

                if(parameters[0].ToString() == "Cascade")
                {
                    ((parameters[1] as DockingManager).DocContainer as DocumentContainer).SetLayout(MDILayout.Cascade);
                }
                else if (parameters[0].ToString() == "Horizontal")
                {
                    ((parameters[1] as DockingManager).DocContainer as DocumentContainer).SetLayout(MDILayout.Horizontal);
                }
                else if (parameters[0].ToString() == "Vertical")
                {
                    ((parameters[1] as DockingManager).DocContainer as DocumentContainer).SetLayout(MDILayout.Vertical);
                }
            }
        }
    }
}
