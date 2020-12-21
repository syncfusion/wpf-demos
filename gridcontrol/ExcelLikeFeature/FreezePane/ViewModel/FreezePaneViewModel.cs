#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;

namespace syncfusion.gridcontroldemos.wpf
{
    public class FreezePanelViewModel
    {
        private IFreezePanel mainView;
        public FreezePanelViewModel(IFreezePanel mainView)
        {
            this.mainView = mainView;
            Initialize();
        }

        private void Initialize()
        {
            if (MainView != null)
                MainView.Initialize();
        }

        public IFreezePanel MainView
        {
            get
            {
                return mainView;
            }
        }

        #region Command

        private DelegateCommand<object> freezePaneCommand;
        public DelegateCommand<object> FreezePaneCommand
        {
            get
            {
                if (freezePaneCommand == null)
                    freezePaneCommand = new DelegateCommand<object>(OnExecuteFreezePaneCommand);
                return freezePaneCommand;
            }
        }

        private void OnExecuteFreezePaneCommand(object param)
        {
            if (MainView != null)
            {
                MainView.SetFreezePane();
            }
        }

        #endregion
    }
}
