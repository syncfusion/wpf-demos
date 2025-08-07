#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for Serialization.xaml
    /// </summary>
    public partial class Serialization : DemoControl
    {
        public Serialization()
        {
            InitializeComponent();
        }

        public Serialization(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            if (this.diagram != null)
            {
                this.diagram = null;
            }
            if (this.stencil != null)
            {
                if (this.stencil.SymbolGroups != null)
                {
                    foreach (SymbolGroupViewModel viewModel in this.stencil.SymbolGroups)
                    {
                        viewModel.Menu = null;
                        viewModel.CategorySource = null;
                    }
                    this.stencil.SymbolGroups.Clear();
                    this.stencil.SymbolGroups = null;
                }
                if (this.stencil.SymbolSource != null)
                {
                    if (this.stencil.SymbolSource is SymbolCollection)
                    {
                        (this.stencil.SymbolSource as SymbolCollection).Clear();
                    }
                    this.stencil.SymbolSource = null;
                }
                this.stencil.DataContext = null;
                this.stencil = null;
            }
            base.Dispose(disposing);
        }
    }
}
