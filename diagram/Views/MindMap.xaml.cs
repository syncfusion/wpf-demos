#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.Model;
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
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

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for MindMap.xaml
    /// </summary>
    public partial class MindMap : DemoControl
    {
        public MindMap()
        {
            InitializeComponent();
        }

        public MindMap(string themename) : base(themename)
        {
            InitializeComponent();
            this.Diagram.Loaded += Diagram_Loaded;
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
        }

        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            var layout = this.Diagram.LayoutManager.Layout as SfMindMapTreeLayout;
            (layout.LayoutRoot as INode).IsSelected = true;

            (this.Diagram.Info as IGraphInfo).Commands.FitToPage.Execute(null);

            foreach (NodeViewModel node in this.Diagram.Nodes as NodeCollection)
            {
                node.Annotations = null;
            }

            ((layout.LayoutRoot as INode).Info as INodeInfo).BringIntoCenter();
        }

        private void TextBox_PreviewMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }
}
