#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
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
    public partial class MainWindow :SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnComboxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            if (columnChart != null)
            {
                if (combo.SelectedIndex == 0)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Blend);
                }
                else if (combo.SelectedIndex == 1)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Metro);
                }
                else if (combo.SelectedIndex == 2)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2010Black);
                }
                else if (combo.SelectedIndex == 3)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2010Blue);
                }
                else if (combo.SelectedIndex == 4)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2010Silver);
                }
                else if (combo.SelectedIndex == 5)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2013DarkGray);
                }
                else if (combo.SelectedIndex == 6)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2013LightGray);
                }
                else if (combo.SelectedIndex == 7)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2013White);
                }
                else if (combo.SelectedIndex == 8)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.VisualStudio2013);
                }
                else if (combo.SelectedIndex == 9)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Lime);
                }
                else if (combo.SelectedIndex == 10)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Saffron);
                }
                else if (combo.SelectedIndex == 11)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office365);
                }
                else if (combo.SelectedIndex == 12)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2016White);
                }
                else if (combo.SelectedIndex == 13)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2016DarkGray);
                }
                else if (combo.SelectedIndex == 14)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2016Colorful);
                }
                else if (combo.SelectedIndex == 15)
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.VisualStudio2015);
                }
                else
                {
                    Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.SystemTheme);
                }
            }
        }
    }

    public class Model
    {
        public DateTime Year
        {
            get;
            set;
        }
        public double China
        {
            get;
            set;
        }

        public double India
        {
            get;
            set;
        }
    }

    public class ViewModel
    {
        public ObservableCollection<Model> Population
        {
            get;
            set;
        }

        public List<object> ChartThemes { get; set; }

        public ViewModel()
        {
            this.Population = new ObservableCollection<Model>();
            ChartThemes = Enum.GetValues(typeof(Syncfusion.SfSkinManager.VisualStyles)).OfType<object>().ToList();
            ChartThemes.RemoveAt(0);
            DateTime date = new DateTime(2006, 1, 1);
            Population.Add(new Model { Year = date.AddYears(1), China = 1307.56, India = 1101.32 });
            Population.Add(new Model { Year = date.AddYears(2), China = 1314.48, India = 1117.73 });
            Population.Add(new Model { Year = date.AddYears(3), China = 1321.29, India = 1134.02 });
            Population.Add(new Model { Year = date.AddYears(4), China = 1328.2, India = 1150.2 });
            Population.Add(new Model { Year = date.AddYears(5), China = 1334.5, India = 1166.23 });
            Population.Add(new Model { Year = date.AddYears(6), China = 1340.91, India = 1186 });
            Population.Add(new Model { Year = date.AddYears(7), China = 1347.35, India = 1210.57 });
            Population.Add(new Model { Year = date.AddYears(8), China = 1353.04, India = 1213.37 });
        }
    }
}
