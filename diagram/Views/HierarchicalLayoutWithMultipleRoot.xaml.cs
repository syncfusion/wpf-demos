#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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
    /// Interaction logic for HierarchicalLayoutWithMultipleRoot.xaml
    /// </summary>
    public partial class HierarchicalLayoutWithMultipleRoot : DemoControl
    {
        public HierarchicalLayoutWithMultipleRoot()
        {
            InitializeComponent();
        }

        public HierarchicalLayoutWithMultipleRoot(string themename) : base(themename)
        {
            InitializeComponent();

            (Diagram.Info as IGraphInfo).ViewPortChangedEvent += HierarchicalLayoutWithMultipleRoot_ViewPortChangedEvent;
        }

        private void HierarchicalLayoutWithMultipleRoot_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            if (Diagram.Info != null && (args.Item as SfDiagram).IsLoaded == true && args.NewValue.ContentBounds != args.OldValue.ContentBounds)
            {
                (Diagram.Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
            }
        }

        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(NodeViewModel node in Diagram.Nodes as NodeCollection)
            {
                node.Constraints = NodeConstraints.AllowPan;
            }
            foreach(ConnectorViewModel connector in Diagram.Connectors as ConnectorCollection)
            {
                connector.Constraints = ConnectorConstraints.AllowPan;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
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
