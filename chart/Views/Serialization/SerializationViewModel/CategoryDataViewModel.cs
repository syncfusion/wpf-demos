#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Manages chart data and commands for chart XML serialization/deserialization.</summary>
    public class CategoryDataViewModel : NotificationObject , IDisposable
    {
        private ICommand serializeCommand;

        private Visibility textVisibility;
        private Visibility chartVisibility;
        private bool loadIsEnabled;
        private double loadOpacity;

        /// <summary>Gets or sets the command that saves or loads the chart.</summary>
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

        /// <summary>Gets or sets the visibility of the deserialized chart view.</summary>
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

        /// <summary>Gets or sets the visibility of the serialized XAML text view.</summary>
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

        /// <summary>Gets or sets a value indicating whether the Load action is enabled.</summary>
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

        /// <summary>Gets or sets the opacity of the Load button.</summary>
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

        /// <summary>Gets or sets the serialized XAML content.</summary>
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

        /// <summary>Gets or sets the user control hosting the serialized chart.</summary>
        public UserControl SerializedChartContainer { get; set; }

        /// <summary>Gets or sets the user control hosting the deserialized chart.</summary>
        public UserControl DeserializedChartContainer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryDataViewModel"/> class.
        /// </summary>
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

        /// <summary>Executes the Save or Load action based on the command parameter.</summary>
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

        /// <summary>Gets or sets the source data collection displayed by the chart.</summary>
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

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if (CategoricalDatas != null)
                CategoricalDatas.Clear();
        }
    }

}
