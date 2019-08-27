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
using System.Windows;
using System.Windows.Input;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace GettingStarted_NodeContent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //To disable selectable and draggable options for diagram
            diagram.Constraints.Remove(GraphConstraints.Selectable, GraphConstraints.Draggable);
        }
    }
}
