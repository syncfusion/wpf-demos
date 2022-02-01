#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.diagrambuilder.wpf.ViewModel
{
    public class BlankStencilVM
    {
        public SymbolFilters SymbolFilters { get; set; }

        public SymbolFilterProvider SelectedFilter { get; set; }

        public BlankStencilVM()
        {
            SymbolFilters = new SymbolFilters();

            SymbolFilterProvider inputshapes = new SymbolFilterProvider { Content = "Basic Shapes", SymbolFilter = Filter };
            SymbolFilterProvider outputhapes = new SymbolFilterProvider { Content = "Flow Shapes", SymbolFilter = Filter };
            SymbolFilterProvider logicgateshapes = new SymbolFilterProvider { Content = "Arrow", SymbolFilter = Filter };
            SymbolFilterProvider flipflophapes = new SymbolFilterProvider { Content = "DataFlow", SymbolFilter = Filter };
            SymbolFilterProvider othershapes = new SymbolFilterProvider { Content = "UML Activity", SymbolFilter = Filter };
            SymbolFilterProvider electricalshapes = new SymbolFilterProvider { Content = "Electrical Shapes", SymbolFilter = Filter };

            this.SymbolFilters.Add(inputshapes);
            this.SymbolFilters.Add(outputhapes);
            this.SymbolFilters.Add(logicgateshapes);
            this.SymbolFilters.Add(flipflophapes);
            this.SymbolFilters.Add(othershapes);
            this.SymbolFilters.Add(electricalshapes);
            this.SelectedFilter = SymbolFilters[0];
        }

        private bool Filter(SymbolFilterProvider sender, object symbol)
        {
            if (sender.Content.ToString() == (symbol as NodeViewModel).Key.ToString())
            {
                return true;
            }
            return false;
        }
    }
}
