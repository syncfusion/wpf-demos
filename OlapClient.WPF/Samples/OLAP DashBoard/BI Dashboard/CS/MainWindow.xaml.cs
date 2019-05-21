#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace BIDashboard
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using BIDashboard.DashboardLayout;
    using BIDashboard.Dialogs;
    using BIDashboard.Helper;
    using Microsoft.Win32;
    using Syncfusion.Windows.Chart.Olap;
    using Syncfusion.Windows.Gauge.Olap;
    using Syncfusion.Windows.Grid.Olap;
    using Syncfusion.Windows.Shared;
    using System.IO;
    using SampleUtils;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleWindow
    {
        #region [ Members ]
        public static readonly DependencyProperty DashboardReportProperty =
    DependencyProperty.Register("DashboardReport", typeof(DashboardReport), typeof(MainWindow), new UIPropertyMetadata(new DashboardReport()));

        public static readonly DependencyProperty SelectedControlProperty =
            DependencyProperty.Register("SelectedControl", typeof(Tile), typeof(MainWindow), new UIPropertyMetadata(null,
                (s, e) =>
                {
                    var mainWindow = (MainWindow)s;

                    if (e.NewValue != null && e.NewValue != e.OldValue)
                    {
                        var newValue = (Tile)e.NewValue;

                        mainWindow.SelectedReport = (from r in mainWindow.DashboardReport.Reports
                                                     where r.ReportName == newValue.Report.ReportName
                                                     select r).FirstOrDefault();
                    }
                }));

        public static readonly DependencyProperty SelectedReportProperty =
            DependencyProperty.Register("SelectedReport", typeof(Report), typeof(MainWindow), new UIPropertyMetadata(null));

        public static readonly DependencyProperty DashboardTitleProperty =
            DependencyProperty.Register("DashboardTitle", typeof(string), typeof(MainWindow), new UIPropertyMetadata("BI Dashboard"));

        public static readonly DependencyProperty ItemsCountProperty =
            DependencyProperty.Register("ItemsCount", typeof(int), typeof(MainWindow), new UIPropertyMetadata(0,
                (s, e) =>
                {
                    var mainWindow = (MainWindow)s;

                    if (e.NewValue != e.OldValue && e.NewValue != null)
                    {
                        if ((int)e.NewValue < (int)e.OldValue)
                        {
                            var deletedItemName = mainWindow.FindDeletedItem();
                            // mainWindow.DashboardReport.Tiles.Remove(mainWindow.DashboardReport.Tiles.Where(t => t.Header == deletedItemName).FirstOrDefault());
                        }
                    }
                }));
        private BIDashboard.Command.DelegateCommand addControlCommand;
        private BIDashboard.Command.DelegateCommand saveCommand;
        private BIDashboard.Command.DelegateCommand loadCommand;
        private BIDashboard.Command.DelegateCommand bindCommand;
        private BIDashboard.Command.DelegateCommand renameCommand;

        #endregion

        #region [ Constructor ]

        public MainWindow()
        {
            InitializeComponent();

            ConnectionHelper.Instance.UseConnectionName = false;
            ConnectionHelper.Instance.ConnectionName = GetConnectionString();

            this.UpdateReports();
            this.InitializeDetectTileDeletion();

            this.DefaultReport();
            this.tileViewControl.Maximized += new TileViewControl.TileViewEventHandler(tileViewControl_StateChanged);
            this.tileViewControl.Minimized += new TileViewControl.TileViewEventHandler(tileViewControl_StateChanged);

            this.DataContext = this;
        }

        #endregion

        #region [ Properties ]
        public BIDashboard.Command.DelegateCommand SaveCommand
        {
            get
            {
                if (this.saveCommand == null)
                {
                    this.saveCommand = new BIDashboard.Command.DelegateCommand(
                        () => Save(),
                        () => CanSave());
                }

                return this.saveCommand;
            }
        }
        public BIDashboard.Command.DelegateCommand LoadCommand
        {
            get
            {
                if (this.loadCommand == null)
                {
                    this.loadCommand = new BIDashboard.Command.DelegateCommand(
                        () => Load(),
                        () => CanLoad());
                }

                return this.loadCommand;
            }
        }
        public BIDashboard.Command.DelegateCommand BindCommand
        {
            get
            {
                if (this.bindCommand == null)
                {
                    this.bindCommand = new BIDashboard.Command.DelegateCommand(
                        () => Bind(),
                        () => CanBind());
                }

                return this.bindCommand;
            }
        }

        public BIDashboard.Command.DelegateCommand RenameCommand
        {
            get
            {
                if (this.renameCommand == null)
                {
                    this.renameCommand = new BIDashboard.Command.DelegateCommand(
                        () => Rename(),
                        () => CanRename());

                }

                return this.renameCommand;
            }
        }

        public DashboardReport DashboardReport
        {
            get { return (DashboardReport)GetValue(DashboardReportProperty); }
            set { SetValue(DashboardReportProperty, value); }
        }

        public Tile SelectedControl
        {
            get { return (Tile)GetValue(SelectedControlProperty); }
            set { SetValue(SelectedControlProperty, value); }
        }

        public Report SelectedReport
        {
            get { return (Report)GetValue(SelectedReportProperty); }
            set { SetValue(SelectedReportProperty, value); }
        }

        public string DashboardTitle
        {
            get { return (string)GetValue(DashboardTitleProperty); }
            set { SetValue(DashboardTitleProperty, value); }
        }

        public int ItemsCount
        {
            get { return (int)GetValue(ItemsCountProperty); }
            set { SetValue(ItemsCountProperty, value); }
        }

        public BIDashboard.Command.DelegateCommand AddControlCommand
        {
            get
            {
                if (this.addControlCommand == null)
                {
                    this.addControlCommand = new BIDashboard.Command.DelegateCommand(
                        () => SelectCommand(),
                        () => CanSelectCommand());
                }

                return this.addControlCommand;
            }
        }
        #endregion

        #region [ Dependency Properties ]

        #region [ Find Deleted Item ]
        private void DefaultReport()
        {
            Tile tile = new Tile();
            tile.Header = "OlapChart";
            this.DashboardReport.Tiles.Add(tile);
            tile.Report = this.DashboardReport.Reports.ElementAt(1);
            tile.ControlType = "Chart";
            OlapChart olapChart = new OlapChart()
            {
                OlapDataManager = OlapDataSourceHelper.GetManager(tile.Report.ReportFileName, GetConnectionString())
            };
            olapChart.Loaded += new RoutedEventHandler(olapChart_Loaded);
            this.tileViewControl.Items.Add(new TileViewItem
            {
                Header = tile.Header,
                Tag = olapChart,
                TileViewItemState = tile.TileState,
                Content = olapChart
            });
        }

        void tileViewControl_StateChanged(object sender, TileViewEventArgs args)
        {
            foreach (TileViewItem item in tileViewControl.Items)
            {
                var tile = (from t in this.DashboardReport.Tiles
                            where t.Header == item.Header.ToString()
                            select t).FirstOrDefault();

                if (tile != null)
                {
                    tile.TileState = item.TileViewItemState;
                }
            }
        }

        private void InitializeDetectTileDeletion()
        {
            this.SetBinding(ItemsCountProperty, new System.Windows.Data.Binding() { Source = this.tileViewControl.Items, Path = new PropertyPath("Count"), Mode = System.Windows.Data.BindingMode.OneWay });
        }

        private string FindDeletedItem()
        {
            var deletedItem = string.Empty;

            foreach (var item in this.DashboardReport.Tiles)
            {
                if (!GetIsInTileViewControl(item.Header))
                {
                    deletedItem = item.Header.ToString();
                }
            }

            return deletedItem;
        }

        private bool GetIsInTileViewControl(string header)
        {
            var tileExist = false;

            foreach (TileViewItem item in tileViewControl.Items)
            {
                if (item.Header.ToString() == header)
                {
                    tileExist = true;
                }
            }

            return tileExist;
        }

        #endregion

        #endregion

        #region [ Commands ]

        #region [ Add Control ]


        private bool CanSelectCommand()
        {
            return true;
        }

        private void SelectCommand()
        {
            AddControlWindow addWindow = new AddControlWindow(this.addControlCommand.CommandParameter);
            addWindow.Owner = this;
            addWindow.CurrentCollection = this.DashboardReport.Reports;

            var dialogResult = addWindow.ShowDialog().Value;

            if (dialogResult)
            {
                //// Add the recently added tile to the dashboard report
                this.DashboardReport.Tiles.Add(addWindow.Tile);

                this.CreateTile(addWindow.Tile);
            }
        }

        #endregion

        #region [ Save to File ]

        private void Save()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Reports";
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml;";
            var dialogResult = saveFileDialog.ShowDialog().Value;

            if (dialogResult == true)
            {
                SerializationHelper.Serialize<DashboardReport>(typeof(DashboardReport), this.DashboardReport, saveFileDialog.FileName);
                MessageBox.Show(@"File saved to '" + saveFileDialog.FileName + "'");
            }
        }

        private bool CanSave()
        {
            return true;
        }

        #endregion

        #region [ Load from File ]


        private void Load()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "XML Files (*.xml)|*.xml;";
                openFileDialog.Title = "Open Report Layout";

                var dialogResult = openFileDialog.ShowDialog().Value;

                if (dialogResult == true)
                {
                    this.DashboardReport = SerializationHelper.Deserialize<DashboardReport>(typeof(DashboardReport), openFileDialog.FileName);

                    if (this.DashboardReport != null)
                    {
                        //// Clearing the collection before opening new collection.
                        this.tileViewControl.Items.Clear();
                        LoadAndConfigureControls(this.DashboardReport);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Unable to load the specified file.");
            }
        }

        private bool CanLoad()
        {
            return true;
        }

        #endregion

        #region [ Bind Reports ]

        private void Bind()
        {
            this.SelectedControl.Report = this.SelectedReport;

            var control = (from TileViewItem t in this.tileViewControl.Items
                           where t.Header == this.SelectedControl.Header
                           select t).FirstOrDefault();

            if (control != null)
            {
                if (this.SelectedControl.ControlType == "Chart")
                {
                    (control.Content as OlapChart).OlapDataManager = OlapDataSourceHelper.GetManager(this.SelectedControl.Report.ReportFileName, GetConnectionString());
                }
                else if (this.SelectedControl.ControlType == "Grid")
                {
                    (control.Content as OlapGrid).OlapDataManager = OlapDataSourceHelper.GetManager(this.SelectedControl.Report.ReportFileName, GetConnectionString());
                }
                else if (this.SelectedControl.ControlType == "Gauge")
                {
                    (control.Content as OlapGauge).OlapDataManager = OlapDataSourceHelper.GetManager(this.SelectedControl.Report.ReportFileName, GetConnectionString());
                }
            }
        }

        private bool CanBind()
        {
            if (this.SelectedControl != null &&
                this.SelectedReport != null)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region [ Rename Dashboard ]

        private void Rename()
        {
            RenameDialog renameDialog = new RenameDialog(this.DashboardTitle);
            renameDialog.Owner = this;
            var result = renameDialog.ShowDialog().Value;

            if (result == true)
            {
                this.DashboardTitle = renameDialog.textBox1.Text;
                this.DashboardReport.Name = this.DashboardTitle;
            }
        }

        private bool CanRename()
        {
            return true;
        }

        #endregion

        #endregion

        #region [ Control Initialization and Helper methods ]

        /// <summary>
        /// Loads/Creates a single tile.
        /// </summary>
        /// <param name="tile"></param>
        private void CreateTile(Tile tile)
        {
            try
            {
                this.tileViewControl.Items.Add(new TileViewItem
                {
                    Header = tile.Header,
                    Tag = tile,
                    TileViewItemState = tile.TileState,
                    Content = CreateControl(tile)
                });
            }
            catch (Exception ex)
            {
                this.DashboardReport.Tiles.Remove(tile);
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Helps to create a control for a tile.
        /// </summary>
        /// <param name="controlType"></param>
        /// <param name="tile"></param>
        /// <returns></returns>
        private FrameworkElement CreateControl(Tile tile)
        {
            var controlType = tile.ControlType;

            switch (controlType)
            {
                case "Chart":
                    OlapChart olapChart = new OlapChart()
                    {
                        OlapDataManager = OlapDataSourceHelper.GetManager(tile.Report.ReportFileName, GetConnectionString())
                    };
                    olapChart.Loaded += new RoutedEventHandler(olapChart_Loaded);
                    return olapChart;
                case "Grid":
                    return new OlapGrid()
                    {
                        Style = (Style)FindResource("olapGridStyle"),
                        OlapDataManager = OlapDataSourceHelper.GetManager(tile.Report.ReportFileName, GetConnectionString())
                    };
                case "Gauge":
                    OlapGauge olapGauge = new OlapGauge()
                    {
                        OlapDataManager = OlapDataSourceHelper.GetManager(tile.Report.ReportFileName, GetConnectionString())
                    };
                    SkinStorage.SetVisualStyle(olapGauge, "Office2007Blue");
                    return olapGauge;
            }

            return null;
        }

        void olapChart_Loaded(object sender, RoutedEventArgs e)
        {
            var olapChart = (sender as OlapChart);

            this.Dispatcher.BeginInvoke((Action)(() =>
            {
                try
                {
                    var foregroundBrush = (Brush)FindResource("foregroundColor");
                    var gridLineStroke = (Pen)FindResource("chartGridLineStroke");

                    if (olapChart.SecondaryAxis == null)
                    {
                        olapChart.SecondaryAxis = new Syncfusion.Windows.Chart.ChartAxis();
                    }

                    olapChart.GridLineStroke = gridLineStroke;
                    olapChart.PrimaryAxis.LabelForeground = foregroundBrush;
                    olapChart.SecondaryAxis.LabelForeground = foregroundBrush;
                    olapChart.ColorModel.Palette = Syncfusion.Windows.Chart.ChartColorPalette.MixedFantasy;

                    foreach (var series in olapChart.Series)
                    {
                        series.Interior.Opacity = 0.83;
                        series.StrokeThickness = 0.5;
                        series.Stroke = foregroundBrush;
                    }
                }
                catch
                {
                    //// Rarely frozen brush might throw exception.
                }

            }));
        }

        /// <summary>
        /// Loads entire set of tiles.
        /// </summary>
        /// <param name="dashboardReport"></param>
        private void LoadAndConfigureControls(DashboardReport dashboardReport)
        {
            this.DashboardTitle = dashboardReport.Name;

            foreach (var tile in dashboardReport.Tiles)
            {
                this.CreateTile(tile);
            }
        }

        #endregion

        #region [ Reprot Initialization helper method ]

        private void UpdateReports()
        {
            var reportsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Reports/");
            var reportFileNames = new DirectoryInfo(reportsFolder).EnumerateFiles();

            foreach (var reportFile in reportFileNames)
            {
                this.DashboardReport.Reports.Add(new Report { ReportFileName = reportFile.FullName, ReportName = reportFile.Name.Substring(0, reportFile.Name.Length - 4) });
            }
        }

        #endregion
    }

    #region [ Testing Converter ]

    public sealed class TempConverter
        : System.Windows.Data.IValueConverter
    {
        #region [ IValueConverter Members ]

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    #endregion
}