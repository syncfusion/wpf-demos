#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInteraction_Stencil.Viewmodel
{
    public class StencilVM : DiagramViewModel
    {
        public StencilVM()
        {
            Symbolfilters = new SymbolFilters();

            SymbolFilterProvider all = new SymbolFilterProvider { Content = "All", SymbolFilter = Filter };
            SymbolFilterProvider basicshapes = new SymbolFilterProvider { Content = "Basic Shapes", SymbolFilter = Filter };
            SymbolFilterProvider flowshapes = new SymbolFilterProvider { Content = "Flow Shapes", SymbolFilter = Filter };
            SymbolFilterProvider arrowshapes = new SymbolFilterProvider { Content = "Arrow Shapes", SymbolFilter = Filter };

            this.Symbolfilters.Add(all);
            this.Symbolfilters.Add(basicshapes);
            this.Symbolfilters.Add(flowshapes); 
            this.Symbolfilters.Add(arrowshapes);
            this.Selectedfilter = Symbolfilters[0];
        }

        // Define filtering of Symbols
        private bool Filter(SymbolFilterProvider sender, object symbol)
        {            
            if (sender.Content.ToString() == "All")
            {
                return true;
            }
            if(sender.Content.ToString() == (symbol as NodeViewModel).Key.ToString())
            {
                return true;
            }
            if (sender.Content.ToString() == (symbol as NodeViewModel).Key.ToString())
            {
                return true;
            }
            if (sender.Content.ToString() == (symbol as NodeViewModel).Key.ToString())
            {
                return true;
            }
            return false;
        }
        public ObservableCollection<SymbolFilterProvider> Symbolfilters { get; set; }

        public SymbolFilterProvider Selectedfilter { get; set; }
    }
}
