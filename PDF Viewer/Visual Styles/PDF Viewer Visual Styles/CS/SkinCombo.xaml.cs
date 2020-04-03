#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
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
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Tools;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;

namespace GettingStarted_2008
{
    /// <summary>
    /// Interaction logic for SkinCombo.xaml
    /// </summary>
    public partial class SkinCombo : UserControl
    {
        #region Constructor
        public SkinCombo()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void ComboBoxAdv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItemAdv item;
            WindowCollection windows = Application.Current.Windows;
            if (windows.Count > 0)
            {
                Window samplewindow = windows[0];
                ComboBoxAdv combo = sender as ComboBoxAdv;
                if (combo != null)
                {
                    if (combo.SelectedItem != null)
                    {
                        item = combo.SelectedItem as ComboBoxItemAdv;
                        SfSkinManager.SetVisualStyle(combo, (VisualStyles)Enum.Parse(typeof(VisualStyles), item.Content.ToString()));
                        SfSkinManager.SetVisualStyle(samplewindow,(VisualStyles) Enum.Parse(typeof(VisualStyles), item.Content.ToString()));                        
                    }
                }
            }
        }
        #endregion
    }
}
