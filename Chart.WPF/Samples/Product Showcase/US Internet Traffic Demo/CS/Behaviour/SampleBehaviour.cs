#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.SampleLayout;

namespace USInternetTrafficDemo
{
    public class SampleBehaviour : Behavior<MainWindow>
    {
        private MainWindow mainwindow;
        protected override void OnAttached()
        {
            base.OnAttached();
            mainwindow = this.AssociatedObject as MainWindow;
            mainwindow.shapeControl.ShapesLoaded += new Syncfusion.Windows.Controls.Map.ShapesLoadedEventHandler(shapeControl_ShapesLoaded);
        }

        void shapeControl_ShapesLoaded(object sender, Syncfusion.Windows.Controls.Map.ShapesLoadedEventArgs args)
        {
            (mainwindow.DataContext as MapSelectionModel).InitializeMap(mainwindow.shapeControl, mainwindow);
        }       
    }
}
