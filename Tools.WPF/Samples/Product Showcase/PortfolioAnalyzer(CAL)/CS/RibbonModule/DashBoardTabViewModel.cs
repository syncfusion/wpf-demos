using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

            //Skin Events
            this.SelectBlueSkin = new DelegateCommand<object>(o => eventAggregator.GetEvent<SkinChangedEvent>().Publish("Blue"));
            this.SelectBlackSkin = new DelegateCommand<object>(o => eventAggregator.GetEvent<SkinChangedEvent>().Publish("Black"));
            this.SelectSilverSkin = new DelegateCommand<object>(o => eventAggregator.GetEvent<SkinChangedEvent>().Publish("Silver"));
            this.SelectBlendSkin = new DelegateCommand<object>(o => eventAggregator.GetEvent<SkinChangedEvent>().Publish("Blend"));

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
            border.Child = label;
            win.Background = brush;
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.WindowStyle = WindowStyle.None;
            win.Height = 75;
            win.Width = 309;
            win.ShowInTaskbar = false;
            win.Content = border;
            win.Show();
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
                this.eventAggregator.GetEvent<DashboardAnimationEvents>().Publish(true);
            }
            else
            {
                this.AnimationLabel = "Activate Animation";
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
                this.eventAggregator.GetEvent<StartStopUpdateEvent>().Publish(true);
            }
            else
            {
                this.LiveButtonDetails = "Live Updates";
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

        /// <summary>
        /// Gets or sets the select blue skin.
        /// </summary>
        /// <value>The select blue skin.</value>
        public DelegateCommand<object> SelectBlueSkin { get; set; }

        /// <summary>
        /// Gets or sets the select black skin.
        /// </summary>
        /// <value>The select black skin.</value>
        public DelegateCommand<object> SelectBlackSkin { get; set; }

        /// <summary>
        /// Gets or sets the select silver skin.
        /// </summary>
        /// <value>The select silver skin.</value>
        public DelegateCommand<object> SelectSilverSkin { get; set; }

        /// <summary>
        /// Gets or sets the select blend skin.
        /// </summary>
        /// <value>The select blend skin.</value>
        public DelegateCommand<object> SelectBlendSkin { get; set; }

        /// <summary>
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
