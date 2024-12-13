#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
        private SymbolSelectionMode symbolSelectionMode = SymbolSelectionMode.Multiple;
        private SymbolGroupDisplayMode symbolGroupDisplayMode = SymbolGroupDisplayMode.List;
        private SymbolsDisplayMode symbolDisplayMode = SymbolsDisplayMode.IconsOnly;
        private DisplayMode displayMode = DisplayMode.Expanded;
        private bool showSearchTextBox = true;
        private bool showDisplayModeToggleButton = true;
        private bool showPreview = false;
        private bool enableReorder = true;
        private StencilConstraints stencilConstraints = StencilConstraints.Default;

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
        public SymbolSelectionMode SymbolSelectionMode
        {
            get
            {
                return symbolSelectionMode;
            }
            set
            {
                symbolSelectionMode = value;
                OnPropertyChanged("SymbolSelectionMode");
            }
        }

        public SymbolGroupDisplayMode SymbolGroupDisplayMode
        {
            get
            {
                return symbolGroupDisplayMode;
            }
            set
            {
                symbolGroupDisplayMode = value;
                OnPropertyChanged("SymbolGroupDisplayMode");
            }

        }


        public SymbolsDisplayMode SymbolsDisplayMode
        {
            get
            {
                return symbolDisplayMode;
            }
            set
            {
                symbolDisplayMode = value;
                OnPropertyChanged("SymbolsDisplayMode");
            }
        }

        public DisplayMode DisplayMode
        {
            get
            {
                return displayMode;
            }
            set
            {
                displayMode = value;
                OnPropertyChanged("DisplayMode");
            }
        }

        public bool ShowSearchTextBox
        {
            get
            {
                return showSearchTextBox;
            }
            set
            {
                showSearchTextBox = value;
                OnPropertyChanged("ShowSearchTextBox");
            }
        }

        public bool ShowDisplayModeToggleButton
        {
            get
            {
                return showDisplayModeToggleButton;
            }
            set
            {
                showDisplayModeToggleButton = value;
                OnPropertyChanged("ShowDisplayModeToggleButton");
            }
        }

        public bool ShowPreview
        {
            get
            {
                return showPreview;
            }
            set
            {
                showPreview = value;
                OnPropertyChanged("ShowPreview");
            }
        }

        public bool EnableReorder
        {
            get
            {
                return enableReorder;
            }
            set
            {
                enableReorder = value;
                OnPropertyChanged("EnableReorder");
            }
        }

        public StencilConstraints StencilConstraints
        {
            get
            {
                return stencilConstraints;
            }
            set
            {
                stencilConstraints = value;
                OnPropertyChanged("StencilConstraints");
            }
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            switch (name)
            {
                case "ShowPreview":
                    if (this.StencilConstraints.Contains(StencilConstraints.ShowPreview))
                    {
                        this.StencilConstraints &= ~StencilConstraints.ShowPreview;
                    }
                    else
                    {
                        this.StencilConstraints |= StencilConstraints.ShowPreview;
                    }
                    break;

                case "EnableReorder":
                    if (this.StencilConstraints.Contains(StencilConstraints.AllowDragDrop))
                    {
                        this.StencilConstraints &= ~StencilConstraints.AllowDragDrop;
                    }
                    else
                    {
                        this.StencilConstraints |= StencilConstraints.AllowDragDrop;
                    }
                    break;
            }
        }
    }
}
