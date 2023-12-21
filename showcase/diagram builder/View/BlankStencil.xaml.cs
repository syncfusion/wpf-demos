#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.diagrambuilder.wpf.ViewModel;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace syncfusion.diagrambuilder.wpf.View
{
    /// <summary>
    /// Interaction logic for BlankStencil.xaml
    /// </summary>
    public partial class BlankStencil : UserControl, IStencilTheme
    {
        public BlankStencil()
        {
            InitializeComponent();
        }

        public DiagramTheme Theme
        {
            get
            {
                return stencil.DiagramTheme;
            }
            set
            {
                if (stencil.DiagramTheme != value)
                {
                    stencil.DiagramTheme = value;
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new BlankStencilVM();
        }
    }

    public interface IStencilTheme
    {
        DiagramTheme Theme { get; set; }
    } 
}
