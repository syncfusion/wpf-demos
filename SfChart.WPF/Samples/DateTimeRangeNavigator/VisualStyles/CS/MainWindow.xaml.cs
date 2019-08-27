#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace VisualStyles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void themecombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            if (rangeNavigator != null)
            {
                if (combo.SelectedIndex == 0)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(rangeNavigator, Syncfusion.SfSkinManager.VisualStyles.Default);
                }
                else if (combo.SelectedIndex == 1)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(rangeNavigator, Syncfusion.SfSkinManager.VisualStyles.Blend);
                }
                else if (combo.SelectedIndex == 2)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(rangeNavigator, Syncfusion.SfSkinManager.VisualStyles.Metro);
                }
                else if (combo.SelectedIndex == 3)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(rangeNavigator, Syncfusion.SfSkinManager.VisualStyles.Office2010Black);
                }
                else if (combo.SelectedIndex == 4)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(rangeNavigator, Syncfusion.SfSkinManager.VisualStyles.Office2010Blue);
                }
                else if (combo.SelectedIndex == 5)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(rangeNavigator, Syncfusion.SfSkinManager.VisualStyles.Office2010Silver);
                }
                else if (combo.SelectedIndex == 6)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(rangeNavigator, Syncfusion.SfSkinManager.VisualStyles.Office2013DarkGray);
                }
                else if (combo.SelectedIndex == 7)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(rangeNavigator, Syncfusion.SfSkinManager.VisualStyles.Office2013LightGray);
                }
                else if (combo.SelectedIndex == 8)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(rangeNavigator, Syncfusion.SfSkinManager.VisualStyles.Office2013White);
                }
                else if (combo.SelectedIndex == 9)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(rangeNavigator, Syncfusion.SfSkinManager.VisualStyles.VisualStudio2013);
                }
            }
        }
    }
    public class Model
    {
        public DateTime Date
        {
            get;
            set;
        }
        public double Value
        {
            get;
            set;
        }
    }

    public class ViewModel
    {
        public ObservableCollection<Model> Statistics
        {
            get;
            set;
        }

        public Array ChartThemes
        {
            get
            {
                return Enum.GetValues(typeof(Syncfusion.SfSkinManager.VisualStyles));
            }
        }

        public ViewModel()
        {
            this.Statistics = new ObservableCollection<Model>();
            DateTime date = new DateTime(2014, 1, 1);
            Random rd = new Random();
            for (int i = 0; i < 100; i++)
            {
                this.Statistics.Add(new Model() { Date = date.AddDays(i+30), Value = rd.Next(10, 50) });
            }
        }
    }
}

