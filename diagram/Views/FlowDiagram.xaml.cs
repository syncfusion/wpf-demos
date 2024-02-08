#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Theming;
using Syncfusion.Windows.Tools.Controls;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for FlowDiagram.xaml
    /// </summary>
    public partial class FlowDiagram : RibbonWindow
    {
        private bool first = true;
        public FlowDiagram()
        {
            InitializeComponent();
            diagramcontrol.Loaded += Diagramcontrol_Loaded;

            SfSkinManager.SetTheme(this, new Syncfusion.SfSkinManager.Theme() { ThemeName = "Windows11Light" });

            // This code is used to set the menu drop down in the left side for both right handed and left handed settings.
            //Whether the acquisition system is Left-handed (true) or Right-handed (false)            

            var ifLeft = SystemParameters.MenuDropAlignment;
            if (ifLeft)
            {
                var t = typeof(SystemParameters);
                var field = t.GetField("_menuDropAlignment", BindingFlags.NonPublic | BindingFlags.Static);
                field.SetValue(null, false);
                ifLeft = SystemParameters.MenuDropAlignment;
            }

            diagramcontrol.PropertyChanged += Diagramcontrol_PropertyChanged;
            diagramcontrol.Theme = new OfficeTheme();
        }

        private void Diagramcontrol_Loaded(object sender, RoutedEventArgs e)
        {
            (diagramcontrol.Info as IGraphInfo).ViewPortChangedEvent += FlowDiagram_ViewPortChangedEvent;
        }

        private DiagramTheme cacheTheme;
        private void Diagramcontrol_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Theme")
            {
                if (cacheTheme != null)
                {
                    cacheTheme.PropertyChanged -= DiagramTheme_PropertyChanged;
                    cacheTheme = null;
                }

                if (((SfDiagram)sender).Theme != null)
                {
                    cacheTheme = ((SfDiagram)sender).Theme;
                    stencil.DiagramTheme = Activator.CreateInstance(cacheTheme.GetType()) as DiagramTheme;
                    cacheTheme.PropertyChanged += DiagramTheme_PropertyChanged;
                }
            }
        }

        private void DiagramTheme_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "NodeStyles")
            {
                stencil.DiagramTheme.NodeStyles = (sender as DiagramTheme).NodeStyles;
            }
            else if (e.PropertyName == "ConnectorStyles")
            {
                stencil.DiagramTheme.ConnectorStyles = (sender as DiagramTheme).ConnectorStyles;
            }
        }

        private void FlowDiagram_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            if (diagramcontrol.Info != null && (args.Item as SfDiagram).IsLoaded == true && first)
            {
                (diagramcontrol.Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
                first = false;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (cacheTheme != null)
            {
                cacheTheme.PropertyChanged -= DiagramTheme_PropertyChanged;
                cacheTheme = null;
            }

            if (this.stencil != null)
            {
                (this.stencil.SymbolSource as SymbolCollection).Clear();
                this.stencil.DataContext = null;
                this.stencil = null;
            }

            if (this.diagramRibbon != null)
            {
                this.diagramRibbon.Tabs = null;
                this.diagramRibbon.DataContext = null;
                this.diagramRibbon = null;
            }

            if (this.diagramcontrol != null)
            {
                if (diagramcontrol.Info is IGraphInfo)
                {
                    (diagramcontrol.Info as IGraphInfo).ViewPortChangedEvent -= FlowDiagram_ViewPortChangedEvent;
                }

                diagramcontrol.PropertyChanged -= Diagramcontrol_PropertyChanged;
                (diagramcontrol.Connectors as ConnectorCollection).Clear();
                (diagramcontrol.Nodes as NodeCollection).Clear();
                this.diagramcontrol = null;
            }

            GC.SuppressFinalize(this);

            this.DataContext = null;
            base.OnClosing(e);
        }
    }
}
