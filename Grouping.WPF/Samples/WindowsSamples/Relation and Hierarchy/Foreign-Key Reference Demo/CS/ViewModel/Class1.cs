#region Copyright Syncfusion Inc. 2001 - 2006
//
//  Copyright Syncfusion Inc. 2001 - 2006. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;

using Syncfusion.Grouping;

namespace ForeignKeyReference
{
	public class Class1
	{
		private Syncfusion.Grouping.Engine engine1;

		public Class1()
		{
			engine1 = new Engine();

			USStatesCollection usStates = USStatesCollection.CreateDefaultCollection();
			CountriesCollection countries = CountriesCollection.CreateDefaultCollection();

			this.engine1.SourceListSet.Add("Countries", countries);
			this.engine1.SourceListSet.Add("USStates", usStates);

			DataTable table = new DataTable();
			table.Columns.Add("Id", typeof(string));
			table.Columns.Add("Country", typeof(string));
			table.Columns.Add("State", typeof(string));

			// and then add a few rows:
			for ( int i=0; i < 50; i++ )
			{
				table.Rows.Add(table.NewRow());
				table.Rows[i][0] = i;
				table.Rows[i][1] = countries[i%8].CountryCode;
				table.Rows[i][2] = usStates[i%8].Key;
			}

			TableDescriptor mainTd = this.engine1.TableDescriptor;

			RelationDescriptor usStatesRd = new RelationDescriptor();
			usStatesRd.Name = "State";
			usStatesRd.RelationKind = RelationKind.ForeignKeyReference;
			usStatesRd.ChildTableName = "USStates";  // SourceListSet name for lookup
			usStatesRd.RelationKeys.Add("State", "Key");
			usStatesRd.ChildTableDescriptor.SortedColumns.Add("Name");
			usStatesRd.ChildTableDescriptor.AllowEdit = false;
			usStatesRd.ChildTableDescriptor.AllowNew = false;  // Make pencil icon disappear, users can't modify states.
			mainTd.Relations.Add(usStatesRd);

			RelationDescriptor countriesRd = new RelationDescriptor();
			//countriesRd.Name = "Country";  - default will be ChildTableName = "Countries"
			countriesRd.RelationKind = RelationKind.ForeignKeyReference;
			countriesRd.ChildTableName = "Countries";  // SourceListSet name for lookup
			countriesRd.RelationKeys.Add("Country", "CountryCode");
			countriesRd.ChildTableDescriptor.AllowEdit = true;
			countriesRd.ChildTableDescriptor.AllowNew = true;  // Make pencil icon appear, allow user to add countries (these setting will be overriden by CountriesCollection.IsReadOnly / CountriesCollection.IsFixedSize properties if they are true).
			mainTd.Relations.Add(countriesRd);


			this.engine1.SetSourceList(table.DefaultView);
			mainTd.Name = "ForeignKeyReference";
		}

		

		public void Run()
		{
			foreach (Record r in engine1.Table.FilteredRecords)
			{
				// Print record fields
				Console.WriteLine(r.ToString());

				Console.WriteLine(r.GetValue("State_Name"));

				// Get related record in foreign table.
				RelationDescriptor usStatesRd = r.ParentTableDescriptor.Relations["State"];
				Record relatedRecord = r.GetRelatedRecord(usStatesRd);
				Console.WriteLine(relatedRecord.GetValue("Name"));
			}
		}
	}
}
