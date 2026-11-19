using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Automation.Peers;

namespace syncfusion.weatheranalysis.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class WeatherAnalysisDemo : ChromelessWindow
    {
        public WeatherAnalysisDemo()
        {
            WindowHelper.MainWindow = this;
            DataStore.Initialize();
            
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DataStore.ReleaseData();
            Dispose();
            base.OnClosing(e);
        }

        public void Dispose()
        {
            weatherView.Dispose();
            hourlyView.Dispose();
            mapsView.Dispose();

            if (Weather_TabControl != null)
            {
                Weather_TabControl.Dispose();
                Weather_TabControl = null;
            }

            if(this.DataContext is LocationViewModel locationViewModel)
            {
                locationViewModel.Dispose();
            }

            ViewModelLocator locator = (ViewModelLocator)this.TryFindResource("ViewModelLocator");
            locator.DayWeatherInfoViewModel = null;
            locator.HistoricalWeatherViewModel = null;
            locator.DailyForecastViewModel = null;
            locator.HourlyForecastViewModel = null;
            locator.LocationViewModel = null;
            locator.TodayWeatherTileViewModel = null;
            locator.MapsViewModel = null;

            WindowHelper.MainWindow = null;
            GC.Collect();
            GC.SuppressFinalize(this);
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new FakeWindowsPeer(this);
        }
    }

    public class FakeWindowsPeer : WindowAutomationPeer
    {
        public FakeWindowsPeer(Window window)
            : base(window)
        {
        }

        protected override List<AutomationPeer> GetChildrenCore()
        {
            return null;
        }
    }
}
