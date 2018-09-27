using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;

namespace ScrollableAutoHiddenPanelDemo
{
    public class MenuCommand
    {
        private ICommand btnmode;

        public ICommand BtnMode
        {
            get { return btnmode; }
            set { btnmode = value; }
        }
        public MenuCommand()
        {
            btnmode = new DelegateCommand<object>(MenuCommandExecuted);
        }

        private void MenuCommandExecuted(object obj)
        {
            if (obj.ToString() == "Normal")
                (App.Current.MainWindow as MainWindow).dockingManager.ScrollButtonMode = ScrollingButtonMode.Normal;
            else if (obj.ToString() == "Extended")
                (App.Current.MainWindow as MainWindow).dockingManager.ScrollButtonMode = ScrollingButtonMode.Extended;
        }
        
    }
}