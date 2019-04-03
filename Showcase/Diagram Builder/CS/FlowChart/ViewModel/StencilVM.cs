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
using System.Threading.Tasks;
using DiagramBuilder.ViewModel;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Diagram.Stencil;

namespace FlowChart.ViewModel
{
    public class FlowChartStencilVM : StencilVM
    {
        public FlowChartStencilVM()
        {
            SymbolFilterProvider flowShapes = new SymbolFilterProvider { SymbolFilter = Filter, Content = "Flow Shapes" };
            Filters = new ObservableCollection<SymbolFilterProvider>()
            {
                flowShapes
            };
            SelectedFilter = flowShapes;
        }
    }
}
