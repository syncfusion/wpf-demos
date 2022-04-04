#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls.Gantt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.ganttdemos.wpf.ViewModel
{
    public class StatisticsViewModel 
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsViewModel"/> class.
        /// </summary>
        /// <param name="prjInfo">The PRJ info.</param>
        public StatisticsViewModel(ProjectInfo prjInfo)
        {
            _projectInformation = prjInfo;
            this.SetCostExpenditure(prjInfo);
            this.SetDurationExpenditure(prjInfo);
        }

        private ProjectInfo _projectInformation;

        /// <summary>
        /// Gets the project information.
        /// </summary>
        /// <value>The project information.</value>
        public ProjectInfo ProjectInformation
        {
            get
            {
                return _projectInformation;
            }
        }

        /// <summary>
        /// Gets or sets the cost expenditure.
        /// </summary>
        /// <value>The cost expenditure.</value>
        public IList<ProjectStatisticsModel> CostExpenditure
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the duration expenditure.
        /// </summary>
        /// <value>The duration expenditure.</value>
        public IList<ProjectStatisticsModel> DurationExpenditure
        {
            get;
            set;
        }

        /// <summary>
        /// Sets the cost expenditure.
        /// </summary>
        /// <param name="prjInfo">The PRJ info.</param>
        private void SetCostExpenditure(ProjectInfo prjInfo)
        {
            this.CostExpenditure = new List<ProjectStatisticsModel>();
            var temp = Math.Round(((Math.Round(prjInfo.ActualCost) / (Math.Round(prjInfo.Cost))) * 100), 2);
            CostExpenditure.Add(new ProjectStatisticsModel() { Name = " Spent ", Amount = temp });
            CostExpenditure.Add(new ProjectStatisticsModel() { Name = " Remaining ", Amount = 100 - temp });
        }

        /// <summary>
        /// Sets the duration expenditure.
        /// </summary>
        /// <param name="prjInfo">The PRJ info.</param>
        private void SetDurationExpenditure(ProjectInfo prjInfo)
        {
            this.DurationExpenditure = new List<ProjectStatisticsModel>();
            var t = Math.Round(((Math.Round(prjInfo.ActualDuration.TotalDays, 2) / (Math.Round(prjInfo.Duration.TotalDays))) * 100), 2);
            DurationExpenditure.Add(new ProjectStatisticsModel() { Name = " Completed ", Amount = t });
            DurationExpenditure.Add(new ProjectStatisticsModel() { Name = " Remaining ", Amount = 100 - t });
        }

        internal void Dispose()
        {
            foreach(var cost in CostExpenditure)
            {
                cost.Dispose();
            }

            foreach (var duration in DurationExpenditure)
            {
                duration.Dispose();
            }
        }
    }
}
