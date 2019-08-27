#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using System.Collections.ObjectModel;
using DiagramBuilder.ViewModel;
using Syncfusion.UI.Xaml.Diagram;
using System.Windows.Controls;
using System.Windows.Input;
using DiagramBuilder.Utility;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DiagramBuilder.View
{
    public sealed partial class StencilView : UserControl
    {
        public StencilView()
        {
            this.InitializeComponent();
            HeaderVisibility = new Command(OnHeaderVisibilityCommand);
            ShowSymbolGroup = new Command(OnShowSymbolGroupCommand);
        }

        //private void GetParent(object sender, out Grid g)
        //{
        //    var parent = VisualTreeHelper.GetParent(sender as DependencyObject);

        //    if (parent.GetType() == typeof(Grid))
        //    {
        //        if ((parent as Grid).Name == "rootgrid")
        //        {
        //            g = (parent as Grid);
        //        }
        //        else
        //        {
        //            GetParent(parent, out g);
        //        }
        //    }

        //    else
        //    {
        //        GetParent(parent, out g);
        //    }
        //}

        public ICommand HeaderVisibility
        {
            get;
            set;
        }

        public ICommand ShowSymbolGroup
        {
            get;
            set;
        }

        public void OnHeaderVisibilityCommand(object param)
        {
            if (stencil.DataContext != null)
            {
                if (param.ToString().Equals("Expand"))
                {
                    this.stencil.HeaderVisibility = System.Windows.Visibility.Visible;
                    SymbolFilterProvider all = new SymbolFilterProvider { SymbolFilter = (this.stencil.DataContext as StencilVM).Filter, Content = "All" };
                    (this.stencil.DataContext as StencilVM).SelectedFilter = all;
                }
                else if (param.ToString().Equals("Collapse"))
                {
                    this.stencil.HeaderVisibility = System.Windows.Visibility.Collapsed;
                    SymbolFilterProvider basicShapes = new SymbolFilterProvider { SymbolFilter = (this.stencil.DataContext as StencilVM).Filter, Content = "Basic Shapes" };
                    (this.stencil.DataContext as StencilVM).SelectedFilter = basicShapes;
                }
            }
        }

        public void OnShowSymbolGroupCommand(object param)
        {
            if (stencil.DataContext != null)
            {
                if (param.ToString().Equals("Basic Shapes"))
                {
                    SymbolFilterProvider basicShapes = new SymbolFilterProvider { SymbolFilter = (this.stencil.DataContext as StencilVM).Filter, Content = "Basic Shapes" };
                    (this.stencil.DataContext as StencilVM).SelectedFilter = basicShapes;
                }
                else if (param.ToString().Equals("Flow Shapes"))
                {
                    SymbolFilterProvider flowShapes = new SymbolFilterProvider { SymbolFilter = (this.stencil.DataContext as StencilVM).Filter, Content = "Flow Shapes" };
                    (this.stencil.DataContext as StencilVM).SelectedFilter = flowShapes;
                }
                else if (param.ToString().Equals("BPMN Shapes"))
                {
                    SymbolFilterProvider basicShapes = new SymbolFilterProvider { SymbolFilter = (this.stencil.DataContext as StencilVM).Filter, Content = "BPMN Shapes" };
                    (this.stencil.DataContext as StencilVM).SelectedFilter = basicShapes;
                }
                else if (param.ToString().Equals("Electrical"))
                {
                    SymbolFilterProvider basicShapes = new SymbolFilterProvider { SymbolFilter = (this.stencil.DataContext as StencilVM).Filter, Content = "Electrical" };
                    (this.stencil.DataContext as StencilVM).SelectedFilter = basicShapes;
                }
                else if (param.ToString().Equals("Arrow"))
                {
                    SymbolFilterProvider basicShapes = new SymbolFilterProvider { SymbolFilter = (this.stencil.DataContext as StencilVM).Filter, Content = "Arrow" };
                    (this.stencil.DataContext as StencilVM).SelectedFilter = basicShapes;
                }
            }
        }
    }
}
