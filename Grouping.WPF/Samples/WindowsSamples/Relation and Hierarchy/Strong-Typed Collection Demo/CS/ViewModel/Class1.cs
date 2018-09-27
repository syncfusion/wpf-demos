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
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Text;
using Syncfusion;
using Syncfusion.Grouping;

using Syncfusion.Collections;
using Syncfusion.Drawing;
using Syncfusion.ComponentModel;

namespace StrongTypedCollectionSample
{
	public class Class1
	{
		private Syncfusion.Grouping.Engine engine1;

		public Class1()
		{
			engine1 = new Engine();

			CustomerCollection customers = PopulateCustomers.CreateCustomers();

			this.engine1.SetSourceList(customers);

			RelationDescriptorCollection relations = new RelationDescriptorCollection();

			// First level
			RelationDescriptor rd = AddRelation("Level_0", relations);

			// Subsequent levels
			for (int level = 1; level < 5; level++)
			{
				rd = AddRelation("Level_" + level.ToString(), rd.ChildTableDescriptor.Relations);
			}

			this.engine1.TableDescriptor.Relations.InitializeFrom(relations);

			this.engine1.Table.ExpandAllRecords();
		}

		RelationDescriptor AddRelation(string name, RelationDescriptorCollection relations)
		{
			RelationDescriptor children = new RelationDescriptor();
			children.RelationKind = RelationKind.UniformChildList;
			children.MappingName = "Children";
			children.Name = name;
			relations.Add(children);
			return children;
		}


		public static void Main()
		{
			Class1 c = new Class1();
			c.Run();

			Console.WriteLine("Please press <Enter> to continue.");
			Console.ReadLine();
		}

		public void Run()
		{
			foreach (Element el in engine1.Table.NestedDisplayElements)
			{
				Console.WriteLine(el.ToString());
			}
		}

	}
}
