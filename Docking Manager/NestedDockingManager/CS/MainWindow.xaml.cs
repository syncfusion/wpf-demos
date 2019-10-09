#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
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

namespace NestedDockingManagerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DocumentContainer documentcontainer1 = clientdockingManager.DocContainer as DocumentContainer;
            documentcontainer1.Loaded += documentcontainer1_Loaded;
        }

        void documentcontainer1_Loaded(object sender, RoutedEventArgs e)
        {
            TabPanelAdv tabpanel = VisualUtils.FindDescendant(sender as Visual, typeof(TabPanelAdv)) as TabPanelAdv;
            if (tabpanel != null)
            {
                Button prevbutton = tabpanel.Template.FindName("PART_PrevTab", tabpanel) as Button;
                Button nextbutton = tabpanel.Template.FindName("PART_NextTab", tabpanel) as Button;
                if (prevbutton != null)
                {
                    ToolTipService.SetShowOnDisabled(prevbutton, true);
                    prevbutton.ToolTip = "Previous";
                }
                if (nextbutton != null)
                {
                    ToolTipService.SetShowOnDisabled(nextbutton, true);
                    nextbutton.ToolTip = "Next";
                }
            }
        }
        private void ComboBoxAdv_SelectionChanged(DependencyPropertyChangedEventArgs  e)
        {

        }

        private void SkinCombo_SelectedIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if((d as SkinCombo).combo.SelectedItem != null)
            {
                this.SetValue(SkinStorage.VisualStyleProperty,
                    ((d as SkinCombo).combo.SelectedItem as ComboBoxItemAdv).Content.ToString());
            }
        }
    }
}
