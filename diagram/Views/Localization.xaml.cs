#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for Localization.xaml
    /// </summary>
    public partial class Localization : DemoControl
    {
        //To Represent ResourceManager
        System.Resources.ResourceManager manager;

        private bool first = true;

        private Rect contentbounds = Rect.Empty;
        public Localization()
        {

            //Get CultureInfo 
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");//French

            InitializeComponent();            

            //Initialize Assembly
            Assembly assembly = Assembly.Load("syncfusion.diagramdemo.wpf");
            manager = new System.Resources.ResourceManager("syncfusion.diagramdemo.wpf.Resources.Syncfusion.SfDiagram.Wpf", assembly);

            DiagramResourceWrapper.SetResources(assembly, "syncfusion.diagramdemo.wpf");

            diagram.Loaded += Diagram_Loaded;

            (diagram.Info as IGraphInfo).ViewPortChangedEvent += Localization_ViewPortChangedEvent;
            
        }

        public Localization(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            //Get CultureInfo 
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            //Initialize Assembly
            Assembly assembly = Assembly.Load("syncfusion.diagramdemo.wpf");
            manager = new System.Resources.ResourceManager("syncfusion.diagramdemo.wpf.Resources.Syncfusion.SfDiagram.Wpf", assembly);

            DiagramResourceWrapper.SetResources(assembly, "syncfusion.diagramdemo.wpf");

            base.Dispose(disposing);
        }

        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            if(diagram.Info != null)
            {
                if (first && contentbounds != Rect.Empty)
                {
                    (diagram.Info as IGraphInfo).BringIntoCenter(contentbounds);
                    first = false;
                }
            }
        }

        private void Localization_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            if(args.NewValue.ContentBounds != args.OldValue.ContentBounds)
            {
                contentbounds = args.NewValue.ContentBounds;
            }
        }
    }
}
