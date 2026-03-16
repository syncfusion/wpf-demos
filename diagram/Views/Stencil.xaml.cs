#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using Syncfusion.UI.Xaml.Diagram.Stencil;
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
    /// Interaction logic for Stencil.xaml
    /// </summary>
    public partial class Stencil : DemoControl
    {
        public Stencil()
        {
            InitializeComponent();
        }

        public Stencil(string themename) : base(themename)
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
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
                this.stencil.SymbolGroups = null;
                this.stencil = null;
            }
            base.Dispose(disposing);
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;
            if(selectedItem.Content.ToString() == "Icons Only")
            {
                stencil.SymbolsDisplayMode = Syncfusion.UI.Xaml.Diagram.SymbolsDisplayMode.IconsOnly;
            }
            else
            {
                stencil.SymbolsDisplayMode = Syncfusion.UI.Xaml.Diagram.SymbolsDisplayMode.NamesUnderIcons;
            }
        }
    }
}
