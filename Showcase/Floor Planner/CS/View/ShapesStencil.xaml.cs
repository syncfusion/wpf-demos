#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Controls;
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
    public sealed partial class ShapesStencil : UserControl
    {
        public ShapesStencil()
        {
            this.InitializeComponent();
            //MyStencil = stencil;
          //  stencil.SelectedFilter = new Syncfusion.UI.Xaml.Diagram.Stencil.SymbolFilterProvider() { Content = "Test", Filter = Filter };
        }

        private bool Filter(Syncfusion.UI.Xaml.Diagram.Stencil.SymbolFilterProvider sender, Syncfusion.UI.Xaml.Diagram.Stencil.ISymbol symbol)
        {
            return true;
        }

        public Stencil MyStencil { get; set; }


       
    }
}
