#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using System.Windows.Shapes;

namespace Syncfusion.UI.Xaml.MindMapDiagram.View
{
    /// <summary>
    /// Interaction logic for DiagramStyleWindow.xaml
    /// </summary>
    public partial class DiagramStyleWindow : Window
    {
        public DiagramStyleWindow()
        {
            InitializeComponent();            
            diagramcontrol.PageSettings = new PageSettings();
            diagramcontrol.PageSettings.PageHeight = 400;
            diagramcontrol.PageSettings.PageWidth = 500;
            diagramcontrol.PageSettings.ShowPageBreaks = false;
            FitToPageParameter fitToPage = new FitToPageParameter() { FitToPage = FitToPage.FitToPage, Region = Region.PageSettings };
            (diagramcontrol.Info as IGraphInfo).Commands.FitToPage.Execute(fitToPage);
        }
    }
}
