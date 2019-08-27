#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.UI.Xaml.Diagram;

namespace DiagramBuilder.ViewModel
{
    public class StencilVM : DiagramElementViewModel
    {
        private SymbolFilterProvider _selectedFilter;
        private Syncfusion.UI.Xaml.Diagram.Stencil.Symbol _selectedSymbol = null;
        public StencilVM()
        {
            //List<SymbolVM> items = new List<SymbolVM>()
            //    {
            //        new SymbolVM() {Symbol = new TextBlock {Text = "AAA"}},
            //        new SymbolVM() {Symbol = new TextBlock {Text = "BBB"}},
            //        new SymbolVM() {Symbol = new TextBlock {Text = "CCC"}},
            //        new SymbolVM() {Symbol = new TextBlock {Text = "DDD"}},
            //        new SymbolVM() {Symbol = new TextBlock {Text = "EEE"}},
            //        new SymbolVM() {Symbol = new TextBlock {Text = "FFF"}},
            //        new SymbolVM() {Symbol = new TextBlock {Text = "GGG"}},
            //    };
            SymbolFilterProvider all = new SymbolFilterProvider { SymbolFilter = All, Content = "All" };
            SymbolFilterProvider basicShapes = new SymbolFilterProvider { SymbolFilter = Filter, Content = "Basic Shapes" };
            SymbolFilterProvider flowChart = new SymbolFilterProvider { SymbolFilter = Filter, Content = "Flow Chart" };
            SymbolFilterProvider electrical = new SymbolFilterProvider { SymbolFilter = Filter, Content = "Electrical" };
            SymbolFilterProvider connector = new SymbolFilterProvider { SymbolFilter = Filter, Content = "Connector" };
            SymbolFilterProvider flowShapes = new SymbolFilterProvider { SymbolFilter = Filter, Content = "Flow Shapes" };
            SymbolFilterProvider dataflowShapes = new SymbolFilterProvider { SymbolFilter = Filter, Content = "DataFlow" };
            SymbolFilterProvider umlActivity = new SymbolFilterProvider { SymbolFilter = Filter, Content = "UML Activity" };
            SymbolFilterProvider umlRelationship = new SymbolFilterProvider { SymbolFilter = Filter, Content = "UML Relationship" };
            SymbolFilterProvider umlUsecase = new SymbolFilterProvider { SymbolFilter = Filter, Content = "UML UseCase" };


            Filters = new ObservableCollection<SymbolFilterProvider>()
            {
                all,
                basicShapes,
                flowChart,
                electrical,
                connector,
                flowShapes,
                dataflowShapes,
                umlActivity,
                umlRelationship,
                umlUsecase
            };
            SelectedFilter = all;
        }

        public SymbolFilterProvider SelectedFilter
        {
            get { return _selectedFilter; }
            set
            {
                if (_selectedFilter != value)
                {
                    _selectedFilter = value;
                    OnPropertyChanged("SelectedFilter");
                }
            }
        }

        public Syncfusion.UI.Xaml.Diagram.Stencil.Symbol SelectedSymbol
        {
            get { return _selectedSymbol; }
            set
            {
                if (_selectedSymbol != value)
                {
                    _selectedSymbol = value;
                    OnPropertyChanged("SelectedSymbol");
                }
            }
        }


        public IEnumerable<SymbolFilterProvider> Filters { get; set; }

        public object Test(object key)
        {
            return key;
        }

        public bool All(SymbolFilterProvider source, object symbol)
        {
            //if ((symbol.Symbol as TextBlock).Text == "AAA")
            //{
            //    return false;
            //}

            return true;
        }

        public bool Filter(SymbolFilterProvider symbol, object sender)
        {
            if (symbol.Content.ToString() == "All")
            {
                return true;
            }
            if ((sender as NodeVM).Key.Equals(symbol.Content.ToString()))
            {
                return true;
            }
            return false;

        }
    }
}