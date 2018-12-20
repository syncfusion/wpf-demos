#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.PMML;
using System;
using System.Collections.Generic;
using System.IO;

namespace AuditLogitClassification
{
    /// <summary>
    /// Console program to demonstrate PMML execution engine
    /// </summary>
    public class Program
    {
        //Create Table instance for input, output and R Result
        public Table inputTable = null;

        private Table outputTable = null;
        private Table rResults = null;

#if CONSOLE

        private static void Main(string[] args)
        {
            //Create instance
            Program program = new Program();
            //Load input csv
            program.inputTable = new Table("../../Model/Audit.csv", true, ',');
            //Invoke PredictResult
            program.outputTable = program.PredictResult(program.inputTable,
                "../../Model/Audit.pmml");
            //Compare predicted results of PMML execution engine with R Results
            //Dispose the inputTable values
            program.inputTable.Dispose();
            program.ComparePredictedResultsWithR("../../Model/ROutput.csv");
            //Write the Result as CSV Table
            program.outputTable.WriteToCSV("../../Model/PredictedOutput.csv", true, ',');
            //Dispose the output Table
            program.outputTable.Dispose();
            //Display the result saved location
            Console.WriteLine("\nResult saved in : " + Path.GetFullPath("../../Model/PredictedOutput.csv"));
            Console.ReadKey();
        }

#endif

        #region PredictResult

        /// <summary>
        /// Predicts the results for given PMML and CSV file and serialize the results in a CSV file
        /// </summary>
        public Table PredictResult(Table inputTable, string pmmlPath)  
        {
            //Get PMML Evaluator instance
            PMMLEvaluator evaluator = new PMMLEvaluatorFactory().
              GetPMMLEvaluatorInstance(pmmlPath);

            string[] predictedCategories = null;

            //Predict the value for each record using the PMML Evaluator instance
            for (int i = 0; i < inputTable.RowCount; i++)
            {
                var audit = GetDataObject(inputTable, i);

                //Get result
                PredictedResult predictedResult = evaluator.GetResult(audit, null);

                if (i == 0)
                {
                    //Get the predicted propability fields
                    predictedCategories = predictedResult.GetPredictedCategories();
                    //Initialize the output table
                    InitializeTable(inputTable.RowCount, predictedResult.PredictedField, predictedCategories);
                }

                //Add predicted value
                outputTable[i, 0] = predictedResult.PredictedValue;

                for (int j = 1; j <= predictedCategories.Length; j++)
                    outputTable[i, j] = predictedResult.GetPredictedProbability(predictedCategories[j - 1]);
            }
            return outputTable;
        }

        #endregion PredictResult

        #region Compare Predicted Results With R

        /// <summary>
        /// Compare predicted results of PMML execution engine with R results
        /// </summary>

        public void ComparePredictedResultsWithR(string rOutputDataCSVPath)
        {
            //Create instance to hold results of R
            rResults = new Table(rOutputDataCSVPath, true, ',');
            string differentIndices = string.Empty;
            //Pass the Table to the compare method of resultTable
            bool isDifferent = Compare(rResults, 1, 0, ref differentIndices);
            //Display mismatched index
#if CONSOLE
            if (isDifferent)
            {
                Console.WriteLine("\nDifference in predicted results by R and PMML execution engine");
                Console.WriteLine("\nDifferent indices are " + differentIndices);
            }
            else
            {
                Console.WriteLine("\nBoth predicted results by R and PMML execution engine are equal");
            }
            //Dispose the R results Table
#endif
            rResults.Dispose();
        }

        #endregion Compare Predicted Results With R

        #region Initialize OutputTable

        /// <summary>
        /// Initialize the outputTable
        /// </summary>
        /// <param name="rowCount">rowCount of output table</param>
        /// <param name="predictedfield">predictedfield name</param>
        /// <param name="predictedCategories">probableFields</param>
        private void InitializeTable(int rowCount, string predictedfield, string[] predictedCategories)
        {
            //Create instance to hold evaluated results
            outputTable = new Table(rowCount, predictedCategories.Length + 1);
            //Add predicted column names
            outputTable.ColumnNames[0] = "Predicted_" + predictedfield;
            outputTable.ColumnNames[1] = "AuditLowriskProbability";
            outputTable.ColumnNames[2] = "AuditHighriskProbability";
        }

        #endregion Initialize OutputTable

        #region GetDataObject

        /// <summary>
        /// Returns the row as anonymous object
        /// </summary>
        /// <param name="inputTable"> input Table values</param>
        /// <param name="row">input row</param>
        /// <returns>Anonymous object</returns>
        public Dictionary<string, object> GetDataObject(Table inputTable, int row)
        {
            Dictionary<string, object> audit = new Dictionary<string, object>();
            for (int i = 0; i < inputTable.ColumnCount; i++)
            {
                audit.Add(inputTable.ColumnNames[i], inputTable[row, inputTable.ColumnNames[i]]);
            }
            return audit;
        }

        #endregion GetDataObject

        #region Compare

        /// <summary>
        /// Compares the result of 2 Tables based on column index.
        /// </summary>
        /// <param name="rOutput">R output table</param>
        /// <param name="rColumnIndex">R's Column to be compared</param>
        /// <param name="predictedColumnIndex">predicted result's column index</param>
        /// <param name="differentIndices"> different indices</param>
        public bool Compare(Table table, int rColumnIndex, int predictedColumnIndex, ref string differentIndices)
        {
            bool isDifferent = false;
            //Compare predicted values
            for (int i = 0; i < table.RowCount; i++)
            {
                //Compare Results based on column index
                if (outputTable[i, predictedColumnIndex].ToString() != table[i, rColumnIndex].ToString())
                {
                    differentIndices += ", " + i;
                    isDifferent = true;
                }
            }
            return isDifferent;
        }

        #endregion Compare
    }
}