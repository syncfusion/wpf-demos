using System;
using Syncfusion.Windows.Shared;

namespace ExcelExport.ViewModel
{
    public class MainViewModel
    {
        private IMainView mainView;

        public MainViewModel(IMainView mainView)
        {
            this.mainView = mainView;
            Initialize();
        }

        private void Initialize()
        {
            if (MainView != null)
            {
                MainView.Initialize();
                MainView.FillData();
            }
        }

        public IMainView MainView
        {
            get
            {
                return mainView;
            }
        }

        #region Commands
        
        public DelegateCommand<Object> exportFullRange;
        public DelegateCommand<Object> ExportFullRange
        {
            get
            {
                if (exportFullRange == null)
                    exportFullRange = new DelegateCommand<object>(OnExecuteExportFullRange);
                return exportFullRange;
            }
        }

        private void OnExecuteExportFullRange(object param)
        {
            if (MainView != null)
                MainView.ExportFullRange();
        }

        public DelegateCommand<Object> exportSelectedRange;
        public DelegateCommand<Object> ExportSelectedRange
        {
            get
            {
                if (exportSelectedRange == null)
                    exportSelectedRange = new DelegateCommand<object>(OnExecuteExportSelectedRange);
                return exportSelectedRange;
            }
        }

        private void OnExecuteExportSelectedRange(object param)
        {
            if (MainView != null)
                MainView.ExportSelectedRange();
        }

        public DelegateCommand<Object> exportWithChart;
        public DelegateCommand<Object> ExportWithChart
        {
            get
            {
                if (exportWithChart == null)
                    exportWithChart = new DelegateCommand<object>(OnExecuteExportWithChart);
                return exportWithChart;
            }
        }

        private void OnExecuteExportWithChart(object param)
        {
            if (MainView != null)
                MainView.ExportWithChart();
        }

        public DelegateCommand<Object> exportUsingEngine;
        public DelegateCommand<Object> ExportUsingEngine
        {
            get
            {
                if (exportUsingEngine == null)
                    exportUsingEngine = new DelegateCommand<object>(OnExecuteExportUsingEngine);
                return exportUsingEngine;
            }
        }

        private void OnExecuteExportUsingEngine(object param)
        {
            if (MainView != null)
                MainView.ExportUsingEngine();
        }

        #endregion
    }
}
