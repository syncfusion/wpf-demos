#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for Rulers_and_Units.xaml
    /// </summary>
    public partial class Rulers_and_Units : DemoControl
    {
        private bool first = true;
        public Rulers_and_Units()
        {
            InitializeComponent();
        }

        public Rulers_and_Units(string themename) : base(themename)
        {
            InitializeComponent();
            (DiagramControl.Info as IGraphInfo).ViewPortChangedEvent += Rulers_and_Units_ViewPortChangedEvent;
        }

        private void Rulers_and_Units_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            if (DiagramControl.Info != null && (args.Item as SfDiagram).IsLoaded == true && first && args.NewValue.ContentBounds != args.OldValue.ContentBounds)
            {
                (DiagramControl.Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
                first = false;
            }
        }
    }
}
