#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.Windows.Controls.Gantt;
using Syncfusion.Windows.Controls.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public class ProjectStatisticsBehavior : Behavior<StatisticsWindow>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var view = AssociatedObject.DataContext as StatisticsViewModel;
            var Info = view.ProjectInformation as ProjectInfo;
            var Model = AssociatedObject.Grid.Model as GridModel;

            AssociatedObject.headerText.Text = "Project AssociatedObject for \'" + Info.ProjectName + "\'";
            Model.RowCount = 10;
            Model.ColumnCount = 3;
            AssociatedObject.Grid.SetColumnWidth(0, 160);
            AssociatedObject.Grid.SetColumnWidth(1, 180);
            AssociatedObject.Grid.SetColumnWidth(2, 180);

            // Disable all mouse related actions in Grid
            AssociatedObject.Grid.MouseControllerDispatcher.Clear();

            // Declaring Header cells
            Model[0, 1].Text = "Start ";
            Model[0, 1].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[0, 2].Text = "Finish ";
            Model[0, 2].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[1, 0].Text = "Current ";
            Model[1, 0].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[2, 0].Text = "Baseline ";
            Model[2, 0].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[3, 0].Text = "Actual ";
            Model[3, 0].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[4, 0].Text = "Variance ";
            Model[4, 0].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[5, 1].Text = "Duration ";
            Model[5, 1].Background = (Brush)(new BrushConverter().ConvertFromString("#FFF0F0F0"));
            Model[5, 1].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Model[5, 1].Font.FontWeight = FontWeights.Bold;

            Model[5, 2].Text = "Cost ";
            Model[5, 2].Background = (Brush)(new BrushConverter().ConvertFromString("#FFF0F0F0"));
            Model[5, 2].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Model[5, 2].Font.FontWeight = FontWeights.Bold;

            Model[6, 0].Text = "Current ";
            Model[6, 0].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[7, 0].Text = "Baseline ";
            Model[7, 0].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[8, 0].Text = "Actual ";
            Model[8, 0].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[9, 0].Text = "Remaining ";
            Model[9, 0].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            //// The following are for displaying the Data from ProjectInfo Instance.

            AssociatedObject.Title = "Project AssociatedObject for " + "\'" + Info.ProjectName + "\'";

            // Start Date
            Model[1, 1].Text = Info.StartDate == DateTime.MinValue ? "NA" : Info.StartDate.ToString("MM/dd/yyyy");
            Model[1, 1].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[2, 1].Text = Info.BaselineStart == DateTime.MinValue ? "NA" : Info.BaselineStart.ToString("MM/dd/yyyy");
            Model[2, 1].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[3, 1].Text = Info.ActualStartDate == DateTime.MinValue ? "NA" : Info.ActualStartDate.ToString("MM/dd/yyyy");
            Model[3, 1].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[4, 1].Text = Info.StartVariance.Days.ToString() + " Days";
            Model[4, 1].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            // Finish Date
            Model[1, 2].Text = Info.FinishDate == DateTime.MinValue ? "NA" : Info.FinishDate.ToString("MM/dd/yyyy");
            Model[1, 2].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[2, 2].Text = Info.BaselineFinish == DateTime.MinValue ? "NA" : Info.BaselineFinish.ToString("MM/dd/yyyy");
            Model[2, 2].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[3, 2].Text = Info.ActualFinishDate == DateTime.MinValue ? "NA" : Info.ActualFinishDate.ToString("MM/dd/yyyy");
            Model[3, 2].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[4, 2].Text = Info.FinishVariance.Days.ToString() + " Days";
            Model[4, 2].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            // Duration 
            Model[6, 1].Text = Math.Round(Info.Duration.TotalDays, 2).ToString() + " Days";
            Model[6, 1].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[7, 1].Text = Math.Round(Info.BaselineDuration.TotalDays, 2).ToString() + " Days";
            Model[7, 1].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[8, 1].Text = Math.Round(Info.ActualDuration.TotalDays, 2).ToString() + " Days";
            Model[8, 1].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[9, 1].Text = Math.Round(Info.RemainingDuration.TotalDays, 2).ToString() + " Days";
            Model[9, 1].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;


            // Cost
            Model[6, 2].Text = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol.ToString() + Info.Cost.ToString();
            Model[6, 2].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[7, 2].Text = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol.ToString() + Info.BaselineCost.ToString();
            Model[7, 2].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[8, 2].Text = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol.ToString() + Info.ActualCost.ToString();
            Model[8, 2].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model[9, 2].Text = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol.ToString() + Info.RemainingCost.ToString();
            Model[9, 2].HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            Model.TableStyle.CellType = "Static";
            Model.HeaderStyle.Font.FontWeight = FontWeights.Bold;
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }
    }
}
