#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.brainstormingdiagram.wpf.View
{
    /// <summary>
    /// Interaction logic for StatusBar.xaml
    /// </summary>
    public partial class StatusBar : UserControl
    {
        SfDiagram diagramControl;
        public StatusBar()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty DiagramProperty = DependencyProperty.Register("Diagram", typeof(SfDiagram), typeof(StatusBar), new UIPropertyMetadata(null, OnDiagramChanged));

       
        public ICommand Diagram
        {
            get
            {
                return (ICommand)GetValue(DiagramProperty);
            }
            set
            {
                SetValue(DiagramProperty, value);
            }
        }

        private static void OnDiagramChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            (sender as StatusBar).SetDiagramControl(args.NewValue as SfDiagram);
        }

        private void SetDiagramControl(SfDiagram diagram)
        {
            this.diagramControl = diagram;
            //Binding currentzoom = new Binding();
            //currentzoom.Source = this.diagramControl.ScrollSettings.ScrollInfo;
            //currentzoom.Path = new PropertyPath("CurrentZoom");
            //currentzoom.Mode = BindingMode.OneWay;
            //PART_ZoomSlider.SetBinding(Slider.ValueProperty, currentzoom);
        }

        private void Text_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            if (text != null)
            {
                ZoomPanWindow n = new ZoomPanWindow();
                n.DataContext = this.DataContext;
                n.Show();
            }
        }
    }
}
