#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemos.wpf.ViewModel;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for FishboneDiagram.xaml
    /// </summary>
    public partial class FishboneDiagram : DemoControl
    {
        public FishboneDiagram()
        {
            InitializeComponent();
        }

        public FishboneDiagram(string themename) : base(themename)
        {
            InitializeComponent();
            diagram.ScrollSettings.ScrollLimit = ScrollLimit.Diagram;
            this.DataContext = new FishboneDiagramViewModel(this);
            diagram.Loaded += Diagram_Loaded;
        }

        private bool loaded = false;
        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            (diagram.Info as IGraphInfo).ViewPortChangedEvent += FishboneDiagram_ViewPortChangedEvent;             
        }

        private void FishboneDiagram_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            if (diagram.Info != null && !loaded && diagram.IsLoaded && args.NewValue.ContentBounds == args.OldValue.ContentBounds)
            {
                (diagram.Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
                diagram.PageSettings.PageHeight = double.NaN;
                diagram.PageSettings.PageWidth = double.NaN;
                (diagram.Info as IGraphInfo).Commands.FitToPage.Execute(null);
                loaded = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.diagram != null)
            {
                this.diagram.SelectedItems = null;
                this.diagram = null;
            }
            base.Dispose(disposing);
        }
    }
}
