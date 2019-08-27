#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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