namespace syncfusion.weatheranalysis.wpf
{
    public static class WindowHelper
    {
        private static WeatherAnalysisDemo mainWindow;

        public static WeatherAnalysisDemo MainWindow
        {
            get { return mainWindow; }
            set { mainWindow = value; }
        }
    }
}
