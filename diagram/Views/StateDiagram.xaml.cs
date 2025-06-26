#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.UI.Xaml.Diagram.Theming;
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


namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for StateDiagram.xaml
    /// </summary>
    public partial class StateDiagram : DemoControl
    {
        public StateDiagram()
        {
            InitializeComponent();
        }
        public StateDiagram(string themename) : base(themename)
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Syncfusion.SfSkinManager.Theme() { ThemeName = themename });   
        }
        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            if (this.Diagram != null)
            {
                if (this.Diagram.Nodes != null)
                {
                    (this.Diagram.Nodes as NodeCollection).Clear();
                }
                if (this.Diagram.Connectors != null)
                {
                    (this.Diagram.Connectors as ConnectorCollection).Clear();
                }
                if (this.Diagram.Groups != null)
                {
                    (this.Diagram.Groups as GroupCollection).Clear();
                }
                this.Diagram.HorizontalRuler = null;
                this.Diagram.VerticalRuler = null;
                this.Diagram = null;
            }
            if (this.stencil != null)
            {
                if (this.stencil.SymbolGroups != null)
                {
                    foreach (SymbolGroupViewModel viewModel in this.stencil.SymbolGroups)
                    {
                        if (viewModel is IDisposable)
                        {
                            ((IDisposable)viewModel).Dispose();
                        }
                        viewModel.Menu = null;
                        viewModel.CategorySource = null;
                    }
                    this.stencil.SymbolGroups.Clear();
                }
                if (this.stencil.SymbolSource is SymbolCollection)
                {
                    (this.stencil.SymbolSource as SymbolCollection).Clear();
                }
                this.stencil.SymbolGroups = null;
                this.stencil.SymbolSource = null;
                this.stencil.DataContext = null;
                this.stencil = null;
            }

            base.Dispose(disposing);
        }
    }

    public class PathDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var width = (double)value;
            var height = 30d;
            var cornerRadius = 9d;
            string pathData = "M " + cornerRadius + " 0 " +
                          "L " + (width - cornerRadius) + " 0 " +
                          "Q " + width + " 0, " + width + " " + cornerRadius + " " +
                          "L " + width + " " + (height - cornerRadius) + " " +
                          "L 0 " + (height - cornerRadius) + " " +
                          "L 0 " + cornerRadius + " " +
                          "Q 0 0, " + cornerRadius + " 0 Z";
            return Geometry.Parse(pathData);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
