#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class GettingStartedViewModel : NotificationObject
    {
        public GettingStartedViewModel()
        {
            this.OptionCommand = new DelegateCommand<object>(Execute);
            this.CloseCommand = new DelegateCommand<object>(CloseCommandExecute);
        }

        private void CloseCommandExecute(object obj)
        {
            string closingtabs = "";
            WindowClosingEventArgs windowClosingEventArgs = obj as WindowClosingEventArgs;
            CloseTabEventArgs closeTabEventArgs = obj as CloseTabEventArgs;
            List<object> closingItems = null;
            if (closeTabEventArgs != null)
            {
                closingItems = closeTabEventArgs.ClosingTabItems.Select(a => a).ToList();
            }

            MessageBoxResult result = MessageBox.Show("Do you want to close the tabs? ", "Closing Tabs", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (closeTabEventArgs != null && closingItems != null)
                {
                    for (int i = 0; i < closingItems.Count; i++)
                    {
                        TabItemExt tabitem = closingItems[i] as TabItemExt;
                        if (tabitem.Content != null && (tabitem.Content as ContentPresenter) != null)
                        {
                            ContentPresenter presenter = tabitem.Content as ContentPresenter;
                            if (presenter != null && presenter.Content != null)
                            {
                                closingtabs = closingtabs + "\n\t" + DockingManager.GetHeader(presenter.Content as DependencyObject);
                            }
                        }
                    }

                    closingItems.Clear();
                }
                else
                {
                    closingtabs = closingtabs + "\n\t" + DockingManager.GetHeader(windowClosingEventArgs.TargetItem);
                }

                this.Text = this.Text + "Closed Tabs" + " : " + closingtabs + "\n";
            }
            else if (result == MessageBoxResult.No)
            {
                (obj as CloseTabEventArgs).Cancel = true;
            }
        }

        private void Execute(object obj)
        {
            if(obj != null)
            {
                switch (obj.ToString())
                {
                    case "NormalDragging":
                    case "ShadowDragging":
                    case "BorderDragging":
                        {
                            this.DraggingType = (DraggingType)Enum.Parse(typeof(DraggingType), obj.ToString());
                            break;
                        }
                    case "Default":
                    case "VS2010":
                        {
                            this.DockBehavior = (DockBehavior)Enum.Parse(typeof(DockBehavior), obj.ToString());
                            break;
                        }                   
                    case "Left":
                    case "Top":
                    case "Right":
                    case "Bottom":
                        {
                            this.TabAlignment = (Dock)Enum.Parse(typeof(Dock), obj.ToString());
                            break;
                        }
                }
            }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                this.RaisePropertyChanged(nameof(this.Text));
            }
        }

        private Dock tabAlignment = Dock.Bottom;

        public Dock TabAlignment
        {
            get { return tabAlignment; }
            set { tabAlignment = value; this.RaisePropertyChanged(nameof(this.TabAlignment)); }
        }

        private DraggingType draggingType = DraggingType.NormalDragging;

        public DraggingType DraggingType
        {
            get { return draggingType; }
            set
            {
                draggingType = value;
                this.RaisePropertyChanged(nameof(this.DraggingType));
            }
        }

        private DockBehavior dockBehavior = DockBehavior.Default;

        public DockBehavior DockBehavior
        {
            get { return dockBehavior; }
            set
            {
                dockBehavior = value;
                this.RaisePropertyChanged(nameof(DockBehavior));
            }
        }

        private bool enableFlatLayout;

        public bool EnableFlatLayout
        {
            get { return enableFlatLayout; }
            set
            {
                enableFlatLayout = value;
                this.RaisePropertyChanged(nameof(this.EnableFlatLayout));
            }
        }


        private bool enableSnappingFloatWindow = false;

        public bool EnableSnappingFloatWindow
        {
            get 
            { 
                return enableSnappingFloatWindow; 
            }
            set
            {
                if (enableSnappingFloatWindow != value)
                {
                    enableSnappingFloatWindow = value;
                    this.RaisePropertyChanged(nameof(this.EnableSnappingFloatWindow));
                }
            }
        }

        private bool canDrag = true;

        public bool CanDrag
        {
            get 
            {
                return canDrag; 
            }
            set
            {
                canDrag = value;
                this.RaisePropertyChanged(nameof(this.CanDrag));
            }
        }

        private bool allowSnap;

        public bool AllowSnap
        {
            get { return allowSnap; }
            set { allowSnap = value; this.RaisePropertyChanged(nameof(this.AllowSnap)); }
        }

        private ICommand clickCommand;

        public ICommand OptionCommand
        {
            get { return clickCommand; }
            set { clickCommand = value; this.RaisePropertyChanged(nameof(this.OptionCommand)); }
        }

        private ICommand close;

        public ICommand CloseCommand
        {
            get { return close; }
            set { close = value; }
        }

    }
}
