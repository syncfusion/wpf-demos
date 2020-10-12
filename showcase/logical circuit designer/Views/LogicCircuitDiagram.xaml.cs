#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.logicalcircuitdesigner.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace syncfusion.logicalcircuitdesigner.wpf
{
    /// <summary>
    /// Interaction logic for LogicCircuitDiagramDemo.xaml
    /// </summary>
    public partial class LogicalCircuitDesignerDemo : Window
    {
        public LogicalCircuitDesignerDemo()
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "MaterialDark" });
            (this.DataContext as LogicGatesViewModel).View = this;
        }

        private void LoadDiagramFromFile(string file)
        {
            (Diagram.Nodes as ObservableCollection<CustomNode>).Clear();
            (Diagram.Connectors as ObservableCollection<ConnectorViewModel>).Clear();
            if (Diagram.Info != null)
            {
                using (FileStream fileStream = File.OpenRead(file))
                {
                    (Diagram.Info as IGraphInfo).Load(fileStream);
                }
            }
        }

        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadDiagramFromFile(@"PredefinedDiagram/BasicLogicCircuit.xml");
        }
    }
}
