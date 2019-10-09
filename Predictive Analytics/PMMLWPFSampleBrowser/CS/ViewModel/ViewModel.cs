#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;

namespace PMMLWPFSampleBrowser
{
    public class ViewModel : NotificationObject
    {
        #region Private properties

        private DispatcherTimer timer;
        private Paragraph m_Source;
        private Paragraph m_RScript;
        private Paragraph m_Pmml;
        private BaseCommand m_LoadCommand;
        private BaseCommand m_modelClickCommand;
        private BaseCommand m_ItemsSourceChangedCommand;
        private BaseCommand m_sfDataGridLoadCommand;
        private BaseCommand m_sfDataPagerLoadCommand;
        private FlowDocument m_cSharpDocument;
        private FlowDocument m_rDocument;
        private FlowDocument m_pmmlDocument;
        private DataTable m_outputValue;
        private object m_selectedItem;
        private bool m_Visible= false;
        private bool m_IsBusy;
        private int m_pageSize=24;
        private BackgroundWorker bgWorker;
        private List<Model> m_modelCollection;
        private Syncfusion.Windows.Controls.Navigation.SfTreeNavigator sfTreeNavigator = null;
        private Syncfusion.UI.Xaml.Controls.DataPager.SfDataPager sFDataPager = null;
        private Syncfusion.UI.Xaml.Grid.SfDataGrid sFDataGrid = null;
        private Sample sample = null;
        private int m_pageCount = 10;
        private bool isLoading = false;
        private string m_selectedSampleName;
        
        #endregion Private properties

        #region Constructor

