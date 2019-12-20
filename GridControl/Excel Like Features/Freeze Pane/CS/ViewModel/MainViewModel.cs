#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;

namespace FreezePaneDemo.ViewModel
{
    public class MainViewModel
    {
        private IMainView mainView;
        public MainViewModel(IMainView mainView)
        {
            this.mainView = mainView;
            Initialize();
        }

        private void Initialize()
        {
            if (MainView != null)
                MainView.Initialize();
        }

        public IMainView MainView
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
