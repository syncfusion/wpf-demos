#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Shared;
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
using System.Windows.Shapes;

namespace syncfusion.brainstormingdiagram.wpf.View
{
    /// <summary>
    /// Interaction logic for DiagramStyleWindow.xaml
    /// </summary>
    public partial class DiagramStyleWindow : ChromelessWindow
    {
        public DiagramStyleWindow()
        {
            InitializeComponent();            
            (diagramcontrol.Info as IGraphInfo).ViewPortChangedEvent += DiagramStyleWindow_ViewPortChangedEvent;
        }

        private void DiagramStyleWindow_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            if (args.OldValue.PageBounds != args.NewValue.PageBounds)
            {
                FitToPageParameter fitToPage = new FitToPageParameter() { FitToPage = FitToPage.FitToPage, CanZoomIn = true, Region = Region.PageSettings };
                (diagramcontrol.Info as IGraphInfo).Commands.FitToPage.Execute(fitToPage);

              
            }
        }
    }
}
