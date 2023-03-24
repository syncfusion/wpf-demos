#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class FlowDiagramViewModel : DiagramViewModel
    {
        public FlowDiagramViewModel()
        {
            Symbolfilters = new SymbolFilters();

            SymbolFilterProvider basicshapes = new SymbolFilterProvider { Content = "Basic Shapes",IsChecked = true,  SymbolFilter = Filter };
            SymbolFilterProvider flowshapes = new SymbolFilterProvider { Content = "Flow Shapes", IsChecked = true, SymbolFilter = Filter };
            SymbolFilterProvider dataflowshapes = new SymbolFilterProvider { Content = "DataFlow Shapes", IsChecked = true, SymbolFilter = Filter };
            SymbolFilterProvider arrowshapes = new SymbolFilterProvider { Content = "Arrow Shapes", SymbolFilter = Filter };

            this.Symbolfilters.Add(basicshapes);
            this.Symbolfilters.Add(flowshapes);
            this.symbolfilters.Add(dataflowshapes);
            this.Symbolfilters.Add(arrowshapes);
            this.Selectedfilter = Symbolfilters[0];
        }

        // Define filtering of Symbols
        private bool Filter(SymbolFilterProvider sender, object symbol)
        {
            if (sender.Content.ToString() == (symbol as NodeViewModel).Key.ToString())
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

        private SymbolFilters symbolfilters;

        public SymbolFilters Symbolfilters
        {
            get
            {
                return symbolfilters;
            }
            set
            {
                symbolfilters = value;
                OnPropertyChanged("Symbolfilters");
            }
        }

        private SymbolFilterProvider selectedfilter;

        public SymbolFilterProvider Selectedfilter
        {
            get
            {
                return selectedfilter;
            }
            set
            {
                selectedfilter = value;
                OnPropertyChanged("Selectedfilter");
            }
        }
    }
}
