#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Events;
using System.Windows.Data;
using System.Collections.ObjectModel;
using PortfolioAnalyzer.Infrastructure;
using PortfolioAnalyzer.Model;
using System.Timers;
using Microsoft.Practices.Composite.Presentation.Commands;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Syncfusion.Windows;
using System.Windows.Shapes;

namespace PortfolioAnalyzer.RibbonModule
{
    /// <summary>
    /// Represents the DashBoardTabViewModel class which handles the interaction logic for DashBoardTabView.
    /// </summary>
    public class DashBoardTabViewModel :Control, INotifyPropertyChanged
    {
        #region Members
        IEventAggregator eventAggregator;
        private readonly IModuleManager moduleManager;
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer unityContainer;

        private ObservableCollection<Path> liveUpdatesPathCollection;

        public ObservableCollection<Path> LiveUpdatesPathCollection
        {
            get { return liveUpdatesPathCollection; }
            set { liveUpdatesPathCollection = value;
                this.OnPropertyChanged("LiveUpdatesPathCollection");
            }
        }

        private ObservableCollection<Path> stopUpdatesPathCollection; 

        public ObservableCollection<Path> StopUpdatesPathCollection
        {
            get { return stopUpdatesPathCollection; }
            set { stopUpdatesPathCollection = value;
                this.OnPropertyChanged("StopUpdatesPathCollection");
            }
        }

        private ObservableCollection<Path> activateAnimationPathCollection;

        public ObservableCollection<Path> ActivateAnimationPathCollection
        {
            get { return activateAnimationPathCollection; }
            set
            {
                activateAnimationPathCollection = value;
                this.OnPropertyChanged("ActivateAnimationPathCollection");
            }
        }

        private ObservableCollection<Path> deactivateAnimationPathCollection;

        public ObservableCollection<Path> DeactivateAnimationPathCollection
        {
            get { return deactivateAnimationPathCollection; }
            set
            {
                deactivateAnimationPathCollection = value;
                this.OnPropertyChanged("DeactivateAnimationPathCollection");
            }
        }

        private ObservableCollection<Path> liveVectorImage = new ObservableCollection<Path>();

        public ObservableCollection<Path> LiveVectorImage
        {
            get { return liveVectorImage; }
            set { liveVectorImage = value;
                this.OnPropertyChanged("LiveVectorImage");
            }
        }

        private ObservableCollection<Path> animationVectorImage;

        public ObservableCollection<Path> AnimationVectorImage
        {
            get { return animationVectorImage; }
            set { animationVectorImage = value;
                OnPropertyChanged("AnimationVectorImage");
            }
        }


        string animationlabel;
        string liveButtonDetails;
        BackgroundWorker worker = new BackgroundWorker();
        Window win;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DashBoardTabViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="moduleManager">The module manager.</param>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        public DashBoardTabViewModel(IEventAggregator eventAggregator, IModuleManager moduleManager, IRegionManager regionManager, IUnityContainer unityContainer)
        {
            this.eventAggregator = eventAggregator;
            this.moduleManager = moduleManager;
            this.regionManager = regionManager;
            this.unityContainer = unityContainer;
            this.LiveButtonDetails = "Live Updates";           
            this.AnimationLabel = "Activate Animation";
            this.liveVectorImage = new ObservableCollection<Path>();
            UpdatePathCollection();
            this.liveVectorImage = liveUpdatesPathCollection;
            this.animationVectorImage = new ObservableCollection<Path>();
            this.animationVectorImage = activateAnimationPathCollection;
            RegisterDelegates();
            InitializeWorker();
        }

        #region Implementation

