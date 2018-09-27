using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using ISummary = Syncfusion.Collections.BinaryTree.ITreeTableSummary;
using Syncfusion.Grouping;

namespace RandomTest
{
    public class StartTestCmd : ICommand
    {
        private ViewModel viewModel;

        public StartTestCmd(ViewModel _viewModel)
        {
            viewModel = _viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            viewModel.IntCollection.Clear();

            int refreshValue = int.Parse(viewModel.NRefreshrate);

            int timeLimit = Environment.TickCount + 1000 * int.Parse(viewModel.NTimeInTest);

            int count = 0;

            Random r = new Random();

            while (count < int.MaxValue && Environment.TickCount < timeLimit)
            {
                viewModel.IntCollection.Add(new WrappedInt(r.Next(100)));
                count++;
                if ((count % refreshValue) == 0)
                {
                    UpdateDisplay();                    
                }
            }
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            //bool summaryChange;
            ISummary[] summaries = viewModel.TheTable.TopLevelGroup.GetSummaries(viewModel.TheTable);
            SummaryDescriptorCollection sdc = viewModel.TheTable.TableDescriptor.Summaries;
            int index = sdc.IndexOf(sdc["Int32Agg"]);
            Int32AggregateSummary summaryInt32Agg = summaries[index] as Int32AggregateSummary;

            viewModel.Lblauto = viewModel.TheTable.Records.Count.ToString();
            viewModel.Lblavg = summaryInt32Agg.Average.ToString("F2");

            index = sdc.IndexOf(sdc["Vect"]);
            DoubleVectorSummary summaryVector = summaries[index] as DoubleVectorSummary;

            viewModel.Lblmed = summaryVector.Median.ToString();
            viewModel.Lblpeer25 = summaryVector.Percentile25.ToString();
            viewModel.Lblper75 = summaryVector.Percentile75.ToString();

            index = sdc.IndexOf(sdc["Int32Agg"]);

            int bucketCount = viewModel.TheTable.TopLevelGroup.Groups.Count;
            if (bucketCount > 3)
            {
                summaries = viewModel.TheTable.TopLevelGroup.Groups[3].GetSummaries(viewModel.TheTable);
                summaryInt32Agg = summaries[index] as Int32AggregateSummary;

                viewModel.Lblbuk3 = summaryInt32Agg.Count.ToString();
            }
            else
                // Less than 3 buckets ...
                viewModel.Lblbuk3 = "###";

            if (bucketCount > 56)
            {
                summaries = viewModel.TheTable.TopLevelGroup.Groups[56].GetSummaries(viewModel.TheTable);
                summaryInt32Agg = summaries[index] as Int32AggregateSummary;
                viewModel.Lblbuk56 = summaryInt32Agg.Count.ToString();
            }
            else
                // Less than 56 buckets ...
                viewModel.Lblbuk56 = "###";
        }
    }
}

