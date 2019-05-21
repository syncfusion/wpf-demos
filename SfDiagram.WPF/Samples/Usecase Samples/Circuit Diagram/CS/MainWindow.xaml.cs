#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.Collections.ObjectModel;
using SPath = System.Windows.Shapes.Path;
using System.Windows.Media;
using System.Windows;

namespace UseCaseSamples_CircuitDiagram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public MainWindow()
        {
            InitializeComponent();

            //To enable Bridging, Zoomable, Pannable options for diagram
            diagram.Constraints.Add(GraphConstraints.Bridging, GraphConstraints.Zoomable, GraphConstraints.Pannable);
        }
    }
}