        /// <summary>
        /// Registers the delegates.
        /// </summary>
        private void RegisterDelegates()
        {
            this.RealTimeUpdates = new DelegateCommand<object>(StartStopRealTimeUpdates);

            //Animation Events
            this.CubicAnimationType = new DelegateCommand<object>(o => eventAggregator.GetEvent<AnimationTypesEvents>().Publish("Cubic"));
            this.ElasticAnimationType = new DelegateCommand<object>(o => eventAggregator.GetEvent<AnimationTypesEvents>().Publish("Elastic"));
            this.BounceAnimationType = new DelegateCommand<object>(o => eventAggregator.GetEvent<AnimationTypesEvents>().Publish("Bounce"));
            this.BackAnimationType = new DelegateCommand<object>(o => eventAggregator.GetEvent<AnimationTypesEvents>().Publish("Back"));
            this.QuinticAnimationType = new DelegateCommand<object>(o => eventAggregator.GetEvent<AnimationTypesEvents>().Publish("Quintic"));

            this.SelectView = new DelegateCommand<object>(o => eventAggregator.GetEvent<SelectedViewEvents>().Publish("Dashboard"));
            this.ActivateAnimation = new DelegateCommand<object>(ActivateAnimationHandler);
            this.eventAggregator.GetEvent<SelectedViewEvents>().Subscribe(SelectedViewEventHandler);
        }

        /// <summary>
        /// Initializes the background worker.
        /// </summary>
        void InitializeWorker()
        {
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        }

        /// <summary>
        /// Shows the window.
        /// </summary>
        void ShowWindow()
        {
            win = new Window();
            ResourceDictionary rs = new ResourceDictionary();
            rs.Source = new Uri("/PortfolioAnalyzer.Infrastructure;component/Brushes.xaml", UriKind.RelativeOrAbsolute);
            DrawingBrush brush = rs["background"] as DrawingBrush;
            Border border = new Border();
            //border = this.Resources["border"] as Border;
            Label label = new Label();
            label.Content = "Please Wait...Loading Modules...";
            label.FontWeight = FontWeights.Bold;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.FontSize = 14;
            label.FontFamily = new FontFamily("Verdana");
            label.Foreground = Brushes.Black;
            border.Child = label;
            win.Background = brush;
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.BorderBrush = Brushes.Gray;
            win.BorderThickness = new Thickness(0.8);
            win.WindowStyle = WindowStyle.None;
            win.Height = 75;
            win.Width = 309;
            win.ShowInTaskbar = false;
            win.Content = border;
            win.Effect = new DropShadowEffect() { BlurRadius = 1, ShadowDepth = 180, Color = Colors.Black };
            WindowChrome.SetWindowChrome(win, new WindowChrome() { UseAeroCaptionButtons = false });
            win.Show();
        }

