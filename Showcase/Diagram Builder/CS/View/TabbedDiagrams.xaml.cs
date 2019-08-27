#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using DiagramBuilder.Utility;
using DiagramBuilder.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DiagramBuilder.View
{
    public sealed partial class TabbedDiagrams : ItemsControl
    {
        public TabbedDiagrams()
        {
            this.InitializeComponent();
            this.Loaded += TabbedDiagrams_Loaded;
        }

        private void TabbedDiagrams_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {           
            (this.DataContext as DiagramBuilderVM).Delete.Execute((this.DataContext as DiagramBuilderVM).SelectedDiagram);

            if ((this.DataContext as DiagramBuilderVM).Diagrams.Count < 1)
            {
                (this.DataContext as DiagramBuilderVM).New.Execute((this.DataContext as DiagramBuilderVM).SelectedDiagram);
            }                   
        }  

        private void MenuItem_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            (this.DataContext as DiagramBuilderVM).Duplicate.Execute(null);
        }       

        private void DockingManager_WindowClosing(object sender, Syncfusion.Windows.Tools.Controls.WindowClosingEventArgs e)
        {
            e.Cancel = true;
            ((this.DataContext as DiagramBuilderVM).SelectedDiagram as DiagramVM).EnablePanZoom = false;
        }

        private void DockingManager_WindowClosing_1(object sender, Syncfusion.Windows.Tools.Controls.WindowClosingEventArgs e)
        {
            e.Cancel = true;
            ((this.DataContext as DiagramBuilderVM).SelectedDiagram as DiagramVM).EnableSizePosition = false;
        }

        //public object SelectedDiagram
        //{
        //    get { return (object)GetValue(SelectedDiagramProperty); }
        //    set { SetValue(SelectedDiagramProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for SelectedDiagram.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SelectedDiagramProperty =
        //    DependencyProperty.Register("SelectedDiagram", typeof(object), typeof(TabbedDiagrams), new PropertyMetadata(null));

        //public object Diagrams
        //{
        //    get { return (object)GetValue(DiagramsProperty); }
        //    set { SetValue(DiagramsProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Diagrams.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty DiagramsProperty =
        //    DependencyProperty.Register("Diagrams", typeof(object), typeof(TabbedDiagrams), new PropertyMetadata(null));



        //public DataTemplate HeaderTemplate
        //{
        //    get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
        //    set { SetValue(HeaderTemplateProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for HeaderTemplate.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty HeaderTemplateProperty =
        //    DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(TabbedDiagrams), new PropertyMetadata(null));


        //protected override DependencyObject GetContainerForItemOverride()
        //{
        //    return new SfDiagramView();
        //}
    }
}
