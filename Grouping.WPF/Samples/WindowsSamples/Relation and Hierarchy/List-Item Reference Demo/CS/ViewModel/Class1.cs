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

namespace ListItemReference
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
			table.Columns.Add("Country", typeof(Country));
			table.Columns.Add("State", typeof(USState));

			// and then add a few rows:
			for ( int i=0; i < 50; i++ )
			{
				table.Rows.Add(table.NewRow());
				table.Rows[i][0] = i;
				table.Rows[i][1] = countries[i%8];
				if (i%8 == 0)
					table.Rows[i][2] = usStates[i/8];
			}

			TableDescriptor mainTd = this.engine1.TableDescriptor;
			//mainTd.Fields.ExpandProperties = false;

			RelationDescriptor usStatesRd = new RelationDescriptor();
			usStatesRd.Name = "State";
			usStatesRd.MappingName = "State";  // FieldName in table
			usStatesRd.ChildTableName = "USStates";  // SourceListSet name for lookup
			usStatesRd.RelationKind = RelationKind.ListItemReference;
			usStatesRd.ChildTableDescriptor.SortedColumns.Add("Name");
			//usStatesRd.ChildTableDescriptor.AllowEdit = false;
			//usStatesRd.ChildTableDescriptor.AllowNew = false;  // users can't modify states.
			mainTd.Relations.Add(usStatesRd);

			RelationDescriptor countriesRd = new RelationDescriptor();
			countriesRd.Name = "Country";
			countriesRd.MappingName = "Country";  // FieldName in table
			countriesRd.ChildTableName = "Countries";  // SourceListSet name for lookup
			countriesRd.RelationKind = RelationKind.ListItemReference;
			countriesRd.ChildTableDescriptor.AllowEdit = true;
			countriesRd.ChildTableDescriptor.AllowNew = true;  // allow user to add countries (these setting will be overriden by CountriesCollection.IsReadOnly / CountriesCollection.IsFixedSize properties if they are true).
			mainTd.Relations.Add(countriesRd);
			this.engine1.SetSourceList(table.DefaultView);
		}

        //public static void Main()
        //{
			
        //}

		public void Run()
		{
			foreach (Record r in engine1.Table.FilteredRecords)
			{
				// Print record fields
				Console.WriteLine(r.ToString());

				Console.WriteLine(r.GetValue("State_Name"));

				// Get related record in foreign table.
				RelationDescriptor usStatesRd = r.ParentTableDescriptor.Relations["State"];
				if (!(r.GetValue("State") is DBNull))
				{
					USState state = (USState) r.GetValue("State");
					Console.WriteLine(state.Name);
				}
			}
		}
	}
}
