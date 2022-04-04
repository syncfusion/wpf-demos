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
    public class ProjectStatisticsViewModel 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GanttViewModel"/> class.
        /// </summary>
        public ProjectStatisticsViewModel()
        {
            _taskDetails = GetData();
        }

        private ObservableCollection<ProjectStatisticsModel> _taskDetails;

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<ProjectStatisticsModel> TaskDetails
        {
            get
            {
                return _taskDetails;
            }
            set
            {
                _taskDetails = value;
            }
        }


        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<ProjectStatisticsModel> GetData()
        {
            var data = new ObservableCollection<ProjectStatisticsModel>();

            // Collection to Strore the Required Resources.
            ObservableCollection<Resource> ResidentialConstructionResources = new ObservableCollection<Resource>();
            ResidentialConstructionResources = GetResources();

            // Adding Tasks

            data.Add(new ProjectStatisticsModel() { Id = 1, Name = "Residential Construction (2500 sq.ft)", StDate = new DateTime(2012, 3, 1), EndDate = new DateTime(2012, 3, 15), BaselineStart = new DateTime(2012, 3, 1), BaselineEnd = new DateTime(2012, 3, 14), Complete = 0d, Cost = 500, BaselineCost = 833d, });

            data[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 2, Name = "General Considerations", StDate = new DateTime(2012, 7, 3), EndDate = new DateTime(2012, 7, 14), BaselineStart = new DateTime(2012, 7, 3), BaselineEnd = new DateTime(2012, 7, 14), Complete = 0d, Cost = 89, BaselineCost = 833d, });

            data[0].ChildTask[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 3, Name = "Finalize and Approve Plans", StDate = new DateTime(2012, 3, 1), EndDate = new DateTime(2012, 3, 15), BaselineStart = new DateTime(2012, 3, 2), BaselineEnd = new DateTime(2012, 3, 16), Complete = 0d, Cost = 500, BaselineCost = 833d, });
            data[0].ChildTask[0].ChildTask[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 4, Name = "Review and Finalize Site Plans", StDate = new DateTime(2012, 3, 1), EndDate = new DateTime(2012, 3, 20), BaselineStart = new DateTime(2012, 3, 1), BaselineEnd = new DateTime(2012, 3, 20), Complete = 0d, Cost = 500, BaselineCost = 833d, });
            data[0].ChildTask[0].ChildTask[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 5, Name = "Sign contract and Proceed", StDate = new DateTime(2012, 3, 20), EndDate = new DateTime(2012, 3, 22), BaselineStart = new DateTime(2012, 3, 19), BaselineEnd = new DateTime(2012, 3, 21), Complete = 0d, Cost = 500, BaselineCost = 833d, });

            data[0].ChildTask[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 6, Name = "Contracts and Agreements", StDate = new DateTime(2012, 3, 22), EndDate = new DateTime(2012, 3, 22), BaselineStart = new DateTime(2012, 3, 20), BaselineEnd = new DateTime(2012, 3, 21), Complete = 0d, Cost = 20d, BaselineCost = 14 });
            data[0].ChildTask[0].ChildTask[1].ChildTask.Add((new ProjectStatisticsModel() { Id = 7, Name = "Lot Sale Agreement", StDate = new DateTime(2012, 3, 22), EndDate = new DateTime(2012, 3, 22), BaselineStart = new DateTime(2012, 3, 20), BaselineEnd = new DateTime(2012, 3, 20), Complete = 0d, Cost = 20d, BaselineCost = 14 }));
            data[0].ChildTask[0].ChildTask[1].ChildTask.Add((new ProjectStatisticsModel() { Id = 8, Name = "Construction Agreement", StDate = new DateTime(2012, 3, 22), EndDate = new DateTime(2012, 3, 22), BaselineStart = new DateTime(2012, 3, 21), BaselineEnd = new DateTime(2012, 3, 21), Complete = 0d, Cost = 33d, BaselineCost = 12 }));
            data[0].ChildTask[0].ChildTask[1].ChildTask.Add((new ProjectStatisticsModel() { Id = 9, Name = "Contract Specifications", StDate = new DateTime(2012, 3, 22), EndDate = new DateTime(2012, 3, 22), BaselineStart = new DateTime(2012, 3, 20), BaselineEnd = new DateTime(2012, 3, 20), Complete = 0d, Cost = 30d, BaselineCost = 50 }));
            data[0].ChildTask[0].ChildTask[1].ChildTask.Add((new ProjectStatisticsModel() { Id = 10, Name = "Contract Site Plan", StDate = new DateTime(2012, 3, 22), EndDate = new DateTime(2012, 3, 22), BaselineStart = new DateTime(2012, 3, 20), BaselineEnd = new DateTime(2012, 3, 20), Complete = 0d, Cost = 360d, BaselineCost = 100 }));
            data[0].ChildTask[0].ChildTask[1].ChildTask.Add((new ProjectStatisticsModel() { Id = 11, Name = "Financing", StDate = new DateTime(2012, 3, 22), EndDate = new DateTime(2012, 3, 22), BaselineStart = new DateTime(2012, 3, 20), BaselineEnd = new DateTime(2012, 3, 20), Complete = 0d, Cost = 39d, BaselineCost = 16 }));

            data[0].ChildTask[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 12, Name = "Apply Permits", StDate = new DateTime(2012, 3, 23), EndDate = new DateTime(2012, 3, 24), BaselineStart = new DateTime(2012, 3, 22), BaselineEnd = new DateTime(2012, 3, 23), Complete = 0d, Cost = 53d, BaselineCost = 65 });
            data[0].ChildTask[0].ChildTask[2].ChildTask.Add((new ProjectStatisticsModel() { Id = 13, Name = "Foundation Permit", StDate = new DateTime(2012, 3, 23), EndDate = new DateTime(2012, 3, 24), BaselineStart = new DateTime(2012, 3, 22), BaselineEnd = new DateTime(2012, 3, 23), Complete = 0d, Cost = 53d, BaselineCost = 65 }));
            data[0].ChildTask[0].ChildTask[2].ChildTask.Add((new ProjectStatisticsModel() { Id = 14, Name = "Electrical Permit", StDate = new DateTime(2012, 3, 24), EndDate = new DateTime(2012, 3, 25), BaselineStart = new DateTime(2012, 3, 24), BaselineEnd = new DateTime(2012, 3, 25), Complete = 0d, Cost = 23d, BaselineCost = 34 }));
            data[0].ChildTask[0].ChildTask[2].ChildTask.Add((new ProjectStatisticsModel() { Id = 15, Name = "Plumbing Permit", StDate = new DateTime(2012, 3, 25), EndDate = new DateTime(2012, 3, 26), BaselineStart = new DateTime(2012, 3, 25), BaselineEnd = new DateTime(2012, 3, 26), Complete = 0d, Cost = 63d, BaselineCost = 53 }));

            data[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 16, Name = "Site Work", StDate = new DateTime(2012, 3, 26), EndDate = new DateTime(2012, 3, 27), BaselineStart = new DateTime(2012, 3, 26), BaselineEnd = new DateTime(2012, 3, 27), Complete = 0d, Cost = 2000d, BaselineCost = 1000 });
            data[0].ChildTask[1].ChildTask.Add(new ProjectStatisticsModel() { Id = 17, Name = "Clear Lot", StDate = new DateTime(2012, 3, 26), EndDate = new DateTime(2012, 3, 27), BaselineStart = new DateTime(2012, 3, 27), BaselineEnd = new DateTime(2012, 3, 28), Complete = 0d, Cost = 2000d, BaselineCost = 1000 });
            data[0].ChildTask[1].ChildTask.Add(new ProjectStatisticsModel() { Id = 18, Name = "Strip Topsoil", StDate = new DateTime(2012, 3, 27), EndDate = new DateTime(2012, 3, 28), BaselineStart = new DateTime(2012, 3, 27), BaselineEnd = new DateTime(2012, 3, 28), Complete = 0d, Cost = 1200d, BaselineCost = 800 });
            data[0].ChildTask[1].ChildTask.Add(new ProjectStatisticsModel() { Id = 19, Name = "Installing Temporary requirements", StDate = new DateTime(2012, 3, 28), EndDate = new DateTime(2012, 3, 29), BaselineStart = new DateTime(2012, 3, 30), BaselineEnd = new DateTime(2012, 4, 2), Complete = 0d, Cost = 354d, BaselineCost = 230 });

            data[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 20, Name = "Foundation", StDate = new DateTime(2012, 3, 29), EndDate = new DateTime(2012, 4, 2), BaselineStart = new DateTime(2012, 3, 29), BaselineEnd = new DateTime(2012, 4, 2), Complete = 0d, Cost = 899, BaselineCost = 833d, });
            data[0].ChildTask[2].ChildTask.Add(new ProjectStatisticsModel() { Id = 21, Name = "Excavate for foundation", StDate = new DateTime(2012, 3, 29), EndDate = new DateTime(2012, 4, 2), BaselineStart = new DateTime(2012, 3, 29), BaselineEnd = new DateTime(2012, 4, 2), Complete = 0d, Cost = 899, BaselineCost = 833d, });
            data[0].ChildTask[2].ChildTask.Add(new ProjectStatisticsModel() { Id = 22, Name = "Building Basement Walls", StDate = new DateTime(2012, 4, 3), EndDate = new DateTime(2012, 4, 8), BaselineStart = new DateTime(2012, 4, 3), BaselineEnd = new DateTime(2012, 4, 8), Complete = 0d, Cost = 889, BaselineCost = 803d, });
            data[0].ChildTask[2].ChildTask.Add(new ProjectStatisticsModel() { Id = 23, Name = "Foundation inspection", StDate = new DateTime(2012, 4, 8), EndDate = new DateTime(2012, 4, 10), BaselineStart = new DateTime(2012, 4, 7), BaselineEnd = new DateTime(2012, 4, 9), Complete = 0d, Cost = 8, BaselineCost = 8d, });
            data[0].ChildTask[2].ChildTask.Add(new ProjectStatisticsModel() { Id = 24, Name = "Finishing Foundation", StDate = new DateTime(2012, 4, 10), EndDate = new DateTime(2012, 4, 17), BaselineStart = new DateTime(2012, 4, 10), BaselineEnd = new DateTime(2012, 4, 17), Complete = 0d, Cost = 0, BaselineCost = 8d, });

            data[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 25, Name = "Framing", StDate = new DateTime(2012, 4, 18), EndDate = new DateTime(2012, 4, 24), BaselineStart = new DateTime(2012, 4, 18), BaselineEnd = new DateTime(2012, 4, 24), Complete = 0d, Cost = 890, BaselineCost = 803d, });
            data[0].ChildTask[3].ChildTask.Add(new ProjectStatisticsModel() { Id = 26, Name = "First Floor Framing", StDate = new DateTime(2012, 4, 18), EndDate = new DateTime(2012, 4, 24), BaselineStart = new DateTime(2012, 4, 17), BaselineEnd = new DateTime(2012, 4, 23), Complete = 0d, Cost = 890, BaselineCost = 803d, });
            data[0].ChildTask[3].ChildTask.Add(new ProjectStatisticsModel() { Id = 27, Name = "Second Floor Framing", StDate = new DateTime(2012, 4, 24), EndDate = new DateTime(2012, 5, 3), BaselineStart = new DateTime(2012, 4, 24), BaselineEnd = new DateTime(2012, 5, 3), Complete = 0d, Cost = 789, BaselineCost = 898d, });
            data[0].ChildTask[3].ChildTask.Add(new ProjectStatisticsModel() { Id = 28, Name = "Framing Roof", StDate = new DateTime(2012, 5, 3), EndDate = new DateTime(2012, 5, 7), BaselineStart = new DateTime(2012, 5, 4), BaselineEnd = new DateTime(2012, 5, 8), Complete = 0d, Cost = 780, BaselineCost = 833d, });
            data[0].ChildTask[3].ChildTask.Add(new ProjectStatisticsModel() { Id = 29, Name = "Framing Inspection", StDate = new DateTime(2012, 5, 7), EndDate = new DateTime(2012, 5, 8), BaselineStart = new DateTime(2012, 5, 7), BaselineEnd = new DateTime(2012, 5, 8), Complete = 0d, Cost = 5, BaselineCost = 8d, });

            data[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 30, Name = "Dry In", StDate = new DateTime(2012, 5, 8), EndDate = new DateTime(2012, 5, 14), BaselineStart = new DateTime(2012, 5, 8), BaselineEnd = new DateTime(2012, 5, 15), Complete = 0d, Cost = 232, BaselineCost = 323d, });
            data[0].ChildTask[4].ChildTask.Add(new ProjectStatisticsModel() { Id = 31, Name = "Installing Sheathing for floors", StDate = new DateTime(2012, 5, 8), EndDate = new DateTime(2012, 5, 14), BaselineStart = new DateTime(2012, 5, 9), BaselineEnd = new DateTime(2012, 5, 15), Complete = 0d, Cost = 232, BaselineCost = 323d, });
            data[0].ChildTask[4].ChildTask.Add(new ProjectStatisticsModel() { Id = 32, Name = "Installing Windows", StDate = new DateTime(2012, 5, 14), EndDate = new DateTime(2012, 5, 25), BaselineStart = new DateTime(2012, 5, 14), BaselineEnd = new DateTime(2012, 5, 25), Complete = 0d, Cost = 325, BaselineCost = 452d, });
            data[0].ChildTask[4].ChildTask.Add(new ProjectStatisticsModel() { Id = 33, Name = "Installing Sheathing for Roof", StDate = new DateTime(2012, 5, 25), EndDate = new DateTime(2012, 5, 30), BaselineStart = new DateTime(2012, 5, 23), BaselineEnd = new DateTime(2012, 5, 30), Complete = 0d, Cost = 82, BaselineCost = 83d, });

            data[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 34, Name = "Exterior Finishing", StDate = new DateTime(2012, 5, 31), EndDate = new DateTime(2012, 6, 12), BaselineStart = new DateTime(2012, 5, 31), BaselineEnd = new DateTime(2012, 6, 12), Complete = 0d, Cost = 463, BaselineCost = 633d, });
            data[0].ChildTask[5].ChildTask.Add(new ProjectStatisticsModel() { Id = 35, Name = "Exterior Trimming", StDate = new DateTime(2012, 5, 31), EndDate = new DateTime(2012, 6, 12), BaselineStart = new DateTime(2012, 5, 31), BaselineEnd = new DateTime(2012, 6, 12), Complete = 0d, Cost = 463, BaselineCost = 633d, });
            data[0].ChildTask[5].ChildTask.Add(new ProjectStatisticsModel() { Id = 36, Name = "Completing Exterior Bricks", StDate = new DateTime(2012, 6, 12), EndDate = new DateTime(2012, 6, 17), BaselineStart = new DateTime(2012, 6, 12), BaselineEnd = new DateTime(2012, 6, 17), Complete = 0d, Cost = 234, BaselineCost = 333d, });

            data[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 37, Name = "Interior Finishing", StDate = new DateTime(2012, 6, 17), EndDate = new DateTime(2012, 6, 19), BaselineStart = new DateTime(2012, 6, 17), BaselineEnd = new DateTime(2012, 6, 19), Complete = 0d, Cost = 43, BaselineCost = 33d, });

            data[0].ChildTask[6].ChildTask.Add(new ProjectStatisticsModel() { Id = 38, Name = "Installing Insulation", StDate = new DateTime(2012, 6, 17), EndDate = new DateTime(2012, 6, 19), BaselineStart = new DateTime(2012, 6, 17), BaselineEnd = new DateTime(2012, 6, 19), Complete = 0d, Cost = 43, BaselineCost = 33d, });
            data[0].ChildTask[6].ChildTask[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 39, Name = "Install Floor Insulation", StDate = new DateTime(2012, 6, 17), EndDate = new DateTime(2012, 6, 19), BaselineStart = new DateTime(2012, 6, 17), BaselineEnd = new DateTime(2012, 6, 19), Complete = 0d, Cost = 43, BaselineCost = 33d, });
            data[0].ChildTask[6].ChildTask[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 40, Name = "Install Wall Insulation", StDate = new DateTime(2012, 6, 19), EndDate = new DateTime(2012, 6, 21), BaselineStart = new DateTime(2012, 6, 19), BaselineEnd = new DateTime(2012, 6, 21), Complete = 0d, Cost = 53, BaselineCost = 83d, });
            data[0].ChildTask[6].ChildTask[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 41, Name = "Install Ceiling Insulation", StDate = new DateTime(2012, 6, 21), EndDate = new DateTime(2012, 6, 22), BaselineStart = new DateTime(2012, 6, 21), BaselineEnd = new DateTime(2012, 6, 22), Complete = 0d, Cost = 89, BaselineCost = 83d, });


            data[0].ChildTask[6].ChildTask.Add(new ProjectStatisticsModel() { Id = 42, Name = "Painting and Wallpaper", StDate = new DateTime(2012, 6, 22), EndDate = new DateTime(2012, 6, 23), BaselineStart = new DateTime(2012, 6, 22), BaselineEnd = new DateTime(2012, 6, 23), Complete = 0d, Cost = 453, BaselineCost = 563, });
            data[0].ChildTask[6].ChildTask[1].ChildTask.Add(new ProjectStatisticsModel() { Id = 43, Name = "Painting all Interior", StDate = new DateTime(2012, 6, 22), EndDate = new DateTime(2012, 6, 23), BaselineStart = new DateTime(2012, 6, 22), BaselineEnd = new DateTime(2012, 6, 23), Complete = 0d, Cost = 453, BaselineCost = 563, });
            data[0].ChildTask[6].ChildTask[1].ChildTask.Add(new ProjectStatisticsModel() { Id = 44, Name = "Painting all Exterior", StDate = new DateTime(2012, 6, 23), EndDate = new DateTime(2012, 6, 25), BaselineStart = new DateTime(2012, 6, 23), BaselineEnd = new DateTime(2012, 6, 25), Complete = 0d, Cost = 352, BaselineCost = 342, });
            data[0].ChildTask[6].ChildTask[1].ChildTask.Add(new ProjectStatisticsModel() { Id = 45, Name = "Additional Trimming Work", StDate = new DateTime(2012, 6, 25), EndDate = new DateTime(2012, 6, 27), BaselineStart = new DateTime(2012, 6, 25), BaselineEnd = new DateTime(2012, 6, 27), Complete = 0d, Cost = 32, BaselineCost = 50, });

            data[0].ChildTask[6].ChildTask.Add(new ProjectStatisticsModel() { Id = 46, Name = "Finishing Plumbing", StDate = new DateTime(2012, 6, 27), EndDate = new DateTime(2012, 6, 29), BaselineStart = new DateTime(2012, 6, 27), BaselineEnd = new DateTime(2012, 6, 29), Complete = 0d, Cost = 424, BaselineCost = 423, });
            data[0].ChildTask[6].ChildTask[2].ChildTask.Add(new ProjectStatisticsModel() { Id = 47, Name = "First floor Plumbing", StDate = new DateTime(2012, 6, 27), EndDate = new DateTime(2012, 6, 29), BaselineStart = new DateTime(2012, 6, 27), BaselineEnd = new DateTime(2012, 6, 29), Complete = 0d, Cost = 424, BaselineCost = 423, });
            data[0].ChildTask[6].ChildTask[2].ChildTask.Add(new ProjectStatisticsModel() { Id = 48, Name = "Second floor plumbing", StDate = new DateTime(2012, 6, 29), EndDate = new DateTime(2012, 7, 1), BaselineStart = new DateTime(2012, 6, 29), BaselineEnd = new DateTime(2012, 7, 1), Complete = 0d, Cost = 234, BaselineCost = 324, });
            data[0].ChildTask[6].ChildTask[2].ChildTask.Add(new ProjectStatisticsModel() { Id = 49, Name = "Inspecting Plumbing", StDate = new DateTime(2012, 7, 1), EndDate = new DateTime(2012, 7, 3), BaselineStart = new DateTime(2012, 7, 1), BaselineEnd = new DateTime(2012, 7, 3), Complete = 0d, Cost = 23, BaselineCost = 33d, });

            data[0].ChildTask[6].ChildTask.Add(new ProjectStatisticsModel() { Id = 50, Name = "Finishing Electrical", StDate = new DateTime(2012, 7, 3), EndDate = new DateTime(2012, 7, 5), BaselineStart = new DateTime(2012, 7, 3), BaselineEnd = new DateTime(2012, 7, 5), Complete = 0d, Cost = 432, BaselineCost = 536, });
            data[0].ChildTask[6].ChildTask[3].ChildTask.Add(new ProjectStatisticsModel() { Id = 51, Name = "Complete first floor connections", StDate = new DateTime(2012, 7, 3), EndDate = new DateTime(2012, 7, 5), BaselineStart = new DateTime(2012, 7, 3), BaselineEnd = new DateTime(2012, 7, 5), Complete = 0d, Cost = 432, BaselineCost = 536, });
            data[0].ChildTask[6].ChildTask[3].ChildTask.Add(new ProjectStatisticsModel() { Id = 52, Name = "Complete second floor connections", StDate = new DateTime(2012, 7, 5), EndDate = new DateTime(2012, 7, 7), BaselineStart = new DateTime(2012, 7, 4), BaselineEnd = new DateTime(2012, 7, 6), Complete = 0d, Cost = 563, BaselineCost = 463, });
            data[0].ChildTask[6].ChildTask[3].ChildTask.Add(new ProjectStatisticsModel() { Id = 53, Name = "Complete non-Electrical Wiring", StDate = new DateTime(2012, 7, 7), EndDate = new DateTime(2012, 7, 8), BaselineStart = new DateTime(2012, 7, 7), BaselineEnd = new DateTime(2012, 7, 8), Complete = 0d, Cost = 234, BaselineCost = 563, });

            data[0].ChildTask[6].ChildTask.Add(new ProjectStatisticsModel() { Id = 54, Name = "Carpet,Tiles and Furnishing", StDate = new DateTime(2012, 7, 8), EndDate = new DateTime(2012, 7, 10), BaselineStart = new DateTime(2012, 7, 9), BaselineEnd = new DateTime(2012, 7, 11), Complete = 0d, Cost = 253, BaselineCost = 210, });
            data[0].ChildTask[6].ChildTask[4].ChildTask.Add(new ProjectStatisticsModel() { Id = 55, Name = "Complete first floor carpet", StDate = new DateTime(2012, 7, 8), EndDate = new DateTime(2012, 7, 10), BaselineStart = new DateTime(2012, 7, 8), BaselineEnd = new DateTime(2012, 7, 10), Complete = 0d, Cost = 253, BaselineCost = 210, });
            data[0].ChildTask[6].ChildTask[4].ChildTask.Add(new ProjectStatisticsModel() { Id = 56, Name = "Complete second floor carpet", StDate = new DateTime(2012, 7, 10), EndDate = new DateTime(2012, 7, 13), BaselineStart = new DateTime(2012, 7, 10), BaselineEnd = new DateTime(2012, 7, 13), Complete = 0d, Cost = 341, BaselineCost = 300, });
            data[0].ChildTask[6].ChildTask[4].ChildTask.Add(new ProjectStatisticsModel() { Id = 57, Name = "Complete Furnishing Kitchen, bath, hall", StDate = new DateTime(2012, 7, 13), EndDate = new DateTime(2012, 7, 14), BaselineStart = new DateTime(2012, 7, 13), BaselineEnd = new DateTime(2012, 7, 14), Complete = 0, Cost = 4252, BaselineCost = 6033d, });

            data[0].ChildTask.Add(new ProjectStatisticsModel() { Id = 58, Name = "Final Acceptance", StDate = new DateTime(2012, 7, 14), EndDate = new DateTime(2012, 7, 16), BaselineStart = new DateTime(2012, 7, 14), BaselineEnd = new DateTime(2012, 7, 16), Complete = 0d, Cost = 430, BaselineCost = 433d, });
            data[0].ChildTask[7].ChildTask.Add(new ProjectStatisticsModel() { Id = 59, Name = "Cleaning", StDate = new DateTime(2012, 7, 14), EndDate = new DateTime(2012, 7, 16), BaselineStart = new DateTime(2012, 7, 14), BaselineEnd = new DateTime(2012, 7, 16), Complete = 0d, Cost = 430, BaselineCost = 433d, });
            data[0].ChildTask[7].ChildTask.Add(new ProjectStatisticsModel() { Id = 60, Name = "Final Inspection", StDate = new DateTime(2012, 7, 16), EndDate = new DateTime(2012, 7, 17), BaselineStart = new DateTime(2012, 7, 16), BaselineEnd = new DateTime(2012, 7, 17), Complete = 0d, Cost = 0, BaselineCost = 5, });
            data[0].ChildTask[7].ChildTask.Add(new ProjectStatisticsModel() { Id = 61, Name = "Move In", StDate = new DateTime(2012, 7, 17), EndDate = new DateTime(2012, 7, 17), BaselineStart = new DateTime(2012, 7, 18), BaselineEnd = new DateTime(2012, 7, 18), Complete = 0d, Cost = 0, BaselineCost = 0, });


            // Adding Resources
            data[0].ChildTask[0].ChildTask[0].ChildTask[0].Resource.Add(ResidentialConstructionResources[1]);
            data[0].ChildTask[0].ChildTask[0].ChildTask[0].Resource.Add(ResidentialConstructionResources[0]);
            data[0].ChildTask[0].ChildTask[0].ChildTask[0].Resource.Add(ResidentialConstructionResources[2]);

            data[0].ChildTask[0].ChildTask[0].ChildTask[1].Resource.Add(ResidentialConstructionResources[0]);
            data[0].ChildTask[0].ChildTask[0].ChildTask[1].Resource.Add(ResidentialConstructionResources[1]);
            data[0].ChildTask[0].ChildTask[0].ChildTask[1].Resource.Add(ResidentialConstructionResources[2]);

            data[0].ChildTask[1].ChildTask[0].Resource.Add(ResidentialConstructionResources[3]);
            data[0].ChildTask[1].ChildTask[1].Resource.Add(ResidentialConstructionResources[3]);
            data[0].ChildTask[1].ChildTask[2].Resource.Add(ResidentialConstructionResources[5]);
            data[0].ChildTask[1].ChildTask[2].Resource.Add(ResidentialConstructionResources[6]);
            data[0].ChildTask[1].ChildTask[2].Resource.Add(ResidentialConstructionResources[4]);

            data[0].ChildTask[2].ChildTask[0].Resource.Add(ResidentialConstructionResources[3]);
            data[0].ChildTask[2].ChildTask[1].Resource.Add(ResidentialConstructionResources[6]);
            data[0].ChildTask[2].ChildTask[2].Resource.Add(ResidentialConstructionResources[7]);
            data[0].ChildTask[2].ChildTask[3].Resource.Add(ResidentialConstructionResources[3]);

            data[0].ChildTask[3].ChildTask[0].Resource.Add(ResidentialConstructionResources[8]);
            data[0].ChildTask[3].ChildTask[1].Resource.Add(ResidentialConstructionResources[8]);
            data[0].ChildTask[3].ChildTask[2].Resource.Add(ResidentialConstructionResources[9]);
            data[0].ChildTask[3].ChildTask[3].Resource.Add(ResidentialConstructionResources[7]);

            data[0].ChildTask[4].ChildTask[0].Resource.Add(ResidentialConstructionResources[8]);
            data[0].ChildTask[4].ChildTask[1].Resource.Add(ResidentialConstructionResources[9]);
            data[0].ChildTask[4].ChildTask[2].Resource.Add(ResidentialConstructionResources[8]);

            data[0].ChildTask[5].ChildTask[0].Resource.Add(ResidentialConstructionResources[14]);
            data[0].ChildTask[5].ChildTask[1].Resource.Add(ResidentialConstructionResources[8]);

            data[0].ChildTask[6].ChildTask[0].ChildTask[0].Resource.Add(ResidentialConstructionResources[10]);
            data[0].ChildTask[6].ChildTask[0].ChildTask[1].Resource.Add(ResidentialConstructionResources[10]);
            data[0].ChildTask[6].ChildTask[0].ChildTask[2].Resource.Add(ResidentialConstructionResources[10]);

            data[0].ChildTask[6].ChildTask[1].ChildTask[0].Resource.Add(ResidentialConstructionResources[12]);
            data[0].ChildTask[6].ChildTask[1].ChildTask[1].Resource.Add(ResidentialConstructionResources[12]);
            data[0].ChildTask[6].ChildTask[1].ChildTask[2].Resource.Add(ResidentialConstructionResources[12]);

            data[0].ChildTask[6].ChildTask[2].ChildTask[0].Resource.Add(ResidentialConstructionResources[5]);
            data[0].ChildTask[6].ChildTask[2].ChildTask[1].Resource.Add(ResidentialConstructionResources[5]);
            data[0].ChildTask[6].ChildTask[2].ChildTask[2].Resource.Add(ResidentialConstructionResources[7]);

            data[0].ChildTask[6].ChildTask[3].ChildTask[0].Resource.Add(ResidentialConstructionResources[4]);
            data[0].ChildTask[6].ChildTask[3].ChildTask[1].Resource.Add(ResidentialConstructionResources[4]);
            data[0].ChildTask[6].ChildTask[3].ChildTask[2].Resource.Add(ResidentialConstructionResources[4]);

            data[0].ChildTask[6].ChildTask[4].ChildTask[0].Resource.Add(ResidentialConstructionResources[13]);
            data[0].ChildTask[6].ChildTask[4].ChildTask[1].Resource.Add(ResidentialConstructionResources[13]);
            data[0].ChildTask[6].ChildTask[4].ChildTask[2].Resource.Add(ResidentialConstructionResources[14]);

            data[0].ChildTask[7].ChildTask[0].Resource.Add(ResidentialConstructionResources[16]);
            data[0].ChildTask[7].ChildTask[1].Resource.Add(ResidentialConstructionResources[7]);
            data[0].ChildTask[7].ChildTask[2].Resource.Add(ResidentialConstructionResources[1]);

            // Adding Predecessors
            data[0].ChildTask[0].ChildTask[0].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 4, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[0].ChildTask[1].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[0].ChildTask[0].ChildTask[1].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[0].ChildTask[0].ChildTask[1].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[0].ChildTask[0].ChildTask[1].ChildTask[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[0].ChildTask[0].ChildTask[1].ChildTask[4].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });

            data[0].ChildTask[0].ChildTask[2].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[0].ChildTask[0].ChildTask[2].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });
            data[0].ChildTask[0].ChildTask[2].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 5, GanttTaskRelationship = GanttTaskRelationship.FinishToFinish });

            data[0].ChildTask[1].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 13, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[1].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 14, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[1].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 15, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[1].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 17, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[1].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 18, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[2].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 19, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[2].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 21, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[2].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 19, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[2].ChildTask[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 23, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[3].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 24, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[3].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 26, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[3].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 27, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[3].ChildTask[3].Predecessor.Add(new Predecessor() { GanttTaskIndex = 28, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[4].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 29, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[4].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 31, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[4].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 32, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[5].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 33, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[5].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 35, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[6].ChildTask[0].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 36, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[0].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 39, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[0].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 40, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[6].ChildTask[1].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 41, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[1].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 43, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[1].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 44, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[1].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 43, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[6].ChildTask[2].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 45, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[2].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 47, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[2].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 48, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[6].ChildTask[3].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 49, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[3].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 48, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[3].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 51, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[3].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 52, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[6].ChildTask[4].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 53, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[4].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 55, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[6].ChildTask[4].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 56, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            data[0].ChildTask[7].ChildTask[0].Predecessor.Add(new Predecessor() { GanttTaskIndex = 57, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[7].ChildTask[1].Predecessor.Add(new Predecessor() { GanttTaskIndex = 59, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });
            data[0].ChildTask[7].ChildTask[2].Predecessor.Add(new Predecessor() { GanttTaskIndex = 60, GanttTaskRelationship = GanttTaskRelationship.FinishToStart });

            return data;
        }

        private static ObservableCollection<Resource> GetResources()
        {
            ObservableCollection<Resource> Resources = new ObservableCollection<Resource>();
            Resources.Add(new Resource() { ID = 1, Name = "General Contractor" });
            Resources.Add(new Resource() { ID = 2, Name = "Owner" });
            Resources.Add(new Resource() { ID = 3, Name = "Architect" });
            Resources.Add(new Resource() { ID = 4, Name = "Site Excavation Contractor" });
            Resources.Add(new Resource() { ID = 5, Name = "Electrical Contractor" });
            Resources.Add(new Resource() { ID = 6, Name = "Plumbing Contractor" });
            Resources.Add(new Resource() { ID = 7, Name = "Concrete Contractor" });
            Resources.Add(new Resource() { ID = 8, Name = "Inspector" });
            Resources.Add(new Resource() { ID = 9, Name = "Framing Contractor" });
            Resources.Add(new Resource() { ID = 10, Name = "Roofing Contractor" });
            Resources.Add(new Resource() { ID = 11, Name = "Insulation Contractor" });
            Resources.Add(new Resource() { ID = 12, Name = "Drywall contractor" });
            Resources.Add(new Resource() { ID = 13, Name = "Painting Contractor" });
            Resources.Add(new Resource() { ID = 14, Name = "Flooring Contractor" });
            Resources.Add(new Resource() { ID = 15, Name = "Appliance Contractor" });
            Resources.Add(new Resource() { ID = 16, Name = "Masonry Contractor" });
            Resources.Add(new Resource() { ID = 17, Name = "Maid Service" });

            return Resources;
        }

        internal void Dispose()
        {
            foreach(var taskDetail in TaskDetails)
            {
                taskDetail.Dispose();
            }
        }
    }

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
    }
}