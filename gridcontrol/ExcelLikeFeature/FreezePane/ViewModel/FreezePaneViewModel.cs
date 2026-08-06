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
