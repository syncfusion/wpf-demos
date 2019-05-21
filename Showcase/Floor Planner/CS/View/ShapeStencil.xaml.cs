#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FloorPlanner
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShapeStencil : Grid
    {
        public ShapeStencil()
        {
            this.InitializeComponent();
            stencil.SelectedFilter = new SymbolFilterProvider() { SymbolFilter = Filter1, Content = "test" };
            stencil.Loaded += stencil_Loaded;
            stencil.Constraints = StencilConstraints.ShowPreview;
        }
        public FloorPlanSymbolGroup sg;
        void stencil_Loaded(object sender, RoutedEventArgs e)
        {
            //sg = stencil.FindDescendantByName("group") as FloorPlanSymbolGroup;
            //foreach (FloorPlanSymbolGroup f in sg.fsg)
            //{
            //    f.VModel = this.DataViewModel as FloorPlannerViewModel;
            //}
            //sg.VModel = this.DataViewModel as FloorPlannerViewModel;
            //stencil.Tag = this.DataViewModel;
        }
        public FloorPlannerViewModel DataViewModel
        {
            get { return (FloorPlannerViewModel)GetValue(DataViewModelProperty); }
            set { SetValue(DataViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataViewModelProperty =
            DependencyProperty.Register("DataViewModel", typeof(FloorPlannerViewModel), typeof(ShapeStencil), new PropertyMetadata(null, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //ShapeStencil c = d as ShapeStencil;
            //if (c.sg != null)
            //{
            //    c.sg.VModel = (FloorPlannerViewModel)e.NewValue;
            //}
        }
        private bool Filter1(SymbolFilterProvider sender, object symbol)
        {
            return true;
        }
    }
}
