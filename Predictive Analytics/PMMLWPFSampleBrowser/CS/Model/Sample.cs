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
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace PMMLWPFSampleBrowser
{
    /// <summary>
    /// Hold the sample information
    /// </summary>
    public class Sample : NotificationObject
    {
        Syncfusion.PMML.Table outputTable = null;
        Syncfusion.PMML.Table inputTable = null;
        Syncfusion.PMML.Table currentPageTable = null;

        string samplePath = string.Empty;
        string pmmlPath = string.Empty;
        string rScriptPath = string.Empty;
      
        /// <summary>
        /// get and set the View model
        /// </summary>
        internal ViewModel viewModel { get; set; }



        /// <summary>
        /// get and set the sample file path
        /// </summary>
        public string SamplePath { get; set; }

        /// <summary>
        /// get and set the model name
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// get and set the tag name
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// get and set the sample name
        /// </summary>
        private string m_name;

        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// get and set the sample is Isselected
        /// </summary>
        private bool m_isSelected;

        public bool IsSelected
        {
            get
            {
                return m_isSelected;
            }
            set
            {
                m_isSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }

        /// <summary>
        /// Load the sample
        /// </summary>
        /// <param name="sample">Selected sample</param>
        public void LoadSample()
        {
            string
                outputPath = string.Empty,
                inputPath = string.Empty,

                sourcePath = string.Empty;

#if NETCORE
            var path = "..\\..\\..\\..\\..\\..\\Common\\Analytics";
#else
            var path = "..\\..\\..\\..\\..\\Common\\Analytics";
#endif
            samplePath = string.Format("{0}{1}\\", path, this.SamplePath);
            sourcePath = samplePath + "Program.cs";
            if (File.Exists(sourcePath))
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    viewModel.Source = new SyntaxRichTextBoxCS().FormatCode(File.ReadAllText(sourcePath));
                    viewModel.CSharpDocument.Blocks.Clear();
                    viewModel.CSharpDocument.Blocks.Add(viewModel.Source);
                }));
            }
            samplePath += "Model\\";
            outputPath = samplePath + "ROutput.csv";
            pmmlPath = string.Format("{0}{1}.pmml", samplePath, this.Name);
            rScriptPath = string.Format("{0}{1}.R", samplePath, this.Name);
            
            switch (this.ModelName)
            {
                case "General Regression":
                    LoadGeneralRegressionSample(samplePath, inputPath, outputPath);
                    break;

                case "Naive Bayes":
                    LoadNaiveBayesSample(samplePath, inputPath, outputPath);
                    break;

                case "Random Forest":
                    LoadRandomForestSample(samplePath, inputPath, outputPath);
                    break;

                case "Regression":
                    LoadRegressionSample(samplePath, inputPath, outputPath);
                    break;

                case "Support Vector Machine":
                    LoadSupportVectorMachineSample(samplePath, inputPath, outputPath);
                    break;

                case "Tree Model":
                    LoadTreeModelSample(samplePath, inputPath, outputPath);
                    break;

                case "Clustering Model":
                    LoadClusteringSample(samplePath, inputPath, outputPath);
                    break;

                case "Neural Networks":
                    LoadNeuralNetworksSample(samplePath, inputPath, outputPath);
                    break;

                case "Multinomial Regression":
                    LoadMultinomialSample(samplePath, inputPath, outputPath);
                    break;

                case "Cox Regression":
                    LoadCoxRegressionSample(samplePath, inputPath, outputPath);
                    break;

                case "Gradient Boosting":
                    LoadGradientBoostingSample(samplePath, inputPath, outputPath);
                    break;

                case "Association Rules":
                    LoadAssociationRuleSample(samplePath, inputPath, outputPath);
                    break;
            }

            if (File.Exists(rScriptPath))
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    viewModel.RScript = new SyntaxHighlighterR().FormatCode(File.ReadAllText(rScriptPath));
                    viewModel.RDocument.Blocks.Clear();
                    viewModel.RDocument.Blocks.Add(viewModel.RScript);
                }));
            }

            if (File.Exists(pmmlPath))
            {
                var reader = new StreamReader(pmmlPath);
                string text = reader.ReadToEnd();
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    viewModel.Pmml = SyntaxHighlighterXAML.FormatCode(text);
                    viewModel.PMMLDocument.Blocks.Clear();
                    viewModel.PMMLDocument.Blocks.Add(viewModel.Pmml);
                }));
            }

            if (currentPageTable != null && outputTable != null)
            {
                viewModel.InputColumnCount = inputTable.ColumnCount;

                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {

                    if (inputTable.RowCount % viewModel.PageSize > 0)
                        viewModel.PageCount += 1;

                    viewModel.IsLoading = true;
                    viewModel.SFDataPager.PageCount = viewModel.PageCount;
                    viewModel.SFDataPager.MoveToFirstPage();
                    viewModel.IsLoading = false;
                  
                    
                    var result = this.MergeTableDictionary(currentPageTable, outputTable);

                    this.AddColumnToGrid(result);
        
                    viewModel.SFDataPager.LoadDynamicItems(0, result);

                    

                    if (viewModel.SFDataGrid.View != null)
                    {
                        viewModel.SFDataGrid.View.Refresh();

                        viewModel.SFDataGrid.GridColumnSizer.ResetAutoCalculationforAllColumns();

                        viewModel.SFDataGrid.GridColumnSizer.Refresh();
                    }

                }));
            }
        }

        public void UpdateSample(int start)
        {
            var index = (start + viewModel.PageSize) >= inputTable.RowCount ? inputTable.RowCount : start + viewModel.PageSize;
            currentPageTable = this.Take(inputTable, start, index);

            switch (ModelName)
            {
                case "General Regression":
                    this.UpdateGeneralRegressionModel(start, index);
                    break;
                case "Naive Bayes":
                    UpdateNaiveBayesModel(start, index);
                    break;

                case "Random Forest":
                    UpdateRandomForestModel(start, index);
                    break;

                case "Regression":
                    UpdateRegressionModel(start, index);
                    break;

                case "Support Vector Machine":
                    UploadSupportVectorMachineModel(start, index);
                    break;

                case "Tree Model":
                    UploadTreeModel(start, index);
                    break;

                case "Clustering Model":
                    UpdateClusteringModel(start, index);
                    break;

                case "Neural Networks":
                    UploadNeuralNetworksModel(start, index);
                    break;

                case "Multinomial Regression":
                    UpdateMultinomialModel(start, index);
                    break;

                case "Cox Regression":
                    UpdateCoxRegressionModel(start, index);
                    break;

                case "Gradient Boosting":
                    UpdateGradientBoostingSample(start, index);
                    break;

                case "Association Rules":
                    UpdateAssociationRuleSample(start, index);
                    break;
            }


            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                var result = this.MergeTableDictionary(currentPageTable, outputTable);

                viewModel.SFDataPager.LoadDynamicItems(start, result);

                if (viewModel.SFDataGrid.View != null)
                {
                    viewModel.SFDataGrid.View.Refresh();

                    viewModel.SFDataGrid.GridColumnSizer.ResetAutoCalculationforAllColumns();

                    viewModel.SFDataGrid.GridColumnSizer.Refresh();
                }

            }));
        }

        public void UpdateGeneralRegressionModel(int start,int index)
        {
            switch (this.Name)
            {   
                case "WineLog":
                    WineLog.Program wineLogProgram = new WineLog.Program();                   
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    outputTable = wineLogProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineIdentity":
                    WineIdentity.Program wineIdentityProgram = new WineIdentity.Program();                                
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    outputTable = wineIdentityProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicLogit":
                    TitanicLogit.Program titanicLogitProgram = new TitanicLogit.Program();                   
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    outputTable = titanicLogitProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "TitanicCloglog":
                    TitanicCloglog.Program titanicCloglogProgram = new TitanicCloglog.Program();                 
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    outputTable = titanicCloglogProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "GlassCloglog":
                    GlassCloglog.Program glassCloglogProgram = new GlassCloglog.Program();              
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    outputTable = glassCloglogProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "GlassLogit":
                    GlassLogit.Program glassLogitProgram = new GlassLogit.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    outputTable = glassLogitProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "OzoneLog":
                    OzoneLog.Program ozoneLogProgram = new OzoneLog.Program();                  
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    outputTable = ozoneLogProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneIdentity":
                    OzoneIdentity.Program ozoneIdentityProgram = new OzoneIdentity.Program();                         
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    outputTable = ozoneIdentityProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsIdentity":
                    TipsIdentity.Program tipsIdentityProgram = new TipsIdentity.Program();                   
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    outputTable = tipsIdentityProgram.PredictResult(currentPageTable, pmmlPath);             
                    break;

                case "ImportsIdentity":
                    ImportsIdentity.Program importsIdentityProgram = new ImportsIdentity.Program();                    
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    outputTable = importsIdentityProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "CarsIdentity":
                    CarsIdentity.Program carsIdentityProgram = new CarsIdentity.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    outputTable = carsIdentityProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerLogitRegression":
                    BreastCancerLogitRegression.Program bcLogitRegressionProgram = new BreastCancerLogitRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = bcLogitRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerCloglogRegression":
                    BreastCancerCloglogRegression.Program bcCloglogRegressionProgram = new BreastCancerCloglogRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = bcCloglogRegressionProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerCloglogClassification":
                    BreastCancerCloglogClassification.Program bcCloglogClassificationProgram = new BreastCancerCloglogClassification.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = bcCloglogClassificationProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerLogitClassification":
                    BreastCancerLogitClassification.Program bcLogitClassificationProgram = new BreastCancerLogitClassification.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = bcLogitClassificationProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "AuditLogitRegression":
                    AuditLogitRegression.Program auditLogitRegressionProgram = new AuditLogitRegression.Program();                    
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    outputTable = auditLogitRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "AuditLogitClassification":
                    AuditLogitClassification.Program auditLogitClassificationProgram = new AuditLogitClassification.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    outputTable = auditLogitClassificationProgram.PredictResult(currentPageTable, pmmlPath);                 
                    break;

                case "IrisLogit":
                    IrisLogit.Program irisLogitProgram = new IrisLogit.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    outputTable = irisLogitProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "IrisCloglog":
                    IrisCloglog.Program irisCloglogProgram = new IrisCloglog.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    outputTable = irisCloglogProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "AuditBinomialProbitClassification":
                    AuditBinomialProbitClassification.Program auditBinomialProbitClassificationProgram = new AuditBinomialProbitClassification.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    outputTable = auditBinomialProbitClassificationProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "AuditQuasibinomialProbitRegression":
                    AuditQuasibinomialProbitRegression.Program auditQuasibinomialProbitClassificationProgram = new AuditQuasibinomialProbitRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    outputTable = auditQuasibinomialProbitClassificationProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerBinomialProbitClassification":
                    BreastCancerBinomialProbitClassification.Program breastCancerBinomialProbitClassificationProgram = new BreastCancerBinomialProbitClassification.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = breastCancerBinomialProbitClassificationProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerGaussianInverseRegression":
                    BreastCancerGaussianInverseRegression.Program breastCancerGaussianInverseRegressionProgram = new BreastCancerGaussianInverseRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = breastCancerGaussianInverseRegressionProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerQuasiInverseRegression":
                    BreastCancerQuasiInverseRegression.Program breastCancerQuasiInverseRegressionProgram = new BreastCancerQuasiInverseRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = breastCancerQuasiInverseRegressionProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerQuasibinomialProbitRegression":
                    BreastCancerQuasibinomialProbitRegression.Program breastCancerQuasibinomialProbitClassificationProgram = new BreastCancerQuasibinomialProbitRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = breastCancerQuasibinomialProbitClassificationProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerQuasipoissonInverseRegression":
                    BreastCancerQuasipoissonInverseRegression.Program breastCancerQuasipoissonInverseRegressionProgram = new BreastCancerQuasipoissonInverseRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = breastCancerQuasipoissonInverseRegressionProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerQuasipoissonProbitRegression":
                    BreastCancerQuasipoissonProbitRegression.Program breastCancerQuasipoissonProbitRegressionProgram = new BreastCancerQuasipoissonProbitRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = breastCancerQuasipoissonProbitRegressionProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "CarsGammaInverse":
                    CarsGammaInverse.Program carsGammaInverseProgram = new CarsGammaInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    outputTable = carsGammaInverseProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "CarsInverseGaussian":
                    CarsInverseGaussian.Program carsInverseGaussianProgram = new CarsInverseGaussian.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    outputTable = carsInverseGaussianProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "CarsQuasiInverse":
                    CarsQuasiInverse.Program carsQuasiInverseProgram = new CarsQuasiInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    outputTable = carsQuasiInverseProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "CarsQuasiSqrt":
                    CarsQuasiSqrt.Program carsQuasiSqrtProgram = new CarsQuasiSqrt.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    outputTable = carsQuasiSqrtProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "GlassBinomialProbit":
                    GlassBinomialProbit.Program glassBinomialProbitProgram = new GlassBinomialProbit.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    outputTable = glassBinomialProbitProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "GlassQuasibinomialProbit":
                    GlassQuasibinomialProbit.Program glassQuasibinomialProbitProgram = new GlassQuasibinomialProbit.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    outputTable = glassQuasibinomialProbitProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "ImportsGammaInverse":
                    ImportsGammaInverse.Program importsGammaInverseProgram = new ImportsGammaInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    outputTable = importsGammaInverseProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "ImportsGaussianInverse":
                    ImportsGaussianInverse.Program importsGaussianInverseProgram = new ImportsGaussianInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    outputTable = importsGaussianInverseProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "ImportsInverseGaussian":
                    ImportsInverseGaussian.Program importsInverseGaussianProgram = new ImportsInverseGaussian.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    outputTable = importsInverseGaussianProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsNegativeBinomialSqrt":
                    ImportsNegativeBinomialSqrt.Program importsNegativeBinomialSqrtProgram = new ImportsNegativeBinomialSqrt.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    outputTable = importsNegativeBinomialSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsPoissonSqrt":
                    ImportsPoissonSqrt.Program importsPoissonSqrtProgram = new ImportsPoissonSqrt.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    outputTable = importsPoissonSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsQuasiInverse":
                    ImportsQuasiInverse.Program importsQuasiInverseProgram = new ImportsQuasiInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    outputTable = importsQuasiInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsQuasiSqrt":
                    ImportsQuasiSqrt.Program importsQuasiSqrtProgram = new ImportsQuasiSqrt.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    outputTable = importsQuasiSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "IrisBinomialProbit":
                    IrisBinomialProbit.Program irisBinomialProbitProgram = new IrisBinomialProbit.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    outputTable = irisBinomialProbitProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "IrisQuasibinomialProbit":
                    IrisQuasibinomialProbit.Program irisQuasibinomialProbitProgram = new IrisQuasibinomialProbit.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    outputTable = irisQuasibinomialProbitProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneGammaInverse":
                    OzoneGammaInverse.Program ozoneGammaInverseProgram = new OzoneGammaInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    outputTable = ozoneGammaInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneGaussianInverse":
                    OzoneGaussianInverse.Program ozoneGaussianInverseProgram = new OzoneGaussianInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    outputTable = ozoneGaussianInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzonePoissonSqrt":
                    OzonePoissonSqrt.Program ozonePoissonSqrtProgram = new OzonePoissonSqrt.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    outputTable = ozonePoissonSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneQuasiInverse":
                    OzoneQuasiInverse.Program ozoneQuasiInverseProgram = new OzoneQuasiInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    outputTable = ozoneQuasiInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneQuasiSqrt":
                    OzoneQuasiSqrt.Program ozoneQuasiSqrtProgram = new OzoneQuasiSqrt.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    outputTable = ozoneQuasiSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneQuasipoissonSqrt":
                    OzoneQuasipoissonSqrt.Program ozoneQuasipoissonSqrtProgram = new OzoneQuasipoissonSqrt.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    outputTable = ozoneQuasipoissonSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsGammaInverse":
                    TipsGammaInverse.Program tipsGammaInverseProgram = new TipsGammaInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    outputTable = tipsGammaInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsGaussianInverse":
                    TipsGaussianInverse.Program tipsGaussianInverseProgram = new TipsGaussianInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    outputTable = tipsGaussianInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsInverseGaussian":
                    TipsInverseGaussian.Program tipsInverseGaussianProgram = new TipsInverseGaussian.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    outputTable = tipsInverseGaussianProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsQuasiInverse":
                    TipsQuasiInverse.Program tipsQuasiInverseProgram = new TipsQuasiInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    outputTable = tipsQuasiInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsQuasiSqrt":
                    TipsQuasiSqrt.Program tipsQuasiSqrtProgram = new TipsQuasiSqrt.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    outputTable = tipsQuasiSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsQuasipoissonProbit":
                    TipsQuasipoissonProbit.Program tipsQuasipoissonProbitProbit = new TipsQuasipoissonProbit.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    outputTable = tipsQuasipoissonProbitProbit.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicBinomialProbit":
                    TitanicBinomialProbit.Program titanicBinomialProbitProgram = new TitanicBinomialProbit.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    outputTable = titanicBinomialProbitProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicQuasibinomialProbit":
                    TitanicQuasibinomialProbit.Program titanicQuasibinomialProbitProgram = new TitanicQuasibinomialProbit.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    outputTable = titanicQuasibinomialProbitProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineGammaInverse":
                    WineGammaInverse.Program wineGammaInverseProgram = new WineGammaInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    outputTable = wineGammaInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineInverseGaussian":
                    WineInverseGaussian.Program wineInverseGaussianProgram = new WineInverseGaussian.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    outputTable = wineInverseGaussianProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WinePoissonSqrt":
                    WinePoissonSqrt.Program winePoissonSqrtProgram = new WinePoissonSqrt.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    outputTable = winePoissonSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineQuasiInverse":
                    WineQuasiInverse.Program wineQuasiInverseProgram = new WineQuasiInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    outputTable = wineQuasiInverseProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "WineQuasiSqrt":
                    WineQuasiSqrt.Program wineQuasiSqrtProgram = new WineQuasiSqrt.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    outputTable = wineQuasiSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineQuasipoissonInverse":
                    WineQuasipoissonInverse.Program wineQuasipoissonInverseProgram = new WineQuasipoissonInverse.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    outputTable = wineQuasipoissonInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineQuasipoissonSqrt":
                    WineQuasipoissonSqrt.Program wineQuasipoissonSqrtProgram = new WineQuasipoissonSqrt.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    outputTable = wineQuasipoissonSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }
        
        public void UpdateClusteringModel(int start, int index)
        {
            switch (this.Name)
            {
                case "Audit":
                    AuditKMeans.Program auditKMeansProgram = new AuditKMeans.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = auditKMeansProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "BreastCancer":
                    BreastCancerKMeans.Program breastCancerKMeansKMeansProgram = new BreastCancerKMeans.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = breastCancerKMeansKMeansProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "Glass":
                    GlassKMeans.Program glassKMeansProgram = new GlassKMeans.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = glassKMeansProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "Iris":
                    IrisKMeans.Program irisKMeansProgram = new IrisKMeans.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = irisKMeansProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "Titanic":
                    TitanicKMeans.Program titanicKMeansProgram = new TitanicKMeans.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = titanicKMeansProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "Wine":
                    WineKMeans.Program wineKMeansProgram = new WineKMeans.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = wineKMeansProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }
        
        public void UpdateCoxRegressionModel(int start,int index)
        {
            switch (this.Name)
            {
                case "Aml":
                    AmlCoxRegression.Program amlCoxRegressionProgram = new AmlCoxRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = amlCoxRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Bfeed":
                    BfeedCoxRegression.Program bfeedCoxRegressionProgram = new BfeedCoxRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = bfeedCoxRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Larynx":
                    LarynxCoxRegression.Program larynxCoxRegressionProgram = new LarynxCoxRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = larynxCoxRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Lung":
                    LungCoxRegression.Program lungCoxRegressionProgram = new LungCoxRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = lungCoxRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "Ovarian":
                    OvarianCoxRegression.Program ovarianCoxRegressionProgram = new OvarianCoxRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = ovarianCoxRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "Rats":
                    RatsCoxRegression.Program ratsCoxRegressionProgram = new RatsCoxRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = ratsCoxRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }
        
        public void UpdateMultinomialModel(int start, int index)
        {
            switch (this.Name)
            {
                case "Audit":
                    AuditMultinomial.Program auditProgram = new AuditMultinomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = auditProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancer":
                    BreastCancerMultinomial.Program breastCancerProgram = new BreastCancerMultinomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = breastCancerProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Glass":
                    GlassMultinomial.Program glassProgram = new GlassMultinomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = glassProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Iris":
                    IrisMultinomial.Program irisProgram = new IrisMultinomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = irisProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Titanic":
                    TitanicMultinomial.Program titanicProgram = new TitanicMultinomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = titanicProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Wine":
                    WineMultinomial.Program wineProgram = new WineMultinomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = wineProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }
        
        public void UpdateNaiveBayesModel(int start, int index)
        {
            switch (this.Name)
            {
                case "Audit":
                    Audit.Program auditProgram = new Audit.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = auditProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancer":
                    BreastCancer.Program breastCancerProgram = new BreastCancer.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = breastCancerProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Imports":
                    Imports.Program importsProgram = new Imports.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = importsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Iris":
                    Iris.Program irisProgram = new Iris.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = irisProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Titanic":
                    Titanic.Program titanicProgram = new Titanic.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = titanicProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Wine":
                    Wine.Program wineProgram = new Wine.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = wineProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }
        
        public void UpdateRandomForestModel(int start, int index)
        {
            switch (this.Name)
            {
                case "Audit":
                    AuditRandomForest.Program auditProgram = new AuditRandomForest.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = auditProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancer":
                    BreastCancerRandomForest.Program breastCancerProgram = new BreastCancerRandomForest.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = breastCancerProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Cars":
                    CarsRandomForest.Program carsProgram = new CarsRandomForest.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = carsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Glass":
                    GlassRandomForest.Program glassProgram = new GlassRandomForest.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = glassProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Imports":
                    ImportsRandomForest.Program importsProgram = new ImportsRandomForest.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = importsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Iris":
                    IrisRandomForest.Program irisProgram = new IrisRandomForest.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = irisProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Ozone":
                    OzoneRandomForest.Program ozoneProgram = new OzoneRandomForest.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = ozoneProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Tips":
                    TipsRandomForest.Program tipsProgram = new TipsRandomForest.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = tipsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Titanic":
                    TitanicRandomForest.Program titanicProgram = new TitanicRandomForest.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = titanicProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Wine":
                    WineRandomForest.Program wineProgram = new WineRandomForest.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = wineProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }
        
        public void UpdateRegressionModel(int start, int index)
        {
            switch (this.Name)
            {
                case "Cars":
                    CarsRegression.Program carsProgram = new CarsRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = carsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Imports":
                    ImportsRegression.Program importsProgram = new ImportsRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = importsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Ozone":
                    OzoneRegression.Program ozoneProgram = new OzoneRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = ozoneProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Tips":
                    TipsRegression.Program tipsProgram = new TipsRegression.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = tipsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        public void UploadSupportVectorMachineModel(int start, int index)
        {
            switch (this.Name)
            {
                case "AuditLinear":
                    AuditLinear.Program auditLinearProgram = new AuditLinear.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    outputTable = auditLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "AuditPolynomial":
                    AuditPolynomial.Program auditPolynomialProgram = new AuditPolynomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    outputTable = auditPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "AuditRadial":
                    AuditRadial.Program auditRadialProgram = new AuditRadial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    outputTable = auditRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "AuditSigmoid":
                    AuditSigmoid.Program auditSigmoidProgram = new AuditSigmoid.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    outputTable = auditSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerLinear":
                    BreastCancerLinear.Program bcLinearProgram = new BreastCancerLinear.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = bcLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerPolynomial":
                    BreastCancerPolynomial.Program bcPolynomialProgram = new BreastCancerPolynomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = bcPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerRadial":
                    BreastCancerRadial.Program bcRadialProgram = new BreastCancerRadial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = bcRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerSigmoid":
                    BreastCancerSigmoid.Program bcSigmoidProgram = new BreastCancerSigmoid.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    outputTable = bcSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "CarsLinear":
                    CarsLinear.Program carsLinearProgram = new CarsLinear.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    outputTable = carsLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "CarsPolynomial":
                    CarsPolynomial.Program carsPolynomialProgram = new CarsPolynomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    outputTable = carsPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "CarsRadial":
                    CarsRadial.Program carsRadialProgram = new CarsRadial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    outputTable = carsRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "CarsSigmoid":
                    CarsSigmoid.Program carsSigmoidProgram = new CarsSigmoid.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    outputTable = carsSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "GlassLinear":
                    GlassLinear.Program glassLinearProgram = new GlassLinear.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    outputTable = glassLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "GlassPolynomial":
                    GlassPolynomial.Program glassPolynomialProgram = new GlassPolynomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    outputTable = glassPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "GlassRadial":
                    GlassRadial.Program glassRadialProgram = new GlassRadial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    outputTable = glassRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "GlassSigmoid":
                    GlassSigmoid.Program glassSigmoidProgram = new GlassSigmoid.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    outputTable = glassSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsLinear":
                    ImportsLinear.Program importsLinearProgram = new ImportsLinear.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    outputTable = importsLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsPolynomial":
                    ImportsPolynomial.Program importsPolynomialProgram = new ImportsPolynomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    outputTable = importsPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsRadial":
                    ImportsRadial.Program importsRadialProgram = new ImportsRadial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    outputTable = importsRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsSigmoid":
                    ImportsSigmoid.Program importsSigmoidProgram = new ImportsSigmoid.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    outputTable = importsSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "IrisLinear":
                    IrisLinear.Program irisLinearProgram = new IrisLinear.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    outputTable = irisLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "IrisPolynomial":
                    IrisPolynomial.Program irisPolynomialProgram = new IrisPolynomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    outputTable = irisPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "IrisRadial":
                    IrisRadial.Program irisRadialProgram = new IrisRadial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    outputTable = irisRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "IrisSigmoid":
                    IrisSigmoid.Program irisSigmoidProgram = new IrisSigmoid.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    outputTable = irisSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneLinear":
                    OzoneLinear.Program ozoneLinearProgram = new OzoneLinear.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    outputTable = ozoneLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzonePolynomial":
                    OzonePolynomial.Program ozonePolynomialProgram = new OzonePolynomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    outputTable = ozonePolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneRadial":
                    OzoneRadial.Program ozoneRadialProgram = new OzoneRadial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    outputTable = ozoneRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneSigmoid":
                    OzoneSigmoid.Program ozoneSigmoidProgram = new OzoneSigmoid.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    outputTable = ozoneSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsLinear":
                    TipsLinear.Program tipsLinearProgram = new TipsLinear.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    outputTable = tipsLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsPolynomial":
                    TipsPolynomial.Program tipsPolynomialProgram = new TipsPolynomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    outputTable = tipsPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsRadial":
                    TipsRadial.Program tipsRadialProgram = new TipsRadial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    outputTable = tipsRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsSigmoid":
                    TipsSigmoid.Program tipsSigmoidProgram = new TipsSigmoid.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    outputTable = tipsSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicLinear":
                    TitanicLinear.Program titanicLinearProgram = new TitanicLinear.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    outputTable = titanicLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicPolynomial":
                    TitanicPolynomial.Program titanicPolynomialProgram = new TitanicPolynomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    outputTable = titanicPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicRadial":
                    TitanicRadial.Program titanicRadialProgram = new TitanicRadial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    outputTable = titanicRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicSigmoid":
                    TitanicSigmoid.Program titanicSigmoidProgram = new TitanicSigmoid.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    outputTable = titanicSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineLinear":
                    WineLinear.Program wineLinearProgram = new WineLinear.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    outputTable = wineLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WinePolynomial":
                    WinePolynomial.Program winePolynomialProgram = new WinePolynomial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    outputTable = winePolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineRadial":
                    WineRadial.Program wineRadialProgram = new WineRadial.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    outputTable = wineRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineSigmoid":
                    WineSigmoid.Program wineSigmoidProgram = new WineSigmoid.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    outputTable = wineSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        public void UploadTreeModel(int start,int index)
        {
            switch (this.Name)
            {
                case "Audit":
                    AuditTree.Program auditProgram = new AuditTree.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = auditProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancer":
                    BreastCancerTree.Program breastCancerProgram = new BreastCancerTree.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = breastCancerProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Cars":
                    CarsTree.Program carsProgram = new CarsTree.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = carsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Glass":
                    GlassTree.Program glassProgram = new GlassTree.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = glassProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Imports":
                    ImportsTree.Program importsProgram = new ImportsTree.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = importsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Iris":
                    IrisTree.Program irisProgram = new IrisTree.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = irisProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Ozone":
                    OzoneTree.Program ozoneProgram = new OzoneTree.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = ozoneProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Tips":
                    TipsTree.Program tipsProgram = new TipsTree.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = tipsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Titanic":
                    TitanicTree.Program titanicProgram = new TitanicTree.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = titanicProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Wine":
                    WineTree.Program wineProgram = new WineTree.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = wineProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        public void UploadNeuralNetworksModel(int start, int index)
        {
            switch (this.Name)
            {
                case "Audit":
                    AuditNeural.Program auditProgram = new AuditNeural.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = auditProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancer":
                    BreastCancerNeural.Program breastCancerProgram = new BreastCancerNeural.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = breastCancerProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Cars":
                    CarsNeural.Program carsProgram = new CarsNeural.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = carsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Glass":
                    GlassNeural.Program glassProgram = new GlassNeural.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = glassProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Imports":
                    ImportsNeural.Program importsProgram = new ImportsNeural.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = importsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Iris":
                    IrisNeural.Program irisProgram = new IrisNeural.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = irisProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Ozone":
                    OzoneNeural.Program ozoneProgram = new OzoneNeural.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = ozoneProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Tips":
                    TipsNeural.Program tipsProgram = new TipsNeural.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = tipsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Titanic":
                    TitanicNeural.Program titanicProgram = new TitanicNeural.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = titanicProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Wine":
                    WineNeural.Program wineProgram = new WineNeural.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = wineProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        private void UpdateGradientBoostingSample(int start, int index)
        {
            switch (this.Name)
            {
                case "AuditBernoulli":
                    Audit_Bernoulli.Program auditProgram = new Audit_Bernoulli.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = auditProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BfeedCoxph":
                    Bfeed_Coxph.Program bfeedProgram = new Bfeed_Coxph.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = bfeedProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerAdaboost":
                    BreastCancer_Adaboost.Program breastCancerProgram = new BreastCancer_Adaboost.Program();
                     currentPageTable = this.Take(inputTable, start, index);
                     outputTable = breastCancerProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerHuberized":
                    BreastCancer_Huberized.Program breastCancerHeuberizedProgram = new BreastCancer_Huberized.Program();
                     currentPageTable = this.Take(inputTable, start, index);
                     outputTable = breastCancerHeuberizedProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "CarsLaplace":
                    Cars_Laplace.Program carsProgram = new Cars_Laplace.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = carsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "CarsTdist":
                    Cars_Tdist.Program carsTdistProgram = new Cars_Tdist.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = carsTdistProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsPairwise":
                    Imports_Pairwise.Program importsProgram = new Imports_Pairwise.Program();
                     currentPageTable = this.Take(inputTable, start, index);
                     outputTable = importsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsPoisson":
                    Imports_Poisson.Program importsPoissonProgram = new Imports_Poisson.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = importsPoissonProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsQuantile":
                    Imports_Quantile.Program importsQuantileProgram = new Imports_Quantile.Program();
                     currentPageTable = this.Take(inputTable, start, index);
                     outputTable = importsQuantileProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsGaussian":
                    Tips_Gaussian.Program tipsProgram = new Tips_Gaussian.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = tipsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        private void UpdateAssociationRuleSample(int start, int index)
        {
            switch (this.Name)
            {
                case "Adult":
                    Adult.Program adultProgram = new Adult.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = adultProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Epub":
                    Epub.Program epubProgram = new Epub.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = epubProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Groceries":
                    Groceries.Program groceriesProgram = new Groceries.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = groceriesProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Income":
                    Income.Program incomeProgram = new Income.Program();
                    currentPageTable = this.Take(inputTable, start, index);
                    outputTable = incomeProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

                
        public void AddColumnToGrid(ObservableCollection<BusinessObject> enumList)
        {
            //var firstRow = (BusinessObject)enumList.FirstOrDefault();
            var firstRow = (BusinessObject)enumList[0];
            if (viewModel.SFDataGrid != null)
            {
                viewModel.SFDataGrid.Columns.Clear();
            }
            int index = 0;

            foreach (KeyValuePair<string, object> item in firstRow.DictValueProperty)
            {

                var cellValue = item.Value.ToString();
                
                double result = 0.0;
                

                if (double.TryParse(cellValue, out result))
                {
                   var column = new Syncfusion.UI.Xaml.Grid.GridNumericColumn();
                   column.UseBindingValue = true;
                   column.HeaderText = item.Key;
                   column.TextAlignment = TextAlignment.Right;
                   column.MappingName = "DictValueProperty[" + item.Key.ToString() + "]";

                   if (index >= inputTable.ColumnNames.Length)
                   {
                       column.CellStyle=Application.Current.Resources["predictedColumnColor"] as Style;
                   }
                   viewModel.SFDataGrid.Columns.Add(column);
                }
                else
                {
                    var textColumn = new Syncfusion.UI.Xaml.Grid.GridTextColumn();
                   textColumn.UseBindingValue = true;
                   textColumn.HeaderText = item.Key;
                   textColumn.MappingName = "DictValueProperty[" + item.Key.ToString() + "]";
                   if (index >= inputTable.ColumnNames.Length)
                   {
                       textColumn.CellStyle = Application.Current.Resources["predictedColumnColor"] as Style;
                   }
                   viewModel.SFDataGrid.Columns.Add(textColumn);
                }
                index++;           
            }
        }

        private ObservableCollection<BusinessObject> MergeTableDictionary(Syncfusion.PMML.Table inputTable, Syncfusion.PMML.Table outputTable)
        {
            ObservableCollection<BusinessObject> rows = new ObservableCollection<BusinessObject>();

            for (int i = 0; i < inputTable.RowCount; i++)
            {
                Dictionary<string, object> row = new Dictionary<string, object>();

                for (int j = 0; j < inputTable.ColumnCount; j++)
                {
                    row[inputTable.ColumnNames[j]] = inputTable[i, j];
                }
                for (int j = 0; j < outputTable.ColumnCount; j++)
                {
                    row[outputTable.ColumnNames[j]] = outputTable[i, j];
                }

                BusinessObject baseObject = new BusinessObject();
                baseObject.DictValueProperty = row;

                rows.Add(baseObject);
            }
            return rows;
        }

        /// <summary>
        /// Merge the DataSet input dataTable and outputTable
        /// </summary>
        /// <param name="inputDataTable"></param>
        /// <param name="outputTable"></param>
        /// <returns></returns>
        private DataTable MergeTable(DataTable inputDataTable,Syncfusion.PMML.Table outputTable)
        {            
            var columnEnumarator = outputTable.ColumnNames.GetEnumerator();            

            while (columnEnumarator.MoveNext())
            {
                var column = new DataColumn() { ColumnName = columnEnumarator.Current.ToString() };
                inputDataTable.Columns.Add(column);
            }

            for (int i = 0; i < inputDataTable.Rows.Count; i++)
            {
                for (int j = 0; j < outputTable.ColumnNames.Length; j++)
                {
                    inputDataTable.Rows[i].SetField(outputTable.ColumnNames[j], outputTable[i, j]);
                }
            }            

            return inputDataTable;
        }

        /// <summary>
        /// Load the general regression model samples
        /// </summary>
        /// <param name="sampleName">sample name </param>
        /// <param name="samplePath">sample file path</param>
        /// <param name="inputPath">inut file path</param>
        /// <param name="pmmlPath">pmml file path</param>
        /// <param name="outputPath">output file path</param>
        private void LoadGeneralRegressionSample(string samplePath, string inputPath, string outputPath)
        {            
            switch (this.Name)
            {
                case "WineLog":
                    WineLog.Program wineLogProgram = new WineLog.Program();
                    inputPath = samplePath + "Wine.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Wine");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineLogProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineIdentity":
                    WineIdentity.Program wineIdentityProgram = new WineIdentity.Program();
                    inputPath = samplePath + "Wine.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Wine");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineIdentityProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicLogit":
                    TitanicLogit.Program titanicLogitProgram = new TitanicLogit.Program();
                    inputPath = samplePath + "Titanic.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Titanic");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;     
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicLogitProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "TitanicCloglog":
                    TitanicCloglog.Program titanicCloglogProgram = new TitanicCloglog.Program();
                    inputPath = samplePath + "Titanic.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Titanic");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicCloglogProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "GlassCloglog":
                    GlassCloglog.Program glassCloglogProgram = new GlassCloglog.Program();
                    inputPath = samplePath + "Glass.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Glass");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = glassCloglogProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "GlassLogit":
                    GlassLogit.Program glassLogitProgram = new GlassLogit.Program();
                    inputPath = samplePath + "Glass.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Glass");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = glassLogitProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "OzoneLog":
                    OzoneLog.Program ozoneLogProgram = new OzoneLog.Program();
                    inputPath = samplePath + "Ozone.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Ozone");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozoneLogProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneIdentity":
                    OzoneIdentity.Program ozoneIdentityProgram = new OzoneIdentity.Program();
                    inputPath = samplePath + "Ozone.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Ozone");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;     
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozoneIdentityProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsIdentity":
                    TipsIdentity.Program tipsIdentityProgram = new TipsIdentity.Program();
                    inputPath = samplePath + "Tips.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Tips");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsIdentityProgram.PredictResult(currentPageTable, pmmlPath);             
                    break;

                case "ImportsIdentity":
                    ImportsIdentity.Program importsIdentityProgram = new ImportsIdentity.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;       
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsIdentityProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "CarsIdentity":
                    CarsIdentity.Program carsIdentityProgram = new CarsIdentity.Program();
                    inputPath = samplePath + "Cars.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Cars");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsIdentityProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerLogitRegression":
                    BreastCancerLogitRegression.Program bcLogitRegressionProgram = new BreastCancerLogitRegression.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = bcLogitRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerCloglogRegression":
                    BreastCancerCloglogRegression.Program bcCloglogRegressionProgram = new BreastCancerCloglogRegression.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = bcCloglogRegressionProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerCloglogClassification":
                    BreastCancerCloglogClassification.Program bcCloglogClassificationProgram = new BreastCancerCloglogClassification.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = bcCloglogClassificationProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerLogitClassification":
                    BreastCancerLogitClassification.Program bcLogitClassificationProgram = new BreastCancerLogitClassification.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = bcLogitClassificationProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "AuditLogitRegression":
                    AuditLogitRegression.Program auditLogitRegressionProgram = new AuditLogitRegression.Program();
                    inputPath = samplePath + "Audit.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Audit");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditLogitRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "AuditLogitClassification":
                    AuditLogitClassification.Program auditLogitClassificationProgram = new AuditLogitClassification.Program();
                    inputPath = samplePath + "Audit.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Audit");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditLogitClassificationProgram.PredictResult(currentPageTable, pmmlPath);                 
                    break;

                case "IrisLogit":
                    IrisLogit.Program irisLogitProgram = new IrisLogit.Program();
                    inputPath = samplePath + "Iris.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Iris");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisLogitProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "IrisCloglog":
                    IrisCloglog.Program irisCloglogProgram = new IrisCloglog.Program();
                    inputPath = samplePath + "Iris.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Iris");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisCloglogProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "AuditBinomialProbitClassification":
                    AuditBinomialProbitClassification.Program auditBinomialProbitClassificationProgram = new AuditBinomialProbitClassification.Program();
                    inputPath = samplePath + "Audit.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Audit");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditBinomialProbitClassificationProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "AuditQuasibinomialProbitRegression":
                    AuditQuasibinomialProbitRegression.Program auditQuasibinomialProbitClassificationProgram = new AuditQuasibinomialProbitRegression.Program();
                    inputPath = samplePath + "Audit.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Audit");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditQuasibinomialProbitClassificationProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerBinomialProbitClassification":
                    BreastCancerBinomialProbitClassification.Program breastCancerBinomialProbitClassificationProgram = new BreastCancerBinomialProbitClassification.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerBinomialProbitClassificationProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerGaussianInverseRegression":
                    BreastCancerGaussianInverseRegression.Program breastCancerGaussianInverseRegressionProgram = new BreastCancerGaussianInverseRegression.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerGaussianInverseRegressionProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerQuasiInverseRegression":
                    BreastCancerQuasiInverseRegression.Program breastCancerQuasiInverseRegressionProgram = new BreastCancerQuasiInverseRegression.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerQuasiInverseRegressionProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerQuasibinomialProbitRegression":
                    BreastCancerQuasibinomialProbitRegression.Program breastCancerQuasibinomialProbitClassificationProgram = new BreastCancerQuasibinomialProbitRegression.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerQuasibinomialProbitClassificationProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerQuasipoissonInverseRegression":
                    BreastCancerQuasipoissonInverseRegression.Program breastCancerQuasipoissonInverseRegressionProgram = new BreastCancerQuasipoissonInverseRegression.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerQuasipoissonInverseRegressionProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "BreastCancerQuasipoissonProbitRegression":
                    BreastCancerQuasipoissonProbitRegression.Program breastCancerQuasipoissonProbitRegressionProgram = new BreastCancerQuasipoissonProbitRegression.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerQuasipoissonProbitRegressionProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "CarsGammaInverse":
                    CarsGammaInverse.Program carsGammaInverseProgram = new CarsGammaInverse.Program();
                    inputPath = samplePath + "Cars.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Cars");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsGammaInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "CarsInverseGaussian":
                    CarsInverseGaussian.Program carsInverseGaussianProgram = new CarsInverseGaussian.Program();
                    inputPath = samplePath + "Cars.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Cars");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsInverseGaussianProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "CarsQuasiInverse":
                    CarsQuasiInverse.Program carsQuasiInverseProgram = new CarsQuasiInverse.Program();
                    inputPath = samplePath + "Cars.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Cars");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsQuasiInverseProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "CarsQuasiSqrt":
                    CarsQuasiSqrt.Program carsQuasiSqrtProgram = new CarsQuasiSqrt.Program();
                    inputPath = samplePath + "Cars.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Cars");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsQuasiSqrtProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "GlassBinomialProbit":
                    GlassBinomialProbit.Program glassBinomialProbitProgram = new GlassBinomialProbit.Program();
                    inputPath = samplePath + "Glass.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Glass");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = glassBinomialProbitProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "GlassQuasibinomialProbit":
                    GlassQuasibinomialProbit.Program glassQuasibinomialProbitProgram = new GlassQuasibinomialProbit.Program();
                    inputPath = samplePath + "Glass.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Glass");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = glassQuasibinomialProbitProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "ImportsGammaInverse":
                    ImportsGammaInverse.Program importsGammaInverseProgram = new ImportsGammaInverse.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsGammaInverseProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "ImportsGaussianInverse":
                    ImportsGaussianInverse.Program importsGaussianInverseProgram = new ImportsGaussianInverse.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsGaussianInverseProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "ImportsInverseGaussian":
                    ImportsInverseGaussian.Program importsInverseGaussianProgram = new ImportsInverseGaussian.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsInverseGaussianProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsNegativeBinomialSqrt":
                    ImportsNegativeBinomialSqrt.Program importsNegativeBinomialSqrtProgram = new ImportsNegativeBinomialSqrt.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsNegativeBinomialSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsPoissonSqrt":
                    ImportsPoissonSqrt.Program importsPoissonSqrtProgram = new ImportsPoissonSqrt.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsPoissonSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsQuasiInverse":
                    ImportsQuasiInverse.Program importsQuasiInverseProgram = new ImportsQuasiInverse.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsQuasiInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsQuasiSqrt":
                    ImportsQuasiSqrt.Program importsQuasiSqrtProgram = new ImportsQuasiSqrt.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsQuasiSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "IrisBinomialProbit":
                    IrisBinomialProbit.Program irisBinomialProbitProgram = new IrisBinomialProbit.Program();
                    inputPath = samplePath + "Iris.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Iris");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisBinomialProbitProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "IrisQuasibinomialProbit":
                    IrisQuasibinomialProbit.Program irisQuasibinomialProbitProgram = new IrisQuasibinomialProbit.Program();
                    inputPath = samplePath + "Iris.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Iris");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisQuasibinomialProbitProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneGammaInverse":
                    OzoneGammaInverse.Program ozoneGammaInverseProgram = new OzoneGammaInverse.Program();
                    inputPath = samplePath + "Ozone.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Ozone");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozoneGammaInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneGaussianInverse":
                    OzoneGaussianInverse.Program ozoneGaussianInverseProgram = new OzoneGaussianInverse.Program();
                    inputPath = samplePath + "Ozone.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Ozone");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozoneGaussianInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzonePoissonSqrt":
                    OzonePoissonSqrt.Program ozonePoissonSqrtProgram = new OzonePoissonSqrt.Program();
                    inputPath = samplePath + "Ozone.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Ozone");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozonePoissonSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneQuasiInverse":
                    OzoneQuasiInverse.Program ozoneQuasiInverseProgram = new OzoneQuasiInverse.Program();
                    inputPath = samplePath + "Ozone.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Ozone");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                      viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                outputTable = ozoneQuasiInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneQuasiSqrt":
                    OzoneQuasiSqrt.Program ozoneQuasiSqrtProgram = new OzoneQuasiSqrt.Program();
                    inputPath = samplePath + "Ozone.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Ozone");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozoneQuasiSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneQuasipoissonSqrt":
                    OzoneQuasipoissonSqrt.Program ozoneQuasipoissonSqrtProgram = new OzoneQuasipoissonSqrt.Program();
                    inputPath = samplePath + "Ozone.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Ozone");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozoneQuasipoissonSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsGammaInverse":
                    TipsGammaInverse.Program tipsGammaInverseProgram = new TipsGammaInverse.Program();
                    inputPath = samplePath + "Tips.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Tips");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsGammaInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsGaussianInverse":
                    TipsGaussianInverse.Program tipsGaussianInverseProgram = new TipsGaussianInverse.Program();
                    inputPath = samplePath + "Tips.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Tips");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsGaussianInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsInverseGaussian":
                    TipsInverseGaussian.Program tipsInverseGaussianProgram = new TipsInverseGaussian.Program();
                    inputPath = samplePath + "Tips.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Tips");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsInverseGaussianProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsQuasiInverse":
                    TipsQuasiInverse.Program tipsQuasiInverseProgram = new TipsQuasiInverse.Program();
                    inputPath = samplePath + "Tips.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Tips");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsQuasiInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsQuasiSqrt":
                    TipsQuasiSqrt.Program tipsQuasiSqrtProgram = new TipsQuasiSqrt.Program();
                    inputPath = samplePath + "Tips.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Tips");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsQuasiSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsQuasipoissonProbit":
                    TipsQuasipoissonProbit.Program tipsQuasipoissonProbitProbit = new TipsQuasipoissonProbit.Program();
                    inputPath = samplePath + "Tips.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Tips");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsQuasipoissonProbitProbit.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicBinomialProbit":
                    TitanicBinomialProbit.Program titanicBinomialProbitProgram = new TitanicBinomialProbit.Program();
                    inputPath = samplePath + "Titanic.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Titanic");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicBinomialProbitProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicQuasibinomialProbit":
                    TitanicQuasibinomialProbit.Program titanicQuasibinomialProbitProgram = new TitanicQuasibinomialProbit.Program();
                    inputPath = samplePath + "Titanic.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Titanic");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicQuasibinomialProbitProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineGammaInverse":
                    WineGammaInverse.Program wineGammaInverseProgram = new WineGammaInverse.Program();
                    inputPath = samplePath + "Wine.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Wine");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineGammaInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineInverseGaussian":
                    WineInverseGaussian.Program wineInverseGaussianProgram = new WineInverseGaussian.Program();
                    inputPath = samplePath + "Wine.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Wine");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineInverseGaussianProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WinePoissonSqrt":
                    WinePoissonSqrt.Program winePoissonSqrtProgram = new WinePoissonSqrt.Program();
                    inputPath = samplePath + "Wine.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Wine");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = winePoissonSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineQuasiInverse":
                    WineQuasiInverse.Program wineQuasiInverseProgram = new WineQuasiInverse.Program();
                    inputPath = samplePath + "Wine.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Wine");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineQuasiInverseProgram.PredictResult(currentPageTable, pmmlPath);                    
                    break;

                case "WineQuasiSqrt":
                    WineQuasiSqrt.Program wineQuasiSqrtProgram = new WineQuasiSqrt.Program();
                    inputPath = samplePath + "Wine.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Wine");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineQuasiSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineQuasipoissonInverse":
                    WineQuasipoissonInverse.Program wineQuasipoissonInverseProgram = new WineQuasipoissonInverse.Program();
                    inputPath = samplePath + "Wine.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Wine");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineQuasipoissonInverseProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineQuasipoissonSqrt":
                    WineQuasipoissonSqrt.Program wineQuasipoissonSqrtProgram = new WineQuasipoissonSqrt.Program();
                    inputPath = samplePath + "Wine.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Wine");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;        
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineQuasipoissonSqrtProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }         
        
        }

        /// <summary>
        /// Load the Clustering model samples
        /// </summary>
        /// <param name="sampleName">sample name </param>
        /// <param name="samplePath">sample file path</param>
        /// <param name="inputPath">inut file path</param>
        /// <param name="pmmlPath">pmml file path</param>
        /// <param name="outputPath">output file path</param>
        private void LoadClusteringSample(string samplePath, string inputPath, string outputPath)
        {
            switch (this.Name)
            {
                case "Audit":
                    AuditKMeans.Program auditKMeansProgram = new AuditKMeans.Program();
                    inputPath = samplePath + "Audit.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditKMeansProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "BreastCancer":
                    BreastCancerKMeans.Program breastCancerKMeansKMeansProgram = new BreastCancerKMeans.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerKMeansKMeansProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "Glass":
                    GlassKMeans.Program glassKMeansProgram = new GlassKMeans.Program();
                    inputPath = samplePath + "Glass.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = glassKMeansProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "Iris":
                    IrisKMeans.Program irisKMeansProgram = new IrisKMeans.Program();
                    inputPath = samplePath + "Iris.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisKMeansProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "Titanic":
                    TitanicKMeans.Program titanicKMeansProgram = new TitanicKMeans.Program();
                    inputPath = samplePath + "Titanic.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicKMeansProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "Wine":
                    WineKMeans.Program wineKMeansProgram = new WineKMeans.Program();
                    inputPath = samplePath + "Wine.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineKMeansProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        /// <summary>
        /// Load the Cox Regression  model samples
        /// </summary>
        /// <param name="sampleName">sample name </param>
        /// <param name="samplePath">sample file path</param>
        /// <param name="inputPath">inut file path</param>
        /// <param name="pmmlPath">pmml file path</param>
        /// <param name="outputPath">output file path</param>
        private void LoadCoxRegressionSample(string samplePath, string inputPath, string outputPath)
        {
            switch (this.Name)
            {
                case "Aml":
                    AmlCoxRegression.Program amlCoxRegressionProgram = new AmlCoxRegression.Program();
                    inputPath = samplePath + "Aml.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = amlCoxRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Bfeed":
                    BfeedCoxRegression.Program bfeedCoxRegressionProgram = new BfeedCoxRegression.Program();
                    inputPath = samplePath + "Bfeed.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = bfeedCoxRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Larynx":
                    LarynxCoxRegression.Program larynxCoxRegressionProgram = new LarynxCoxRegression.Program();
                    inputPath = samplePath + "Larynx.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = larynxCoxRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Lung":
                    LungCoxRegression.Program lungCoxRegressionProgram = new LungCoxRegression.Program();
                    inputPath = samplePath + "Lung.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = lungCoxRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "Ovarian":
                    OvarianCoxRegression.Program ovarianCoxRegressionProgram = new OvarianCoxRegression.Program();
                    inputPath = samplePath + "Ovarian.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ovarianCoxRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
                case "Rats":
                    RatsCoxRegression.Program ratsCoxRegressionProgram = new RatsCoxRegression.Program();
                    inputPath = samplePath + "Rats.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ratsCoxRegressionProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        /// <summary>
        /// Load the Multinomial regression model samples
        /// </summary>
        /// <param name="sampleName">sample name </param>
        /// <param name="samplePath">sample file path</param>
        /// <param name="inputPath">inut file path</param>
        /// <param name="pmmlPath">pmml file path</param>
        /// <param name="outputPath">output file path</param>
        private void LoadMultinomialSample(string samplePath, string inputPath, string outputPath)
        {
            switch (this.Name)
            {
                case "Audit":
                    AuditMultinomial.Program auditProgram = new AuditMultinomial.Program();
                    inputPath = samplePath + "Audit.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancer":
                    BreastCancerMultinomial.Program breastCancerProgram = new BreastCancerMultinomial.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Glass":
                    GlassMultinomial.Program glassProgram = new GlassMultinomial.Program();
                    inputPath = samplePath + "Glass.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = glassProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Iris":
                    IrisMultinomial.Program irisProgram = new IrisMultinomial.Program();
                    inputPath = samplePath + "Iris.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Titanic":
                    TitanicMultinomial.Program titanicProgram = new TitanicMultinomial.Program();
                    inputPath = samplePath + "Titanic.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Wine":
                    WineMultinomial.Program wineProgram = new WineMultinomial.Program();
                    inputPath = samplePath + "Wine.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }
        
        /// <summary>
        /// Method to load naive bayes Samples
        /// </summary>
        /// <param name="sampleName">Sample's name</param>
        /// <param name="samplePath">sample path</param>
        /// <param name="inputPath">input path</param>
        /// <param name="pmmlPath">pmml path</param>
        /// <param name="outputPath">output path</param>
        private void LoadNaiveBayesSample(string samplePath, string inputPath, string outputPath)
        {
            switch (this.Name)
            {
                case "Audit":
                    Audit.Program auditProgram = new Audit.Program();
                    inputPath = samplePath + "Audit.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancer":
                    BreastCancer.Program breastCancerProgram = new BreastCancer.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Imports":
                    Imports.Program importsProgram = new Imports.Program();
                    inputPath = samplePath + "Imports.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Iris":
                    Iris.Program irisProgram = new Iris.Program();
                    inputPath = samplePath + "Iris.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Titanic":
                    Titanic.Program titanicProgram = new Titanic.Program();
                    inputPath = samplePath + "Titanic.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Wine":
                    Wine.Program wineProgram = new Wine.Program();
                    inputPath = samplePath + "Wine.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        /// <summary>
        /// Method to load Random Forest Samples
        /// </summary>
        /// <param name="sampleName">Sample's name</param>
        /// <param name="samplePath">sample path</param>
        /// <param name="inputPath">input path</param>
        /// <param name="pmmlPath">pmml path</param>
        /// <param name="outputPath">output path</param>
        private void LoadRandomForestSample(string samplePath, string inputPath, string outputPath)
        {
            switch (this.Name)
            {
                case "Audit":
                    AuditRandomForest.Program auditProgram = new AuditRandomForest.Program();
                    inputPath = samplePath + "Audit.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancer":
                    BreastCancerRandomForest.Program breastCancerProgram = new BreastCancerRandomForest.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Cars":
                    CarsRandomForest.Program carsProgram = new CarsRandomForest.Program();
                    inputPath = samplePath + "Cars.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Glass":
                    GlassRandomForest.Program glassProgram = new GlassRandomForest.Program();
                    inputPath = samplePath + "Glass.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = glassProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Imports":
                    ImportsRandomForest.Program importsProgram = new ImportsRandomForest.Program();
                    inputPath = samplePath + "Imports.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Iris":
                    IrisRandomForest.Program irisProgram = new IrisRandomForest.Program();
                    inputPath = samplePath + "Iris.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Ozone":
                    OzoneRandomForest.Program ozoneProgram = new OzoneRandomForest.Program();
                    inputPath = samplePath + "Ozone.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozoneProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Tips":
                    TipsRandomForest.Program tipsProgram = new TipsRandomForest.Program();
                    inputPath = samplePath + "Tips.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Titanic":
                    TitanicRandomForest.Program titanicProgram = new TitanicRandomForest.Program();
                    inputPath = samplePath + "Titanic.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Wine":
                    WineRandomForest.Program wineProgram = new WineRandomForest.Program();
                    inputPath = samplePath + "Wine.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        /// <summary>
        /// Method to load Regression Samples
        /// </summary>
        /// <param name="sampleName">Sample's name</param>
        /// <param name="samplePath">sample path</param>
        /// <param name="inputPath">input path</param>
        /// <param name="pmmlPath">pmml path</param>
        /// <param name="outputPath">output path</param>
        private void LoadRegressionSample(string samplePath, string inputPath, string outputPath)
        {
            switch (this.Name)
            {
                case "Cars":
                    CarsRegression.Program carsProgram = new CarsRegression.Program();
                    inputPath = samplePath + "Cars.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Imports":
                    ImportsRegression.Program importsProgram = new ImportsRegression.Program();
                    inputPath = samplePath + "Imports.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Ozone":
                    OzoneRegression.Program ozoneProgram = new OzoneRegression.Program();
                    inputPath = samplePath + "Ozone.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozoneProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Tips":
                    TipsRegression.Program tipsProgram = new TipsRegression.Program();
                    inputPath = samplePath + "Tips.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        /// <summary>
        /// Method to load Support Vector Machine Samples
        /// </summary>
        /// <param name="sampleName">Sample's name</param>
        /// <param name="samplePath">sample path</param>
        /// <param name="inputPath">input path</param>
        /// <param name="pmmlPath">pmml path</param>
        /// <param name="outputPath">output path</param>
        private void LoadSupportVectorMachineSample(string samplePath, string inputPath, string outputPath)
        {
            switch (this.Name)
            {
                case "AuditLinear":
                    AuditLinear.Program auditLinearProgram = new AuditLinear.Program();
                    inputPath = samplePath + "Audit.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Audit");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "AuditPolynomial":
                    AuditPolynomial.Program auditPolynomialProgram = new AuditPolynomial.Program();
                    inputPath = samplePath + "Audit.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Audit");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "AuditRadial":
                    AuditRadial.Program auditRadialProgram = new AuditRadial.Program();
                    inputPath = samplePath + "Audit.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Audit");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "AuditSigmoid":
                    AuditSigmoid.Program auditSigmoidProgram = new AuditSigmoid.Program();
                    inputPath = samplePath + "Audit.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Audit");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerLinear":
                    BreastCancerLinear.Program bcLinearProgram = new BreastCancerLinear.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = bcLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerPolynomial":
                    BreastCancerPolynomial.Program bcPolynomialProgram = new BreastCancerPolynomial.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = bcPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerRadial":
                    BreastCancerRadial.Program bcRadialProgram = new BreastCancerRadial.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = bcRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerSigmoid":
                    BreastCancerSigmoid.Program bcSigmoidProgram = new BreastCancerSigmoid.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = bcSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "CarsLinear":
                    CarsLinear.Program carsLinearProgram = new CarsLinear.Program();
                    inputPath = samplePath + "Cars.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Cars");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "CarsPolynomial":
                    CarsPolynomial.Program carsPolynomialProgram = new CarsPolynomial.Program();
                    inputPath = samplePath + "Cars.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Cars");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "CarsRadial":
                    CarsRadial.Program carsRadialProgram = new CarsRadial.Program();
                    inputPath = samplePath + "Cars.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Cars");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "CarsSigmoid":
                    CarsSigmoid.Program carsSigmoidProgram = new CarsSigmoid.Program();
                    inputPath = samplePath + "Cars.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Cars");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "GlassLinear":
                    GlassLinear.Program glassLinearProgram = new GlassLinear.Program();
                    inputPath = samplePath + "Glass.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Glass");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = glassLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "GlassPolynomial":
                    GlassPolynomial.Program glassPolynomialProgram = new GlassPolynomial.Program();
                    inputPath = samplePath + "Glass.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Glass");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = glassPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "GlassRadial":
                    GlassRadial.Program glassRadialProgram = new GlassRadial.Program();
                    inputPath = samplePath + "Glass.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Glass");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = glassRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "GlassSigmoid":
                    GlassSigmoid.Program glassSigmoidProgram = new GlassSigmoid.Program();
                    inputPath = samplePath + "Glass.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Glass");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Glass");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = glassSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsLinear":
                    ImportsLinear.Program importsLinearProgram = new ImportsLinear.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsPolynomial":
                    ImportsPolynomial.Program importsPolynomialProgram = new ImportsPolynomial.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsRadial":
                    ImportsRadial.Program importsRadialProgram = new ImportsRadial.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsSigmoid":
                    ImportsSigmoid.Program importsSigmoidProgram = new ImportsSigmoid.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "IrisLinear":
                    IrisLinear.Program irisLinearProgram = new IrisLinear.Program();
                    inputPath = samplePath + "Iris.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Iris");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "IrisPolynomial":
                    IrisPolynomial.Program irisPolynomialProgram = new IrisPolynomial.Program();
                    inputPath = samplePath + "Iris.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Iris");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "IrisRadial":
                    IrisRadial.Program irisRadialProgram = new IrisRadial.Program();
                    inputPath = samplePath + "Iris.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Iris");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "IrisSigmoid":
                    IrisSigmoid.Program irisSigmoidProgram = new IrisSigmoid.Program();
                    inputPath = samplePath + "Iris.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Iris");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Iris");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneLinear":
                    OzoneLinear.Program ozoneLinearProgram = new OzoneLinear.Program();
                    inputPath = samplePath + "Ozone.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Ozone");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozoneLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzonePolynomial":
                    OzonePolynomial.Program ozonePolynomialProgram = new OzonePolynomial.Program();
                    inputPath = samplePath + "Ozone.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Ozone");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozonePolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneRadial":
                    OzoneRadial.Program ozoneRadialProgram = new OzoneRadial.Program();
                    inputPath = samplePath + "Ozone.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Ozone");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozoneRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "OzoneSigmoid":
                    OzoneSigmoid.Program ozoneSigmoidProgram = new OzoneSigmoid.Program();
                    inputPath = samplePath + "Ozone.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Ozone");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Ozone");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozoneSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsLinear":
                    TipsLinear.Program tipsLinearProgram = new TipsLinear.Program();
                    inputPath = samplePath + "Tips.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Tips");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsPolynomial":
                    TipsPolynomial.Program tipsPolynomialProgram = new TipsPolynomial.Program();
                    inputPath = samplePath + "Tips.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Tips");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsRadial":
                    TipsRadial.Program tipsRadialProgram = new TipsRadial.Program();
                    inputPath = samplePath + "Tips.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Tips");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsSigmoid":
                    TipsSigmoid.Program tipsSigmoidProgram = new TipsSigmoid.Program();
                    inputPath = samplePath + "Tips.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Tips");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicLinear":
                    TitanicLinear.Program titanicLinearProgram = new TitanicLinear.Program();
                    inputPath = samplePath + "Titanic.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Titanic");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicPolynomial":
                    TitanicPolynomial.Program titanicPolynomialProgram = new TitanicPolynomial.Program();
                    inputPath = samplePath + "Titanic.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Titanic");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicPolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicRadial":
                    TitanicRadial.Program titanicRadialProgram = new TitanicRadial.Program();
                    inputPath = samplePath + "Titanic.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Titanic");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TitanicSigmoid":
                    TitanicSigmoid.Program titanicSigmoidProgram = new TitanicSigmoid.Program();
                    inputPath = samplePath + "Titanic.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Titanic");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Titanic");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineLinear":
                    WineLinear.Program wineLinearProgram = new WineLinear.Program();
                    inputPath = samplePath + "Wine.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Wine");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineLinearProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WinePolynomial":
                    WinePolynomial.Program winePolynomialProgram = new WinePolynomial.Program();
                    inputPath = samplePath + "Wine.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Wine");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = winePolynomialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineRadial":
                    WineRadial.Program wineRadialProgram = new WineRadial.Program();
                    inputPath = samplePath + "Wine.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Wine");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineRadialProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "WineSigmoid":
                    WineSigmoid.Program wineSigmoidProgram = new WineSigmoid.Program();
                    inputPath = samplePath + "Wine.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Wine");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Wine");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineSigmoidProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        /// <summary>
        /// Method to load Tree Model Samples
        /// </summary>
        /// <param name="sampleName">Sample's name</param>
        /// <param name="samplePath">sample path</param>
        /// <param name="inputPath">input path</param>
        /// <param name="pmmlPath">pmml path</param>
        /// <param name="outputPath">output path</param>
        private void LoadTreeModelSample(string samplePath, string inputPath, string outputPath)
        {
            switch (this.Name)
            {
                case "Audit":
                    AuditTree.Program auditProgram = new AuditTree.Program();
                    inputPath = samplePath + "Audit.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancer":
                    BreastCancerTree.Program breastCancerProgram = new BreastCancerTree.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Cars":
                    CarsTree.Program carsProgram = new CarsTree.Program();
                    inputPath = samplePath + "Cars.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Glass":
                    GlassTree.Program glassProgram = new GlassTree.Program();
                    inputPath = samplePath + "Glass.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = glassProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Imports":
                    ImportsTree.Program importsProgram = new ImportsTree.Program();
                    inputPath = samplePath + "Imports.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Iris":
                    IrisTree.Program irisProgram = new IrisTree.Program();
                    inputPath = samplePath + "Iris.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Ozone":
                    OzoneTree.Program ozoneProgram = new OzoneTree.Program();
                    inputPath = samplePath + "Ozone.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozoneProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Tips":
                    TipsTree.Program tipsProgram = new TipsTree.Program();
                    inputPath = samplePath + "Tips.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Titanic":
                    TitanicTree.Program titanicProgram = new TitanicTree.Program();
                    inputPath = samplePath + "Titanic.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Wine":
                    WineTree.Program wineProgram = new WineTree.Program();
                    inputPath = samplePath + "Wine.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        /// <summary>
        /// Method to load Neural Network Samples
        /// </summary>
        /// <param name="sampleName">Sample's name</param>
        /// <param name="samplePath">sample path</param>
        /// <param name="inputPath">input path</param>
        /// <param name="pmmlPath">pmml path</param>
        /// <param name="outputPath">output path</param>
        private void LoadNeuralNetworksSample(string samplePath, string inputPath, string outputPath)
        {
            switch (this.Name)
            {
                case "Audit":
                    AuditNeural.Program auditProgram = new AuditNeural.Program();
                    inputPath = samplePath + "Audit.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancer":
                    BreastCancerNeural.Program breastCancerProgram = new BreastCancerNeural.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Cars":
                    CarsNeural.Program carsProgram = new CarsNeural.Program();
                    inputPath = samplePath + "Cars.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Glass":
                    GlassNeural.Program glassProgram = new GlassNeural.Program();
                    inputPath = samplePath + "Glass.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = glassProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Imports":
                    ImportsNeural.Program importsProgram = new ImportsNeural.Program();
                    inputPath = samplePath + "Imports.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Iris":
                    IrisNeural.Program irisProgram = new IrisNeural.Program();
                    inputPath = samplePath + "Iris.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = irisProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Ozone":
                    OzoneNeural.Program ozoneProgram = new OzoneNeural.Program();
                    inputPath = samplePath + "Ozone.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = ozoneProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Tips":
                    TipsNeural.Program tipsProgram = new TipsNeural.Program();
                    inputPath = samplePath + "Tips.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Titanic":
                    TitanicNeural.Program titanicProgram = new TitanicNeural.Program();
                    inputPath = samplePath + "Titanic.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = titanicProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Wine":
                    WineNeural.Program wineProgram = new WineNeural.Program();
                    inputPath = samplePath + "Wine.csv";
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = wineProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        /// <summary>
        /// Load the Gradient Boosting Machine model samples
        /// </summary>
        /// <param name="sampleName">sample name </param>
        /// <param name="samplePath">sample file path</param>
        /// <param name="inputPath">inut file path</param>
        /// <param name="pmmlPath">pmml file path</param>
        /// <param name="outputPath">output file path</param>
        private void LoadGradientBoostingSample(string samplePath, string inputPath, string outputPath)
        {
            switch (this.Name)
            {
                case "AuditBernoulli":
                    Audit_Bernoulli.Program auditProgram = new Audit_Bernoulli.Program();
                    inputPath = samplePath + "Audit.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Audit");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Audit");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = auditProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BfeedCoxph":
                    Bfeed_Coxph.Program bfeedProgram = new Bfeed_Coxph.Program();
                    inputPath = samplePath + "Bfeed.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Bfeed");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Bfeed");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = bfeedProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerAdaboost":
                    BreastCancer_Adaboost.Program breastCancerProgram = new BreastCancer_Adaboost.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "BreastCancerHuberized":
                    BreastCancer_Huberized.Program breastCancerHeuberizedProgram = new BreastCancer_Huberized.Program();
                    inputPath = samplePath + "BreastCancer.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "BreastCancer");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "BreastCancer");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = breastCancerHeuberizedProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "CarsLaplace":
                    Cars_Laplace.Program carsProgram = new Cars_Laplace.Program();
                    inputPath = samplePath + "Cars.csv";
                     pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Cars");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "CarsTdist":
                    Cars_Tdist.Program carsTdistProgram = new Cars_Tdist.Program();
                    inputPath = samplePath + "Cars.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Cars");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Cars");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = carsTdistProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsPairwise":
                    Imports_Pairwise.Program importsProgram = new Imports_Pairwise.Program();
                    inputPath = samplePath + "Imports.csv";
                     pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsPoisson":
                    Imports_Poisson.Program importsPoissonProgram = new Imports_Poisson.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsPoissonProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "ImportsQuantile":
                    Imports_Quantile.Program importsQuantileProgram = new Imports_Quantile.Program();
                    inputPath = samplePath + "Imports.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Imports");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Imports");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = importsQuantileProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "TipsGaussian":
                    Tips_Gaussian.Program tipsProgram = new Tips_Gaussian.Program();
                    inputPath = samplePath + "Tips.csv";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Tips");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Tips");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, ',');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = tipsProgram.PredictResult(currentPageTable, pmmlPath);
                    break;
            }
        }

        /// <summary>
        /// Load the Association Rule model samples
        /// </summary>
        /// <param name="sampleName">sample name </param>
        /// <param name="samplePath">sample file path</param>
        /// <param name="inputPath">inut file path</param>
        /// <param name="pmmlPath">pmml file path</param>
        /// <param name="outputPath">output file path</param>
        /// 
        private void LoadAssociationRuleSample(string samplePath, string inputPath, string outputPath)
        {
            switch (this.Name)
            {
                case "Adult":
                    Adult.Program adultProgram = new Adult.Program();
                    inputPath = samplePath + "Adult.txt";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Adult");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Adult");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, '\t');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = adultProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Epub":
                    Epub.Program epubProgram = new Epub.Program();
                    inputPath = samplePath + "Epub.txt";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Epub");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Epub");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, '\t');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = epubProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Groceries":
                    Groceries.Program groceriesProgram = new Groceries.Program();
                    inputPath = samplePath + "Groceries.txt";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Groceries");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Groceries");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, '\t');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = groceriesProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

                case "Income":
                    Income.Program incomeProgram = new Income.Program();
                    inputPath = samplePath + "Income.txt";
                    pmmlPath = string.Format("{0}{1}.pmml", samplePath, "Income");
                    rScriptPath = string.Format("{0}{1}.R", samplePath, "Income");
                    inputTable = new Syncfusion.PMML.Table(inputPath, true, '\t');
                    viewModel.PageCount = inputTable.RowCount / viewModel.PageSize;
                    currentPageTable = this.Take(inputTable, 0, viewModel.PageSize);
                    outputTable = incomeProgram.PredictResult(currentPageTable, pmmlPath);
                    break;

            }
        }

        /// <summary>
        /// Select the current page rows from input table
        /// </summary>
        /// <param name="inputTable">Table</param>
        /// <param name="skip">int</param>
        /// <param name="take">int</param>
        /// <returns>Table</returns>
        public Syncfusion.PMML.Table Take(Syncfusion.PMML.Table inputTable, int skip, int take)
        {
            int rowCount = skip;

            take = take > inputTable.RowCount ? inputTable.RowCount : take;

            Syncfusion.PMML.Table currentPageTable = new Syncfusion.PMML.Table(take - skip, inputTable.ColumnCount);

            for (int i = 0; i < inputTable.ColumnCount; i++)
            {
                currentPageTable.ColumnNames[i] = inputTable.ColumnNames[i];
            }

            int row = 0;
            for (int i = skip; i < take; i++)
            {
                currentPageTable[row] = inputTable[i];
                row++;
            }

            return currentPageTable;
        }
    }
}