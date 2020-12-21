#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace syncfusion.gridcontroldemos.wpf
{
    public class AdvancedDataTemplateCellViewModel
    {
        private IAdvancedDataTemplateCell mainView;

        public AdvancedDataTemplateCellViewModel(IAdvancedDataTemplateCell mainView)
        {
            this.mainView = mainView;
            Initialize();
        }

        public IAdvancedDataTemplateCell MainView
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
                //if (!LayoutControl.IsInDesignMode)
                //{
                    var list = Queries.GetHoldingsList();
                    return list;
                //}
                //else
                //    return null;
            }
        }

        private void Initialize()
        {
            if (MainView != null)
                MainView.Initialize();
        }
    }
}
