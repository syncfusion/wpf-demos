#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace syncfusion.floorplanner.wpf
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateStencil : Grid
    {
        public CreateStencil()
        {
            this.InitializeComponent();
            floorplanstencil.SymbolFilters = new SymbolFilters();
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "All", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "Basic Shapes", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "Kitchen", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "Dining Room", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "Living Room", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "BathRoom", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "BedRoom", SymbolFilter = Filter });
            floorplanstencil.SymbolFilters.Add(new SymbolFilterProvider { Content = "Doors", SymbolFilter = Filter });

            floorplanstencil.SelectedFilter = floorplanstencil.SymbolFilters[0];
        }

        public FloorPlannerViewModel DataViewModel
        {
            get { return (FloorPlannerViewModel)GetValue(DataViewModelProperty); }
            set { SetValue(DataViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataViewModelProperty =
            DependencyProperty.Register("DataViewModel", typeof(FloorPlannerViewModel), typeof(CreateStencil), new PropertyMetadata(null, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CreateStencil c = d as CreateStencil;
        }

        private bool Filter(SymbolFilterProvider sender, object symbol)
        {
            if (sender.Content.ToString() == "All")
            {
                return true;
            }
            if ((symbol as FloorPlanSymbolItem).GroupName.Equals(sender.Content.ToString()))
            {
                return true;
            }
            return false;
        }
    }

    public class FloorPlanSymbolGroup : SymbolGroup
    {

    }
}
