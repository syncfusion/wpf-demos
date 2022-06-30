#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Controls.Gantt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace syncfusion.ganttdemos.wpf
{
    public class BuiltinZoomingViewModel : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public BuiltinZoomingViewModel()
        {
            _resourceCollection = this.GetResources();
            _taskCollection = this.GetData();
            _zoomFactorValue = 100;
        }

        private ObservableCollection<TaskDetails> _taskCollection;

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<TaskDetails> TaskCollection
        {
            get
            {
                return _taskCollection;
            }
            set
            {
                _taskCollection = value;
            }
        }

        private ObservableCollection<Resource> _resourceCollection;

        /// <summary>
        /// Gets or sets the gantt resources.
        /// </summary>
        /// <value>The gantt resources.</value>
        public ObservableCollection<Resource> ResourceCollection
        {
            get
            {
                return _resourceCollection;
            }
            set
            {
                _resourceCollection = value;
            }
        }

        private double _zoomFactorValue;

        /// <summary>
        /// Gets or sets the zoom factor value.
        /// </summary>
        /// <value>The zoom factor value.</value>
        public double ZoomFactorValue
        {
            get
            {
                return _zoomFactorValue;
            }
            set
            {
                _zoomFactorValue = value;
                RaisePropertyChanged("ZoomFactorValue");
            }
        }


        /// <summary>
        /// Gets the resources.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<Resource> GetResources()
        {
            ObservableCollection<Resource> Resources = new ObservableCollection<Resource>();

            Resources.Add(new Resource { ID = 1, Name = "R & D" });
            Resources.Add(new Resource { ID = 2, Name = "Analyzers" });
            Resources.Add(new Resource { ID = 3, Name = "Product Definer" });
            Resources.Add(new Resource { ID = 4, Name = "Risk Management" });
            Resources.Add(new Resource { ID = 5, Name = "Budgeting Team" });
            Resources.Add(new Resource { ID = 6, Name = "Developers" });
            Resources.Add(new Resource { ID = 7, Name = "Testers" });
            Resources.Add(new Resource { ID = 8, Name = "Reviewer" });

            return Resources;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<TaskDetails> GetData()
        {
            ObservableCollection<TaskDetails> Activities = new ObservableCollection<TaskDetails>();

            Activities.Add(new TaskDetails { StartDate = new DateTime(2010, 6, 2), FinishDate = new DateTime(2010, 6, 18), TaskName = "Analysing Market Scope of the Product", TaskId = 1 });

            ObservableCollection<IGanttTask> MarketAnalysis = new ObservableCollection<IGanttTask>();
            MarketAnalysis.Add(new TaskDetails { StartDate = new DateTime(2010, 6, 2), FinishDate = new DateTime(2010, 6, 6), TaskName = "Current Market Review", TaskId = 2 });
            MarketAnalysis.Add(new TaskDetails { StartDate = new DateTime(2010, 6, 6), FinishDate = new DateTime(2010, 6, 9), TaskName = "Establish milestone for future development", TaskId = 3 });
            MarketAnalysis.Add(new TaskDetails { StartDate = new DateTime(2010, 6, 9), FinishDate = new DateTime(2010, 6, 10), TaskName = "Establish goals", TaskId = 4 });
            MarketAnalysis.Add(new TaskDetails { StartDate = new DateTime(2010, 6, 10), FinishDate = new DateTime(2010, 6, 13), TaskName = "Sales, marketing and pricing plan", TaskId = 5 });
            MarketAnalysis.Add(new TaskDetails { StartDate = new DateTime(2010, 6, 11), FinishDate = new DateTime(2010, 6, 14), TaskName = "Define product goals and milestones", TaskId = 6 });
            MarketAnalysis.Add(new TaskDetails { StartDate = new DateTime(2010, 6, 12), FinishDate = new DateTime(2010, 6, 17), TaskName = "Organization status review", TaskId = 7 });
            MarketAnalysis.Add(new TaskDetails { StartDate = new DateTime(2010, 6, 18), FinishDate = new DateTime(2010, 6, 18), TaskName = "Market Scope of Product clarified", TaskId = 8 });
            ObservableCollection<Predecessor> mrkPredecessor = new ObservableCollection<Predecessor>();
            mrkPredecessor.Add(new Predecessor { GanttTaskIndex = 2, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            mrkPredecessor.Add(new Predecessor { GanttTaskIndex = 3, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            mrkPredecessor.Add(new Predecessor { GanttTaskIndex = 4, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            mrkPredecessor.Add(new Predecessor { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            mrkPredecessor.Add(new Predecessor { GanttTaskIndex = 6, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            mrkPredecessor.Add(new Predecessor { GanttTaskIndex = 7, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            MarketAnalysis[6].Predecessor = mrkPredecessor;

            MarketAnalysis[0].Resources.Add(this.ResourceCollection[0]);
            MarketAnalysis[1].Resources.Add(this.ResourceCollection[0]);
            MarketAnalysis[2].Resources.Add(this.ResourceCollection[0]);
            MarketAnalysis[3].Resources.Add(this.ResourceCollection[0]);
            MarketAnalysis[4].Resources.Add(this.ResourceCollection[0]);
            MarketAnalysis[5].Resources.Add(this.ResourceCollection[0]);
            Activities[0].Child = MarketAnalysis;


            Activities.Add(new TaskDetails { StartDate = new DateTime(2010, 6, 18), FinishDate = new DateTime(2010, 7, 14), TaskName = "Infrastructure for Product Planning", TaskId = 9 });
            ObservableCollection<IGanttTask> InfrastructureReq = new ObservableCollection<IGanttTask>();
            InfrastructureReq.Add(new TaskDetails { StartDate = new DateTime(2010, 6, 18), FinishDate = new DateTime(2010, 6, 24), TaskName = "Define procedure for qualifying ideas", TaskId = 10 });
            InfrastructureReq.Add(new TaskDetails { StartDate = new DateTime(2010, 6, 24), FinishDate = new DateTime(2010, 7, 7), TaskName = "Define process for idea sharing", TaskId = 11 });
            InfrastructureReq.Add(new TaskDetails { StartDate = new DateTime(2010, 7, 7), FinishDate = new DateTime(2010, 7, 14), TaskName = "Infrastructure for Product planning Complete", TaskId = 12 });
            InfrastructureReq[1].Predecessor.Add(new Predecessor { GanttTaskIndex = 10, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            InfrastructureReq[2].Predecessor.Add(new Predecessor { GanttTaskIndex = 11, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            InfrastructureReq[0].Resources.Add(this.ResourceCollection[0]);
            InfrastructureReq[1].Resources.Add(this.ResourceCollection[0]);
            InfrastructureReq[2].Resources.Add(this.ResourceCollection[0]);

            Activities[1].Child = InfrastructureReq;

            Activities.Add(new TaskDetails { StartDate = new DateTime(2010, 7, 14), FinishDate = new DateTime(2010, 8, 29), TaskName = "Product Definition Phase", TaskId = 13 });
            ObservableCollection<IGanttTask> Product = new ObservableCollection<IGanttTask>();
            Product.Add(new TaskDetails { StartDate = new DateTime(2010, 7, 14), FinishDate = new DateTime(2010, 7, 25), TaskName = "Identify product", TaskId = 14 });
            Product.Add(new TaskDetails { StartDate = new DateTime(2010, 7, 28), FinishDate = new DateTime(2010, 8, 1), TaskName = "Identify need for the product", TaskId = 15 });
            Product.Add(new TaskDetails { StartDate = new DateTime(2010, 8, 4), FinishDate = new DateTime(2010, 8, 8), TaskName = "Identify current trend for targets", TaskId = 16 });
            Product.Add(new TaskDetails { StartDate = new DateTime(2010, 8, 4), FinishDate = new DateTime(2010, 8, 29), TaskName = "Define product use and features", TaskId = 17 });
            Product.Add(new TaskDetails { StartDate = new DateTime(2010, 8, 4), FinishDate = new DateTime(2010, 8, 8), TaskName = "Identify competitor product", TaskId = 18 });
            Product.Add(new TaskDetails { StartDate = new DateTime(2010, 8, 29), FinishDate = new DateTime(2010, 8, 29), TaskName = "Product Definition Complete", TaskId = 19 });

            Product[1].Predecessor.Add(new Predecessor { GanttTaskIndex = 14, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Product[2].Predecessor.Add(new Predecessor { GanttTaskIndex = 15, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Product[3].Predecessor.Add(new Predecessor { GanttTaskIndex = 16, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Product[5].Predecessor.Add(new Predecessor { GanttTaskIndex = 16, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Product[5].Predecessor.Add(new Predecessor { GanttTaskIndex = 17, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Product[5].Predecessor.Add(new Predecessor { GanttTaskIndex = 18, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            Product[0].Resources.Add(this.ResourceCollection[2]);
            Product[1].Resources.Add(this.ResourceCollection[2]);
            Product[2].Resources.Add(this.ResourceCollection[2]);
            Product[3].Resources.Add(this.ResourceCollection[2]);
            Product[4].Resources.Add(this.ResourceCollection[2]);

            Activities[2].Child = Product;

            Activities.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 2), FinishDate = new DateTime(2010, 9, 10), TaskName = "Analysing Customer Requirement", TaskId = 20 });
            ObservableCollection<IGanttTask> Customer = new ObservableCollection<IGanttTask>();
            Customer.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 2), FinishDate = new DateTime(2010, 9, 4), TaskName = "Identify Consumer of Products", TaskId = 21 });
            Customer.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 3), FinishDate = new DateTime(2010, 9, 6), TaskName = "Identify Customer Requirement", TaskId = 22 });
            Customer.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 5), FinishDate = new DateTime(2010, 9, 8), TaskName = "Analysing Customer Requiremet with current plan", TaskId = 23 });
            Customer.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 7), FinishDate = new DateTime(2010, 9, 10), TaskName = "Design based on Customer Requirement", TaskId = 24 });
            Customer.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 10), FinishDate = new DateTime(2010, 9, 10), TaskName = "Customer Requirement Analysis Complete", TaskId = 25 });
            Customer[1].Predecessor.Add(new Predecessor { GanttTaskIndex = 21, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Customer[2].Predecessor.Add(new Predecessor { GanttTaskIndex = 22, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Customer[3].Predecessor.Add(new Predecessor { GanttTaskIndex = 23, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Customer[4].Predecessor.Add(new Predecessor { GanttTaskIndex = 24, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            Customer[0].Resources.Add(this.ResourceCollection[1]);
            Customer[1].Resources.Add(this.ResourceCollection[1]);
            Customer[2].Resources.Add(this.ResourceCollection[1]);
            Customer[3].Resources.Add(this.ResourceCollection[1]);

            Activities[3].Child = Customer;

            Activities.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 2), FinishDate = new DateTime(2010, 10, 10), TaskName = "Competitor Analysis", TaskId = 26 });
            ObservableCollection<IGanttTask> Competitor = new ObservableCollection<IGanttTask>();
            Competitor.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 2), FinishDate = new DateTime(2010, 9, 13), TaskName = "Define competitor with similar Product", TaskId = 27 });
            Competitor.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 13), FinishDate = new DateTime(2010, 9, 20), TaskName = "Define competitive advantage", TaskId = 28 });
            Competitor.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 22), FinishDate = new DateTime(2010, 9, 27), TaskName = "Identify competitive features", TaskId = 29 });
            Competitor.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 29), FinishDate = new DateTime(2010, 10, 10), TaskName = "Define how to build competitive features", TaskId = 30 });
            Competitor[1].Predecessor.Add(new Predecessor { GanttTaskIndex = 27, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Competitor[2].Predecessor.Add(new Predecessor { GanttTaskIndex = 28, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Competitor[3].Predecessor.Add(new Predecessor { GanttTaskIndex = 29, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            Competitor[0].Resources.Add(this.ResourceCollection[1]);
            Competitor[1].Resources.Add(this.ResourceCollection[1]);
            Competitor[2].Resources.Add(this.ResourceCollection[1]);
            Activities[4].Child = Competitor;

            Activities.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 9), FinishDate = new DateTime(2010, 9, 20), TaskName = "Defining Sucess Measure", TaskId = 31 });
            ObservableCollection<IGanttTask> Measure = new ObservableCollection<IGanttTask>();
            Measure.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 2), FinishDate = new DateTime(2010, 9, 6), TaskName = "Identify Risks", TaskId = 32 });
            Measure.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 2), FinishDate = new DateTime(2010, 9, 6), TaskName = "Define Key success measures", TaskId = 33 });
            Measure.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 7), FinishDate = new DateTime(2010, 9, 13), TaskName = "Define strategy to address risks", TaskId = 34 });
            Measure.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 13), FinishDate = new DateTime(2010, 9, 20), TaskName = "Define strategy to meet market position", TaskId = 35 });
            Measure.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 20), FinishDate = new DateTime(2010, 9, 20), TaskName = "Success Measure Defined", TaskId = 36 });

            Measure[1].Predecessor.Add(new Predecessor { GanttTaskIndex = 32, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Measure[4].Predecessor.Add(new Predecessor { GanttTaskIndex = 33, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Measure[4].Predecessor.Add(new Predecessor { GanttTaskIndex = 34, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Measure[4].Predecessor.Add(new Predecessor { GanttTaskIndex = 35, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            Measure[0].Resources.Add(this.ResourceCollection[3]);
            Measure[1].Resources.Add(this.ResourceCollection[3]);
            Measure[2].Resources.Add(this.ResourceCollection[3]);
            Measure[3].Resources.Add(this.ResourceCollection[3]);
            Measure[4].Resources.Add(this.ResourceCollection[3]);

            Activities[5].Child = Measure;

            Activities.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 23), FinishDate = new DateTime(2010, 10, 17), TaskName = "Defining Team to Develop", TaskId = 37 });
            ObservableCollection<IGanttTask> Team = new ObservableCollection<IGanttTask>();
            Team.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 23), FinishDate = new DateTime(2010, 9, 27), TaskName = "Define successful team components for success", TaskId = 38 });
            Team.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 30), FinishDate = new DateTime(2010, 10, 3), TaskName = "Identify Key qualities needed to develop, produce and grow", TaskId = 39 });
            Team.Add(new TaskDetails { StartDate = new DateTime(2010, 10, 6), FinishDate = new DateTime(2010, 10, 10), TaskName = "Define current team members", TaskId = 40 });
            Team.Add(new TaskDetails { StartDate = new DateTime(2010, 10, 13), FinishDate = new DateTime(2010, 10, 17), TaskName = "Identify and address gaps", TaskId = 41 });
            Team.Add(new TaskDetails { StartDate = new DateTime(2010, 10, 17), FinishDate = new DateTime(2010, 10, 17), TaskName = "Team Defined", TaskId = 42 });

            Team[1].Predecessor.Add(new Predecessor { GanttTaskIndex = 38, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Team[2].Predecessor.Add(new Predecessor { GanttTaskIndex = 39, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Team[3].Predecessor.Add(new Predecessor { GanttTaskIndex = 40, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Team[4].Predecessor.Add(new Predecessor { GanttTaskIndex = 41, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            Activities[6].Child = Team;

            Activities.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 2), FinishDate = new DateTime(2010, 9, 24), TaskName = "Budgeting in the Product", TaskId = 43 });
            ObservableCollection<IGanttTask> Budget = new ObservableCollection<IGanttTask>();
            Budget.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 2), FinishDate = new DateTime(2010, 9, 3), TaskName = "Define financial metrics of product", TaskId = 44 });
            Budget.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 3), FinishDate = new DateTime(2010, 9, 13), TaskName = "Estimate cost need to develop", TaskId = 45 });
            Budget.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 13), FinishDate = new DateTime(2010, 9, 15), TaskName = "Estimate time to develop", TaskId = 46 });
            Budget.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 15), FinishDate = new DateTime(2010, 9, 20), TaskName = "Analyse resource cost", TaskId = 47 });
            Budget.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 20), FinishDate = new DateTime(2010, 9, 24), TaskName = "Define financial plan of Product", TaskId = 48 });
            Budget.Add(new TaskDetails { StartDate = new DateTime(2010, 9, 24), FinishDate = new DateTime(2010, 9, 24), TaskName = "Product Budget defined", TaskId = 49 });

            Budget[1].Predecessor.Add(new Predecessor { GanttTaskIndex = 44, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Budget[2].Predecessor.Add(new Predecessor { GanttTaskIndex = 45, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Budget[3].Predecessor.Add(new Predecessor { GanttTaskIndex = 46, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Budget[4].Predecessor.Add(new Predecessor { GanttTaskIndex = 47, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Budget[5].Predecessor.Add(new Predecessor { GanttTaskIndex = 48, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            Budget[0].Resources.Add(this.ResourceCollection[4]);
            Budget[1].Resources.Add(this.ResourceCollection[4]);
            Budget[2].Resources.Add(this.ResourceCollection[4]);
            Budget[3].Resources.Add(this.ResourceCollection[4]);
            Budget[4].Resources.Add(this.ResourceCollection[4]);

            Activities[7].Child = Budget;

            Activities.Add(new TaskDetails { StartDate = new DateTime(2010, 10, 20), FinishDate = new DateTime(2010, 11, 10), TaskName = "Product Development", TaskId = 50 });
            ObservableCollection<IGanttTask> Development = new ObservableCollection<IGanttTask>();
            Development.Add(new TaskDetails { StartDate = new DateTime(2010, 10, 20), FinishDate = new DateTime(2010, 10, 30), TaskName = "Implementation Phase 1", TaskId = 51 });
            Development.Add(new TaskDetails { StartDate = new DateTime(2010, 10, 30), FinishDate = new DateTime(2010, 11, 10), TaskName = "Implementation Phase 2", TaskId = 52 });
            Development.Add(new TaskDetails { StartDate = new DateTime(2010, 11, 10), FinishDate = new DateTime(2010, 11, 10), TaskName = "Product Developed", TaskId = 53 });

            Development[1].Predecessor.Add(new Predecessor { GanttTaskIndex = 51, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Development[2].Predecessor.Add(new Predecessor { GanttTaskIndex = 52, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            Development[0].Resources.Add(this.ResourceCollection[5]);
            Development[1].Resources.Add(this.ResourceCollection[5]);
            Development[2].Resources.Add(this.ResourceCollection[5]);
            Activities[8].Child = Development;

            Activities.Add(new TaskDetails { StartDate = new DateTime(2010, 11, 8), FinishDate = new DateTime(2010, 11, 13), TaskName = "Product Review", TaskId = 54 });
            Activities[9].Child.Add(new TaskDetails { StartDate = new DateTime(2010, 11, 8), FinishDate = new DateTime(2010, 11, 10), TaskName = "Product Techincal Review", TaskId = 55 });
            Activities[9].Child.Add(new TaskDetails { StartDate = new DateTime(2010, 11, 9), FinishDate = new DateTime(2010, 11, 13), TaskName = "Product Cost Review", TaskId = 56 });

            Activities.Add(new TaskDetails { StartDate = new DateTime(2010, 11, 15), FinishDate = new DateTime(2010, 11, 30), TaskName = "Beta Testing", TaskId = 57 });
            ObservableCollection<IGanttTask> Testing = new ObservableCollection<IGanttTask>();
            Testing.Add((new TaskDetails { StartDate = new DateTime(2010, 11, 15), FinishDate = new DateTime(2010, 11, 17), TaskName = "Disseminate completed product", TaskId = 58 }));
            Testing.Add((new TaskDetails { StartDate = new DateTime(2010, 11, 18), FinishDate = new DateTime(2010, 11, 20), TaskName = "Obtain feedback", TaskId = 59 }));
            Testing.Add((new TaskDetails { StartDate = new DateTime(2010, 11, 20), FinishDate = new DateTime(2010, 11, 25), TaskName = "Modification", TaskId = 60 }));
            Testing.Add((new TaskDetails { StartDate = new DateTime(2010, 11, 24), FinishDate = new DateTime(2010, 11, 30), TaskName = "Test", TaskId = 61 }));
            Testing.Add((new TaskDetails { StartDate = new DateTime(2010, 11, 30), FinishDate = new DateTime(2010, 11, 30), TaskName = "Testing Completed", TaskId = 62 }));

            Testing[1].Predecessor.Add(new Predecessor { GanttTaskIndex = 58, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Testing[2].Predecessor.Add(new Predecessor { GanttTaskIndex = 59, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Testing[3].Predecessor.Add(new Predecessor { GanttTaskIndex = 60, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            Testing[4].Predecessor.Add(new Predecessor { GanttTaskIndex = 61, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            Testing[0].Resources.Add(this.ResourceCollection[6]);
            Testing[1].Resources.Add(this.ResourceCollection[6]);
            Testing[2].Resources.Add(this.ResourceCollection[6]);
            Testing[3].Resources.Add(this.ResourceCollection[6]);
            Testing[4].Resources.Add(this.ResourceCollection[6]);
            Activities[10].Child = Testing;

            Activities.Add(new TaskDetails { StartDate = new DateTime(2010, 11, 25), FinishDate = new DateTime(2010, 12, 06), TaskName = "Post Product Review", TaskId = 63 });
            ObservableCollection<IGanttTask> PostReview = new ObservableCollection<IGanttTask>();
            PostReview.Add((new TaskDetails { StartDate = new DateTime(2010, 11, 25), FinishDate = new DateTime(2010, 11, 27), TaskName = "Finalize cost analysis", TaskId = 64 }));
            PostReview.Add((new TaskDetails { StartDate = new DateTime(2010, 11, 27), FinishDate = new DateTime(2010, 11, 28), TaskName = "Analyze performance", TaskId = 65 }));
            PostReview.Add((new TaskDetails { StartDate = new DateTime(2010, 11, 29), FinishDate = new DateTime(2010, 12, 2), TaskName = "Archive files", TaskId = 66 }));
            PostReview.Add((new TaskDetails { StartDate = new DateTime(2010, 12, 2), FinishDate = new DateTime(2010, 12, 4), TaskName = "Document lessons learned", TaskId = 67 }));
            PostReview.Add((new TaskDetails { StartDate = new DateTime(2010, 12, 4), FinishDate = new DateTime(2010, 12, 6), TaskName = "Distribute to team members", TaskId = 68 }));
            PostReview.Add((new TaskDetails { StartDate = new DateTime(2010, 12, 6), FinishDate = new DateTime(2010, 12, 6), TaskName = "Post-project review complete", TaskId = 69 }));

            PostReview[1].Predecessor.Add(new Predecessor { GanttTaskIndex = 64, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            PostReview[2].Predecessor.Add(new Predecessor { GanttTaskIndex = 65, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            PostReview[3].Predecessor.Add(new Predecessor { GanttTaskIndex = 66, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            PostReview[4].Predecessor.Add(new Predecessor { GanttTaskIndex = 67, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            PostReview[5].Predecessor.Add(new Predecessor { GanttTaskIndex = 68, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            PostReview[0].Resources.Add(this.ResourceCollection[7]);
            PostReview[1].Resources.Add(this.ResourceCollection[7]);
            PostReview[2].Resources.Add(this.ResourceCollection[7]);
            PostReview[3].Resources.Add(this.ResourceCollection[7]);
            PostReview[4].Resources.Add(this.ResourceCollection[7]);

            Activities[11].Child = PostReview;

            Activities.Add(new TaskDetails { StartDate = new DateTime(2010, 12, 10), FinishDate = new DateTime(2010, 12, 10), TaskName = "Product Released Successfully", TaskId = 70 });

            return Activities;

        }
    }
}
