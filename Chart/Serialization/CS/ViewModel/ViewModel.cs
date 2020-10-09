#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Serialization.ViewModel.Command;
using Syncfusion.UI.Xaml.Charts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Serialization
{
    public class CategoryDataViewModel : INotifyPropertyChanged
    {
        private SerializeCommand serializeCommand;
        private Visibility textVisibility;
        private Visibility chartVisibility;
        private bool loadIsEnabled;
        private double loadOpacity;
        public event PropertyChangedEventHandler PropertyChanged;

        public SerializeCommand SerializeCommand 
        { 
            get
            {
                return serializeCommand;
            }
            set
            {
                serializeCommand = value;
                OnPropertyChanged("SerializeCommand");
            }        
        }

        public Visibility ChartVisibility 
        {
            get
            {
                return chartVisibility;
            }

            set
            {
                chartVisibility = value;
                OnPropertyChanged("ChartVisibility");
            }
        }

        public Visibility TextVisibility 
        {
            get
            {
                return textVisibility;
            }

            set
            {
                textVisibility = value;
                OnPropertyChanged("TextVisibility");
            }
        }
                
        public bool LoadIsEnabled
        {
            get 
            {
                return loadIsEnabled;
            }

            set 
            {
                loadIsEnabled = value;
                OnPropertyChanged("LoadIsEnabled");
            }
        }

        public double LoadOpacity
        {
            get 
            {
                return loadOpacity; 
            }

            set 
            {
                loadOpacity = value;
                OnPropertyChanged("LoadOpacity");
            }
        }

        private string xamlText;

        public string XamlText
        {
            get 
            {
                return xamlText;
            }

            set 
            {
                xamlText = value;
                OnPropertyChanged("XamlText");
            }
        }
        
        public UserControl SerializedChartContainer { get; set; }
        public UserControl DeserializedChartContainer { get; set; }

        public CategoryDataViewModel()
        {
            CategoricalDatas = new ObservableCollection<CategoryData>();
            CategoricalDatas.Add(new CategoryData("Gear", 5));
            CategoricalDatas.Add(new CategoryData("Motor", 10));
            CategoricalDatas.Add(new CategoryData("Bearing", 15));
            CategoricalDatas.Add(new CategoryData("Switch", 20));
            CategoricalDatas.Add(new CategoryData("Plug", 20));
            CategoricalDatas.Add(new CategoryData("Cord", 35));
            CategoricalDatas.Add(new CategoryData("Fuse", 40));
            CategoricalDatas.Add(new CategoryData("Pump", 20));
            CategoricalDatas.Add(new CategoryData("Leak", 15));
            CategoricalDatas.Add(new CategoryData("Seals", 40));

            SerializedChartContainer = new SerializedChartContainer();
            DeserializedChartContainer = new DeserializedChartContainer();

            SerializeCommand = new SerializeCommand(this);
            LoadOpacity = 0.5;
            ChartVisibility = Visibility.Collapsed;
        }

        public ObservableCollection<CategoryData> CategoricalDatas
        {
            get;
            set;
        }
        
        internal void Load()
        {
            TextVisibility = Visibility.Collapsed;
            (DeserializedChartContainer.Content) = (SfChart)(SerializedChartContainer.Content as SfChart).Deserialize();
            ChartVisibility = Visibility.Visible;
            LoadIsEnabled = false;
            LoadOpacity = 0.5;
        }

        internal void Save()
        {
            (SerializedChartContainer.Content as SfChart).Serialize();
            (DeserializedChartContainer.Content as SfChart).Visibility = Visibility.Collapsed;
            TextVisibility = Visibility.Visible;
            string filePath = System.IO.Directory.GetParent(@"../").FullName + "\\chart.xml";
            XamlText = System.IO.File.ReadAllText(filePath);
            LoadIsEnabled = true;
            LoadOpacity = 1;
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
