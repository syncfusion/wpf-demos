#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public partial class DockingManagerlikeVisualStudioViewModel : NotificationObject
    {
        private DockingManager dockingManager = null;

        /// <summary>
        /// Gets or sets the current active mode
        /// </summary>
        public VisualStudioMode CurrentMode { get; set; }

        public DockingManager DockingManager
        {
            get
            {
                return dockingManager;
            }
            set
            {
                dockingManager = value;
                this.RaisePropertyChanged(nameof(DockingManager));
            }

        }

        public ICommand RunButtonClickCommand { get; set; }
        public ICommand ResetButtonClickCommand { get; set; }
        public ICommand LoadedCommand { get; set; }
        public ICommand UnLoadedCommand { get; set; }

        public DockingManagerlikeVisualStudioViewModel()
        {
            RunButtonClickCommand = new DelegateCommand<object>(OnRunButtonClicked);
            ResetButtonClickCommand = new DelegateCommand<object>(OnResetLayoutClicked);
            LoadedCommand = new DelegateCommand<object>(OnLoaded);
            UnLoadedCommand = new DelegateCommand<object>(OnUnLoaded);
        }

        //Based on the mode, set the save and load current layout file path
        private void OnRunButtonClicked(object sender)
        {
            object[] parameters = sender as object[];
            if (parameters[0] is Button && parameters[1] is DockingManager)
            {
                DockingManager = parameters[1] as DockingManager;

                string layout_Header = (parameters[0] as Button).Content.ToString();

                //Saving the current Edit mode layout and loading the Run mode layout
                if (layout_Header == "Run")
                {
                    (parameters[0] as Button).Content = "Stop";
                    CurrentMode = VisualStudioMode.RunMode;
                    Save(currentEditLayout, DockingManager);
                    Switch(CurrentMode);
                }

                //Saving the current Run mode layout and loading the Edit mode layout
                else if (layout_Header == "Stop")
                {
                    (parameters[0] as Button).Content = "Run";
                    CurrentMode = VisualStudioMode.EditMode;
                    Save(currentRunLayout, DockingManager);
                    Switch(CurrentMode);
                }
            }
        }

        //Reset the current layout to default layout
        private void OnResetLayoutClicked(object sender)
        {
            string currentLayout;
            DockingManager = sender as DockingManager;

            //Resetting the current edit layout with default edit layout.
            ResetToDefaultLayout(currentEditLayout, defaultEditLayout);

            //Resetting the current run layout with default run layout.
            ResetToDefaultLayout(currentRunLayout, defaultRunLayout);

            if (CurrentMode == VisualStudioMode.RunMode)
            {
                currentLayout = currentRunLayout;
            }
            else
            {
                currentLayout = currentEditLayout;
            }

            Load(currentLayout, DockingManager);
        }

        //Check and load the currently saved Edit mode layout
        private void OnLoaded(object sender)
        {
            DockingManager = sender as DockingManager;
            Switch(CurrentMode);
        }

        //Saving the current mode layout
        private void OnUnLoaded(object sender)
        {
            string layoutPath;
            DockingManager = sender as DockingManager;

            //Save the current active mode layout while closing the application
            if (CurrentMode == VisualStudioMode.EditMode)
            {
                layoutPath = currentEditLayout;
            }
            else
            {
                layoutPath = currentRunLayout;
            }

            Save(layoutPath, DockingManager);
        }
    }
}
