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
