#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
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
    /// Interaction logic for Nodes.xaml
    /// </summary>
    public partial class Nodes : DemoControl
    {
        public Nodes()
        {
            InitializeComponent();
        }

        public Nodes(string themename) : base(themename)
        {
            InitializeComponent();
            (this.DataContext as NodesViewModel).View = this;
        }

        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            (Diagram.DataContext as NodesViewModel).prevbutton = fill;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                var viewmodel = Diagram.DataContext as NodesViewModel;
                if (viewmodel != null)
                {
                    viewmodel.View = null;
                    viewmodel.prevbutton = null;
                }

                this.DataContext = null;
            }
            
            if (this.Diagram != null)
            {
                this.Diagram = null;
            }

            base.Dispose(disposing);
        }
    }
}
