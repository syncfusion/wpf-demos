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
using Syncfusion.Windows.Controls.Grid;

namespace PortfolioManager1.ViewModel
{
    public class MainViewModel
    {
        private IMainView mainView;

        public MainViewModel(IMainView mainView)
        {
            this.mainView = mainView;
            Initialize();
        }

        public IMainView MainView
        {
            get
            {
                return mainView;
            }
        }

        public List<Queries.CurrentHoldings> Holdings
        {
            get
            {
                if (!LayoutControl.IsInDesignMode)
                {
                    var list = Queries.GetHoldingsList();
                    return list;
                }
                else
                    return null;
            }
        }

        private void Initialize()
        {
            if (MainView != null)
                MainView.Initialize();
        }
    }
}
