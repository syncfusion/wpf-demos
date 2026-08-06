using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Stencil;

namespace syncfusion.diagrambuilder.wpf.Network
{
    public class NetworkStencilVM
    {
        public SymbolFilters Symbolfilters { get; set; }

        public SymbolFilterProvider Selectedfilter { get; set; }

        public NetworkStencilVM()
        {
            Symbolfilters = new SymbolFilters();

            SymbolFilterProvider all = new SymbolFilterProvider { Content = "All", SymbolFilter = Filter };
            SymbolFilterProvider computershapes = new SymbolFilterProvider { Content = "Computers and Moniters", SymbolFilter = Filter };
            SymbolFilterProvider networkshapes = new SymbolFilterProvider { Content = "Network and Peripherals", SymbolFilter = Filter };

            Symbolfilters.Add(all);
            Symbolfilters.Add(computershapes);
            Symbolfilters.Add(networkshapes);
            Selectedfilter = Symbolfilters[0];
        }
        private bool Filter(SymbolFilterProvider sender, object symbol)
        {
            if (sender.Content.ToString() == "All")
            {
                return true;
            }
            if (sender.Content.ToString() == (symbol as NodeViewModel).Key.ToString())
            {
                return true;
            }
            return false;
        }

    }
}
