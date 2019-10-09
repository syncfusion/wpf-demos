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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;

namespace EditControl_XAML_Demo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        /// <summary>
        /// Window Constructor and events initialization
        /// </summary>
        public Window1()
        {
            InitializeComponent();
#if NETCORE
            editXAML.DocumentSource = "../../../Test.xaml";
            editXML.DocumentSource = "../../../Products.xml";
#else
            editXAML.DocumentSource = "../../Test.xaml";
            editXML.DocumentSource = "../../Products.xml";
#endif
            tabControl1.SelectionChanged += new SelectionChangedEventHandler(tabControl1_SelectionChanged);
        }

        void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
            {
                TabItem item = e.RemovedItems[0] as TabItem;
                if (item.Content == null || (item.Content != null && !(item.Content is EditControl)))
                {
                    return;
                }
                EditControl tempControl = item.Content as EditControl;
                Binding prevBinding = BindingOperations.GetBinding(tempControl, EditControl.FontFamilyProperty);
                if (prevBinding != null)
                {
                    FontFamily tempFont = tempControl.FontFamily;
                    BindingOperations.ClearBinding(tempControl, EditControl.FontFamilyProperty);
                    tempControl.FontFamily = tempFont;

                    double tempSize = tempControl.FontSize;
                    BindingOperations.ClearBinding(tempControl, EditControl.FontSizeProperty);
                    tempControl.FontSize = tempSize;
                }
            }

            if (e.AddedItems.Count > 0)
            {
                TabItem item = e.AddedItems[0] as TabItem;
                if (item.Content == null || (item.Content != null && !(item.Content is EditControl)))
                {
                    return;
                }
                EditControl tempControl = item.Content as EditControl;
                Binding prevBinding = BindingOperations.GetBinding(tempControl, EditControl.FontFamilyProperty);
                if (prevBinding == null)
                {
                    fontlst.SelectedItem = tempControl.FontFamily;
                    fontsze.SelectedItem = tempControl.FontSize;
                    Binding binding = new Binding("SelectedItem");
                    binding.Source = fontlst;
                    binding.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(tempControl, EditControl.FontFamilyProperty, binding);

                    Binding bindingSize = new Binding("SelectedItem");
                    bindingSize.Source = fontsze;
                    bindingSize.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(tempControl, EditControl.FontSizeProperty, bindingSize);
                }
            }
            e.Handled = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
