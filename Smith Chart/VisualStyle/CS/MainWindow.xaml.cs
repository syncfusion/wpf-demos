#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
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

namespace VisualStyle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBoxAdv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItemAdv item;
            WindowCollection windows = Application.Current.Windows;
            if (windows.Count > 0)
            {
                ComboBoxAdv combo = sender as ComboBoxAdv;
                if (combo != null)
                {
                    if (combo.SelectedItem != null)
                    {
                        item = combo.SelectedItem as ComboBoxItemAdv;
                        VisualStyles selectedStyle = (VisualStyles)Enum.Parse(typeof(VisualStyles), item.Content.ToString());
                        SfSkinManager.SetVisualStyle(this.SmithChart, selectedStyle);
						SfSkinManager.SetVisualStyle(this.combo, selectedStyle);
						SfSkinManager.SetVisualStyle(this.VisualStyleTextblock, selectedStyle);

                        if(selectedStyle == VisualStyles.MaterialDark)
                        {
                            this.grid.Background = Brushes.Black;
                        }
                        else
                        {
                            this.grid.Background = Brushes.White;
                        }
                    }
                }
            }
        }
    }
}
