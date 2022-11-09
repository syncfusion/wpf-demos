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
using System.Windows;

namespace syncfusion.diagrambuilder.wpf.LogicCircuit
{
    public class LogicCircuitStencilVM
    {
        public SymbolFilters SymbolFilters { get; set; }

        public SymbolFilterProvider SelectedFilter { get; set; }

        private SymbolCollection _symbolsource;

        public SymbolCollection SymbolSource
        {
            get
            {
                return _symbolsource;
            }
            set
            {
                if (value != null && value != _symbolsource)
                {
                    _symbolsource = value;
                }
            }
        }

        public LogicCircuitStencilVM()
        {
            GetSymbols();

            SymbolFilters = new SymbolFilters();

            SymbolFilterProvider all = new SymbolFilterProvider { Content = "All", SymbolFilter = Filter };
            SymbolFilterProvider inputshapes = new SymbolFilterProvider { Content = "Input Controls", SymbolFilter = Filter };
            SymbolFilterProvider outputhapes = new SymbolFilterProvider { Content = "Output Controls", SymbolFilter = Filter };
            SymbolFilterProvider logicgateshapes = new SymbolFilterProvider { Content = "Logic Gates", SymbolFilter = Filter };
            SymbolFilterProvider flipflophapes = new SymbolFilterProvider { Content = "Flip-Flops", SymbolFilter = Filter };
            SymbolFilterProvider othershapes = new SymbolFilterProvider { Content = "Other", SymbolFilter = Filter };

            this.SymbolFilters.Add(all);
            this.SymbolFilters.Add(inputshapes);
            this.SymbolFilters.Add(outputhapes);
            this.SymbolFilters.Add(logicgateshapes);
            this.SymbolFilters.Add(flipflophapes);
            this.SymbolFilters.Add(othershapes);
            this.SelectedFilter = SymbolFilters[0];
        }

        private void GetSymbols()
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(@"/syncfusion.diagrambuilder.wpf;component/LogicCircuit/LogicCircuitResources.xaml", UriKind.RelativeOrAbsolute)
            };

            SymbolSource = resourceDictionary["SymbolSource"] as SymbolCollection;
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
