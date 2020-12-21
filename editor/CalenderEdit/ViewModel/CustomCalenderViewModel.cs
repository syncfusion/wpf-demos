#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.editordemos.wpf
{
	public class CustomCalenderViewModel
    {
		private SpecialDatesCollection SpecialDaysCollection;

		public CustomCalenderViewModel()
		{
			specialDays = new SpecialDatesCollection();
			PopulateData();
		}

		private void PopulateData()
		{
			ResourceDictionary resourceDictionary = new ResourceDictionary() { Source = new Uri("/syncfusion.editordemos.wpf;component/Assets/CalenderEdit/CalendarEditTemplate.xaml", UriKind.RelativeOrAbsolute) };
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 1, 15, 0, 0, 0, 0), CellTemplate = resourceDictionary["ArmyDay"] as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 2, 4, 0, 0, 0, 0), CellTemplate = resourceDictionary["WorldCancerDay"] as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 2, 14, 0, 0, 0, 0), CellTemplate = resourceDictionary["Valentine Day"] as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 3, 8, 0, 0, 0, 0), CellTemplate = resourceDictionary["WomensDay"] as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 4, 7, 0, 0, 0, 0), CellTemplate = resourceDictionary["WorldHealthDay"] as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 5, 1, 0, 0, 0, 0), CellTemplate = resourceDictionary["WorkersDay"] as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 6, 5, 0, 0, 0, 0), CellTemplate = resourceDictionary["WorldEnvironmentDay"] as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 7, 1, 0, 0, 0, 0), CellTemplate = resourceDictionary["DoctorsDay"] as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 8, 29, 0, 0, 0, 0), CellTemplate = resourceDictionary["NationalSportsDay"] as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 9, 15, 0, 0, 0, 0), CellTemplate = resourceDictionary["EngineersDay"] as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 10, 9, 0, 0, 0, 0), CellTemplate = resourceDictionary["WorldPostOfficeDay"] as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 10, 16, 0, 0, 0, 0), CellTemplate = resourceDictionary["WorldFoodDay"] as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 11, 14, 0, 0, 0, 0), CellTemplate = resourceDictionary["ChildrensDay"] as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2020, 12, 25, 0, 0, 0, 0), CellTemplate = resourceDictionary["Christmas"] as DataTemplate });

			CalendarEditMouseMove = new DelegateCommand(CalendarEditMouseMoveMethod);
		}

		public SpecialDatesCollection specialDays
		{
			get { return SpecialDaysCollection; }
			set { SpecialDaysCollection = value; }
		}

		public ICommand CalendarEditMouseMove
		{
			get;
			private set;
		}

		private void CalendarEditMouseMoveMethod(object obj)
		{
			var calendarEdit = obj as CalendarEdit;
			Date day1 = new Date(2020, 1, 15);
			Date day2 = new Date(2020, 2, 4);
			Date day3 = new Date(2020, 2, 14);
			Date day4 = new Date(2020, 3, 8);
			Date day5 = new Date(2020, 4, 7);
			Date day6 = new Date(2020, 5, 1);
			Date day7 = new Date(2020, 6, 5);
			Date day8 = new Date(2020, 7, 1);
			Date day9 = new Date(2020, 8, 29);
			Date day10 = new Date(2020, 9, 15);
			Date day11 = new Date(2020, 10, 9);
			Date day12 = new Date(2020, 10, 16);
			Date day13 = new Date(2020, 11, 14);
			Date day14 = new Date(2020, 12, 25);

			if (day1 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Army Day";
				calendarEdit.SetToolTip(day1, toolTip);
			}

			if (day2 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Cancer Day";
				calendarEdit.SetToolTip(day2, toolTip);
			}

			if (day3 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Valentine Day";
				calendarEdit.SetToolTip(day3, toolTip);
			}
			
			if (day4 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "International Women’s Day";
				calendarEdit.SetToolTip(day4, toolTip);
			}
		
			if (day5 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Health Day";
				calendarEdit.SetToolTip(day5, toolTip);
			}
			
			if (day6 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Workers’ Day";
				calendarEdit.SetToolTip(day6, toolTip);
			}
			
			if (day7 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Environment Day";
				calendarEdit.SetToolTip(day7, toolTip);
			}

			if (day8 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Doctor’s Day";
				calendarEdit.SetToolTip(day8, toolTip);
			}

			if (day9 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "National Sports Day";
				calendarEdit.SetToolTip(day9, toolTip);
			}

			if (day10 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Engineer's Day";
				calendarEdit.SetToolTip(day10, toolTip);
			}
			
			if (day11 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Post Office Day";
				calendarEdit.SetToolTip(day11, toolTip);
			}

			if (day12 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "World Food Day";
				calendarEdit.SetToolTip(day12, toolTip);
			}
			
			if (day13 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Children’s Day";
				calendarEdit.SetToolTip(day13, toolTip);
			}

			if (day14 != null)
			{
				ToolTip toolTip = new ToolTip();
				toolTip.Content = "Christmas";
				calendarEdit.SetToolTip(day14, toolTip);
			}
		}
	}
}
