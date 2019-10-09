#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.Windows.Tools.Controls;
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

namespace MindMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office2016White);
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            _ribbon.BackStageButton.Visibility = Visibility.Collapsed;
            mindmapDiagram.ViewModel.LoadCommand.Execute(@"../../PreSavedDiagram/BusinessPlanning.xml");
            mindmapDiagram.Loaded += MindmapDiagram_Loaded;
        }

        private void MindmapDiagram_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is SfDiagram)
            {
                SfDiagram diagram = sender as SfDiagram;
                if (diagram.Nodes != null)
                {
                    foreach (NodeViewModel node in diagram.Nodes as ObservableCollection<NodeViewModel>)
                    {
                        if (node.Annotations != null)
                        {
                            foreach (TextAnnotationViewModel anno in node.Annotations as ObservableCollection<IAnnotation>)
                            {
                                anno.FontFamily = new FontFamily("Calibri");
                            }
                        }
                    }

                }
            }
        }
    }

    public class PathCollection : ObservableCollection<Path>
    { 
    }
}
