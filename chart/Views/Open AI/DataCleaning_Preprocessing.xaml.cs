#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Demonstrates AI assisted data cleaning and preprocessing in a chart.</summary>
    public partial class DataCleaning_Preprocessing : DemoControl
    {
        private readonly PreprocessingAzureAIService aiService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataCleaning_Preprocessing"/> class.
        /// </summary>
        public DataCleaning_Preprocessing()
        {
            InitializeComponent();
            aiService = new PreprocessingAzureAIService();
            aiService.IsCredentialsValid();
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            Chart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            viewModel.IsBusy = true;
            Task.Run(async () =>
            {
                Task.Delay(1000).Wait();
                await viewModel.LoadCleanedDataAsync(aiService);
            });
        }
    }
}