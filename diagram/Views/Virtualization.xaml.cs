#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for Virtualization.xaml
    /// </summary>
    public partial class Virtualization : DemoControl
    {
        public Virtualization()
        {
            InitializeComponent();
        }

        public Virtualization(string themename) : base(themename)
        {
            InitializeComponent();
            InitializeNodesandConnectors(diagram);
        }

        public async static void InitializeNodesandConnectors(SfDiagram diag)
        {
            DispatcherTimer timer = new DispatcherTimer();
            await timer.Dispatcher.BeginInvoke
            (
                new Action(() =>
                {
                    diag.Nodes = (diag.DataContext as VirtualizationViewModel).Nodes;
                    diag.Connectors = (diag.DataContext as VirtualizationViewModel).Connectors;

                }), System.Windows.Threading.DispatcherPriority.Background
            );
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }

            if (this.diagram != null)
            {
                (this.diagram.Connectors as ObservableCollection<ConnectorViewModel>).Clear();
                (this.diagram.Nodes as ObservableCollection<NodeViewModel>).Clear();
                this.diagram = null;
            }

            base.Dispose(disposing);
        }
    }
}
