// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlowChartStencilVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the stencil class for flow chart.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FlowChart.ViewModel
{
    using System.Collections.ObjectModel;

    using DiagramBuilder.ViewModel;

    using Syncfusion.UI.Xaml.Diagram.Stencil;

    /// <summary>
    ///     Represents the stencil class for flow chart.
    /// </summary>
    public class FlowChartStencilVM : StencilVm
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FlowChartStencilVM" /> class.
        /// </summary>
        public FlowChartStencilVM()
        {
            SymbolFilterProvider flowShapes =
                new SymbolFilterProvider { SymbolFilter = this.Filter, Content = "Flow Shapes" };
            this.Filters = new ObservableCollection<SymbolFilterProvider> { flowShapes };
            this.SelectedFilter = flowShapes;
        }
    }
}