#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using System.Diagnostics;

namespace LinkedManagerDemo
{
    /// <summary>
    /// Interaction logic for SkinCombo.xaml
    /// </summary>
    public partial class SkinCombo : UserControl
    {
        public SkinCombo()
        {
            InitializeComponent();
        }
        private void ComboBoxAdv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItemAdv item;
            MainWindow samplewindow = VisualUtils.FindAncestor((Visual)this, typeof(MainWindow)) as MainWindow;
            ComboBoxAdv combo = sender as ComboBoxAdv;
            if (combo != null && samplewindow !=null)
            {
                if (combo.SelectedItem != null)
                {
                    item = combo.SelectedItem as ComboBoxItemAdv;
                    SkinStorage.SetVisualStyle(samplewindow, item.Content.ToString());

                }
            }

        }
    }
}
