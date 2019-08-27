#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


namespace BIDashboard.Dialogs
{
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using BIDashboard.Command;
    using BIDashboard.DashboardLayout;
    using Microsoft.Win32;
    /// <summary>
    /// Interaction logic for AddControlWindow.xaml
    /// </summary>
    public partial class AddControlWindow 
        : Window, INotifyPropertyChanged
    {
        #region [ Members ]
        #region [ Dependency Properties ]

        public static readonly DependencyProperty TileHeaderProperty =
            DependencyProperty.Register("TileHeader", typeof(string), typeof(MainWindow), new UIPropertyMetadata(string.Empty));

        public static readonly DependencyProperty ReportLocationProperty =
            DependencyProperty.Register("ReportLocation", typeof(Report), typeof(MainWindow), new UIPropertyMetadata(null));

        public static readonly DependencyProperty CurrentCollectionProperty =
            DependencyProperty.Register("CurrentCollection", typeof(Reports), typeof(AddControlWindow), new UIPropertyMetadata(new Reports()));

        #endregion

        private Tile tile;
        private DelegateCommand addCommand;
        private DelegateCommand closeCommand;

        #endregion

        #region [ Constructor ]

        public AddControlWindow(string controlType)
        {
            InitializeComponent();

            this.tile = new Tile();
            this.tile.ControlType = controlType;

            this.DataContext = this;
        }

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        #region [ Properties ]

        public string TileHeader
        {
            get { return (string)GetValue(TileHeaderProperty); }
            set { SetValue(TileHeaderProperty, value); }
        }

        public Report ReportLocation
        {
            get { return (Report)GetValue(ReportLocationProperty); }
            set { SetValue(ReportLocationProperty, value); }
        }

        public Reports CurrentCollection
        {
            get { return (Reports)GetValue(CurrentCollectionProperty); }
            set { SetValue(CurrentCollectionProperty, value); }
        }

        public Tile Tile 
        {
            get { return this.tile; }
        }

        #endregion


        #region [ Commands ]

        #region [ Add Command ]

        public DelegateCommand AddCommand
        {
            get
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new DelegateCommand(
                        () => Add(),
                        () => CanAdd());
                }

                return this.addCommand;
            }
        }

        public DelegateCommand CloseCommand
        {
            get
            {
                if (this.closeCommand == null)
                {
                    this.closeCommand = new DelegateCommand(
                        () => ExecuteClose(),
                        () => CanClose());
                }

                return this.closeCommand;
            }
        }

        private void Add()
        {
            this.tile.Header = this.TileHeader;
            this.tile.Report = this.ReportLocation;

            this.DialogResult = true;
            this.Close();
        }

        private bool CanAdd()
        {
            if (!string.IsNullOrEmpty(this.TileHeader) &&
               this.ReportLocation != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region [ Close Command ]

        private void ExecuteClose()
        {
            this.DialogResult = false;
            this.Close();
        }

        private bool CanClose()
        {
            return true;
        }

        #endregion

        #endregion

        #region INotifyPropertyChanged Members

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
