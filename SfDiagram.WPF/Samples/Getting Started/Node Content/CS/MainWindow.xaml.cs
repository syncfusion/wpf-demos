#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace NodeContent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //To Disable ContextMenu
            diagramControl.Menu = null;

            //Intialize PageSettingsand Snapping
            InitializeDiagram();

            diagramControl.MouseLeave += diagramControl_MouseLeave;

            //Unload diagram
            this.Unloaded += diagramControl_Unloaded;
        }

        private void InitializeDiagram()
        {
            diagramControl.Tool = Tool.ZoomPan;
            //Draggable Constraints used to enable/disable the Dragging.
            diagramControl.Constraints = diagramControl.Constraints &
                                         ~(GraphConstraints.Selectable | GraphConstraints.Draggable);
            diagramControl.KnownTypes = GetKnownTypes;
            //diagramControl.Constraints = diagramControl.Constraints & ~(GraphConstraints.Zoomable | GraphConstraints.Pannable);
        }

        void diagramControl_Unloaded(object sender, RoutedEventArgs e)
        {
            diagramControl.MouseLeave -= diagramControl_MouseLeave;
            diagramControl.KnownTypes = null;
            this.Unloaded -= diagramControl_Unloaded;
        }

        void diagramControl_MouseLeave(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        //Helps to Serialize the Shape
        private IEnumerable<Type> GetKnownTypes()
        {
            List<Type> known = new List<Type>()
            {
                typeof(Shapes)
            };
            foreach (var item in known)
            {
                yield return item;
            }
        }
    }
    public class PortCollection : ObservableCollection<IPort>
    {

    }
    public class SegmentPoint : ObservableCollection<IConnectorSegment>
    {

    }
}
