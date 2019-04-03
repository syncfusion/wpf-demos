#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;

namespace LookAndFeel
{
	public class ViewModel
	{
		public ViewModel()
		{
			specialDays = new SpecialDatesCollection();
			PopulateData();
		}

		private void PopulateData()
		{
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 1, 12, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("NationalYouthDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 1, 15, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("ArmyDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 2, 4, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WorldCancerDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 2, 14, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("Valentine Day") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 12, 2, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("PollutionPreventionDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 3, 8, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WomensDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 3, 21, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WorldForestryDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 3, 24, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WorldDayforWater") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 4, 7, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WorldHealthDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 4, 22, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("EarthDay") as DataTemplate });

			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 5, 1, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WorkersDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 5, 31, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("Anti-tobaccoDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 6, 5, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WorldEnvironmentDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 6, 14, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WorldBloodDonorDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 6, 21, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("DayofYoga") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 7, 1, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("DoctorsDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 8, 6, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("HiroshimaDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 8, 19, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("PhotographyDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 8, 29, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("NationalSportsDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 9, 15, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("EngineersDay") as DataTemplate });

			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 9, 16, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WorldOzoneDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 9, 27, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WorldTourismDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 10, 9, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WorldPostOfficeDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 10, 16, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WorldFoodDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 11, 5, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WorldTsunamiDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 11, 14, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("ChildrensDay") as DataTemplate });

			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 12, 1, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("WorldAIDSDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 12, 22, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("NationalMathematicsDay") as DataTemplate });
			specialDays.Add(new SpecialDate() { Date = new System.DateTime(2018, 12, 25, 0, 0, 0, 0), CellTemplate = System.Windows.Application.Current.TryFindResource("Christmas") as DataTemplate });
			

		}
		private SpecialDatesCollection SpecialDaysCollection;
		public SpecialDatesCollection specialDays
		{
			get { return SpecialDaysCollection; }
			set { SpecialDaysCollection = value; }
		}

	}
	
}
