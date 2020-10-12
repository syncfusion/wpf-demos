#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
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
    /// Interaction logic for Ports.xaml
    /// </summary>
    public partial class Ports : DemoControl
    {
        public Ports()
        {
            InitializeComponent();
        }

        public Ports(string themename) : base(themename)
        {
            InitializeComponent();
            this.Diagram.Loaded += (s, evt) =>
            {
                var nodes = this.Diagram.Nodes as NodeCollection;
                if (nodes != null && nodes.Any())
                {
                    nodes.First().IsSelected = true;
                }
            };
        }
    }
}