        public ViewModel()
        {
            this.CSharpDocument = new FlowDocument();
            this.RDocument = new FlowDocument();
            this.PMMLDocument = new FlowDocument();
            this.OutputValue = new DataTable();            
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
        }

        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }

        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.sfTreeNavigator != null)
            {                
                    if (this.SelectedItem is Model)
                    {
                        var Model = this.SelectedItem as Model;

                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                            {
                                if (sfTreeNavigator != null && Model != null)
                                {
                                    Model.SampleCollection[0].IsSelected = true;

                                    this.sfTreeNavigator.SelectedItem = Model.SampleCollection[0];
                                }
                                this.IsBusy = false;                                
                                Visible = true;
                            }));
                       
                    }
                    else if (this.SelectedItem is Sample)
                    {
                        Sample = this.SelectedItem as Sample;

                        if (sfTreeNavigator != null && Sample != null)
                        {                            
                            Sample.LoadSample();                            
                        }
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            this.SelectedSampleName = this.Sample.ModelName + " / " + this.Sample.Name;
                            this.IsBusy = false;
                            Visible = true;
                        }));                       
                    }
                    else if (this.SelectedItem is ViewModel)
                    {
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            this.IsBusy = false;
                        }));
                    }

            }
            
        }

        #endregion Constructor

        #region Public properties

        /// <summary>
        /// Gets or sets the InputColumnCount
        /// </summary>
        public int InputColumnCount { get; set; }

        /// <summary>
        /// Gets or sets the ModelCollection for PMMLWPFSampleBrowser
        /// </summary>
        public List<Model> ModelCollection
        {
            get
            {
                return m_modelCollection;
            }
            set
            {
                m_modelCollection = value;
                this.RaisePropertyChanged("ModelCollection");
            }
        }

        /// <summary>
        /// Get the ItemsSourceChangedCommand
        /// </summary>
        public BaseCommand  ItemsSourceChangedCommand
        {
            get
            {
                if(m_ItemsSourceChangedCommand==null)
                {
                    m_ItemsSourceChangedCommand = new BaseCommand(ItemsSourceChanged);
                }
                return m_ItemsSourceChangedCommand;
            }
        }
        

        /// <summary>
        /// Gets or sets the C# source
        /// </summary>
        public Paragraph Source
        {
            get
            {
                return m_Source;
            }
            set
            {
                m_Source = value;
                RaisePropertyChanged("Source");
            }
        }

        /// <summary>
        /// Get or sets the RScript source
        /// </summary>
        public Paragraph RScript
        {
            get
            {
                return m_RScript;
            }
            set
            {
                m_RScript = value;
                RaisePropertyChanged("RScript");
            }
        }

        /// <summary>
        /// Gets or sets the Pmml source
        /// </summary>
        public Paragraph Pmml
        {
            get
            {
                return m_Pmml;
            }
            set
            {
                m_Pmml = value;
                RaisePropertyChanged("PMML");
            }
        }       

        /// <summary>
        /// get and set the csharpdocument
        /// </summary>
        public FlowDocument CSharpDocument
        {
            get
            {
                return m_cSharpDocument;
            }
            set
            {
                m_cSharpDocument = value;
                RaisePropertyChanged("CSharpDocument");
            }
        }

        /// <summary>
        /// get and set the rdocument
        /// </summary>
        public FlowDocument RDocument
        {
            get
            {
                return m_rDocument;
            }
            set
            {
                m_rDocument = value;
                RaisePropertyChanged("RDocument");
            }
        }

        /// <summary>
        /// get and set the pmmldocument
        /// </summary>
        public FlowDocument PMMLDocument
        {
            get
            {
                return m_pmmlDocument;
            }
            set
            {
                m_pmmlDocument = value;
                RaisePropertyChanged("PMMLDocument");
            }
        }

        /// <summary>
        /// get and set the output value as datatable
        /// </summary>
        public DataTable OutputValue
        {
            get
            {
                return m_outputValue;
            }
            set
            {
                m_outputValue = value;
                this.RaisePropertyChanged("OutputValue");
            }
        }

        /// <summary>
        /// Get the Selected item from TreeNavigator
        /// </summary>
        public object SelectedItem
        {
            get
            {
                return m_selectedItem;
            }
            set
            {
                m_selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Get and set the visibility mode for Tabcontrol
        /// </summary>
        public bool Visible
        {
            get
            {
                return m_Visible;
            }
            set
            {
                m_Visible = value;
                RaisePropertyChanged("Visible");
            }
        }

        /// <summary>
        /// Get and set the busy mode for Busy Indicator
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return m_IsBusy;
            }
            set
            {
                m_IsBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        /// <summary>
        /// Get or set the PageSize
        /// </summary>
        public int PageSize
        {
            get
            {
                return m_pageSize;
            }
            set
            {
                m_pageSize = value;
            }
        }

        /// <summary>
        /// Get or set the sample
        /// </summary>
        public Sample Sample
        {
            get
            {
                return sample;
            }
            set
            {
                sample = value;
                RaisePropertyChanged("Sample");
            }
        }

        /// <summary>
        /// Get or set the PageCount
        /// </summary>
        public int PageCount
        {
            get
            {
                return m_pageCount;
            }
            set
            {
                m_pageCount = value;
                RaisePropertyChanged("PageCount");
            }
        }

        /// <summary>
        /// Get or set the selected sample name
        /// </summary>
        public string SelectedSampleName
        {
            get
            {
                return m_selectedSampleName;
            }
            set
            {
                m_selectedSampleName = value;
                RaisePropertyChanged("SelectedSampleName");
            }
        }
        
        /// <summary>
        /// Get or set the SfDataPager
        /// </summary>
        public Syncfusion.UI.Xaml.Controls.DataPager.SfDataPager SFDataPager
        {
            get
            {
                return sFDataPager;
            }
            set
            {
                sFDataPager = value;
            }
        }

        /// <summary>
        /// Get or set the SfDataGrid
        /// </summary>
        public Syncfusion.UI.Xaml.Grid.SfDataGrid SFDataGrid
        {
            get
            {
                return sFDataGrid;
            }
            set
            {
                sFDataGrid = value;
            }
        }


        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }
        #endregion Public properties

        #region Commands

        /// <summary>
        /// Get the Initial loaded command
        /// </summary>
        public BaseCommand LoadCommand
        {
            get
            {
                if (m_LoadCommand == null)
                {
                    m_LoadCommand = new BaseCommand(Load);
                }
                return m_LoadCommand;
            }
        }

        /// <summary>
        /// Get the Model Click command
        /// </summary>
        public BaseCommand ModelClickCommand
        {
            get
            {
                if (m_modelClickCommand == null)
                {
                    m_modelClickCommand = new BaseCommand(ModelClicked);
                }
                return m_modelClickCommand;
            }
        }

        /// <summary>
        /// Get the SfDataGrid load command
        /// </summary>
        public BaseCommand SfDataGridLoadCommand
        {
            get
            {
                if (m_sfDataGridLoadCommand == null)
                {
                    m_sfDataGridLoadCommand = new BaseCommand(SFDataGridLoad);
                }
                return m_sfDataGridLoadCommand;
            }
            
        }

        /// <summary>
        /// Get the SfDataPager Load event
        /// </summary>
        public BaseCommand SFDataPagerLoadCommand
        {
            get
            {
                if (m_sfDataPagerLoadCommand == null)
                {
                    m_sfDataPagerLoadCommand=new BaseCommand(SFDataPagerLoad);
                }
                return m_sfDataPagerLoadCommand;
            }
        }

       
        #endregion               

        #region Methods

        /// <summary>
        /// Initial loaded values in treeview
        /// </summary>
        /// <param name="obj">Initial selected items</param>
        public void Load(object obj)
        {
            ModelCollection = GetModels();

            sfTreeNavigator = obj as Syncfusion.Windows.Controls.Navigation.SfTreeNavigator;

            if (sfTreeNavigator != null && ModelCollection[0] != null)
            {
                this.IsBusy = false;
                Visible = true;
                ModelCollection[0].SampleCollection[0].IsSelected = true;
                
                this.Sample = ModelCollection[0].SampleCollection[0];
                this.SelectedSampleName = this.Sample.ModelName + " / " + this.Sample.Name;
                this.SelectedItem = ModelCollection[0];
                this.Sample.LoadSample();
            }

           
        }

        /// <summary>
        /// Loads initial sample of model clicked
        /// </summary>
        /// <param name="obj">Initial selected items</param>
        private void ModelClicked(object obj)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    sfTreeNavigator = obj as Syncfusion.Windows.Controls.Navigation.SfTreeNavigator;
                    timer = new DispatcherTimer();
                    this.IsBusy = true;
                    timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
                    timer.Start();
                    timer.Tick += timer_Tick;
                }));            
        }

         /// <summary>
        /// ItemsSource changed event for each samples
        /// </summary>
        /// <param name="obj">SfDataGrid</param>
        private void ItemsSourceChanged(object obj)
        {
            var SfDataGrid = obj as Syncfusion.UI.Xaml.Grid.SfDataGrid;

            var inputColumnCount = this.InputColumnCount;
            var columnNames = this.OutputValue.Columns;
            for (int i = 0; i < columnNames.Count; i++)
            {
                if (i >= inputColumnCount)
                {
                    SfDataGrid.Columns[i].CellStyle = Application.Current.Resources["predictedColumnColor"] as Style;
                }
            }
        }

        private void SFDataPagerLoad(object obj)
        {
            this.SFDataPager = obj as Syncfusion.UI.Xaml.Controls.DataPager.SfDataPager;
            this.SFDataPager.OnDemandLoading += SFDataPager_OnDemandLoading;
        }

        void SFDataPager_OnDemandLoading(object sender, Syncfusion.UI.Xaml.Controls.DataPager.OnDemandLoadingEventArgs args)
        {
            if (args.StartIndex > 0&&!this.IsLoading)
            {
                Sample.UpdateSample(args.StartIndex);
            }
        }

        private void SFDataGridLoad(object obj)
        {
            this.SFDataGrid = obj as Syncfusion.UI.Xaml.Grid.SfDataGrid;
        }

        /// <summary>
        /// Timer tick event for busy indicator
        /// </summary>
        /// <param name="sender">timer</param>
        /// <param name="e">timer tick event</param>
        void timer_Tick(object sender, EventArgs e)
        {
            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    timer.Stop();
                }));
            }
        }

        /// <summary>
        /// Create the Model Collection from Sample.xml file
        /// </summary>
        /// <returns></returns>
        private List<Model> GetModels()
        {
            var list = new List<Model>();
#if NETCORE
            var path = string.Format("..\\..\\..\\..\\..\\Samples.xml");
#else
            var path = string.Format("..\\..\\..\\..\\Samples.xml");
#endif
            if (File.Exists(path))
            {
                StreamReader streamreader = new StreamReader(path);
                XDocument document = XDocument.Load(streamreader);

                //iterate the xml element
                foreach (XElement models in document.Descendants(XName.Get("Model")))
                {
                    string modelName = models.Attribute(XName.Get("Name")) != null ?
                        models.Attribute(XName.Get("Name")).Value.ToString() : string.Empty;
                    string tag = models.Attribute(XName.Get("Tag")) != null ?
                        models.Attribute(XName.Get("Tag")).Value.ToString() : string.Empty;

                    var model = new Model()
                    {
                        Name = modelName,
                        Tag = tag,
                        SampleCollection = new List<Sample>()
                    };

                    foreach (XElement samples in models.Descendants(XName.Get("Sample")))
                    {
                        string sampleName = samples.Attribute(XName.Get("Name")) != null ?
                            samples.Attribute(XName.Get("Name")).Value.ToString() : string.Empty;
                        string samplePath = samples.Attribute(XName.Get("SamplePath")) != null ?
                            samples.Attribute(XName.Get("SamplePath")).Value.ToString() : string.Empty;
                        string sampleTag = samples.Attribute(XName.Get("Tag")) != null ?
                        samples.Attribute(XName.Get("Tag")).Value.ToString() : string.Empty;

                        var sample = new Sample()
                        {
                            Name = sampleName,
                            SamplePath = samplePath,
                            Tag = sampleTag,
                            ModelName = modelName,
                            viewModel = this
                        };

                        model.SampleCollection.Add(sample);
                    }

                    if (list.Count == 0)
                    {
                        model.IsExpanded = true;

                        if (model.SampleCollection != null && model.SampleCollection.Count > 0)
                        {
                            model.SampleCollection[0].IsSelected = true;
                        }
                    }

                    list.Add(model);
                }
            }
            return list;
        }

        #endregion Methods        
    }
}