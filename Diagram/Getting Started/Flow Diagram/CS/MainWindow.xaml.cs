#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Runtime.Serialization;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Syncfusion.UI.Xaml.Diagram.Theming;
using System.Windows.Media;

namespace GettingStarted_FlowDiagram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Graph constraints is used here to enable/disable the undoable process.
            diagram.Constraints.Add(GraphConstraints.Undoable);

            (diagramcontrol.Info as IGraphInfo).ItemAdded += MainWindow_ItemAdded;
        }

        private void MainWindow_ItemAdded(object sender, ItemAddedEventArgs args)
        {
            if (args.Item is NodeViewModel)
            {
                if(args.ItemSource == ItemSource.Stencil)
                {
                    (args.Item as NodeViewModel).Annotations = new ObservableCollection<IAnnotation>()
                    {
                        new TextAnnotationViewModel()
                        {
                            FontFamily = new FontFamily("FontFamily"),
                            TextHorizontalAlignment = TextAlignment.Center,
                            TextVerticalAlignment = VerticalAlignment.Center,
                        }
                    };
                }
                foreach (IAnnotation anno in (args.Item as NodeViewModel).Annotations as ObservableCollection<IAnnotation>)
                {
                    (anno as TextAnnotationViewModel).FontFamily = new FontFamily("Calibri");                    
                }
            }
        }
    }

    //Collection of Symbols
    public class SymbolCollection : ObservableCollection<object>
    {

    }
}
