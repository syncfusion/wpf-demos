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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.diagramdemo.wpf.ViewModel
{
    public class StencilViewModel : DiagramViewModel
    {
        public StencilViewModel()
        {
            Symbolfilters = new SymbolFilters();

            SymbolFilterProvider node1 = new SymbolFilterProvider { Content = "Basic Shapes", IsChecked = true, SymbolFilter = Filter };
            SymbolFilterProvider node2 = new SymbolFilterProvider { Content = "Flow Shapes", IsChecked = true, SymbolFilter = Filter };
            SymbolFilterProvider node3 = new SymbolFilterProvider { Content = "Arrow Shapes", IsChecked = true, SymbolFilter = Filter };
            SymbolFilterProvider node4 = new SymbolFilterProvider { Content = "DataFlow Shapes", SymbolFilter = Filter };
            SymbolFilterProvider node5 = new SymbolFilterProvider { Content = "UMLActivity Shapes", SymbolFilter = Filter };
            SymbolFilterProvider node6 = new SymbolFilterProvider { Content = "UMLUseCase Shapes", SymbolFilter = Filter };
            SymbolFilterProvider node7 = new SymbolFilterProvider { Content = "UMLRelationship Shapes", SymbolFilter = Filter };
            SymbolFilterProvider node8 = new SymbolFilterProvider { Content = "Swimlane Shapes", SymbolFilter = Filter };
            SymbolFilterProvider node9 = new SymbolFilterProvider { Content = "BPMNEditor Shapes", SymbolFilter = Filter };
            this.Symbolfilters.Add(node1);
            this.Symbolfilters.Add(node2);
            this.Symbolfilters.Add(node3);
            this.Symbolfilters.Add(node4);
            this.Symbolfilters.Add(node5);
            this.Symbolfilters.Add(node6);
            this.Symbolfilters.Add(node7);
            this.Symbolfilters.Add(node8);
            this.Symbolfilters.Add(node9);
            this.Selectedfilter = Symbolfilters[0];
        }

        // Define filtering of Symbols
        private bool Filter(SymbolFilterProvider sender, object symbol)
        {
            if (symbol is NodeViewModel && (symbol as NodeViewModel).ParentGroup == null)
            {
                if (sender.Content.ToString() == (symbol as NodeViewModel).Key.ToString())
                    return true;
            }
            if (symbol is LaneViewModel)
            {
                if (sender.Content.ToString() == (symbol as LaneViewModel).Key.ToString())
                    return true;
            }
            if (symbol is PhaseViewModel)
            {
                if (sender.Content.ToString() == (symbol as PhaseViewModel).Key.ToString())
                    return true;
            }
            if (symbol is ConnectorViewModel)
            {
                if (sender.Content.ToString() == (symbol as ConnectorViewModel).Key.ToString())
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
