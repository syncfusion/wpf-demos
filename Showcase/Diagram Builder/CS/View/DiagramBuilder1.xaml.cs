#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DiagramBuilder.ViewModel;
using Syncfusion.UI.Xaml.Diagram;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using Syncfusion.UI.Xaml.Diagram.Controls;
using System.Windows.Input;
using DiagramBuilder.Utility;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.Windows.Controls.Navigation;

namespace DiagramBuilder.View
{
    sealed partial class DiagramBuilder1 : UserControl
    {
        public DiagramBuilder1()
        {
            this.InitializeComponent();

#if SyncfusionFramework4_5_1
            MenuFlyout menu = new MenuFlyout();
            Binding bind = new Binding { Path = new PropertyPath("SelectedDiagram.Export") };
            List<string> formats = new List<string> { "Png", "Jpeg", "Gif", "Tiff", "Jpegxr" };
            foreach (var item in formats)
            {
                MenuFlyoutItem menuItem = new MenuFlyoutItem
                {
                    Text = item,
                    CommandParameter = item
                };
                menuItem.SetBinding(MenuFlyoutItem.CommandProperty, bind);
                menu.Items.Add(menuItem);
            }
            export.Flyout = menu;
#endif

            
        }
        public ObservableCollection<NodeVM> dummy1 { get; set; }
        public ObservableCollection<ConnectorVM> dummy2 { get; set; }
        public ObservableCollection<object> dummy3 { get; set; }
        //public IPageSettings dummy4 { get; set; }
        public PageVM dummy5 { get; set; }
        public List<IAnnotation> dummy6 { get; set; }
        public ConnectorSegments dummy7 { get; set; }
        public ObservableCollection<SfRadialMenuItem> sfri { get; set; }

      
     
      

        private void AppBar_Click_1(object sender, RoutedEventArgs e)
        {
            (this.DataContext as DiagramBuilderVM).SelectedDiagram.Tool = Tool.MultipleSelect;
        }
       
       
        private void TappedDiagrams_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Point position = e.GetPosition(rootgrid);
            //double x = 0;
            //double y = 0;
            //if (!radialMenu.IsOpen)
            //{

            //    //var elements = (rootgrid as UIElement).fi
            //    //    //rootgrid.FindCommonVisualAncestor()
            //    //    .FindElementsInHostCoordinates(e.GetPosition(this), this);
            //    //UIElement element = elements.FirstOrDefault(item => item is INode || item is IConnector);
            //    {
            //        double scale = ((this.DataContext as DiagramBuilderVM).SelectedDiagram.Info as IGraphInfo).ScrollInfo.CurrentZoom;
            //        //double x = position.X + e.GetPosition(element) + 
            //        //radialMenu.Visibility = Visibility.Collapsed;
            //        //return;
            //    }
            //    radialMenu.Visibility = Visibility.Visible;
            //    radialMenu.UpdateLayout();
            //    //radialMenu.Focus(FocusState.Keyboard);                
            //    //foreach (var controls in elements)
            //    //{
            //    //    if (controls is Node || controls is Connector)
            //    //    {
            //    x = (position.X - radialMenu.RadiusX) - 60;
            //    y = (position.Y - radialMenu.RadiusY) - 0;
            //    //        break;
            //    //    }
            //    //    else if (controls is SfDiagram)
            //    //    {
            //    //        x = (position.X - radialMenu.RadiusX);
            //    //        y = (position.Y - radialMenu.RadiusY);
            //    //        break;
            //    //    }
            //    //}
            //    x = Math.Min(Math.Max(0, x), ActualWidth - radialMenu.RadiusX * 2);
            //    y = Math.Min(Math.Max(0, y), ActualHeight - radialMenu.RadiusY * 2);
            //    radialMenu.RenderTransform = new TranslateTransform() { X = x, Y = y};
            //    //radialMenu.Focus(FocusState.Keyboard);
            //}
            //else
            //{
            //    radialMenu.IsOpen = false;
            //}

        }

        private void expandButton_Click(object sender, RoutedEventArgs e)
        {
            //expandButton.Visibility = System.Windows.Visibility.Collapsed;
            //collpaseButton.Visibility = System.Windows.Visibility.Visible;
            propertyPanel.Width = 245;
        }

        private void collpaseButton_Click(object sender, RoutedEventArgs e)
        {
            //collpaseButton.Visibility = System.Windows.Visibility.Collapsed;
          //  expandButton.Visibility = System.Windows.Visibility.Visible;
            propertyPanel.Width = 75;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //expandDropDown.IsDropDownOpen = true;
        }
      
    }
}
                   
       