        public void UpdatePathCollection()
        {
            liveUpdatesPathCollection = new ObservableCollection<Path>();
            stopUpdatesPathCollection = new ObservableCollection<Path>();
            activateAnimationPathCollection = new ObservableCollection<Path>();
            deactivateAnimationPathCollection = new ObservableCollection<Path>();
            var converter = new System.Windows.Media.BrushConverter();
            Path live = new Path
            {
                Data = Geometry.Parse("M19.973338,14.255686 C20.191135,14.263163 20.410738,14.332203 20.602608,14.47126 20.965599,14.73525 21.134594,15.188232 21.008597,15.609217 20.014624,18.915091 16.855708,21.333999 13.107808,21.333999 10.934865,21.333999 8.9599178,20.520029 7.4909568,19.19208 L7.4899566,19.19308 6.0009967,20.066047 6.0009967,14.690251 11.378853,16.914166 9.4969034,18.017125 C10.502877,18.749097 11.751843,19.18808 13.107808,19.18808 15.842735,19.18808 18.150673,17.423147 18.876654,15.01024 19.023775,14.520758 19.494184,14.239238 19.973338,14.255686 z M13.400911,5.4500008 C15.523939,5.4500009 17.45896,6.2259974 18.916977,7.4999981 L20.509,6.533 20.701004,11.908995 15.322932,9.6839943 16.933952,8.7049952 C15.942942,8.0069978 14.721926,7.595999 13.400911,7.5959988 10.666876,7.595999 8.3588493,9.3599973 7.6328428,11.772993 7.4188354,12.484994 6.5208294,12.757993 5.9068234,12.312994 5.5438124,12.048994 5.3738121,11.595995 5.5008127,11.173995 6.4948281,7.8679979 9.6538634,5.4500009 13.400911,5.4500008 z M2,1.9999998 L2,24.999999 25,24.999999 25,1.9999998 z M1,0 L26,0 C26.552001,0 27,0.44700003 27,1 L27,25.999999 C27,26.553 26.552001,26.999999 26,26.999999 L1,26.999999 C0.44799995,26.999999 0,26.553 0,25.999999 L0,1 C0,0.44700003 0.44799995,0 1,0 z"),
                Height = 27,
                Width = 27,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Stretch = Stretch.Fill,
                Fill = (Brush)converter.ConvertFromString("#FF4E8024")
            };

            Path stop1 = new Path
            {
                Data = Geometry.Parse("M19.972812,14.254677 C20.190619,14.262154 20.410233,14.331195 20.602113,14.470255 20.966098,14.734238 21.135105,15.187224 21.00809,15.608213 20.014097,18.914091 16.855085,21.332 13.108058,21.332 10.935043,21.332 8.960058,20.520034 7.4900495,19.19208 L6.0000214,20.065049 6.0000214,14.689241 11.379045,16.912166 9.4970481,18.016114 C10.502058,18.748096 11.751057,19.186084 13.108058,19.186084 15.843087,19.186084 18.150075,17.422142 18.876091,15.009237 19.02321,14.519751 19.493636,14.238227 19.972812,14.254677 z M13.401185,5.4489946 C15.524129,5.4489946 17.458077,6.2259464 18.917039,7.498868 L20.508998,6.5319276 20.700993,11.907595 15.322134,9.683733 16.934092,8.7037935 C15.943118,8.0068364 14.72215,7.5958619 13.401185,7.5958619 10.667256,7.5958619 8.3583171,9.3587532 7.6333362,11.771604 7.418342,12.48356 6.5213656,12.757543 5.9073818,12.311571 5.5433913,12.048587 5.3743958,11.595615 5.5003926,11.173641 6.4953663,7.8668451 9.654283,5.4489946 13.401185,5.4489946 z M1,0 L26,0 C26.552,0 27,0.44699955 27,1 L27,18.578 25,18.578 25,2 2,2 2,25 18.5,25 18.5,27 1,27 C0.44799995,27 0,26.552999 0,26 L0,1 C0,0.44699955 0.44799995,0 1,0 z"),
                Margin = new Thickness(0, 0, 5, 5.003),
                Stretch = Stretch.Fill,
                Fill = (Brush)converter.ConvertFromString("#FF4E8024")
            };
            Path stop2 = new Path
            {
                Data = Geometry.Parse("M2.4188124,3.1309509 L2.371632,3.1867619 C1.5150759,4.2248473 0.99999991,5.5548768 0.99999985,7.0030079 0.99999991,10.313006 3.6910094,13.006 6.9999999,13.006 8.4476832,13.006 9.7770814,12.490543 10.814598,11.633476 L10.869884,11.586686 z M6.9999999,1.0000003 C5.5523166,1.0000002 4.2229184,1.5154561 3.1854021,2.3725255 L3.1252748,2.4234126 11.577093,10.879895 11.628367,10.819242 C12.484924,9.7811575 13,8.4511318 13,7.0030079 13,3.6929941 10.30899,1.0000002 6.9999999,1.0000003 z M6.9999999,0 C10.859985,0 14,3.141999 14,7.0030079 14,10.864001 10.859985,14.006001 6.9999999,14.006001 3.1400146,14.006001 -9.2987342E-08,10.864001 0,7.0030079 -9.2987342E-08,3.141999 3.1400146,0 6.9999999,0 z"),
                Height = 14.006,
                Width = 14,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom,
                Stretch = Stretch.Fill,
                Fill = Brushes.Red
            };

            Path activaeAnimation = new Path
            {
                Data = Geometry.Parse("M0,0 L23,0 23,23 0,23"),
                Margin = new Thickness(1.5),
                Stretch = Stretch.Fill,
                Fill = (Brush)converter.ConvertFromString("#FF99CFFF")
            };
            Path activaeAnimation1 = new Path
            {
                Data = Geometry.Parse("M11,9.7839994 L15.063001,13.413 11,17.042 z M4,1.9999999 L4,4 1.9999999,4 1.9999999,22 4,22 4,24 22,24 22,22 24,22 24,4 22,4 22,1.9999999 z M0,0 L4,0 4,0.99999994 22,0.99999994 22,0 26,0 26,4 25,4 25,22 26,22 26,26 22,26 22,25 4,25 4,26 0,26 0,22 0.99999994,22 0.99999994,4 0,4 z"),
                Stretch = Stretch.Fill,
                Fill = (Brush)converter.ConvertFromString("#FF4E82B8")
            };

            Path deactivaeAnimation = new Path
            {
                Data = Geometry.Parse("F1M38,41.9678L38,26.9998L18,26.9998L18,46.9998L33.665,46.9998C34.172,44.6838,35.824,42.8008,38,41.9678"),
                Margin = new Thickness(2, 2, 10, 9),
                Stretch = Stretch.Fill,
                Fill = (Brush)converter.ConvertFromString("#FF99CFFF")
            };
            Path deactivaeAnimation1 = new Path
            {
                Data = Geometry.Parse("M10.804001,7.7839999 L14.867002,11.412998 10.804001,15.042 z M0,0 L4,0 4,1 20,1 20,0 24,0 24,4 23,4 23,16.664999 C22.656,16.74 22.323,16.844 22,16.968 L22,4 20,4 20,2 4,2 4,4 2,4 2,20 4,20 4,22 17.665,22 C17.594,22.325 17.55,22.659 17.525,23 L4,23 4,24 0,24 0,20 1,20 1,4 0,4 z"),
                Stretch = Stretch.Fill,
                Margin = new Thickness(0, 0, 8, 7),
                Fill = (Brush)converter.ConvertFromString("#FF4E82B8")
            };
            Path deactivaeAnimation2 = new Path
            {
                Data = Geometry.Parse("M2.6612649,3.1649551 L2.587013,3.2486124 C1.5987198,4.3891554 1,5.8760004 0.99999994,7.5 1,11.084 3.9160004,14 7.5,14 9.0120001,14 10.40511,13.481014 11.510541,12.611835 L11.616314,12.526606 z M7.5,0.99999994 C5.9879999,1 4.5948896,1.5189854 3.4894593,2.3881657 L3.3842442,2.472945 12.33876,11.835016 12.412987,11.751388 C13.40128,10.610845 14,9.1239996 14,7.5 14,3.9160004 11.084,1 7.5,0.99999994 z M7.5,0 C11.636002,0 15,3.3639984 15,7.5 15,11.636002 11.636002,15 7.5,15 3.3639984,15 0,11.636002 0,7.5 0,3.3639984 3.3639984,0 7.5,0 z"),
                Stretch = Stretch.Fill,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom,
                Height = 15,
                Width = 15,
                Fill = Brushes.Red
            };
            activateAnimationPathCollection.Add(activaeAnimation);
            activateAnimationPathCollection.Add(activaeAnimation1);
            deactivateAnimationPathCollection.Add(deactivaeAnimation);
            deactivateAnimationPathCollection.Add(deactivaeAnimation1);
            deactivateAnimationPathCollection.Add(deactivaeAnimation2);
            liveUpdatesPathCollection.Add(live);
            stopUpdatesPathCollection.Add(stop1);
            stopUpdatesPathCollection.Add(stop2);
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Handles the DoWork event of the worker control. Does the long work.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
            {
                ShowWindow();
                this.moduleManager.LoadModule("AccountsModule");
                this.moduleManager.LoadModule("StockListModule");
                this.moduleManager.LoadModule("HistoryChartModule");
                activateView();
            }));

        }

        /// <summary>
        /// Handles the RunWorkerCompleted event of the worker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            win.Close();
        }

        /// <summary>
        /// Handles the view selected event 
        /// </summary>
        /// <param name="ViewName">Name of the view.</param>
        void SelectedViewEventHandler(string ViewName)
        {
            if (ViewName == "Dashboard")
            {
                if(!worker.IsBusy)
                worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Activates the view.
        /// </summary>
        private void activateView()
        {
            IRegion ribbonRegion = regionManager.Regions[RegionNames.RibbonRegion];
            object cview = ribbonRegion.GetView("contributionAnalyzerView");
            ribbonRegion.Deactivate(cview);
            object dview = ribbonRegion.GetView("dashboardView");
            ribbonRegion.Activate(dview);
            IRegion dockingRegion = regionManager.Regions[RegionNames.DockingRegion];
            object accountsview1 = dockingRegion.GetView("accountsView");
            if(accountsview1!=null)
            dockingRegion.Deactivate(accountsview1);
            object gridview = dockingRegion.GetView("portfoliogridView");
            if(gridview!=null)
            dockingRegion.Deactivate(gridview);
            object chartview1 = dockingRegion.GetView("countrysectorchartView");
            if(chartview1!=null)
            dockingRegion.Deactivate(chartview1);
            object accountsview = dockingRegion.GetView("accountsView");
            dockingRegion.Activate(accountsview);
            object stockview = dockingRegion.GetView("stocklistView");
            dockingRegion.Activate(stockview);
            object chartview = dockingRegion.GetView("historychartView");
            dockingRegion.Activate(chartview);
        }

        /// <summary>
        ///  Publishes the animation activation/deactivation event
        /// </summary>
        /// <param name="o"></param>
        void ActivateAnimationHandler(object o)
        {
            if (this.AnimationLabel.Equals("Activate Animation"))
            {
                this.AnimationLabel = "Deactivate Animation";
                this.AnimationVectorImage = deactivateAnimationPathCollection;
                this.eventAggregator.GetEvent<DashboardAnimationEvents>().Publish(true);
            }
            else
            {
                this.AnimationLabel = "Activate Animation";
                this.AnimationVectorImage = activateAnimationPathCollection;
                this.eventAggregator.GetEvent<DashboardAnimationEvents>().Publish(false);
            }
        }

        /// <summary>
        /// Publishes real time updates.
        /// </summary>
        /// <param name="o">The o.</param>
        void StartStopRealTimeUpdates(object o)
        {
            if (this.LiveButtonDetails.Equals("Live Updates"))
            {
                this.LiveButtonDetails = "Stop Updates";
                this.LiveVectorImage = stopUpdatesPathCollection;
                this.eventAggregator.GetEvent<StartStopUpdateEvent>().Publish(true);
            }
            else
            {
                this.LiveButtonDetails = "Live Updates";
                this.LiveVectorImage = liveUpdatesPathCollection;
                this.eventAggregator.GetEvent<StartStopUpdateEvent>().Publish(false);
            }
        }
      
        #endregion

        #region DelegateCommands and Properties

        /// <summary>
        /// Gets or sets the selected view.
        /// </summary>
        /// <value>The select blue skin.</value>
        public DelegateCommand<object> SelectView { get; set; }

        /// <summary>
        /// Gets or sets the real time updates.
        /// </summary>
        /// <value>The real time updates.</value>
        public DelegateCommand<object> RealTimeUpdates { get; set; }

        /// <summary>
        /// Gets or sets the type of the cubic animation.
        /// </summary>
        /// <value>The type of the cubic animation.</value>
        public DelegateCommand<object> CubicAnimationType { get; set; }

        /// <summary>
        /// Gets or sets the type of the bounce animation.
        /// </summary>
        /// <value>The type of the bounce animation.</value>
        public DelegateCommand<object> BounceAnimationType { get; set; }

        /// <summary>
        /// Gets or sets the type of the elastic animation.
        /// </summary>
        /// <value>The type of the elastic animation.</value>
        public DelegateCommand<object> ElasticAnimationType { get; set; }

        /// <summary>
        /// Gets or sets the type of the back animation.
        /// </summary>
        /// <value>The type of the back animation.</value>
        public DelegateCommand<object> BackAnimationType { get; set; }

        /// <summary>
        /// Gets or sets the type of the quintic animation.
        /// </summary>
        /// <value>The type of the quintic animation.</value>
        public DelegateCommand<object> QuinticAnimationType { get; set; }

        /// <summary>
        /// Gets or sets the activate animation.
        /// </summary>
        /// <value>The activate animation.</value>
        public DelegateCommand<object> ActivateAnimation { get; set; }

        /// <summary>B
        /// Gets or sets the live button details.
        /// </summary>
        /// <value>The live button details.</value>
        public string LiveButtonDetails
        {
            get
            {
                return this.liveButtonDetails;
            }
            set
            {
                this.liveButtonDetails = value;

                this.OnPropertyChanged("LiveButtonDetails");
            }
        }

        /// <summary>
        /// Gets or sets the animation label.
        /// </summary>
        /// <value>The animation label.</value>
        public string AnimationLabel
        {
            get
            {
                return animationlabel;
            }
            set
            {
                animationlabel = value;

                OnPropertyChanged("AnimationLabel");
            }
        }        

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }


}
