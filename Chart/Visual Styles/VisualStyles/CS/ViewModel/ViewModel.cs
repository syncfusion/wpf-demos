#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStyles
{
    public class ViewModel : INotifyPropertyChanged
    {
        private int m_selectedIndex = -1;
        private ChartUserControl m_chartUserControl;

        public int SelectedIndex
        {
            get
            {
                return m_selectedIndex;
            }

            set
            {
                if (m_selectedIndex != value)
                {
                    m_selectedIndex = value;
                    SetStyle();
                    OnPropertyChanged("SelectedIndex");
                }
            }
        }

        public ChartUserControl ChartUserControl
        {
            get
            {
                return m_chartUserControl;
            }

            set
            {
                m_chartUserControl = value;
                OnPropertyChanged("ChartUserControl");
            }
        }

        public ObservableCollection<Model> Population
        {
            get;
            set;
        }

        public List<object> ChartThemes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

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
            ChartUserControl = new ChartUserControl();
            SelectedIndex = 0;
        }

        private void SetStyle()
        {
            var columnChart = ChartUserControl.Content as SfChart;

            if (columnChart != null)
            {
                switch (m_selectedIndex)
                {
                    case 0:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Blend);
                        break;

                    case 1:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Metro);
                        break;

                    case 2:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2010Black);
                        break;

                    case 3:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2010Blue);
                        break;

                    case 4:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2010Silver);
                        break;

                    case 5:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2013DarkGray);
                        break;

                    case 6:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2013LightGray);
                        break;

                    case 7:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2013White);
                        break;

                    case 8:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.VisualStudio2013);
                        break;

                    case 9:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Lime);
                        break;

                    case 10:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Saffron);
                        break;

                    case 11:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office365);
                        break;

                    case 12:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2016White);
                        break;

                    case 13:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2016DarkGray);
                        break;

                    case 14:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.Office2016Colorful);
                        break;

                    case 15:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.VisualStudio2015);
                        break;

                    default:
                        Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(columnChart, Syncfusion.SfSkinManager.VisualStyles.SystemTheme);
                        break;
                }
            }
        }
    
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
