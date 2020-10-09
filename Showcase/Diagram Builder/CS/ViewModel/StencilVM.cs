// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StencilVM.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the collection of Filters in Stencil.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Syncfusion.UI.Xaml.Diagram;
    using Syncfusion.UI.Xaml.Diagram.Stencil;

    /// <summary>
    ///     Represents the collection of Filters in Stencil.
    /// </summary>
    public class StencilVm : DiagramElementViewModel
    {
        /// <summary>
        ///     Represents the filter which need to be in selected state by default.
        /// </summary>
        private SymbolFilterProvider selectedFilter;

        /// <summary>
        ///     Represents the _selected symbol.
        /// </summary>
        private Symbol selectedSymbol;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StencilVm" /> class.
        /// </summary>
        public StencilVm()
        {
            SymbolFilterProvider all = new SymbolFilterProvider { SymbolFilter = this.All, Content = "All" };
            SymbolFilterProvider basicShapes = new SymbolFilterProvider
                                                   {
                                                       SymbolFilter = this.Filter, Content = "Basic Shapes"
                                                   };
            SymbolFilterProvider flowChart =
                new SymbolFilterProvider { SymbolFilter = this.Filter, Content = "Flow Chart" };
            SymbolFilterProvider electrical =
                new SymbolFilterProvider { SymbolFilter = this.Filter, Content = "Electrical" };
            SymbolFilterProvider connector =
                new SymbolFilterProvider { SymbolFilter = this.Filter, Content = "Connector" };
            SymbolFilterProvider flowShapes =
                new SymbolFilterProvider { SymbolFilter = this.Filter, Content = "Flow Shapes" };
            SymbolFilterProvider dataFlowShapes = new SymbolFilterProvider
                                                      {
                                                          SymbolFilter = this.Filter, Content = "DataFlow"
                                                      };
            SymbolFilterProvider umlActivity = new SymbolFilterProvider
                                                   {
                                                       SymbolFilter = this.Filter, Content = "UML Activity"
                                                   };
            SymbolFilterProvider umlRelationship = new SymbolFilterProvider
                                                       {
                                                           SymbolFilter = this.Filter, Content = "UML Relationship"
                                                       };
            SymbolFilterProvider umlUseCase =
                new SymbolFilterProvider { SymbolFilter = this.Filter, Content = "UML UseCase" };

            this.Filters = new ObservableCollection<SymbolFilterProvider>
                               {
                                   all,
                                   basicShapes,
                                   flowChart,
                                   electrical,
                                   connector,
                                   flowShapes,
                                   dataFlowShapes,
                                   umlActivity,
                                   umlRelationship,
                                   umlUseCase
                               };
            this.SelectedFilter = all;
        }

        /// <summary>
        ///     Gets or sets the filters.
        /// </summary>
        public IEnumerable<SymbolFilterProvider> Filters { get; set; }

        /// <summary>
        ///     Gets or sets the selected filter.
        /// </summary>
        public SymbolFilterProvider SelectedFilter
        {
            get
            {
                return this.selectedFilter;
            }

            set
            {
                if (this.selectedFilter != value)
                {
                    this.selectedFilter = value;
                    this.OnPropertyChanged("SelectedFilter");
                }
            }
        }

        /// <summary>
        ///     Gets or sets the selected symbol.
        /// </summary>
        public Symbol SelectedSymbol
        {
            get
            {
                return this.selectedSymbol;
            }

            set
            {
                if (this.selectedSymbol != value)
                {
                    this.selectedSymbol = value;
                    this.OnPropertyChanged("SelectedSymbol");
                }
            }
        }

        /// <summary>
        /// The all.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="symbol">
        /// The symbol.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool All(SymbolFilterProvider source, object symbol)
        {
            return true;
        }

        /// <summary>
        /// The filter.
        /// </summary>
        /// <param name="symbol">
        /// The symbol.
        /// </param>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Filter(SymbolFilterProvider symbol, object sender)
        {
            if (symbol.Content.ToString() == "All")
            {
                return true;
            }

            if (sender != null && ((NodeVM)sender).Key.Equals(symbol.Content.ToString()))
            {
                return true;
            }

            return false;
        }
    }
}