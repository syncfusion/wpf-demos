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

namespace ManualRelations
{
	public class Class1 
	{
		private Syncfusion.Grouping.Engine engine1;

		public Class1()
		{
			engine1 = new Engine();
	
			DataTable parentTable = GetParentTable();
			DataTable childTable = GetChildTable();
			DataTable grandChildTable = GetGrandChildTable();

			// Manually specify relations in grouping engine. The DataSet does not need to have any DataRelations.
			// This is the same approach that should be used if you want to set up relation ships
			// between independent IList.
			RelationDescriptor parentToChildRelationDescriptor = new RelationDescriptor();
			parentToChildRelationDescriptor.ChildTableName = "MyChildTable";    // same as SourceListSetEntry.Name for childTable (see below)
			parentToChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;
			parentToChildRelationDescriptor.RelationKeys.Add("parentID", "ParentID");

			// Add relation to ParentTable 
			engine1.TableDescriptor.Relations.Add(parentToChildRelationDescriptor);

			RelationDescriptor childToGrandChildRelationDescriptor = new RelationDescriptor();
			childToGrandChildRelationDescriptor.ChildTableName = "MyGrandChildTable";  // same as SourceListSetEntry.Name for grandChhildTable (see below)
			childToGrandChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails;
			childToGrandChildRelationDescriptor.RelationKeys.Add("childID", "ChildID");

			// Add relation to ChildTable 
			parentToChildRelationDescriptor.ChildTableDescriptor.Relations.Add(childToGrandChildRelationDescriptor);

			// Register any DataTable/IList with SourceListSet, so that RelationDescriptor can resolve the name
			this.engine1.SourceListSet.Add("MyParentTable", parentTable);
			this.engine1.SourceListSet.Add("MyChildTable", childTable);
			this.engine1.SourceListSet.Add("MyGrandChildTable", grandChildTable);

			this.engine1.SetSourceList(parentTable.DefaultView);
		}

			
		private int numberParentRows = 5;
		private int numberChildRows = 20;
		private int numberGrandChildRows = 50;
		private DataTable GetParentTable()
		{
			DataTable dt = new DataTable("ParentTable");

			
			dt.Columns.Add(new DataColumn("parentID")); //lower case p
			dt.Columns.Add(new DataColumn("ParentName"));
			dt.Columns.Add(new DataColumn("ParentDec"));

			for(int i = 0; i < numberParentRows; i++)
			{
				DataRow dr = dt.NewRow();
				dr[0] = i;//.ToString();
				dr[1] = string.Format("parentName{0}", i);
				dr[1] = string.Format("parentName{0}", i);
				dt.Rows.Add(dr);
			}

			return dt;
		}

		private DataTable GetChildTable()
		{
			DataTable dt = new DataTable("ChildTable");

			dt.Columns.Add(new DataColumn("childID")); //lower case c
			dt.Columns.Add(new DataColumn("Name"));
			dt.Columns.Add(new DataColumn("ParentID")); //upper case P
			
			for(int i = 0; i < numberChildRows; i++)
			{
				DataRow dr = dt.NewRow();
				dr[0] = i.ToString();
				dr[1] = string.Format("ChildName{0}",i);
				dr[2] = (i % numberParentRows).ToString();
				dt.Rows.Add(dr);
			}
		
			return dt;
		}

		private DataTable GetGrandChildTable()
		{
			DataTable dt = new DataTable("GrandChildTable");

			dt.Columns.Add(new DataColumn("GrandChildID"));
			dt.Columns.Add(new DataColumn("Name"));
			dt.Columns.Add(new DataColumn("ChildID")); //upper case C
			
			for(int i = 0; i < numberGrandChildRows; i++)
			{
				DataRow dr = dt.NewRow();
				dr[0] = i.ToString();
				dr[1] = string.Format("GrandChildName{0}",i);
				dr[2] = (i % numberChildRows).ToString();
				dt.Rows.Add(dr);
			}
			
			return dt;
		}
     

		public void Run()
		{
			engine1.Table.ExpandAllRecords();
			foreach (Element el in engine1.Table.NestedDisplayElements)
			{
				Console.WriteLine(el.ToString());
			}
		}
	}
}
