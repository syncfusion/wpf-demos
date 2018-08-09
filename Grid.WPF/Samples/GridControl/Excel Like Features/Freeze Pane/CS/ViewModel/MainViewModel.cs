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
