#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.chartdemos.wpf
{
    public class CategoryDataViewModel : NotificationObject
    {
        private ICommand serializeCommand;

        private Visibility textVisibility;
        private Visibility chartVisibility;
        private bool loadIsEnabled;
        private double loadOpacity;

        public ICommand SerializeCommand 
        { 
            get
            {
                return serializeCommand;
            }
            set
            {
                serializeCommand = value;
                RaisePropertyChanged(nameof(this.SerializeCommand));
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
                RaisePropertyChanged(nameof(this.ChartVisibility));
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
                RaisePropertyChanged(nameof(this.TextVisibility));
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
                RaisePropertyChanged(nameof(this.LoadIsEnabled));
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
                RaisePropertyChanged(nameof(this.LoadOpacity));
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
                RaisePropertyChanged(nameof(this.XamlText));
            }
        }
        
        public UserControl SerializedChartContainer { get; set; }
        public UserControl DeserializedChartContainer { get; set; }

        public CategoryDataViewModel()
        {
            CategoricalDatas = new ObservableCollection<CategoryDataModel>();
            CategoricalDatas.Add(new CategoryDataModel("Gear", 25));
            CategoricalDatas.Add(new CategoryDataModel("Motor", 10));
            CategoricalDatas.Add(new CategoryDataModel("Bearing", 15));
            CategoricalDatas.Add(new CategoryDataModel("Switch", 20));
            CategoricalDatas.Add(new CategoryDataModel("Plug", 20));
            CategoricalDatas.Add(new CategoryDataModel("Cord", 35));
            CategoricalDatas.Add(new CategoryDataModel("Fuse", 40));
            CategoricalDatas.Add(new CategoryDataModel("Pump", 20));
            CategoricalDatas.Add(new CategoryDataModel("Leak", 15));
            CategoricalDatas.Add(new CategoryDataModel("Seals", 40));

            SerializedChartContainer = new SerializedChartContainer();
            DeserializedChartContainer = new DeserializedChartContainer();

            SerializeCommand = new DelegateCommand(Execute);
            LoadOpacity = 0.5;
            ChartVisibility = Visibility.Collapsed;
        }

        public void Execute(object parameter)
        {
            var executeCommand = parameter.ToString();

            if (executeCommand == "Save")
            {
                Save();
            }
            else
            {
                Load();
            }
        }

        public ObservableCollection<CategoryDataModel> CategoricalDatas
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
    }

}
