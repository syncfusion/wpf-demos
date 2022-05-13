#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.diagrambuilder.wpf.View;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.UI.Xaml.Diagram.Theming;
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

namespace syncfusion.diagrambuilder.wpf.FlowChart
{
    /// <summary>
    /// Interaction logic for FlowStencil.xaml
    /// </summary>
    public partial class FlowStencil : UserControl, IStencilTheme
    {
        public FlowStencil()
        {
            InitializeComponent();
            this.Loaded += FlowStencil_Loaded;
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

        private void FlowStencil_Loaded(object sender, RoutedEventArgs e)
        {
            stencil.Categories = new StencilCategoryCollection()
            {
                new StencilCategory()
                {
                    Title = "Flow Shapes",
                    Keys = this.Resources["FlowShapes"] as IEnumerable<string>,
                },
            };
        }
    }
}
