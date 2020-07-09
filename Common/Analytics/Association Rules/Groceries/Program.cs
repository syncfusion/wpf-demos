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
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Groceries
{
    /// <summary>
    /// Console program to demonstrate PMML execution engine
    /// </summary>
    public class Program
    {
        //Create Table instance for input and output
        public Table inputTable = null;
        private Table outputTable = null;

#if CONSOLE

        private static void Main(string[] args)
        {
            //Create instance
            Program program = new Program();
            //Load input csv
            program.inputTable = new Table("../../Model/Groceries.txt", true, '\t');
            //Invoke PredictResult
            program.outputTable = program.PredictResult(program.inputTable,
                "../../Model/Groceries.pmml");
            //Write the Result as CSV File
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
            string[] recommendations = null;
            string[] exclusiveRecommendations = null;
            string[] ruleAssociations = null;
            List<string> input = null;
            int index = 0;

            //Get PMML Evaluator instance
            PMMLEvaluator evaluator = new PMMLEvaluatorFactory().
              GetPMMLEvaluatorInstance(pmmlPath);

            for (int i = 0; i < inputTable.ColumnNames.Length; i++)
            {
                if (inputTable.ColumnNames[i].ToLower() == "items")
                    index = i;
            }

            //Predict the recommendations, exclusiveRecommendations and ruleAssociations for each transactions using the PMML Evaluator instance
            for (int i = 0; i < inputTable.RowCount; i++)
            {
                input = inputTable[i,index].ToString().Replace("{", "").Replace("}", "").Split(new char[] { ',' }).ToList();

                //Get result
                PredictedResult predictedResult = evaluator.GetResult(input, null);
                recommendations = predictedResult.GetRecommendations();
                exclusiveRecommendations = predictedResult.GetExclusiveRecommendations();
                ruleAssociations = predictedResult.GetRuleAssociations();

                if (i == 0)
                {
                    InitializeTable(inputTable.RowCount);
                }

                outputTable[i, 0] = "[" + string.Join(",", recommendations) + "]";
                outputTable[i, 1] = "[" + string.Join(",", exclusiveRecommendations) + "]";
                outputTable[i, 2] = "[" + string.Join(",", ruleAssociations) + "]";
            }

                return outputTable;
        }

        #endregion PredictResult

        #region Initialize OutputTable

        /// <summary>
        /// Initialize the outputTable
        /// </summary>
        /// <param name="rowCount">rowCount of output table</param>
        private void InitializeTable(int rowCount)
        {
            //Create instance to hold evaluated results
            outputTable = new Table(rowCount, 3);
            //Add predicted column names
            outputTable.ColumnNames[0] = "Recommendation";
            outputTable.ColumnNames[1] = "Exclusive_Recommendation";
            outputTable.ColumnNames[2] = "Rule_Association";
        }

        #endregion Initialize OutputTable
    }
}